using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Roles_para_Notificar;
using Spartane.Core.Domain.Tipo_Paciente;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Roles_para_Notificar;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Roles_para_Notificar;
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
    public class Roles_para_NotificarController : Controller
    {
        #region "variable declaration"

        private IRoles_para_NotificarService service = null;
        private IRoles_para_NotificarApiConsumer _IRoles_para_NotificarApiConsumer;
        private ITipo_PacienteApiConsumer _ITipo_PacienteApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Roles_para_NotificarController(IRoles_para_NotificarService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IRoles_para_NotificarApiConsumer Roles_para_NotificarApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , ITipo_PacienteApiConsumer Tipo_PacienteApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IRoles_para_NotificarApiConsumer = Roles_para_NotificarApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ITipo_PacienteApiConsumer = Tipo_PacienteApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Roles_para_Notificar
        [ObjectAuth(ObjectId = (ModuleObjectId)44718, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44718);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Roles_para_Notificar/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44718, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44718);
            ViewBag.Permission = permission;
            var varRoles_para_Notificar = new Roles_para_NotificarModel();
			
            ViewBag.ObjectId = "44718";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IRoles_para_NotificarApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Roles_para_NotificarData = _IRoles_para_NotificarApiConsumer.GetByKeyComplete(Id).Resource.Roles_para_Notificars[0];
                if (Roles_para_NotificarData == null)
                    return HttpNotFound();

                varRoles_para_Notificar = new Roles_para_NotificarModel
                {
                    Folio = (int)Roles_para_NotificarData.Folio
                    ,Rol = Roles_para_NotificarData.Rol
                    ,RolDescripcion = CultureHelper.GetTraduction(Convert.ToString(Roles_para_NotificarData.Rol), "Tipo_Paciente") ??  (string)Roles_para_NotificarData.Rol_Tipo_Paciente.Descripcion

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ITipo_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_Pacientes_Rol = _ITipo_PacienteApiConsumer.SelAll(true);
            if (Tipo_Pacientes_Rol != null && Tipo_Pacientes_Rol.Resource != null)
                ViewBag.Tipo_Pacientes_Rol = Tipo_Pacientes_Rol.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Paciente", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varRoles_para_Notificar);
        }
		
	[HttpGet]
        public ActionResult AddRoles_para_Notificar(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44718);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IRoles_para_NotificarApiConsumer.SetAuthHeader(_tokenManager.Token);
			Roles_para_NotificarModel varRoles_para_Notificar= new Roles_para_NotificarModel();


            if (id.ToString() != "0")
            {
                var Roles_para_NotificarsData = _IRoles_para_NotificarApiConsumer.ListaSelAll(0, 1000, "Roles_para_Notificar.Folio=" + id, "").Resource.Roles_para_Notificars;
				
				if (Roles_para_NotificarsData != null && Roles_para_NotificarsData.Count > 0)
                {
					var Roles_para_NotificarData = Roles_para_NotificarsData.First();
					varRoles_para_Notificar= new Roles_para_NotificarModel
					{
						Folio  = Roles_para_NotificarData.Folio 
	                    ,Rol = Roles_para_NotificarData.Rol
                    ,RolDescripcion = CultureHelper.GetTraduction(Convert.ToString(Roles_para_NotificarData.Rol), "Tipo_Paciente") ??  (string)Roles_para_NotificarData.Rol_Tipo_Paciente.Descripcion

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ITipo_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_Pacientes_Rol = _ITipo_PacienteApiConsumer.SelAll(true);
            if (Tipo_Pacientes_Rol != null && Tipo_Pacientes_Rol.Resource != null)
                ViewBag.Tipo_Pacientes_Rol = Tipo_Pacientes_Rol.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Paciente", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddRoles_para_Notificar", varRoles_para_Notificar);
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Roles_para_NotificarPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IRoles_para_NotificarApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Roles_para_Notificars == null)
                result.Roles_para_Notificars = new List<Roles_para_Notificar>();

            return Json(new
            {
                data = result.Roles_para_Notificars.Select(m => new Roles_para_NotificarGridModel
                    {
                    Folio = m.Folio
                        ,RolDescripcion = CultureHelper.GetTraduction(m.Rol_Tipo_Paciente.Clave.ToString(), "Descripcion") ?? (string)m.Rol_Tipo_Paciente.Descripcion

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
                _IRoles_para_NotificarApiConsumer.SetAuthHeader(_tokenManager.Token);

                Roles_para_Notificar varRoles_para_Notificar = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IRoles_para_NotificarApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Roles_para_NotificarModel varRoles_para_Notificar)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IRoles_para_NotificarApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Roles_para_NotificarInfo = new Roles_para_Notificar
                    {
                        Folio = varRoles_para_Notificar.Folio
                        ,Rol = varRoles_para_Notificar.Rol

                    };

                    result = !IsNew ?
                        _IRoles_para_NotificarApiConsumer.Update(Roles_para_NotificarInfo, null, null).Resource.ToString() :
                         _IRoles_para_NotificarApiConsumer.Insert(Roles_para_NotificarInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Roles_para_Notificar script
        /// </summary>
        /// <param name="oRoles_para_NotificarElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Roles_para_NotificarModuleAttributeList)
        {
            for (int i = 0; i < Roles_para_NotificarModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Roles_para_NotificarModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Roles_para_NotificarModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Roles_para_NotificarModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Roles_para_NotificarModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Roles_para_NotificarModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Roles_para_NotificarModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Roles_para_NotificarModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Roles_para_NotificarModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Roles_para_NotificarModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Roles_para_NotificarModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strRoles_para_NotificarScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Roles_para_Notificar.js")))
            {
                strRoles_para_NotificarScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Roles_para_Notificar element attributes
            string userChangeJson = jsSerialize.Serialize(Roles_para_NotificarModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strRoles_para_NotificarScript.IndexOf("inpuElementArray");
            string splittedString = strRoles_para_NotificarScript.Substring(indexOfArray, strRoles_para_NotificarScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Roles_para_NotificarModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Roles_para_NotificarModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strRoles_para_NotificarScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strRoles_para_NotificarScript.Substring(indexOfArrayHistory, strRoles_para_NotificarScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strRoles_para_NotificarScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strRoles_para_NotificarScript.Substring(endIndexOfMainElement + indexOfArray, strRoles_para_NotificarScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Roles_para_NotificarModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strRoles_para_NotificarScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strRoles_para_NotificarScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strRoles_para_NotificarScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strRoles_para_NotificarScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Roles_para_Notificar.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Roles_para_Notificar.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Roles_para_Notificar.js")))
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
        public ActionResult Roles_para_NotificarPropertyBag()
        {
            return PartialView("Roles_para_NotificarPropertyBag", "Roles_para_Notificar");
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

            _IRoles_para_NotificarApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Roles_para_NotificarPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IRoles_para_NotificarApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Roles_para_Notificars == null)
                result.Roles_para_Notificars = new List<Roles_para_Notificar>();

            var data = result.Roles_para_Notificars.Select(m => new Roles_para_NotificarGridModel
            {
                Folio = m.Folio
                ,RolDescripcion = (string)m.Rol_Tipo_Paciente.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Roles_para_NotificarList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Roles_para_NotificarList_" + DateTime.Now.ToString());
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

            _IRoles_para_NotificarApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Roles_para_NotificarPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IRoles_para_NotificarApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Roles_para_Notificars == null)
                result.Roles_para_Notificars = new List<Roles_para_Notificar>();

            var data = result.Roles_para_Notificars.Select(m => new Roles_para_NotificarGridModel
            {
                Folio = m.Folio
                ,RolDescripcion = (string)m.Rol_Tipo_Paciente.Descripcion

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
