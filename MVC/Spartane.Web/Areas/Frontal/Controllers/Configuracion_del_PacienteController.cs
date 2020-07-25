using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Configuracion_del_Paciente;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Detalle_Notificaciones_Paciente;

using Spartane.Core.Domain.Funcionalidades_para_Notificacion;


using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Configuracion_del_Paciente;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Configuracion_del_Paciente;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Notificaciones_Paciente;

using Spartane.Web.Areas.WebApiConsumer.Funcionalidades_para_Notificacion;


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
    public class Configuracion_del_PacienteController : Controller
    {
        #region "variable declaration"

        private IConfiguracion_del_PacienteService service = null;
        private IConfiguracion_del_PacienteApiConsumer _IConfiguracion_del_PacienteApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private IDetalle_Notificaciones_PacienteApiConsumer _IDetalle_Notificaciones_PacienteApiConsumer;

        private IFuncionalidades_para_NotificacionApiConsumer _IFuncionalidades_para_NotificacionApiConsumer;


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

        
        public Configuracion_del_PacienteController(IConfiguracion_del_PacienteService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IConfiguracion_del_PacienteApiConsumer Configuracion_del_PacienteApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer , IDetalle_Notificaciones_PacienteApiConsumer Detalle_Notificaciones_PacienteApiConsumer , IFuncionalidades_para_NotificacionApiConsumer Funcionalidades_para_NotificacionApiConsumer  )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IConfiguracion_del_PacienteApiConsumer = Configuracion_del_PacienteApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_FormatApiConsumer = Spartan_FormatApiConsumer;
            this._ISpartan_Format_PermissionsApiConsumer = Spartan_Format_PermissionsApiConsumer;
            this._IGeneratePDFApiConsumer = GeneratePDFApiConsumer;
			this._ISpartan_FormatRelatedApiConsumer = Spartan_Format_RelatedApiConsumer;
            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;
            this._IDetalle_Notificaciones_PacienteApiConsumer = Detalle_Notificaciones_PacienteApiConsumer;

            this._IFuncionalidades_para_NotificacionApiConsumer = Funcionalidades_para_NotificacionApiConsumer;


        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Configuracion_del_Paciente
        [ObjectAuth(ObjectId = (ModuleObjectId)44693, PermissionType = PermissionTypes.Consult)]
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
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44693, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			          
            return View();
        }

        // GET: Frontal/Configuracion_del_Paciente/Create
          [ObjectAuth(ObjectId = (ModuleObjectId)44693, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44693, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varConfiguracion_del_Paciente = new Configuracion_del_PacienteModel();
			varConfiguracion_del_Paciente.Folio = Id;
			
            ViewBag.ObjectId = "44693";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;

            var permissionDetalle_Notificaciones_Paciente = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44695, ModuleId);
            ViewBag.PermissionDetalle_Notificaciones_Paciente = permissionDetalle_Notificaciones_Paciente;


            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
				
				_tokenManager.GenerateToken();
				_ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _IConfiguracion_del_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Configuracion_del_PacientesData = _IConfiguracion_del_PacienteApiConsumer.ListaSelAll(0, 1000, "Configuracion_del_Paciente.Folio=" + Id, "").Resource.Configuracion_del_Pacientes;
				
				if (Configuracion_del_PacientesData != null && Configuracion_del_PacientesData.Count > 0)
                {
					var Configuracion_del_PacienteData = Configuracion_del_PacientesData.First();
					varConfiguracion_del_Paciente= new Configuracion_del_PacienteModel
					{
						Folio  = Configuracion_del_PacienteData.Folio 
	                    ,Fecha_de_Registro = (Configuracion_del_PacienteData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(Configuracion_del_PacienteData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = Configuracion_del_PacienteData.Hora_de_Registro
                    ,Usuario_Registrado = Configuracion_del_PacienteData.Usuario_Registrado
                    ,Usuario_RegistradoName = CultureHelper.GetTraduction(Convert.ToString(Configuracion_del_PacienteData.Usuario_Registrado), "Spartan_User") ??  (string)Configuracion_del_PacienteData.Usuario_Registrado_Spartan_User.Name
                    ,Rol = Configuracion_del_PacienteData.Rol
                    ,Token = Configuracion_del_PacienteData.Token
                    ,Android = Configuracion_del_PacienteData.Android.GetValueOrDefault()
                    ,iOS = Configuracion_del_PacienteData.iOS.GetValueOrDefault()
                    ,Permite_notificaciones_por_email = Configuracion_del_PacienteData.Permite_notificaciones_por_email.GetValueOrDefault()
                    ,Permite_notificaciones_push = Configuracion_del_PacienteData.Permite_notificaciones_push.GetValueOrDefault()

					};
				}
				
				
				
            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_Registrado = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_Registrado != null && Spartan_Users_Usuario_Registrado.Resource != null)
                ViewBag.Spartan_Users_Usuario_Registrado = Spartan_Users_Usuario_Registrado.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
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

				
            return View(varConfiguracion_del_Paciente);
        }
		
	[HttpGet]
        public ActionResult AddConfiguracion_del_Paciente(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44693);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IConfiguracion_del_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
			Configuracion_del_PacienteModel varConfiguracion_del_Paciente= new Configuracion_del_PacienteModel();
            var permissionDetalle_Notificaciones_Paciente = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44695, ModuleId);
            ViewBag.PermissionDetalle_Notificaciones_Paciente = permissionDetalle_Notificaciones_Paciente;


            if (id.ToString() != "0")
            {
                var Configuracion_del_PacientesData = _IConfiguracion_del_PacienteApiConsumer.ListaSelAll(0, 1000, "Configuracion_del_Paciente.Folio=" + id, "").Resource.Configuracion_del_Pacientes;
				
				if (Configuracion_del_PacientesData != null && Configuracion_del_PacientesData.Count > 0)
                {
					var Configuracion_del_PacienteData = Configuracion_del_PacientesData.First();
					varConfiguracion_del_Paciente= new Configuracion_del_PacienteModel
					{
						Folio  = Configuracion_del_PacienteData.Folio 
	                    ,Fecha_de_Registro = (Configuracion_del_PacienteData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(Configuracion_del_PacienteData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = Configuracion_del_PacienteData.Hora_de_Registro
                    ,Usuario_Registrado = Configuracion_del_PacienteData.Usuario_Registrado
                    ,Usuario_RegistradoName = CultureHelper.GetTraduction(Convert.ToString(Configuracion_del_PacienteData.Usuario_Registrado), "Spartan_User") ??  (string)Configuracion_del_PacienteData.Usuario_Registrado_Spartan_User.Name
                    ,Rol = Configuracion_del_PacienteData.Rol
                    ,Token = Configuracion_del_PacienteData.Token
                    ,Android = Configuracion_del_PacienteData.Android.GetValueOrDefault()
                    ,iOS = Configuracion_del_PacienteData.iOS.GetValueOrDefault()
                    ,Permite_notificaciones_por_email = Configuracion_del_PacienteData.Permite_notificaciones_por_email.GetValueOrDefault()
                    ,Permite_notificaciones_push = Configuracion_del_PacienteData.Permite_notificaciones_push.GetValueOrDefault()

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_Registrado = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_Registrado != null && Spartan_Users_Usuario_Registrado.Resource != null)
                ViewBag.Spartan_Users_Usuario_Registrado = Spartan_Users_Usuario_Registrado.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();


            return PartialView("AddConfiguracion_del_Paciente", varConfiguracion_del_Paciente);
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
        public ActionResult GetSpartan_UserAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_UserApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name")?? m.Name,
                    Value = Convert.ToString(m.Id_User)
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
        public ActionResult ShowAdvanceFilter(Configuracion_del_PacienteAdvanceSearchModel model, int idFilter = -1)
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

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_Registrado = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_Registrado != null && Spartan_Users_Usuario_Registrado.Resource != null)
                ViewBag.Spartan_Users_Usuario_Registrado = Spartan_Users_Usuario_Registrado.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();


            return View(model);  
        }

        [HttpGet]
        public ActionResult ShowAdvanceFilter(string previousFilters = "")
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_Registrado = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_Registrado != null && Spartan_Users_Usuario_Registrado.Resource != null)
                ViewBag.Spartan_Users_Usuario_Registrado = Spartan_Users_Usuario_Registrado.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();


            var previousFiltersObj = new Configuracion_del_PacienteAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Configuracion_del_PacienteAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Configuracion_del_PacienteAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Configuracion_del_PacientePropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IConfiguracion_del_PacienteApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Configuracion_del_Pacientes == null)
                result.Configuracion_del_Pacientes = new List<Configuracion_del_Paciente>();

            return Json(new
            {
                data = result.Configuracion_del_Pacientes.Select(m => new Configuracion_del_PacienteGridModel
                    {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_RegistradoName = CultureHelper.GetTraduction(m.Usuario_Registrado_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_Registrado_Spartan_User.Name
			,Rol = m.Rol
			,Token = m.Token
			,Android = m.Android
			,iOS = m.iOS
			,Permite_notificaciones_por_email = m.Permite_notificaciones_por_email
			,Permite_notificaciones_push = m.Permite_notificaciones_push

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }
		/*
		 [HttpGet]
        public ActionResult GetConfiguracion_del_PacienteAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IConfiguracion_del_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IConfiguracion_del_PacienteApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraductionNew(Convert.ToString(m.Folio), "Configuracion_del_Paciente", m.),
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
        /// Get List of Configuracion_del_Paciente from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Configuracion_del_Paciente Entity</returns>
        public ActionResult GetConfiguracion_del_PacienteList(UrlParametersModel param)
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
            _IConfiguracion_del_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);

          
            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new Configuracion_del_PacientePropertyMapper());
				
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
				if (Session["AdvanceSearch"].GetType() == typeof(Configuracion_del_PacienteAdvanceSearchModel))
                {
					var advanceFilter =
                    (Configuracion_del_PacienteAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            Configuracion_del_PacientePropertyMapper oConfiguracion_del_PacientePropertyMapper = new Configuracion_del_PacientePropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                 if (sortColumn != -1)
                    configuration.OrderByClause = oConfiguracion_del_PacientePropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _IConfiguracion_del_PacienteApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Configuracion_del_Pacientes == null)
                result.Configuracion_del_Pacientes = new List<Configuracion_del_Paciente>();

            return Json(new
            {
                aaData = result.Configuracion_del_Pacientes.Select(m => new Configuracion_del_PacienteGridModel
            {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_RegistradoName = CultureHelper.GetTraduction(m.Usuario_Registrado_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_Registrado_Spartan_User.Name
			,Rol = m.Rol
			,Token = m.Token
			,Android = m.Android
			,iOS = m.iOS
			,Permite_notificaciones_por_email = m.Permite_notificaciones_por_email
			,Permite_notificaciones_push = m.Permite_notificaciones_push

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }


//Grid GetAutoComplete






        [NonAction]
        public string GetAdvanceFilter(Configuracion_del_PacienteAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromFolio) || !string.IsNullOrEmpty(filter.ToFolio))
            {
                if (!string.IsNullOrEmpty(filter.FromFolio))
                    where += " AND Configuracion_del_Paciente.Folio >= " + filter.FromFolio;
                if (!string.IsNullOrEmpty(filter.ToFolio))
                    where += " AND Configuracion_del_Paciente.Folio <= " + filter.ToFolio;
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro) || !string.IsNullOrEmpty(filter.ToFecha_de_Registro))
            {
                var Fecha_de_RegistroFrom = DateTime.ParseExact(filter.FromFecha_de_Registro, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_de_RegistroTo = DateTime.ParseExact(filter.ToFecha_de_Registro, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro))
                    where += " AND Configuracion_del_Paciente.Fecha_de_Registro >= '" + Fecha_de_RegistroFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_Registro))
                    where += " AND Configuracion_del_Paciente.Fecha_de_Registro <= '" + Fecha_de_RegistroTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromHora_de_Registro) || !string.IsNullOrEmpty(filter.ToHora_de_Registro))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_de_Registro))
                    where += " AND Convert(TIME,Configuracion_del_Paciente.Hora_de_Registro) >='" + filter.FromHora_de_Registro + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_de_Registro))
                    where += " AND Convert(TIME,Configuracion_del_Paciente.Hora_de_Registro) <='" + filter.ToHora_de_Registro + "'";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceUsuario_Registrado))
            {
                switch (filter.Usuario_RegistradoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_User.Name LIKE '" + filter.AdvanceUsuario_Registrado + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceUsuario_Registrado + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_User.Name = '" + filter.AdvanceUsuario_Registrado + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceUsuario_Registrado + "%'";
                        break;
                }
            }
            else if (filter.AdvanceUsuario_RegistradoMultiple != null && filter.AdvanceUsuario_RegistradoMultiple.Count() > 0)
            {
                var Usuario_RegistradoIds = string.Join(",", filter.AdvanceUsuario_RegistradoMultiple);

                where += " AND Configuracion_del_Paciente.Usuario_Registrado In (" + Usuario_RegistradoIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Rol))
            {
                switch (filter.RolFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Configuracion_del_Paciente.Rol LIKE '" + filter.Rol + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Configuracion_del_Paciente.Rol LIKE '%" + filter.Rol + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Configuracion_del_Paciente.Rol = '" + filter.Rol + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Configuracion_del_Paciente.Rol LIKE '%" + filter.Rol + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Token))
            {
                switch (filter.TokenFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Configuracion_del_Paciente.Token LIKE '" + filter.Token + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Configuracion_del_Paciente.Token LIKE '%" + filter.Token + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Configuracion_del_Paciente.Token = '" + filter.Token + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Configuracion_del_Paciente.Token LIKE '%" + filter.Token + "%'";
                        break;
                }
            }

            if (filter.Android != RadioOptions.NoApply)
                where += " AND Configuracion_del_Paciente.Android = " + Convert.ToInt32(filter.Android);

            if (filter.iOS != RadioOptions.NoApply)
                where += " AND Configuracion_del_Paciente.iOS = " + Convert.ToInt32(filter.iOS);

            if (filter.Permite_notificaciones_por_email != RadioOptions.NoApply)
                where += " AND Configuracion_del_Paciente.Permite_notificaciones_por_email = " + Convert.ToInt32(filter.Permite_notificaciones_por_email);

            if (filter.Permite_notificaciones_push != RadioOptions.NoApply)
                where += " AND Configuracion_del_Paciente.Permite_notificaciones_push = " + Convert.ToInt32(filter.Permite_notificaciones_push);


            where = new Regex(Regex.Escape("AND ")).Replace(where, "", 1);
            return where;
        }

        [NonAction]
        public Grid_File ConvertSpartane_FileToGridFile(Spartane.Core.Domain.Spartane_File.Spartane_File file)
        {
            return file == null ? new Grid_File { FileId = 0, FileSize = 0, FileName = "" } : new Grid_File { FileId = file.File_Id, FileName = file.Description, FileSize = file.File_Size ?? 0, };
        }

        public ActionResult GetDetalle_Notificaciones_Paciente(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_Notificaciones_PacienteGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Notificaciones_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Notificaciones_Paciente.FolioConfiguracion=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Notificaciones_Paciente.FolioConfiguracion='" + RelationId + "'";
            }
            var result = _IDetalle_Notificaciones_PacienteApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Notificaciones_Pacientes == null)
                result.Detalle_Notificaciones_Pacientes = new List<Detalle_Notificaciones_Paciente>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Notificaciones_Pacientes.Select(m => new Detalle_Notificaciones_PacienteGridModel
                {
                    Folio = m.Folio

                        ,Funcionalidad = m.Funcionalidad
                        ,FuncionalidadFuncionalidad = CultureHelper.GetTraduction(m.Funcionalidad_Funcionalidades_para_Notificacion.Folio.ToString(), "Funcionalidad") ??(string)m.Funcionalidad_Funcionalidades_para_Notificacion.Funcionalidad

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_Notificaciones_PacienteGridModel> GetDetalle_Notificaciones_PacienteData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_Notificaciones_PacienteGridModel> resultData = new List<Detalle_Notificaciones_PacienteGridModel>();
            string where = "Detalle_Notificaciones_Paciente.FolioConfiguracion=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Notificaciones_Paciente.FolioConfiguracion='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Notificaciones_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_Notificaciones_PacienteApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Notificaciones_Pacientes != null)
            {
                resultData = result.Detalle_Notificaciones_Pacientes.Select(m => new Detalle_Notificaciones_PacienteGridModel
                    {
                        Folio = m.Folio

                        ,Funcionalidad = m.Funcionalidad
                        ,FuncionalidadFuncionalidad = CultureHelper.GetTraduction(m.Funcionalidad_Funcionalidades_para_Notificacion.Folio.ToString(), "Funcionalidad") ??(string)m.Funcionalidad_Funcionalidades_para_Notificacion.Funcionalidad


                    }).ToList();
                RowCount = result.RowCount;
            }
            return resultData;
        }


        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IConfiguracion_del_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);

                Configuracion_del_Paciente varConfiguracion_del_Paciente = null;
                if (id.ToString() != "0")
                {
                        string where = "";
                    _IDetalle_Notificaciones_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Notificaciones_Paciente.FolioConfiguracion=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Notificaciones_Paciente.FolioConfiguracion='" + id + "'";
                    }
                    var Detalle_Notificaciones_PacienteInfo =
                        _IDetalle_Notificaciones_PacienteApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_Notificaciones_PacienteInfo.Detalle_Notificaciones_Pacientes.Count > 0)
                    {
                        var resultDetalle_Notificaciones_Paciente = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_Notificaciones_PacienteItem in Detalle_Notificaciones_PacienteInfo.Detalle_Notificaciones_Pacientes)
                            resultDetalle_Notificaciones_Paciente = resultDetalle_Notificaciones_Paciente
                                              && _IDetalle_Notificaciones_PacienteApiConsumer.Delete(Detalle_Notificaciones_PacienteItem.Folio, null,null).Resource;

                        if (!resultDetalle_Notificaciones_Paciente)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                var result = _IConfiguracion_del_PacienteApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Configuracion_del_PacienteModel varConfiguracion_del_Paciente)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IConfiguracion_del_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Configuracion_del_PacienteInfo = new Configuracion_del_Paciente
                    {
                        Folio = varConfiguracion_del_Paciente.Folio
                        ,Fecha_de_Registro = (!String.IsNullOrEmpty(varConfiguracion_del_Paciente.Fecha_de_Registro)) ? DateTime.ParseExact(varConfiguracion_del_Paciente.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varConfiguracion_del_Paciente.Hora_de_Registro
                        ,Usuario_Registrado = varConfiguracion_del_Paciente.Usuario_Registrado
                        ,Rol = varConfiguracion_del_Paciente.Rol
                        ,Token = varConfiguracion_del_Paciente.Token
                        ,Android = varConfiguracion_del_Paciente.Android
                        ,iOS = varConfiguracion_del_Paciente.iOS
                        ,Permite_notificaciones_por_email = varConfiguracion_del_Paciente.Permite_notificaciones_por_email
                        ,Permite_notificaciones_push = varConfiguracion_del_Paciente.Permite_notificaciones_push

                    };

                    result = !IsNew ?
                        _IConfiguracion_del_PacienteApiConsumer.Update(Configuracion_del_PacienteInfo, null, null).Resource.ToString() :
                         _IConfiguracion_del_PacienteApiConsumer.Insert(Configuracion_del_PacienteInfo, null, null).Resource.ToString();
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
        public bool CopyDetalle_Notificaciones_Paciente(int MasterId, int referenceId, List<Detalle_Notificaciones_PacienteGridModelPost> Detalle_Notificaciones_PacienteItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_Notificaciones_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_Notificaciones_PacienteData = _IDetalle_Notificaciones_PacienteApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Notificaciones_Paciente.FolioConfiguracion=" + referenceId,"").Resource;
                if (Detalle_Notificaciones_PacienteData == null || Detalle_Notificaciones_PacienteData.Detalle_Notificaciones_Pacientes.Count == 0)
                    return true;

                var result = true;

                Detalle_Notificaciones_PacienteGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Notificaciones_Paciente in Detalle_Notificaciones_PacienteData.Detalle_Notificaciones_Pacientes)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Notificaciones_Paciente Detalle_Notificaciones_Paciente1 = varDetalle_Notificaciones_Paciente;

                    if (Detalle_Notificaciones_PacienteItems != null && Detalle_Notificaciones_PacienteItems.Any(m => m.Folio == Detalle_Notificaciones_Paciente1.Folio))
                    {
                        modelDataToChange = Detalle_Notificaciones_PacienteItems.FirstOrDefault(m => m.Folio == Detalle_Notificaciones_Paciente1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Notificaciones_Paciente.FolioConfiguracion = MasterId;
                    var insertId = _IDetalle_Notificaciones_PacienteApiConsumer.Insert(varDetalle_Notificaciones_Paciente,null,null).Resource;
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
        public ActionResult PostDetalle_Notificaciones_Paciente(List<Detalle_Notificaciones_PacienteGridModelPost> Detalle_Notificaciones_PacienteItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Notificaciones_Paciente(MasterId, referenceId, Detalle_Notificaciones_PacienteItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_Notificaciones_PacienteItems != null && Detalle_Notificaciones_PacienteItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_Notificaciones_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_Notificaciones_PacienteItem in Detalle_Notificaciones_PacienteItems)
                    {



                        //Removal Request
                        if (Detalle_Notificaciones_PacienteItem.Removed)
                        {
                            result = result && _IDetalle_Notificaciones_PacienteApiConsumer.Delete(Detalle_Notificaciones_PacienteItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_Notificaciones_PacienteItem.Folio = 0;

                        var Detalle_Notificaciones_PacienteData = new Detalle_Notificaciones_Paciente
                        {
                            FolioConfiguracion = MasterId
                            ,Folio = Detalle_Notificaciones_PacienteItem.Folio
                            ,Funcionalidad = (Convert.ToInt32(Detalle_Notificaciones_PacienteItem.Funcionalidad) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Notificaciones_PacienteItem.Funcionalidad))

                        };

                        var resultId = Detalle_Notificaciones_PacienteItem.Folio > 0
                           ? _IDetalle_Notificaciones_PacienteApiConsumer.Update(Detalle_Notificaciones_PacienteData,null,null).Resource
                           : _IDetalle_Notificaciones_PacienteApiConsumer.Insert(Detalle_Notificaciones_PacienteData,null,null).Resource;

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
        public ActionResult GetDetalle_Notificaciones_Paciente_Funcionalidades_para_NotificacionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IFuncionalidades_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IFuncionalidades_para_NotificacionApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Folio), "Funcionalidades_para_Notificacion", "Funcionalidad");
                  item.Funcionalidad= trans??item.Funcionalidad;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }



        /// <summary>
        /// Write Element Array of Configuracion_del_Paciente script
        /// </summary>
        /// <param name="oConfiguracion_del_PacienteElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew Configuracion_del_PacienteModuleAttributeList)
        {
            for (int i = 0; i < Configuracion_del_PacienteModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Configuracion_del_PacienteModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Configuracion_del_PacienteModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Configuracion_del_PacienteModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Configuracion_del_PacienteModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Configuracion_del_PacienteModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Configuracion_del_PacienteModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < Configuracion_del_PacienteModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(Configuracion_del_PacienteModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							Configuracion_del_PacienteModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(Configuracion_del_PacienteModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							Configuracion_del_PacienteModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strConfiguracion_del_PacienteScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Configuracion_del_Paciente.js")))
            {
                strConfiguracion_del_PacienteScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Configuracion_del_Paciente element attributes
            string userChangeJson = jsSerialize.Serialize(Configuracion_del_PacienteModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strConfiguracion_del_PacienteScript.IndexOf("inpuElementArray");
            string splittedString = strConfiguracion_del_PacienteScript.Substring(indexOfArray, strConfiguracion_del_PacienteScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Configuracion_del_PacienteModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Configuracion_del_PacienteModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strConfiguracion_del_PacienteScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strConfiguracion_del_PacienteScript.Substring(indexOfArrayHistory, strConfiguracion_del_PacienteScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strConfiguracion_del_PacienteScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strConfiguracion_del_PacienteScript.Substring(endIndexOfMainElement + indexOfArray, strConfiguracion_del_PacienteScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (Configuracion_del_PacienteModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in Configuracion_del_PacienteModuleAttributeList.ChildModuleAttributeList)
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
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Configuracion_del_Paciente.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Configuracion_del_Paciente.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Configuracion_del_Paciente.js")))
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
        public ActionResult Configuracion_del_PacientePropertyBag()
        {
            return PartialView("Configuracion_del_PacientePropertyBag", "Configuracion_del_Paciente");
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
        public ActionResult AddDetalle_Notificaciones_Paciente(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Notificaciones_Paciente/AddDetalle_Notificaciones_Paciente");
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
                var whereClauseFormat = "Object = 44693 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _IConfiguracion_del_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Configuracion_del_Paciente.Folio= " + RecordId;
                            var result = _IConfiguracion_del_PacienteApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
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

            _IConfiguracion_del_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Configuracion_del_PacientePropertyMapper());
			
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
                    (Configuracion_del_PacienteAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
			string sortDirection = "asc";

            Configuracion_del_PacientePropertyMapper oConfiguracion_del_PacientePropertyMapper = new Configuracion_del_PacientePropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oConfiguracion_del_PacientePropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IConfiguracion_del_PacienteApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Configuracion_del_Pacientes == null)
                result.Configuracion_del_Pacientes = new List<Configuracion_del_Paciente>();

            var data = result.Configuracion_del_Pacientes.Select(m => new Configuracion_del_PacienteGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_RegistradoName = CultureHelper.GetTraduction(m.Usuario_Registrado_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_Registrado_Spartan_User.Name
			,Rol = m.Rol
			,Token = m.Token
			,Android = m.Android
			,iOS = m.iOS
			,Permite_notificaciones_por_email = m.Permite_notificaciones_por_email
			,Permite_notificaciones_push = m.Permite_notificaciones_push

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(44693, arrayColumnsVisible), "Configuracion_del_PacienteList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(44693, arrayColumnsVisible), "Configuracion_del_PacienteList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(44693, arrayColumnsVisible), "Configuracion_del_PacienteList_" + DateTime.Now.ToString());
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

            _IConfiguracion_del_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Configuracion_del_PacientePropertyMapper());
				
				
            if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
			if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (Configuracion_del_PacienteAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            Configuracion_del_PacientePropertyMapper oConfiguracion_del_PacientePropertyMapper = new Configuracion_del_PacientePropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oConfiguracion_del_PacientePropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
			
			if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IConfiguracion_del_PacienteApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Configuracion_del_Pacientes == null)
                result.Configuracion_del_Pacientes = new List<Configuracion_del_Paciente>();

            var data = result.Configuracion_del_Pacientes.Select(m => new Configuracion_del_PacienteGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_RegistradoName = CultureHelper.GetTraduction(m.Usuario_Registrado_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_Registrado_Spartan_User.Name
			,Rol = m.Rol
			,Token = m.Token
			,Android = m.Android
			,iOS = m.iOS
			,Permite_notificaciones_por_email = m.Permite_notificaciones_por_email
			,Permite_notificaciones_push = m.Permite_notificaciones_push

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
                _IConfiguracion_del_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IConfiguracion_del_PacienteApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpPost]
        public ActionResult Post_Datos_Generales(Configuracion_del_Paciente_Datos_GeneralesModel varConfiguracion_del_Paciente)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IConfiguracion_del_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Configuracion_del_Paciente_Datos_GeneralesInfo = new Configuracion_del_Paciente_Datos_Generales
                {
                    Folio = varConfiguracion_del_Paciente.Folio
                                            ,Fecha_de_Registro = (!String.IsNullOrEmpty(varConfiguracion_del_Paciente.Fecha_de_Registro)) ? DateTime.ParseExact(varConfiguracion_del_Paciente.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varConfiguracion_del_Paciente.Hora_de_Registro
                        ,Usuario_Registrado = varConfiguracion_del_Paciente.Usuario_Registrado
                        ,Rol = varConfiguracion_del_Paciente.Rol
                        ,Token = varConfiguracion_del_Paciente.Token
                        ,Android = varConfiguracion_del_Paciente.Android
                        ,iOS = varConfiguracion_del_Paciente.iOS
                        ,Permite_notificaciones_por_email = varConfiguracion_del_Paciente.Permite_notificaciones_por_email
                        ,Permite_notificaciones_push = varConfiguracion_del_Paciente.Permite_notificaciones_push
                    
                };

                result = _IConfiguracion_del_PacienteApiConsumer.Update_Datos_Generales(Configuracion_del_Paciente_Datos_GeneralesInfo).Resource.ToString();
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
                _IConfiguracion_del_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IConfiguracion_del_PacienteApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Notificaciones_Paciente;
                var Detalle_Notificaciones_PacienteData = GetDetalle_Notificaciones_PacienteData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Notificaciones_Paciente);

                var result = new Configuracion_del_Paciente_Datos_GeneralesModel
                {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_Registrado = m.Usuario_Registrado
                        ,Usuario_RegistradoName = CultureHelper.GetTraduction(m.Usuario_Registrado_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_Registrado_Spartan_User.Name
			,Rol = m.Rol
			,Token = m.Token
			,Android = m.Android
			,iOS = m.iOS
			,Permite_notificaciones_por_email = m.Permite_notificaciones_por_email
			,Permite_notificaciones_push = m.Permite_notificaciones_push

                    
                };
				var resultData = new
                {
                    data = result
                    ,MR_Notificaciones = Detalle_Notificaciones_PacienteData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }


    }
}

