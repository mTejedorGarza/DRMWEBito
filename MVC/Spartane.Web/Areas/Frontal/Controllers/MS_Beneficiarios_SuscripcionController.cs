using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.MS_Beneficiarios_Suscripcion;
using Spartane.Core.Domain.Tipo_Paciente;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.MS_Beneficiarios_Suscripcion;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.MS_Beneficiarios_Suscripcion;
using Spartane.Web.Areas.WebApiConsumer.Tipo_Paciente;

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
    public class MS_Beneficiarios_SuscripcionController : Controller
    {
        #region "variable declaration"

        private IMS_Beneficiarios_SuscripcionService service = null;
        private IMS_Beneficiarios_SuscripcionApiConsumer _IMS_Beneficiarios_SuscripcionApiConsumer;
        private ITipo_PacienteApiConsumer _ITipo_PacienteApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public MS_Beneficiarios_SuscripcionController(IMS_Beneficiarios_SuscripcionService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IMS_Beneficiarios_SuscripcionApiConsumer MS_Beneficiarios_SuscripcionApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , ITipo_PacienteApiConsumer Tipo_PacienteApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IMS_Beneficiarios_SuscripcionApiConsumer = MS_Beneficiarios_SuscripcionApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ITipo_PacienteApiConsumer = Tipo_PacienteApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/MS_Beneficiarios_Suscripcion
        [ObjectAuth(ObjectId = (ModuleObjectId)44600, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44600);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/MS_Beneficiarios_Suscripcion/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44600, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44600);
            ViewBag.Permission = permission;
            var varMS_Beneficiarios_Suscripcion = new MS_Beneficiarios_SuscripcionModel();
			
            ViewBag.ObjectId = "44600";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMS_Beneficiarios_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var MS_Beneficiarios_SuscripcionData = _IMS_Beneficiarios_SuscripcionApiConsumer.GetByKeyComplete(Id).Resource.MS_Beneficiarios_Suscripcions[0];
                if (MS_Beneficiarios_SuscripcionData == null)
                    return HttpNotFound();

                varMS_Beneficiarios_Suscripcion = new MS_Beneficiarios_SuscripcionModel
                {
                    Folio = (int)MS_Beneficiarios_SuscripcionData.Folio
                    ,Beneficiario = MS_Beneficiarios_SuscripcionData.Beneficiario
                    ,BeneficiarioDescripcion = CultureHelper.GetTraduction(Convert.ToString(MS_Beneficiarios_SuscripcionData.Beneficiario), "Tipo_Paciente") ??  (string)MS_Beneficiarios_SuscripcionData.Beneficiario_Tipo_Paciente.Descripcion

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ITipo_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_Pacientes_Beneficiario = _ITipo_PacienteApiConsumer.SelAll(true);
            if (Tipo_Pacientes_Beneficiario != null && Tipo_Pacientes_Beneficiario.Resource != null)
                ViewBag.Tipo_Pacientes_Beneficiario = Tipo_Pacientes_Beneficiario.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Paciente", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varMS_Beneficiarios_Suscripcion);
        }
		
	[HttpGet]
        public ActionResult AddMS_Beneficiarios_Suscripcion(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44600);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IMS_Beneficiarios_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
			MS_Beneficiarios_SuscripcionModel varMS_Beneficiarios_Suscripcion= new MS_Beneficiarios_SuscripcionModel();


            if (id.ToString() != "0")
            {
                var MS_Beneficiarios_SuscripcionsData = _IMS_Beneficiarios_SuscripcionApiConsumer.ListaSelAll(0, 1000, "MS_Beneficiarios_Suscripcion.Folio=" + id, "").Resource.MS_Beneficiarios_Suscripcions;
				
				if (MS_Beneficiarios_SuscripcionsData != null && MS_Beneficiarios_SuscripcionsData.Count > 0)
                {
					var MS_Beneficiarios_SuscripcionData = MS_Beneficiarios_SuscripcionsData.First();
					varMS_Beneficiarios_Suscripcion= new MS_Beneficiarios_SuscripcionModel
					{
						Folio  = MS_Beneficiarios_SuscripcionData.Folio 
	                    ,Beneficiario = MS_Beneficiarios_SuscripcionData.Beneficiario
                    ,BeneficiarioDescripcion = CultureHelper.GetTraduction(Convert.ToString(MS_Beneficiarios_SuscripcionData.Beneficiario), "Tipo_Paciente") ??  (string)MS_Beneficiarios_SuscripcionData.Beneficiario_Tipo_Paciente.Descripcion

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ITipo_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_Pacientes_Beneficiario = _ITipo_PacienteApiConsumer.SelAll(true);
            if (Tipo_Pacientes_Beneficiario != null && Tipo_Pacientes_Beneficiario.Resource != null)
                ViewBag.Tipo_Pacientes_Beneficiario = Tipo_Pacientes_Beneficiario.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Paciente", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddMS_Beneficiarios_Suscripcion", varMS_Beneficiarios_Suscripcion);
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
        public ActionResult GetTipo_PacienteAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipo_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipo_PacienteApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Paciente", "Descripcion")?? m.Descripcion,
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
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_Beneficiarios_SuscripcionPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IMS_Beneficiarios_SuscripcionApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Beneficiarios_Suscripcions == null)
                result.MS_Beneficiarios_Suscripcions = new List<MS_Beneficiarios_Suscripcion>();

            return Json(new
            {
                data = result.MS_Beneficiarios_Suscripcions.Select(m => new MS_Beneficiarios_SuscripcionGridModel
                    {
                    Folio = m.Folio
                        ,BeneficiarioDescripcion = CultureHelper.GetTraduction(m.Beneficiario_Tipo_Paciente.Clave.ToString(), "Descripcion") ?? (string)m.Beneficiario_Tipo_Paciente.Descripcion

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
                _IMS_Beneficiarios_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);

                MS_Beneficiarios_Suscripcion varMS_Beneficiarios_Suscripcion = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IMS_Beneficiarios_SuscripcionApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, MS_Beneficiarios_SuscripcionModel varMS_Beneficiarios_Suscripcion)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IMS_Beneficiarios_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var MS_Beneficiarios_SuscripcionInfo = new MS_Beneficiarios_Suscripcion
                    {
                        Folio = varMS_Beneficiarios_Suscripcion.Folio
                        ,Beneficiario = varMS_Beneficiarios_Suscripcion.Beneficiario

                    };

                    result = !IsNew ?
                        _IMS_Beneficiarios_SuscripcionApiConsumer.Update(MS_Beneficiarios_SuscripcionInfo, null, null).Resource.ToString() :
                         _IMS_Beneficiarios_SuscripcionApiConsumer.Insert(MS_Beneficiarios_SuscripcionInfo, null, null).Resource.ToString();

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
        /// Write Element Array of MS_Beneficiarios_Suscripcion script
        /// </summary>
        /// <param name="oMS_Beneficiarios_SuscripcionElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements MS_Beneficiarios_SuscripcionModuleAttributeList)
        {
            for (int i = 0; i < MS_Beneficiarios_SuscripcionModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(MS_Beneficiarios_SuscripcionModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    MS_Beneficiarios_SuscripcionModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(MS_Beneficiarios_SuscripcionModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    MS_Beneficiarios_SuscripcionModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (MS_Beneficiarios_SuscripcionModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < MS_Beneficiarios_SuscripcionModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(MS_Beneficiarios_SuscripcionModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						MS_Beneficiarios_SuscripcionModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(MS_Beneficiarios_SuscripcionModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						MS_Beneficiarios_SuscripcionModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strMS_Beneficiarios_SuscripcionScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/MS_Beneficiarios_Suscripcion.js")))
            {
                strMS_Beneficiarios_SuscripcionScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change MS_Beneficiarios_Suscripcion element attributes
            string userChangeJson = jsSerialize.Serialize(MS_Beneficiarios_SuscripcionModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strMS_Beneficiarios_SuscripcionScript.IndexOf("inpuElementArray");
            string splittedString = strMS_Beneficiarios_SuscripcionScript.Substring(indexOfArray, strMS_Beneficiarios_SuscripcionScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(MS_Beneficiarios_SuscripcionModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (MS_Beneficiarios_SuscripcionModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strMS_Beneficiarios_SuscripcionScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strMS_Beneficiarios_SuscripcionScript.Substring(indexOfArrayHistory, strMS_Beneficiarios_SuscripcionScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strMS_Beneficiarios_SuscripcionScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strMS_Beneficiarios_SuscripcionScript.Substring(endIndexOfMainElement + indexOfArray, strMS_Beneficiarios_SuscripcionScript.Length - (endIndexOfMainElement + indexOfArray));
            if (MS_Beneficiarios_SuscripcionModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strMS_Beneficiarios_SuscripcionScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strMS_Beneficiarios_SuscripcionScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strMS_Beneficiarios_SuscripcionScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strMS_Beneficiarios_SuscripcionScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/MS_Beneficiarios_Suscripcion.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/MS_Beneficiarios_Suscripcion.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/MS_Beneficiarios_Suscripcion.js")))
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
        public ActionResult MS_Beneficiarios_SuscripcionPropertyBag()
        {
            return PartialView("MS_Beneficiarios_SuscripcionPropertyBag", "MS_Beneficiarios_Suscripcion");
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

            _IMS_Beneficiarios_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_Beneficiarios_SuscripcionPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMS_Beneficiarios_SuscripcionApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Beneficiarios_Suscripcions == null)
                result.MS_Beneficiarios_Suscripcions = new List<MS_Beneficiarios_Suscripcion>();

            var data = result.MS_Beneficiarios_Suscripcions.Select(m => new MS_Beneficiarios_SuscripcionGridModel
            {
                Folio = m.Folio
                ,BeneficiarioDescripcion = (string)m.Beneficiario_Tipo_Paciente.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "MS_Beneficiarios_SuscripcionList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "MS_Beneficiarios_SuscripcionList_" + DateTime.Now.ToString());
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

            _IMS_Beneficiarios_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_Beneficiarios_SuscripcionPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMS_Beneficiarios_SuscripcionApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Beneficiarios_Suscripcions == null)
                result.MS_Beneficiarios_Suscripcions = new List<MS_Beneficiarios_Suscripcion>();

            var data = result.MS_Beneficiarios_Suscripcions.Select(m => new MS_Beneficiarios_SuscripcionGridModel
            {
                Folio = m.Folio
                ,BeneficiarioDescripcion = (string)m.Beneficiario_Tipo_Paciente.Descripcion

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
