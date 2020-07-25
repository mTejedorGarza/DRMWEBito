﻿using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Spartan_Report_Presentation_View;
using Spartane.Core.Domain.Spartan_Report_Presentation_Type;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Spartan_Report_Presentation_View;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Presentation_View;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Presentation_Type;

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
    public class Spartan_Report_Presentation_ViewController : Controller
    {
        #region "variable declaration"

        private ISpartan_Report_Presentation_ViewService service = null;
        private ISpartan_Report_Presentation_ViewApiConsumer _ISpartan_Report_Presentation_ViewApiConsumer;
        private ISpartan_Report_Presentation_TypeApiConsumer _ISpartan_Report_Presentation_TypeApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Spartan_Report_Presentation_ViewController(ISpartan_Report_Presentation_ViewService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ISpartan_Report_Presentation_ViewApiConsumer Spartan_Report_Presentation_ViewApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , ISpartan_Report_Presentation_TypeApiConsumer Spartan_Report_Presentation_TypeApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._ISpartan_Report_Presentation_ViewApiConsumer = Spartan_Report_Presentation_ViewApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_Report_Presentation_TypeApiConsumer = Spartan_Report_Presentation_TypeApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Spartan_Report_Presentation_View
        [ObjectAuth(ObjectId = (ModuleObjectId)31955, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 31955);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Spartan_Report_Presentation_View/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)31955, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 31955);
            ViewBag.Permission = permission;
            var varSpartan_Report_Presentation_View = new Spartan_Report_Presentation_ViewModel();
			
            ViewBag.ObjectId = "31955";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || (Id.GetType() == typeof(int) && Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Report_Presentation_ViewApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Spartan_Report_Presentation_ViewData = _ISpartan_Report_Presentation_ViewApiConsumer.GetByKeyComplete(Id).Resource.Spartan_Report_Presentation_Views[0];
                if (Spartan_Report_Presentation_ViewData == null)
                    return HttpNotFound();

                varSpartan_Report_Presentation_View = new Spartan_Report_Presentation_ViewModel
                {
                    PresentationViewId = (int)Spartan_Report_Presentation_ViewData.PresentationViewId
                    ,Description = Spartan_Report_Presentation_ViewData.Description
                    ,Presentation_Type = Spartan_Report_Presentation_ViewData.Presentation_Type
                    ,Presentation_TypeDescription =  (string)Spartan_Report_Presentation_ViewData.Presentation_Type_Spartan_Report_Presentation_Type.Description

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_Report_Presentation_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Presentation_Types = _ISpartan_Report_Presentation_TypeApiConsumer.SelAll(true);
            if (Spartan_Report_Presentation_Types != null && Spartan_Report_Presentation_Types.Resource != null)
                ViewBag.Spartan_Report_Presentation_Types = Spartan_Report_Presentation_Types.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.PresentationTypeId)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varSpartan_Report_Presentation_View);
        }
		
	[HttpGet]
        public ActionResult AddSpartan_Report_Presentation_View(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 31955);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _ISpartan_Report_Presentation_ViewApiConsumer.SetAuthHeader(_tokenManager.Token);
			Spartan_Report_Presentation_ViewModel varSpartan_Report_Presentation_View= new Spartan_Report_Presentation_ViewModel();


            if (id.ToString() != "0")
            {
                var Spartan_Report_Presentation_ViewsData = _ISpartan_Report_Presentation_ViewApiConsumer.ListaSelAll(0, 1000, "PresentationViewId=" + id, "").Resource.Spartan_Report_Presentation_Views;
				
				if (Spartan_Report_Presentation_ViewsData != null && Spartan_Report_Presentation_ViewsData.Count > 0)
                {
					var Spartan_Report_Presentation_ViewData = Spartan_Report_Presentation_ViewsData.First();
					varSpartan_Report_Presentation_View= new Spartan_Report_Presentation_ViewModel
					{
						PresentationViewId  = Spartan_Report_Presentation_ViewData.PresentationViewId 
	                    ,Description = Spartan_Report_Presentation_ViewData.Description
                    ,Presentation_Type = Spartan_Report_Presentation_ViewData.Presentation_Type
                    ,Presentation_TypeDescription =  (string)Spartan_Report_Presentation_ViewData.Presentation_Type_Spartan_Report_Presentation_Type.Description

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_Report_Presentation_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Presentation_Types = _ISpartan_Report_Presentation_TypeApiConsumer.SelAll(true);
            if (Spartan_Report_Presentation_Types != null && Spartan_Report_Presentation_Types.Resource != null)
                ViewBag.Spartan_Report_Presentation_Types = Spartan_Report_Presentation_Types.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.PresentationTypeId)
                }).ToList();


            return PartialView("AddSpartan_Report_Presentation_View", varSpartan_Report_Presentation_View);
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
        public ActionResult GetSpartan_Report_Presentation_TypeAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Report_Presentation_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_Report_Presentation_TypeApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }




        [HttpPost]
        public JsonResult ClearAdvanceFilter()
        {
            Session["AdvanceSearch"] = null;
            return Json(new { result = Session["AdvanceSearch"] == null }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ShowAdvanceFilter(Spartan_Report_Presentation_ViewAdvanceSearchModel model)
        {
            if (ModelState.IsValid)
            {
                Session["AdvanceSearch"] = model;
                return RedirectToAction("Index");
            }
            ViewBag.Filter = new List<SelectListItem>
            {
                new SelectListItem() {Text = Resources.Resources.BeginWith, Value = "1"},
                new SelectListItem() {Text = Resources.Resources.EndWith, Value = "2"},
                new SelectListItem() {Text = Resources.Resources.Contains, Value = "4"},
                new SelectListItem() {Text = Resources.Resources.Exact, Value = "3"},
            };
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_Report_Presentation_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Presentation_Types = _ISpartan_Report_Presentation_TypeApiConsumer.SelAll(true);
            if (Spartan_Report_Presentation_Types != null && Spartan_Report_Presentation_Types.Resource != null)
                ViewBag.Spartan_Report_Presentation_Types = Spartan_Report_Presentation_Types.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.PresentationTypeId)
                }).ToList();


            return View(model);  
        }

        [HttpGet]
        public ActionResult ShowAdvanceFilter(string previousFilters = "")
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_Report_Presentation_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Presentation_Types = _ISpartan_Report_Presentation_TypeApiConsumer.SelAll(true);
            if (Spartan_Report_Presentation_Types != null && Spartan_Report_Presentation_Types.Resource != null)
                ViewBag.Spartan_Report_Presentation_Types = Spartan_Report_Presentation_Types.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.PresentationTypeId)
                }).ToList();


            var previousFiltersObj = new Spartan_Report_Presentation_ViewAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Spartan_Report_Presentation_ViewAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Spartan_Report_Presentation_ViewAdvanceSearchModel());
            }

            ViewBag.Filter = new List<SelectListItem>
            {
                new SelectListItem() {Text = Resources.Resources.BeginWith, Value = "1"},
                new SelectListItem() {Text = Resources.Resources.EndWith, Value = "2"},
                new SelectListItem() {Text = Resources.Resources.Contains, Value = "4"},
                new SelectListItem() {Text = Resources.Resources.Exact, Value = "3"},

            };

            return View(previousFiltersObj);
        }

        public ActionResult Get()
        {
            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_Report_Presentation_ViewPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _ISpartan_Report_Presentation_ViewApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Report_Presentation_Views == null)
                result.Spartan_Report_Presentation_Views = new List<Spartan_Report_Presentation_View>();

            return Json(new
            {
                data = result.Spartan_Report_Presentation_Views.Select(m => new Spartan_Report_Presentation_ViewGridModel
                    {
                    PresentationViewId = m.PresentationViewId
			,Description = m.Description
                        ,Presentation_TypeDescription = (string)m.Presentation_Type_Spartan_Report_Presentation_Type.Description

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get List of Spartan_Report_Presentation_View from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Spartan_Report_Presentation_View Entity</returns>
        public ActionResult GetSpartan_Report_Presentation_ViewList(int sEcho, int iDisplayStart, int iDisplayLength)
        {
            int sortColumn = -1;
            string sortDirection = "asc";
            if (iDisplayLength == -1)
            {
                //length = TOTAL_ROWS;
                iDisplayLength = Int32.MaxValue;
            }
            // note: we only sort one column at a time
            if (Request.QueryString["iSortCol_0"] != null)
            {
                sortColumn = int.Parse(Request.QueryString["iSortCol_0"]);
            }
            if (Request.QueryString["sSortDir_0"] != null)
            {
                sortDirection = Request.QueryString["sSortDir_0"];
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_Report_Presentation_ViewApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Spartan_Report_Presentation_ViewPropertyMapper());

            //Adding Advance Search
            if (!string.IsNullOrEmpty(Request.QueryString["AdvanceSearch"]) && Request.QueryString["AdvanceSearch"] == "True")
            {
                var advanceFilter =
                    (Spartan_Report_Presentation_ViewAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            Spartan_Report_Presentation_ViewPropertyMapper oSpartan_Report_Presentation_ViewPropertyMapper = new Spartan_Report_Presentation_ViewPropertyMapper();

            configuration.OrderByClause = oSpartan_Report_Presentation_ViewPropertyMapper.GetPropertyName(Convert.ToString(Request.QueryString["mDataProp_" + sortColumn])) + " " + sortDirection;

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _ISpartan_Report_Presentation_ViewApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Report_Presentation_Views == null)
                result.Spartan_Report_Presentation_Views = new List<Spartan_Report_Presentation_View>();

            return Json(new
            {
                aaData = result.Spartan_Report_Presentation_Views.Select(m => new Spartan_Report_Presentation_ViewGridModel
            {
                    PresentationViewId = m.PresentationViewId
			,Description = m.Description
                        ,Presentation_TypeDescription = (string)m.Presentation_Type_Spartan_Report_Presentation_Type.Description

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }







        [NonAction]
        public string GetAdvanceFilter(Spartan_Report_Presentation_ViewAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromPresentationViewId) || !string.IsNullOrEmpty(filter.ToPresentationViewId))
            {
                if (!string.IsNullOrEmpty(filter.FromPresentationViewId))
                    where += " AND Spartan_Report_Presentation_View.PresentationViewId >= " + filter.FromPresentationViewId;
                if (!string.IsNullOrEmpty(filter.ToPresentationViewId))
                    where += " AND Spartan_Report_Presentation_View.PresentationViewId <= " + filter.ToPresentationViewId;
            }

            if (!string.IsNullOrEmpty(filter.Description))
            {
                switch (filter.DescriptionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Report_Presentation_View.Description LIKE '" + filter.Description + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Report_Presentation_View.Description LIKE '%" + filter.Description + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Report_Presentation_View.Description = '" + filter.Description + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Report_Presentation_View.Description LIKE '%" + filter.Description + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvancePresentation_Type))
            {
                switch (filter.Presentation_TypeFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Report_Presentation_Type.Description LIKE '" + filter.AdvancePresentation_Type + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Report_Presentation_Type.Description LIKE '%" + filter.AdvancePresentation_Type + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Report_Presentation_Type.Description = '" + filter.AdvancePresentation_Type + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Report_Presentation_Type.Description LIKE '%" + filter.AdvancePresentation_Type + "%'";
                        break;
                }
            }
            else if (filter.AdvancePresentation_TypeMultiple != null && filter.AdvancePresentation_TypeMultiple.Count() > 0)
            {
                var Presentation_TypeIds = string.Join(",", filter.AdvancePresentation_TypeMultiple);

                where += " AND Spartan_Report_Presentation_View.Presentation_Type In (" + Presentation_TypeIds + ")";
            }


            where = new Regex(Regex.Escape("AND ")).Replace(where, "", 1);
            return where;
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
                _ISpartan_Report_Presentation_ViewApiConsumer.SetAuthHeader(_tokenManager.Token);

                //Spartan_Report_Presentation_View varSpartan_Report_Presentation_View = null;
                if (id.ToString() != "0")
                {

                }
                var result = _ISpartan_Report_Presentation_ViewApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Spartan_Report_Presentation_ViewModel varSpartan_Report_Presentation_View)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _ISpartan_Report_Presentation_ViewApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Spartan_Report_Presentation_ViewInfo = new Spartan_Report_Presentation_View
                    {
                        PresentationViewId = varSpartan_Report_Presentation_View.PresentationViewId
                        ,Description = varSpartan_Report_Presentation_View.Description
                        ,Presentation_Type = varSpartan_Report_Presentation_View.Presentation_Type

                    };

                    result = !IsNew ?
                        _ISpartan_Report_Presentation_ViewApiConsumer.Update(Spartan_Report_Presentation_ViewInfo, null, null).Resource.ToString() :
                         _ISpartan_Report_Presentation_ViewApiConsumer.Insert(Spartan_Report_Presentation_ViewInfo, null, null).Resource.ToString();

                    return Json(result, JsonRequestBehavior.AllowGet);
				}
				return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }



        /// <summary>
        /// Write Element Array of Spartan_Report_Presentation_View script
        /// </summary>
        /// <param name="oSpartan_Report_Presentation_ViewElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Spartan_Report_Presentation_ViewModuleAttributeList)
        {
            for (int i = 0; i < Spartan_Report_Presentation_ViewModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Spartan_Report_Presentation_ViewModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Spartan_Report_Presentation_ViewModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Spartan_Report_Presentation_ViewModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Spartan_Report_Presentation_ViewModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Spartan_Report_Presentation_ViewModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Spartan_Report_Presentation_ViewModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Spartan_Report_Presentation_ViewModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Spartan_Report_Presentation_ViewModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Spartan_Report_Presentation_ViewModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Spartan_Report_Presentation_ViewModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strSpartan_Report_Presentation_ViewScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_Report_Presentation_View.js")))
            {
                strSpartan_Report_Presentation_ViewScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Spartan_Report_Presentation_View element attributes
            string userChangeJson = jsSerialize.Serialize(Spartan_Report_Presentation_ViewModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strSpartan_Report_Presentation_ViewScript.IndexOf("inpuElementArray");
            string splittedString = strSpartan_Report_Presentation_ViewScript.Substring(indexOfArray, strSpartan_Report_Presentation_ViewScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Spartan_Report_Presentation_ViewModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Spartan_Report_Presentation_ViewModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strSpartan_Report_Presentation_ViewScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strSpartan_Report_Presentation_ViewScript.Substring(indexOfArrayHistory, strSpartan_Report_Presentation_ViewScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strSpartan_Report_Presentation_ViewScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strSpartan_Report_Presentation_ViewScript.Substring(endIndexOfMainElement + indexOfArray, strSpartan_Report_Presentation_ViewScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Spartan_Report_Presentation_ViewModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strSpartan_Report_Presentation_ViewScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strSpartan_Report_Presentation_ViewScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strSpartan_Report_Presentation_ViewScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strSpartan_Report_Presentation_ViewScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Spartan_Report_Presentation_View.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Spartan_Report_Presentation_View.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_Report_Presentation_View.js")))
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
        public ActionResult Spartan_Report_Presentation_ViewPropertyBag()
        {
            return PartialView("Spartan_Report_Presentation_ViewPropertyBag", "Spartan_Report_Presentation_View");
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

            _ISpartan_Report_Presentation_ViewApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_Report_Presentation_ViewPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_Report_Presentation_ViewApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Report_Presentation_Views == null)
                result.Spartan_Report_Presentation_Views = new List<Spartan_Report_Presentation_View>();

            var data = result.Spartan_Report_Presentation_Views.Select(m => new Spartan_Report_Presentation_ViewGridModel
            {
                PresentationViewId = m.PresentationViewId
                ,Description = m.Description

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Spartan_Report_Presentation_ViewList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Spartan_Report_Presentation_ViewList_" + DateTime.Now.ToString());
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

            _ISpartan_Report_Presentation_ViewApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_Report_Presentation_ViewPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_Report_Presentation_ViewApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Report_Presentation_Views == null)
                result.Spartan_Report_Presentation_Views = new List<Spartan_Report_Presentation_View>();

            var data = result.Spartan_Report_Presentation_Views.Select(m => new Spartan_Report_Presentation_ViewGridModel
            {
                PresentationViewId = m.PresentationViewId
                ,Description = m.Description

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
