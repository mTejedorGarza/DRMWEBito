using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.MR_Tarjetas;
using Spartane.Core.Domain.Tipo_de_Tarjeta;
using Spartane.Core.Domain.Estatus;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.MR_Tarjetas;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.MR_Tarjetas;
using Spartane.Web.Areas.WebApiConsumer.Tipo_de_Tarjeta;
using Spartane.Web.Areas.WebApiConsumer.Estatus;

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
    public class MR_TarjetasController : Controller
    {
        #region "variable declaration"

        private IMR_TarjetasService service = null;
        private IMR_TarjetasApiConsumer _IMR_TarjetasApiConsumer;
        private ITipo_de_TarjetaApiConsumer _ITipo_de_TarjetaApiConsumer;
        private IEstatusApiConsumer _IEstatusApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public MR_TarjetasController(IMR_TarjetasService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IMR_TarjetasApiConsumer MR_TarjetasApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , ITipo_de_TarjetaApiConsumer Tipo_de_TarjetaApiConsumer , IEstatusApiConsumer EstatusApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IMR_TarjetasApiConsumer = MR_TarjetasApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ITipo_de_TarjetaApiConsumer = Tipo_de_TarjetaApiConsumer;
            this._IEstatusApiConsumer = EstatusApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/MR_Tarjetas
        [ObjectAuth(ObjectId = (ModuleObjectId)44790, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44790);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/MR_Tarjetas/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44790, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44790);
            ViewBag.Permission = permission;
            var varMR_Tarjetas = new MR_TarjetasModel();
			
            ViewBag.ObjectId = "44790";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMR_TarjetasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var MR_TarjetasData = _IMR_TarjetasApiConsumer.GetByKeyComplete(Id).Resource.MR_Tarjetass[0];
                if (MR_TarjetasData == null)
                    return HttpNotFound();

                varMR_Tarjetas = new MR_TarjetasModel
                {
                    Folio = (int)MR_TarjetasData.Folio
                    ,Tipo_de_Tarjeta = MR_TarjetasData.Tipo_de_Tarjeta
                    ,Tipo_de_TarjetaDescripcion = CultureHelper.GetTraduction(Convert.ToString(MR_TarjetasData.Tipo_de_Tarjeta), "Tipo_de_Tarjeta") ??  (string)MR_TarjetasData.Tipo_de_Tarjeta_Tipo_de_Tarjeta.Descripcion
                    ,Numero_de_Tarjeta = MR_TarjetasData.Numero_de_Tarjeta
                    ,Nombre_del_Titular = MR_TarjetasData.Nombre_del_Titular
                    ,Ano_de_vigencia = MR_TarjetasData.Ano_de_vigencia
                    ,Mes_de_vigencia = MR_TarjetasData.Mes_de_vigencia
                    ,Alias_de_la_Tarjeta = MR_TarjetasData.Alias_de_la_Tarjeta
                    ,Estatus = MR_TarjetasData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(MR_TarjetasData.Estatus), "Estatus") ??  (string)MR_TarjetasData.Estatus_Estatus.Descripcion

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ITipo_de_TarjetaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Tarjetas_Tipo_de_Tarjeta = _ITipo_de_TarjetaApiConsumer.SelAll(true);
            if (Tipo_de_Tarjetas_Tipo_de_Tarjeta != null && Tipo_de_Tarjetas_Tipo_de_Tarjeta.Resource != null)
                ViewBag.Tipo_de_Tarjetas_Tipo_de_Tarjeta = Tipo_de_Tarjetas_Tipo_de_Tarjeta.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Tarjeta", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varMR_Tarjetas);
        }
		
	[HttpGet]
        public ActionResult AddMR_Tarjetas(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44790);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IMR_TarjetasApiConsumer.SetAuthHeader(_tokenManager.Token);
			MR_TarjetasModel varMR_Tarjetas= new MR_TarjetasModel();


            if (id.ToString() != "0")
            {
                var MR_TarjetassData = _IMR_TarjetasApiConsumer.ListaSelAll(0, 1000, "MR_Tarjetas.Folio=" + id, "").Resource.MR_Tarjetass;
				
				if (MR_TarjetassData != null && MR_TarjetassData.Count > 0)
                {
					var MR_TarjetasData = MR_TarjetassData.First();
					varMR_Tarjetas= new MR_TarjetasModel
					{
						Folio  = MR_TarjetasData.Folio 
	                    ,Tipo_de_Tarjeta = MR_TarjetasData.Tipo_de_Tarjeta
                    ,Tipo_de_TarjetaDescripcion = CultureHelper.GetTraduction(Convert.ToString(MR_TarjetasData.Tipo_de_Tarjeta), "Tipo_de_Tarjeta") ??  (string)MR_TarjetasData.Tipo_de_Tarjeta_Tipo_de_Tarjeta.Descripcion
                    ,Numero_de_Tarjeta = MR_TarjetasData.Numero_de_Tarjeta
                    ,Nombre_del_Titular = MR_TarjetasData.Nombre_del_Titular
                    ,Ano_de_vigencia = MR_TarjetasData.Ano_de_vigencia
                    ,Mes_de_vigencia = MR_TarjetasData.Mes_de_vigencia
                    ,Alias_de_la_Tarjeta = MR_TarjetasData.Alias_de_la_Tarjeta
                    ,Estatus = MR_TarjetasData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(MR_TarjetasData.Estatus), "Estatus") ??  (string)MR_TarjetasData.Estatus_Estatus.Descripcion

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ITipo_de_TarjetaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Tarjetas_Tipo_de_Tarjeta = _ITipo_de_TarjetaApiConsumer.SelAll(true);
            if (Tipo_de_Tarjetas_Tipo_de_Tarjeta != null && Tipo_de_Tarjetas_Tipo_de_Tarjeta.Resource != null)
                ViewBag.Tipo_de_Tarjetas_Tipo_de_Tarjeta = Tipo_de_Tarjetas_Tipo_de_Tarjeta.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Tarjeta", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddMR_Tarjetas", varMR_Tarjetas);
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
        public ActionResult GetTipo_de_TarjetaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipo_de_TarjetaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipo_de_TarjetaApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Tarjeta", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetEstatusAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstatusApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion")?? m.Descripcion,
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
                configuration = GridQueryHelper.GetConfiguration(filter, new MR_TarjetasPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IMR_TarjetasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MR_Tarjetass == null)
                result.MR_Tarjetass = new List<MR_Tarjetas>();

            return Json(new
            {
                data = result.MR_Tarjetass.Select(m => new MR_TarjetasGridModel
                    {
                    Folio = m.Folio
                        ,Tipo_de_TarjetaDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Tarjeta_Tipo_de_Tarjeta.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Tarjeta_Tipo_de_Tarjeta.Descripcion
			,Numero_de_Tarjeta = m.Numero_de_Tarjeta
			,Nombre_del_Titular = m.Nombre_del_Titular
			,Ano_de_vigencia = m.Ano_de_vigencia
			,Mes_de_vigencia = m.Mes_de_vigencia
			,Alias_de_la_Tarjeta = m.Alias_de_la_Tarjeta
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion

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
                _IMR_TarjetasApiConsumer.SetAuthHeader(_tokenManager.Token);

                MR_Tarjetas varMR_Tarjetas = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IMR_TarjetasApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, MR_TarjetasModel varMR_Tarjetas)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IMR_TarjetasApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var MR_TarjetasInfo = new MR_Tarjetas
                    {
                        Folio = varMR_Tarjetas.Folio
                        ,Tipo_de_Tarjeta = varMR_Tarjetas.Tipo_de_Tarjeta
                        ,Numero_de_Tarjeta = varMR_Tarjetas.Numero_de_Tarjeta
                        ,Nombre_del_Titular = varMR_Tarjetas.Nombre_del_Titular
                        ,Ano_de_vigencia = varMR_Tarjetas.Ano_de_vigencia
                        ,Mes_de_vigencia = varMR_Tarjetas.Mes_de_vigencia
                        ,Alias_de_la_Tarjeta = varMR_Tarjetas.Alias_de_la_Tarjeta
                        ,Estatus = varMR_Tarjetas.Estatus

                    };

                    result = !IsNew ?
                        _IMR_TarjetasApiConsumer.Update(MR_TarjetasInfo, null, null).Resource.ToString() :
                         _IMR_TarjetasApiConsumer.Insert(MR_TarjetasInfo, null, null).Resource.ToString();

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
        /// Write Element Array of MR_Tarjetas script
        /// </summary>
        /// <param name="oMR_TarjetasElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements MR_TarjetasModuleAttributeList)
        {
            for (int i = 0; i < MR_TarjetasModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(MR_TarjetasModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    MR_TarjetasModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(MR_TarjetasModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    MR_TarjetasModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (MR_TarjetasModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < MR_TarjetasModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(MR_TarjetasModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						MR_TarjetasModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(MR_TarjetasModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						MR_TarjetasModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strMR_TarjetasScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/MR_Tarjetas.js")))
            {
                strMR_TarjetasScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change MR_Tarjetas element attributes
            string userChangeJson = jsSerialize.Serialize(MR_TarjetasModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strMR_TarjetasScript.IndexOf("inpuElementArray");
            string splittedString = strMR_TarjetasScript.Substring(indexOfArray, strMR_TarjetasScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(MR_TarjetasModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (MR_TarjetasModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strMR_TarjetasScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strMR_TarjetasScript.Substring(indexOfArrayHistory, strMR_TarjetasScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strMR_TarjetasScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strMR_TarjetasScript.Substring(endIndexOfMainElement + indexOfArray, strMR_TarjetasScript.Length - (endIndexOfMainElement + indexOfArray));
            if (MR_TarjetasModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strMR_TarjetasScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strMR_TarjetasScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strMR_TarjetasScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strMR_TarjetasScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/MR_Tarjetas.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/MR_Tarjetas.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/MR_Tarjetas.js")))
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
        public ActionResult MR_TarjetasPropertyBag()
        {
            return PartialView("MR_TarjetasPropertyBag", "MR_Tarjetas");
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

            _IMR_TarjetasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new MR_TarjetasPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMR_TarjetasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MR_Tarjetass == null)
                result.MR_Tarjetass = new List<MR_Tarjetas>();

            var data = result.MR_Tarjetass.Select(m => new MR_TarjetasGridModel
            {
                Folio = m.Folio
                ,Tipo_de_TarjetaDescripcion = (string)m.Tipo_de_Tarjeta_Tipo_de_Tarjeta.Descripcion
                ,Numero_de_Tarjeta = m.Numero_de_Tarjeta
                ,Nombre_del_Titular = m.Nombre_del_Titular
                ,Ano_de_vigencia = m.Ano_de_vigencia
                ,Mes_de_vigencia = m.Mes_de_vigencia
                ,Alias_de_la_Tarjeta = m.Alias_de_la_Tarjeta
                ,EstatusDescripcion = (string)m.Estatus_Estatus.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "MR_TarjetasList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "MR_TarjetasList_" + DateTime.Now.ToString());
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

            _IMR_TarjetasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new MR_TarjetasPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMR_TarjetasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MR_Tarjetass == null)
                result.MR_Tarjetass = new List<MR_Tarjetas>();

            var data = result.MR_Tarjetass.Select(m => new MR_TarjetasGridModel
            {
                Folio = m.Folio
                ,Tipo_de_TarjetaDescripcion = (string)m.Tipo_de_Tarjeta_Tipo_de_Tarjeta.Descripcion
                ,Numero_de_Tarjeta = m.Numero_de_Tarjeta
                ,Nombre_del_Titular = m.Nombre_del_Titular
                ,Ano_de_vigencia = m.Ano_de_vigencia
                ,Mes_de_vigencia = m.Mes_de_vigencia
                ,Alias_de_la_Tarjeta = m.Alias_de_la_Tarjeta
                ,EstatusDescripcion = (string)m.Estatus_Estatus.Descripcion

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
