﻿using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Spartan_Traduction_Object;
using Spartane.Core.Domain.Spartan_Traduction_Object_Type;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Spartan_Traduction_Object;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Object;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Object_Type;

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

using Spartane.Web.Areas.WebApiConsumer.Spartan_Format;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Permissions;
using Spartane.Web.Areas.WebApiConsumer.GeneratePDF;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;

namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class Spartan_Traduction_ObjectController : Controller
    {
        #region "variable declaration"

        private ISpartan_Traduction_ObjectService service = null;
        private ISpartan_Traduction_ObjectApiConsumer _ISpartan_Traduction_ObjectApiConsumer;
        private ISpartan_Traduction_Object_TypeApiConsumer _ISpartan_Traduction_Object_TypeApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;
        private IGeneratePDFApiConsumer _IGeneratePDFApiConsumer;
        private ISpartan_FormatApiConsumer _ISpartan_FormatApiConsumer;
        private ISpartan_Format_PermissionsApiConsumer _ISpartan_Format_PermissionsApiConsumer;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Spartan_Traduction_ObjectController(ISpartan_Traduction_ObjectService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ISpartan_Traduction_ObjectApiConsumer Spartan_Traduction_ObjectApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer , ISpartan_Traduction_Object_TypeApiConsumer Spartan_Traduction_Object_TypeApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._ISpartan_Traduction_ObjectApiConsumer = Spartan_Traduction_ObjectApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_FormatApiConsumer = Spartan_FormatApiConsumer;
            this._ISpartan_Format_PermissionsApiConsumer = Spartan_Format_PermissionsApiConsumer;
            this._IGeneratePDFApiConsumer = GeneratePDFApiConsumer;
            this._ISpartan_Traduction_Object_TypeApiConsumer = Spartan_Traduction_Object_TypeApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Spartan_Traduction_Object
        [ObjectAuth(ObjectId = (ModuleObjectId)32361, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index(int ModuleId=0)
        {
			/*if (ModuleId == 0)
            {
                ModuleId = Convert.ToInt32(Session["CurrentModuleId"]);
                if (ModuleId == 0)
                {
                    Response.Redirect("~/Frontal/Accounts/UnAuthorized?controllerName=Spartan_Traduction_Object&ActionName=Index");
                }
            }*/
            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 32361, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);
            _ISpartan_Format_PermissionsApiConsumer.SetAuthHeader(_tokenManager.Token);
            _ISpartan_FormatApiConsumer.SetAuthHeader(_tokenManager.Token);

            var whereClause = " Spartan_Format_Permissions.Spartan_User_Role = " + SessionHelper.Role + " AND Spartan_Format_Permissions_Permission_Type = " + PermissionTypes.Consult + " AND Apply=1 ";
            var formatsPermisions=_ISpartan_Format_PermissionsApiConsumer.SelAll(false, whereClause, string.Empty);
            if (formatsPermisions != null && formatsPermisions.Resource != null)
            {
                var formats = string.Join(",", formatsPermisions.Resource.Select(f => f.Format).ToArray());
                var whereClauseFormat = "Object = 32361 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);
                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats!= null)
                {
                    ViewBag.Spartan_Formats = Spartan_Formats.Resource.Spartan_Formats.Select(m => new SelectListItem
                    {
                        Text = m.Format_Name.ToString(),
                        Value = Convert.ToString(m.FormatId)
                    }).ToList();

                }
            }
            return View();
        }

        // GET: Frontal/Spartan_Traduction_Object/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)32361, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 32361, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/Frontal/Accounts/UnAuthorized?controllerName=Spartan_Traduction_Object&ActionName=Create");
            }
            ViewBag.Permission = permission;
            var varSpartan_Traduction_Object = new Spartan_Traduction_ObjectModel();
			
            ViewBag.ObjectId = "32361";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Traduction_ObjectApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Spartan_Traduction_ObjectData = _ISpartan_Traduction_ObjectApiConsumer.GetByKeyComplete(Id).Resource.Spartan_Traduction_Objects[0];
                if (Spartan_Traduction_ObjectData == null)
                    return HttpNotFound();

                varSpartan_Traduction_Object = new Spartan_Traduction_ObjectModel
                {
                    IdObject = (int)Spartan_Traduction_ObjectData.IdObject
                    ,Object_Description = Spartan_Traduction_ObjectData.Object_Description
                    ,Object_Type = Spartan_Traduction_ObjectData.Object_Type
                    ,Object_TypeObject_Type_Description =  (string)Spartan_Traduction_ObjectData.Object_Type_Spartan_Traduction_Object_Type.Object_Type_Description

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_Traduction_Object_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Traduction_Object_Types_Object_Type = _ISpartan_Traduction_Object_TypeApiConsumer.SelAll(true);
            if (Spartan_Traduction_Object_Types_Object_Type != null && Spartan_Traduction_Object_Types_Object_Type.Resource != null)
                ViewBag.Spartan_Traduction_Object_Types_Object_Type = Spartan_Traduction_Object_Types_Object_Type.Resource.OrderBy(m => m.Object_Type_Description).Select(m => new SelectListItem
                {
                    Text = m.Object_Type_Description.ToString(), Value = Convert.ToString(m.IdType)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varSpartan_Traduction_Object);
        }
		
	[HttpGet]
        public ActionResult AddSpartan_Traduction_Object(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 32361);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _ISpartan_Traduction_ObjectApiConsumer.SetAuthHeader(_tokenManager.Token);
			Spartan_Traduction_ObjectModel varSpartan_Traduction_Object= new Spartan_Traduction_ObjectModel();


            if (id.ToString() != "0")
            {
                var Spartan_Traduction_ObjectsData = _ISpartan_Traduction_ObjectApiConsumer.ListaSelAll(0, 1000, "IdObject=" + id, "").Resource.Spartan_Traduction_Objects;
				
				if (Spartan_Traduction_ObjectsData != null && Spartan_Traduction_ObjectsData.Count > 0)
                {
					var Spartan_Traduction_ObjectData = Spartan_Traduction_ObjectsData.First();
					varSpartan_Traduction_Object= new Spartan_Traduction_ObjectModel
					{
						IdObject  = Spartan_Traduction_ObjectData.IdObject 
	                    ,Object_Description = Spartan_Traduction_ObjectData.Object_Description
                    ,Object_Type = Spartan_Traduction_ObjectData.Object_Type
                    ,Object_TypeObject_Type_Description =  (string)Spartan_Traduction_ObjectData.Object_Type_Spartan_Traduction_Object_Type.Object_Type_Description

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_Traduction_Object_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Traduction_Object_Types_Object_Type = _ISpartan_Traduction_Object_TypeApiConsumer.SelAll(true);
            if (Spartan_Traduction_Object_Types_Object_Type != null && Spartan_Traduction_Object_Types_Object_Type.Resource != null)
                ViewBag.Spartan_Traduction_Object_Types_Object_Type = Spartan_Traduction_Object_Types_Object_Type.Resource.OrderBy(m => m.Object_Type_Description).Select(m => new SelectListItem
                {
                    Text = m.Object_Type_Description.ToString(), Value = Convert.ToString(m.IdType)
                }).ToList();


            return PartialView("AddSpartan_Traduction_Object", varSpartan_Traduction_Object);
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
        public ActionResult GetSpartan_Traduction_Object_TypeAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Traduction_Object_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_Traduction_Object_TypeApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
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
        public ActionResult ShowAdvanceFilter(Spartan_Traduction_ObjectAdvanceSearchModel model)
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

            _ISpartan_Traduction_Object_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Traduction_Object_Types_Object_Type = _ISpartan_Traduction_Object_TypeApiConsumer.SelAll(true);
            if (Spartan_Traduction_Object_Types_Object_Type != null && Spartan_Traduction_Object_Types_Object_Type.Resource != null)
                ViewBag.Spartan_Traduction_Object_Types_Object_Type = Spartan_Traduction_Object_Types_Object_Type.Resource.OrderBy(m => m.Object_Type_Description).Select(m => new SelectListItem
                {
                    Text = m.Object_Type_Description.ToString(), Value = Convert.ToString(m.IdType)
                }).ToList();


            return View(model);  
        }

        [HttpGet]
        public ActionResult ShowAdvanceFilter(string previousFilters = "")
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_Traduction_Object_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Traduction_Object_Types_Object_Type = _ISpartan_Traduction_Object_TypeApiConsumer.SelAll(true);
            if (Spartan_Traduction_Object_Types_Object_Type != null && Spartan_Traduction_Object_Types_Object_Type.Resource != null)
                ViewBag.Spartan_Traduction_Object_Types_Object_Type = Spartan_Traduction_Object_Types_Object_Type.Resource.OrderBy(m => m.Object_Type_Description).Select(m => new SelectListItem
                {
                    Text = m.Object_Type_Description.ToString(), Value = Convert.ToString(m.IdType)
                }).ToList();


            var previousFiltersObj = new Spartan_Traduction_ObjectAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Spartan_Traduction_ObjectAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Spartan_Traduction_ObjectAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_Traduction_ObjectPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _ISpartan_Traduction_ObjectApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Traduction_Objects == null)
                result.Spartan_Traduction_Objects = new List<Spartan_Traduction_Object>();

            return Json(new
            {
                data = result.Spartan_Traduction_Objects.Select(m => new Spartan_Traduction_ObjectGridModel
                    {
                    IdObject = m.IdObject
			,Object_Description = m.Object_Description
                        ,Object_TypeObject_Type_Description = (string)m.Object_Type_Spartan_Traduction_Object_Type.Object_Type_Description

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get List of Spartan_Traduction_Object from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Spartan_Traduction_Object Entity</returns>
        public ActionResult GetSpartan_Traduction_ObjectList(int sEcho, int iDisplayStart, int iDisplayLength, string where, string order)
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
            _ISpartan_Traduction_ObjectApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Spartan_Traduction_ObjectPropertyMapper());
			if (!String.IsNullOrEmpty(where))
            {
                 configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
            if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            //Adding Advance Search
            if (!string.IsNullOrEmpty(Request.QueryString["AdvanceSearch"]) && Request.QueryString["AdvanceSearch"] == "True" && Session["AdvanceSearch"]!=null)
            {
				if (Session["AdvanceSearch"].GetType() == typeof(Spartan_Traduction_ObjectAdvanceSearchModel))
                {
					var advanceFilter =
                    (Spartan_Traduction_ObjectAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            Spartan_Traduction_ObjectPropertyMapper oSpartan_Traduction_ObjectPropertyMapper = new Spartan_Traduction_ObjectPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = oSpartan_Traduction_ObjectPropertyMapper.GetPropertyName(Convert.ToString(Request.QueryString["mDataProp_" + sortColumn])) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _ISpartan_Traduction_ObjectApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Traduction_Objects == null)
                result.Spartan_Traduction_Objects = new List<Spartan_Traduction_Object>();

            return Json(new
            {
                aaData = result.Spartan_Traduction_Objects.Select(m => new Spartan_Traduction_ObjectGridModel
            {
                    IdObject = m.IdObject
			,Object_Description = m.Object_Description
                        ,Object_TypeObject_Type_Description = (string)m.Object_Type_Spartan_Traduction_Object_Type.Object_Type_Description

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }







        [NonAction]
        public string GetAdvanceFilter(Spartan_Traduction_ObjectAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromIdObject) || !string.IsNullOrEmpty(filter.ToIdObject))
            {
                if (!string.IsNullOrEmpty(filter.FromIdObject))
                    where += " AND Spartan_Traduction_Object.IdObject >= " + filter.FromIdObject;
                if (!string.IsNullOrEmpty(filter.ToIdObject))
                    where += " AND Spartan_Traduction_Object.IdObject <= " + filter.ToIdObject;
            }

            if (!string.IsNullOrEmpty(filter.Object_Description))
            {
                switch (filter.Object_DescriptionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Traduction_Object.Object_Description LIKE '" + filter.Object_Description + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Traduction_Object.Object_Description LIKE '%" + filter.Object_Description + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Traduction_Object.Object_Description = '" + filter.Object_Description + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Traduction_Object.Object_Description LIKE '%" + filter.Object_Description + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceObject_Type))
            {
                switch (filter.Object_TypeFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Traduction_Object_Type.Object_Type_Description LIKE '" + filter.AdvanceObject_Type + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Traduction_Object_Type.Object_Type_Description LIKE '%" + filter.AdvanceObject_Type + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Traduction_Object_Type.Object_Type_Description = '" + filter.AdvanceObject_Type + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Traduction_Object_Type.Object_Type_Description LIKE '%" + filter.AdvanceObject_Type + "%'";
                        break;
                }
            }
            else if (filter.AdvanceObject_TypeMultiple != null && filter.AdvanceObject_TypeMultiple.Count() > 0)
            {
                var Object_TypeIds = string.Join(",", filter.AdvanceObject_TypeMultiple);

                where += " AND Spartan_Traduction_Object.Object_Type In (" + Object_TypeIds + ")";
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
                _ISpartan_Traduction_ObjectApiConsumer.SetAuthHeader(_tokenManager.Token);

                Spartan_Traduction_Object varSpartan_Traduction_Object = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _ISpartan_Traduction_ObjectApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Spartan_Traduction_ObjectModel varSpartan_Traduction_Object)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _ISpartan_Traduction_ObjectApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Spartan_Traduction_ObjectInfo = new Spartan_Traduction_Object
                    {
                        IdObject = varSpartan_Traduction_Object.IdObject
                        ,Object_Description = varSpartan_Traduction_Object.Object_Description
                        ,Object_Type = varSpartan_Traduction_Object.Object_Type

                    };

                    result = !IsNew ?
                        _ISpartan_Traduction_ObjectApiConsumer.Update(Spartan_Traduction_ObjectInfo, null, null).Resource.ToString() :
                         _ISpartan_Traduction_ObjectApiConsumer.Insert(Spartan_Traduction_ObjectInfo, null, null).Resource.ToString();
					Session["KeyValueInserted"] = result;
                    return Json(result, JsonRequestBehavior.AllowGet);
				//}
				//return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }



        /// <summary>
        /// Write Element Array of Spartan_Traduction_Object script
        /// </summary>
        /// <param name="oSpartan_Traduction_ObjectElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew Spartan_Traduction_ObjectModuleAttributeList)
        {
            for (int i = 0; i < Spartan_Traduction_ObjectModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Spartan_Traduction_ObjectModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Spartan_Traduction_ObjectModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Spartan_Traduction_ObjectModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Spartan_Traduction_ObjectModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Spartan_Traduction_ObjectModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Spartan_Traduction_ObjectModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < Spartan_Traduction_ObjectModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(Spartan_Traduction_ObjectModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							Spartan_Traduction_ObjectModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(Spartan_Traduction_ObjectModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							Spartan_Traduction_ObjectModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strSpartan_Traduction_ObjectScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_Traduction_Object.js")))
            {
                strSpartan_Traduction_ObjectScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Spartan_Traduction_Object element attributes
            string userChangeJson = jsSerialize.Serialize(Spartan_Traduction_ObjectModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strSpartan_Traduction_ObjectScript.IndexOf("inpuElementArray");
            string splittedString = strSpartan_Traduction_ObjectScript.Substring(indexOfArray, strSpartan_Traduction_ObjectScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Spartan_Traduction_ObjectModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Spartan_Traduction_ObjectModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strSpartan_Traduction_ObjectScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strSpartan_Traduction_ObjectScript.Substring(indexOfArrayHistory, strSpartan_Traduction_ObjectScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strSpartan_Traduction_ObjectScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strSpartan_Traduction_ObjectScript.Substring(endIndexOfMainElement + indexOfArray, strSpartan_Traduction_ObjectScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (Spartan_Traduction_ObjectModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in Spartan_Traduction_ObjectModuleAttributeList.ChildModuleAttributeList)
                {
				if (item!= null && item.elements != null  && item.elements.Count>0)
                    ResponseChild += "\r\n  \n\r function set" + item.table + "Validation() { " +
                                    " \r\n var inpuElementChildArray =" + jsSerialize.Serialize(item.elements) + ";" +
                                    "  \r\n setInputEntityAttributes(inpuElementChildArray, \".\", 0);" +
                                    "  \r\n setDynamicRenderElement(); \n\r } ";

                }
            }
            finalResponse = finalResponse.Substring(0, finalResponse.IndexOf("});") + 4) +  "\n\r";
            finalResponse += ResponseChild;
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Spartan_Traduction_Object.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Spartan_Traduction_Object.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_Traduction_Object.js")))
                {
                    strCustomScript = r.ReadToEnd();
                
                }

                int indexOfArray = strCustomScript.IndexOf("inpuElementArray");
                string splittedString = strCustomScript.Substring(indexOfArray, strCustomScript.Length - indexOfArray);                
                int indexOfMainElement = splittedString.IndexOf('[');                
                int endIndexOfMainElement = splittedString.IndexOf(']') + 1;                
                string mainJsonArray = splittedString.Substring(indexOfMainElement, endIndexOfMainElement - indexOfMainElement);

                int indexOfChildArray = strCustomScript.IndexOf("function set");
                string childJsonArray = "[";
                if (indexOfChildArray != -1)
                {
                    string splittedChildString = strCustomScript.Substring(indexOfChildArray, strCustomScript.Length - indexOfChildArray);

                    var funcionsValidations = splittedChildString.Split(new string[] { "function" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var str in funcionsValidations)
                    {
                        var tabla = str.Substring(0, str.IndexOf('('));
                        tabla = tabla.Trim().Replace("set", string.Empty).Replace("Validation", string.Empty);
                        childJsonArray += "{ \"table\": \"" + tabla + "\", \"elements\":";
                        int indexOfChildElement = str.IndexOf('[');
                        int endIndexOfChildElement = str.IndexOf(']') + 1;
                        childJsonArray += str.Substring(indexOfChildElement, endIndexOfChildElement - indexOfChildElement) + "},";
                    }
                }
                childJsonArray = childJsonArray.TrimEnd(',') + "]";
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
        public ActionResult Spartan_Traduction_ObjectPropertyBag()
        {
            return PartialView("Spartan_Traduction_ObjectPropertyBag", "Spartan_Traduction_Object");
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
        public FileStreamResult PrintFormats(int idFormat, string RecordId)
        {
            if (!_tokenManager.GenerateToken())
                return null;

            _IGeneratePDFApiConsumer.SetAuthHeader(_tokenManager.Token);
            var bytePdf= _IGeneratePDFApiConsumer.GeneratePDF(idFormat, RecordId);

            MemoryStream ms = new MemoryStream();
            ms.Write(bytePdf.Resource, 0, bytePdf.Resource.Length);
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Formatos.pdf");
            Response.Buffer = true;
            Response.Clear();
            Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
            Response.OutputStream.Flush();
            Response.End();

            return new FileStreamResult(Response.OutputStream, "application/pdf");
        }

        [HttpGet]
        public void Export(string format, int pageIndex, int pageSize)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);

            if (!_tokenManager.GenerateToken())
                return;

            _ISpartan_Traduction_ObjectApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Spartan_Traduction_ObjectPropertyMapper());
			
            //Adding Advance Search
            if (!string.IsNullOrEmpty(Request.QueryString["AdvanceSearch"]) && Request.QueryString["AdvanceSearch"] == "True")
            {
                var advanceFilter =
                    (Spartan_Traduction_ObjectAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_Traduction_ObjectApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Traduction_Objects == null)
                result.Spartan_Traduction_Objects = new List<Spartan_Traduction_Object>();

            var data = result.Spartan_Traduction_Objects.Select(m => new Spartan_Traduction_ObjectGridModel
            {
                IdObject = m.IdObject
			,Object_Description = m.Object_Description
                        ,Object_TypeObject_Type_Description = (string)m.Object_Type_Spartan_Traduction_Object_Type.Object_Type_Description

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Spartan_Traduction_ObjectList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Spartan_Traduction_ObjectList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(), "Spartan_Traduction_ObjectList_" + DateTime.Now.ToString());
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

            _ISpartan_Traduction_ObjectApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Spartan_Traduction_ObjectPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_Traduction_ObjectApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Traduction_Objects == null)
                result.Spartan_Traduction_Objects = new List<Spartan_Traduction_Object>();

            var data = result.Spartan_Traduction_Objects.Select(m => new Spartan_Traduction_ObjectGridModel
            {
                IdObject = m.IdObject
			,Object_Description = m.Object_Description
                        ,Object_TypeObject_Type_Description = (string)m.Object_Type_Spartan_Traduction_Object_Type.Object_Type_Description

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
