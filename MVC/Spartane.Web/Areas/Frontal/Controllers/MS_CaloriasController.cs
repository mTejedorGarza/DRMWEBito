using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.MS_Calorias;
using Spartane.Core.Domain.Calorias;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.MS_Calorias;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.MS_Calorias;
using Spartane.Web.Areas.WebApiConsumer.Calorias;

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
    public class MS_CaloriasController : Controller
    {
        #region "variable declaration"

        private IMS_CaloriasService service = null;
        private IMS_CaloriasApiConsumer _IMS_CaloriasApiConsumer;
        private ICaloriasApiConsumer _ICaloriasApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public MS_CaloriasController(IMS_CaloriasService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IMS_CaloriasApiConsumer MS_CaloriasApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , ICaloriasApiConsumer CaloriasApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IMS_CaloriasApiConsumer = MS_CaloriasApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ICaloriasApiConsumer = CaloriasApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/MS_Calorias
        [ObjectAuth(ObjectId = (ModuleObjectId)44729, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44729);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/MS_Calorias/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44729, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44729);
            ViewBag.Permission = permission;
            var varMS_Calorias = new MS_CaloriasModel();
			
            ViewBag.ObjectId = "44729";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMS_CaloriasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var MS_CaloriasData = _IMS_CaloriasApiConsumer.GetByKeyComplete(Id).Resource.MS_Caloriass[0];
                if (MS_CaloriasData == null)
                    return HttpNotFound();

                varMS_Calorias = new MS_CaloriasModel
                {
                    Folio = (int)MS_CaloriasData.Folio
                    ,Calorias = MS_CaloriasData.Calorias
                    ,CaloriasCantidad = CultureHelper.GetTraduction(Convert.ToString(MS_CaloriasData.Calorias), "Calorias") ??  (string)MS_CaloriasData.Calorias_Calorias.Cantidad

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ICaloriasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Caloriass_Calorias = _ICaloriasApiConsumer.SelAll(true);
            if (Caloriass_Calorias != null && Caloriass_Calorias.Resource != null)
                ViewBag.Caloriass_Calorias = Caloriass_Calorias.Resource.Where(m => m.Cantidad != null).OrderBy(m => m.Cantidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Calorias", "Cantidad") ?? m.Cantidad.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varMS_Calorias);
        }
		
	[HttpGet]
        public ActionResult AddMS_Calorias(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44729);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IMS_CaloriasApiConsumer.SetAuthHeader(_tokenManager.Token);
			MS_CaloriasModel varMS_Calorias= new MS_CaloriasModel();


            if (id.ToString() != "0")
            {
                var MS_CaloriassData = _IMS_CaloriasApiConsumer.ListaSelAll(0, 1000, "MS_Calorias.Folio=" + id, "").Resource.MS_Caloriass;
				
				if (MS_CaloriassData != null && MS_CaloriassData.Count > 0)
                {
					var MS_CaloriasData = MS_CaloriassData.First();
					varMS_Calorias= new MS_CaloriasModel
					{
						Folio  = MS_CaloriasData.Folio 
	                    ,Calorias = MS_CaloriasData.Calorias
                    ,CaloriasCantidad = CultureHelper.GetTraduction(Convert.ToString(MS_CaloriasData.Calorias), "Calorias") ??  (string)MS_CaloriasData.Calorias_Calorias.Cantidad

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ICaloriasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Caloriass_Calorias = _ICaloriasApiConsumer.SelAll(true);
            if (Caloriass_Calorias != null && Caloriass_Calorias.Resource != null)
                ViewBag.Caloriass_Calorias = Caloriass_Calorias.Resource.Where(m => m.Cantidad != null).OrderBy(m => m.Cantidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Calorias", "Cantidad") ?? m.Cantidad.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddMS_Calorias", varMS_Calorias);
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
        public ActionResult GetCaloriasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ICaloriasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ICaloriasApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Cantidad).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Calorias", "Cantidad")?? m.Cantidad,
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
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_CaloriasPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IMS_CaloriasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Caloriass == null)
                result.MS_Caloriass = new List<MS_Calorias>();

            return Json(new
            {
                data = result.MS_Caloriass.Select(m => new MS_CaloriasGridModel
                    {
                    Folio = m.Folio
                        ,CaloriasCantidad = CultureHelper.GetTraduction(m.Calorias_Calorias.Clave.ToString(), "Cantidad") ?? (string)m.Calorias_Calorias.Cantidad

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
                _IMS_CaloriasApiConsumer.SetAuthHeader(_tokenManager.Token);

                MS_Calorias varMS_Calorias = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IMS_CaloriasApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, MS_CaloriasModel varMS_Calorias)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IMS_CaloriasApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var MS_CaloriasInfo = new MS_Calorias
                    {
                        Folio = varMS_Calorias.Folio
                        ,Calorias = varMS_Calorias.Calorias

                    };

                    result = !IsNew ?
                        _IMS_CaloriasApiConsumer.Update(MS_CaloriasInfo, null, null).Resource.ToString() :
                         _IMS_CaloriasApiConsumer.Insert(MS_CaloriasInfo, null, null).Resource.ToString();

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
        /// Write Element Array of MS_Calorias script
        /// </summary>
        /// <param name="oMS_CaloriasElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements MS_CaloriasModuleAttributeList)
        {
            for (int i = 0; i < MS_CaloriasModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(MS_CaloriasModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    MS_CaloriasModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(MS_CaloriasModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    MS_CaloriasModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (MS_CaloriasModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < MS_CaloriasModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(MS_CaloriasModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						MS_CaloriasModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(MS_CaloriasModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						MS_CaloriasModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strMS_CaloriasScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/MS_Calorias.js")))
            {
                strMS_CaloriasScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change MS_Calorias element attributes
            string userChangeJson = jsSerialize.Serialize(MS_CaloriasModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strMS_CaloriasScript.IndexOf("inpuElementArray");
            string splittedString = strMS_CaloriasScript.Substring(indexOfArray, strMS_CaloriasScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(MS_CaloriasModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (MS_CaloriasModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strMS_CaloriasScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strMS_CaloriasScript.Substring(indexOfArrayHistory, strMS_CaloriasScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strMS_CaloriasScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strMS_CaloriasScript.Substring(endIndexOfMainElement + indexOfArray, strMS_CaloriasScript.Length - (endIndexOfMainElement + indexOfArray));
            if (MS_CaloriasModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strMS_CaloriasScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strMS_CaloriasScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strMS_CaloriasScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strMS_CaloriasScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/MS_Calorias.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/MS_Calorias.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/MS_Calorias.js")))
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
        public ActionResult MS_CaloriasPropertyBag()
        {
            return PartialView("MS_CaloriasPropertyBag", "MS_Calorias");
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

            _IMS_CaloriasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_CaloriasPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMS_CaloriasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Caloriass == null)
                result.MS_Caloriass = new List<MS_Calorias>();

            var data = result.MS_Caloriass.Select(m => new MS_CaloriasGridModel
            {
                Folio = m.Folio
                ,CaloriasCantidad = (string)m.Calorias_Calorias.Cantidad

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "MS_CaloriasList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "MS_CaloriasList_" + DateTime.Now.ToString());
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

            _IMS_CaloriasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_CaloriasPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMS_CaloriasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Caloriass == null)
                result.MS_Caloriass = new List<MS_Calorias>();

            var data = result.MS_Caloriass.Select(m => new MS_CaloriasGridModel
            {
                Folio = m.Folio
                ,CaloriasCantidad = (string)m.Calorias_Calorias.Cantidad

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
