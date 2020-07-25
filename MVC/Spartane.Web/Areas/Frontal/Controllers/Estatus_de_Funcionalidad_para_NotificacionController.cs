using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Estatus_de_Funcionalidad_para_Notificacion;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Estatus_de_Funcionalidad_para_Notificacion;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Estatus_de_Funcionalidad_para_Notificacion;

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

using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Related;
using Spartane.Core.Domain.Spartan_Format;
using iTextSharp.text.pdf;


namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class Estatus_de_Funcionalidad_para_NotificacionController : Controller
    {
        #region "variable declaration"

        private IEstatus_de_Funcionalidad_para_NotificacionService service = null;
        private IEstatus_de_Funcionalidad_para_NotificacionApiConsumer _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;
        private IGeneratePDFApiConsumer _IGeneratePDFApiConsumer;
        private ISpartan_FormatApiConsumer _ISpartan_FormatApiConsumer;
        private ISpartan_Format_PermissionsApiConsumer _ISpartan_Format_PermissionsApiConsumer;
		private ISpartan_Format_RelatedApiConsumer _ISpartan_FormatRelatedApiConsumer;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Estatus_de_Funcionalidad_para_NotificacionController(IEstatus_de_Funcionalidad_para_NotificacionService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IEstatus_de_Funcionalidad_para_NotificacionApiConsumer Estatus_de_Funcionalidad_para_NotificacionApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IEstatus_de_Funcionalidad_para_NotificacionApiConsumer = Estatus_de_Funcionalidad_para_NotificacionApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_FormatApiConsumer = Spartan_FormatApiConsumer;
            this._ISpartan_Format_PermissionsApiConsumer = Spartan_Format_PermissionsApiConsumer;
            this._IGeneratePDFApiConsumer = GeneratePDFApiConsumer;
			this._ISpartan_FormatRelatedApiConsumer = Spartan_Format_RelatedApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Estatus_de_Funcionalidad_para_Notificacion
        [ObjectAuth(ObjectId = (ModuleObjectId)44719, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index(int ModuleId=0)
        {
			if (Session["AdvanceReportFilter"] != null)
            {
                Session["AdvanceReportFilter"] = null;
                Session["AdvanceSearch"] = null;
            }
			if (ModuleId == 0)
            {
                ModuleId = Convert.ToInt32(Session["CurrentModuleId"]);
                if (ModuleId == 0)
                {
                    Response.Redirect("~/");
                }
            }
            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44719, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			          
            return View();
        }

        // GET: Frontal/Estatus_de_Funcionalidad_para_Notificacion/Create
          [ObjectAuth(ObjectId = (ModuleObjectId)44719, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44719, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varEstatus_de_Funcionalidad_para_Notificacion = new Estatus_de_Funcionalidad_para_NotificacionModel();
			varEstatus_de_Funcionalidad_para_Notificacion.Folio = Id;
			
            ViewBag.ObjectId = "44719";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
				
				_tokenManager.GenerateToken();
				_ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Estatus_de_Funcionalidad_para_NotificacionsData = _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.ListaSelAll(0, 1000, "Estatus_de_Funcionalidad_para_Notificacion.Folio=" + Id, "").Resource.Estatus_de_Funcionalidad_para_Notificacions;
				
				if (Estatus_de_Funcionalidad_para_NotificacionsData != null && Estatus_de_Funcionalidad_para_NotificacionsData.Count > 0)
                {
					var Estatus_de_Funcionalidad_para_NotificacionData = Estatus_de_Funcionalidad_para_NotificacionsData.First();
					varEstatus_de_Funcionalidad_para_Notificacion= new Estatus_de_Funcionalidad_para_NotificacionModel
					{
						Folio  = Estatus_de_Funcionalidad_para_NotificacionData.Folio 
	                    ,Campo_para_Estatus = Estatus_de_Funcionalidad_para_NotificacionData.Campo_para_Estatus
                    ,Nombre_Fisico_del_Campo = Estatus_de_Funcionalidad_para_NotificacionData.Nombre_Fisico_del_Campo
                    ,Nombre_Fisico_de_la_Tabla = Estatus_de_Funcionalidad_para_NotificacionData.Nombre_Fisico_de_la_Tabla

					};
				}
				
				
				
            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);



            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
				
			var isPartial = false;
            var isMR = false;
            var nameMR = string.Empty;
            var nameAttribute = string.Empty;

	        if (Request.QueryString["isPartial"]!= null)
                isPartial = Convert.ToBoolean(Request.QueryString["isPartial"]);

            if (Request.QueryString["isMR"] != null)
                isMR = Convert.ToBoolean(Request.QueryString["isMR"]);

            if (Request.QueryString["nameMR"] != null)
                nameMR = Request.QueryString["nameMR"].ToString();

            if (Request.QueryString["nameAttribute"] != null)
                nameAttribute = Request.QueryString["nameAttribute"].ToString();
				
			ViewBag.isPartial=isPartial;
			ViewBag.isMR=isMR;
			ViewBag.nameMR=nameMR;
			ViewBag.nameAttribute=nameAttribute;

				
            return View(varEstatus_de_Funcionalidad_para_Notificacion);
        }
		
	[HttpGet]
        public ActionResult AddEstatus_de_Funcionalidad_para_Notificacion(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44719);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
			Estatus_de_Funcionalidad_para_NotificacionModel varEstatus_de_Funcionalidad_para_Notificacion= new Estatus_de_Funcionalidad_para_NotificacionModel();


            if (id.ToString() != "0")
            {
                var Estatus_de_Funcionalidad_para_NotificacionsData = _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.ListaSelAll(0, 1000, "Estatus_de_Funcionalidad_para_Notificacion.Folio=" + id, "").Resource.Estatus_de_Funcionalidad_para_Notificacions;
				
				if (Estatus_de_Funcionalidad_para_NotificacionsData != null && Estatus_de_Funcionalidad_para_NotificacionsData.Count > 0)
                {
					var Estatus_de_Funcionalidad_para_NotificacionData = Estatus_de_Funcionalidad_para_NotificacionsData.First();
					varEstatus_de_Funcionalidad_para_Notificacion= new Estatus_de_Funcionalidad_para_NotificacionModel
					{
						Folio  = Estatus_de_Funcionalidad_para_NotificacionData.Folio 
	                    ,Campo_para_Estatus = Estatus_de_Funcionalidad_para_NotificacionData.Campo_para_Estatus
                    ,Nombre_Fisico_del_Campo = Estatus_de_Funcionalidad_para_NotificacionData.Nombre_Fisico_del_Campo
                    ,Nombre_Fisico_de_la_Tabla = Estatus_de_Funcionalidad_para_NotificacionData.Nombre_Fisico_de_la_Tabla

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);



            return PartialView("AddEstatus_de_Funcionalidad_para_Notificacion", varEstatus_de_Funcionalidad_para_Notificacion);
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




        [HttpPost]
        public JsonResult ClearAdvanceFilter()
        {
            Session["AdvanceSearch"] = null;
            return Json(new { result = Session["AdvanceSearch"] == null }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ShowAdvanceFilter(Estatus_de_Funcionalidad_para_NotificacionAdvanceSearchModel model, int idFilter = -1)
        {
            if (ModelState.IsValid)
            {
                Session["AdvanceSearch"] = model;
				if (idFilter != -1)
                {
                    Session["AdvanceReportFilter"] = GetAdvanceFilter(model);
                    return RedirectToAction("Index", "Report", new { id = idFilter });
                }
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



            return View(model);  
        }

        [HttpGet]
        public ActionResult ShowAdvanceFilter(string previousFilters = "")
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);



            var previousFiltersObj = new Estatus_de_Funcionalidad_para_NotificacionAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Estatus_de_Funcionalidad_para_NotificacionAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Estatus_de_Funcionalidad_para_NotificacionAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Estatus_de_Funcionalidad_para_NotificacionPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Estatus_de_Funcionalidad_para_Notificacions == null)
                result.Estatus_de_Funcionalidad_para_Notificacions = new List<Estatus_de_Funcionalidad_para_Notificacion>();

            return Json(new
            {
                data = result.Estatus_de_Funcionalidad_para_Notificacions.Select(m => new Estatus_de_Funcionalidad_para_NotificacionGridModel
                    {
                    Folio = m.Folio
			,Campo_para_Estatus = m.Campo_para_Estatus
			,Nombre_Fisico_del_Campo = m.Nombre_Fisico_del_Campo
			,Nombre_Fisico_de_la_Tabla = m.Nombre_Fisico_de_la_Tabla

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }
		/*
		 [HttpGet]
        public ActionResult GetEstatus_de_Funcionalidad_para_NotificacionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraductionNew(Convert.ToString(m.Folio), "Estatus_de_Funcionalidad_para_Notificacion", m.),
                     Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
*/
        /// <summary>
        /// Get List of Estatus_de_Funcionalidad_para_Notificacion from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Estatus_de_Funcionalidad_para_Notificacion Entity</returns>
        public ActionResult GetEstatus_de_Funcionalidad_para_NotificacionList(UrlParametersModel param)
        {
			 int sEcho = param.sEcho;
            int iDisplayStart = param.iDisplayStart;
            int iDisplayLength = param.iDisplayLength;
            string where = param.where;
            string order = param.order;

            where = HttpUtility.UrlEncode(where);
            int sortColumn = -1;
            string sortDirection = "asc";
            if (iDisplayLength == -1)
            {
                //length = TOTAL_ROWS;
                iDisplayLength = Int32.MaxValue;
            }
            // note: we only sort one column at a time
            if (param.sortColumn != null)
            {
                sortColumn = int.Parse(param.sortColumn);
            }
            if (param.sortDirection != null)
            {
                sortDirection = param.sortDirection;
            }


            if (!_tokenManager.GenerateToken())
                return null;
            _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);

          
            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new Estatus_de_Funcionalidad_para_NotificacionPropertyMapper());
				
			if (!String.IsNullOrEmpty(where))
            {
                 configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
            if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            //Adding Advance Search
            if (param.AdvanceSearch != null && param.AdvanceSearch == true && Session["AdvanceSearch"] != null)            
            {
				if (Session["AdvanceSearch"].GetType() == typeof(Estatus_de_Funcionalidad_para_NotificacionAdvanceSearchModel))
                {
					var advanceFilter =
                    (Estatus_de_Funcionalidad_para_NotificacionAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            Estatus_de_Funcionalidad_para_NotificacionPropertyMapper oEstatus_de_Funcionalidad_para_NotificacionPropertyMapper = new Estatus_de_Funcionalidad_para_NotificacionPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                 if (sortColumn != -1)
                    configuration.OrderByClause = oEstatus_de_Funcionalidad_para_NotificacionPropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Estatus_de_Funcionalidad_para_Notificacions == null)
                result.Estatus_de_Funcionalidad_para_Notificacions = new List<Estatus_de_Funcionalidad_para_Notificacion>();

            return Json(new
            {
                aaData = result.Estatus_de_Funcionalidad_para_Notificacions.Select(m => new Estatus_de_Funcionalidad_para_NotificacionGridModel
            {
                    Folio = m.Folio
			,Campo_para_Estatus = m.Campo_para_Estatus
			,Nombre_Fisico_del_Campo = m.Nombre_Fisico_del_Campo
			,Nombre_Fisico_de_la_Tabla = m.Nombre_Fisico_de_la_Tabla

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }







        [NonAction]
        public string GetAdvanceFilter(Estatus_de_Funcionalidad_para_NotificacionAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromFolio) || !string.IsNullOrEmpty(filter.ToFolio))
            {
                if (!string.IsNullOrEmpty(filter.FromFolio))
                    where += " AND Estatus_de_Funcionalidad_para_Notificacion.Folio >= " + filter.FromFolio;
                if (!string.IsNullOrEmpty(filter.ToFolio))
                    where += " AND Estatus_de_Funcionalidad_para_Notificacion.Folio <= " + filter.ToFolio;
            }

            if (!string.IsNullOrEmpty(filter.Campo_para_Estatus))
            {
                switch (filter.Campo_para_EstatusFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Estatus_de_Funcionalidad_para_Notificacion.Campo_para_Estatus LIKE '" + filter.Campo_para_Estatus + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Estatus_de_Funcionalidad_para_Notificacion.Campo_para_Estatus LIKE '%" + filter.Campo_para_Estatus + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Estatus_de_Funcionalidad_para_Notificacion.Campo_para_Estatus = '" + filter.Campo_para_Estatus + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Estatus_de_Funcionalidad_para_Notificacion.Campo_para_Estatus LIKE '%" + filter.Campo_para_Estatus + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Nombre_Fisico_del_Campo))
            {
                switch (filter.Nombre_Fisico_del_CampoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Estatus_de_Funcionalidad_para_Notificacion.Nombre_Fisico_del_Campo LIKE '" + filter.Nombre_Fisico_del_Campo + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Estatus_de_Funcionalidad_para_Notificacion.Nombre_Fisico_del_Campo LIKE '%" + filter.Nombre_Fisico_del_Campo + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Estatus_de_Funcionalidad_para_Notificacion.Nombre_Fisico_del_Campo = '" + filter.Nombre_Fisico_del_Campo + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Estatus_de_Funcionalidad_para_Notificacion.Nombre_Fisico_del_Campo LIKE '%" + filter.Nombre_Fisico_del_Campo + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Nombre_Fisico_de_la_Tabla))
            {
                switch (filter.Nombre_Fisico_de_la_TablaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Estatus_de_Funcionalidad_para_Notificacion.Nombre_Fisico_de_la_Tabla LIKE '" + filter.Nombre_Fisico_de_la_Tabla + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Estatus_de_Funcionalidad_para_Notificacion.Nombre_Fisico_de_la_Tabla LIKE '%" + filter.Nombre_Fisico_de_la_Tabla + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Estatus_de_Funcionalidad_para_Notificacion.Nombre_Fisico_de_la_Tabla = '" + filter.Nombre_Fisico_de_la_Tabla + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Estatus_de_Funcionalidad_para_Notificacion.Nombre_Fisico_de_la_Tabla LIKE '%" + filter.Nombre_Fisico_de_la_Tabla + "%'";
                        break;
                }
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
                _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);

                Estatus_de_Funcionalidad_para_Notificacion varEstatus_de_Funcionalidad_para_Notificacion = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Estatus_de_Funcionalidad_para_NotificacionModel varEstatus_de_Funcionalidad_para_Notificacion)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Estatus_de_Funcionalidad_para_NotificacionInfo = new Estatus_de_Funcionalidad_para_Notificacion
                    {
                        Folio = varEstatus_de_Funcionalidad_para_Notificacion.Folio
                        ,Campo_para_Estatus = varEstatus_de_Funcionalidad_para_Notificacion.Campo_para_Estatus
                        ,Nombre_Fisico_del_Campo = varEstatus_de_Funcionalidad_para_Notificacion.Nombre_Fisico_del_Campo
                        ,Nombre_Fisico_de_la_Tabla = varEstatus_de_Funcionalidad_para_Notificacion.Nombre_Fisico_de_la_Tabla

                    };

                    result = !IsNew ?
                        _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.Update(Estatus_de_Funcionalidad_para_NotificacionInfo, null, null).Resource.ToString() :
                         _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.Insert(Estatus_de_Funcionalidad_para_NotificacionInfo, null, null).Resource.ToString();
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
        /// Write Element Array of Estatus_de_Funcionalidad_para_Notificacion script
        /// </summary>
        /// <param name="oEstatus_de_Funcionalidad_para_NotificacionElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew Estatus_de_Funcionalidad_para_NotificacionModuleAttributeList)
        {
            for (int i = 0; i < Estatus_de_Funcionalidad_para_NotificacionModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Estatus_de_Funcionalidad_para_NotificacionModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Estatus_de_Funcionalidad_para_NotificacionModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Estatus_de_Funcionalidad_para_NotificacionModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Estatus_de_Funcionalidad_para_NotificacionModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Estatus_de_Funcionalidad_para_NotificacionModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Estatus_de_Funcionalidad_para_NotificacionModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < Estatus_de_Funcionalidad_para_NotificacionModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(Estatus_de_Funcionalidad_para_NotificacionModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							Estatus_de_Funcionalidad_para_NotificacionModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(Estatus_de_Funcionalidad_para_NotificacionModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							Estatus_de_Funcionalidad_para_NotificacionModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strEstatus_de_Funcionalidad_para_NotificacionScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Estatus_de_Funcionalidad_para_Notificacion.js")))
            {
                strEstatus_de_Funcionalidad_para_NotificacionScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Estatus_de_Funcionalidad_para_Notificacion element attributes
            string userChangeJson = jsSerialize.Serialize(Estatus_de_Funcionalidad_para_NotificacionModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strEstatus_de_Funcionalidad_para_NotificacionScript.IndexOf("inpuElementArray");
            string splittedString = strEstatus_de_Funcionalidad_para_NotificacionScript.Substring(indexOfArray, strEstatus_de_Funcionalidad_para_NotificacionScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Estatus_de_Funcionalidad_para_NotificacionModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Estatus_de_Funcionalidad_para_NotificacionModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strEstatus_de_Funcionalidad_para_NotificacionScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strEstatus_de_Funcionalidad_para_NotificacionScript.Substring(indexOfArrayHistory, strEstatus_de_Funcionalidad_para_NotificacionScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strEstatus_de_Funcionalidad_para_NotificacionScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strEstatus_de_Funcionalidad_para_NotificacionScript.Substring(endIndexOfMainElement + indexOfArray, strEstatus_de_Funcionalidad_para_NotificacionScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (Estatus_de_Funcionalidad_para_NotificacionModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in Estatus_de_Funcionalidad_para_NotificacionModuleAttributeList.ChildModuleAttributeList)
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
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Estatus_de_Funcionalidad_para_Notificacion.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Estatus_de_Funcionalidad_para_Notificacion.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Estatus_de_Funcionalidad_para_Notificacion.js")))
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
        public ActionResult Estatus_de_Funcionalidad_para_NotificacionPropertyBag()
        {
            return PartialView("Estatus_de_Funcionalidad_para_NotificacionPropertyBag", "Estatus_de_Funcionalidad_para_Notificacion");
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
            _ISpartan_FormatRelatedApiConsumer.SetAuthHeader(_tokenManager.Token);

            MemoryStream ms = new MemoryStream();
           
            //Buscar los Formatos Relacionados
            var relacionados = _ISpartan_FormatRelatedApiConsumer.ListaSelAll(0, 5000, "Spartan_Format_Related.FormatId = " + idFormat, "").Resource.Spartan_Format_Relateds.OrderBy(r => r.Order).ToList();
            if (relacionados.Count > 0)
            {
                var outputDocument = new iTextSharp.text.Document();
                var writer = new PdfCopy(outputDocument, ms);
                outputDocument.Open();
                foreach (var spartan_Format_Related in relacionados)
                {
                    var bytePdf = _IGeneratePDFApiConsumer.GeneratePDF(Convert.ToInt32(spartan_Format_Related.FormatId_Related), RecordId).Resource;
                    var reader = new PdfReader(bytePdf);
                    for (var j = 1; j <= reader.NumberOfPages; j++)
                    {
                        writer.AddPage(writer.GetImportedPage(reader, j));
                    }
                    writer.FreeReader(reader);
                    reader.Close();
                }
                writer.Close();
                outputDocument.Close();
                var allPagesContent = ms.GetBuffer();
                ms.Flush();
            }
            else {
                var bytePdf = _IGeneratePDFApiConsumer.GeneratePDF(idFormat, RecordId);
                ms.Write(bytePdf.Resource, 0, bytePdf.Resource.Length);           
            }
                
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
        public ActionResult GetFormats(string RecordId)
        {
            if (!_tokenManager.GenerateToken())
                return null;

            var formatList = new List<SelectListItem>();

            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);
            _ISpartan_Format_PermissionsApiConsumer.SetAuthHeader(_tokenManager.Token);
           _ISpartan_FormatApiConsumer.SetAuthHeader(_tokenManager.Token);

            var whereClause = " Spartan_Format_Permissions.Spartan_User_Role = " + SessionHelper.Role + " AND Spartan_Format_Permissions.Permission_Type = 1 AND Apply=1 ";
            var formatsPermisions = _ISpartan_Format_PermissionsApiConsumer.ListaSelAll(0, 500, whereClause, string.Empty).Resource;
            if (formatsPermisions.RowCount > 0)
            {
                var formats = string.Join(",", formatsPermisions.Spartan_Format_Permissionss.Select(f => f.Format).ToArray());
                var whereClauseFormat = "Object = 44719 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Estatus_de_Funcionalidad_para_Notificacion.Folio= " + RecordId;
                            var result = _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
                            if (result != null && result.Resource != null && result.Resource.RowCount > 0)
                            {
                                formatList.Add(new SelectListItem
                                {
                                    Text =  CultureHelper.GetTraductionAdd(format.FormatId.ToString(), "Format", format.Format_Name),
                                    Value = Convert.ToString(format.FormatId)
                                });
                            }
                        }
                        else
                        {
                            formatList.Add(new SelectListItem
                            {
                                Text =  CultureHelper.GetTraductionAdd(format.FormatId.ToString(), "Format", format.Format_Name),
                                Value = Convert.ToString(format.FormatId)
                            });
                        }


                    }
                }
            }
            return Json(formatList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public void Export(string format, int pageIndex, int pageSize, string iSortCol, string sSortDir, string where, string order, dynamic columnsVisible)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);
										  
			string[] arrayColumnsVisible = ((string[])columnsVisible)[0].ToString().Split(',');

			 where = HttpUtility.UrlEncode(where);
            if (!_tokenManager.GenerateToken())
                return;

            _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Estatus_de_Funcionalidad_para_NotificacionPropertyMapper());
			
			 if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
            if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            //Adding Advance Search
            if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (Estatus_de_Funcionalidad_para_NotificacionAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
			string sortDirection = "asc";

            Estatus_de_Funcionalidad_para_NotificacionPropertyMapper oEstatus_de_Funcionalidad_para_NotificacionPropertyMapper = new Estatus_de_Funcionalidad_para_NotificacionPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oEstatus_de_Funcionalidad_para_NotificacionPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Estatus_de_Funcionalidad_para_Notificacions == null)
                result.Estatus_de_Funcionalidad_para_Notificacions = new List<Estatus_de_Funcionalidad_para_Notificacion>();

            var data = result.Estatus_de_Funcionalidad_para_Notificacions.Select(m => new Estatus_de_Funcionalidad_para_NotificacionGridModel
            {
                Folio = m.Folio
			,Campo_para_Estatus = m.Campo_para_Estatus
			,Nombre_Fisico_del_Campo = m.Nombre_Fisico_del_Campo
			,Nombre_Fisico_de_la_Tabla = m.Nombre_Fisico_de_la_Tabla

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(44719, arrayColumnsVisible), "Estatus_de_Funcionalidad_para_NotificacionList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(44719, arrayColumnsVisible), "Estatus_de_Funcionalidad_para_NotificacionList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(44719, arrayColumnsVisible), "Estatus_de_Funcionalidad_para_NotificacionList_" + DateTime.Now.ToString());
                    break;
            }
        }

        [HttpGet]
        //[ObjectAuth(ObjectId = ModuleObjectId.EMPLEADOS_OBJECT, PermissionType = PermissionTypes.Export)]
        public ActionResult Print(string format, int pageIndex, int pageSize, string iSortCol, string sSortDir,string where, string order)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);

			where = HttpUtility.UrlEncode(where);
										   
            if (!_tokenManager.GenerateToken())
                return null;

            _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Estatus_de_Funcionalidad_para_NotificacionPropertyMapper());
				
				
            if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
			if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (Estatus_de_Funcionalidad_para_NotificacionAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            Estatus_de_Funcionalidad_para_NotificacionPropertyMapper oEstatus_de_Funcionalidad_para_NotificacionPropertyMapper = new Estatus_de_Funcionalidad_para_NotificacionPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oEstatus_de_Funcionalidad_para_NotificacionPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
			
			if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Estatus_de_Funcionalidad_para_Notificacions == null)
                result.Estatus_de_Funcionalidad_para_Notificacions = new List<Estatus_de_Funcionalidad_para_Notificacion>();

            var data = result.Estatus_de_Funcionalidad_para_Notificacions.Select(m => new Estatus_de_Funcionalidad_para_NotificacionGridModel
            {
                Folio = m.Folio
			,Campo_para_Estatus = m.Campo_para_Estatus
			,Nombre_Fisico_del_Campo = m.Nombre_Fisico_del_Campo
			,Nombre_Fisico_de_la_Tabla = m.Nombre_Fisico_de_la_Tabla

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
		
		[HttpGet]
        public JsonResult CreateID()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpPost]
        public ActionResult Post_Datos_Generales(Estatus_de_Funcionalidad_para_Notificacion_Datos_GeneralesModel varEstatus_de_Funcionalidad_para_Notificacion)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Estatus_de_Funcionalidad_para_Notificacion_Datos_GeneralesInfo = new Estatus_de_Funcionalidad_para_Notificacion_Datos_Generales
                {
                    Folio = varEstatus_de_Funcionalidad_para_Notificacion.Folio
                                            ,Campo_para_Estatus = varEstatus_de_Funcionalidad_para_Notificacion.Campo_para_Estatus
                        ,Nombre_Fisico_del_Campo = varEstatus_de_Funcionalidad_para_Notificacion.Nombre_Fisico_del_Campo
                        ,Nombre_Fisico_de_la_Tabla = varEstatus_de_Funcionalidad_para_Notificacion.Nombre_Fisico_de_la_Tabla
                    
                };

                result = _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.Update_Datos_Generales(Estatus_de_Funcionalidad_para_Notificacion_Datos_GeneralesInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Datos_Generales(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				
                var result = new Estatus_de_Funcionalidad_para_Notificacion_Datos_GeneralesModel
                {
                    Folio = m.Folio
			,Campo_para_Estatus = m.Campo_para_Estatus
			,Nombre_Fisico_del_Campo = m.Nombre_Fisico_del_Campo
			,Nombre_Fisico_de_la_Tabla = m.Nombre_Fisico_de_la_Tabla

                    
                };
				var resultData = new
                {
                    data = result

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }


    }
}

