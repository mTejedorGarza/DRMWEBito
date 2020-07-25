using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Configuracion_de_Rutinas;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Tipo_de_Ejercicio_Rutina;
using Spartane.Core.Domain.Nivel_de_dificultad;
using Spartane.Core.Domain.Sexo;
using Spartane.Core.Domain.Estatus;
using Spartane.Core.Domain.Detalle_Secuencia_de_Ejercicios;

using Spartane.Core.Domain.Secuencia_de_Ejercicios_en_Rutinas;
using Spartane.Core.Domain.Tipo_de_Ejercicio_Rutina;
using Spartane.Core.Domain.Tipo_de_Enfoque_del_Ejercicio;



using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Configuracion_de_Rutinas;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Configuracion_de_Rutinas;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Tipo_de_Ejercicio_Rutina;
using Spartane.Web.Areas.WebApiConsumer.Nivel_de_dificultad;
using Spartane.Web.Areas.WebApiConsumer.Sexo;
using Spartane.Web.Areas.WebApiConsumer.Estatus;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Secuencia_de_Ejercicios;

using Spartane.Web.Areas.WebApiConsumer.Secuencia_de_Ejercicios_en_Rutinas;
using Spartane.Web.Areas.WebApiConsumer.Tipo_de_Ejercicio_Rutina;
using Spartane.Web.Areas.WebApiConsumer.Tipo_de_Enfoque_del_Ejercicio;


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
    public class Configuracion_de_RutinasController : Controller
    {
        #region "variable declaration"

        private IConfiguracion_de_RutinasService service = null;
        private IConfiguracion_de_RutinasApiConsumer _IConfiguracion_de_RutinasApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private ITipo_de_Ejercicio_RutinaApiConsumer _ITipo_de_Ejercicio_RutinaApiConsumer;
        private INivel_de_dificultadApiConsumer _INivel_de_dificultadApiConsumer;
        private ISexoApiConsumer _ISexoApiConsumer;
        private IEstatusApiConsumer _IEstatusApiConsumer;
        private IDetalle_Secuencia_de_EjerciciosApiConsumer _IDetalle_Secuencia_de_EjerciciosApiConsumer;

        private ISecuencia_de_Ejercicios_en_RutinasApiConsumer _ISecuencia_de_Ejercicios_en_RutinasApiConsumer;
        private ITipo_de_Enfoque_del_EjercicioApiConsumer _ITipo_de_Enfoque_del_EjercicioApiConsumer;


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

        
        public Configuracion_de_RutinasController(IConfiguracion_de_RutinasService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IConfiguracion_de_RutinasApiConsumer Configuracion_de_RutinasApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer , ITipo_de_Ejercicio_RutinaApiConsumer Tipo_de_Ejercicio_RutinaApiConsumer , INivel_de_dificultadApiConsumer Nivel_de_dificultadApiConsumer , ISexoApiConsumer SexoApiConsumer , IEstatusApiConsumer EstatusApiConsumer , IDetalle_Secuencia_de_EjerciciosApiConsumer Detalle_Secuencia_de_EjerciciosApiConsumer , ISecuencia_de_Ejercicios_en_RutinasApiConsumer Secuencia_de_Ejercicios_en_RutinasApiConsumer , ITipo_de_Enfoque_del_EjercicioApiConsumer Tipo_de_Enfoque_del_EjercicioApiConsumer  )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IConfiguracion_de_RutinasApiConsumer = Configuracion_de_RutinasApiConsumer;
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
            this._ITipo_de_Ejercicio_RutinaApiConsumer = Tipo_de_Ejercicio_RutinaApiConsumer;
            this._INivel_de_dificultadApiConsumer = Nivel_de_dificultadApiConsumer;
            this._ISexoApiConsumer = SexoApiConsumer;
            this._IEstatusApiConsumer = EstatusApiConsumer;
            this._IDetalle_Secuencia_de_EjerciciosApiConsumer = Detalle_Secuencia_de_EjerciciosApiConsumer;

            this._ISecuencia_de_Ejercicios_en_RutinasApiConsumer = Secuencia_de_Ejercicios_en_RutinasApiConsumer;
            this._ITipo_de_Ejercicio_RutinaApiConsumer = Tipo_de_Ejercicio_RutinaApiConsumer;
            this._ITipo_de_Enfoque_del_EjercicioApiConsumer = Tipo_de_Enfoque_del_EjercicioApiConsumer;


        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Configuracion_de_Rutinas
        [ObjectAuth(ObjectId = (ModuleObjectId)44613, PermissionType = PermissionTypes.Consult)]
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
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44613, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			          
            return View();
        }

        // GET: Frontal/Configuracion_de_Rutinas/Create
          [ObjectAuth(ObjectId = (ModuleObjectId)44613, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44613, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varConfiguracion_de_Rutinas = new Configuracion_de_RutinasModel();
			varConfiguracion_de_Rutinas.Folio = Id;
			
            ViewBag.ObjectId = "44613";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;

            var permissionDetalle_Secuencia_de_Ejercicios = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44614, ModuleId);
            ViewBag.PermissionDetalle_Secuencia_de_Ejercicios = permissionDetalle_Secuencia_de_Ejercicios;


            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
				
				_tokenManager.GenerateToken();
				_ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _IConfiguracion_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Configuracion_de_RutinassData = _IConfiguracion_de_RutinasApiConsumer.ListaSelAll(0, 1000, "Configuracion_de_Rutinas.Folio=" + Id, "").Resource.Configuracion_de_Rutinass;
				
				if (Configuracion_de_RutinassData != null && Configuracion_de_RutinassData.Count > 0)
                {
					var Configuracion_de_RutinasData = Configuracion_de_RutinassData.First();
					varConfiguracion_de_Rutinas= new Configuracion_de_RutinasModel
					{
						Folio  = Configuracion_de_RutinasData.Folio 
	                    ,Fecha_de_Registro = (Configuracion_de_RutinasData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(Configuracion_de_RutinasData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = Configuracion_de_RutinasData.Hora_de_Registro
                    ,Usuario_que_Registra = Configuracion_de_RutinasData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(Configuracion_de_RutinasData.Usuario_que_Registra), "Spartan_User") ??  (string)Configuracion_de_RutinasData.Usuario_que_Registra_Spartan_User.Name
                    ,Tipo_de_Rutina = Configuracion_de_RutinasData.Tipo_de_Rutina
                    ,Tipo_de_RutinaTipo_de_Rutina = CultureHelper.GetTraduction(Convert.ToString(Configuracion_de_RutinasData.Tipo_de_Rutina), "Tipo_de_Ejercicio_Rutina") ??  (string)Configuracion_de_RutinasData.Tipo_de_Rutina_Tipo_de_Ejercicio_Rutina.Tipo_de_Rutina
                    ,Nivel_de_Dificultad = Configuracion_de_RutinasData.Nivel_de_Dificultad
                    ,Nivel_de_DificultadDificultad = CultureHelper.GetTraduction(Convert.ToString(Configuracion_de_RutinasData.Nivel_de_Dificultad), "Nivel_de_dificultad") ??  (string)Configuracion_de_RutinasData.Nivel_de_Dificultad_Nivel_de_dificultad.Dificultad
                    ,Sexo = Configuracion_de_RutinasData.Sexo
                    ,SexoDescripcion = CultureHelper.GetTraduction(Convert.ToString(Configuracion_de_RutinasData.Sexo), "Sexo") ??  (string)Configuracion_de_RutinasData.Sexo_Sexo.Descripcion
                    ,Cantidad_de_ejercicios = Configuracion_de_RutinasData.Cantidad_de_ejercicios
                    ,Cantidad_de_series = Configuracion_de_RutinasData.Cantidad_de_series
                    ,Cantidad_de_repeticiones = Configuracion_de_RutinasData.Cantidad_de_repeticiones
                    ,Descanso_segundos = Configuracion_de_RutinasData.Descanso_segundos
                    ,Texto_Ejercicios = Configuracion_de_RutinasData.Texto_Ejercicios
                    ,Lleva_Calentamiento = Configuracion_de_RutinasData.Lleva_Calentamiento.GetValueOrDefault()
                    ,Lleva_Enfriamiento = Configuracion_de_RutinasData.Lleva_Enfriamiento.GetValueOrDefault()
                    ,Estatus = Configuracion_de_RutinasData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Configuracion_de_RutinasData.Estatus), "Estatus") ??  (string)Configuracion_de_RutinasData.Estatus_Estatus.Descripcion

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
            _ITipo_de_Ejercicio_RutinaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Ejercicio_Rutinas_Tipo_de_Rutina = _ITipo_de_Ejercicio_RutinaApiConsumer.SelAll(true);
            if (Tipo_de_Ejercicio_Rutinas_Tipo_de_Rutina != null && Tipo_de_Ejercicio_Rutinas_Tipo_de_Rutina.Resource != null)
                ViewBag.Tipo_de_Ejercicio_Rutinas_Tipo_de_Rutina = Tipo_de_Ejercicio_Rutinas_Tipo_de_Rutina.Resource.Where(m => m.Tipo_de_Rutina != null).OrderBy(m => m.Tipo_de_Rutina).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Tipo_de_Ejercicio_Rutina", "Tipo_de_Rutina") ?? m.Tipo_de_Rutina.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _INivel_de_dificultadApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Nivel_de_dificultads_Nivel_de_Dificultad = _INivel_de_dificultadApiConsumer.SelAll(true);
            if (Nivel_de_dificultads_Nivel_de_Dificultad != null && Nivel_de_dificultads_Nivel_de_Dificultad.Resource != null)
                ViewBag.Nivel_de_dificultads_Nivel_de_Dificultad = Nivel_de_dificultads_Nivel_de_Dificultad.Resource.Where(m => m.Dificultad != null).OrderBy(m => m.Dificultad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Nivel_de_dificultad", "Dificultad") ?? m.Dificultad.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISexoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Sexos_Sexo = _ISexoApiConsumer.SelAll(true);
            if (Sexos_Sexo != null && Sexos_Sexo.Resource != null)
                ViewBag.Sexos_Sexo = Sexos_Sexo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Sexo", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
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

				
            return View(varConfiguracion_de_Rutinas);
        }
		
	[HttpGet]
        public ActionResult AddConfiguracion_de_Rutinas(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44613);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IConfiguracion_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
			Configuracion_de_RutinasModel varConfiguracion_de_Rutinas= new Configuracion_de_RutinasModel();
            var permissionDetalle_Secuencia_de_Ejercicios = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44614, ModuleId);
            ViewBag.PermissionDetalle_Secuencia_de_Ejercicios = permissionDetalle_Secuencia_de_Ejercicios;


            if (id.ToString() != "0")
            {
                var Configuracion_de_RutinassData = _IConfiguracion_de_RutinasApiConsumer.ListaSelAll(0, 1000, "Configuracion_de_Rutinas.Folio=" + id, "").Resource.Configuracion_de_Rutinass;
				
				if (Configuracion_de_RutinassData != null && Configuracion_de_RutinassData.Count > 0)
                {
					var Configuracion_de_RutinasData = Configuracion_de_RutinassData.First();
					varConfiguracion_de_Rutinas= new Configuracion_de_RutinasModel
					{
						Folio  = Configuracion_de_RutinasData.Folio 
	                    ,Fecha_de_Registro = (Configuracion_de_RutinasData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(Configuracion_de_RutinasData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = Configuracion_de_RutinasData.Hora_de_Registro
                    ,Usuario_que_Registra = Configuracion_de_RutinasData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(Configuracion_de_RutinasData.Usuario_que_Registra), "Spartan_User") ??  (string)Configuracion_de_RutinasData.Usuario_que_Registra_Spartan_User.Name
                    ,Tipo_de_Rutina = Configuracion_de_RutinasData.Tipo_de_Rutina
                    ,Tipo_de_RutinaTipo_de_Rutina = CultureHelper.GetTraduction(Convert.ToString(Configuracion_de_RutinasData.Tipo_de_Rutina), "Tipo_de_Ejercicio_Rutina") ??  (string)Configuracion_de_RutinasData.Tipo_de_Rutina_Tipo_de_Ejercicio_Rutina.Tipo_de_Rutina
                    ,Nivel_de_Dificultad = Configuracion_de_RutinasData.Nivel_de_Dificultad
                    ,Nivel_de_DificultadDificultad = CultureHelper.GetTraduction(Convert.ToString(Configuracion_de_RutinasData.Nivel_de_Dificultad), "Nivel_de_dificultad") ??  (string)Configuracion_de_RutinasData.Nivel_de_Dificultad_Nivel_de_dificultad.Dificultad
                    ,Sexo = Configuracion_de_RutinasData.Sexo
                    ,SexoDescripcion = CultureHelper.GetTraduction(Convert.ToString(Configuracion_de_RutinasData.Sexo), "Sexo") ??  (string)Configuracion_de_RutinasData.Sexo_Sexo.Descripcion
                    ,Cantidad_de_ejercicios = Configuracion_de_RutinasData.Cantidad_de_ejercicios
                    ,Cantidad_de_series = Configuracion_de_RutinasData.Cantidad_de_series
                    ,Cantidad_de_repeticiones = Configuracion_de_RutinasData.Cantidad_de_repeticiones
                    ,Descanso_segundos = Configuracion_de_RutinasData.Descanso_segundos
                    ,Texto_Ejercicios = Configuracion_de_RutinasData.Texto_Ejercicios
                    ,Lleva_Calentamiento = Configuracion_de_RutinasData.Lleva_Calentamiento.GetValueOrDefault()
                    ,Lleva_Enfriamiento = Configuracion_de_RutinasData.Lleva_Enfriamiento.GetValueOrDefault()
                    ,Estatus = Configuracion_de_RutinasData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Configuracion_de_RutinasData.Estatus), "Estatus") ??  (string)Configuracion_de_RutinasData.Estatus_Estatus.Descripcion

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
            _ITipo_de_Ejercicio_RutinaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Ejercicio_Rutinas_Tipo_de_Rutina = _ITipo_de_Ejercicio_RutinaApiConsumer.SelAll(true);
            if (Tipo_de_Ejercicio_Rutinas_Tipo_de_Rutina != null && Tipo_de_Ejercicio_Rutinas_Tipo_de_Rutina.Resource != null)
                ViewBag.Tipo_de_Ejercicio_Rutinas_Tipo_de_Rutina = Tipo_de_Ejercicio_Rutinas_Tipo_de_Rutina.Resource.Where(m => m.Tipo_de_Rutina != null).OrderBy(m => m.Tipo_de_Rutina).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Tipo_de_Ejercicio_Rutina", "Tipo_de_Rutina") ?? m.Tipo_de_Rutina.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _INivel_de_dificultadApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Nivel_de_dificultads_Nivel_de_Dificultad = _INivel_de_dificultadApiConsumer.SelAll(true);
            if (Nivel_de_dificultads_Nivel_de_Dificultad != null && Nivel_de_dificultads_Nivel_de_Dificultad.Resource != null)
                ViewBag.Nivel_de_dificultads_Nivel_de_Dificultad = Nivel_de_dificultads_Nivel_de_Dificultad.Resource.Where(m => m.Dificultad != null).OrderBy(m => m.Dificultad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Nivel_de_dificultad", "Dificultad") ?? m.Dificultad.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISexoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Sexos_Sexo = _ISexoApiConsumer.SelAll(true);
            if (Sexos_Sexo != null && Sexos_Sexo.Resource != null)
                ViewBag.Sexos_Sexo = Sexos_Sexo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Sexo", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddConfiguracion_de_Rutinas", varConfiguracion_de_Rutinas);
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
        public ActionResult GetTipo_de_Ejercicio_RutinaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipo_de_Ejercicio_RutinaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipo_de_Ejercicio_RutinaApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Tipo_de_Rutina).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Tipo_de_Ejercicio_Rutina", "Tipo_de_Rutina")?? m.Tipo_de_Rutina,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetNivel_de_dificultadAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _INivel_de_dificultadApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _INivel_de_dificultadApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Dificultad).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Nivel_de_dificultad", "Dificultad")?? m.Dificultad,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSexoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISexoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISexoApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Sexo", "Descripcion")?? m.Descripcion,
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
        public ActionResult ShowAdvanceFilter(Configuracion_de_RutinasAdvanceSearchModel model, int idFilter = -1)
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
            _ITipo_de_Ejercicio_RutinaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Ejercicio_Rutinas_Tipo_de_Rutina = _ITipo_de_Ejercicio_RutinaApiConsumer.SelAll(true);
            if (Tipo_de_Ejercicio_Rutinas_Tipo_de_Rutina != null && Tipo_de_Ejercicio_Rutinas_Tipo_de_Rutina.Resource != null)
                ViewBag.Tipo_de_Ejercicio_Rutinas_Tipo_de_Rutina = Tipo_de_Ejercicio_Rutinas_Tipo_de_Rutina.Resource.Where(m => m.Tipo_de_Rutina != null).OrderBy(m => m.Tipo_de_Rutina).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Tipo_de_Ejercicio_Rutina", "Tipo_de_Rutina") ?? m.Tipo_de_Rutina.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _INivel_de_dificultadApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Nivel_de_dificultads_Nivel_de_Dificultad = _INivel_de_dificultadApiConsumer.SelAll(true);
            if (Nivel_de_dificultads_Nivel_de_Dificultad != null && Nivel_de_dificultads_Nivel_de_Dificultad.Resource != null)
                ViewBag.Nivel_de_dificultads_Nivel_de_Dificultad = Nivel_de_dificultads_Nivel_de_Dificultad.Resource.Where(m => m.Dificultad != null).OrderBy(m => m.Dificultad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Nivel_de_dificultad", "Dificultad") ?? m.Dificultad.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISexoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Sexos_Sexo = _ISexoApiConsumer.SelAll(true);
            if (Sexos_Sexo != null && Sexos_Sexo.Resource != null)
                ViewBag.Sexos_Sexo = Sexos_Sexo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Sexo", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
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
            _ITipo_de_Ejercicio_RutinaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Ejercicio_Rutinas_Tipo_de_Rutina = _ITipo_de_Ejercicio_RutinaApiConsumer.SelAll(true);
            if (Tipo_de_Ejercicio_Rutinas_Tipo_de_Rutina != null && Tipo_de_Ejercicio_Rutinas_Tipo_de_Rutina.Resource != null)
                ViewBag.Tipo_de_Ejercicio_Rutinas_Tipo_de_Rutina = Tipo_de_Ejercicio_Rutinas_Tipo_de_Rutina.Resource.Where(m => m.Tipo_de_Rutina != null).OrderBy(m => m.Tipo_de_Rutina).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Tipo_de_Ejercicio_Rutina", "Tipo_de_Rutina") ?? m.Tipo_de_Rutina.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _INivel_de_dificultadApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Nivel_de_dificultads_Nivel_de_Dificultad = _INivel_de_dificultadApiConsumer.SelAll(true);
            if (Nivel_de_dificultads_Nivel_de_Dificultad != null && Nivel_de_dificultads_Nivel_de_Dificultad.Resource != null)
                ViewBag.Nivel_de_dificultads_Nivel_de_Dificultad = Nivel_de_dificultads_Nivel_de_Dificultad.Resource.Where(m => m.Dificultad != null).OrderBy(m => m.Dificultad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Nivel_de_dificultad", "Dificultad") ?? m.Dificultad.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISexoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Sexos_Sexo = _ISexoApiConsumer.SelAll(true);
            if (Sexos_Sexo != null && Sexos_Sexo.Resource != null)
                ViewBag.Sexos_Sexo = Sexos_Sexo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Sexo", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            var previousFiltersObj = new Configuracion_de_RutinasAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Configuracion_de_RutinasAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Configuracion_de_RutinasAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Configuracion_de_RutinasPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IConfiguracion_de_RutinasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Configuracion_de_Rutinass == null)
                result.Configuracion_de_Rutinass = new List<Configuracion_de_Rutinas>();

            return Json(new
            {
                data = result.Configuracion_de_Rutinass.Select(m => new Configuracion_de_RutinasGridModel
                    {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,Tipo_de_RutinaTipo_de_Rutina = CultureHelper.GetTraduction(m.Tipo_de_Rutina_Tipo_de_Ejercicio_Rutina.Folio.ToString(), "Tipo_de_Rutina") ?? (string)m.Tipo_de_Rutina_Tipo_de_Ejercicio_Rutina.Tipo_de_Rutina
                        ,Nivel_de_DificultadDificultad = CultureHelper.GetTraduction(m.Nivel_de_Dificultad_Nivel_de_dificultad.Folio.ToString(), "Dificultad") ?? (string)m.Nivel_de_Dificultad_Nivel_de_dificultad.Dificultad
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
			,Cantidad_de_ejercicios = m.Cantidad_de_ejercicios
			,Cantidad_de_series = m.Cantidad_de_series
			,Cantidad_de_repeticiones = m.Cantidad_de_repeticiones
			,Descanso_segundos = m.Descanso_segundos
			,Texto_Ejercicios = m.Texto_Ejercicios
			,Lleva_Calentamiento = m.Lleva_Calentamiento
			,Lleva_Enfriamiento = m.Lleva_Enfriamiento
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }
		/*
		 [HttpGet]
        public ActionResult GetConfiguracion_de_RutinasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IConfiguracion_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IConfiguracion_de_RutinasApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraductionNew(Convert.ToString(m.Folio), "Configuracion_de_Rutinas", m.),
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
        /// Get List of Configuracion_de_Rutinas from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Configuracion_de_Rutinas Entity</returns>
        public ActionResult GetConfiguracion_de_RutinasList(UrlParametersModel param)
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
            _IConfiguracion_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);

          
            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new Configuracion_de_RutinasPropertyMapper());
				
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
				if (Session["AdvanceSearch"].GetType() == typeof(Configuracion_de_RutinasAdvanceSearchModel))
                {
					var advanceFilter =
                    (Configuracion_de_RutinasAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            Configuracion_de_RutinasPropertyMapper oConfiguracion_de_RutinasPropertyMapper = new Configuracion_de_RutinasPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                 if (sortColumn != -1)
                    configuration.OrderByClause = oConfiguracion_de_RutinasPropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _IConfiguracion_de_RutinasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Configuracion_de_Rutinass == null)
                result.Configuracion_de_Rutinass = new List<Configuracion_de_Rutinas>();

            return Json(new
            {
                aaData = result.Configuracion_de_Rutinass.Select(m => new Configuracion_de_RutinasGridModel
            {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,Tipo_de_RutinaTipo_de_Rutina = CultureHelper.GetTraduction(m.Tipo_de_Rutina_Tipo_de_Ejercicio_Rutina.Folio.ToString(), "Tipo_de_Rutina") ?? (string)m.Tipo_de_Rutina_Tipo_de_Ejercicio_Rutina.Tipo_de_Rutina
                        ,Nivel_de_DificultadDificultad = CultureHelper.GetTraduction(m.Nivel_de_Dificultad_Nivel_de_dificultad.Folio.ToString(), "Dificultad") ?? (string)m.Nivel_de_Dificultad_Nivel_de_dificultad.Dificultad
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
			,Cantidad_de_ejercicios = m.Cantidad_de_ejercicios
			,Cantidad_de_series = m.Cantidad_de_series
			,Cantidad_de_repeticiones = m.Cantidad_de_repeticiones
			,Descanso_segundos = m.Descanso_segundos
			,Texto_Ejercicios = m.Texto_Ejercicios
			,Lleva_Calentamiento = m.Lleva_Calentamiento
			,Lleva_Enfriamiento = m.Lleva_Enfriamiento
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }


//Grid GetAutoComplete






        [NonAction]
        public string GetAdvanceFilter(Configuracion_de_RutinasAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromFolio) || !string.IsNullOrEmpty(filter.ToFolio))
            {
                if (!string.IsNullOrEmpty(filter.FromFolio))
                    where += " AND Configuracion_de_Rutinas.Folio >= " + filter.FromFolio;
                if (!string.IsNullOrEmpty(filter.ToFolio))
                    where += " AND Configuracion_de_Rutinas.Folio <= " + filter.ToFolio;
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro) || !string.IsNullOrEmpty(filter.ToFecha_de_Registro))
            {
                var Fecha_de_RegistroFrom = DateTime.ParseExact(filter.FromFecha_de_Registro, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_de_RegistroTo = DateTime.ParseExact(filter.ToFecha_de_Registro, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro))
                    where += " AND Configuracion_de_Rutinas.Fecha_de_Registro >= '" + Fecha_de_RegistroFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_Registro))
                    where += " AND Configuracion_de_Rutinas.Fecha_de_Registro <= '" + Fecha_de_RegistroTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromHora_de_Registro) || !string.IsNullOrEmpty(filter.ToHora_de_Registro))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_de_Registro))
                    where += " AND Convert(TIME,Configuracion_de_Rutinas.Hora_de_Registro) >='" + filter.FromHora_de_Registro + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_de_Registro))
                    where += " AND Convert(TIME,Configuracion_de_Rutinas.Hora_de_Registro) <='" + filter.ToHora_de_Registro + "'";
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

                where += " AND Configuracion_de_Rutinas.Usuario_que_Registra In (" + Usuario_que_RegistraIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceTipo_de_Rutina))
            {
                switch (filter.Tipo_de_RutinaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Tipo_de_Ejercicio_Rutina.Tipo_de_Rutina LIKE '" + filter.AdvanceTipo_de_Rutina + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Tipo_de_Ejercicio_Rutina.Tipo_de_Rutina LIKE '%" + filter.AdvanceTipo_de_Rutina + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Tipo_de_Ejercicio_Rutina.Tipo_de_Rutina = '" + filter.AdvanceTipo_de_Rutina + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Tipo_de_Ejercicio_Rutina.Tipo_de_Rutina LIKE '%" + filter.AdvanceTipo_de_Rutina + "%'";
                        break;
                }
            }
            else if (filter.AdvanceTipo_de_RutinaMultiple != null && filter.AdvanceTipo_de_RutinaMultiple.Count() > 0)
            {
                var Tipo_de_RutinaIds = string.Join(",", filter.AdvanceTipo_de_RutinaMultiple);

                where += " AND Configuracion_de_Rutinas.Tipo_de_Rutina In (" + Tipo_de_RutinaIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceNivel_de_Dificultad))
            {
                switch (filter.Nivel_de_DificultadFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Nivel_de_dificultad.Dificultad LIKE '" + filter.AdvanceNivel_de_Dificultad + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Nivel_de_dificultad.Dificultad LIKE '%" + filter.AdvanceNivel_de_Dificultad + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Nivel_de_dificultad.Dificultad = '" + filter.AdvanceNivel_de_Dificultad + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Nivel_de_dificultad.Dificultad LIKE '%" + filter.AdvanceNivel_de_Dificultad + "%'";
                        break;
                }
            }
            else if (filter.AdvanceNivel_de_DificultadMultiple != null && filter.AdvanceNivel_de_DificultadMultiple.Count() > 0)
            {
                var Nivel_de_DificultadIds = string.Join(",", filter.AdvanceNivel_de_DificultadMultiple);

                where += " AND Configuracion_de_Rutinas.Nivel_de_Dificultad In (" + Nivel_de_DificultadIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceSexo))
            {
                switch (filter.SexoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Sexo.Descripcion LIKE '" + filter.AdvanceSexo + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Sexo.Descripcion LIKE '%" + filter.AdvanceSexo + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Sexo.Descripcion = '" + filter.AdvanceSexo + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Sexo.Descripcion LIKE '%" + filter.AdvanceSexo + "%'";
                        break;
                }
            }
            else if (filter.AdvanceSexoMultiple != null && filter.AdvanceSexoMultiple.Count() > 0)
            {
                var SexoIds = string.Join(",", filter.AdvanceSexoMultiple);

                where += " AND Configuracion_de_Rutinas.Sexo In (" + SexoIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.FromCantidad_de_ejercicios) || !string.IsNullOrEmpty(filter.ToCantidad_de_ejercicios))
            {
                if (!string.IsNullOrEmpty(filter.FromCantidad_de_ejercicios))
                    where += " AND Configuracion_de_Rutinas.Cantidad_de_ejercicios >= " + filter.FromCantidad_de_ejercicios;
                if (!string.IsNullOrEmpty(filter.ToCantidad_de_ejercicios))
                    where += " AND Configuracion_de_Rutinas.Cantidad_de_ejercicios <= " + filter.ToCantidad_de_ejercicios;
            }

            if (!string.IsNullOrEmpty(filter.FromCantidad_de_series) || !string.IsNullOrEmpty(filter.ToCantidad_de_series))
            {
                if (!string.IsNullOrEmpty(filter.FromCantidad_de_series))
                    where += " AND Configuracion_de_Rutinas.Cantidad_de_series >= " + filter.FromCantidad_de_series;
                if (!string.IsNullOrEmpty(filter.ToCantidad_de_series))
                    where += " AND Configuracion_de_Rutinas.Cantidad_de_series <= " + filter.ToCantidad_de_series;
            }

            if (!string.IsNullOrEmpty(filter.FromCantidad_de_repeticiones) || !string.IsNullOrEmpty(filter.ToCantidad_de_repeticiones))
            {
                if (!string.IsNullOrEmpty(filter.FromCantidad_de_repeticiones))
                    where += " AND Configuracion_de_Rutinas.Cantidad_de_repeticiones >= " + filter.FromCantidad_de_repeticiones;
                if (!string.IsNullOrEmpty(filter.ToCantidad_de_repeticiones))
                    where += " AND Configuracion_de_Rutinas.Cantidad_de_repeticiones <= " + filter.ToCantidad_de_repeticiones;
            }

            if (!string.IsNullOrEmpty(filter.FromDescanso_segundos) || !string.IsNullOrEmpty(filter.ToDescanso_segundos))
            {
                if (!string.IsNullOrEmpty(filter.FromDescanso_segundos))
                    where += " AND Configuracion_de_Rutinas.Descanso_segundos >= " + filter.FromDescanso_segundos;
                if (!string.IsNullOrEmpty(filter.ToDescanso_segundos))
                    where += " AND Configuracion_de_Rutinas.Descanso_segundos <= " + filter.ToDescanso_segundos;
            }

            if (!string.IsNullOrEmpty(filter.Texto_Ejercicios))
            {
                switch (filter.Texto_EjerciciosFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Configuracion_de_Rutinas.Texto_Ejercicios LIKE '" + filter.Texto_Ejercicios + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Configuracion_de_Rutinas.Texto_Ejercicios LIKE '%" + filter.Texto_Ejercicios + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Configuracion_de_Rutinas.Texto_Ejercicios = '" + filter.Texto_Ejercicios + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Configuracion_de_Rutinas.Texto_Ejercicios LIKE '%" + filter.Texto_Ejercicios + "%'";
                        break;
                }
            }

            if (filter.Lleva_Calentamiento != RadioOptions.NoApply)
                where += " AND Configuracion_de_Rutinas.Lleva_Calentamiento = " + Convert.ToInt32(filter.Lleva_Calentamiento);

            if (filter.Lleva_Enfriamiento != RadioOptions.NoApply)
                where += " AND Configuracion_de_Rutinas.Lleva_Enfriamiento = " + Convert.ToInt32(filter.Lleva_Enfriamiento);

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

                where += " AND Configuracion_de_Rutinas.Estatus In (" + EstatusIds + ")";
            }


            where = new Regex(Regex.Escape("AND ")).Replace(where, "", 1);
            return where;
        }

        [NonAction]
        public Grid_File ConvertSpartane_FileToGridFile(Spartane.Core.Domain.Spartane_File.Spartane_File file)
        {
            return file == null ? new Grid_File { FileId = 0, FileSize = 0, FileName = "" } : new Grid_File { FileId = file.File_Id, FileName = file.Description, FileSize = file.File_Size ?? 0, };
        }

        public ActionResult GetDetalle_Secuencia_de_Ejercicios(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_Secuencia_de_EjerciciosGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Secuencia_de_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Secuencia_de_Ejercicios.Folio_Configuracion_Rutinas=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Secuencia_de_Ejercicios.Folio_Configuracion_Rutinas='" + RelationId + "'";
            }
            var result = _IDetalle_Secuencia_de_EjerciciosApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Secuencia_de_Ejercicioss == null)
                result.Detalle_Secuencia_de_Ejercicioss = new List<Detalle_Secuencia_de_Ejercicios>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Secuencia_de_Ejercicioss.Select(m => new Detalle_Secuencia_de_EjerciciosGridModel
                {
                    Folio = m.Folio

                        ,Orden_del_Ejercicio = m.Orden_del_Ejercicio
                        ,Orden_del_EjercicioDescripcion = CultureHelper.GetTraduction(m.Orden_del_Ejercicio_Secuencia_de_Ejercicios_en_Rutinas.Folio.ToString(), "Descripcion") ??(string)m.Orden_del_Ejercicio_Secuencia_de_Ejercicios_en_Rutinas.Descripcion
                        ,Tipo_de_Ejercicio = m.Tipo_de_Ejercicio
                        ,Tipo_de_EjercicioNombre_para_Secuencia = CultureHelper.GetTraduction(m.Tipo_de_Ejercicio_Tipo_de_Ejercicio_Rutina.Folio.ToString(), "Nombre_para_Secuencia") ??(string)m.Tipo_de_Ejercicio_Tipo_de_Ejercicio_Rutina.Nombre_para_Secuencia
                        ,Enfoque = m.Enfoque
                        ,EnfoqueDescripcion = CultureHelper.GetTraduction(m.Enfoque_Tipo_de_Enfoque_del_Ejercicio.Folio.ToString(), "Descripcion") ??(string)m.Enfoque_Tipo_de_Enfoque_del_Ejercicio.Descripcion
			,Secuencia_del_Ejercicio = m.Secuencia_del_Ejercicio

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_Secuencia_de_EjerciciosGridModel> GetDetalle_Secuencia_de_EjerciciosData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_Secuencia_de_EjerciciosGridModel> resultData = new List<Detalle_Secuencia_de_EjerciciosGridModel>();
            string where = "Detalle_Secuencia_de_Ejercicios.Folio_Configuracion_Rutinas=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Secuencia_de_Ejercicios.Folio_Configuracion_Rutinas='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Secuencia_de_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_Secuencia_de_EjerciciosApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Secuencia_de_Ejercicioss != null)
            {
                resultData = result.Detalle_Secuencia_de_Ejercicioss.Select(m => new Detalle_Secuencia_de_EjerciciosGridModel
                    {
                        Folio = m.Folio

                        ,Orden_del_Ejercicio = m.Orden_del_Ejercicio
                        ,Orden_del_EjercicioDescripcion = CultureHelper.GetTraduction(m.Orden_del_Ejercicio_Secuencia_de_Ejercicios_en_Rutinas.Folio.ToString(), "Descripcion") ??(string)m.Orden_del_Ejercicio_Secuencia_de_Ejercicios_en_Rutinas.Descripcion
                        ,Tipo_de_Ejercicio = m.Tipo_de_Ejercicio
                        ,Tipo_de_EjercicioNombre_para_Secuencia = CultureHelper.GetTraduction(m.Tipo_de_Ejercicio_Tipo_de_Ejercicio_Rutina.Folio.ToString(), "Nombre_para_Secuencia") ??(string)m.Tipo_de_Ejercicio_Tipo_de_Ejercicio_Rutina.Nombre_para_Secuencia
                        ,Enfoque = m.Enfoque
                        ,EnfoqueDescripcion = CultureHelper.GetTraduction(m.Enfoque_Tipo_de_Enfoque_del_Ejercicio.Folio.ToString(), "Descripcion") ??(string)m.Enfoque_Tipo_de_Enfoque_del_Ejercicio.Descripcion
			,Secuencia_del_Ejercicio = m.Secuencia_del_Ejercicio


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
                _IConfiguracion_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);

                Configuracion_de_Rutinas varConfiguracion_de_Rutinas = null;
                if (id.ToString() != "0")
                {
                        string where = "";
                    _IDetalle_Secuencia_de_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Secuencia_de_Ejercicios.Folio_Configuracion_Rutinas=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Secuencia_de_Ejercicios.Folio_Configuracion_Rutinas='" + id + "'";
                    }
                    var Detalle_Secuencia_de_EjerciciosInfo =
                        _IDetalle_Secuencia_de_EjerciciosApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_Secuencia_de_EjerciciosInfo.Detalle_Secuencia_de_Ejercicioss.Count > 0)
                    {
                        var resultDetalle_Secuencia_de_Ejercicios = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_Secuencia_de_EjerciciosItem in Detalle_Secuencia_de_EjerciciosInfo.Detalle_Secuencia_de_Ejercicioss)
                            resultDetalle_Secuencia_de_Ejercicios = resultDetalle_Secuencia_de_Ejercicios
                                              && _IDetalle_Secuencia_de_EjerciciosApiConsumer.Delete(Detalle_Secuencia_de_EjerciciosItem.Folio, null,null).Resource;

                        if (!resultDetalle_Secuencia_de_Ejercicios)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                var result = _IConfiguracion_de_RutinasApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Configuracion_de_RutinasModel varConfiguracion_de_Rutinas)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IConfiguracion_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Configuracion_de_RutinasInfo = new Configuracion_de_Rutinas
                    {
                        Folio = varConfiguracion_de_Rutinas.Folio
                        ,Fecha_de_Registro = (!String.IsNullOrEmpty(varConfiguracion_de_Rutinas.Fecha_de_Registro)) ? DateTime.ParseExact(varConfiguracion_de_Rutinas.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varConfiguracion_de_Rutinas.Hora_de_Registro
                        ,Usuario_que_Registra = varConfiguracion_de_Rutinas.Usuario_que_Registra
                        ,Tipo_de_Rutina = varConfiguracion_de_Rutinas.Tipo_de_Rutina
                        ,Nivel_de_Dificultad = varConfiguracion_de_Rutinas.Nivel_de_Dificultad
                        ,Sexo = varConfiguracion_de_Rutinas.Sexo
                        ,Cantidad_de_ejercicios = varConfiguracion_de_Rutinas.Cantidad_de_ejercicios
                        ,Cantidad_de_series = varConfiguracion_de_Rutinas.Cantidad_de_series
                        ,Cantidad_de_repeticiones = varConfiguracion_de_Rutinas.Cantidad_de_repeticiones
                        ,Descanso_segundos = varConfiguracion_de_Rutinas.Descanso_segundos
                        ,Texto_Ejercicios = varConfiguracion_de_Rutinas.Texto_Ejercicios
                        ,Lleva_Calentamiento = varConfiguracion_de_Rutinas.Lleva_Calentamiento
                        ,Lleva_Enfriamiento = varConfiguracion_de_Rutinas.Lleva_Enfriamiento
                        ,Estatus = varConfiguracion_de_Rutinas.Estatus

                    };

                    result = !IsNew ?
                        _IConfiguracion_de_RutinasApiConsumer.Update(Configuracion_de_RutinasInfo, null, null).Resource.ToString() :
                         _IConfiguracion_de_RutinasApiConsumer.Insert(Configuracion_de_RutinasInfo, null, null).Resource.ToString();
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
        public bool CopyDetalle_Secuencia_de_Ejercicios(int MasterId, int referenceId, List<Detalle_Secuencia_de_EjerciciosGridModelPost> Detalle_Secuencia_de_EjerciciosItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_Secuencia_de_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_Secuencia_de_EjerciciosData = _IDetalle_Secuencia_de_EjerciciosApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Secuencia_de_Ejercicios.Folio_Configuracion_Rutinas=" + referenceId,"").Resource;
                if (Detalle_Secuencia_de_EjerciciosData == null || Detalle_Secuencia_de_EjerciciosData.Detalle_Secuencia_de_Ejercicioss.Count == 0)
                    return true;

                var result = true;

                Detalle_Secuencia_de_EjerciciosGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Secuencia_de_Ejercicios in Detalle_Secuencia_de_EjerciciosData.Detalle_Secuencia_de_Ejercicioss)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Secuencia_de_Ejercicios Detalle_Secuencia_de_Ejercicios1 = varDetalle_Secuencia_de_Ejercicios;

                    if (Detalle_Secuencia_de_EjerciciosItems != null && Detalle_Secuencia_de_EjerciciosItems.Any(m => m.Folio == Detalle_Secuencia_de_Ejercicios1.Folio))
                    {
                        modelDataToChange = Detalle_Secuencia_de_EjerciciosItems.FirstOrDefault(m => m.Folio == Detalle_Secuencia_de_Ejercicios1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Secuencia_de_Ejercicios.Folio_Configuracion_Rutinas = MasterId;
                    var insertId = _IDetalle_Secuencia_de_EjerciciosApiConsumer.Insert(varDetalle_Secuencia_de_Ejercicios,null,null).Resource;
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
        public ActionResult PostDetalle_Secuencia_de_Ejercicios(List<Detalle_Secuencia_de_EjerciciosGridModelPost> Detalle_Secuencia_de_EjerciciosItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Secuencia_de_Ejercicios(MasterId, referenceId, Detalle_Secuencia_de_EjerciciosItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_Secuencia_de_EjerciciosItems != null && Detalle_Secuencia_de_EjerciciosItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_Secuencia_de_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_Secuencia_de_EjerciciosItem in Detalle_Secuencia_de_EjerciciosItems)
                    {






                        //Removal Request
                        if (Detalle_Secuencia_de_EjerciciosItem.Removed)
                        {
                            result = result && _IDetalle_Secuencia_de_EjerciciosApiConsumer.Delete(Detalle_Secuencia_de_EjerciciosItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_Secuencia_de_EjerciciosItem.Folio = 0;

                        var Detalle_Secuencia_de_EjerciciosData = new Detalle_Secuencia_de_Ejercicios
                        {
                            Folio_Configuracion_Rutinas = MasterId
                            ,Folio = Detalle_Secuencia_de_EjerciciosItem.Folio
                            ,Orden_del_Ejercicio = (Convert.ToInt32(Detalle_Secuencia_de_EjerciciosItem.Orden_del_Ejercicio) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Secuencia_de_EjerciciosItem.Orden_del_Ejercicio))
                            ,Tipo_de_Ejercicio = (Convert.ToInt32(Detalle_Secuencia_de_EjerciciosItem.Tipo_de_Ejercicio) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Secuencia_de_EjerciciosItem.Tipo_de_Ejercicio))
                            ,Enfoque = (Convert.ToInt32(Detalle_Secuencia_de_EjerciciosItem.Enfoque) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Secuencia_de_EjerciciosItem.Enfoque))
                            ,Secuencia_del_Ejercicio = Detalle_Secuencia_de_EjerciciosItem.Secuencia_del_Ejercicio

                        };

                        var resultId = Detalle_Secuencia_de_EjerciciosItem.Folio > 0
                           ? _IDetalle_Secuencia_de_EjerciciosApiConsumer.Update(Detalle_Secuencia_de_EjerciciosData,null,null).Resource
                           : _IDetalle_Secuencia_de_EjerciciosApiConsumer.Insert(Detalle_Secuencia_de_EjerciciosData,null,null).Resource;

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
        public ActionResult GetDetalle_Secuencia_de_Ejercicios_Secuencia_de_Ejercicios_en_RutinasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISecuencia_de_Ejercicios_en_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISecuencia_de_Ejercicios_en_RutinasApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Folio), "Secuencia_de_Ejercicios_en_Rutinas", "Descripcion");
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
        public ActionResult GetDetalle_Secuencia_de_Ejercicios_Tipo_de_Ejercicio_RutinaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipo_de_Ejercicio_RutinaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipo_de_Ejercicio_RutinaApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Folio), "Tipo_de_Ejercicio_Rutina", "Nombre_para_Secuencia");
                  item.Nombre_para_Secuencia= trans??item.Nombre_para_Secuencia;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetDetalle_Secuencia_de_Ejercicios_Tipo_de_Enfoque_del_EjercicioAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipo_de_Enfoque_del_EjercicioApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipo_de_Enfoque_del_EjercicioApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Folio), "Tipo_de_Enfoque_del_Ejercicio", "Descripcion");
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
        /// Write Element Array of Configuracion_de_Rutinas script
        /// </summary>
        /// <param name="oConfiguracion_de_RutinasElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew Configuracion_de_RutinasModuleAttributeList)
        {
            for (int i = 0; i < Configuracion_de_RutinasModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Configuracion_de_RutinasModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Configuracion_de_RutinasModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Configuracion_de_RutinasModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Configuracion_de_RutinasModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Configuracion_de_RutinasModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Configuracion_de_RutinasModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < Configuracion_de_RutinasModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(Configuracion_de_RutinasModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							Configuracion_de_RutinasModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(Configuracion_de_RutinasModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							Configuracion_de_RutinasModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strConfiguracion_de_RutinasScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Configuracion_de_Rutinas.js")))
            {
                strConfiguracion_de_RutinasScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Configuracion_de_Rutinas element attributes
            string userChangeJson = jsSerialize.Serialize(Configuracion_de_RutinasModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strConfiguracion_de_RutinasScript.IndexOf("inpuElementArray");
            string splittedString = strConfiguracion_de_RutinasScript.Substring(indexOfArray, strConfiguracion_de_RutinasScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Configuracion_de_RutinasModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Configuracion_de_RutinasModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strConfiguracion_de_RutinasScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strConfiguracion_de_RutinasScript.Substring(indexOfArrayHistory, strConfiguracion_de_RutinasScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strConfiguracion_de_RutinasScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strConfiguracion_de_RutinasScript.Substring(endIndexOfMainElement + indexOfArray, strConfiguracion_de_RutinasScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (Configuracion_de_RutinasModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in Configuracion_de_RutinasModuleAttributeList.ChildModuleAttributeList)
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
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Configuracion_de_Rutinas.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Configuracion_de_Rutinas.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Configuracion_de_Rutinas.js")))
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
        public ActionResult Configuracion_de_RutinasPropertyBag()
        {
            return PartialView("Configuracion_de_RutinasPropertyBag", "Configuracion_de_Rutinas");
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
        public ActionResult AddDetalle_Secuencia_de_Ejercicios(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Secuencia_de_Ejercicios/AddDetalle_Secuencia_de_Ejercicios");
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
                var whereClauseFormat = "Object = 44613 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _IConfiguracion_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Configuracion_de_Rutinas.Folio= " + RecordId;
                            var result = _IConfiguracion_de_RutinasApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
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

            _IConfiguracion_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Configuracion_de_RutinasPropertyMapper());
			
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
                    (Configuracion_de_RutinasAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
			string sortDirection = "asc";

            Configuracion_de_RutinasPropertyMapper oConfiguracion_de_RutinasPropertyMapper = new Configuracion_de_RutinasPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oConfiguracion_de_RutinasPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IConfiguracion_de_RutinasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Configuracion_de_Rutinass == null)
                result.Configuracion_de_Rutinass = new List<Configuracion_de_Rutinas>();

            var data = result.Configuracion_de_Rutinass.Select(m => new Configuracion_de_RutinasGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,Tipo_de_RutinaTipo_de_Rutina = CultureHelper.GetTraduction(m.Tipo_de_Rutina_Tipo_de_Ejercicio_Rutina.Folio.ToString(), "Tipo_de_Rutina") ?? (string)m.Tipo_de_Rutina_Tipo_de_Ejercicio_Rutina.Tipo_de_Rutina
                        ,Nivel_de_DificultadDificultad = CultureHelper.GetTraduction(m.Nivel_de_Dificultad_Nivel_de_dificultad.Folio.ToString(), "Dificultad") ?? (string)m.Nivel_de_Dificultad_Nivel_de_dificultad.Dificultad
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
			,Cantidad_de_ejercicios = m.Cantidad_de_ejercicios
			,Cantidad_de_series = m.Cantidad_de_series
			,Cantidad_de_repeticiones = m.Cantidad_de_repeticiones
			,Descanso_segundos = m.Descanso_segundos
			,Texto_Ejercicios = m.Texto_Ejercicios
			,Lleva_Calentamiento = m.Lleva_Calentamiento
			,Lleva_Enfriamiento = m.Lleva_Enfriamiento
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(44613, arrayColumnsVisible), "Configuracion_de_RutinasList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(44613, arrayColumnsVisible), "Configuracion_de_RutinasList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(44613, arrayColumnsVisible), "Configuracion_de_RutinasList_" + DateTime.Now.ToString());
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

            _IConfiguracion_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Configuracion_de_RutinasPropertyMapper());
				
				
            if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
			if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (Configuracion_de_RutinasAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            Configuracion_de_RutinasPropertyMapper oConfiguracion_de_RutinasPropertyMapper = new Configuracion_de_RutinasPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oConfiguracion_de_RutinasPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
			
			if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IConfiguracion_de_RutinasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Configuracion_de_Rutinass == null)
                result.Configuracion_de_Rutinass = new List<Configuracion_de_Rutinas>();

            var data = result.Configuracion_de_Rutinass.Select(m => new Configuracion_de_RutinasGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,Tipo_de_RutinaTipo_de_Rutina = CultureHelper.GetTraduction(m.Tipo_de_Rutina_Tipo_de_Ejercicio_Rutina.Folio.ToString(), "Tipo_de_Rutina") ?? (string)m.Tipo_de_Rutina_Tipo_de_Ejercicio_Rutina.Tipo_de_Rutina
                        ,Nivel_de_DificultadDificultad = CultureHelper.GetTraduction(m.Nivel_de_Dificultad_Nivel_de_dificultad.Folio.ToString(), "Dificultad") ?? (string)m.Nivel_de_Dificultad_Nivel_de_dificultad.Dificultad
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
			,Cantidad_de_ejercicios = m.Cantidad_de_ejercicios
			,Cantidad_de_series = m.Cantidad_de_series
			,Cantidad_de_repeticiones = m.Cantidad_de_repeticiones
			,Descanso_segundos = m.Descanso_segundos
			,Texto_Ejercicios = m.Texto_Ejercicios
			,Lleva_Calentamiento = m.Lleva_Calentamiento
			,Lleva_Enfriamiento = m.Lleva_Enfriamiento
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion

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
                _IConfiguracion_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IConfiguracion_de_RutinasApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpPost]
        public ActionResult Post_Datos_Generales(Configuracion_de_Rutinas_Datos_GeneralesModel varConfiguracion_de_Rutinas)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IConfiguracion_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Configuracion_de_Rutinas_Datos_GeneralesInfo = new Configuracion_de_Rutinas_Datos_Generales
                {
                    Folio = varConfiguracion_de_Rutinas.Folio
                                            ,Fecha_de_Registro = (!String.IsNullOrEmpty(varConfiguracion_de_Rutinas.Fecha_de_Registro)) ? DateTime.ParseExact(varConfiguracion_de_Rutinas.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varConfiguracion_de_Rutinas.Hora_de_Registro
                        ,Usuario_que_Registra = varConfiguracion_de_Rutinas.Usuario_que_Registra
                        ,Tipo_de_Rutina = varConfiguracion_de_Rutinas.Tipo_de_Rutina
                        ,Nivel_de_Dificultad = varConfiguracion_de_Rutinas.Nivel_de_Dificultad
                        ,Sexo = varConfiguracion_de_Rutinas.Sexo
                        ,Cantidad_de_ejercicios = varConfiguracion_de_Rutinas.Cantidad_de_ejercicios
                        ,Cantidad_de_series = varConfiguracion_de_Rutinas.Cantidad_de_series
                        ,Cantidad_de_repeticiones = varConfiguracion_de_Rutinas.Cantidad_de_repeticiones
                        ,Descanso_segundos = varConfiguracion_de_Rutinas.Descanso_segundos
                        ,Texto_Ejercicios = varConfiguracion_de_Rutinas.Texto_Ejercicios
                        ,Lleva_Calentamiento = varConfiguracion_de_Rutinas.Lleva_Calentamiento
                        ,Lleva_Enfriamiento = varConfiguracion_de_Rutinas.Lleva_Enfriamiento
                        ,Estatus = varConfiguracion_de_Rutinas.Estatus
                    
                };

                result = _IConfiguracion_de_RutinasApiConsumer.Update_Datos_Generales(Configuracion_de_Rutinas_Datos_GeneralesInfo).Resource.ToString();
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
                _IConfiguracion_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IConfiguracion_de_RutinasApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Secuencia_de_Ejercicios;
                var Detalle_Secuencia_de_EjerciciosData = GetDetalle_Secuencia_de_EjerciciosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Secuencia_de_Ejercicios);

                var result = new Configuracion_de_Rutinas_Datos_GeneralesModel
                {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_Registra = m.Usuario_que_Registra
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,Tipo_de_Rutina = m.Tipo_de_Rutina
                        ,Tipo_de_RutinaTipo_de_Rutina = CultureHelper.GetTraduction(m.Tipo_de_Rutina_Tipo_de_Ejercicio_Rutina.Folio.ToString(), "Tipo_de_Rutina") ?? (string)m.Tipo_de_Rutina_Tipo_de_Ejercicio_Rutina.Tipo_de_Rutina
                        ,Nivel_de_Dificultad = m.Nivel_de_Dificultad
                        ,Nivel_de_DificultadDificultad = CultureHelper.GetTraduction(m.Nivel_de_Dificultad_Nivel_de_dificultad.Folio.ToString(), "Dificultad") ?? (string)m.Nivel_de_Dificultad_Nivel_de_dificultad.Dificultad
                        ,Sexo = m.Sexo
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
			,Cantidad_de_ejercicios = m.Cantidad_de_ejercicios
			,Cantidad_de_series = m.Cantidad_de_series
			,Cantidad_de_repeticiones = m.Cantidad_de_repeticiones
			,Descanso_segundos = m.Descanso_segundos
			,Texto_Ejercicios = m.Texto_Ejercicios
			,Lleva_Calentamiento = m.Lleva_Calentamiento
			,Lleva_Enfriamiento = m.Lleva_Enfriamiento
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion

                    
                };
				var resultData = new
                {
                    data = result
                    ,Secuencia_de_Ejercicios = Detalle_Secuencia_de_EjerciciosData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }


    }
}

