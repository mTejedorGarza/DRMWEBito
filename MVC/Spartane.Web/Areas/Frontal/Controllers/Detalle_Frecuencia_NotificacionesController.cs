using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Detalle_Frecuencia_Notificaciones;
using Spartane.Core.Domain.Tipo_Frecuencia_Notificacion;
using Spartane.Core.Domain.Tipo_Dia_Notificacion;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Detalle_Frecuencia_Notificaciones;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Frecuencia_Notificaciones;
using Spartane.Web.Areas.WebApiConsumer.Tipo_Frecuencia_Notificacion;
using Spartane.Web.Areas.WebApiConsumer.Tipo_Dia_Notificacion;

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
    public class Detalle_Frecuencia_NotificacionesController : Controller
    {
        #region "variable declaration"

        private IDetalle_Frecuencia_NotificacionesService service = null;
        private IDetalle_Frecuencia_NotificacionesApiConsumer _IDetalle_Frecuencia_NotificacionesApiConsumer;
        private ITipo_Frecuencia_NotificacionApiConsumer _ITipo_Frecuencia_NotificacionApiConsumer;
        private ITipo_Dia_NotificacionApiConsumer _ITipo_Dia_NotificacionApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Detalle_Frecuencia_NotificacionesController(IDetalle_Frecuencia_NotificacionesService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDetalle_Frecuencia_NotificacionesApiConsumer Detalle_Frecuencia_NotificacionesApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , ITipo_Frecuencia_NotificacionApiConsumer Tipo_Frecuencia_NotificacionApiConsumer , ITipo_Dia_NotificacionApiConsumer Tipo_Dia_NotificacionApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDetalle_Frecuencia_NotificacionesApiConsumer = Detalle_Frecuencia_NotificacionesApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ITipo_Frecuencia_NotificacionApiConsumer = Tipo_Frecuencia_NotificacionApiConsumer;
            this._ITipo_Dia_NotificacionApiConsumer = Tipo_Dia_NotificacionApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Detalle_Frecuencia_Notificaciones
        [ObjectAuth(ObjectId = (ModuleObjectId)44696, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44696);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Detalle_Frecuencia_Notificaciones/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44696, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44696);
            ViewBag.Permission = permission;
            var varDetalle_Frecuencia_Notificaciones = new Detalle_Frecuencia_NotificacionesModel();
			
            ViewBag.ObjectId = "44696";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Frecuencia_NotificacionesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Detalle_Frecuencia_NotificacionesData = _IDetalle_Frecuencia_NotificacionesApiConsumer.GetByKeyComplete(Id).Resource.Detalle_Frecuencia_Notificacioness[0];
                if (Detalle_Frecuencia_NotificacionesData == null)
                    return HttpNotFound();

                varDetalle_Frecuencia_Notificaciones = new Detalle_Frecuencia_NotificacionesModel
                {
                    Folio = (int)Detalle_Frecuencia_NotificacionesData.Folio
                    ,Frecuencia = Detalle_Frecuencia_NotificacionesData.Frecuencia
                    ,FrecuenciaDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Frecuencia_NotificacionesData.Frecuencia), "Tipo_Frecuencia_Notificacion") ??  (string)Detalle_Frecuencia_NotificacionesData.Frecuencia_Tipo_Frecuencia_Notificacion.Descripcion
                    ,Dia = Detalle_Frecuencia_NotificacionesData.Dia
                    ,DiaDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Frecuencia_NotificacionesData.Dia), "Tipo_Dia_Notificacion") ??  (string)Detalle_Frecuencia_NotificacionesData.Dia_Tipo_Dia_Notificacion.Descripcion
                    ,Hora = Detalle_Frecuencia_NotificacionesData.Hora

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ITipo_Frecuencia_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_Frecuencia_Notificacions_Frecuencia = _ITipo_Frecuencia_NotificacionApiConsumer.SelAll(true);
            if (Tipo_Frecuencia_Notificacions_Frecuencia != null && Tipo_Frecuencia_Notificacions_Frecuencia.Resource != null)
                ViewBag.Tipo_Frecuencia_Notificacions_Frecuencia = Tipo_Frecuencia_Notificacions_Frecuencia.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Frecuencia_Notificacion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipo_Dia_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_Dia_Notificacions_Dia = _ITipo_Dia_NotificacionApiConsumer.SelAll(true);
            if (Tipo_Dia_Notificacions_Dia != null && Tipo_Dia_Notificacions_Dia.Resource != null)
                ViewBag.Tipo_Dia_Notificacions_Dia = Tipo_Dia_Notificacions_Dia.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Dia_Notificacion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varDetalle_Frecuencia_Notificaciones);
        }
		
	[HttpGet]
        public ActionResult AddDetalle_Frecuencia_Notificaciones(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44696);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDetalle_Frecuencia_NotificacionesApiConsumer.SetAuthHeader(_tokenManager.Token);
			Detalle_Frecuencia_NotificacionesModel varDetalle_Frecuencia_Notificaciones= new Detalle_Frecuencia_NotificacionesModel();


            if (id.ToString() != "0")
            {
                var Detalle_Frecuencia_NotificacionessData = _IDetalle_Frecuencia_NotificacionesApiConsumer.ListaSelAll(0, 1000, "Detalle_Frecuencia_Notificaciones.Folio=" + id, "").Resource.Detalle_Frecuencia_Notificacioness;
				
				if (Detalle_Frecuencia_NotificacionessData != null && Detalle_Frecuencia_NotificacionessData.Count > 0)
                {
					var Detalle_Frecuencia_NotificacionesData = Detalle_Frecuencia_NotificacionessData.First();
					varDetalle_Frecuencia_Notificaciones= new Detalle_Frecuencia_NotificacionesModel
					{
						Folio  = Detalle_Frecuencia_NotificacionesData.Folio 
	                    ,Frecuencia = Detalle_Frecuencia_NotificacionesData.Frecuencia
                    ,FrecuenciaDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Frecuencia_NotificacionesData.Frecuencia), "Tipo_Frecuencia_Notificacion") ??  (string)Detalle_Frecuencia_NotificacionesData.Frecuencia_Tipo_Frecuencia_Notificacion.Descripcion
                    ,Dia = Detalle_Frecuencia_NotificacionesData.Dia
                    ,DiaDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Frecuencia_NotificacionesData.Dia), "Tipo_Dia_Notificacion") ??  (string)Detalle_Frecuencia_NotificacionesData.Dia_Tipo_Dia_Notificacion.Descripcion
                    ,Hora = Detalle_Frecuencia_NotificacionesData.Hora

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ITipo_Frecuencia_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_Frecuencia_Notificacions_Frecuencia = _ITipo_Frecuencia_NotificacionApiConsumer.SelAll(true);
            if (Tipo_Frecuencia_Notificacions_Frecuencia != null && Tipo_Frecuencia_Notificacions_Frecuencia.Resource != null)
                ViewBag.Tipo_Frecuencia_Notificacions_Frecuencia = Tipo_Frecuencia_Notificacions_Frecuencia.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Frecuencia_Notificacion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipo_Dia_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_Dia_Notificacions_Dia = _ITipo_Dia_NotificacionApiConsumer.SelAll(true);
            if (Tipo_Dia_Notificacions_Dia != null && Tipo_Dia_Notificacions_Dia.Resource != null)
                ViewBag.Tipo_Dia_Notificacions_Dia = Tipo_Dia_Notificacions_Dia.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Dia_Notificacion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddDetalle_Frecuencia_Notificaciones", varDetalle_Frecuencia_Notificaciones);
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
        public ActionResult GetTipo_Frecuencia_NotificacionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipo_Frecuencia_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipo_Frecuencia_NotificacionApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Frecuencia_Notificacion", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetTipo_Dia_NotificacionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipo_Dia_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipo_Dia_NotificacionApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Dia_Notificacion", "Descripcion")?? m.Descripcion,
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Frecuencia_NotificacionesPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDetalle_Frecuencia_NotificacionesApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Frecuencia_Notificacioness == null)
                result.Detalle_Frecuencia_Notificacioness = new List<Detalle_Frecuencia_Notificaciones>();

            return Json(new
            {
                data = result.Detalle_Frecuencia_Notificacioness.Select(m => new Detalle_Frecuencia_NotificacionesGridModel
                    {
                    Folio = m.Folio
                        ,FrecuenciaDescripcion = CultureHelper.GetTraduction(m.Frecuencia_Tipo_Frecuencia_Notificacion.Clave.ToString(), "Descripcion") ?? (string)m.Frecuencia_Tipo_Frecuencia_Notificacion.Descripcion
                        ,DiaDescripcion = CultureHelper.GetTraduction(m.Dia_Tipo_Dia_Notificacion.Clave.ToString(), "Descripcion") ?? (string)m.Dia_Tipo_Dia_Notificacion.Descripcion
			,Hora = m.Hora

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
                _IDetalle_Frecuencia_NotificacionesApiConsumer.SetAuthHeader(_tokenManager.Token);

                Detalle_Frecuencia_Notificaciones varDetalle_Frecuencia_Notificaciones = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDetalle_Frecuencia_NotificacionesApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Detalle_Frecuencia_NotificacionesModel varDetalle_Frecuencia_Notificaciones)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDetalle_Frecuencia_NotificacionesApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Detalle_Frecuencia_NotificacionesInfo = new Detalle_Frecuencia_Notificaciones
                    {
                        Folio = varDetalle_Frecuencia_Notificaciones.Folio
                        ,Frecuencia = varDetalle_Frecuencia_Notificaciones.Frecuencia
                        ,Dia = varDetalle_Frecuencia_Notificaciones.Dia
                        ,Hora = varDetalle_Frecuencia_Notificaciones.Hora

                    };

                    result = !IsNew ?
                        _IDetalle_Frecuencia_NotificacionesApiConsumer.Update(Detalle_Frecuencia_NotificacionesInfo, null, null).Resource.ToString() :
                         _IDetalle_Frecuencia_NotificacionesApiConsumer.Insert(Detalle_Frecuencia_NotificacionesInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Detalle_Frecuencia_Notificaciones script
        /// </summary>
        /// <param name="oDetalle_Frecuencia_NotificacionesElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Detalle_Frecuencia_NotificacionesModuleAttributeList)
        {
            for (int i = 0; i < Detalle_Frecuencia_NotificacionesModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Detalle_Frecuencia_NotificacionesModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Detalle_Frecuencia_NotificacionesModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Detalle_Frecuencia_NotificacionesModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Detalle_Frecuencia_NotificacionesModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Detalle_Frecuencia_NotificacionesModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Detalle_Frecuencia_NotificacionesModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Detalle_Frecuencia_NotificacionesModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Detalle_Frecuencia_NotificacionesModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Detalle_Frecuencia_NotificacionesModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Detalle_Frecuencia_NotificacionesModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strDetalle_Frecuencia_NotificacionesScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Frecuencia_Notificaciones.js")))
            {
                strDetalle_Frecuencia_NotificacionesScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Detalle_Frecuencia_Notificaciones element attributes
            string userChangeJson = jsSerialize.Serialize(Detalle_Frecuencia_NotificacionesModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDetalle_Frecuencia_NotificacionesScript.IndexOf("inpuElementArray");
            string splittedString = strDetalle_Frecuencia_NotificacionesScript.Substring(indexOfArray, strDetalle_Frecuencia_NotificacionesScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Detalle_Frecuencia_NotificacionesModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Detalle_Frecuencia_NotificacionesModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDetalle_Frecuencia_NotificacionesScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strDetalle_Frecuencia_NotificacionesScript.Substring(indexOfArrayHistory, strDetalle_Frecuencia_NotificacionesScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strDetalle_Frecuencia_NotificacionesScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDetalle_Frecuencia_NotificacionesScript.Substring(endIndexOfMainElement + indexOfArray, strDetalle_Frecuencia_NotificacionesScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Detalle_Frecuencia_NotificacionesModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strDetalle_Frecuencia_NotificacionesScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strDetalle_Frecuencia_NotificacionesScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strDetalle_Frecuencia_NotificacionesScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strDetalle_Frecuencia_NotificacionesScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Detalle_Frecuencia_Notificaciones.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Detalle_Frecuencia_Notificaciones.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Frecuencia_Notificaciones.js")))
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
        public ActionResult Detalle_Frecuencia_NotificacionesPropertyBag()
        {
            return PartialView("Detalle_Frecuencia_NotificacionesPropertyBag", "Detalle_Frecuencia_Notificaciones");
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

            _IDetalle_Frecuencia_NotificacionesApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Frecuencia_NotificacionesPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Frecuencia_NotificacionesApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Frecuencia_Notificacioness == null)
                result.Detalle_Frecuencia_Notificacioness = new List<Detalle_Frecuencia_Notificaciones>();

            var data = result.Detalle_Frecuencia_Notificacioness.Select(m => new Detalle_Frecuencia_NotificacionesGridModel
            {
                Folio = m.Folio
                ,FrecuenciaDescripcion = (string)m.Frecuencia_Tipo_Frecuencia_Notificacion.Descripcion
                ,DiaDescripcion = (string)m.Dia_Tipo_Dia_Notificacion.Descripcion
                ,Hora = m.Hora

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Detalle_Frecuencia_NotificacionesList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Detalle_Frecuencia_NotificacionesList_" + DateTime.Now.ToString());
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

            _IDetalle_Frecuencia_NotificacionesApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Frecuencia_NotificacionesPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Frecuencia_NotificacionesApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Frecuencia_Notificacioness == null)
                result.Detalle_Frecuencia_Notificacioness = new List<Detalle_Frecuencia_Notificaciones>();

            var data = result.Detalle_Frecuencia_Notificacioness.Select(m => new Detalle_Frecuencia_NotificacionesGridModel
            {
                Folio = m.Folio
                ,FrecuenciaDescripcion = (string)m.Frecuencia_Tipo_Frecuencia_Notificacion.Descripcion
                ,DiaDescripcion = (string)m.Dia_Tipo_Dia_Notificacion.Descripcion
                ,Hora = m.Hora

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
