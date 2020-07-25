﻿using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Spartan_Traduction_Detail;
using Spartane.Core.Domain.Spartan_Traduction_Concept_Type;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Spartan_Traduction_Detail;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Concept_Type;

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
    public class Spartan_Traduction_DetailController : Controller
    {
        #region "variable declaration"

        private ISpartan_Traduction_DetailService service = null;
        private ISpartan_Traduction_DetailApiConsumer _ISpartan_Traduction_DetailApiConsumer;
        private ISpartan_Traduction_Concept_TypeApiConsumer _ISpartan_Traduction_Concept_TypeApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Spartan_Traduction_DetailController(ISpartan_Traduction_DetailService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ISpartan_Traduction_DetailApiConsumer Spartan_Traduction_DetailApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , ISpartan_Traduction_Concept_TypeApiConsumer Spartan_Traduction_Concept_TypeApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._ISpartan_Traduction_DetailApiConsumer = Spartan_Traduction_DetailApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_Traduction_Concept_TypeApiConsumer = Spartan_Traduction_Concept_TypeApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Spartan_Traduction_Detail
        [ObjectAuth(ObjectId = (ModuleObjectId)32363, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 32363);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Spartan_Traduction_Detail/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)32363, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 32363);
            ViewBag.Permission = permission;
            var varSpartan_Traduction_Detail = new Spartan_Traduction_DetailModel();
			
            ViewBag.ObjectId = "32363";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Traduction_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Spartan_Traduction_DetailData = _ISpartan_Traduction_DetailApiConsumer.GetByKeyComplete(Id).Resource.Spartan_Traduction_Details[0];
                if (Spartan_Traduction_DetailData == null)
                    return HttpNotFound();

                varSpartan_Traduction_Detail = new Spartan_Traduction_DetailModel
                {
                    IdTraductionDetail = (int)Spartan_Traduction_DetailData.IdTraductionDetail
                    ,Concept = Spartan_Traduction_DetailData.Concept
                    ,ConceptConcept_Description =  (string)Spartan_Traduction_DetailData.Concept_Spartan_Traduction_Concept_Type.Concept_Description
                    ,IdConcept = Spartan_Traduction_DetailData.IdConcept
                    ,Original_Text = Spartan_Traduction_DetailData.Original_Text
                    ,Translated_Text = Spartan_Traduction_DetailData.Translated_Text

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_Traduction_Concept_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Traduction_Concept_Types_Concept = _ISpartan_Traduction_Concept_TypeApiConsumer.SelAll(true);
            if (Spartan_Traduction_Concept_Types_Concept != null && Spartan_Traduction_Concept_Types_Concept.Resource != null)
                ViewBag.Spartan_Traduction_Concept_Types_Concept = Spartan_Traduction_Concept_Types_Concept.Resource.OrderBy(m => m.Concept_Description).Select(m => new SelectListItem
                {
                    Text = m.Concept_Description.ToString(), Value = Convert.ToString(m.IdConcept)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varSpartan_Traduction_Detail);
        }
		
	[HttpGet]
        public ActionResult AddSpartan_Traduction_Detail(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 32363);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _ISpartan_Traduction_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
			Spartan_Traduction_DetailModel varSpartan_Traduction_Detail= new Spartan_Traduction_DetailModel();


            if (id.ToString() != "0")
            {
                var Spartan_Traduction_DetailsData = _ISpartan_Traduction_DetailApiConsumer.ListaSelAll(0, 1000, "IdTraductionDetail=" + id, "").Resource.Spartan_Traduction_Details;
				
				if (Spartan_Traduction_DetailsData != null && Spartan_Traduction_DetailsData.Count > 0)
                {
					var Spartan_Traduction_DetailData = Spartan_Traduction_DetailsData.First();
					varSpartan_Traduction_Detail= new Spartan_Traduction_DetailModel
					{
						IdTraductionDetail  = Spartan_Traduction_DetailData.IdTraductionDetail 
	                    ,Concept = Spartan_Traduction_DetailData.Concept
                    ,ConceptConcept_Description =  (string)Spartan_Traduction_DetailData.Concept_Spartan_Traduction_Concept_Type.Concept_Description
                    ,IdConcept = Spartan_Traduction_DetailData.IdConcept
                    ,Original_Text = Spartan_Traduction_DetailData.Original_Text
                    ,Translated_Text = Spartan_Traduction_DetailData.Translated_Text

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_Traduction_Concept_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Traduction_Concept_Types_Concept = _ISpartan_Traduction_Concept_TypeApiConsumer.SelAll(true);
            if (Spartan_Traduction_Concept_Types_Concept != null && Spartan_Traduction_Concept_Types_Concept.Resource != null)
                ViewBag.Spartan_Traduction_Concept_Types_Concept = Spartan_Traduction_Concept_Types_Concept.Resource.OrderBy(m => m.Concept_Description).Select(m => new SelectListItem
                {
                    Text = m.Concept_Description.ToString(), Value = Convert.ToString(m.IdConcept)
                }).ToList();


            return PartialView("AddSpartan_Traduction_Detail", varSpartan_Traduction_Detail);
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
        public ActionResult GetSpartan_Traduction_Concept_TypeAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Traduction_Concept_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_Traduction_Concept_TypeApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_Traduction_DetailPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _ISpartan_Traduction_DetailApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Traduction_Details == null)
                result.Spartan_Traduction_Details = new List<Spartan_Traduction_Detail>();

            return Json(new
            {
                data = result.Spartan_Traduction_Details.Select(m => new Spartan_Traduction_DetailGridModel
                    {
                    IdTraductionDetail = m.IdTraductionDetail
                        ,ConceptConcept_Description = (string)m.Concept_Spartan_Traduction_Concept_Type.Concept_Description
			,IdConcept = m.IdConcept
			,Original_Text = m.Original_Text
			,Translated_Text = m.Translated_Text

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
                _ISpartan_Traduction_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                Spartan_Traduction_Detail varSpartan_Traduction_Detail = null;
                if (id.ToString() != "0")
                {

                }
                var result = _ISpartan_Traduction_DetailApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Spartan_Traduction_DetailModel varSpartan_Traduction_Detail)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _ISpartan_Traduction_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Spartan_Traduction_DetailInfo = new Spartan_Traduction_Detail
                    {
                        IdTraductionDetail = varSpartan_Traduction_Detail.IdTraductionDetail
                        ,Concept = varSpartan_Traduction_Detail.Concept
                        ,IdConcept = varSpartan_Traduction_Detail.IdConcept
                        ,Original_Text = varSpartan_Traduction_Detail.Original_Text
                        ,Translated_Text = varSpartan_Traduction_Detail.Translated_Text

                    };

                    result = !IsNew ?
                        _ISpartan_Traduction_DetailApiConsumer.Update(Spartan_Traduction_DetailInfo, null, null).Resource.ToString() :
                         _ISpartan_Traduction_DetailApiConsumer.Insert(Spartan_Traduction_DetailInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Spartan_Traduction_Detail script
        /// </summary>
        /// <param name="oSpartan_Traduction_DetailElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Spartan_Traduction_DetailModuleAttributeList)
        {
            for (int i = 0; i < Spartan_Traduction_DetailModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Spartan_Traduction_DetailModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Spartan_Traduction_DetailModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Spartan_Traduction_DetailModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Spartan_Traduction_DetailModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Spartan_Traduction_DetailModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Spartan_Traduction_DetailModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Spartan_Traduction_DetailModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Spartan_Traduction_DetailModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Spartan_Traduction_DetailModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Spartan_Traduction_DetailModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strSpartan_Traduction_DetailScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_Traduction_Detail.js")))
            {
                strSpartan_Traduction_DetailScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Spartan_Traduction_Detail element attributes
            string userChangeJson = jsSerialize.Serialize(Spartan_Traduction_DetailModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strSpartan_Traduction_DetailScript.IndexOf("inpuElementArray");
            string splittedString = strSpartan_Traduction_DetailScript.Substring(indexOfArray, strSpartan_Traduction_DetailScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Spartan_Traduction_DetailModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Spartan_Traduction_DetailModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strSpartan_Traduction_DetailScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strSpartan_Traduction_DetailScript.Substring(indexOfArrayHistory, strSpartan_Traduction_DetailScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strSpartan_Traduction_DetailScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strSpartan_Traduction_DetailScript.Substring(endIndexOfMainElement + indexOfArray, strSpartan_Traduction_DetailScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Spartan_Traduction_DetailModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strSpartan_Traduction_DetailScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strSpartan_Traduction_DetailScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strSpartan_Traduction_DetailScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strSpartan_Traduction_DetailScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Spartan_Traduction_Detail.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Spartan_Traduction_Detail.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_Traduction_Detail.js")))
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
        public ActionResult Spartan_Traduction_DetailPropertyBag()
        {
            return PartialView("Spartan_Traduction_DetailPropertyBag", "Spartan_Traduction_Detail");
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

            _ISpartan_Traduction_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_Traduction_DetailPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_Traduction_DetailApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Traduction_Details == null)
                result.Spartan_Traduction_Details = new List<Spartan_Traduction_Detail>();

            var data = result.Spartan_Traduction_Details.Select(m => new Spartan_Traduction_DetailGridModel
            {
                IdTraductionDetail = m.IdTraductionDetail
                ,IdConcept = m.IdConcept
                ,Original_Text = m.Original_Text
                ,Translated_Text = m.Translated_Text

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Spartan_Traduction_DetailList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Spartan_Traduction_DetailList_" + DateTime.Now.ToString());
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

            _ISpartan_Traduction_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_Traduction_DetailPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_Traduction_DetailApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Traduction_Details == null)
                result.Spartan_Traduction_Details = new List<Spartan_Traduction_Detail>();

            var data = result.Spartan_Traduction_Details.Select(m => new Spartan_Traduction_DetailGridModel
            {
                IdTraductionDetail = m.IdTraductionDetail
                ,IdConcept = m.IdConcept
                ,Original_Text = m.Original_Text
                ,Translated_Text = m.Translated_Text

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
