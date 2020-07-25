using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.MS_Campos_por_Funcionalidad;
using Spartane.Core.Domain.Nombre_del_campo_en_MS;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.MS_Campos_por_Funcionalidad;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.MS_Campos_por_Funcionalidad;
using Spartane.Web.Areas.WebApiConsumer.Nombre_del_campo_en_MS;

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
    public class MS_Campos_por_FuncionalidadController : Controller
    {
        #region "variable declaration"

        private IMS_Campos_por_FuncionalidadService service = null;
        private IMS_Campos_por_FuncionalidadApiConsumer _IMS_Campos_por_FuncionalidadApiConsumer;
        private INombre_del_campo_en_MSApiConsumer _INombre_del_campo_en_MSApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public MS_Campos_por_FuncionalidadController(IMS_Campos_por_FuncionalidadService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IMS_Campos_por_FuncionalidadApiConsumer MS_Campos_por_FuncionalidadApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , INombre_del_campo_en_MSApiConsumer Nombre_del_campo_en_MSApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IMS_Campos_por_FuncionalidadApiConsumer = MS_Campos_por_FuncionalidadApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._INombre_del_campo_en_MSApiConsumer = Nombre_del_campo_en_MSApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/MS_Campos_por_Funcionalidad
        [ObjectAuth(ObjectId = (ModuleObjectId)44720, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44720);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/MS_Campos_por_Funcionalidad/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44720, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44720);
            ViewBag.Permission = permission;
            var varMS_Campos_por_Funcionalidad = new MS_Campos_por_FuncionalidadModel();
			
            ViewBag.ObjectId = "44720";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMS_Campos_por_FuncionalidadApiConsumer.SetAuthHeader(_tokenManager.Token);
                var MS_Campos_por_FuncionalidadData = _IMS_Campos_por_FuncionalidadApiConsumer.GetByKeyComplete(Id).Resource.MS_Campos_por_Funcionalidads[0];
                if (MS_Campos_por_FuncionalidadData == null)
                    return HttpNotFound();

                varMS_Campos_por_Funcionalidad = new MS_Campos_por_FuncionalidadModel
                {
                    Folio = (int)MS_Campos_por_FuncionalidadData.Folio
                    ,Campo = MS_Campos_por_FuncionalidadData.Campo
                    ,CampoDescripcion = CultureHelper.GetTraduction(Convert.ToString(MS_Campos_por_FuncionalidadData.Campo), "Nombre_del_campo_en_MS") ??  (string)MS_Campos_por_FuncionalidadData.Campo_Nombre_del_campo_en_MS.Descripcion

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _INombre_del_campo_en_MSApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Nombre_del_campo_en_MSs_Campo = _INombre_del_campo_en_MSApiConsumer.SelAll(true);
            if (Nombre_del_campo_en_MSs_Campo != null && Nombre_del_campo_en_MSs_Campo.Resource != null)
                ViewBag.Nombre_del_campo_en_MSs_Campo = Nombre_del_campo_en_MSs_Campo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Nombre_del_campo_en_MS", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varMS_Campos_por_Funcionalidad);
        }
		
	[HttpGet]
        public ActionResult AddMS_Campos_por_Funcionalidad(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44720);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IMS_Campos_por_FuncionalidadApiConsumer.SetAuthHeader(_tokenManager.Token);
			MS_Campos_por_FuncionalidadModel varMS_Campos_por_Funcionalidad= new MS_Campos_por_FuncionalidadModel();


            if (id.ToString() != "0")
            {
                var MS_Campos_por_FuncionalidadsData = _IMS_Campos_por_FuncionalidadApiConsumer.ListaSelAll(0, 1000, "MS_Campos_por_Funcionalidad.Folio=" + id, "").Resource.MS_Campos_por_Funcionalidads;
				
				if (MS_Campos_por_FuncionalidadsData != null && MS_Campos_por_FuncionalidadsData.Count > 0)
                {
					var MS_Campos_por_FuncionalidadData = MS_Campos_por_FuncionalidadsData.First();
					varMS_Campos_por_Funcionalidad= new MS_Campos_por_FuncionalidadModel
					{
						Folio  = MS_Campos_por_FuncionalidadData.Folio 
	                    ,Campo = MS_Campos_por_FuncionalidadData.Campo
                    ,CampoDescripcion = CultureHelper.GetTraduction(Convert.ToString(MS_Campos_por_FuncionalidadData.Campo), "Nombre_del_campo_en_MS") ??  (string)MS_Campos_por_FuncionalidadData.Campo_Nombre_del_campo_en_MS.Descripcion

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _INombre_del_campo_en_MSApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Nombre_del_campo_en_MSs_Campo = _INombre_del_campo_en_MSApiConsumer.SelAll(true);
            if (Nombre_del_campo_en_MSs_Campo != null && Nombre_del_campo_en_MSs_Campo.Resource != null)
                ViewBag.Nombre_del_campo_en_MSs_Campo = Nombre_del_campo_en_MSs_Campo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Nombre_del_campo_en_MS", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddMS_Campos_por_Funcionalidad", varMS_Campos_por_Funcionalidad);
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
        public ActionResult GetNombre_del_campo_en_MSAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _INombre_del_campo_en_MSApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _INombre_del_campo_en_MSApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Nombre_del_campo_en_MS", "Descripcion")?? m.Descripcion,
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
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_Campos_por_FuncionalidadPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IMS_Campos_por_FuncionalidadApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Campos_por_Funcionalidads == null)
                result.MS_Campos_por_Funcionalidads = new List<MS_Campos_por_Funcionalidad>();

            return Json(new
            {
                data = result.MS_Campos_por_Funcionalidads.Select(m => new MS_Campos_por_FuncionalidadGridModel
                    {
                    Folio = m.Folio
                        ,CampoDescripcion = CultureHelper.GetTraduction(m.Campo_Nombre_del_campo_en_MS.Clave.ToString(), "Descripcion") ?? (string)m.Campo_Nombre_del_campo_en_MS.Descripcion

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
                _IMS_Campos_por_FuncionalidadApiConsumer.SetAuthHeader(_tokenManager.Token);

                MS_Campos_por_Funcionalidad varMS_Campos_por_Funcionalidad = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IMS_Campos_por_FuncionalidadApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, MS_Campos_por_FuncionalidadModel varMS_Campos_por_Funcionalidad)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IMS_Campos_por_FuncionalidadApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var MS_Campos_por_FuncionalidadInfo = new MS_Campos_por_Funcionalidad
                    {
                        Folio = varMS_Campos_por_Funcionalidad.Folio
                        ,Campo = varMS_Campos_por_Funcionalidad.Campo

                    };

                    result = !IsNew ?
                        _IMS_Campos_por_FuncionalidadApiConsumer.Update(MS_Campos_por_FuncionalidadInfo, null, null).Resource.ToString() :
                         _IMS_Campos_por_FuncionalidadApiConsumer.Insert(MS_Campos_por_FuncionalidadInfo, null, null).Resource.ToString();

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
        /// Write Element Array of MS_Campos_por_Funcionalidad script
        /// </summary>
        /// <param name="oMS_Campos_por_FuncionalidadElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements MS_Campos_por_FuncionalidadModuleAttributeList)
        {
            for (int i = 0; i < MS_Campos_por_FuncionalidadModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(MS_Campos_por_FuncionalidadModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    MS_Campos_por_FuncionalidadModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(MS_Campos_por_FuncionalidadModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    MS_Campos_por_FuncionalidadModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (MS_Campos_por_FuncionalidadModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < MS_Campos_por_FuncionalidadModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(MS_Campos_por_FuncionalidadModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						MS_Campos_por_FuncionalidadModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(MS_Campos_por_FuncionalidadModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						MS_Campos_por_FuncionalidadModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strMS_Campos_por_FuncionalidadScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/MS_Campos_por_Funcionalidad.js")))
            {
                strMS_Campos_por_FuncionalidadScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change MS_Campos_por_Funcionalidad element attributes
            string userChangeJson = jsSerialize.Serialize(MS_Campos_por_FuncionalidadModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strMS_Campos_por_FuncionalidadScript.IndexOf("inpuElementArray");
            string splittedString = strMS_Campos_por_FuncionalidadScript.Substring(indexOfArray, strMS_Campos_por_FuncionalidadScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(MS_Campos_por_FuncionalidadModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (MS_Campos_por_FuncionalidadModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strMS_Campos_por_FuncionalidadScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strMS_Campos_por_FuncionalidadScript.Substring(indexOfArrayHistory, strMS_Campos_por_FuncionalidadScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strMS_Campos_por_FuncionalidadScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strMS_Campos_por_FuncionalidadScript.Substring(endIndexOfMainElement + indexOfArray, strMS_Campos_por_FuncionalidadScript.Length - (endIndexOfMainElement + indexOfArray));
            if (MS_Campos_por_FuncionalidadModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strMS_Campos_por_FuncionalidadScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strMS_Campos_por_FuncionalidadScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strMS_Campos_por_FuncionalidadScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strMS_Campos_por_FuncionalidadScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/MS_Campos_por_Funcionalidad.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/MS_Campos_por_Funcionalidad.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/MS_Campos_por_Funcionalidad.js")))
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
        public ActionResult MS_Campos_por_FuncionalidadPropertyBag()
        {
            return PartialView("MS_Campos_por_FuncionalidadPropertyBag", "MS_Campos_por_Funcionalidad");
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

            _IMS_Campos_por_FuncionalidadApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_Campos_por_FuncionalidadPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMS_Campos_por_FuncionalidadApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Campos_por_Funcionalidads == null)
                result.MS_Campos_por_Funcionalidads = new List<MS_Campos_por_Funcionalidad>();

            var data = result.MS_Campos_por_Funcionalidads.Select(m => new MS_Campos_por_FuncionalidadGridModel
            {
                Folio = m.Folio
                ,CampoDescripcion = (string)m.Campo_Nombre_del_campo_en_MS.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "MS_Campos_por_FuncionalidadList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "MS_Campos_por_FuncionalidadList_" + DateTime.Now.ToString());
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

            _IMS_Campos_por_FuncionalidadApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_Campos_por_FuncionalidadPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMS_Campos_por_FuncionalidadApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Campos_por_Funcionalidads == null)
                result.MS_Campos_por_Funcionalidads = new List<MS_Campos_por_Funcionalidad>();

            var data = result.MS_Campos_por_Funcionalidads.Select(m => new MS_Campos_por_FuncionalidadGridModel
            {
                Folio = m.Folio
                ,CampoDescripcion = (string)m.Campo_Nombre_del_campo_en_MS.Descripcion

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
