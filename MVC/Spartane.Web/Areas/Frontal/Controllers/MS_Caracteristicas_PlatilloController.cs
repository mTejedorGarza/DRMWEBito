using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.MS_Caracteristicas_Platillo;
using Spartane.Core.Domain.Caracteristicas_platillo;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.MS_Caracteristicas_Platillo;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.MS_Caracteristicas_Platillo;
using Spartane.Web.Areas.WebApiConsumer.Caracteristicas_platillo;

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
    public class MS_Caracteristicas_PlatilloController : Controller
    {
        #region "variable declaration"

        private IMS_Caracteristicas_PlatilloService service = null;
        private IMS_Caracteristicas_PlatilloApiConsumer _IMS_Caracteristicas_PlatilloApiConsumer;
        private ICaracteristicas_platilloApiConsumer _ICaracteristicas_platilloApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public MS_Caracteristicas_PlatilloController(IMS_Caracteristicas_PlatilloService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IMS_Caracteristicas_PlatilloApiConsumer MS_Caracteristicas_PlatilloApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , ICaracteristicas_platilloApiConsumer Caracteristicas_platilloApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IMS_Caracteristicas_PlatilloApiConsumer = MS_Caracteristicas_PlatilloApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ICaracteristicas_platilloApiConsumer = Caracteristicas_platilloApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/MS_Caracteristicas_Platillo
        [ObjectAuth(ObjectId = (ModuleObjectId)44734, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44734);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/MS_Caracteristicas_Platillo/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44734, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44734);
            ViewBag.Permission = permission;
            var varMS_Caracteristicas_Platillo = new MS_Caracteristicas_PlatilloModel();
			
            ViewBag.ObjectId = "44734";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMS_Caracteristicas_PlatilloApiConsumer.SetAuthHeader(_tokenManager.Token);
                var MS_Caracteristicas_PlatilloData = _IMS_Caracteristicas_PlatilloApiConsumer.GetByKeyComplete(Id).Resource.MS_Caracteristicas_Platillos[0];
                if (MS_Caracteristicas_PlatilloData == null)
                    return HttpNotFound();

                varMS_Caracteristicas_Platillo = new MS_Caracteristicas_PlatilloModel
                {
                    Folio = (int)MS_Caracteristicas_PlatilloData.Folio
                    ,Caracteristicas = MS_Caracteristicas_PlatilloData.Caracteristicas
                    ,CaracteristicasCaracteristicas = CultureHelper.GetTraduction(Convert.ToString(MS_Caracteristicas_PlatilloData.Caracteristicas), "Caracteristicas_platillo") ??  (string)MS_Caracteristicas_PlatilloData.Caracteristicas_Caracteristicas_platillo.Caracteristicas

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ICaracteristicas_platilloApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Caracteristicas_platillos_Caracteristicas = _ICaracteristicas_platilloApiConsumer.SelAll(true);
            if (Caracteristicas_platillos_Caracteristicas != null && Caracteristicas_platillos_Caracteristicas.Resource != null)
                ViewBag.Caracteristicas_platillos_Caracteristicas = Caracteristicas_platillos_Caracteristicas.Resource.Where(m => m.Caracteristicas != null).OrderBy(m => m.Caracteristicas).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Caracteristicas_platillo", "Caracteristicas") ?? m.Caracteristicas.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varMS_Caracteristicas_Platillo);
        }
		
	[HttpGet]
        public ActionResult AddMS_Caracteristicas_Platillo(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44734);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IMS_Caracteristicas_PlatilloApiConsumer.SetAuthHeader(_tokenManager.Token);
			MS_Caracteristicas_PlatilloModel varMS_Caracteristicas_Platillo= new MS_Caracteristicas_PlatilloModel();


            if (id.ToString() != "0")
            {
                var MS_Caracteristicas_PlatillosData = _IMS_Caracteristicas_PlatilloApiConsumer.ListaSelAll(0, 1000, "MS_Caracteristicas_Platillo.Folio=" + id, "").Resource.MS_Caracteristicas_Platillos;
				
				if (MS_Caracteristicas_PlatillosData != null && MS_Caracteristicas_PlatillosData.Count > 0)
                {
					var MS_Caracteristicas_PlatilloData = MS_Caracteristicas_PlatillosData.First();
					varMS_Caracteristicas_Platillo= new MS_Caracteristicas_PlatilloModel
					{
						Folio  = MS_Caracteristicas_PlatilloData.Folio 
	                    ,Caracteristicas = MS_Caracteristicas_PlatilloData.Caracteristicas
                    ,CaracteristicasCaracteristicas = CultureHelper.GetTraduction(Convert.ToString(MS_Caracteristicas_PlatilloData.Caracteristicas), "Caracteristicas_platillo") ??  (string)MS_Caracteristicas_PlatilloData.Caracteristicas_Caracteristicas_platillo.Caracteristicas

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ICaracteristicas_platilloApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Caracteristicas_platillos_Caracteristicas = _ICaracteristicas_platilloApiConsumer.SelAll(true);
            if (Caracteristicas_platillos_Caracteristicas != null && Caracteristicas_platillos_Caracteristicas.Resource != null)
                ViewBag.Caracteristicas_platillos_Caracteristicas = Caracteristicas_platillos_Caracteristicas.Resource.Where(m => m.Caracteristicas != null).OrderBy(m => m.Caracteristicas).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Caracteristicas_platillo", "Caracteristicas") ?? m.Caracteristicas.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            return PartialView("AddMS_Caracteristicas_Platillo", varMS_Caracteristicas_Platillo);
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
        public ActionResult GetCaracteristicas_platilloAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ICaracteristicas_platilloApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ICaracteristicas_platilloApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Caracteristicas).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Caracteristicas_platillo", "Caracteristicas")?? m.Caracteristicas,
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
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_Caracteristicas_PlatilloPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IMS_Caracteristicas_PlatilloApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Caracteristicas_Platillos == null)
                result.MS_Caracteristicas_Platillos = new List<MS_Caracteristicas_Platillo>();

            return Json(new
            {
                data = result.MS_Caracteristicas_Platillos.Select(m => new MS_Caracteristicas_PlatilloGridModel
                    {
                    Folio = m.Folio
                        ,CaracteristicasCaracteristicas = CultureHelper.GetTraduction(m.Caracteristicas_Caracteristicas_platillo.Folio.ToString(), "Caracteristicas") ?? (string)m.Caracteristicas_Caracteristicas_platillo.Caracteristicas

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
                _IMS_Caracteristicas_PlatilloApiConsumer.SetAuthHeader(_tokenManager.Token);

                MS_Caracteristicas_Platillo varMS_Caracteristicas_Platillo = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IMS_Caracteristicas_PlatilloApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, MS_Caracteristicas_PlatilloModel varMS_Caracteristicas_Platillo)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IMS_Caracteristicas_PlatilloApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var MS_Caracteristicas_PlatilloInfo = new MS_Caracteristicas_Platillo
                    {
                        Folio = varMS_Caracteristicas_Platillo.Folio
                        ,Caracteristicas = varMS_Caracteristicas_Platillo.Caracteristicas

                    };

                    result = !IsNew ?
                        _IMS_Caracteristicas_PlatilloApiConsumer.Update(MS_Caracteristicas_PlatilloInfo, null, null).Resource.ToString() :
                         _IMS_Caracteristicas_PlatilloApiConsumer.Insert(MS_Caracteristicas_PlatilloInfo, null, null).Resource.ToString();

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
        /// Write Element Array of MS_Caracteristicas_Platillo script
        /// </summary>
        /// <param name="oMS_Caracteristicas_PlatilloElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements MS_Caracteristicas_PlatilloModuleAttributeList)
        {
            for (int i = 0; i < MS_Caracteristicas_PlatilloModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(MS_Caracteristicas_PlatilloModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    MS_Caracteristicas_PlatilloModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(MS_Caracteristicas_PlatilloModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    MS_Caracteristicas_PlatilloModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (MS_Caracteristicas_PlatilloModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < MS_Caracteristicas_PlatilloModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(MS_Caracteristicas_PlatilloModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						MS_Caracteristicas_PlatilloModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(MS_Caracteristicas_PlatilloModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						MS_Caracteristicas_PlatilloModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strMS_Caracteristicas_PlatilloScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/MS_Caracteristicas_Platillo.js")))
            {
                strMS_Caracteristicas_PlatilloScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change MS_Caracteristicas_Platillo element attributes
            string userChangeJson = jsSerialize.Serialize(MS_Caracteristicas_PlatilloModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strMS_Caracteristicas_PlatilloScript.IndexOf("inpuElementArray");
            string splittedString = strMS_Caracteristicas_PlatilloScript.Substring(indexOfArray, strMS_Caracteristicas_PlatilloScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(MS_Caracteristicas_PlatilloModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (MS_Caracteristicas_PlatilloModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strMS_Caracteristicas_PlatilloScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strMS_Caracteristicas_PlatilloScript.Substring(indexOfArrayHistory, strMS_Caracteristicas_PlatilloScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strMS_Caracteristicas_PlatilloScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strMS_Caracteristicas_PlatilloScript.Substring(endIndexOfMainElement + indexOfArray, strMS_Caracteristicas_PlatilloScript.Length - (endIndexOfMainElement + indexOfArray));
            if (MS_Caracteristicas_PlatilloModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strMS_Caracteristicas_PlatilloScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strMS_Caracteristicas_PlatilloScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strMS_Caracteristicas_PlatilloScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strMS_Caracteristicas_PlatilloScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/MS_Caracteristicas_Platillo.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/MS_Caracteristicas_Platillo.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/MS_Caracteristicas_Platillo.js")))
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
        public ActionResult MS_Caracteristicas_PlatilloPropertyBag()
        {
            return PartialView("MS_Caracteristicas_PlatilloPropertyBag", "MS_Caracteristicas_Platillo");
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

            _IMS_Caracteristicas_PlatilloApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_Caracteristicas_PlatilloPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMS_Caracteristicas_PlatilloApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Caracteristicas_Platillos == null)
                result.MS_Caracteristicas_Platillos = new List<MS_Caracteristicas_Platillo>();

            var data = result.MS_Caracteristicas_Platillos.Select(m => new MS_Caracteristicas_PlatilloGridModel
            {
                Folio = m.Folio
                ,CaracteristicasCaracteristicas = (string)m.Caracteristicas_Caracteristicas_platillo.Caracteristicas

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "MS_Caracteristicas_PlatilloList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "MS_Caracteristicas_PlatilloList_" + DateTime.Now.ToString());
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

            _IMS_Caracteristicas_PlatilloApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_Caracteristicas_PlatilloPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMS_Caracteristicas_PlatilloApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Caracteristicas_Platillos == null)
                result.MS_Caracteristicas_Platillos = new List<MS_Caracteristicas_Platillo>();

            var data = result.MS_Caracteristicas_Platillos.Select(m => new MS_Caracteristicas_PlatilloGridModel
            {
                Folio = m.Folio
                ,CaracteristicasCaracteristicas = (string)m.Caracteristicas_Caracteristicas_platillo.Caracteristicas

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
