using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Funcionalidades_para_Notificacion;
using Spartane.Core.Domain.MS_Campos_por_Funcionalidad;

using Spartane.Core.Domain.Nombre_del_campo_en_MS;

using Spartane.Core.Domain.Estatus_de_Funcionalidad_para_Notificacion;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Funcionalidades_para_Notificacion;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Funcionalidades_para_Notificacion;
using Spartane.Web.Areas.WebApiConsumer.MS_Campos_por_Funcionalidad;

using Spartane.Web.Areas.WebApiConsumer.Nombre_del_campo_en_MS;

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
    public class Funcionalidades_para_NotificacionController : Controller
    {
        #region "variable declaration"

        private IFuncionalidades_para_NotificacionService service = null;
        private IFuncionalidades_para_NotificacionApiConsumer _IFuncionalidades_para_NotificacionApiConsumer;
        private IMS_Campos_por_FuncionalidadApiConsumer _IMS_Campos_por_FuncionalidadApiConsumer;

        private INombre_del_campo_en_MSApiConsumer _INombre_del_campo_en_MSApiConsumer;

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

        
        public Funcionalidades_para_NotificacionController(IFuncionalidades_para_NotificacionService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IFuncionalidades_para_NotificacionApiConsumer Funcionalidades_para_NotificacionApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer , IMS_Campos_por_FuncionalidadApiConsumer MS_Campos_por_FuncionalidadApiConsumer , INombre_del_campo_en_MSApiConsumer Nombre_del_campo_en_MSApiConsumer  , IEstatus_de_Funcionalidad_para_NotificacionApiConsumer Estatus_de_Funcionalidad_para_NotificacionApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IFuncionalidades_para_NotificacionApiConsumer = Funcionalidades_para_NotificacionApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_FormatApiConsumer = Spartan_FormatApiConsumer;
            this._ISpartan_Format_PermissionsApiConsumer = Spartan_Format_PermissionsApiConsumer;
            this._IGeneratePDFApiConsumer = GeneratePDFApiConsumer;
			this._ISpartan_FormatRelatedApiConsumer = Spartan_Format_RelatedApiConsumer;
            this._IMS_Campos_por_FuncionalidadApiConsumer = MS_Campos_por_FuncionalidadApiConsumer;

            this._INombre_del_campo_en_MSApiConsumer = Nombre_del_campo_en_MSApiConsumer;

            this._IEstatus_de_Funcionalidad_para_NotificacionApiConsumer = Estatus_de_Funcionalidad_para_NotificacionApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Funcionalidades_para_Notificacion
        [ObjectAuth(ObjectId = (ModuleObjectId)44704, PermissionType = PermissionTypes.Consult)]
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
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44704, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			          
            return View();
        }

        // GET: Frontal/Funcionalidades_para_Notificacion/Create
          [ObjectAuth(ObjectId = (ModuleObjectId)44704, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44704, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varFuncionalidades_para_Notificacion = new Funcionalidades_para_NotificacionModel();
			varFuncionalidades_para_Notificacion.Folio = Id;
			
            ViewBag.ObjectId = "44704";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;

            var permissionMS_Campos_por_Funcionalidad = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44720, ModuleId);
            ViewBag.PermissionMS_Campos_por_Funcionalidad = permissionMS_Campos_por_Funcionalidad;


            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
				
				_tokenManager.GenerateToken();
				_ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _IFuncionalidades_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Funcionalidades_para_NotificacionsData = _IFuncionalidades_para_NotificacionApiConsumer.ListaSelAll(0, 1000, "Funcionalidades_para_Notificacion.Folio=" + Id, "").Resource.Funcionalidades_para_Notificacions;
				
				if (Funcionalidades_para_NotificacionsData != null && Funcionalidades_para_NotificacionsData.Count > 0)
                {
					var Funcionalidades_para_NotificacionData = Funcionalidades_para_NotificacionsData.First();
					varFuncionalidades_para_Notificacion= new Funcionalidades_para_NotificacionModel
					{
						Folio  = Funcionalidades_para_NotificacionData.Folio 
	                    ,Funcionalidad = Funcionalidades_para_NotificacionData.Funcionalidad
                    ,Nombre_de_la_Tabla = Funcionalidades_para_NotificacionData.Nombre_de_la_Tabla
                    ,Campos_de_Estatus = Funcionalidades_para_NotificacionData.Campos_de_Estatus
                    ,Campos_de_EstatusCampo_para_Estatus = CultureHelper.GetTraduction(Convert.ToString(Funcionalidades_para_NotificacionData.Campos_de_Estatus), "Estatus_de_Funcionalidad_para_Notificacion") ??  (string)Funcionalidades_para_NotificacionData.Campos_de_Estatus_Estatus_de_Funcionalidad_para_Notificacion.Campo_para_Estatus
                    ,Validacion_Obligatoria = Funcionalidades_para_NotificacionData.Validacion_Obligatoria

					};
				}
				
				
				
            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_de_Funcionalidad_para_Notificacions_Campos_de_Estatus = _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.SelAll(true);
            if (Estatus_de_Funcionalidad_para_Notificacions_Campos_de_Estatus != null && Estatus_de_Funcionalidad_para_Notificacions_Campos_de_Estatus.Resource != null)
                ViewBag.Estatus_de_Funcionalidad_para_Notificacions_Campos_de_Estatus = Estatus_de_Funcionalidad_para_Notificacions_Campos_de_Estatus.Resource.Where(m => m.Campo_para_Estatus != null).OrderBy(m => m.Campo_para_Estatus).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Estatus_de_Funcionalidad_para_Notificacion", "Campo_para_Estatus") ?? m.Campo_para_Estatus.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


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

				
            return View(varFuncionalidades_para_Notificacion);
        }
		
	[HttpGet]
        public ActionResult AddFuncionalidades_para_Notificacion(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44704);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IFuncionalidades_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
			Funcionalidades_para_NotificacionModel varFuncionalidades_para_Notificacion= new Funcionalidades_para_NotificacionModel();
            var permissionMS_Campos_por_Funcionalidad = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44720, ModuleId);
            ViewBag.PermissionMS_Campos_por_Funcionalidad = permissionMS_Campos_por_Funcionalidad;


            if (id.ToString() != "0")
            {
                var Funcionalidades_para_NotificacionsData = _IFuncionalidades_para_NotificacionApiConsumer.ListaSelAll(0, 1000, "Funcionalidades_para_Notificacion.Folio=" + id, "").Resource.Funcionalidades_para_Notificacions;
				
				if (Funcionalidades_para_NotificacionsData != null && Funcionalidades_para_NotificacionsData.Count > 0)
                {
					var Funcionalidades_para_NotificacionData = Funcionalidades_para_NotificacionsData.First();
					varFuncionalidades_para_Notificacion= new Funcionalidades_para_NotificacionModel
					{
						Folio  = Funcionalidades_para_NotificacionData.Folio 
	                    ,Funcionalidad = Funcionalidades_para_NotificacionData.Funcionalidad
                    ,Nombre_de_la_Tabla = Funcionalidades_para_NotificacionData.Nombre_de_la_Tabla
                    ,Campos_de_Estatus = Funcionalidades_para_NotificacionData.Campos_de_Estatus
                    ,Campos_de_EstatusCampo_para_Estatus = CultureHelper.GetTraduction(Convert.ToString(Funcionalidades_para_NotificacionData.Campos_de_Estatus), "Estatus_de_Funcionalidad_para_Notificacion") ??  (string)Funcionalidades_para_NotificacionData.Campos_de_Estatus_Estatus_de_Funcionalidad_para_Notificacion.Campo_para_Estatus
                    ,Validacion_Obligatoria = Funcionalidades_para_NotificacionData.Validacion_Obligatoria

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_de_Funcionalidad_para_Notificacions_Campos_de_Estatus = _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.SelAll(true);
            if (Estatus_de_Funcionalidad_para_Notificacions_Campos_de_Estatus != null && Estatus_de_Funcionalidad_para_Notificacions_Campos_de_Estatus.Resource != null)
                ViewBag.Estatus_de_Funcionalidad_para_Notificacions_Campos_de_Estatus = Estatus_de_Funcionalidad_para_Notificacions_Campos_de_Estatus.Resource.Where(m => m.Campo_para_Estatus != null).OrderBy(m => m.Campo_para_Estatus).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Estatus_de_Funcionalidad_para_Notificacion", "Campo_para_Estatus") ?? m.Campo_para_Estatus.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            return PartialView("AddFuncionalidades_para_Notificacion", varFuncionalidades_para_Notificacion);
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
        public ActionResult GetEstatus_de_Funcionalidad_para_NotificacionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Campo_para_Estatus).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Estatus_de_Funcionalidad_para_Notificacion", "Campo_para_Estatus")?? m.Campo_para_Estatus,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
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
        public ActionResult ShowAdvanceFilter(Funcionalidades_para_NotificacionAdvanceSearchModel model, int idFilter = -1)
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

            _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_de_Funcionalidad_para_Notificacions_Campos_de_Estatus = _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.SelAll(true);
            if (Estatus_de_Funcionalidad_para_Notificacions_Campos_de_Estatus != null && Estatus_de_Funcionalidad_para_Notificacions_Campos_de_Estatus.Resource != null)
                ViewBag.Estatus_de_Funcionalidad_para_Notificacions_Campos_de_Estatus = Estatus_de_Funcionalidad_para_Notificacions_Campos_de_Estatus.Resource.Where(m => m.Campo_para_Estatus != null).OrderBy(m => m.Campo_para_Estatus).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Estatus_de_Funcionalidad_para_Notificacion", "Campo_para_Estatus") ?? m.Campo_para_Estatus.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            return View(model);  
        }

        [HttpGet]
        public ActionResult ShowAdvanceFilter(string previousFilters = "")
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_de_Funcionalidad_para_Notificacions_Campos_de_Estatus = _IEstatus_de_Funcionalidad_para_NotificacionApiConsumer.SelAll(true);
            if (Estatus_de_Funcionalidad_para_Notificacions_Campos_de_Estatus != null && Estatus_de_Funcionalidad_para_Notificacions_Campos_de_Estatus.Resource != null)
                ViewBag.Estatus_de_Funcionalidad_para_Notificacions_Campos_de_Estatus = Estatus_de_Funcionalidad_para_Notificacions_Campos_de_Estatus.Resource.Where(m => m.Campo_para_Estatus != null).OrderBy(m => m.Campo_para_Estatus).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Estatus_de_Funcionalidad_para_Notificacion", "Campo_para_Estatus") ?? m.Campo_para_Estatus.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            var previousFiltersObj = new Funcionalidades_para_NotificacionAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Funcionalidades_para_NotificacionAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Funcionalidades_para_NotificacionAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Funcionalidades_para_NotificacionPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IFuncionalidades_para_NotificacionApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Funcionalidades_para_Notificacions == null)
                result.Funcionalidades_para_Notificacions = new List<Funcionalidades_para_Notificacion>();

            return Json(new
            {
                data = result.Funcionalidades_para_Notificacions.Select(m => new Funcionalidades_para_NotificacionGridModel
                    {
                    Folio = m.Folio
			,Funcionalidad = m.Funcionalidad
			,Nombre_de_la_Tabla = m.Nombre_de_la_Tabla
                        ,Campos_de_EstatusCampo_para_Estatus = CultureHelper.GetTraduction(m.Campos_de_Estatus_Estatus_de_Funcionalidad_para_Notificacion.Folio.ToString(), "Campo_para_Estatus") ?? (string)m.Campos_de_Estatus_Estatus_de_Funcionalidad_para_Notificacion.Campo_para_Estatus
			,Validacion_Obligatoria = m.Validacion_Obligatoria

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }
		/*
		 [HttpGet]
        public ActionResult GetFuncionalidades_para_NotificacionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IFuncionalidades_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IFuncionalidades_para_NotificacionApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraductionNew(Convert.ToString(m.Folio), "Funcionalidades_para_Notificacion", m.),
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
        /// Get List of Funcionalidades_para_Notificacion from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Funcionalidades_para_Notificacion Entity</returns>
        public ActionResult GetFuncionalidades_para_NotificacionList(UrlParametersModel param)
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
            _IFuncionalidades_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);

          
            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new Funcionalidades_para_NotificacionPropertyMapper());
				
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
				if (Session["AdvanceSearch"].GetType() == typeof(Funcionalidades_para_NotificacionAdvanceSearchModel))
                {
					var advanceFilter =
                    (Funcionalidades_para_NotificacionAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            Funcionalidades_para_NotificacionPropertyMapper oFuncionalidades_para_NotificacionPropertyMapper = new Funcionalidades_para_NotificacionPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                 if (sortColumn != -1)
                    configuration.OrderByClause = oFuncionalidades_para_NotificacionPropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _IFuncionalidades_para_NotificacionApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Funcionalidades_para_Notificacions == null)
                result.Funcionalidades_para_Notificacions = new List<Funcionalidades_para_Notificacion>();

            return Json(new
            {
                aaData = result.Funcionalidades_para_Notificacions.Select(m => new Funcionalidades_para_NotificacionGridModel
            {
                    Folio = m.Folio
			,Funcionalidad = m.Funcionalidad
			,Nombre_de_la_Tabla = m.Nombre_de_la_Tabla
                        ,Campos_de_EstatusCampo_para_Estatus = CultureHelper.GetTraduction(m.Campos_de_Estatus_Estatus_de_Funcionalidad_para_Notificacion.Folio.ToString(), "Campo_para_Estatus") ?? (string)m.Campos_de_Estatus_Estatus_de_Funcionalidad_para_Notificacion.Campo_para_Estatus
			,Validacion_Obligatoria = m.Validacion_Obligatoria

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }


//Grid GetAutoComplete






        [NonAction]
        public string GetAdvanceFilter(Funcionalidades_para_NotificacionAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromFolio) || !string.IsNullOrEmpty(filter.ToFolio))
            {
                if (!string.IsNullOrEmpty(filter.FromFolio))
                    where += " AND Funcionalidades_para_Notificacion.Folio >= " + filter.FromFolio;
                if (!string.IsNullOrEmpty(filter.ToFolio))
                    where += " AND Funcionalidades_para_Notificacion.Folio <= " + filter.ToFolio;
            }

            if (!string.IsNullOrEmpty(filter.Funcionalidad))
            {
                switch (filter.FuncionalidadFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Funcionalidades_para_Notificacion.Funcionalidad LIKE '" + filter.Funcionalidad + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Funcionalidades_para_Notificacion.Funcionalidad LIKE '%" + filter.Funcionalidad + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Funcionalidades_para_Notificacion.Funcionalidad = '" + filter.Funcionalidad + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Funcionalidades_para_Notificacion.Funcionalidad LIKE '%" + filter.Funcionalidad + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Nombre_de_la_Tabla))
            {
                switch (filter.Nombre_de_la_TablaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Funcionalidades_para_Notificacion.Nombre_de_la_Tabla LIKE '" + filter.Nombre_de_la_Tabla + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Funcionalidades_para_Notificacion.Nombre_de_la_Tabla LIKE '%" + filter.Nombre_de_la_Tabla + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Funcionalidades_para_Notificacion.Nombre_de_la_Tabla = '" + filter.Nombre_de_la_Tabla + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Funcionalidades_para_Notificacion.Nombre_de_la_Tabla LIKE '%" + filter.Nombre_de_la_Tabla + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceCampos_de_Estatus))
            {
                switch (filter.Campos_de_EstatusFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Estatus_de_Funcionalidad_para_Notificacion.Campo_para_Estatus LIKE '" + filter.AdvanceCampos_de_Estatus + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Estatus_de_Funcionalidad_para_Notificacion.Campo_para_Estatus LIKE '%" + filter.AdvanceCampos_de_Estatus + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Estatus_de_Funcionalidad_para_Notificacion.Campo_para_Estatus = '" + filter.AdvanceCampos_de_Estatus + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Estatus_de_Funcionalidad_para_Notificacion.Campo_para_Estatus LIKE '%" + filter.AdvanceCampos_de_Estatus + "%'";
                        break;
                }
            }
            else if (filter.AdvanceCampos_de_EstatusMultiple != null && filter.AdvanceCampos_de_EstatusMultiple.Count() > 0)
            {
                var Campos_de_EstatusIds = string.Join(",", filter.AdvanceCampos_de_EstatusMultiple);

                where += " AND Funcionalidades_para_Notificacion.Campos_de_Estatus In (" + Campos_de_EstatusIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Validacion_Obligatoria))
            {
                switch (filter.Validacion_ObligatoriaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Funcionalidades_para_Notificacion.Validacion_Obligatoria LIKE '" + filter.Validacion_Obligatoria + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Funcionalidades_para_Notificacion.Validacion_Obligatoria LIKE '%" + filter.Validacion_Obligatoria + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Funcionalidades_para_Notificacion.Validacion_Obligatoria = '" + filter.Validacion_Obligatoria + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Funcionalidades_para_Notificacion.Validacion_Obligatoria LIKE '%" + filter.Validacion_Obligatoria + "%'";
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

[HttpGet]
        public ActionResult GetCampos_para_Vigencia_MS_Campos_por_FuncionalidadAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                
                _INombre_del_campo_en_MSApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _INombre_del_campo_en_MSApiConsumer.SelAll(false).Resource;

                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetMS_Campos_por_Funcionalidad(int draw, int start, int length, int RelationId = 0)
        {
            if (RelationId == 0)
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<MS_Campos_por_FuncionalidadGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IMS_Campos_por_FuncionalidadApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
			
var result = _IMS_Campos_por_FuncionalidadApiConsumer.ListaSelAll(start, pageSize, "MS_Campos_por_Funcionalidad.Folio_Funcionalidades_Notificacion=" + RelationId,"").Resource;

            if (result.MS_Campos_por_Funcionalidads == null)
                result.MS_Campos_por_Funcionalidads = new List<MS_Campos_por_Funcionalidad>();

            var jsonResult = Json(new
            {
                data = result.MS_Campos_por_Funcionalidads.Select(m => new MS_Campos_por_FuncionalidadGridModel
                {
                    Folio = m.Folio
					
                ,Campo = m.Campo
		,CampoDescripcion = m.Campo_Nombre_del_campo_en_MS.Descripcion


                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }


        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IFuncionalidades_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);

                Funcionalidades_para_Notificacion varFuncionalidades_para_Notificacion = null;
                if (id.ToString() != "0")
                {
                        string where = "";
                    _IMS_Campos_por_FuncionalidadApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "MS_Campos_por_Funcionalidad.Folio_Funcionalidades_Notificacion=" + id;
                    if("int" == "string")
                    {
	                where = "MS_Campos_por_Funcionalidad.Folio_Funcionalidades_Notificacion='" + id + "'";
                    }
                    var MS_Campos_por_FuncionalidadInfo =
                        _IMS_Campos_por_FuncionalidadApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (MS_Campos_por_FuncionalidadInfo.MS_Campos_por_Funcionalidads.Count > 0)
                    {
                        var resultMS_Campos_por_Funcionalidad = true;
                        //Removing associated job history with attachment
                        foreach (var MS_Campos_por_FuncionalidadItem in MS_Campos_por_FuncionalidadInfo.MS_Campos_por_Funcionalidads)
                            resultMS_Campos_por_Funcionalidad = resultMS_Campos_por_Funcionalidad
                                              && _IMS_Campos_por_FuncionalidadApiConsumer.Delete(MS_Campos_por_FuncionalidadItem.Folio, null,null).Resource;

                        if (!resultMS_Campos_por_Funcionalidad)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                var result = _IFuncionalidades_para_NotificacionApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Funcionalidades_para_NotificacionModel varFuncionalidades_para_Notificacion)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IFuncionalidades_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Funcionalidades_para_NotificacionInfo = new Funcionalidades_para_Notificacion
                    {
                        Folio = varFuncionalidades_para_Notificacion.Folio
                        ,Funcionalidad = varFuncionalidades_para_Notificacion.Funcionalidad
                        ,Nombre_de_la_Tabla = varFuncionalidades_para_Notificacion.Nombre_de_la_Tabla
                        ,Campos_de_Estatus = varFuncionalidades_para_Notificacion.Campos_de_Estatus
                        ,Validacion_Obligatoria = varFuncionalidades_para_Notificacion.Validacion_Obligatoria

                    };

                    result = !IsNew ?
                        _IFuncionalidades_para_NotificacionApiConsumer.Update(Funcionalidades_para_NotificacionInfo, null, null).Resource.ToString() :
                         _IFuncionalidades_para_NotificacionApiConsumer.Insert(Funcionalidades_para_NotificacionInfo, null, null).Resource.ToString();
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

        [NonAction]
        public bool CopyMS_Campos_por_Funcionalidad(int MasterId, int referenceId, List<MS_Campos_por_FuncionalidadGridModelPost> MS_Campos_por_FuncionalidadItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IMS_Campos_por_FuncionalidadApiConsumer.SetAuthHeader(_tokenManager.Token);

                var MS_Campos_por_FuncionalidadData = _IMS_Campos_por_FuncionalidadApiConsumer.ListaSelAll(1, int.MaxValue, "MS_Campos_por_Funcionalidad.Folio_Funcionalidades_Notificacion=" + referenceId,"").Resource;
                if (MS_Campos_por_FuncionalidadData == null || MS_Campos_por_FuncionalidadData.MS_Campos_por_Funcionalidads.Count == 0)
                    return true;

                var result = true;

                MS_Campos_por_FuncionalidadGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varMS_Campos_por_Funcionalidad in MS_Campos_por_FuncionalidadData.MS_Campos_por_Funcionalidads)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    MS_Campos_por_Funcionalidad MS_Campos_por_Funcionalidad1 = varMS_Campos_por_Funcionalidad;

                    if (MS_Campos_por_FuncionalidadItems != null && MS_Campos_por_FuncionalidadItems.Any(m => m.Folio == MS_Campos_por_Funcionalidad1.Folio))
                    {
                        modelDataToChange = MS_Campos_por_FuncionalidadItems.FirstOrDefault(m => m.Folio == MS_Campos_por_Funcionalidad1.Folio);
                    }
                    //Chaning Id Value
                    varMS_Campos_por_Funcionalidad.Folio_Funcionalidades_Notificacion = MasterId;
                    var insertId = _IMS_Campos_por_FuncionalidadApiConsumer.Insert(varMS_Campos_por_Funcionalidad,null,null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.Folio = insertId;

                    result = insertId > 0;
                }
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        public ActionResult PostMS_Campos_por_Funcionalidad(List<MS_Campos_por_FuncionalidadGridModelPost> MS_Campos_por_FuncionalidadItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyMS_Campos_por_Funcionalidad(MasterId, referenceId, MS_Campos_por_FuncionalidadItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (MS_Campos_por_FuncionalidadItems != null && MS_Campos_por_FuncionalidadItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IMS_Campos_por_FuncionalidadApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var MS_Campos_por_FuncionalidadItem in MS_Campos_por_FuncionalidadItems)
                    {



                        //Removal Request
                        if (MS_Campos_por_FuncionalidadItem.Removed)
                        {
                            result = result && _IMS_Campos_por_FuncionalidadApiConsumer.Delete(MS_Campos_por_FuncionalidadItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							MS_Campos_por_FuncionalidadItem.Folio = 0;

                        var MS_Campos_por_FuncionalidadData = new MS_Campos_por_Funcionalidad
                        {
                            Folio_Funcionalidades_Notificacion = MasterId
                            ,Folio = MS_Campos_por_FuncionalidadItem.Folio
                            ,Campo = (Convert.ToInt32(MS_Campos_por_FuncionalidadItem.Campo) == 0 ? (Int32?)null : Convert.ToInt32(MS_Campos_por_FuncionalidadItem.Campo))

                        };

                        var resultId = MS_Campos_por_FuncionalidadItem.Folio > 0
                           ? _IMS_Campos_por_FuncionalidadApiConsumer.Update(MS_Campos_por_FuncionalidadData,null,null).Resource
                           : _IMS_Campos_por_FuncionalidadApiConsumer.Insert(MS_Campos_por_FuncionalidadData,null,null).Resource;

                        result = result && resultId != -1;
                    }
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public ActionResult GetMS_Campos_por_Funcionalidad_Nombre_del_campo_en_MSAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _INombre_del_campo_en_MSApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _INombre_del_campo_en_MSApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Nombre_del_campo_en_MS", "Descripcion");
                  item.Descripcion= trans??item.Descripcion;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }



        /// <summary>
        /// Write Element Array of Funcionalidades_para_Notificacion script
        /// </summary>
        /// <param name="oFuncionalidades_para_NotificacionElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew Funcionalidades_para_NotificacionModuleAttributeList)
        {
            for (int i = 0; i < Funcionalidades_para_NotificacionModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Funcionalidades_para_NotificacionModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Funcionalidades_para_NotificacionModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Funcionalidades_para_NotificacionModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Funcionalidades_para_NotificacionModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Funcionalidades_para_NotificacionModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Funcionalidades_para_NotificacionModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < Funcionalidades_para_NotificacionModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(Funcionalidades_para_NotificacionModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							Funcionalidades_para_NotificacionModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(Funcionalidades_para_NotificacionModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							Funcionalidades_para_NotificacionModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strFuncionalidades_para_NotificacionScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Funcionalidades_para_Notificacion.js")))
            {
                strFuncionalidades_para_NotificacionScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Funcionalidades_para_Notificacion element attributes
            string userChangeJson = jsSerialize.Serialize(Funcionalidades_para_NotificacionModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strFuncionalidades_para_NotificacionScript.IndexOf("inpuElementArray");
            string splittedString = strFuncionalidades_para_NotificacionScript.Substring(indexOfArray, strFuncionalidades_para_NotificacionScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Funcionalidades_para_NotificacionModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Funcionalidades_para_NotificacionModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strFuncionalidades_para_NotificacionScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strFuncionalidades_para_NotificacionScript.Substring(indexOfArrayHistory, strFuncionalidades_para_NotificacionScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strFuncionalidades_para_NotificacionScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strFuncionalidades_para_NotificacionScript.Substring(endIndexOfMainElement + indexOfArray, strFuncionalidades_para_NotificacionScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (Funcionalidades_para_NotificacionModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in Funcionalidades_para_NotificacionModuleAttributeList.ChildModuleAttributeList)
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
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Funcionalidades_para_Notificacion.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Funcionalidades_para_Notificacion.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Funcionalidades_para_Notificacion.js")))
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
        public ActionResult Funcionalidades_para_NotificacionPropertyBag()
        {
            return PartialView("Funcionalidades_para_NotificacionPropertyBag", "Funcionalidades_para_Notificacion");
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

        [HttpGet]
        public ActionResult AddMS_Campos_por_Funcionalidad(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../MS_Campos_por_Funcionalidad/AddMS_Campos_por_Funcionalidad");
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
                var whereClauseFormat = "Object = 44704 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _IFuncionalidades_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Funcionalidades_para_Notificacion.Folio= " + RecordId;
                            var result = _IFuncionalidades_para_NotificacionApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
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

            _IFuncionalidades_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Funcionalidades_para_NotificacionPropertyMapper());
			
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
                    (Funcionalidades_para_NotificacionAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
			string sortDirection = "asc";

            Funcionalidades_para_NotificacionPropertyMapper oFuncionalidades_para_NotificacionPropertyMapper = new Funcionalidades_para_NotificacionPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oFuncionalidades_para_NotificacionPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IFuncionalidades_para_NotificacionApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Funcionalidades_para_Notificacions == null)
                result.Funcionalidades_para_Notificacions = new List<Funcionalidades_para_Notificacion>();

            var data = result.Funcionalidades_para_Notificacions.Select(m => new Funcionalidades_para_NotificacionGridModel
            {
                Folio = m.Folio
			,Funcionalidad = m.Funcionalidad
			,Nombre_de_la_Tabla = m.Nombre_de_la_Tabla
                        ,Campos_de_EstatusCampo_para_Estatus = CultureHelper.GetTraduction(m.Campos_de_Estatus_Estatus_de_Funcionalidad_para_Notificacion.Folio.ToString(), "Campo_para_Estatus") ?? (string)m.Campos_de_Estatus_Estatus_de_Funcionalidad_para_Notificacion.Campo_para_Estatus
			,Validacion_Obligatoria = m.Validacion_Obligatoria

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(44704, arrayColumnsVisible), "Funcionalidades_para_NotificacionList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(44704, arrayColumnsVisible), "Funcionalidades_para_NotificacionList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(44704, arrayColumnsVisible), "Funcionalidades_para_NotificacionList_" + DateTime.Now.ToString());
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

            _IFuncionalidades_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Funcionalidades_para_NotificacionPropertyMapper());
				
				
            if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
			if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (Funcionalidades_para_NotificacionAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            Funcionalidades_para_NotificacionPropertyMapper oFuncionalidades_para_NotificacionPropertyMapper = new Funcionalidades_para_NotificacionPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oFuncionalidades_para_NotificacionPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
			
			if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IFuncionalidades_para_NotificacionApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Funcionalidades_para_Notificacions == null)
                result.Funcionalidades_para_Notificacions = new List<Funcionalidades_para_Notificacion>();

            var data = result.Funcionalidades_para_Notificacions.Select(m => new Funcionalidades_para_NotificacionGridModel
            {
                Folio = m.Folio
			,Funcionalidad = m.Funcionalidad
			,Nombre_de_la_Tabla = m.Nombre_de_la_Tabla
                        ,Campos_de_EstatusCampo_para_Estatus = CultureHelper.GetTraduction(m.Campos_de_Estatus_Estatus_de_Funcionalidad_para_Notificacion.Folio.ToString(), "Campo_para_Estatus") ?? (string)m.Campos_de_Estatus_Estatus_de_Funcionalidad_para_Notificacion.Campo_para_Estatus
			,Validacion_Obligatoria = m.Validacion_Obligatoria

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
                _IFuncionalidades_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IFuncionalidades_para_NotificacionApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpPost]
        public ActionResult Post_Datos_Generales(Funcionalidades_para_Notificacion_Datos_GeneralesModel varFuncionalidades_para_Notificacion)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IFuncionalidades_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Funcionalidades_para_Notificacion_Datos_GeneralesInfo = new Funcionalidades_para_Notificacion_Datos_Generales
                {
                    Folio = varFuncionalidades_para_Notificacion.Folio
                                            ,Funcionalidad = varFuncionalidades_para_Notificacion.Funcionalidad
                        ,Nombre_de_la_Tabla = varFuncionalidades_para_Notificacion.Nombre_de_la_Tabla
                        ,Campos_de_Estatus = varFuncionalidades_para_Notificacion.Campos_de_Estatus
                        ,Validacion_Obligatoria = varFuncionalidades_para_Notificacion.Validacion_Obligatoria
                    
                };

                result = _IFuncionalidades_para_NotificacionApiConsumer.Update_Datos_Generales(Funcionalidades_para_Notificacion_Datos_GeneralesInfo).Resource.ToString();
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
                _IFuncionalidades_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IFuncionalidades_para_NotificacionApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				
                var result = new Funcionalidades_para_Notificacion_Datos_GeneralesModel
                {
                    Folio = m.Folio
			,Funcionalidad = m.Funcionalidad
			,Nombre_de_la_Tabla = m.Nombre_de_la_Tabla
                        ,Campos_de_Estatus = m.Campos_de_Estatus
                        ,Campos_de_EstatusCampo_para_Estatus = CultureHelper.GetTraduction(m.Campos_de_Estatus_Estatus_de_Funcionalidad_para_Notificacion.Folio.ToString(), "Campo_para_Estatus") ?? (string)m.Campos_de_Estatus_Estatus_de_Funcionalidad_para_Notificacion.Campo_para_Estatus
			,Validacion_Obligatoria = m.Validacion_Obligatoria

                    
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

