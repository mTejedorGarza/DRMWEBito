using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.MS_Semanas_Planes;
using Spartane.Core.Domain.Semanas_Planes;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.MS_Semanas_Planes;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.MS_Semanas_Planes;
using Spartane.Web.Areas.WebApiConsumer.Semanas_Planes;

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
    public class MS_Semanas_PlanesController : Controller
    {
        #region "variable declaration"

        private IMS_Semanas_PlanesService service = null;
        private IMS_Semanas_PlanesApiConsumer _IMS_Semanas_PlanesApiConsumer;
        private ISemanas_PlanesApiConsumer _ISemanas_PlanesApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public MS_Semanas_PlanesController(IMS_Semanas_PlanesService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IMS_Semanas_PlanesApiConsumer MS_Semanas_PlanesApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , ISemanas_PlanesApiConsumer Semanas_PlanesApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IMS_Semanas_PlanesApiConsumer = MS_Semanas_PlanesApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISemanas_PlanesApiConsumer = Semanas_PlanesApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/MS_Semanas_Planes
        [ObjectAuth(ObjectId = (ModuleObjectId)44602, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44602);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/MS_Semanas_Planes/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44602, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44602);
            ViewBag.Permission = permission;
            var varMS_Semanas_Planes = new MS_Semanas_PlanesModel();
			
            ViewBag.ObjectId = "44602";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMS_Semanas_PlanesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var MS_Semanas_PlanesData = _IMS_Semanas_PlanesApiConsumer.GetByKeyComplete(Id).Resource.MS_Semanas_Planess[0];
                if (MS_Semanas_PlanesData == null)
                    return HttpNotFound();

                varMS_Semanas_Planes = new MS_Semanas_PlanesModel
                {
                    Folio = (int)MS_Semanas_PlanesData.Folio
                    ,Semanas = MS_Semanas_PlanesData.Semanas
                    ,SemanasSemana = CultureHelper.GetTraduction(Convert.ToString(MS_Semanas_PlanesData.Semanas), "Semanas_Planes") ??  (string)MS_Semanas_PlanesData.Semanas_Semanas_Planes.Semana

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISemanas_PlanesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Semanas_Planess_Semanas = _ISemanas_PlanesApiConsumer.SelAll(true);
            if (Semanas_Planess_Semanas != null && Semanas_Planess_Semanas.Resource != null)
                ViewBag.Semanas_Planess_Semanas = Semanas_Planess_Semanas.Resource.Where(m => m.Semana != null).OrderBy(m => m.Semana).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Semanas_Planes", "Semana") ?? m.Semana.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varMS_Semanas_Planes);
        }
		
	[HttpGet]
        public ActionResult AddMS_Semanas_Planes(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44602);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IMS_Semanas_PlanesApiConsumer.SetAuthHeader(_tokenManager.Token);
			MS_Semanas_PlanesModel varMS_Semanas_Planes= new MS_Semanas_PlanesModel();


            if (id.ToString() != "0")
            {
                var MS_Semanas_PlanessData = _IMS_Semanas_PlanesApiConsumer.ListaSelAll(0, 1000, "MS_Semanas_Planes.Folio=" + id, "").Resource.MS_Semanas_Planess;
				
				if (MS_Semanas_PlanessData != null && MS_Semanas_PlanessData.Count > 0)
                {
					var MS_Semanas_PlanesData = MS_Semanas_PlanessData.First();
					varMS_Semanas_Planes= new MS_Semanas_PlanesModel
					{
						Folio  = MS_Semanas_PlanesData.Folio 
	                    ,Semanas = MS_Semanas_PlanesData.Semanas
                    ,SemanasSemana = CultureHelper.GetTraduction(Convert.ToString(MS_Semanas_PlanesData.Semanas), "Semanas_Planes") ??  (string)MS_Semanas_PlanesData.Semanas_Semanas_Planes.Semana

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISemanas_PlanesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Semanas_Planess_Semanas = _ISemanas_PlanesApiConsumer.SelAll(true);
            if (Semanas_Planess_Semanas != null && Semanas_Planess_Semanas.Resource != null)
                ViewBag.Semanas_Planess_Semanas = Semanas_Planess_Semanas.Resource.Where(m => m.Semana != null).OrderBy(m => m.Semana).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Semanas_Planes", "Semana") ?? m.Semana.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            return PartialView("AddMS_Semanas_Planes", varMS_Semanas_Planes);
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
        public ActionResult GetSemanas_PlanesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISemanas_PlanesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISemanas_PlanesApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Semana).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Semanas_Planes", "Semana")?? m.Semana,
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
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_Semanas_PlanesPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IMS_Semanas_PlanesApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Semanas_Planess == null)
                result.MS_Semanas_Planess = new List<MS_Semanas_Planes>();

            return Json(new
            {
                data = result.MS_Semanas_Planess.Select(m => new MS_Semanas_PlanesGridModel
                    {
                    Folio = m.Folio
                        ,SemanasSemana = CultureHelper.GetTraduction(m.Semanas_Semanas_Planes.Folio.ToString(), "Semana") ?? (string)m.Semanas_Semanas_Planes.Semana

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
                _IMS_Semanas_PlanesApiConsumer.SetAuthHeader(_tokenManager.Token);

                MS_Semanas_Planes varMS_Semanas_Planes = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IMS_Semanas_PlanesApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, MS_Semanas_PlanesModel varMS_Semanas_Planes)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IMS_Semanas_PlanesApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var MS_Semanas_PlanesInfo = new MS_Semanas_Planes
                    {
                        Folio = varMS_Semanas_Planes.Folio
                        ,Semanas = varMS_Semanas_Planes.Semanas

                    };

                    result = !IsNew ?
                        _IMS_Semanas_PlanesApiConsumer.Update(MS_Semanas_PlanesInfo, null, null).Resource.ToString() :
                         _IMS_Semanas_PlanesApiConsumer.Insert(MS_Semanas_PlanesInfo, null, null).Resource.ToString();

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
        /// Write Element Array of MS_Semanas_Planes script
        /// </summary>
        /// <param name="oMS_Semanas_PlanesElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements MS_Semanas_PlanesModuleAttributeList)
        {
            for (int i = 0; i < MS_Semanas_PlanesModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(MS_Semanas_PlanesModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    MS_Semanas_PlanesModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(MS_Semanas_PlanesModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    MS_Semanas_PlanesModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (MS_Semanas_PlanesModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < MS_Semanas_PlanesModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(MS_Semanas_PlanesModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						MS_Semanas_PlanesModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(MS_Semanas_PlanesModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						MS_Semanas_PlanesModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strMS_Semanas_PlanesScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/MS_Semanas_Planes.js")))
            {
                strMS_Semanas_PlanesScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change MS_Semanas_Planes element attributes
            string userChangeJson = jsSerialize.Serialize(MS_Semanas_PlanesModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strMS_Semanas_PlanesScript.IndexOf("inpuElementArray");
            string splittedString = strMS_Semanas_PlanesScript.Substring(indexOfArray, strMS_Semanas_PlanesScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(MS_Semanas_PlanesModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (MS_Semanas_PlanesModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strMS_Semanas_PlanesScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strMS_Semanas_PlanesScript.Substring(indexOfArrayHistory, strMS_Semanas_PlanesScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strMS_Semanas_PlanesScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strMS_Semanas_PlanesScript.Substring(endIndexOfMainElement + indexOfArray, strMS_Semanas_PlanesScript.Length - (endIndexOfMainElement + indexOfArray));
            if (MS_Semanas_PlanesModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strMS_Semanas_PlanesScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strMS_Semanas_PlanesScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strMS_Semanas_PlanesScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strMS_Semanas_PlanesScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/MS_Semanas_Planes.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/MS_Semanas_Planes.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/MS_Semanas_Planes.js")))
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
        public ActionResult MS_Semanas_PlanesPropertyBag()
        {
            return PartialView("MS_Semanas_PlanesPropertyBag", "MS_Semanas_Planes");
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

            _IMS_Semanas_PlanesApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_Semanas_PlanesPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMS_Semanas_PlanesApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Semanas_Planess == null)
                result.MS_Semanas_Planess = new List<MS_Semanas_Planes>();

            var data = result.MS_Semanas_Planess.Select(m => new MS_Semanas_PlanesGridModel
            {
                Folio = m.Folio
                ,SemanasSemana = (string)m.Semanas_Semanas_Planes.Semana

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "MS_Semanas_PlanesList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "MS_Semanas_PlanesList_" + DateTime.Now.ToString());
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

            _IMS_Semanas_PlanesApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_Semanas_PlanesPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMS_Semanas_PlanesApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Semanas_Planess == null)
                result.MS_Semanas_Planess = new List<MS_Semanas_Planes>();

            var data = result.MS_Semanas_Planess.Select(m => new MS_Semanas_PlanesGridModel
            {
                Folio = m.Folio
                ,SemanasSemana = (string)m.Semanas_Semanas_Planes.Semana

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
