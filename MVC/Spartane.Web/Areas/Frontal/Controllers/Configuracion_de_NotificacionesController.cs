using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Configuracion_de_Notificaciones;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Roles_para_Notificar;

using Spartane.Core.Domain.Tipo_Paciente;

using Spartane.Core.Domain.Funcionalidades_para_Notificacion;
using Spartane.Core.Domain.Tipo_de_Notificacion;
using Spartane.Core.Domain.Tipo_de_Accion_Notificacion;
using Spartane.Core.Domain.Tipo_de_Recordatorio_Notificacion;
using Spartane.Core.Domain.Nombre_del_campo_en_MS;
using Spartane.Core.Domain.Estatus;
using Spartane.Core.Domain.Detalle_Frecuencia_Notificaciones;

using Spartane.Core.Domain.Tipo_Frecuencia_Notificacion;
using Spartane.Core.Domain.Tipo_Dia_Notificacion;



using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Configuracion_de_Notificaciones;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Configuracion_de_Notificaciones;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Roles_para_Notificar;

using Spartane.Web.Areas.WebApiConsumer.Tipo_Paciente;

using Spartane.Web.Areas.WebApiConsumer.Funcionalidades_para_Notificacion;
using Spartane.Web.Areas.WebApiConsumer.Tipo_de_Notificacion;
using Spartane.Web.Areas.WebApiConsumer.Tipo_de_Accion_Notificacion;
using Spartane.Web.Areas.WebApiConsumer.Tipo_de_Recordatorio_Notificacion;
using Spartane.Web.Areas.WebApiConsumer.Nombre_del_campo_en_MS;
using Spartane.Web.Areas.WebApiConsumer.Estatus;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Frecuencia_Notificaciones;

using Spartane.Web.Areas.WebApiConsumer.Tipo_Frecuencia_Notificacion;
using Spartane.Web.Areas.WebApiConsumer.Tipo_Dia_Notificacion;



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
    public class Configuracion_de_NotificacionesController : Controller
    {
        #region "variable declaration"

        private IConfiguracion_de_NotificacionesService service = null;
        private IConfiguracion_de_NotificacionesApiConsumer _IConfiguracion_de_NotificacionesApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private IRoles_para_NotificarApiConsumer _IRoles_para_NotificarApiConsumer;

        private ITipo_PacienteApiConsumer _ITipo_PacienteApiConsumer;

        private IFuncionalidades_para_NotificacionApiConsumer _IFuncionalidades_para_NotificacionApiConsumer;
        private ITipo_de_NotificacionApiConsumer _ITipo_de_NotificacionApiConsumer;
        private ITipo_de_Accion_NotificacionApiConsumer _ITipo_de_Accion_NotificacionApiConsumer;
        private ITipo_de_Recordatorio_NotificacionApiConsumer _ITipo_de_Recordatorio_NotificacionApiConsumer;
        private INombre_del_campo_en_MSApiConsumer _INombre_del_campo_en_MSApiConsumer;
        private IEstatusApiConsumer _IEstatusApiConsumer;
        private IDetalle_Frecuencia_NotificacionesApiConsumer _IDetalle_Frecuencia_NotificacionesApiConsumer;

        private ITipo_Frecuencia_NotificacionApiConsumer _ITipo_Frecuencia_NotificacionApiConsumer;
        private ITipo_Dia_NotificacionApiConsumer _ITipo_Dia_NotificacionApiConsumer;



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

        
        public Configuracion_de_NotificacionesController(IConfiguracion_de_NotificacionesService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IConfiguracion_de_NotificacionesApiConsumer Configuracion_de_NotificacionesApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer , IRoles_para_NotificarApiConsumer Roles_para_NotificarApiConsumer , ITipo_PacienteApiConsumer Tipo_PacienteApiConsumer  , IFuncionalidades_para_NotificacionApiConsumer Funcionalidades_para_NotificacionApiConsumer , ITipo_de_NotificacionApiConsumer Tipo_de_NotificacionApiConsumer , ITipo_de_Accion_NotificacionApiConsumer Tipo_de_Accion_NotificacionApiConsumer , ITipo_de_Recordatorio_NotificacionApiConsumer Tipo_de_Recordatorio_NotificacionApiConsumer , INombre_del_campo_en_MSApiConsumer Nombre_del_campo_en_MSApiConsumer , IEstatusApiConsumer EstatusApiConsumer , IDetalle_Frecuencia_NotificacionesApiConsumer Detalle_Frecuencia_NotificacionesApiConsumer , ITipo_Frecuencia_NotificacionApiConsumer Tipo_Frecuencia_NotificacionApiConsumer , ITipo_Dia_NotificacionApiConsumer Tipo_Dia_NotificacionApiConsumer  )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IConfiguracion_de_NotificacionesApiConsumer = Configuracion_de_NotificacionesApiConsumer;
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
            this._IRoles_para_NotificarApiConsumer = Roles_para_NotificarApiConsumer;

            this._ITipo_PacienteApiConsumer = Tipo_PacienteApiConsumer;

            this._IFuncionalidades_para_NotificacionApiConsumer = Funcionalidades_para_NotificacionApiConsumer;
            this._ITipo_de_NotificacionApiConsumer = Tipo_de_NotificacionApiConsumer;
            this._ITipo_de_Accion_NotificacionApiConsumer = Tipo_de_Accion_NotificacionApiConsumer;
            this._ITipo_de_Recordatorio_NotificacionApiConsumer = Tipo_de_Recordatorio_NotificacionApiConsumer;
            this._INombre_del_campo_en_MSApiConsumer = Nombre_del_campo_en_MSApiConsumer;
            this._IEstatusApiConsumer = EstatusApiConsumer;
            this._IDetalle_Frecuencia_NotificacionesApiConsumer = Detalle_Frecuencia_NotificacionesApiConsumer;

            this._ITipo_Frecuencia_NotificacionApiConsumer = Tipo_Frecuencia_NotificacionApiConsumer;
            this._ITipo_Dia_NotificacionApiConsumer = Tipo_Dia_NotificacionApiConsumer;



        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Configuracion_de_Notificaciones
        [ObjectAuth(ObjectId = (ModuleObjectId)44689, PermissionType = PermissionTypes.Consult)]
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
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44689, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			          
            return View();
        }

        // GET: Frontal/Configuracion_de_Notificaciones/Create
          [ObjectAuth(ObjectId = (ModuleObjectId)44689, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44689, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varConfiguracion_de_Notificaciones = new Configuracion_de_NotificacionesModel();
			varConfiguracion_de_Notificaciones.Folio = Id;
			
            ViewBag.ObjectId = "44689";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;

            var permissionRoles_para_Notificar = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44718, ModuleId);
            ViewBag.PermissionRoles_para_Notificar = permissionRoles_para_Notificar;
            var permissionDetalle_Frecuencia_Notificaciones = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44696, ModuleId);
            ViewBag.PermissionDetalle_Frecuencia_Notificaciones = permissionDetalle_Frecuencia_Notificaciones;


            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
				
				_tokenManager.GenerateToken();
				_ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _IConfiguracion_de_NotificacionesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Configuracion_de_NotificacionessData = _IConfiguracion_de_NotificacionesApiConsumer.ListaSelAll(0, 1000, "Configuracion_de_Notificaciones.Folio=" + Id, "").Resource.Configuracion_de_Notificacioness;
				
				if (Configuracion_de_NotificacionessData != null && Configuracion_de_NotificacionessData.Count > 0)
                {
					var Configuracion_de_NotificacionesData = Configuracion_de_NotificacionessData.First();
					varConfiguracion_de_Notificaciones= new Configuracion_de_NotificacionesModel
					{
						Folio  = Configuracion_de_NotificacionesData.Folio 
	                    ,Fecha_de_Registro = (Configuracion_de_NotificacionesData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(Configuracion_de_NotificacionesData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = Configuracion_de_NotificacionesData.Hora_de_Registro
                    ,Usuario_que_Registra = Configuracion_de_NotificacionesData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(Configuracion_de_NotificacionesData.Usuario_que_Registra), "Spartan_User") ??  (string)Configuracion_de_NotificacionesData.Usuario_que_Registra_Spartan_User.Name
                    ,Nombre_de_la_Notificacion = Configuracion_de_NotificacionesData.Nombre_de_la_Notificacion
                    ,Es_permanente = Configuracion_de_NotificacionesData.Es_permanente.GetValueOrDefault()
                    ,Funcionalidad = Configuracion_de_NotificacionesData.Funcionalidad
                    ,FuncionalidadFuncionalidad = CultureHelper.GetTraduction(Convert.ToString(Configuracion_de_NotificacionesData.Funcionalidad), "Funcionalidades_para_Notificacion") ??  (string)Configuracion_de_NotificacionesData.Funcionalidad_Funcionalidades_para_Notificacion.Funcionalidad
                    ,Tipo_de_Notificacion = Configuracion_de_NotificacionesData.Tipo_de_Notificacion
                    ,Tipo_de_NotificacionDescripcion = CultureHelper.GetTraduction(Convert.ToString(Configuracion_de_NotificacionesData.Tipo_de_Notificacion), "Tipo_de_Notificacion") ??  (string)Configuracion_de_NotificacionesData.Tipo_de_Notificacion_Tipo_de_Notificacion.Descripcion
                    ,Tipo_de_Accion = Configuracion_de_NotificacionesData.Tipo_de_Accion
                    ,Tipo_de_AccionDescripcion = CultureHelper.GetTraduction(Convert.ToString(Configuracion_de_NotificacionesData.Tipo_de_Accion), "Tipo_de_Accion_Notificacion") ??  (string)Configuracion_de_NotificacionesData.Tipo_de_Accion_Tipo_de_Accion_Notificacion.Descripcion
                    ,Tipo_de_Recordatorio = Configuracion_de_NotificacionesData.Tipo_de_Recordatorio
                    ,Tipo_de_RecordatorioDescripcion = CultureHelper.GetTraduction(Convert.ToString(Configuracion_de_NotificacionesData.Tipo_de_Recordatorio), "Tipo_de_Recordatorio_Notificacion") ??  (string)Configuracion_de_NotificacionesData.Tipo_de_Recordatorio_Tipo_de_Recordatorio_Notificacion.Descripcion
                    ,Fecha_inicio = (Configuracion_de_NotificacionesData.Fecha_inicio == null ? string.Empty : Convert.ToDateTime(Configuracion_de_NotificacionesData.Fecha_inicio).ToString(ConfigurationProperty.DateFormat))
                    ,Tiene_fecha_de_finalizacion_definida = Configuracion_de_NotificacionesData.Tiene_fecha_de_finalizacion_definida.GetValueOrDefault()
                    ,Cantidad_de_dias_a_validar = Configuracion_de_NotificacionesData.Cantidad_de_dias_a_validar
                    ,Fecha_a_validar = Configuracion_de_NotificacionesData.Fecha_a_validar
                    ,Fecha_a_validarDescripcion = CultureHelper.GetTraduction(Convert.ToString(Configuracion_de_NotificacionesData.Fecha_a_validar), "Nombre_del_campo_en_MS") ??  (string)Configuracion_de_NotificacionesData.Fecha_a_validar_Nombre_del_campo_en_MS.Descripcion
                    ,Fecha_fin = (Configuracion_de_NotificacionesData.Fecha_fin == null ? string.Empty : Convert.ToDateTime(Configuracion_de_NotificacionesData.Fecha_fin).ToString(ConfigurationProperty.DateFormat))
                    ,Estatus = Configuracion_de_NotificacionesData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Configuracion_de_NotificacionesData.Estatus), "Estatus") ??  (string)Configuracion_de_NotificacionesData.Estatus_Estatus.Descripcion
                    ,Notificar_por_correo = Configuracion_de_NotificacionesData.Notificar_por_correo.GetValueOrDefault()
                    ,Texto_que_llevara_el_correo = Configuracion_de_NotificacionesData.Texto_que_llevara_el_correo
                    ,Notificacion_push = Configuracion_de_NotificacionesData.Notificacion_push.GetValueOrDefault()
                    ,Texto_a_mostrar_en_la_notificacion_Push = Configuracion_de_NotificacionesData.Texto_a_mostrar_en_la_notificacion_Push

					};
				}
				
				
				
            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_que_Registra = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_que_Registra != null && Spartan_Users_Usuario_que_Registra.Resource != null)
                ViewBag.Spartan_Users_Usuario_que_Registra = Spartan_Users_Usuario_que_Registra.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IFuncionalidades_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Funcionalidades_para_Notificacions_Funcionalidad = _IFuncionalidades_para_NotificacionApiConsumer.SelAll(true);
            if (Funcionalidades_para_Notificacions_Funcionalidad != null && Funcionalidades_para_Notificacions_Funcionalidad.Resource != null)
                ViewBag.Funcionalidades_para_Notificacions_Funcionalidad = Funcionalidades_para_Notificacions_Funcionalidad.Resource.Where(m => m.Funcionalidad != null).OrderBy(m => m.Funcionalidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Funcionalidades_para_Notificacion", "Funcionalidad") ?? m.Funcionalidad.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ITipo_de_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Notificacions_Tipo_de_Notificacion = _ITipo_de_NotificacionApiConsumer.SelAll(true);
            if (Tipo_de_Notificacions_Tipo_de_Notificacion != null && Tipo_de_Notificacions_Tipo_de_Notificacion.Resource != null)
                ViewBag.Tipo_de_Notificacions_Tipo_de_Notificacion = Tipo_de_Notificacions_Tipo_de_Notificacion.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Notificacion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipo_de_Accion_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Accion_Notificacions_Tipo_de_Accion = _ITipo_de_Accion_NotificacionApiConsumer.SelAll(true);
            if (Tipo_de_Accion_Notificacions_Tipo_de_Accion != null && Tipo_de_Accion_Notificacions_Tipo_de_Accion.Resource != null)
                ViewBag.Tipo_de_Accion_Notificacions_Tipo_de_Accion = Tipo_de_Accion_Notificacions_Tipo_de_Accion.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Accion_Notificacion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipo_de_Recordatorio_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Recordatorio_Notificacions_Tipo_de_Recordatorio = _ITipo_de_Recordatorio_NotificacionApiConsumer.SelAll(true);
            if (Tipo_de_Recordatorio_Notificacions_Tipo_de_Recordatorio != null && Tipo_de_Recordatorio_Notificacions_Tipo_de_Recordatorio.Resource != null)
                ViewBag.Tipo_de_Recordatorio_Notificacions_Tipo_de_Recordatorio = Tipo_de_Recordatorio_Notificacions_Tipo_de_Recordatorio.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Recordatorio_Notificacion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _INombre_del_campo_en_MSApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Nombre_del_campo_en_MSs_Fecha_a_validar = _INombre_del_campo_en_MSApiConsumer.SelAll(true);
            if (Nombre_del_campo_en_MSs_Fecha_a_validar != null && Nombre_del_campo_en_MSs_Fecha_a_validar.Resource != null)
                ViewBag.Nombre_del_campo_en_MSs_Fecha_a_validar = Nombre_del_campo_en_MSs_Fecha_a_validar.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Nombre_del_campo_en_MS", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
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

				
            return View(varConfiguracion_de_Notificaciones);
        }
		
	[HttpGet]
        public ActionResult AddConfiguracion_de_Notificaciones(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44689);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IConfiguracion_de_NotificacionesApiConsumer.SetAuthHeader(_tokenManager.Token);
			Configuracion_de_NotificacionesModel varConfiguracion_de_Notificaciones= new Configuracion_de_NotificacionesModel();
            var permissionRoles_para_Notificar = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44718, ModuleId);
            ViewBag.PermissionRoles_para_Notificar = permissionRoles_para_Notificar;
            var permissionDetalle_Frecuencia_Notificaciones = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44696, ModuleId);
            ViewBag.PermissionDetalle_Frecuencia_Notificaciones = permissionDetalle_Frecuencia_Notificaciones;


            if (id.ToString() != "0")
            {
                var Configuracion_de_NotificacionessData = _IConfiguracion_de_NotificacionesApiConsumer.ListaSelAll(0, 1000, "Configuracion_de_Notificaciones.Folio=" + id, "").Resource.Configuracion_de_Notificacioness;
				
				if (Configuracion_de_NotificacionessData != null && Configuracion_de_NotificacionessData.Count > 0)
                {
					var Configuracion_de_NotificacionesData = Configuracion_de_NotificacionessData.First();
					varConfiguracion_de_Notificaciones= new Configuracion_de_NotificacionesModel
					{
						Folio  = Configuracion_de_NotificacionesData.Folio 
	                    ,Fecha_de_Registro = (Configuracion_de_NotificacionesData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(Configuracion_de_NotificacionesData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = Configuracion_de_NotificacionesData.Hora_de_Registro
                    ,Usuario_que_Registra = Configuracion_de_NotificacionesData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(Configuracion_de_NotificacionesData.Usuario_que_Registra), "Spartan_User") ??  (string)Configuracion_de_NotificacionesData.Usuario_que_Registra_Spartan_User.Name
                    ,Nombre_de_la_Notificacion = Configuracion_de_NotificacionesData.Nombre_de_la_Notificacion
                    ,Es_permanente = Configuracion_de_NotificacionesData.Es_permanente.GetValueOrDefault()
                    ,Funcionalidad = Configuracion_de_NotificacionesData.Funcionalidad
                    ,FuncionalidadFuncionalidad = CultureHelper.GetTraduction(Convert.ToString(Configuracion_de_NotificacionesData.Funcionalidad), "Funcionalidades_para_Notificacion") ??  (string)Configuracion_de_NotificacionesData.Funcionalidad_Funcionalidades_para_Notificacion.Funcionalidad
                    ,Tipo_de_Notificacion = Configuracion_de_NotificacionesData.Tipo_de_Notificacion
                    ,Tipo_de_NotificacionDescripcion = CultureHelper.GetTraduction(Convert.ToString(Configuracion_de_NotificacionesData.Tipo_de_Notificacion), "Tipo_de_Notificacion") ??  (string)Configuracion_de_NotificacionesData.Tipo_de_Notificacion_Tipo_de_Notificacion.Descripcion
                    ,Tipo_de_Accion = Configuracion_de_NotificacionesData.Tipo_de_Accion
                    ,Tipo_de_AccionDescripcion = CultureHelper.GetTraduction(Convert.ToString(Configuracion_de_NotificacionesData.Tipo_de_Accion), "Tipo_de_Accion_Notificacion") ??  (string)Configuracion_de_NotificacionesData.Tipo_de_Accion_Tipo_de_Accion_Notificacion.Descripcion
                    ,Tipo_de_Recordatorio = Configuracion_de_NotificacionesData.Tipo_de_Recordatorio
                    ,Tipo_de_RecordatorioDescripcion = CultureHelper.GetTraduction(Convert.ToString(Configuracion_de_NotificacionesData.Tipo_de_Recordatorio), "Tipo_de_Recordatorio_Notificacion") ??  (string)Configuracion_de_NotificacionesData.Tipo_de_Recordatorio_Tipo_de_Recordatorio_Notificacion.Descripcion
                    ,Fecha_inicio = (Configuracion_de_NotificacionesData.Fecha_inicio == null ? string.Empty : Convert.ToDateTime(Configuracion_de_NotificacionesData.Fecha_inicio).ToString(ConfigurationProperty.DateFormat))
                    ,Tiene_fecha_de_finalizacion_definida = Configuracion_de_NotificacionesData.Tiene_fecha_de_finalizacion_definida.GetValueOrDefault()
                    ,Cantidad_de_dias_a_validar = Configuracion_de_NotificacionesData.Cantidad_de_dias_a_validar
                    ,Fecha_a_validar = Configuracion_de_NotificacionesData.Fecha_a_validar
                    ,Fecha_a_validarDescripcion = CultureHelper.GetTraduction(Convert.ToString(Configuracion_de_NotificacionesData.Fecha_a_validar), "Nombre_del_campo_en_MS") ??  (string)Configuracion_de_NotificacionesData.Fecha_a_validar_Nombre_del_campo_en_MS.Descripcion
                    ,Fecha_fin = (Configuracion_de_NotificacionesData.Fecha_fin == null ? string.Empty : Convert.ToDateTime(Configuracion_de_NotificacionesData.Fecha_fin).ToString(ConfigurationProperty.DateFormat))
                    ,Estatus = Configuracion_de_NotificacionesData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Configuracion_de_NotificacionesData.Estatus), "Estatus") ??  (string)Configuracion_de_NotificacionesData.Estatus_Estatus.Descripcion
                    ,Notificar_por_correo = Configuracion_de_NotificacionesData.Notificar_por_correo.GetValueOrDefault()
                    ,Texto_que_llevara_el_correo = Configuracion_de_NotificacionesData.Texto_que_llevara_el_correo
                    ,Notificacion_push = Configuracion_de_NotificacionesData.Notificacion_push.GetValueOrDefault()
                    ,Texto_a_mostrar_en_la_notificacion_Push = Configuracion_de_NotificacionesData.Texto_a_mostrar_en_la_notificacion_Push

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_que_Registra = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_que_Registra != null && Spartan_Users_Usuario_que_Registra.Resource != null)
                ViewBag.Spartan_Users_Usuario_que_Registra = Spartan_Users_Usuario_que_Registra.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IFuncionalidades_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Funcionalidades_para_Notificacions_Funcionalidad = _IFuncionalidades_para_NotificacionApiConsumer.SelAll(true);
            if (Funcionalidades_para_Notificacions_Funcionalidad != null && Funcionalidades_para_Notificacions_Funcionalidad.Resource != null)
                ViewBag.Funcionalidades_para_Notificacions_Funcionalidad = Funcionalidades_para_Notificacions_Funcionalidad.Resource.Where(m => m.Funcionalidad != null).OrderBy(m => m.Funcionalidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Funcionalidades_para_Notificacion", "Funcionalidad") ?? m.Funcionalidad.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ITipo_de_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Notificacions_Tipo_de_Notificacion = _ITipo_de_NotificacionApiConsumer.SelAll(true);
            if (Tipo_de_Notificacions_Tipo_de_Notificacion != null && Tipo_de_Notificacions_Tipo_de_Notificacion.Resource != null)
                ViewBag.Tipo_de_Notificacions_Tipo_de_Notificacion = Tipo_de_Notificacions_Tipo_de_Notificacion.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Notificacion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipo_de_Accion_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Accion_Notificacions_Tipo_de_Accion = _ITipo_de_Accion_NotificacionApiConsumer.SelAll(true);
            if (Tipo_de_Accion_Notificacions_Tipo_de_Accion != null && Tipo_de_Accion_Notificacions_Tipo_de_Accion.Resource != null)
                ViewBag.Tipo_de_Accion_Notificacions_Tipo_de_Accion = Tipo_de_Accion_Notificacions_Tipo_de_Accion.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Accion_Notificacion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipo_de_Recordatorio_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Recordatorio_Notificacions_Tipo_de_Recordatorio = _ITipo_de_Recordatorio_NotificacionApiConsumer.SelAll(true);
            if (Tipo_de_Recordatorio_Notificacions_Tipo_de_Recordatorio != null && Tipo_de_Recordatorio_Notificacions_Tipo_de_Recordatorio.Resource != null)
                ViewBag.Tipo_de_Recordatorio_Notificacions_Tipo_de_Recordatorio = Tipo_de_Recordatorio_Notificacions_Tipo_de_Recordatorio.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Recordatorio_Notificacion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _INombre_del_campo_en_MSApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Nombre_del_campo_en_MSs_Fecha_a_validar = _INombre_del_campo_en_MSApiConsumer.SelAll(true);
            if (Nombre_del_campo_en_MSs_Fecha_a_validar != null && Nombre_del_campo_en_MSs_Fecha_a_validar.Resource != null)
                ViewBag.Nombre_del_campo_en_MSs_Fecha_a_validar = Nombre_del_campo_en_MSs_Fecha_a_validar.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Nombre_del_campo_en_MS", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddConfiguracion_de_Notificaciones", varConfiguracion_de_Notificaciones);
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
        [HttpGet]
        public ActionResult GetFuncionalidades_para_NotificacionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IFuncionalidades_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IFuncionalidades_para_NotificacionApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Funcionalidad).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Funcionalidades_para_Notificacion", "Funcionalidad")?? m.Funcionalidad,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetTipo_de_NotificacionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipo_de_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipo_de_NotificacionApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Notificacion", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetTipo_de_Accion_NotificacionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipo_de_Accion_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipo_de_Accion_NotificacionApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Accion_Notificacion", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetTipo_de_Recordatorio_NotificacionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipo_de_Recordatorio_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipo_de_Recordatorio_NotificacionApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Recordatorio_Notificacion", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
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
        [HttpGet]
        public ActionResult GetEstatusAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstatusApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
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
        public ActionResult ShowAdvanceFilter(Configuracion_de_NotificacionesAdvanceSearchModel model, int idFilter = -1)
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
            var Spartan_Users_Usuario_que_Registra = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_que_Registra != null && Spartan_Users_Usuario_que_Registra.Resource != null)
                ViewBag.Spartan_Users_Usuario_que_Registra = Spartan_Users_Usuario_que_Registra.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IFuncionalidades_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Funcionalidades_para_Notificacions_Funcionalidad = _IFuncionalidades_para_NotificacionApiConsumer.SelAll(true);
            if (Funcionalidades_para_Notificacions_Funcionalidad != null && Funcionalidades_para_Notificacions_Funcionalidad.Resource != null)
                ViewBag.Funcionalidades_para_Notificacions_Funcionalidad = Funcionalidades_para_Notificacions_Funcionalidad.Resource.Where(m => m.Funcionalidad != null).OrderBy(m => m.Funcionalidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Funcionalidades_para_Notificacion", "Funcionalidad") ?? m.Funcionalidad.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ITipo_de_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Notificacions_Tipo_de_Notificacion = _ITipo_de_NotificacionApiConsumer.SelAll(true);
            if (Tipo_de_Notificacions_Tipo_de_Notificacion != null && Tipo_de_Notificacions_Tipo_de_Notificacion.Resource != null)
                ViewBag.Tipo_de_Notificacions_Tipo_de_Notificacion = Tipo_de_Notificacions_Tipo_de_Notificacion.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Notificacion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipo_de_Accion_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Accion_Notificacions_Tipo_de_Accion = _ITipo_de_Accion_NotificacionApiConsumer.SelAll(true);
            if (Tipo_de_Accion_Notificacions_Tipo_de_Accion != null && Tipo_de_Accion_Notificacions_Tipo_de_Accion.Resource != null)
                ViewBag.Tipo_de_Accion_Notificacions_Tipo_de_Accion = Tipo_de_Accion_Notificacions_Tipo_de_Accion.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Accion_Notificacion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipo_de_Recordatorio_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Recordatorio_Notificacions_Tipo_de_Recordatorio = _ITipo_de_Recordatorio_NotificacionApiConsumer.SelAll(true);
            if (Tipo_de_Recordatorio_Notificacions_Tipo_de_Recordatorio != null && Tipo_de_Recordatorio_Notificacions_Tipo_de_Recordatorio.Resource != null)
                ViewBag.Tipo_de_Recordatorio_Notificacions_Tipo_de_Recordatorio = Tipo_de_Recordatorio_Notificacions_Tipo_de_Recordatorio.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Recordatorio_Notificacion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _INombre_del_campo_en_MSApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Nombre_del_campo_en_MSs_Fecha_a_validar = _INombre_del_campo_en_MSApiConsumer.SelAll(true);
            if (Nombre_del_campo_en_MSs_Fecha_a_validar != null && Nombre_del_campo_en_MSs_Fecha_a_validar.Resource != null)
                ViewBag.Nombre_del_campo_en_MSs_Fecha_a_validar = Nombre_del_campo_en_MSs_Fecha_a_validar.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Nombre_del_campo_en_MS", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return View(model);  
        }

        [HttpGet]
        public ActionResult ShowAdvanceFilter(string previousFilters = "")
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_que_Registra = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_que_Registra != null && Spartan_Users_Usuario_que_Registra.Resource != null)
                ViewBag.Spartan_Users_Usuario_que_Registra = Spartan_Users_Usuario_que_Registra.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IFuncionalidades_para_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Funcionalidades_para_Notificacions_Funcionalidad = _IFuncionalidades_para_NotificacionApiConsumer.SelAll(true);
            if (Funcionalidades_para_Notificacions_Funcionalidad != null && Funcionalidades_para_Notificacions_Funcionalidad.Resource != null)
                ViewBag.Funcionalidades_para_Notificacions_Funcionalidad = Funcionalidades_para_Notificacions_Funcionalidad.Resource.Where(m => m.Funcionalidad != null).OrderBy(m => m.Funcionalidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Funcionalidades_para_Notificacion", "Funcionalidad") ?? m.Funcionalidad.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ITipo_de_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Notificacions_Tipo_de_Notificacion = _ITipo_de_NotificacionApiConsumer.SelAll(true);
            if (Tipo_de_Notificacions_Tipo_de_Notificacion != null && Tipo_de_Notificacions_Tipo_de_Notificacion.Resource != null)
                ViewBag.Tipo_de_Notificacions_Tipo_de_Notificacion = Tipo_de_Notificacions_Tipo_de_Notificacion.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Notificacion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipo_de_Accion_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Accion_Notificacions_Tipo_de_Accion = _ITipo_de_Accion_NotificacionApiConsumer.SelAll(true);
            if (Tipo_de_Accion_Notificacions_Tipo_de_Accion != null && Tipo_de_Accion_Notificacions_Tipo_de_Accion.Resource != null)
                ViewBag.Tipo_de_Accion_Notificacions_Tipo_de_Accion = Tipo_de_Accion_Notificacions_Tipo_de_Accion.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Accion_Notificacion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipo_de_Recordatorio_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Recordatorio_Notificacions_Tipo_de_Recordatorio = _ITipo_de_Recordatorio_NotificacionApiConsumer.SelAll(true);
            if (Tipo_de_Recordatorio_Notificacions_Tipo_de_Recordatorio != null && Tipo_de_Recordatorio_Notificacions_Tipo_de_Recordatorio.Resource != null)
                ViewBag.Tipo_de_Recordatorio_Notificacions_Tipo_de_Recordatorio = Tipo_de_Recordatorio_Notificacions_Tipo_de_Recordatorio.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Recordatorio_Notificacion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _INombre_del_campo_en_MSApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Nombre_del_campo_en_MSs_Fecha_a_validar = _INombre_del_campo_en_MSApiConsumer.SelAll(true);
            if (Nombre_del_campo_en_MSs_Fecha_a_validar != null && Nombre_del_campo_en_MSs_Fecha_a_validar.Resource != null)
                ViewBag.Nombre_del_campo_en_MSs_Fecha_a_validar = Nombre_del_campo_en_MSs_Fecha_a_validar.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Nombre_del_campo_en_MS", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            var previousFiltersObj = new Configuracion_de_NotificacionesAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Configuracion_de_NotificacionesAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Configuracion_de_NotificacionesAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Configuracion_de_NotificacionesPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IConfiguracion_de_NotificacionesApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Configuracion_de_Notificacioness == null)
                result.Configuracion_de_Notificacioness = new List<Configuracion_de_Notificaciones>();

            return Json(new
            {
                data = result.Configuracion_de_Notificacioness.Select(m => new Configuracion_de_NotificacionesGridModel
                    {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre_de_la_Notificacion = m.Nombre_de_la_Notificacion
			,Es_permanente = m.Es_permanente
                        ,FuncionalidadFuncionalidad = CultureHelper.GetTraduction(m.Funcionalidad_Funcionalidades_para_Notificacion.Folio.ToString(), "Funcionalidad") ?? (string)m.Funcionalidad_Funcionalidades_para_Notificacion.Funcionalidad
                        ,Tipo_de_NotificacionDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Notificacion_Tipo_de_Notificacion.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Notificacion_Tipo_de_Notificacion.Descripcion
                        ,Tipo_de_AccionDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Accion_Tipo_de_Accion_Notificacion.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Accion_Tipo_de_Accion_Notificacion.Descripcion
                        ,Tipo_de_RecordatorioDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Recordatorio_Tipo_de_Recordatorio_Notificacion.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Recordatorio_Tipo_de_Recordatorio_Notificacion.Descripcion
                        ,Fecha_inicio = (m.Fecha_inicio == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio).ToString(ConfigurationProperty.DateFormat))
			,Tiene_fecha_de_finalizacion_definida = m.Tiene_fecha_de_finalizacion_definida
			,Cantidad_de_dias_a_validar = m.Cantidad_de_dias_a_validar
                        ,Fecha_a_validarDescripcion = CultureHelper.GetTraduction(m.Fecha_a_validar_Nombre_del_campo_en_MS.Clave.ToString(), "Descripcion") ?? (string)m.Fecha_a_validar_Nombre_del_campo_en_MS.Descripcion
                        ,Fecha_fin = (m.Fecha_fin == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin).ToString(ConfigurationProperty.DateFormat))
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion
			,Notificar_por_correo = m.Notificar_por_correo
			,Texto_que_llevara_el_correo = m.Texto_que_llevara_el_correo
			,Notificacion_push = m.Notificacion_push
			,Texto_a_mostrar_en_la_notificacion_Push = m.Texto_a_mostrar_en_la_notificacion_Push

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }
		/*
		 [HttpGet]
        public ActionResult GetConfiguracion_de_NotificacionesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IConfiguracion_de_NotificacionesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IConfiguracion_de_NotificacionesApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraductionNew(Convert.ToString(m.Folio), "Configuracion_de_Notificaciones", m.),
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
        /// Get List of Configuracion_de_Notificaciones from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Configuracion_de_Notificaciones Entity</returns>
        public ActionResult GetConfiguracion_de_NotificacionesList(UrlParametersModel param)
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
            _IConfiguracion_de_NotificacionesApiConsumer.SetAuthHeader(_tokenManager.Token);

          
            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new Configuracion_de_NotificacionesPropertyMapper());
				
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
				if (Session["AdvanceSearch"].GetType() == typeof(Configuracion_de_NotificacionesAdvanceSearchModel))
                {
					var advanceFilter =
                    (Configuracion_de_NotificacionesAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            Configuracion_de_NotificacionesPropertyMapper oConfiguracion_de_NotificacionesPropertyMapper = new Configuracion_de_NotificacionesPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                 if (sortColumn != -1)
                    configuration.OrderByClause = oConfiguracion_de_NotificacionesPropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _IConfiguracion_de_NotificacionesApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Configuracion_de_Notificacioness == null)
                result.Configuracion_de_Notificacioness = new List<Configuracion_de_Notificaciones>();

            return Json(new
            {
                aaData = result.Configuracion_de_Notificacioness.Select(m => new Configuracion_de_NotificacionesGridModel
            {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre_de_la_Notificacion = m.Nombre_de_la_Notificacion
			,Es_permanente = m.Es_permanente
                        ,FuncionalidadFuncionalidad = CultureHelper.GetTraduction(m.Funcionalidad_Funcionalidades_para_Notificacion.Folio.ToString(), "Funcionalidad") ?? (string)m.Funcionalidad_Funcionalidades_para_Notificacion.Funcionalidad
                        ,Tipo_de_NotificacionDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Notificacion_Tipo_de_Notificacion.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Notificacion_Tipo_de_Notificacion.Descripcion
                        ,Tipo_de_AccionDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Accion_Tipo_de_Accion_Notificacion.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Accion_Tipo_de_Accion_Notificacion.Descripcion
                        ,Tipo_de_RecordatorioDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Recordatorio_Tipo_de_Recordatorio_Notificacion.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Recordatorio_Tipo_de_Recordatorio_Notificacion.Descripcion
                        ,Fecha_inicio = (m.Fecha_inicio == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio).ToString(ConfigurationProperty.DateFormat))
			,Tiene_fecha_de_finalizacion_definida = m.Tiene_fecha_de_finalizacion_definida
			,Cantidad_de_dias_a_validar = m.Cantidad_de_dias_a_validar
                        ,Fecha_a_validarDescripcion = CultureHelper.GetTraduction(m.Fecha_a_validar_Nombre_del_campo_en_MS.Clave.ToString(), "Descripcion") ?? (string)m.Fecha_a_validar_Nombre_del_campo_en_MS.Descripcion
                        ,Fecha_fin = (m.Fecha_fin == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin).ToString(ConfigurationProperty.DateFormat))
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion
			,Notificar_por_correo = m.Notificar_por_correo
			,Texto_que_llevara_el_correo = m.Texto_que_llevara_el_correo
			,Notificacion_push = m.Notificacion_push
			,Texto_a_mostrar_en_la_notificacion_Push = m.Texto_a_mostrar_en_la_notificacion_Push

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }


//Grid GetAutoComplete

//Grid GetAutoComplete






        [NonAction]
        public string GetAdvanceFilter(Configuracion_de_NotificacionesAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromFolio) || !string.IsNullOrEmpty(filter.ToFolio))
            {
                if (!string.IsNullOrEmpty(filter.FromFolio))
                    where += " AND Configuracion_de_Notificaciones.Folio >= " + filter.FromFolio;
                if (!string.IsNullOrEmpty(filter.ToFolio))
                    where += " AND Configuracion_de_Notificaciones.Folio <= " + filter.ToFolio;
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro) || !string.IsNullOrEmpty(filter.ToFecha_de_Registro))
            {
                var Fecha_de_RegistroFrom = DateTime.ParseExact(filter.FromFecha_de_Registro, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_de_RegistroTo = DateTime.ParseExact(filter.ToFecha_de_Registro, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro))
                    where += " AND Configuracion_de_Notificaciones.Fecha_de_Registro >= '" + Fecha_de_RegistroFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_Registro))
                    where += " AND Configuracion_de_Notificaciones.Fecha_de_Registro <= '" + Fecha_de_RegistroTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromHora_de_Registro) || !string.IsNullOrEmpty(filter.ToHora_de_Registro))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_de_Registro))
                    where += " AND Convert(TIME,Configuracion_de_Notificaciones.Hora_de_Registro) >='" + filter.FromHora_de_Registro + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_de_Registro))
                    where += " AND Convert(TIME,Configuracion_de_Notificaciones.Hora_de_Registro) <='" + filter.ToHora_de_Registro + "'";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceUsuario_que_Registra))
            {
                switch (filter.Usuario_que_RegistraFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_User.Name LIKE '" + filter.AdvanceUsuario_que_Registra + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceUsuario_que_Registra + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_User.Name = '" + filter.AdvanceUsuario_que_Registra + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceUsuario_que_Registra + "%'";
                        break;
                }
            }
            else if (filter.AdvanceUsuario_que_RegistraMultiple != null && filter.AdvanceUsuario_que_RegistraMultiple.Count() > 0)
            {
                var Usuario_que_RegistraIds = string.Join(",", filter.AdvanceUsuario_que_RegistraMultiple);

                where += " AND Configuracion_de_Notificaciones.Usuario_que_Registra In (" + Usuario_que_RegistraIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Nombre_de_la_Notificacion))
            {
                switch (filter.Nombre_de_la_NotificacionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Configuracion_de_Notificaciones.Nombre_de_la_Notificacion LIKE '" + filter.Nombre_de_la_Notificacion + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Configuracion_de_Notificaciones.Nombre_de_la_Notificacion LIKE '%" + filter.Nombre_de_la_Notificacion + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Configuracion_de_Notificaciones.Nombre_de_la_Notificacion = '" + filter.Nombre_de_la_Notificacion + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Configuracion_de_Notificaciones.Nombre_de_la_Notificacion LIKE '%" + filter.Nombre_de_la_Notificacion + "%'";
                        break;
                }
            }

            if (filter.Es_permanente != RadioOptions.NoApply)
                where += " AND Configuracion_de_Notificaciones.Es_permanente = " + Convert.ToInt32(filter.Es_permanente);

            if (!string.IsNullOrEmpty(filter.AdvanceFuncionalidad))
            {
                switch (filter.FuncionalidadFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Funcionalidades_para_Notificacion.Funcionalidad LIKE '" + filter.AdvanceFuncionalidad + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Funcionalidades_para_Notificacion.Funcionalidad LIKE '%" + filter.AdvanceFuncionalidad + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Funcionalidades_para_Notificacion.Funcionalidad = '" + filter.AdvanceFuncionalidad + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Funcionalidades_para_Notificacion.Funcionalidad LIKE '%" + filter.AdvanceFuncionalidad + "%'";
                        break;
                }
            }
            else if (filter.AdvanceFuncionalidadMultiple != null && filter.AdvanceFuncionalidadMultiple.Count() > 0)
            {
                var FuncionalidadIds = string.Join(",", filter.AdvanceFuncionalidadMultiple);

                where += " AND Configuracion_de_Notificaciones.Funcionalidad In (" + FuncionalidadIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceTipo_de_Notificacion))
            {
                switch (filter.Tipo_de_NotificacionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Tipo_de_Notificacion.Descripcion LIKE '" + filter.AdvanceTipo_de_Notificacion + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Tipo_de_Notificacion.Descripcion LIKE '%" + filter.AdvanceTipo_de_Notificacion + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Tipo_de_Notificacion.Descripcion = '" + filter.AdvanceTipo_de_Notificacion + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Tipo_de_Notificacion.Descripcion LIKE '%" + filter.AdvanceTipo_de_Notificacion + "%'";
                        break;
                }
            }
            else if (filter.AdvanceTipo_de_NotificacionMultiple != null && filter.AdvanceTipo_de_NotificacionMultiple.Count() > 0)
            {
                var Tipo_de_NotificacionIds = string.Join(",", filter.AdvanceTipo_de_NotificacionMultiple);

                where += " AND Configuracion_de_Notificaciones.Tipo_de_Notificacion In (" + Tipo_de_NotificacionIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceTipo_de_Accion))
            {
                switch (filter.Tipo_de_AccionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Tipo_de_Accion_Notificacion.Descripcion LIKE '" + filter.AdvanceTipo_de_Accion + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Tipo_de_Accion_Notificacion.Descripcion LIKE '%" + filter.AdvanceTipo_de_Accion + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Tipo_de_Accion_Notificacion.Descripcion = '" + filter.AdvanceTipo_de_Accion + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Tipo_de_Accion_Notificacion.Descripcion LIKE '%" + filter.AdvanceTipo_de_Accion + "%'";
                        break;
                }
            }
            else if (filter.AdvanceTipo_de_AccionMultiple != null && filter.AdvanceTipo_de_AccionMultiple.Count() > 0)
            {
                var Tipo_de_AccionIds = string.Join(",", filter.AdvanceTipo_de_AccionMultiple);

                where += " AND Configuracion_de_Notificaciones.Tipo_de_Accion In (" + Tipo_de_AccionIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceTipo_de_Recordatorio))
            {
                switch (filter.Tipo_de_RecordatorioFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Tipo_de_Recordatorio_Notificacion.Descripcion LIKE '" + filter.AdvanceTipo_de_Recordatorio + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Tipo_de_Recordatorio_Notificacion.Descripcion LIKE '%" + filter.AdvanceTipo_de_Recordatorio + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Tipo_de_Recordatorio_Notificacion.Descripcion = '" + filter.AdvanceTipo_de_Recordatorio + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Tipo_de_Recordatorio_Notificacion.Descripcion LIKE '%" + filter.AdvanceTipo_de_Recordatorio + "%'";
                        break;
                }
            }
            else if (filter.AdvanceTipo_de_RecordatorioMultiple != null && filter.AdvanceTipo_de_RecordatorioMultiple.Count() > 0)
            {
                var Tipo_de_RecordatorioIds = string.Join(",", filter.AdvanceTipo_de_RecordatorioMultiple);

                where += " AND Configuracion_de_Notificaciones.Tipo_de_Recordatorio In (" + Tipo_de_RecordatorioIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_inicio) || !string.IsNullOrEmpty(filter.ToFecha_inicio))
            {
                var Fecha_inicioFrom = DateTime.ParseExact(filter.FromFecha_inicio, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_inicioTo = DateTime.ParseExact(filter.ToFecha_inicio, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_inicio))
                    where += " AND Configuracion_de_Notificaciones.Fecha_inicio >= '" + Fecha_inicioFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_inicio))
                    where += " AND Configuracion_de_Notificaciones.Fecha_inicio <= '" + Fecha_inicioTo.ToString("MM-dd-yyyy") + "'";
            }

            if (filter.Tiene_fecha_de_finalizacion_definida != RadioOptions.NoApply)
                where += " AND Configuracion_de_Notificaciones.Tiene_fecha_de_finalizacion_definida = " + Convert.ToInt32(filter.Tiene_fecha_de_finalizacion_definida);

            if (!string.IsNullOrEmpty(filter.FromCantidad_de_dias_a_validar) || !string.IsNullOrEmpty(filter.ToCantidad_de_dias_a_validar))
            {
                if (!string.IsNullOrEmpty(filter.FromCantidad_de_dias_a_validar))
                    where += " AND Configuracion_de_Notificaciones.Cantidad_de_dias_a_validar >= " + filter.FromCantidad_de_dias_a_validar;
                if (!string.IsNullOrEmpty(filter.ToCantidad_de_dias_a_validar))
                    where += " AND Configuracion_de_Notificaciones.Cantidad_de_dias_a_validar <= " + filter.ToCantidad_de_dias_a_validar;
            }

            if (!string.IsNullOrEmpty(filter.AdvanceFecha_a_validar))
            {
                switch (filter.Fecha_a_validarFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Nombre_del_campo_en_MS.Descripcion LIKE '" + filter.AdvanceFecha_a_validar + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Nombre_del_campo_en_MS.Descripcion LIKE '%" + filter.AdvanceFecha_a_validar + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Nombre_del_campo_en_MS.Descripcion = '" + filter.AdvanceFecha_a_validar + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Nombre_del_campo_en_MS.Descripcion LIKE '%" + filter.AdvanceFecha_a_validar + "%'";
                        break;
                }
            }
            else if (filter.AdvanceFecha_a_validarMultiple != null && filter.AdvanceFecha_a_validarMultiple.Count() > 0)
            {
                var Fecha_a_validarIds = string.Join(",", filter.AdvanceFecha_a_validarMultiple);

                where += " AND Configuracion_de_Notificaciones.Fecha_a_validar In (" + Fecha_a_validarIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_fin) || !string.IsNullOrEmpty(filter.ToFecha_fin))
            {
                var Fecha_finFrom = DateTime.ParseExact(filter.FromFecha_fin, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_finTo = DateTime.ParseExact(filter.ToFecha_fin, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_fin))
                    where += " AND Configuracion_de_Notificaciones.Fecha_fin >= '" + Fecha_finFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_fin))
                    where += " AND Configuracion_de_Notificaciones.Fecha_fin <= '" + Fecha_finTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceEstatus))
            {
                switch (filter.EstatusFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Estatus.Descripcion LIKE '" + filter.AdvanceEstatus + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Estatus.Descripcion LIKE '%" + filter.AdvanceEstatus + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Estatus.Descripcion = '" + filter.AdvanceEstatus + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Estatus.Descripcion LIKE '%" + filter.AdvanceEstatus + "%'";
                        break;
                }
            }
            else if (filter.AdvanceEstatusMultiple != null && filter.AdvanceEstatusMultiple.Count() > 0)
            {
                var EstatusIds = string.Join(",", filter.AdvanceEstatusMultiple);

                where += " AND Configuracion_de_Notificaciones.Estatus In (" + EstatusIds + ")";
            }

            if (filter.Notificar_por_correo != RadioOptions.NoApply)
                where += " AND Configuracion_de_Notificaciones.Notificar_por_correo = " + Convert.ToInt32(filter.Notificar_por_correo);

            if (!string.IsNullOrEmpty(filter.Texto_que_llevara_el_correo))
            {
                switch (filter.Texto_que_llevara_el_correoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Configuracion_de_Notificaciones.Texto_que_llevara_el_correo LIKE '" + filter.Texto_que_llevara_el_correo + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Configuracion_de_Notificaciones.Texto_que_llevara_el_correo LIKE '%" + filter.Texto_que_llevara_el_correo + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Configuracion_de_Notificaciones.Texto_que_llevara_el_correo = '" + filter.Texto_que_llevara_el_correo + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Configuracion_de_Notificaciones.Texto_que_llevara_el_correo LIKE '%" + filter.Texto_que_llevara_el_correo + "%'";
                        break;
                }
            }

            if (filter.Notificacion_push != RadioOptions.NoApply)
                where += " AND Configuracion_de_Notificaciones.Notificacion_push = " + Convert.ToInt32(filter.Notificacion_push);

            if (!string.IsNullOrEmpty(filter.Texto_a_mostrar_en_la_notificacion_Push))
            {
                switch (filter.Texto_a_mostrar_en_la_notificacion_PushFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Configuracion_de_Notificaciones.Texto_a_mostrar_en_la_notificacion_Push LIKE '" + filter.Texto_a_mostrar_en_la_notificacion_Push + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Configuracion_de_Notificaciones.Texto_a_mostrar_en_la_notificacion_Push LIKE '%" + filter.Texto_a_mostrar_en_la_notificacion_Push + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Configuracion_de_Notificaciones.Texto_a_mostrar_en_la_notificacion_Push = '" + filter.Texto_a_mostrar_en_la_notificacion_Push + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Configuracion_de_Notificaciones.Texto_a_mostrar_en_la_notificacion_Push LIKE '%" + filter.Texto_a_mostrar_en_la_notificacion_Push + "%'";
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
        public ActionResult GetDirigido_a_Roles_para_NotificarAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                
                _ITipo_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipo_PacienteApiConsumer.SelAll(false).Resource;

                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetRoles_para_Notificar(int draw, int start, int length, int RelationId = 0)
        {
            if (RelationId == 0)
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Roles_para_NotificarGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IRoles_para_NotificarApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
			
var result = _IRoles_para_NotificarApiConsumer.ListaSelAll(start, pageSize, "Roles_para_Notificar.Folio_Configuracion_de_Notificaciones=" + RelationId,"").Resource;

            if (result.Roles_para_Notificars == null)
                result.Roles_para_Notificars = new List<Roles_para_Notificar>();

            var jsonResult = Json(new
            {
                data = result.Roles_para_Notificars.Select(m => new Roles_para_NotificarGridModel
                {
                    Folio = m.Folio
					
                ,Rol = m.Rol
		,RolDescripcion = m.Rol_Tipo_Paciente.Descripcion


                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public ActionResult GetDetalle_Frecuencia_Notificaciones(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_Frecuencia_NotificacionesGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Frecuencia_NotificacionesApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Frecuencia_Notificaciones.FolioNotificacion=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Frecuencia_Notificaciones.FolioNotificacion='" + RelationId + "'";
            }
            var result = _IDetalle_Frecuencia_NotificacionesApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Frecuencia_Notificacioness == null)
                result.Detalle_Frecuencia_Notificacioness = new List<Detalle_Frecuencia_Notificaciones>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Frecuencia_Notificacioness.Select(m => new Detalle_Frecuencia_NotificacionesGridModel
                {
                    Folio = m.Folio

                        ,Frecuencia = m.Frecuencia
                        ,FrecuenciaDescripcion = CultureHelper.GetTraduction(m.Frecuencia_Tipo_Frecuencia_Notificacion.Clave.ToString(), "Descripcion") ??(string)m.Frecuencia_Tipo_Frecuencia_Notificacion.Descripcion
                        ,Dia = m.Dia
                        ,DiaDescripcion = CultureHelper.GetTraduction(m.Dia_Tipo_Dia_Notificacion.Clave.ToString(), "Descripcion") ??(string)m.Dia_Tipo_Dia_Notificacion.Descripcion
			,Hora = m.Hora

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_Frecuencia_NotificacionesGridModel> GetDetalle_Frecuencia_NotificacionesData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_Frecuencia_NotificacionesGridModel> resultData = new List<Detalle_Frecuencia_NotificacionesGridModel>();
            string where = "Detalle_Frecuencia_Notificaciones.FolioNotificacion=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Frecuencia_Notificaciones.FolioNotificacion='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Frecuencia_NotificacionesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_Frecuencia_NotificacionesApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Frecuencia_Notificacioness != null)
            {
                resultData = result.Detalle_Frecuencia_Notificacioness.Select(m => new Detalle_Frecuencia_NotificacionesGridModel
                    {
                        Folio = m.Folio

                        ,Frecuencia = m.Frecuencia
                        ,FrecuenciaDescripcion = CultureHelper.GetTraduction(m.Frecuencia_Tipo_Frecuencia_Notificacion.Clave.ToString(), "Descripcion") ??(string)m.Frecuencia_Tipo_Frecuencia_Notificacion.Descripcion
                        ,Dia = m.Dia
                        ,DiaDescripcion = CultureHelper.GetTraduction(m.Dia_Tipo_Dia_Notificacion.Clave.ToString(), "Descripcion") ??(string)m.Dia_Tipo_Dia_Notificacion.Descripcion
			,Hora = m.Hora


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
                _IConfiguracion_de_NotificacionesApiConsumer.SetAuthHeader(_tokenManager.Token);

                Configuracion_de_Notificaciones varConfiguracion_de_Notificaciones = null;
                if (id.ToString() != "0")
                {
                        string where = "";
                    _IRoles_para_NotificarApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Roles_para_Notificar.Folio_Configuracion_de_Notificaciones=" + id;
                    if("int" == "string")
                    {
	                where = "Roles_para_Notificar.Folio_Configuracion_de_Notificaciones='" + id + "'";
                    }
                    var Roles_para_NotificarInfo =
                        _IRoles_para_NotificarApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Roles_para_NotificarInfo.Roles_para_Notificars.Count > 0)
                    {
                        var resultRoles_para_Notificar = true;
                        //Removing associated job history with attachment
                        foreach (var Roles_para_NotificarItem in Roles_para_NotificarInfo.Roles_para_Notificars)
                            resultRoles_para_Notificar = resultRoles_para_Notificar
                                              && _IRoles_para_NotificarApiConsumer.Delete(Roles_para_NotificarItem.Folio, null,null).Resource;

                        if (!resultRoles_para_Notificar)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _IDetalle_Frecuencia_NotificacionesApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Frecuencia_Notificaciones.FolioNotificacion=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Frecuencia_Notificaciones.FolioNotificacion='" + id + "'";
                    }
                    var Detalle_Frecuencia_NotificacionesInfo =
                        _IDetalle_Frecuencia_NotificacionesApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_Frecuencia_NotificacionesInfo.Detalle_Frecuencia_Notificacioness.Count > 0)
                    {
                        var resultDetalle_Frecuencia_Notificaciones = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_Frecuencia_NotificacionesItem in Detalle_Frecuencia_NotificacionesInfo.Detalle_Frecuencia_Notificacioness)
                            resultDetalle_Frecuencia_Notificaciones = resultDetalle_Frecuencia_Notificaciones
                                              && _IDetalle_Frecuencia_NotificacionesApiConsumer.Delete(Detalle_Frecuencia_NotificacionesItem.Folio, null,null).Resource;

                        if (!resultDetalle_Frecuencia_Notificaciones)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                var result = _IConfiguracion_de_NotificacionesApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Configuracion_de_NotificacionesModel varConfiguracion_de_Notificaciones)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IConfiguracion_de_NotificacionesApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Configuracion_de_NotificacionesInfo = new Configuracion_de_Notificaciones
                    {
                        Folio = varConfiguracion_de_Notificaciones.Folio
                        ,Fecha_de_Registro = (!String.IsNullOrEmpty(varConfiguracion_de_Notificaciones.Fecha_de_Registro)) ? DateTime.ParseExact(varConfiguracion_de_Notificaciones.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varConfiguracion_de_Notificaciones.Hora_de_Registro
                        ,Usuario_que_Registra = varConfiguracion_de_Notificaciones.Usuario_que_Registra
                        ,Nombre_de_la_Notificacion = varConfiguracion_de_Notificaciones.Nombre_de_la_Notificacion
                        ,Es_permanente = varConfiguracion_de_Notificaciones.Es_permanente
                        ,Funcionalidad = varConfiguracion_de_Notificaciones.Funcionalidad
                        ,Tipo_de_Notificacion = varConfiguracion_de_Notificaciones.Tipo_de_Notificacion
                        ,Tipo_de_Accion = varConfiguracion_de_Notificaciones.Tipo_de_Accion
                        ,Tipo_de_Recordatorio = varConfiguracion_de_Notificaciones.Tipo_de_Recordatorio
                        ,Fecha_inicio = (!String.IsNullOrEmpty(varConfiguracion_de_Notificaciones.Fecha_inicio)) ? DateTime.ParseExact(varConfiguracion_de_Notificaciones.Fecha_inicio, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Tiene_fecha_de_finalizacion_definida = varConfiguracion_de_Notificaciones.Tiene_fecha_de_finalizacion_definida
                        ,Cantidad_de_dias_a_validar = varConfiguracion_de_Notificaciones.Cantidad_de_dias_a_validar
                        ,Fecha_a_validar = varConfiguracion_de_Notificaciones.Fecha_a_validar
                        ,Fecha_fin = (!String.IsNullOrEmpty(varConfiguracion_de_Notificaciones.Fecha_fin)) ? DateTime.ParseExact(varConfiguracion_de_Notificaciones.Fecha_fin, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Estatus = varConfiguracion_de_Notificaciones.Estatus
                        ,Notificar_por_correo = varConfiguracion_de_Notificaciones.Notificar_por_correo
                        ,Texto_que_llevara_el_correo = varConfiguracion_de_Notificaciones.Texto_que_llevara_el_correo
                        ,Notificacion_push = varConfiguracion_de_Notificaciones.Notificacion_push
                        ,Texto_a_mostrar_en_la_notificacion_Push = varConfiguracion_de_Notificaciones.Texto_a_mostrar_en_la_notificacion_Push

                    };

                    result = !IsNew ?
                        _IConfiguracion_de_NotificacionesApiConsumer.Update(Configuracion_de_NotificacionesInfo, null, null).Resource.ToString() :
                         _IConfiguracion_de_NotificacionesApiConsumer.Insert(Configuracion_de_NotificacionesInfo, null, null).Resource.ToString();
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
        public bool CopyRoles_para_Notificar(int MasterId, int referenceId, List<Roles_para_NotificarGridModelPost> Roles_para_NotificarItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IRoles_para_NotificarApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Roles_para_NotificarData = _IRoles_para_NotificarApiConsumer.ListaSelAll(1, int.MaxValue, "Roles_para_Notificar.Folio_Configuracion_de_Notificaciones=" + referenceId,"").Resource;
                if (Roles_para_NotificarData == null || Roles_para_NotificarData.Roles_para_Notificars.Count == 0)
                    return true;

                var result = true;

                Roles_para_NotificarGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varRoles_para_Notificar in Roles_para_NotificarData.Roles_para_Notificars)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Roles_para_Notificar Roles_para_Notificar1 = varRoles_para_Notificar;

                    if (Roles_para_NotificarItems != null && Roles_para_NotificarItems.Any(m => m.Folio == Roles_para_Notificar1.Folio))
                    {
                        modelDataToChange = Roles_para_NotificarItems.FirstOrDefault(m => m.Folio == Roles_para_Notificar1.Folio);
                    }
                    //Chaning Id Value
                    varRoles_para_Notificar.Folio_Configuracion_de_Notificaciones = MasterId;
                    var insertId = _IRoles_para_NotificarApiConsumer.Insert(varRoles_para_Notificar,null,null).Resource;
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
        public ActionResult PostRoles_para_Notificar(List<Roles_para_NotificarGridModelPost> Roles_para_NotificarItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyRoles_para_Notificar(MasterId, referenceId, Roles_para_NotificarItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Roles_para_NotificarItems != null && Roles_para_NotificarItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IRoles_para_NotificarApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Roles_para_NotificarItem in Roles_para_NotificarItems)
                    {



                        //Removal Request
                        if (Roles_para_NotificarItem.Removed)
                        {
                            result = result && _IRoles_para_NotificarApiConsumer.Delete(Roles_para_NotificarItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Roles_para_NotificarItem.Folio = 0;

                        var Roles_para_NotificarData = new Roles_para_Notificar
                        {
                            Folio_Configuracion_de_Notificaciones = MasterId
                            ,Folio = Roles_para_NotificarItem.Folio
                            ,Rol = (Convert.ToInt32(Roles_para_NotificarItem.Rol) == 0 ? (Int32?)null : Convert.ToInt32(Roles_para_NotificarItem.Rol))

                        };

                        var resultId = Roles_para_NotificarItem.Folio > 0
                           ? _IRoles_para_NotificarApiConsumer.Update(Roles_para_NotificarData,null,null).Resource
                           : _IRoles_para_NotificarApiConsumer.Insert(Roles_para_NotificarData,null,null).Resource;

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
        public ActionResult GetRoles_para_Notificar_Tipo_PacienteAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipo_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipo_PacienteApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Tipo_Paciente", "Descripcion");
                  item.Descripcion= trans??item.Descripcion;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [NonAction]
        public bool CopyDetalle_Frecuencia_Notificaciones(int MasterId, int referenceId, List<Detalle_Frecuencia_NotificacionesGridModelPost> Detalle_Frecuencia_NotificacionesItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_Frecuencia_NotificacionesApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_Frecuencia_NotificacionesData = _IDetalle_Frecuencia_NotificacionesApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Frecuencia_Notificaciones.FolioNotificacion=" + referenceId,"").Resource;
                if (Detalle_Frecuencia_NotificacionesData == null || Detalle_Frecuencia_NotificacionesData.Detalle_Frecuencia_Notificacioness.Count == 0)
                    return true;

                var result = true;

                Detalle_Frecuencia_NotificacionesGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Frecuencia_Notificaciones in Detalle_Frecuencia_NotificacionesData.Detalle_Frecuencia_Notificacioness)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Frecuencia_Notificaciones Detalle_Frecuencia_Notificaciones1 = varDetalle_Frecuencia_Notificaciones;

                    if (Detalle_Frecuencia_NotificacionesItems != null && Detalle_Frecuencia_NotificacionesItems.Any(m => m.Folio == Detalle_Frecuencia_Notificaciones1.Folio))
                    {
                        modelDataToChange = Detalle_Frecuencia_NotificacionesItems.FirstOrDefault(m => m.Folio == Detalle_Frecuencia_Notificaciones1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Frecuencia_Notificaciones.FolioNotificacion = MasterId;
                    var insertId = _IDetalle_Frecuencia_NotificacionesApiConsumer.Insert(varDetalle_Frecuencia_Notificaciones,null,null).Resource;
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
        public ActionResult PostDetalle_Frecuencia_Notificaciones(List<Detalle_Frecuencia_NotificacionesGridModelPost> Detalle_Frecuencia_NotificacionesItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Frecuencia_Notificaciones(MasterId, referenceId, Detalle_Frecuencia_NotificacionesItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_Frecuencia_NotificacionesItems != null && Detalle_Frecuencia_NotificacionesItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_Frecuencia_NotificacionesApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_Frecuencia_NotificacionesItem in Detalle_Frecuencia_NotificacionesItems)
                    {





                        //Removal Request
                        if (Detalle_Frecuencia_NotificacionesItem.Removed)
                        {
                            result = result && _IDetalle_Frecuencia_NotificacionesApiConsumer.Delete(Detalle_Frecuencia_NotificacionesItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_Frecuencia_NotificacionesItem.Folio = 0;

                        var Detalle_Frecuencia_NotificacionesData = new Detalle_Frecuencia_Notificaciones
                        {
                            FolioNotificacion = MasterId
                            ,Folio = Detalle_Frecuencia_NotificacionesItem.Folio
                            ,Frecuencia = (Convert.ToInt32(Detalle_Frecuencia_NotificacionesItem.Frecuencia) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Frecuencia_NotificacionesItem.Frecuencia))
                            ,Dia = (Convert.ToInt32(Detalle_Frecuencia_NotificacionesItem.Dia) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Frecuencia_NotificacionesItem.Dia))
                            ,Hora = Detalle_Frecuencia_NotificacionesItem.Hora

                        };

                        var resultId = Detalle_Frecuencia_NotificacionesItem.Folio > 0
                           ? _IDetalle_Frecuencia_NotificacionesApiConsumer.Update(Detalle_Frecuencia_NotificacionesData,null,null).Resource
                           : _IDetalle_Frecuencia_NotificacionesApiConsumer.Insert(Detalle_Frecuencia_NotificacionesData,null,null).Resource;

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
        public ActionResult GetDetalle_Frecuencia_Notificaciones_Tipo_Frecuencia_NotificacionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipo_Frecuencia_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipo_Frecuencia_NotificacionApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Tipo_Frecuencia_Notificacion", "Descripcion");
                  item.Descripcion= trans??item.Descripcion;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetDetalle_Frecuencia_Notificaciones_Tipo_Dia_NotificacionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipo_Dia_NotificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipo_Dia_NotificacionApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Tipo_Dia_Notificacion", "Descripcion");
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
        /// Write Element Array of Configuracion_de_Notificaciones script
        /// </summary>
        /// <param name="oConfiguracion_de_NotificacionesElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew Configuracion_de_NotificacionesModuleAttributeList)
        {
            for (int i = 0; i < Configuracion_de_NotificacionesModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Configuracion_de_NotificacionesModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Configuracion_de_NotificacionesModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Configuracion_de_NotificacionesModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Configuracion_de_NotificacionesModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Configuracion_de_NotificacionesModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Configuracion_de_NotificacionesModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < Configuracion_de_NotificacionesModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(Configuracion_de_NotificacionesModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							Configuracion_de_NotificacionesModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(Configuracion_de_NotificacionesModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							Configuracion_de_NotificacionesModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strConfiguracion_de_NotificacionesScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Configuracion_de_Notificaciones.js")))
            {
                strConfiguracion_de_NotificacionesScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Configuracion_de_Notificaciones element attributes
            string userChangeJson = jsSerialize.Serialize(Configuracion_de_NotificacionesModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strConfiguracion_de_NotificacionesScript.IndexOf("inpuElementArray");
            string splittedString = strConfiguracion_de_NotificacionesScript.Substring(indexOfArray, strConfiguracion_de_NotificacionesScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Configuracion_de_NotificacionesModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Configuracion_de_NotificacionesModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strConfiguracion_de_NotificacionesScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strConfiguracion_de_NotificacionesScript.Substring(indexOfArrayHistory, strConfiguracion_de_NotificacionesScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strConfiguracion_de_NotificacionesScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strConfiguracion_de_NotificacionesScript.Substring(endIndexOfMainElement + indexOfArray, strConfiguracion_de_NotificacionesScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (Configuracion_de_NotificacionesModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in Configuracion_de_NotificacionesModuleAttributeList.ChildModuleAttributeList)
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
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Configuracion_de_Notificaciones.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Configuracion_de_Notificaciones.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Configuracion_de_Notificaciones.js")))
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
        public ActionResult Configuracion_de_NotificacionesPropertyBag()
        {
            return PartialView("Configuracion_de_NotificacionesPropertyBag", "Configuracion_de_Notificaciones");
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
        public ActionResult AddRoles_para_Notificar(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Roles_para_Notificar/AddRoles_para_Notificar");
        }

        [HttpGet]
        public ActionResult AddDetalle_Frecuencia_Notificaciones(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Frecuencia_Notificaciones/AddDetalle_Frecuencia_Notificaciones");
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
                var whereClauseFormat = "Object = 44689 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _IConfiguracion_de_NotificacionesApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Configuracion_de_Notificaciones.Folio= " + RecordId;
                            var result = _IConfiguracion_de_NotificacionesApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
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

            _IConfiguracion_de_NotificacionesApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Configuracion_de_NotificacionesPropertyMapper());
			
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
                    (Configuracion_de_NotificacionesAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
			string sortDirection = "asc";

            Configuracion_de_NotificacionesPropertyMapper oConfiguracion_de_NotificacionesPropertyMapper = new Configuracion_de_NotificacionesPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oConfiguracion_de_NotificacionesPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IConfiguracion_de_NotificacionesApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Configuracion_de_Notificacioness == null)
                result.Configuracion_de_Notificacioness = new List<Configuracion_de_Notificaciones>();

            var data = result.Configuracion_de_Notificacioness.Select(m => new Configuracion_de_NotificacionesGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre_de_la_Notificacion = m.Nombre_de_la_Notificacion
			,Es_permanente = m.Es_permanente
                        ,FuncionalidadFuncionalidad = CultureHelper.GetTraduction(m.Funcionalidad_Funcionalidades_para_Notificacion.Folio.ToString(), "Funcionalidad") ?? (string)m.Funcionalidad_Funcionalidades_para_Notificacion.Funcionalidad
                        ,Tipo_de_NotificacionDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Notificacion_Tipo_de_Notificacion.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Notificacion_Tipo_de_Notificacion.Descripcion
                        ,Tipo_de_AccionDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Accion_Tipo_de_Accion_Notificacion.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Accion_Tipo_de_Accion_Notificacion.Descripcion
                        ,Tipo_de_RecordatorioDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Recordatorio_Tipo_de_Recordatorio_Notificacion.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Recordatorio_Tipo_de_Recordatorio_Notificacion.Descripcion
                        ,Fecha_inicio = (m.Fecha_inicio == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio).ToString(ConfigurationProperty.DateFormat))
			,Tiene_fecha_de_finalizacion_definida = m.Tiene_fecha_de_finalizacion_definida
			,Cantidad_de_dias_a_validar = m.Cantidad_de_dias_a_validar
                        ,Fecha_a_validarDescripcion = CultureHelper.GetTraduction(m.Fecha_a_validar_Nombre_del_campo_en_MS.Clave.ToString(), "Descripcion") ?? (string)m.Fecha_a_validar_Nombre_del_campo_en_MS.Descripcion
                        ,Fecha_fin = (m.Fecha_fin == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin).ToString(ConfigurationProperty.DateFormat))
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion
			,Notificar_por_correo = m.Notificar_por_correo
			,Texto_que_llevara_el_correo = m.Texto_que_llevara_el_correo
			,Notificacion_push = m.Notificacion_push
			,Texto_a_mostrar_en_la_notificacion_Push = m.Texto_a_mostrar_en_la_notificacion_Push

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(44689, arrayColumnsVisible), "Configuracion_de_NotificacionesList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(44689, arrayColumnsVisible), "Configuracion_de_NotificacionesList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(44689, arrayColumnsVisible), "Configuracion_de_NotificacionesList_" + DateTime.Now.ToString());
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

            _IConfiguracion_de_NotificacionesApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Configuracion_de_NotificacionesPropertyMapper());
				
				
            if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
			if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (Configuracion_de_NotificacionesAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            Configuracion_de_NotificacionesPropertyMapper oConfiguracion_de_NotificacionesPropertyMapper = new Configuracion_de_NotificacionesPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oConfiguracion_de_NotificacionesPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
			
			if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IConfiguracion_de_NotificacionesApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Configuracion_de_Notificacioness == null)
                result.Configuracion_de_Notificacioness = new List<Configuracion_de_Notificaciones>();

            var data = result.Configuracion_de_Notificacioness.Select(m => new Configuracion_de_NotificacionesGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre_de_la_Notificacion = m.Nombre_de_la_Notificacion
			,Es_permanente = m.Es_permanente
                        ,FuncionalidadFuncionalidad = CultureHelper.GetTraduction(m.Funcionalidad_Funcionalidades_para_Notificacion.Folio.ToString(), "Funcionalidad") ?? (string)m.Funcionalidad_Funcionalidades_para_Notificacion.Funcionalidad
                        ,Tipo_de_NotificacionDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Notificacion_Tipo_de_Notificacion.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Notificacion_Tipo_de_Notificacion.Descripcion
                        ,Tipo_de_AccionDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Accion_Tipo_de_Accion_Notificacion.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Accion_Tipo_de_Accion_Notificacion.Descripcion
                        ,Tipo_de_RecordatorioDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Recordatorio_Tipo_de_Recordatorio_Notificacion.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Recordatorio_Tipo_de_Recordatorio_Notificacion.Descripcion
                        ,Fecha_inicio = (m.Fecha_inicio == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio).ToString(ConfigurationProperty.DateFormat))
			,Tiene_fecha_de_finalizacion_definida = m.Tiene_fecha_de_finalizacion_definida
			,Cantidad_de_dias_a_validar = m.Cantidad_de_dias_a_validar
                        ,Fecha_a_validarDescripcion = CultureHelper.GetTraduction(m.Fecha_a_validar_Nombre_del_campo_en_MS.Clave.ToString(), "Descripcion") ?? (string)m.Fecha_a_validar_Nombre_del_campo_en_MS.Descripcion
                        ,Fecha_fin = (m.Fecha_fin == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin).ToString(ConfigurationProperty.DateFormat))
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion
			,Notificar_por_correo = m.Notificar_por_correo
			,Texto_que_llevara_el_correo = m.Texto_que_llevara_el_correo
			,Notificacion_push = m.Notificacion_push
			,Texto_a_mostrar_en_la_notificacion_Push = m.Texto_a_mostrar_en_la_notificacion_Push

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
                _IConfiguracion_de_NotificacionesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IConfiguracion_de_NotificacionesApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpPost]
        public ActionResult Post_Datos_Generales(Configuracion_de_Notificaciones_Datos_GeneralesModel varConfiguracion_de_Notificaciones)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IConfiguracion_de_NotificacionesApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Configuracion_de_Notificaciones_Datos_GeneralesInfo = new Configuracion_de_Notificaciones_Datos_Generales
                {
                    Folio = varConfiguracion_de_Notificaciones.Folio
                                            ,Fecha_de_Registro = (!String.IsNullOrEmpty(varConfiguracion_de_Notificaciones.Fecha_de_Registro)) ? DateTime.ParseExact(varConfiguracion_de_Notificaciones.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varConfiguracion_de_Notificaciones.Hora_de_Registro
                        ,Usuario_que_Registra = varConfiguracion_de_Notificaciones.Usuario_que_Registra
                        ,Nombre_de_la_Notificacion = varConfiguracion_de_Notificaciones.Nombre_de_la_Notificacion
                        ,Es_permanente = varConfiguracion_de_Notificaciones.Es_permanente
                        ,Funcionalidad = varConfiguracion_de_Notificaciones.Funcionalidad
                        ,Tipo_de_Notificacion = varConfiguracion_de_Notificaciones.Tipo_de_Notificacion
                        ,Tipo_de_Accion = varConfiguracion_de_Notificaciones.Tipo_de_Accion
                        ,Tipo_de_Recordatorio = varConfiguracion_de_Notificaciones.Tipo_de_Recordatorio
                        ,Fecha_inicio = (!String.IsNullOrEmpty(varConfiguracion_de_Notificaciones.Fecha_inicio)) ? DateTime.ParseExact(varConfiguracion_de_Notificaciones.Fecha_inicio, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Tiene_fecha_de_finalizacion_definida = varConfiguracion_de_Notificaciones.Tiene_fecha_de_finalizacion_definida
                        ,Cantidad_de_dias_a_validar = varConfiguracion_de_Notificaciones.Cantidad_de_dias_a_validar
                        ,Fecha_a_validar = varConfiguracion_de_Notificaciones.Fecha_a_validar
                        ,Fecha_fin = (!String.IsNullOrEmpty(varConfiguracion_de_Notificaciones.Fecha_fin)) ? DateTime.ParseExact(varConfiguracion_de_Notificaciones.Fecha_fin, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Estatus = varConfiguracion_de_Notificaciones.Estatus
                        ,Notificar_por_correo = varConfiguracion_de_Notificaciones.Notificar_por_correo
                        ,Texto_que_llevara_el_correo = varConfiguracion_de_Notificaciones.Texto_que_llevara_el_correo
                        ,Notificacion_push = varConfiguracion_de_Notificaciones.Notificacion_push
                        ,Texto_a_mostrar_en_la_notificacion_Push = varConfiguracion_de_Notificaciones.Texto_a_mostrar_en_la_notificacion_Push
                    
                };

                result = _IConfiguracion_de_NotificacionesApiConsumer.Update_Datos_Generales(Configuracion_de_Notificaciones_Datos_GeneralesInfo).Resource.ToString();
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
                _IConfiguracion_de_NotificacionesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IConfiguracion_de_NotificacionesApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Frecuencia_Notificaciones;
                var Detalle_Frecuencia_NotificacionesData = GetDetalle_Frecuencia_NotificacionesData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Frecuencia_Notificaciones);

                var result = new Configuracion_de_Notificaciones_Datos_GeneralesModel
                {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_Registra = m.Usuario_que_Registra
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre_de_la_Notificacion = m.Nombre_de_la_Notificacion
			,Es_permanente = m.Es_permanente
                        ,Funcionalidad = m.Funcionalidad
                        ,FuncionalidadFuncionalidad = CultureHelper.GetTraduction(m.Funcionalidad_Funcionalidades_para_Notificacion.Folio.ToString(), "Funcionalidad") ?? (string)m.Funcionalidad_Funcionalidades_para_Notificacion.Funcionalidad
                        ,Tipo_de_Notificacion = m.Tipo_de_Notificacion
                        ,Tipo_de_NotificacionDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Notificacion_Tipo_de_Notificacion.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Notificacion_Tipo_de_Notificacion.Descripcion
                        ,Tipo_de_Accion = m.Tipo_de_Accion
                        ,Tipo_de_AccionDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Accion_Tipo_de_Accion_Notificacion.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Accion_Tipo_de_Accion_Notificacion.Descripcion
                        ,Tipo_de_Recordatorio = m.Tipo_de_Recordatorio
                        ,Tipo_de_RecordatorioDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Recordatorio_Tipo_de_Recordatorio_Notificacion.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Recordatorio_Tipo_de_Recordatorio_Notificacion.Descripcion
                        ,Fecha_inicio = (m.Fecha_inicio == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio).ToString(ConfigurationProperty.DateFormat))
			,Tiene_fecha_de_finalizacion_definida = m.Tiene_fecha_de_finalizacion_definida
			,Cantidad_de_dias_a_validar = m.Cantidad_de_dias_a_validar
                        ,Fecha_a_validar = m.Fecha_a_validar
                        ,Fecha_a_validarDescripcion = CultureHelper.GetTraduction(m.Fecha_a_validar_Nombre_del_campo_en_MS.Clave.ToString(), "Descripcion") ?? (string)m.Fecha_a_validar_Nombre_del_campo_en_MS.Descripcion
                        ,Fecha_fin = (m.Fecha_fin == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin).ToString(ConfigurationProperty.DateFormat))
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion
			,Notificar_por_correo = m.Notificar_por_correo
			,Texto_que_llevara_el_correo = m.Texto_que_llevara_el_correo
			,Notificacion_push = m.Notificacion_push
			,Texto_a_mostrar_en_la_notificacion_Push = m.Texto_a_mostrar_en_la_notificacion_Push

                    
                };
				var resultData = new
                {
                    data = result
                    ,Frecuencia_Notificacion = Detalle_Frecuencia_NotificacionesData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }


    }
}

