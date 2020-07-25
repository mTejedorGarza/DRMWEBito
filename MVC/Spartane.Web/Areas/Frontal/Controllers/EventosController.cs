﻿using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Eventos;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Empresas;
using Spartane.Core.Domain.Respuesta_Logica;
using Spartane.Core.Domain.Estado;
using Spartane.Core.Domain.Pais;
using Spartane.Core.Domain.Respuesta_Logica;
using Spartane.Core.Domain.Estatus_Eventos;
using Spartane.Core.Domain.Detalle_Actividades_Evento;

using Spartane.Core.Domain.Tipos_de_Actividades;
using Spartane.Core.Domain.Especialidades;


using Spartane.Core.Domain.Spartan_User;









using Spartane.Core.Domain.Ubicaciones_Eventos_Empresa;
using Spartane.Core.Domain.Estatus_Actividades_Evento;


using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Eventos;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Eventos;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Empresas;
using Spartane.Web.Areas.WebApiConsumer.Respuesta_Logica;
using Spartane.Web.Areas.WebApiConsumer.Estado;
using Spartane.Web.Areas.WebApiConsumer.Pais;
using Spartane.Web.Areas.WebApiConsumer.Respuesta_Logica;
using Spartane.Web.Areas.WebApiConsumer.Estatus_Eventos;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Actividades_Evento;

using Spartane.Web.Areas.WebApiConsumer.Tipos_de_Actividades;
using Spartane.Web.Areas.WebApiConsumer.Especialidades;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;







using Spartane.Web.Areas.WebApiConsumer.Ubicaciones_Eventos_Empresa;
using Spartane.Web.Areas.WebApiConsumer.Estatus_Actividades_Evento;


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
    public class EventosController : Controller
    {
        #region "variable declaration"

        private IEventosService service = null;
        private IEventosApiConsumer _IEventosApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private IEmpresasApiConsumer _IEmpresasApiConsumer;
        private IRespuesta_LogicaApiConsumer _IRespuesta_LogicaApiConsumer;
        private IEstadoApiConsumer _IEstadoApiConsumer;
        private IPaisApiConsumer _IPaisApiConsumer;
        private IEstatus_EventosApiConsumer _IEstatus_EventosApiConsumer;
        private IDetalle_Actividades_EventoApiConsumer _IDetalle_Actividades_EventoApiConsumer;

        private ITipos_de_ActividadesApiConsumer _ITipos_de_ActividadesApiConsumer;
        private IEspecialidadesApiConsumer _IEspecialidadesApiConsumer;







        private IUbicaciones_Eventos_EmpresaApiConsumer _IUbicaciones_Eventos_EmpresaApiConsumer;
        private IEstatus_Actividades_EventoApiConsumer _IEstatus_Actividades_EventoApiConsumer;


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

        
        public EventosController(IEventosService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IEventosApiConsumer EventosApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer , IEmpresasApiConsumer EmpresasApiConsumer , IRespuesta_LogicaApiConsumer Respuesta_LogicaApiConsumer , IEstadoApiConsumer EstadoApiConsumer , IPaisApiConsumer PaisApiConsumer , IEstatus_EventosApiConsumer Estatus_EventosApiConsumer , IDetalle_Actividades_EventoApiConsumer Detalle_Actividades_EventoApiConsumer , ITipos_de_ActividadesApiConsumer Tipos_de_ActividadesApiConsumer , IEspecialidadesApiConsumer EspecialidadesApiConsumer , IUbicaciones_Eventos_EmpresaApiConsumer Ubicaciones_Eventos_EmpresaApiConsumer , IEstatus_Actividades_EventoApiConsumer Estatus_Actividades_EventoApiConsumer  )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IEventosApiConsumer = EventosApiConsumer;
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
            this._IEmpresasApiConsumer = EmpresasApiConsumer;
            this._IRespuesta_LogicaApiConsumer = Respuesta_LogicaApiConsumer;
            this._IEstadoApiConsumer = EstadoApiConsumer;
            this._IPaisApiConsumer = PaisApiConsumer;
            this._IRespuesta_LogicaApiConsumer = Respuesta_LogicaApiConsumer;
            this._IEstatus_EventosApiConsumer = Estatus_EventosApiConsumer;
            this._IDetalle_Actividades_EventoApiConsumer = Detalle_Actividades_EventoApiConsumer;

            this._ITipos_de_ActividadesApiConsumer = Tipos_de_ActividadesApiConsumer;
            this._IEspecialidadesApiConsumer = EspecialidadesApiConsumer;
            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;







            this._IUbicaciones_Eventos_EmpresaApiConsumer = Ubicaciones_Eventos_EmpresaApiConsumer;
            this._IEstatus_Actividades_EventoApiConsumer = Estatus_Actividades_EventoApiConsumer;


        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Eventos
        [ObjectAuth(ObjectId = (ModuleObjectId)44429, PermissionType = PermissionTypes.Consult)]
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
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44429, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			          
            return View();
        }

        // GET: Frontal/Eventos/Create
          [ObjectAuth(ObjectId = (ModuleObjectId)44429, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44429, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varEventos = new EventosModel();
			varEventos.Folio = Id;
			
            ViewBag.ObjectId = "44429";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;

            var permissionDetalle_Actividades_Evento = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44431, ModuleId);
            ViewBag.PermissionDetalle_Actividades_Evento = permissionDetalle_Actividades_Evento;


            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
				
				_tokenManager.GenerateToken();
				_ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _IEventosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var EventossData = _IEventosApiConsumer.ListaSelAll(0, 1000, "Eventos.Folio=" + Id, "").Resource.Eventoss;
				
				if (EventossData != null && EventossData.Count > 0)
                {
					var EventosData = EventossData.First();
					varEventos= new EventosModel
					{
						Folio  = EventosData.Folio 
	                    ,Fecha_de_Registro = (EventosData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(EventosData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = EventosData.Hora_de_Registro
                    ,Usuario_que_Registra = EventosData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(EventosData.Usuario_que_Registra), "Spartan_User") ??  (string)EventosData.Usuario_que_Registra_Spartan_User.Name
                    ,Empresa = EventosData.Empresa
                    ,EmpresaNombre_de_la_Empresa = CultureHelper.GetTraduction(Convert.ToString(EventosData.Empresa), "Empresas") ??  (string)EventosData.Empresa_Empresas.Nombre_de_la_Empresa
                    ,Nombre_del_Evento = EventosData.Nombre_del_Evento
                    ,Descripcion = EventosData.Descripcion
                    ,Fecha_inicio_del_Evento = (EventosData.Fecha_inicio_del_Evento == null ? string.Empty : Convert.ToDateTime(EventosData.Fecha_inicio_del_Evento).ToString(ConfigurationProperty.DateFormat))
                    ,Fecha_fin_del_Evento = (EventosData.Fecha_fin_del_Evento == null ? string.Empty : Convert.ToDateTime(EventosData.Fecha_fin_del_Evento).ToString(ConfigurationProperty.DateFormat))
                    ,Cantidad_de_dias = EventosData.Cantidad_de_dias
                    ,Evento_en_Empresa = EventosData.Evento_en_Empresa
                    ,Evento_en_EmpresaDescripcion = CultureHelper.GetTraduction(Convert.ToString(EventosData.Evento_en_Empresa), "Respuesta_Logica") ??  (string)EventosData.Evento_en_Empresa_Respuesta_Logica.Descripcion
                    ,Nombre_del_Lugar = EventosData.Nombre_del_Lugar
                    ,Calle = EventosData.Calle
                    ,Numero_exterior = EventosData.Numero_exterior
                    ,Numero_interior = EventosData.Numero_interior
                    ,Colonia = EventosData.Colonia
                    ,CP = EventosData.CP
                    ,Ciudad = EventosData.Ciudad
                    ,Estado = EventosData.Estado
                    ,EstadoNombre_del_Estado = CultureHelper.GetTraduction(Convert.ToString(EventosData.Estado), "Estado") ??  (string)EventosData.Estado_Estado.Nombre_del_Estado
                    ,Pais = EventosData.Pais
                    ,PaisNombre_del_Pais = CultureHelper.GetTraduction(Convert.ToString(EventosData.Pais), "Pais") ??  (string)EventosData.Pais_Pais.Nombre_del_Pais
                    ,Permite_Familiares = EventosData.Permite_Familiares
                    ,Permite_FamiliaresDescripcion = CultureHelper.GetTraduction(Convert.ToString(EventosData.Permite_Familiares), "Respuesta_Logica") ??  (string)EventosData.Permite_Familiares_Respuesta_Logica.Descripcion
                    ,Estatus = EventosData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(EventosData.Estatus), "Estatus_Eventos") ??  (string)EventosData.Estatus_Estatus_Eventos.Descripcion

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
            _IEmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Empresass_Empresa = _IEmpresasApiConsumer.SelAll(true);
            if (Empresass_Empresa != null && Empresass_Empresa.Resource != null)
                ViewBag.Empresass_Empresa = Empresass_Empresa.Resource.Where(m => m.Nombre_de_la_Empresa != null).OrderBy(m => m.Nombre_de_la_Empresa).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Empresas", "Nombre_de_la_Empresa") ?? m.Nombre_de_la_Empresa.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Evento_en_Empresa = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Evento_en_Empresa != null && Respuesta_Logicas_Evento_en_Empresa.Resource != null)
                ViewBag.Respuesta_Logicas_Evento_en_Empresa = Respuesta_Logicas_Evento_en_Empresa.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Estado = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Estado != null && Estados_Estado.Resource != null)
                ViewBag.Estados_Estado = Estados_Estado.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre_del_Estado") ?? m.Nombre_del_Estado.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais != null && Paiss_Pais.Resource != null)
                ViewBag.Paiss_Pais = Paiss_Pais.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Permite_Familiares = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Permite_Familiares != null && Respuesta_Logicas_Permite_Familiares.Resource != null)
                ViewBag.Respuesta_Logicas_Permite_Familiares = Respuesta_Logicas_Permite_Familiares.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatus_EventosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_Eventoss_Estatus = _IEstatus_EventosApiConsumer.SelAll(true);
            if (Estatus_Eventoss_Estatus != null && Estatus_Eventoss_Estatus.Resource != null)
                ViewBag.Estatus_Eventoss_Estatus = Estatus_Eventoss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_Eventos", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
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

				
            return View(varEventos);
        }
		
	[HttpGet]
        public ActionResult AddEventos(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44429);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IEventosApiConsumer.SetAuthHeader(_tokenManager.Token);
			EventosModel varEventos= new EventosModel();
            var permissionDetalle_Actividades_Evento = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44431, ModuleId);
            ViewBag.PermissionDetalle_Actividades_Evento = permissionDetalle_Actividades_Evento;


            if (id.ToString() != "0")
            {
                var EventossData = _IEventosApiConsumer.ListaSelAll(0, 1000, "Eventos.Folio=" + id, "").Resource.Eventoss;
				
				if (EventossData != null && EventossData.Count > 0)
                {
					var EventosData = EventossData.First();
					varEventos= new EventosModel
					{
						Folio  = EventosData.Folio 
	                    ,Fecha_de_Registro = (EventosData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(EventosData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = EventosData.Hora_de_Registro
                    ,Usuario_que_Registra = EventosData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(EventosData.Usuario_que_Registra), "Spartan_User") ??  (string)EventosData.Usuario_que_Registra_Spartan_User.Name
                    ,Empresa = EventosData.Empresa
                    ,EmpresaNombre_de_la_Empresa = CultureHelper.GetTraduction(Convert.ToString(EventosData.Empresa), "Empresas") ??  (string)EventosData.Empresa_Empresas.Nombre_de_la_Empresa
                    ,Nombre_del_Evento = EventosData.Nombre_del_Evento
                    ,Descripcion = EventosData.Descripcion
                    ,Fecha_inicio_del_Evento = (EventosData.Fecha_inicio_del_Evento == null ? string.Empty : Convert.ToDateTime(EventosData.Fecha_inicio_del_Evento).ToString(ConfigurationProperty.DateFormat))
                    ,Fecha_fin_del_Evento = (EventosData.Fecha_fin_del_Evento == null ? string.Empty : Convert.ToDateTime(EventosData.Fecha_fin_del_Evento).ToString(ConfigurationProperty.DateFormat))
                    ,Cantidad_de_dias = EventosData.Cantidad_de_dias
                    ,Evento_en_Empresa = EventosData.Evento_en_Empresa
                    ,Evento_en_EmpresaDescripcion = CultureHelper.GetTraduction(Convert.ToString(EventosData.Evento_en_Empresa), "Respuesta_Logica") ??  (string)EventosData.Evento_en_Empresa_Respuesta_Logica.Descripcion
                    ,Nombre_del_Lugar = EventosData.Nombre_del_Lugar
                    ,Calle = EventosData.Calle
                    ,Numero_exterior = EventosData.Numero_exterior
                    ,Numero_interior = EventosData.Numero_interior
                    ,Colonia = EventosData.Colonia
                    ,CP = EventosData.CP
                    ,Ciudad = EventosData.Ciudad
                    ,Estado = EventosData.Estado
                    ,EstadoNombre_del_Estado = CultureHelper.GetTraduction(Convert.ToString(EventosData.Estado), "Estado") ??  (string)EventosData.Estado_Estado.Nombre_del_Estado
                    ,Pais = EventosData.Pais
                    ,PaisNombre_del_Pais = CultureHelper.GetTraduction(Convert.ToString(EventosData.Pais), "Pais") ??  (string)EventosData.Pais_Pais.Nombre_del_Pais
                    ,Permite_Familiares = EventosData.Permite_Familiares
                    ,Permite_FamiliaresDescripcion = CultureHelper.GetTraduction(Convert.ToString(EventosData.Permite_Familiares), "Respuesta_Logica") ??  (string)EventosData.Permite_Familiares_Respuesta_Logica.Descripcion
                    ,Estatus = EventosData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(EventosData.Estatus), "Estatus_Eventos") ??  (string)EventosData.Estatus_Estatus_Eventos.Descripcion

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
            _IEmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Empresass_Empresa = _IEmpresasApiConsumer.SelAll(true);
            if (Empresass_Empresa != null && Empresass_Empresa.Resource != null)
                ViewBag.Empresass_Empresa = Empresass_Empresa.Resource.Where(m => m.Nombre_de_la_Empresa != null).OrderBy(m => m.Nombre_de_la_Empresa).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Empresas", "Nombre_de_la_Empresa") ?? m.Nombre_de_la_Empresa.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Evento_en_Empresa = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Evento_en_Empresa != null && Respuesta_Logicas_Evento_en_Empresa.Resource != null)
                ViewBag.Respuesta_Logicas_Evento_en_Empresa = Respuesta_Logicas_Evento_en_Empresa.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Estado = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Estado != null && Estados_Estado.Resource != null)
                ViewBag.Estados_Estado = Estados_Estado.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre_del_Estado") ?? m.Nombre_del_Estado.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais != null && Paiss_Pais.Resource != null)
                ViewBag.Paiss_Pais = Paiss_Pais.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Permite_Familiares = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Permite_Familiares != null && Respuesta_Logicas_Permite_Familiares.Resource != null)
                ViewBag.Respuesta_Logicas_Permite_Familiares = Respuesta_Logicas_Permite_Familiares.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatus_EventosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_Eventoss_Estatus = _IEstatus_EventosApiConsumer.SelAll(true);
            if (Estatus_Eventoss_Estatus != null && Estatus_Eventoss_Estatus.Resource != null)
                ViewBag.Estatus_Eventoss_Estatus = Estatus_Eventoss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_Eventos", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddEventos", varEventos);
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
        public ActionResult GetEmpresasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEmpresasApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Nombre_de_la_Empresa).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Empresas", "Nombre_de_la_Empresa")?? m.Nombre_de_la_Empresa,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetRespuesta_LogicaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IRespuesta_LogicaApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetEstadoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstadoApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre_del_Estado")?? m.Nombre_del_Estado,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetPaisAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPaisApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais")?? m.Nombre_del_Pais,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetEstatus_EventosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatus_EventosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstatus_EventosApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_Eventos", "Descripcion")?? m.Descripcion,
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
        public ActionResult ShowAdvanceFilter(EventosAdvanceSearchModel model, int idFilter = -1)
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
            _IEmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Empresass_Empresa = _IEmpresasApiConsumer.SelAll(true);
            if (Empresass_Empresa != null && Empresass_Empresa.Resource != null)
                ViewBag.Empresass_Empresa = Empresass_Empresa.Resource.Where(m => m.Nombre_de_la_Empresa != null).OrderBy(m => m.Nombre_de_la_Empresa).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Empresas", "Nombre_de_la_Empresa") ?? m.Nombre_de_la_Empresa.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Evento_en_Empresa = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Evento_en_Empresa != null && Respuesta_Logicas_Evento_en_Empresa.Resource != null)
                ViewBag.Respuesta_Logicas_Evento_en_Empresa = Respuesta_Logicas_Evento_en_Empresa.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Estado = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Estado != null && Estados_Estado.Resource != null)
                ViewBag.Estados_Estado = Estados_Estado.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre_del_Estado") ?? m.Nombre_del_Estado.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais != null && Paiss_Pais.Resource != null)
                ViewBag.Paiss_Pais = Paiss_Pais.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Permite_Familiares = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Permite_Familiares != null && Respuesta_Logicas_Permite_Familiares.Resource != null)
                ViewBag.Respuesta_Logicas_Permite_Familiares = Respuesta_Logicas_Permite_Familiares.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatus_EventosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_Eventoss_Estatus = _IEstatus_EventosApiConsumer.SelAll(true);
            if (Estatus_Eventoss_Estatus != null && Estatus_Eventoss_Estatus.Resource != null)
                ViewBag.Estatus_Eventoss_Estatus = Estatus_Eventoss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_Eventos", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
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
            _IEmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Empresass_Empresa = _IEmpresasApiConsumer.SelAll(true);
            if (Empresass_Empresa != null && Empresass_Empresa.Resource != null)
                ViewBag.Empresass_Empresa = Empresass_Empresa.Resource.Where(m => m.Nombre_de_la_Empresa != null).OrderBy(m => m.Nombre_de_la_Empresa).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Empresas", "Nombre_de_la_Empresa") ?? m.Nombre_de_la_Empresa.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Evento_en_Empresa = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Evento_en_Empresa != null && Respuesta_Logicas_Evento_en_Empresa.Resource != null)
                ViewBag.Respuesta_Logicas_Evento_en_Empresa = Respuesta_Logicas_Evento_en_Empresa.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Estado = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Estado != null && Estados_Estado.Resource != null)
                ViewBag.Estados_Estado = Estados_Estado.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre_del_Estado") ?? m.Nombre_del_Estado.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais != null && Paiss_Pais.Resource != null)
                ViewBag.Paiss_Pais = Paiss_Pais.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Permite_Familiares = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Permite_Familiares != null && Respuesta_Logicas_Permite_Familiares.Resource != null)
                ViewBag.Respuesta_Logicas_Permite_Familiares = Respuesta_Logicas_Permite_Familiares.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatus_EventosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_Eventoss_Estatus = _IEstatus_EventosApiConsumer.SelAll(true);
            if (Estatus_Eventoss_Estatus != null && Estatus_Eventoss_Estatus.Resource != null)
                ViewBag.Estatus_Eventoss_Estatus = Estatus_Eventoss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_Eventos", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            var previousFiltersObj = new EventosAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (EventosAdvanceSearchModel)(Session["AdvanceSearch"] ?? new EventosAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new EventosPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IEventosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Eventoss == null)
                result.Eventoss = new List<Eventos>();

            return Json(new
            {
                data = result.Eventoss.Select(m => new EventosGridModel
                    {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,EmpresaNombre_de_la_Empresa = CultureHelper.GetTraduction(m.Empresa_Empresas.Folio.ToString(), "Nombre_de_la_Empresa") ?? (string)m.Empresa_Empresas.Nombre_de_la_Empresa
			,Nombre_del_Evento = m.Nombre_del_Evento
			,Descripcion = m.Descripcion
                        ,Fecha_inicio_del_Evento = (m.Fecha_inicio_del_Evento == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio_del_Evento).ToString(ConfigurationProperty.DateFormat))
                        ,Fecha_fin_del_Evento = (m.Fecha_fin_del_Evento == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin_del_Evento).ToString(ConfigurationProperty.DateFormat))
			,Cantidad_de_dias = m.Cantidad_de_dias
                        ,Evento_en_EmpresaDescripcion = CultureHelper.GetTraduction(m.Evento_en_Empresa_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Evento_en_Empresa_Respuesta_Logica.Descripcion
			,Nombre_del_Lugar = m.Nombre_del_Lugar
			,Calle = m.Calle
			,Numero_exterior = m.Numero_exterior
			,Numero_interior = m.Numero_interior
			,Colonia = m.Colonia
			,CP = m.CP
			,Ciudad = m.Ciudad
                        ,EstadoNombre_del_Estado = CultureHelper.GetTraduction(m.Estado_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Estado_Estado.Nombre_del_Estado
                        ,PaisNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_Pais.Nombre_del_Pais
                        ,Permite_FamiliaresDescripcion = CultureHelper.GetTraduction(m.Permite_Familiares_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Permite_Familiares_Respuesta_Logica.Descripcion
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_Eventos.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus_Eventos.Descripcion

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }
		/*
		 [HttpGet]
        public ActionResult GetEventosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEventosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEventosApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraductionNew(Convert.ToString(m.Folio), "Eventos", m.),
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
        /// Get List of Eventos from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Eventos Entity</returns>
        public ActionResult GetEventosList(UrlParametersModel param)
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
            _IEventosApiConsumer.SetAuthHeader(_tokenManager.Token);

          
            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new EventosPropertyMapper());
				
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
				if (Session["AdvanceSearch"].GetType() == typeof(EventosAdvanceSearchModel))
                {
					var advanceFilter =
                    (EventosAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            EventosPropertyMapper oEventosPropertyMapper = new EventosPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                 if (sortColumn != -1)
                    configuration.OrderByClause = oEventosPropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _IEventosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Eventoss == null)
                result.Eventoss = new List<Eventos>();

            return Json(new
            {
                aaData = result.Eventoss.Select(m => new EventosGridModel
            {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,EmpresaNombre_de_la_Empresa = CultureHelper.GetTraduction(m.Empresa_Empresas.Folio.ToString(), "Nombre_de_la_Empresa") ?? (string)m.Empresa_Empresas.Nombre_de_la_Empresa
			,Nombre_del_Evento = m.Nombre_del_Evento
			,Descripcion = m.Descripcion
                        ,Fecha_inicio_del_Evento = (m.Fecha_inicio_del_Evento == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio_del_Evento).ToString(ConfigurationProperty.DateFormat))
                        ,Fecha_fin_del_Evento = (m.Fecha_fin_del_Evento == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin_del_Evento).ToString(ConfigurationProperty.DateFormat))
			,Cantidad_de_dias = m.Cantidad_de_dias
                        ,Evento_en_EmpresaDescripcion = CultureHelper.GetTraduction(m.Evento_en_Empresa_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Evento_en_Empresa_Respuesta_Logica.Descripcion
			,Nombre_del_Lugar = m.Nombre_del_Lugar
			,Calle = m.Calle
			,Numero_exterior = m.Numero_exterior
			,Numero_interior = m.Numero_interior
			,Colonia = m.Colonia
			,CP = m.CP
			,Ciudad = m.Ciudad
                        ,EstadoNombre_del_Estado = CultureHelper.GetTraduction(m.Estado_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Estado_Estado.Nombre_del_Estado
                        ,PaisNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_Pais.Nombre_del_Pais
                        ,Permite_FamiliaresDescripcion = CultureHelper.GetTraduction(m.Permite_Familiares_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Permite_Familiares_Respuesta_Logica.Descripcion
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_Eventos.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus_Eventos.Descripcion

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }


//Grid GetAutoComplete






        [NonAction]
        public string GetAdvanceFilter(EventosAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromFolio) || !string.IsNullOrEmpty(filter.ToFolio))
            {
                if (!string.IsNullOrEmpty(filter.FromFolio))
                    where += " AND Eventos.Folio >= " + filter.FromFolio;
                if (!string.IsNullOrEmpty(filter.ToFolio))
                    where += " AND Eventos.Folio <= " + filter.ToFolio;
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro) || !string.IsNullOrEmpty(filter.ToFecha_de_Registro))
            {
                var Fecha_de_RegistroFrom = DateTime.ParseExact(filter.FromFecha_de_Registro, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_de_RegistroTo = DateTime.ParseExact(filter.ToFecha_de_Registro, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro))
                    where += " AND Eventos.Fecha_de_Registro >= '" + Fecha_de_RegistroFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_Registro))
                    where += " AND Eventos.Fecha_de_Registro <= '" + Fecha_de_RegistroTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromHora_de_Registro) || !string.IsNullOrEmpty(filter.ToHora_de_Registro))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_de_Registro))
                    where += " AND Convert(TIME,Eventos.Hora_de_Registro) >='" + filter.FromHora_de_Registro + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_de_Registro))
                    where += " AND Convert(TIME,Eventos.Hora_de_Registro) <='" + filter.ToHora_de_Registro + "'";
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

                where += " AND Eventos.Usuario_que_Registra In (" + Usuario_que_RegistraIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceEmpresa))
            {
                switch (filter.EmpresaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Empresas.Nombre_de_la_Empresa LIKE '" + filter.AdvanceEmpresa + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Empresas.Nombre_de_la_Empresa LIKE '%" + filter.AdvanceEmpresa + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Empresas.Nombre_de_la_Empresa = '" + filter.AdvanceEmpresa + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Empresas.Nombre_de_la_Empresa LIKE '%" + filter.AdvanceEmpresa + "%'";
                        break;
                }
            }
            else if (filter.AdvanceEmpresaMultiple != null && filter.AdvanceEmpresaMultiple.Count() > 0)
            {
                var EmpresaIds = string.Join(",", filter.AdvanceEmpresaMultiple);

                where += " AND Eventos.Empresa In (" + EmpresaIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Nombre_del_Evento))
            {
                switch (filter.Nombre_del_EventoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Eventos.Nombre_del_Evento LIKE '" + filter.Nombre_del_Evento + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Eventos.Nombre_del_Evento LIKE '%" + filter.Nombre_del_Evento + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Eventos.Nombre_del_Evento = '" + filter.Nombre_del_Evento + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Eventos.Nombre_del_Evento LIKE '%" + filter.Nombre_del_Evento + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Descripcion))
            {
                switch (filter.DescripcionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Eventos.Descripcion LIKE '" + filter.Descripcion + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Eventos.Descripcion LIKE '%" + filter.Descripcion + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Eventos.Descripcion = '" + filter.Descripcion + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Eventos.Descripcion LIKE '%" + filter.Descripcion + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_inicio_del_Evento) || !string.IsNullOrEmpty(filter.ToFecha_inicio_del_Evento))
            {
                var Fecha_inicio_del_EventoFrom = DateTime.ParseExact(filter.FromFecha_inicio_del_Evento, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_inicio_del_EventoTo = DateTime.ParseExact(filter.ToFecha_inicio_del_Evento, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_inicio_del_Evento))
                    where += " AND Eventos.Fecha_inicio_del_Evento >= '" + Fecha_inicio_del_EventoFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_inicio_del_Evento))
                    where += " AND Eventos.Fecha_inicio_del_Evento <= '" + Fecha_inicio_del_EventoTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_fin_del_Evento) || !string.IsNullOrEmpty(filter.ToFecha_fin_del_Evento))
            {
                var Fecha_fin_del_EventoFrom = DateTime.ParseExact(filter.FromFecha_fin_del_Evento, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_fin_del_EventoTo = DateTime.ParseExact(filter.ToFecha_fin_del_Evento, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_fin_del_Evento))
                    where += " AND Eventos.Fecha_fin_del_Evento >= '" + Fecha_fin_del_EventoFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_fin_del_Evento))
                    where += " AND Eventos.Fecha_fin_del_Evento <= '" + Fecha_fin_del_EventoTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromCantidad_de_dias) || !string.IsNullOrEmpty(filter.ToCantidad_de_dias))
            {
                if (!string.IsNullOrEmpty(filter.FromCantidad_de_dias))
                    where += " AND Eventos.Cantidad_de_dias >= " + filter.FromCantidad_de_dias;
                if (!string.IsNullOrEmpty(filter.ToCantidad_de_dias))
                    where += " AND Eventos.Cantidad_de_dias <= " + filter.ToCantidad_de_dias;
            }

            if (!string.IsNullOrEmpty(filter.AdvanceEvento_en_Empresa))
            {
                switch (filter.Evento_en_EmpresaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Respuesta_Logica.Descripcion LIKE '" + filter.AdvanceEvento_en_Empresa + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Respuesta_Logica.Descripcion LIKE '%" + filter.AdvanceEvento_en_Empresa + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Respuesta_Logica.Descripcion = '" + filter.AdvanceEvento_en_Empresa + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Respuesta_Logica.Descripcion LIKE '%" + filter.AdvanceEvento_en_Empresa + "%'";
                        break;
                }
            }
            else if (filter.AdvanceEvento_en_EmpresaMultiple != null && filter.AdvanceEvento_en_EmpresaMultiple.Count() > 0)
            {
                var Evento_en_EmpresaIds = string.Join(",", filter.AdvanceEvento_en_EmpresaMultiple);

                where += " AND Eventos.Evento_en_Empresa In (" + Evento_en_EmpresaIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Nombre_del_Lugar))
            {
                switch (filter.Nombre_del_LugarFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Eventos.Nombre_del_Lugar LIKE '" + filter.Nombre_del_Lugar + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Eventos.Nombre_del_Lugar LIKE '%" + filter.Nombre_del_Lugar + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Eventos.Nombre_del_Lugar = '" + filter.Nombre_del_Lugar + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Eventos.Nombre_del_Lugar LIKE '%" + filter.Nombre_del_Lugar + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Calle))
            {
                switch (filter.CalleFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Eventos.Calle LIKE '" + filter.Calle + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Eventos.Calle LIKE '%" + filter.Calle + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Eventos.Calle = '" + filter.Calle + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Eventos.Calle LIKE '%" + filter.Calle + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Numero_exterior))
            {
                switch (filter.Numero_exteriorFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Eventos.Numero_exterior LIKE '" + filter.Numero_exterior + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Eventos.Numero_exterior LIKE '%" + filter.Numero_exterior + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Eventos.Numero_exterior = '" + filter.Numero_exterior + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Eventos.Numero_exterior LIKE '%" + filter.Numero_exterior + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Numero_interior))
            {
                switch (filter.Numero_interiorFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Eventos.Numero_interior LIKE '" + filter.Numero_interior + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Eventos.Numero_interior LIKE '%" + filter.Numero_interior + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Eventos.Numero_interior = '" + filter.Numero_interior + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Eventos.Numero_interior LIKE '%" + filter.Numero_interior + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Colonia))
            {
                switch (filter.ColoniaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Eventos.Colonia LIKE '" + filter.Colonia + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Eventos.Colonia LIKE '%" + filter.Colonia + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Eventos.Colonia = '" + filter.Colonia + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Eventos.Colonia LIKE '%" + filter.Colonia + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.CP))
            {
                switch (filter.CPFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Eventos.CP LIKE '" + filter.CP + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Eventos.CP LIKE '%" + filter.CP + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Eventos.CP = '" + filter.CP + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Eventos.CP LIKE '%" + filter.CP + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Ciudad))
            {
                switch (filter.CiudadFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Eventos.Ciudad LIKE '" + filter.Ciudad + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Eventos.Ciudad LIKE '%" + filter.Ciudad + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Eventos.Ciudad = '" + filter.Ciudad + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Eventos.Ciudad LIKE '%" + filter.Ciudad + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceEstado))
            {
                switch (filter.EstadoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Estado.Nombre_del_Estado LIKE '" + filter.AdvanceEstado + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Estado.Nombre_del_Estado LIKE '%" + filter.AdvanceEstado + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Estado.Nombre_del_Estado = '" + filter.AdvanceEstado + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Estado.Nombre_del_Estado LIKE '%" + filter.AdvanceEstado + "%'";
                        break;
                }
            }
            else if (filter.AdvanceEstadoMultiple != null && filter.AdvanceEstadoMultiple.Count() > 0)
            {
                var EstadoIds = string.Join(",", filter.AdvanceEstadoMultiple);

                where += " AND Eventos.Estado In (" + EstadoIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvancePais))
            {
                switch (filter.PaisFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Pais.Nombre_del_Pais LIKE '" + filter.AdvancePais + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Pais.Nombre_del_Pais LIKE '%" + filter.AdvancePais + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Pais.Nombre_del_Pais = '" + filter.AdvancePais + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Pais.Nombre_del_Pais LIKE '%" + filter.AdvancePais + "%'";
                        break;
                }
            }
            else if (filter.AdvancePaisMultiple != null && filter.AdvancePaisMultiple.Count() > 0)
            {
                var PaisIds = string.Join(",", filter.AdvancePaisMultiple);

                where += " AND Eventos.Pais In (" + PaisIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvancePermite_Familiares))
            {
                switch (filter.Permite_FamiliaresFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Respuesta_Logica.Descripcion LIKE '" + filter.AdvancePermite_Familiares + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Respuesta_Logica.Descripcion LIKE '%" + filter.AdvancePermite_Familiares + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Respuesta_Logica.Descripcion = '" + filter.AdvancePermite_Familiares + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Respuesta_Logica.Descripcion LIKE '%" + filter.AdvancePermite_Familiares + "%'";
                        break;
                }
            }
            else if (filter.AdvancePermite_FamiliaresMultiple != null && filter.AdvancePermite_FamiliaresMultiple.Count() > 0)
            {
                var Permite_FamiliaresIds = string.Join(",", filter.AdvancePermite_FamiliaresMultiple);

                where += " AND Eventos.Permite_Familiares In (" + Permite_FamiliaresIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceEstatus))
            {
                switch (filter.EstatusFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Estatus_Eventos.Descripcion LIKE '" + filter.AdvanceEstatus + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Estatus_Eventos.Descripcion LIKE '%" + filter.AdvanceEstatus + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Estatus_Eventos.Descripcion = '" + filter.AdvanceEstatus + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Estatus_Eventos.Descripcion LIKE '%" + filter.AdvanceEstatus + "%'";
                        break;
                }
            }
            else if (filter.AdvanceEstatusMultiple != null && filter.AdvanceEstatusMultiple.Count() > 0)
            {
                var EstatusIds = string.Join(",", filter.AdvanceEstatusMultiple);

                where += " AND Eventos.Estatus In (" + EstatusIds + ")";
            }


            where = new Regex(Regex.Escape("AND ")).Replace(where, "", 1);
            return where;
        }

        [NonAction]
        public Grid_File ConvertSpartane_FileToGridFile(Spartane.Core.Domain.Spartane_File.Spartane_File file)
        {
            return file == null ? new Grid_File { FileId = 0, FileSize = 0, FileName = "" } : new Grid_File { FileId = file.File_Id, FileName = file.Description, FileSize = file.File_Size ?? 0, };
        }

        public ActionResult GetDetalle_Actividades_Evento(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_Actividades_EventoGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Actividades_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Actividades_Evento.Folio_Eventos=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Actividades_Evento.Folio_Eventos='" + RelationId + "'";
            }
            var result = _IDetalle_Actividades_EventoApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Actividades_Eventos == null)
                result.Detalle_Actividades_Eventos = new List<Detalle_Actividades_Evento>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Actividades_Eventos.Select(m => new Detalle_Actividades_EventoGridModel
                {
                    Folio = m.Folio

                        ,Tipo_de_Actividad = m.Tipo_de_Actividad
                        ,Tipo_de_ActividadDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Actividad_Tipos_de_Actividades.Folio.ToString(), "Descripcion") ??(string)m.Tipo_de_Actividad_Tipos_de_Actividades.Descripcion
                        ,Especialidad = m.Especialidad
                        ,EspecialidadEspecialidad = CultureHelper.GetTraduction(m.Especialidad_Especialidades.Clave.ToString(), "Especialidad") ??(string)m.Especialidad_Especialidades.Especialidad
			,Nombre_de_la_Actividad = m.Nombre_de_la_Actividad
			,Descripcion = m.Descripcion
                        ,Quien_imparte = m.Quien_imparte
                        ,Quien_imparteName = CultureHelper.GetTraduction(m.Quien_imparte_Spartan_User.Id_User.ToString(), "Name") ??(string)m.Quien_imparte_Spartan_User.Name
			,Dia = (m.Dia == null ? string.Empty : Convert.ToDateTime(m.Dia).ToString(ConfigurationProperty.DateFormat))
			,Hora_inicio = m.Hora_inicio
			,Hora_fin = m.Hora_fin
			,Tiene_receso = m.Tiene_receso
			,Hora_inicio_receso = m.Hora_inicio_receso
			,Hora_fin_receso = m.Hora_fin_receso
			,Duracion_maxima_por_paciente_mins = m.Duracion_maxima_por_paciente_mins
			,Cupo_limitado = m.Cupo_limitado
			,Cupo_maximo = m.Cupo_maximo
                        ,Ubicacion = m.Ubicacion
                        ,UbicacionNombre = CultureHelper.GetTraduction(m.Ubicacion_Ubicaciones_Eventos_Empresa.Folio.ToString(), "Nombre") ??(string)m.Ubicacion_Ubicaciones_Eventos_Empresa.Nombre
                        ,Estatus_de_la_Actividad = m.Estatus_de_la_Actividad
                        ,Estatus_de_la_ActividadDescripcion = CultureHelper.GetTraduction(m.Estatus_de_la_Actividad_Estatus_Actividades_Evento.Folio.ToString(), "Descripcion") ??(string)m.Estatus_de_la_Actividad_Estatus_Actividades_Evento.Descripcion

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_Actividades_EventoGridModel> GetDetalle_Actividades_EventoData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_Actividades_EventoGridModel> resultData = new List<Detalle_Actividades_EventoGridModel>();
            string where = "Detalle_Actividades_Evento.Folio_Eventos=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Actividades_Evento.Folio_Eventos='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Actividades_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_Actividades_EventoApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Actividades_Eventos != null)
            {
                resultData = result.Detalle_Actividades_Eventos.Select(m => new Detalle_Actividades_EventoGridModel
                    {
                        Folio = m.Folio

                        ,Tipo_de_Actividad = m.Tipo_de_Actividad
                        ,Tipo_de_ActividadDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Actividad_Tipos_de_Actividades.Folio.ToString(), "Descripcion") ??(string)m.Tipo_de_Actividad_Tipos_de_Actividades.Descripcion
                        ,Especialidad = m.Especialidad
                        ,EspecialidadEspecialidad = CultureHelper.GetTraduction(m.Especialidad_Especialidades.Clave.ToString(), "Especialidad") ??(string)m.Especialidad_Especialidades.Especialidad
			,Nombre_de_la_Actividad = m.Nombre_de_la_Actividad
			,Descripcion = m.Descripcion
                        ,Quien_imparte = m.Quien_imparte
                        ,Quien_imparteName = CultureHelper.GetTraduction(m.Quien_imparte_Spartan_User.Id_User.ToString(), "Name") ??(string)m.Quien_imparte_Spartan_User.Name
			,Dia = (m.Dia == null ? string.Empty : Convert.ToDateTime(m.Dia).ToString(ConfigurationProperty.DateFormat))
			,Hora_inicio = m.Hora_inicio
			,Hora_fin = m.Hora_fin
			,Tiene_receso = m.Tiene_receso
			,Hora_inicio_receso = m.Hora_inicio_receso
			,Hora_fin_receso = m.Hora_fin_receso
			,Duracion_maxima_por_paciente_mins = m.Duracion_maxima_por_paciente_mins
			,Cupo_limitado = m.Cupo_limitado
			,Cupo_maximo = m.Cupo_maximo
                        ,Ubicacion = m.Ubicacion
                        ,UbicacionNombre = CultureHelper.GetTraduction(m.Ubicacion_Ubicaciones_Eventos_Empresa.Folio.ToString(), "Nombre") ??(string)m.Ubicacion_Ubicaciones_Eventos_Empresa.Nombre
                        ,Estatus_de_la_Actividad = m.Estatus_de_la_Actividad
                        ,Estatus_de_la_ActividadDescripcion = CultureHelper.GetTraduction(m.Estatus_de_la_Actividad_Estatus_Actividades_Evento.Folio.ToString(), "Descripcion") ??(string)m.Estatus_de_la_Actividad_Estatus_Actividades_Evento.Descripcion


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
                _IEventosApiConsumer.SetAuthHeader(_tokenManager.Token);

                Eventos varEventos = null;
                if (id.ToString() != "0")
                {
                        string where = "";
                    _IDetalle_Actividades_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Actividades_Evento.Folio_Eventos=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Actividades_Evento.Folio_Eventos='" + id + "'";
                    }
                    var Detalle_Actividades_EventoInfo =
                        _IDetalle_Actividades_EventoApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_Actividades_EventoInfo.Detalle_Actividades_Eventos.Count > 0)
                    {
                        var resultDetalle_Actividades_Evento = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_Actividades_EventoItem in Detalle_Actividades_EventoInfo.Detalle_Actividades_Eventos)
                            resultDetalle_Actividades_Evento = resultDetalle_Actividades_Evento
                                              && _IDetalle_Actividades_EventoApiConsumer.Delete(Detalle_Actividades_EventoItem.Folio, null,null).Resource;

                        if (!resultDetalle_Actividades_Evento)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                var result = _IEventosApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, EventosModel varEventos)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IEventosApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var EventosInfo = new Eventos
                    {
                        Folio = varEventos.Folio
                        ,Fecha_de_Registro = (!String.IsNullOrEmpty(varEventos.Fecha_de_Registro)) ? DateTime.ParseExact(varEventos.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varEventos.Hora_de_Registro
                        ,Usuario_que_Registra = varEventos.Usuario_que_Registra
                        ,Empresa = varEventos.Empresa
                        ,Nombre_del_Evento = varEventos.Nombre_del_Evento
                        ,Descripcion = varEventos.Descripcion
                        ,Fecha_inicio_del_Evento = (!String.IsNullOrEmpty(varEventos.Fecha_inicio_del_Evento)) ? DateTime.ParseExact(varEventos.Fecha_inicio_del_Evento, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Fecha_fin_del_Evento = (!String.IsNullOrEmpty(varEventos.Fecha_fin_del_Evento)) ? DateTime.ParseExact(varEventos.Fecha_fin_del_Evento, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Cantidad_de_dias = varEventos.Cantidad_de_dias
                        ,Evento_en_Empresa = varEventos.Evento_en_Empresa
                        ,Nombre_del_Lugar = varEventos.Nombre_del_Lugar
                        ,Calle = varEventos.Calle
                        ,Numero_exterior = varEventos.Numero_exterior
                        ,Numero_interior = varEventos.Numero_interior
                        ,Colonia = varEventos.Colonia
                        ,CP = varEventos.CP
                        ,Ciudad = varEventos.Ciudad
                        ,Estado = varEventos.Estado
                        ,Pais = varEventos.Pais
                        ,Permite_Familiares = varEventos.Permite_Familiares
                        ,Estatus = varEventos.Estatus

                    };

                    result = !IsNew ?
                        _IEventosApiConsumer.Update(EventosInfo, null, null).Resource.ToString() :
                         _IEventosApiConsumer.Insert(EventosInfo, null, null).Resource.ToString();
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
        public bool CopyDetalle_Actividades_Evento(int MasterId, int referenceId, List<Detalle_Actividades_EventoGridModelPost> Detalle_Actividades_EventoItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_Actividades_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_Actividades_EventoData = _IDetalle_Actividades_EventoApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Actividades_Evento.Folio_Eventos=" + referenceId,"").Resource;
                if (Detalle_Actividades_EventoData == null || Detalle_Actividades_EventoData.Detalle_Actividades_Eventos.Count == 0)
                    return true;

                var result = true;

                Detalle_Actividades_EventoGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Actividades_Evento in Detalle_Actividades_EventoData.Detalle_Actividades_Eventos)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Actividades_Evento Detalle_Actividades_Evento1 = varDetalle_Actividades_Evento;

                    if (Detalle_Actividades_EventoItems != null && Detalle_Actividades_EventoItems.Any(m => m.Folio == Detalle_Actividades_Evento1.Folio))
                    {
                        modelDataToChange = Detalle_Actividades_EventoItems.FirstOrDefault(m => m.Folio == Detalle_Actividades_Evento1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Actividades_Evento.Folio_Eventos = MasterId;
                    var insertId = _IDetalle_Actividades_EventoApiConsumer.Insert(varDetalle_Actividades_Evento,null,null).Resource;
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
        public ActionResult PostDetalle_Actividades_Evento(List<Detalle_Actividades_EventoGridModelPost> Detalle_Actividades_EventoItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Actividades_Evento(MasterId, referenceId, Detalle_Actividades_EventoItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_Actividades_EventoItems != null && Detalle_Actividades_EventoItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_Actividades_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_Actividades_EventoItem in Detalle_Actividades_EventoItems)
                    {


















                        //Removal Request
                        if (Detalle_Actividades_EventoItem.Removed)
                        {
                            result = result && _IDetalle_Actividades_EventoApiConsumer.Delete(Detalle_Actividades_EventoItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_Actividades_EventoItem.Folio = 0;

                        var Detalle_Actividades_EventoData = new Detalle_Actividades_Evento
                        {
                            Folio_Eventos = MasterId
                            ,Folio = Detalle_Actividades_EventoItem.Folio
                            ,Tipo_de_Actividad = (Convert.ToInt32(Detalle_Actividades_EventoItem.Tipo_de_Actividad) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Actividades_EventoItem.Tipo_de_Actividad))
                            ,Especialidad = (Convert.ToInt32(Detalle_Actividades_EventoItem.Especialidad) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Actividades_EventoItem.Especialidad))
                            ,Nombre_de_la_Actividad = Detalle_Actividades_EventoItem.Nombre_de_la_Actividad
                            ,Descripcion = Detalle_Actividades_EventoItem.Descripcion
                            ,Quien_imparte = (Convert.ToInt32(Detalle_Actividades_EventoItem.Quien_imparte) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Actividades_EventoItem.Quien_imparte))
                            ,Dia = (Detalle_Actividades_EventoItem.Dia!= null) ? DateTime.ParseExact(Detalle_Actividades_EventoItem.Dia, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                            ,Hora_inicio = Detalle_Actividades_EventoItem.Hora_inicio
                            ,Hora_fin = Detalle_Actividades_EventoItem.Hora_fin
                            ,Tiene_receso = Detalle_Actividades_EventoItem.Tiene_receso
                            ,Hora_inicio_receso = Detalle_Actividades_EventoItem.Hora_inicio_receso
                            ,Hora_fin_receso = Detalle_Actividades_EventoItem.Hora_fin_receso
                            ,Duracion_maxima_por_paciente_mins = Detalle_Actividades_EventoItem.Duracion_maxima_por_paciente_mins
                            ,Cupo_limitado = Detalle_Actividades_EventoItem.Cupo_limitado
                            ,Cupo_maximo = Detalle_Actividades_EventoItem.Cupo_maximo
                            ,Ubicacion = (Convert.ToInt32(Detalle_Actividades_EventoItem.Ubicacion) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Actividades_EventoItem.Ubicacion))
                            ,Estatus_de_la_Actividad = (Convert.ToInt32(Detalle_Actividades_EventoItem.Estatus_de_la_Actividad) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Actividades_EventoItem.Estatus_de_la_Actividad))

                        };

                        var resultId = Detalle_Actividades_EventoItem.Folio > 0
                           ? _IDetalle_Actividades_EventoApiConsumer.Update(Detalle_Actividades_EventoData,null,null).Resource
                           : _IDetalle_Actividades_EventoApiConsumer.Insert(Detalle_Actividades_EventoData,null,null).Resource;

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
        public ActionResult GetDetalle_Actividades_Evento_Tipos_de_ActividadesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipos_de_ActividadesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipos_de_ActividadesApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Folio), "Tipos_de_Actividades", "Descripcion");
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
        public ActionResult GetDetalle_Actividades_Evento_EspecialidadesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEspecialidadesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEspecialidadesApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Especialidades", "Especialidad");
                  item.Especialidad= trans??item.Especialidad;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public ActionResult GetDetalle_Actividades_Evento_Spartan_UserAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_UserApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Id_User), "Spartan_User", "Name");
                  item.Name= trans??item.Name;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }









        [HttpGet]
        public ActionResult GetDetalle_Actividades_Evento_Ubicaciones_Eventos_EmpresaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IUbicaciones_Eventos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IUbicaciones_Eventos_EmpresaApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Folio), "Ubicaciones_Eventos_Empresa", "Nombre");
                  item.Nombre= trans??item.Nombre;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetDetalle_Actividades_Evento_Estatus_Actividades_EventoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatus_Actividades_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstatus_Actividades_EventoApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Folio), "Estatus_Actividades_Evento", "Descripcion");
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
        /// Write Element Array of Eventos script
        /// </summary>
        /// <param name="oEventosElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew EventosModuleAttributeList)
        {
            for (int i = 0; i < EventosModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(EventosModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    EventosModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(EventosModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    EventosModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (EventosModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < EventosModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < EventosModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(EventosModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							EventosModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(EventosModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							EventosModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strEventosScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Eventos.js")))
            {
                strEventosScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Eventos element attributes
            string userChangeJson = jsSerialize.Serialize(EventosModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strEventosScript.IndexOf("inpuElementArray");
            string splittedString = strEventosScript.Substring(indexOfArray, strEventosScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(EventosModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (EventosModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strEventosScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strEventosScript.Substring(indexOfArrayHistory, strEventosScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strEventosScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strEventosScript.Substring(endIndexOfMainElement + indexOfArray, strEventosScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (EventosModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in EventosModuleAttributeList.ChildModuleAttributeList)
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
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Eventos.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Eventos.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Eventos.js")))
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
        public ActionResult EventosPropertyBag()
        {
            return PartialView("EventosPropertyBag", "Eventos");
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
        public ActionResult AddDetalle_Actividades_Evento(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Actividades_Evento/AddDetalle_Actividades_Evento");
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
                var whereClauseFormat = "Object = 44429 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _IEventosApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Eventos.Folio= " + RecordId;
                            var result = _IEventosApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
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

            _IEventosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new EventosPropertyMapper());
			
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
                    (EventosAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
			string sortDirection = "asc";

            EventosPropertyMapper oEventosPropertyMapper = new EventosPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oEventosPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IEventosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Eventoss == null)
                result.Eventoss = new List<Eventos>();

            var data = result.Eventoss.Select(m => new EventosGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,EmpresaNombre_de_la_Empresa = CultureHelper.GetTraduction(m.Empresa_Empresas.Folio.ToString(), "Nombre_de_la_Empresa") ?? (string)m.Empresa_Empresas.Nombre_de_la_Empresa
			,Nombre_del_Evento = m.Nombre_del_Evento
			,Descripcion = m.Descripcion
                        ,Fecha_inicio_del_Evento = (m.Fecha_inicio_del_Evento == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio_del_Evento).ToString(ConfigurationProperty.DateFormat))
                        ,Fecha_fin_del_Evento = (m.Fecha_fin_del_Evento == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin_del_Evento).ToString(ConfigurationProperty.DateFormat))
			,Cantidad_de_dias = m.Cantidad_de_dias
                        ,Evento_en_EmpresaDescripcion = CultureHelper.GetTraduction(m.Evento_en_Empresa_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Evento_en_Empresa_Respuesta_Logica.Descripcion
			,Nombre_del_Lugar = m.Nombre_del_Lugar
			,Calle = m.Calle
			,Numero_exterior = m.Numero_exterior
			,Numero_interior = m.Numero_interior
			,Colonia = m.Colonia
			,CP = m.CP
			,Ciudad = m.Ciudad
                        ,EstadoNombre_del_Estado = CultureHelper.GetTraduction(m.Estado_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Estado_Estado.Nombre_del_Estado
                        ,PaisNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_Pais.Nombre_del_Pais
                        ,Permite_FamiliaresDescripcion = CultureHelper.GetTraduction(m.Permite_Familiares_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Permite_Familiares_Respuesta_Logica.Descripcion
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_Eventos.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus_Eventos.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(44429, arrayColumnsVisible), "EventosList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(44429, arrayColumnsVisible), "EventosList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(44429, arrayColumnsVisible), "EventosList_" + DateTime.Now.ToString());
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

            _IEventosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new EventosPropertyMapper());
				
				
            if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
			if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (EventosAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            EventosPropertyMapper oEventosPropertyMapper = new EventosPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oEventosPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
			
			if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IEventosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Eventoss == null)
                result.Eventoss = new List<Eventos>();

            var data = result.Eventoss.Select(m => new EventosGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,EmpresaNombre_de_la_Empresa = CultureHelper.GetTraduction(m.Empresa_Empresas.Folio.ToString(), "Nombre_de_la_Empresa") ?? (string)m.Empresa_Empresas.Nombre_de_la_Empresa
			,Nombre_del_Evento = m.Nombre_del_Evento
			,Descripcion = m.Descripcion
                        ,Fecha_inicio_del_Evento = (m.Fecha_inicio_del_Evento == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio_del_Evento).ToString(ConfigurationProperty.DateFormat))
                        ,Fecha_fin_del_Evento = (m.Fecha_fin_del_Evento == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin_del_Evento).ToString(ConfigurationProperty.DateFormat))
			,Cantidad_de_dias = m.Cantidad_de_dias
                        ,Evento_en_EmpresaDescripcion = CultureHelper.GetTraduction(m.Evento_en_Empresa_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Evento_en_Empresa_Respuesta_Logica.Descripcion
			,Nombre_del_Lugar = m.Nombre_del_Lugar
			,Calle = m.Calle
			,Numero_exterior = m.Numero_exterior
			,Numero_interior = m.Numero_interior
			,Colonia = m.Colonia
			,CP = m.CP
			,Ciudad = m.Ciudad
                        ,EstadoNombre_del_Estado = CultureHelper.GetTraduction(m.Estado_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Estado_Estado.Nombre_del_Estado
                        ,PaisNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_Pais.Nombre_del_Pais
                        ,Permite_FamiliaresDescripcion = CultureHelper.GetTraduction(m.Permite_Familiares_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Permite_Familiares_Respuesta_Logica.Descripcion
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_Eventos.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus_Eventos.Descripcion

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
                _IEventosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEventosApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpPost]
        public ActionResult Post_Datos_Generales(Eventos_Datos_GeneralesModel varEventos)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEventosApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Eventos_Datos_GeneralesInfo = new Eventos_Datos_Generales
                {
                    Folio = varEventos.Folio
                                            ,Fecha_de_Registro = (!String.IsNullOrEmpty(varEventos.Fecha_de_Registro)) ? DateTime.ParseExact(varEventos.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varEventos.Hora_de_Registro
                        ,Usuario_que_Registra = varEventos.Usuario_que_Registra
                        ,Empresa = varEventos.Empresa
                        ,Nombre_del_Evento = varEventos.Nombre_del_Evento
                        ,Descripcion = varEventos.Descripcion
                        ,Fecha_inicio_del_Evento = (!String.IsNullOrEmpty(varEventos.Fecha_inicio_del_Evento)) ? DateTime.ParseExact(varEventos.Fecha_inicio_del_Evento, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Fecha_fin_del_Evento = (!String.IsNullOrEmpty(varEventos.Fecha_fin_del_Evento)) ? DateTime.ParseExact(varEventos.Fecha_fin_del_Evento, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Cantidad_de_dias = varEventos.Cantidad_de_dias
                        ,Evento_en_Empresa = varEventos.Evento_en_Empresa
                        ,Nombre_del_Lugar = varEventos.Nombre_del_Lugar
                        ,Calle = varEventos.Calle
                        ,Numero_exterior = varEventos.Numero_exterior
                        ,Numero_interior = varEventos.Numero_interior
                        ,Colonia = varEventos.Colonia
                        ,CP = varEventos.CP
                        ,Ciudad = varEventos.Ciudad
                        ,Estado = varEventos.Estado
                        ,Pais = varEventos.Pais
                        ,Permite_Familiares = varEventos.Permite_Familiares
                        ,Estatus = varEventos.Estatus
                    
                };

                result = _IEventosApiConsumer.Update_Datos_Generales(Eventos_Datos_GeneralesInfo).Resource.ToString();
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
                _IEventosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IEventosApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Actividades_Evento;
                var Detalle_Actividades_EventoData = GetDetalle_Actividades_EventoData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Actividades_Evento);

                var result = new Eventos_Datos_GeneralesModel
                {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_Registra = m.Usuario_que_Registra
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,Empresa = m.Empresa
                        ,EmpresaNombre_de_la_Empresa = CultureHelper.GetTraduction(m.Empresa_Empresas.Folio.ToString(), "Nombre_de_la_Empresa") ?? (string)m.Empresa_Empresas.Nombre_de_la_Empresa
			,Nombre_del_Evento = m.Nombre_del_Evento
			,Descripcion = m.Descripcion
                        ,Fecha_inicio_del_Evento = (m.Fecha_inicio_del_Evento == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio_del_Evento).ToString(ConfigurationProperty.DateFormat))
                        ,Fecha_fin_del_Evento = (m.Fecha_fin_del_Evento == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin_del_Evento).ToString(ConfigurationProperty.DateFormat))
			,Cantidad_de_dias = m.Cantidad_de_dias
                        ,Evento_en_Empresa = m.Evento_en_Empresa
                        ,Evento_en_EmpresaDescripcion = CultureHelper.GetTraduction(m.Evento_en_Empresa_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Evento_en_Empresa_Respuesta_Logica.Descripcion
			,Nombre_del_Lugar = m.Nombre_del_Lugar
			,Calle = m.Calle
			,Numero_exterior = m.Numero_exterior
			,Numero_interior = m.Numero_interior
			,Colonia = m.Colonia
			,CP = m.CP
			,Ciudad = m.Ciudad
                        ,Estado = m.Estado
                        ,EstadoNombre_del_Estado = CultureHelper.GetTraduction(m.Estado_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Estado_Estado.Nombre_del_Estado
                        ,Pais = m.Pais
                        ,PaisNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_Pais.Nombre_del_Pais
                        ,Permite_Familiares = m.Permite_Familiares
                        ,Permite_FamiliaresDescripcion = CultureHelper.GetTraduction(m.Permite_Familiares_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Permite_Familiares_Respuesta_Logica.Descripcion
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_Eventos.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus_Eventos.Descripcion

                    
                };
				var resultData = new
                {
                    data = result
                    ,Actividades_del_Evento = Detalle_Actividades_EventoData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }

		[HttpPost]
        public ActionResult Post_Actividades(Eventos_ActividadesModel varEventos)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEventosApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Eventos_ActividadesInfo = new Eventos_Actividades
                {
                    Folio = varEventos.Folio
                                        
                };

                result = _IEventosApiConsumer.Update_Actividades(Eventos_ActividadesInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Actividades(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEventosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IEventosApiConsumer.Get_Actividades(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Actividades_Evento;
                var Detalle_Actividades_EventoData = GetDetalle_Actividades_EventoData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Actividades_Evento);

                var result = new Eventos_ActividadesModel
                {
                    Folio = m.Folio

                    
                };
				var resultData = new
                {
                    data = result
                    ,Actividades_del_Evento = Detalle_Actividades_EventoData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }


    }
}

