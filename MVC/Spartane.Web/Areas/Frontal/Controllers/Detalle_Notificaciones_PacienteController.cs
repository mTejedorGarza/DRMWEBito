using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Detalle_Notificaciones_Paciente;
using Spartane.Core.Domain.Funcionalidades_para_Notificacion;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Detalle_Notificaciones_Paciente;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Notificaciones_Paciente;
using Spartane.Web.Areas.WebApiConsumer.Funcionalidades_para_Notificacion;

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
    public class Detalle_Notificaciones_PacienteController : Controller
    {
        #region "variable declaration"

        private IDetalle_Notificaciones_PacienteService service = null;
        private IDetalle_Notificaciones_PacienteApiConsumer _IDetalle_Notificaciones_PacienteApiConsumer;
        private IFuncionalidades_para_NotificacionApiConsumer _IFuncionalidades_para_NotificacionApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Detalle_Notificaciones_PacienteController(IDetalle_Notificaciones_PacienteService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDetalle_Notificaciones_PacienteApiConsumer Detalle_Notificaciones_PacienteApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , IFuncionalidades_para_NotificacionApiConsumer Funcionalidades_para_NotificacionApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDetalle_Notificaciones_PacienteApiConsumer = Detalle_Notificaciones_PacienteApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._IFuncionalidades_para_NotificacionApiConsumer = Funcionalidades_para_NotificacionApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Detalle_Notificaciones_Paciente
        [ObjectAuth(ObjectId = (ModuleObjectId)44695, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44695);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Detalle_Notificaciones_Paciente/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44695, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44695);
            ViewBag.Permission = permission;
            var varDetalle_Notificaciones_Paciente = new Detalle_Notificaciones_PacienteModel();
			
            ViewBag.ObjectId = "44695";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Notificaciones_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Detalle_Notificaciones_PacienteData = _IDetalle_Notificaciones_PacienteApiConsumer.GetByKeyComplete(Id).Resource.Detalle_Notificaciones_Pacientes[0];
                if (Detalle_Notificaciones_PacienteData == null)
                    return HttpNotFound();

                varDetalle_Notificaciones_Paciente = new Detalle_Notificaciones_PacienteModel
                {
                    Folio = (int)Detalle_Notificaciones_PacienteData.Folio
                    ,Funcionalidad = Detalle_Notificaciones_PacienteData.Funcionalidad
                    ,FuncionalidadFuncionalidad = CultureHelper.GetTraduction(Convert.ToString(Detalle_Notificaciones_PacienteData.Funcionalidad), "Funcionalidades_para_Notificacion") ??  (string)Detalle_Notificaciones_PacienteData.Funcionalidad_Funcionalidades_para_Notificacion.Funcionalidad

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IFuncionalidades_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Funcionalidades_para_Notificacions_Funcionalidad = _IFuncionalidades_para_NotificacionApiConsumer.SelAll(true);
            if (Funcionalidades_para_Notificacions_Funcionalidad != null && Funcionalidades_para_Notificacions_Funcionalidad.Resource != null)
                ViewBag.Funcionalidades_para_Notificacions_Funcionalidad = Funcionalidades_para_Notificacions_Funcionalidad.Resource.Where(m => m.Funcionalidad != null).OrderBy(m => m.Funcionalidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Funcionalidades_para_Notificacion", "Funcionalidad") ?? m.Funcionalidad.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varDetalle_Notificaciones_Paciente);
        }
		
	[HttpGet]
        public ActionResult AddDetalle_Notificaciones_Paciente(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44695);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDetalle_Notificaciones_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
			Detalle_Notificaciones_PacienteModel varDetalle_Notificaciones_Paciente= new Detalle_Notificaciones_PacienteModel();


            if (id.ToString() != "0")
            {
                var Detalle_Notificaciones_PacientesData = _IDetalle_Notificaciones_PacienteApiConsumer.ListaSelAll(0, 1000, "Detalle_Notificaciones_Paciente.Folio=" + id, "").Resource.Detalle_Notificaciones_Pacientes;
				
				if (Detalle_Notificaciones_PacientesData != null && Detalle_Notificaciones_PacientesData.Count > 0)
                {
					var Detalle_Notificaciones_PacienteData = Detalle_Notificaciones_PacientesData.First();
					varDetalle_Notificaciones_Paciente= new Detalle_Notificaciones_PacienteModel
					{
						Folio  = Detalle_Notificaciones_PacienteData.Folio 
	                    ,Funcionalidad = Detalle_Notificaciones_PacienteData.Funcionalidad
                    ,FuncionalidadFuncionalidad = CultureHelper.GetTraduction(Convert.ToString(Detalle_Notificaciones_PacienteData.Funcionalidad), "Funcionalidades_para_Notificacion") ??  (string)Detalle_Notificaciones_PacienteData.Funcionalidad_Funcionalidades_para_Notificacion.Funcionalidad

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IFuncionalidades_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Funcionalidades_para_Notificacions_Funcionalidad = _IFuncionalidades_para_NotificacionApiConsumer.SelAll(true);
            if (Funcionalidades_para_Notificacions_Funcionalidad != null && Funcionalidades_para_Notificacions_Funcionalidad.Resource != null)
                ViewBag.Funcionalidades_para_Notificacions_Funcionalidad = Funcionalidades_para_Notificacions_Funcionalidad.Resource.Where(m => m.Funcionalidad != null).OrderBy(m => m.Funcionalidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Funcionalidades_para_Notificacion", "Funcionalidad") ?? m.Funcionalidad.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            return PartialView("AddDetalle_Notificaciones_Paciente", varDetalle_Notificaciones_Paciente);
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
        public ActionResult GetFuncionalidades_para_NotificacionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IFuncionalidades_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IFuncionalidades_para_NotificacionApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Funcionalidad).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Funcionalidades_para_Notificacion", "Funcionalidad")?? m.Funcionalidad,
                    Value = Convert.ToString(m.Folio)
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Notificaciones_PacientePropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDetalle_Notificaciones_PacienteApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Notificaciones_Pacientes == null)
                result.Detalle_Notificaciones_Pacientes = new List<Detalle_Notificaciones_Paciente>();

            return Json(new
            {
                data = result.Detalle_Notificaciones_Pacientes.Select(m => new Detalle_Notificaciones_PacienteGridModel
                    {
                    Folio = m.Folio
                        ,FuncionalidadFuncionalidad = CultureHelper.GetTraduction(m.Funcionalidad_Funcionalidades_para_Notificacion.Folio.ToString(), "Funcionalidad") ?? (string)m.Funcionalidad_Funcionalidades_para_Notificacion.Funcionalidad

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
                _IDetalle_Notificaciones_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);

                Detalle_Notificaciones_Paciente varDetalle_Notificaciones_Paciente = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDetalle_Notificaciones_PacienteApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Detalle_Notificaciones_PacienteModel varDetalle_Notificaciones_Paciente)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDetalle_Notificaciones_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Detalle_Notificaciones_PacienteInfo = new Detalle_Notificaciones_Paciente
                    {
                        Folio = varDetalle_Notificaciones_Paciente.Folio
                        ,Funcionalidad = varDetalle_Notificaciones_Paciente.Funcionalidad

                    };

                    result = !IsNew ?
                        _IDetalle_Notificaciones_PacienteApiConsumer.Update(Detalle_Notificaciones_PacienteInfo, null, null).Resource.ToString() :
                         _IDetalle_Notificaciones_PacienteApiConsumer.Insert(Detalle_Notificaciones_PacienteInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Detalle_Notificaciones_Paciente script
        /// </summary>
        /// <param name="oDetalle_Notificaciones_PacienteElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Detalle_Notificaciones_PacienteModuleAttributeList)
        {
            for (int i = 0; i < Detalle_Notificaciones_PacienteModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Detalle_Notificaciones_PacienteModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Detalle_Notificaciones_PacienteModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Detalle_Notificaciones_PacienteModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Detalle_Notificaciones_PacienteModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Detalle_Notificaciones_PacienteModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Detalle_Notificaciones_PacienteModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Detalle_Notificaciones_PacienteModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Detalle_Notificaciones_PacienteModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Detalle_Notificaciones_PacienteModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Detalle_Notificaciones_PacienteModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strDetalle_Notificaciones_PacienteScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Notificaciones_Paciente.js")))
            {
                strDetalle_Notificaciones_PacienteScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Detalle_Notificaciones_Paciente element attributes
            string userChangeJson = jsSerialize.Serialize(Detalle_Notificaciones_PacienteModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDetalle_Notificaciones_PacienteScript.IndexOf("inpuElementArray");
            string splittedString = strDetalle_Notificaciones_PacienteScript.Substring(indexOfArray, strDetalle_Notificaciones_PacienteScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Detalle_Notificaciones_PacienteModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Detalle_Notificaciones_PacienteModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDetalle_Notificaciones_PacienteScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strDetalle_Notificaciones_PacienteScript.Substring(indexOfArrayHistory, strDetalle_Notificaciones_PacienteScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strDetalle_Notificaciones_PacienteScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDetalle_Notificaciones_PacienteScript.Substring(endIndexOfMainElement + indexOfArray, strDetalle_Notificaciones_PacienteScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Detalle_Notificaciones_PacienteModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strDetalle_Notificaciones_PacienteScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strDetalle_Notificaciones_PacienteScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strDetalle_Notificaciones_PacienteScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strDetalle_Notificaciones_PacienteScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Detalle_Notificaciones_Paciente.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Detalle_Notificaciones_Paciente.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Notificaciones_Paciente.js")))
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
        public ActionResult Detalle_Notificaciones_PacientePropertyBag()
        {
            return PartialView("Detalle_Notificaciones_PacientePropertyBag", "Detalle_Notificaciones_Paciente");
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

            _IDetalle_Notificaciones_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Notificaciones_PacientePropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Notificaciones_PacienteApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Notificaciones_Pacientes == null)
                result.Detalle_Notificaciones_Pacientes = new List<Detalle_Notificaciones_Paciente>();

            var data = result.Detalle_Notificaciones_Pacientes.Select(m => new Detalle_Notificaciones_PacienteGridModel
            {
                Folio = m.Folio
                ,FuncionalidadFuncionalidad = (string)m.Funcionalidad_Funcionalidades_para_Notificacion.Funcionalidad

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Detalle_Notificaciones_PacienteList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Detalle_Notificaciones_PacienteList_" + DateTime.Now.ToString());
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

            _IDetalle_Notificaciones_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Notificaciones_PacientePropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Notificaciones_PacienteApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Notificaciones_Pacientes == null)
                result.Detalle_Notificaciones_Pacientes = new List<Detalle_Notificaciones_Paciente>();

            var data = result.Detalle_Notificaciones_Pacientes.Select(m => new Detalle_Notificaciones_PacienteGridModel
            {
                Folio = m.Folio
                ,FuncionalidadFuncionalidad = (string)m.Funcionalidad_Funcionalidades_para_Notificacion.Funcionalidad

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
