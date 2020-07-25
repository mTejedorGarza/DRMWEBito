using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.MR_Detalle_Platillo;
using Spartane.Core.Domain.Ingredientes;
using Spartane.Core.Domain.Unidades_de_Medida;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.MR_Detalle_Platillo;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.MR_Detalle_Platillo;
using Spartane.Web.Areas.WebApiConsumer.Ingredientes;
using Spartane.Web.Areas.WebApiConsumer.Unidades_de_Medida;

using Spartane.Web.AuthFilters;
using Spartane.Web.Helpers;
using Spartane.Web.Models;
using Spartane.Web.SqlModelMapper;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using System.IO;
using Newtonsoft.Json;
using Spartane.Core.Domain.Spartan_Business_Rule;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Business_Rule;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Process_Event_Detail;

namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class MR_Detalle_PlatilloController : Controller
    {
        #region "variable declaration"

        private IMR_Detalle_PlatilloService service = null;
        private IMR_Detalle_PlatilloApiConsumer _IMR_Detalle_PlatilloApiConsumer;
        private IIngredientesApiConsumer _IIngredientesApiConsumer;
        private IUnidades_de_MedidaApiConsumer _IUnidades_de_MedidaApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public MR_Detalle_PlatilloController(IMR_Detalle_PlatilloService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IMR_Detalle_PlatilloApiConsumer MR_Detalle_PlatilloApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , IIngredientesApiConsumer IngredientesApiConsumer , IUnidades_de_MedidaApiConsumer Unidades_de_MedidaApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IMR_Detalle_PlatilloApiConsumer = MR_Detalle_PlatilloApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._IIngredientesApiConsumer = IngredientesApiConsumer;
            this._IUnidades_de_MedidaApiConsumer = Unidades_de_MedidaApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/MR_Detalle_Platillo
        [ObjectAuth(ObjectId = (ModuleObjectId)44723, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44723);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/MR_Detalle_Platillo/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44723, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44723);
            ViewBag.Permission = permission;
            var varMR_Detalle_Platillo = new MR_Detalle_PlatilloModel();
			
            ViewBag.ObjectId = "44723";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMR_Detalle_PlatilloApiConsumer.SetAuthHeader(_tokenManager.Token);
                var MR_Detalle_PlatilloData = _IMR_Detalle_PlatilloApiConsumer.GetByKeyComplete(Id).Resource.MR_Detalle_Platillos[0];
                if (MR_Detalle_PlatilloData == null)
                    return HttpNotFound();

                varMR_Detalle_Platillo = new MR_Detalle_PlatilloModel
                {
                    Folio = (int)MR_Detalle_PlatilloData.Folio
                    ,Ingrediente = MR_Detalle_PlatilloData.Ingrediente
                    ,IngredienteNombre_Ingrediente = CultureHelper.GetTraduction(Convert.ToString(MR_Detalle_PlatilloData.Ingrediente), "Ingredientes") ??  (string)MR_Detalle_PlatilloData.Ingrediente_Ingredientes.Nombre_Ingrediente
                    ,Cantidad = MR_Detalle_PlatilloData.Cantidad
                    ,Cantidad_en_Fraccion = MR_Detalle_PlatilloData.Cantidad_en_Fraccion
                    ,Unidad = MR_Detalle_PlatilloData.Unidad
                    ,UnidadUnidad = CultureHelper.GetTraduction(Convert.ToString(MR_Detalle_PlatilloData.Unidad), "Unidades_de_Medida") ??  (string)MR_Detalle_PlatilloData.Unidad_Unidades_de_Medida.Unidad
                    ,Cantidad_a_mostrar = MR_Detalle_PlatilloData.Cantidad_a_mostrar
                    ,Ingrediente_a_mostrar = MR_Detalle_PlatilloData.Ingrediente_a_mostrar

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IIngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Ingredientess_Ingrediente = _IIngredientesApiConsumer.SelAll(true);
            if (Ingredientess_Ingrediente != null && Ingredientess_Ingrediente.Resource != null)
                ViewBag.Ingredientess_Ingrediente = Ingredientess_Ingrediente.Resource.Where(m => m.Nombre_Ingrediente != null).OrderBy(m => m.Nombre_Ingrediente).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Ingredientes", "Nombre_Ingrediente") ?? m.Nombre_Ingrediente.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IUnidades_de_MedidaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Unidades_de_Medidas_Unidad = _IUnidades_de_MedidaApiConsumer.SelAll(true);
            if (Unidades_de_Medidas_Unidad != null && Unidades_de_Medidas_Unidad.Resource != null)
                ViewBag.Unidades_de_Medidas_Unidad = Unidades_de_Medidas_Unidad.Resource.Where(m => m.Unidad != null).OrderBy(m => m.Unidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Unidades_de_Medida", "Unidad") ?? m.Unidad.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varMR_Detalle_Platillo);
        }
		
	[HttpGet]
        public ActionResult AddMR_Detalle_Platillo(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44723);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IMR_Detalle_PlatilloApiConsumer.SetAuthHeader(_tokenManager.Token);
			MR_Detalle_PlatilloModel varMR_Detalle_Platillo= new MR_Detalle_PlatilloModel();


            if (id.ToString() != "0")
            {
                var MR_Detalle_PlatillosData = _IMR_Detalle_PlatilloApiConsumer.ListaSelAll(0, 1000, "MR_Detalle_Platillo.Folio=" + id, "").Resource.MR_Detalle_Platillos;
				
				if (MR_Detalle_PlatillosData != null && MR_Detalle_PlatillosData.Count > 0)
                {
					var MR_Detalle_PlatilloData = MR_Detalle_PlatillosData.First();
					varMR_Detalle_Platillo= new MR_Detalle_PlatilloModel
					{
						Folio  = MR_Detalle_PlatilloData.Folio 
	                    ,Ingrediente = MR_Detalle_PlatilloData.Ingrediente
                    ,IngredienteNombre_Ingrediente = CultureHelper.GetTraduction(Convert.ToString(MR_Detalle_PlatilloData.Ingrediente), "Ingredientes") ??  (string)MR_Detalle_PlatilloData.Ingrediente_Ingredientes.Nombre_Ingrediente
                    ,Cantidad = MR_Detalle_PlatilloData.Cantidad
                    ,Cantidad_en_Fraccion = MR_Detalle_PlatilloData.Cantidad_en_Fraccion
                    ,Unidad = MR_Detalle_PlatilloData.Unidad
                    ,UnidadUnidad = CultureHelper.GetTraduction(Convert.ToString(MR_Detalle_PlatilloData.Unidad), "Unidades_de_Medida") ??  (string)MR_Detalle_PlatilloData.Unidad_Unidades_de_Medida.Unidad
                    ,Cantidad_a_mostrar = MR_Detalle_PlatilloData.Cantidad_a_mostrar
                    ,Ingrediente_a_mostrar = MR_Detalle_PlatilloData.Ingrediente_a_mostrar

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IIngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Ingredientess_Ingrediente = _IIngredientesApiConsumer.SelAll(true);
            if (Ingredientess_Ingrediente != null && Ingredientess_Ingrediente.Resource != null)
                ViewBag.Ingredientess_Ingrediente = Ingredientess_Ingrediente.Resource.Where(m => m.Nombre_Ingrediente != null).OrderBy(m => m.Nombre_Ingrediente).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Ingredientes", "Nombre_Ingrediente") ?? m.Nombre_Ingrediente.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IUnidades_de_MedidaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Unidades_de_Medidas_Unidad = _IUnidades_de_MedidaApiConsumer.SelAll(true);
            if (Unidades_de_Medidas_Unidad != null && Unidades_de_Medidas_Unidad.Resource != null)
                ViewBag.Unidades_de_Medidas_Unidad = Unidades_de_Medidas_Unidad.Resource.Where(m => m.Unidad != null).OrderBy(m => m.Unidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Unidades_de_Medida", "Unidad") ?? m.Unidad.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddMR_Detalle_Platillo", varMR_Detalle_Platillo);
        }


        [HttpGet]
        public FileResult GetFile(int id)
        {

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var fileInfo = _ISpartane_FileApiConsumer.GetByKey(id).Resource;
            if (fileInfo == null)
                return null;
            return File(fileInfo.File, System.Net.Mime.MediaTypeNames.Application.Octet, fileInfo.Description);
        }

        [HttpGet]
        public ActionResult GetIngredientesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IIngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IIngredientesApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Nombre_Ingrediente).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Ingredientes", "Nombre_Ingrediente")?? m.Nombre_Ingrediente,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetUnidades_de_MedidaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IUnidades_de_MedidaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IUnidades_de_MedidaApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Unidad).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Unidades_de_Medida", "Unidad")?? m.Unidad,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }



        public ActionResult Get()
        {
            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new MR_Detalle_PlatilloPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IMR_Detalle_PlatilloApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MR_Detalle_Platillos == null)
                result.MR_Detalle_Platillos = new List<MR_Detalle_Platillo>();

            return Json(new
            {
                data = result.MR_Detalle_Platillos.Select(m => new MR_Detalle_PlatilloGridModel
                    {
                    Folio = m.Folio
                        ,IngredienteNombre_Ingrediente = CultureHelper.GetTraduction(m.Ingrediente_Ingredientes.Clave.ToString(), "Nombre_Ingrediente") ?? (string)m.Ingrediente_Ingredientes.Nombre_Ingrediente
			,Cantidad = m.Cantidad
			,Cantidad_en_Fraccion = m.Cantidad_en_Fraccion
                        ,UnidadUnidad = CultureHelper.GetTraduction(m.Unidad_Unidades_de_Medida.Clave.ToString(), "Unidad") ?? (string)m.Unidad_Unidades_de_Medida.Unidad
			,Cantidad_a_mostrar = m.Cantidad_a_mostrar
			,Ingrediente_a_mostrar = m.Ingrediente_a_mostrar

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }







       

        [NonAction]
        public Grid_File ConvertSpartane_FileToGridFile(Spartane.Core.Domain.Spartane_File.Spartane_File file)
        {
            return file == null ? new Grid_File { FileId = 0, FileSize = 0, FileName = "" } : new Grid_File { FileId = file.File_Id, FileName = file.Description, FileSize = file.File_Size ?? 0, };
        }



        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMR_Detalle_PlatilloApiConsumer.SetAuthHeader(_tokenManager.Token);

                MR_Detalle_Platillo varMR_Detalle_Platillo = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IMR_Detalle_PlatilloApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, MR_Detalle_PlatilloModel varMR_Detalle_Platillo)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IMR_Detalle_PlatilloApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var MR_Detalle_PlatilloInfo = new MR_Detalle_Platillo
                    {
                        Folio = varMR_Detalle_Platillo.Folio
                        ,Ingrediente = varMR_Detalle_Platillo.Ingrediente
                        ,Cantidad = varMR_Detalle_Platillo.Cantidad
                        ,Cantidad_en_Fraccion = varMR_Detalle_Platillo.Cantidad_en_Fraccion
                        ,Unidad = varMR_Detalle_Platillo.Unidad
                        ,Cantidad_a_mostrar = varMR_Detalle_Platillo.Cantidad_a_mostrar
                        ,Ingrediente_a_mostrar = varMR_Detalle_Platillo.Ingrediente_a_mostrar

                    };

                    result = !IsNew ?
                        _IMR_Detalle_PlatilloApiConsumer.Update(MR_Detalle_PlatilloInfo, null, null).Resource.ToString() :
                         _IMR_Detalle_PlatilloApiConsumer.Insert(MR_Detalle_PlatilloInfo, null, null).Resource.ToString();

                    return Json(result, JsonRequestBehavior.AllowGet);
				}
				return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }



        /// <summary>
        /// Write Element Array of MR_Detalle_Platillo script
        /// </summary>
        /// <param name="oMR_Detalle_PlatilloElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements MR_Detalle_PlatilloModuleAttributeList)
        {
            for (int i = 0; i < MR_Detalle_PlatilloModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(MR_Detalle_PlatilloModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    MR_Detalle_PlatilloModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(MR_Detalle_PlatilloModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    MR_Detalle_PlatilloModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (MR_Detalle_PlatilloModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < MR_Detalle_PlatilloModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(MR_Detalle_PlatilloModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						MR_Detalle_PlatilloModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(MR_Detalle_PlatilloModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						MR_Detalle_PlatilloModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strMR_Detalle_PlatilloScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/MR_Detalle_Platillo.js")))
            {
                strMR_Detalle_PlatilloScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change MR_Detalle_Platillo element attributes
            string userChangeJson = jsSerialize.Serialize(MR_Detalle_PlatilloModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strMR_Detalle_PlatilloScript.IndexOf("inpuElementArray");
            string splittedString = strMR_Detalle_PlatilloScript.Substring(indexOfArray, strMR_Detalle_PlatilloScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(MR_Detalle_PlatilloModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (MR_Detalle_PlatilloModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strMR_Detalle_PlatilloScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strMR_Detalle_PlatilloScript.Substring(indexOfArrayHistory, strMR_Detalle_PlatilloScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strMR_Detalle_PlatilloScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strMR_Detalle_PlatilloScript.Substring(endIndexOfMainElement + indexOfArray, strMR_Detalle_PlatilloScript.Length - (endIndexOfMainElement + indexOfArray));
            if (MR_Detalle_PlatilloModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strMR_Detalle_PlatilloScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strMR_Detalle_PlatilloScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strMR_Detalle_PlatilloScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strMR_Detalle_PlatilloScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/MR_Detalle_Platillo.js")))
            {
                w.WriteLine(finalResponse);
            }
            
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        

        [HttpPost]
        public JsonResult ReadScriptSettings()
        {
            string strCustomScript = string.Empty;
            
            CustomElementAttribute oCustomElementAttribute = new CustomElementAttribute();

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/MR_Detalle_Platillo.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/MR_Detalle_Platillo.js")))
                {
                    strCustomScript = r.ReadToEnd();
                
                }

                int indexOfArray = strCustomScript.IndexOf("inpuElementArray");
                string splittedString = strCustomScript.Substring(indexOfArray, strCustomScript.Length - indexOfArray);                
                int indexOfMainElement = splittedString.IndexOf('[');                
                int endIndexOfMainElement = splittedString.IndexOf(']') + 1;                
                string mainJsonArray = splittedString.Substring(indexOfMainElement, endIndexOfMainElement - indexOfMainElement);

                int indexOfChildArray = strCustomScript.IndexOf("inpuElementChildArray");
				string childJsonArray = "";
                if (indexOfChildArray != -1)
                {
					string splittedChildString = strCustomScript.Substring(indexOfChildArray, strCustomScript.Length - indexOfChildArray);
					int indexOfChildElement = splittedChildString.IndexOf('[');
					int endIndexOfChildElement = splittedChildString.IndexOf(']') + 1;
					childJsonArray = splittedChildString.Substring(indexOfChildElement, endIndexOfChildElement - indexOfChildElement);
				}
                var MainElementList = JsonConvert.DeserializeObject(mainJsonArray);
                var ChildElementList = JsonConvert.DeserializeObject(childJsonArray);

                oCustomElementAttribute.MainElement = MainElementList.ToString();
				if (indexOfChildArray != -1)
                {
					oCustomElementAttribute.ChildElement = ChildElementList.ToString();
				}
            }
            else
            {
                oCustomElementAttribute.MainElement = string.Empty;
                oCustomElementAttribute.ChildElement = string.Empty;
            }        
            return Json(oCustomElementAttribute, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult MR_Detalle_PlatilloPropertyBag()
        {
            return PartialView("MR_Detalle_PlatilloPropertyBag", "MR_Detalle_Platillo");
        }
		
		public List<Spartan_Business_Rule> GetBusinessRules(int ObjectId, int Attribute)
        {
            if (!_tokenManager.GenerateToken())
                return null;
            List<Spartan_Business_Rule> result = new List<Spartan_Business_Rule>();
            _ISpartan_Business_RuleApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (Attribute != 0)
            {
                result = _ISpartan_Business_RuleApiConsumer.ListaSelAll(0, 1000, "Object = " + ObjectId + " AND Attribute = " + Attribute, "").Resource.Spartan_Business_Rules;
            }
            else
            {
                List<Spartan_Business_Rule> partialResult = _ISpartan_Business_RuleApiConsumer.ListaSelAll(0, 1000, "Object = " + ObjectId, "").Resource.Spartan_Business_Rules;
                foreach (var item in partialResult)
                {
                    if (item.Attribute == Attribute)
                    {
                        result.Add(item);
                    }
                    else//Busco las reglas con el event process en cuestion
                    {
                        _ISpartan_BR_Process_Event_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                        var eventProcess = _ISpartan_BR_Process_Event_DetailApiConsumer.ListaSelAll(0, 1000, "Business_Rule = " + item.BusinessRuleId, "").Resource;
                        if (Attribute == 0 && eventProcess.Spartan_BR_Process_Event_Details.Where(x => x.Process_Event == 1).Count() > 0)
                        {
                            result.Add(item);
                        }
                        if ((Attribute == 2) && eventProcess.Spartan_BR_Process_Event_Details.Where(x => x.Process_Event == 2 || x.Process_Event == 3).Count() > 0)
                        {
                            result.Add(item);
                        }
                        if ((Attribute == 3) && eventProcess.Spartan_BR_Process_Event_Details.Where(x => x.Process_Event == 4 || x.Process_Event == 5).Count() > 0)
                        {
                            result.Add(item);
                        }
                        //TODO Faltan en la base de datos cuando creas una row de grilla
                    }
                }
            }
            return result;
        }



        #endregion "Controller Methods"

        #region "Custom methods"

        [HttpGet]
        public void Export(string format, int pageIndex, int pageSize)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);

            if (!_tokenManager.GenerateToken())
                return;

            _IMR_Detalle_PlatilloApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new MR_Detalle_PlatilloPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMR_Detalle_PlatilloApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MR_Detalle_Platillos == null)
                result.MR_Detalle_Platillos = new List<MR_Detalle_Platillo>();

            var data = result.MR_Detalle_Platillos.Select(m => new MR_Detalle_PlatilloGridModel
            {
                Folio = m.Folio
                ,IngredienteNombre_Ingrediente = (string)m.Ingrediente_Ingredientes.Nombre_Ingrediente
                ,Cantidad = m.Cantidad
                ,Cantidad_en_Fraccion = m.Cantidad_en_Fraccion
                ,UnidadUnidad = (string)m.Unidad_Unidades_de_Medida.Unidad
                ,Cantidad_a_mostrar = m.Cantidad_a_mostrar
                ,Ingrediente_a_mostrar = m.Ingrediente_a_mostrar

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "MR_Detalle_PlatilloList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "MR_Detalle_PlatilloList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(), "EmployeeList_" + DateTime.Now.ToString());
                    break;
            }
        }

        [HttpGet]
        //[ObjectAuth(ObjectId = ModuleObjectId.EMPLEADOS_OBJECT, PermissionType = PermissionTypes.Export)]
        public ActionResult Print(string format, int pageIndex, int pageSize)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);

            if (!_tokenManager.GenerateToken())
                return null;

            _IMR_Detalle_PlatilloApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new MR_Detalle_PlatilloPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMR_Detalle_PlatilloApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MR_Detalle_Platillos == null)
                result.MR_Detalle_Platillos = new List<MR_Detalle_Platillo>();

            var data = result.MR_Detalle_Platillos.Select(m => new MR_Detalle_PlatilloGridModel
            {
                Folio = m.Folio
                ,IngredienteNombre_Ingrediente = (string)m.Ingrediente_Ingredientes.Nombre_Ingrediente
                ,Cantidad = m.Cantidad
                ,Cantidad_en_Fraccion = m.Cantidad_en_Fraccion
                ,UnidadUnidad = (string)m.Unidad_Unidades_de_Medida.Unidad
                ,Cantidad_a_mostrar = m.Cantidad_a_mostrar
                ,Ingrediente_a_mostrar = m.Ingrediente_a_mostrar

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
