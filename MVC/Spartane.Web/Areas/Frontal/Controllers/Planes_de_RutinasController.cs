using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Planes_de_Rutinas;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Pacientes;
using Spartane.Core.Domain.Nivel_de_dificultad;
using Spartane.Core.Domain.Semanas_Planes;
using Spartane.Core.Domain.Estatus;
using Spartane.Core.Domain.Rutinas;
using Spartane.Core.Domain.Detalle_Planes_de_Rutinas;

using Spartane.Core.Domain.Dias_de_la_semana;



using Spartane.Core.Domain.Tipo_de_Enfoque_del_Ejercicio;
using Spartane.Core.Domain.Ejercicios;


using Spartane.Core.Domain.Estatus_Plan_de_Rutinas;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Planes_de_Rutinas;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Planes_de_Rutinas;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Pacientes;
using Spartane.Web.Areas.WebApiConsumer.Nivel_de_dificultad;
using Spartane.Web.Areas.WebApiConsumer.Semanas_Planes;
using Spartane.Web.Areas.WebApiConsumer.Estatus;
using Spartane.Web.Areas.WebApiConsumer.Rutinas;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Planes_de_Rutinas;

using Spartane.Web.Areas.WebApiConsumer.Dias_de_la_semana;

using Spartane.Web.Areas.WebApiConsumer.Tipo_de_Enfoque_del_Ejercicio;
using Spartane.Web.Areas.WebApiConsumer.Ejercicios;


using Spartane.Web.Areas.WebApiConsumer.Estatus_Plan_de_Rutinas;

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
    public class Planes_de_RutinasController : Controller
    {
        #region "variable declaration"

        private IPlanes_de_RutinasService service = null;
        private IPlanes_de_RutinasApiConsumer _IPlanes_de_RutinasApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private IPacientesApiConsumer _IPacientesApiConsumer;
        private INivel_de_dificultadApiConsumer _INivel_de_dificultadApiConsumer;
        private ISemanas_PlanesApiConsumer _ISemanas_PlanesApiConsumer;
        private IEstatusApiConsumer _IEstatusApiConsumer;
        private IRutinasApiConsumer _IRutinasApiConsumer;
        private IDetalle_Planes_de_RutinasApiConsumer _IDetalle_Planes_de_RutinasApiConsumer;

        private IDias_de_la_semanaApiConsumer _IDias_de_la_semanaApiConsumer;

        private ITipo_de_Enfoque_del_EjercicioApiConsumer _ITipo_de_Enfoque_del_EjercicioApiConsumer;
        private IEjerciciosApiConsumer _IEjerciciosApiConsumer;


        private IEstatus_Plan_de_RutinasApiConsumer _IEstatus_Plan_de_RutinasApiConsumer;

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

        
        public Planes_de_RutinasController(IPlanes_de_RutinasService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IPlanes_de_RutinasApiConsumer Planes_de_RutinasApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer , IPacientesApiConsumer PacientesApiConsumer , INivel_de_dificultadApiConsumer Nivel_de_dificultadApiConsumer , ISemanas_PlanesApiConsumer Semanas_PlanesApiConsumer , IEstatusApiConsumer EstatusApiConsumer , IRutinasApiConsumer RutinasApiConsumer , IDetalle_Planes_de_RutinasApiConsumer Detalle_Planes_de_RutinasApiConsumer , IDias_de_la_semanaApiConsumer Dias_de_la_semanaApiConsumer , ITipo_de_Enfoque_del_EjercicioApiConsumer Tipo_de_Enfoque_del_EjercicioApiConsumer , IEjerciciosApiConsumer EjerciciosApiConsumer  , IEstatus_Plan_de_RutinasApiConsumer Estatus_Plan_de_RutinasApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IPlanes_de_RutinasApiConsumer = Planes_de_RutinasApiConsumer;
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
            this._IPacientesApiConsumer = PacientesApiConsumer;
            this._INivel_de_dificultadApiConsumer = Nivel_de_dificultadApiConsumer;
            this._ISemanas_PlanesApiConsumer = Semanas_PlanesApiConsumer;
            this._IEstatusApiConsumer = EstatusApiConsumer;
            this._IRutinasApiConsumer = RutinasApiConsumer;
            this._IDetalle_Planes_de_RutinasApiConsumer = Detalle_Planes_de_RutinasApiConsumer;

            this._IDias_de_la_semanaApiConsumer = Dias_de_la_semanaApiConsumer;

            this._ITipo_de_Enfoque_del_EjercicioApiConsumer = Tipo_de_Enfoque_del_EjercicioApiConsumer;
            this._IEjerciciosApiConsumer = EjerciciosApiConsumer;


            this._IEstatus_Plan_de_RutinasApiConsumer = Estatus_Plan_de_RutinasApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Planes_de_Rutinas
        [ObjectAuth(ObjectId = (ModuleObjectId)44570, PermissionType = PermissionTypes.Consult)]
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
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44570, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			          
            return View();
        }

        // GET: Frontal/Planes_de_Rutinas/Create
          [ObjectAuth(ObjectId = (ModuleObjectId)44570, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44570, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varPlanes_de_Rutinas = new Planes_de_RutinasModel();
			varPlanes_de_Rutinas.Folio = Id;
			
            ViewBag.ObjectId = "44570";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;

            var permissionDetalle_Planes_de_Rutinas = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44571, ModuleId);
            ViewBag.PermissionDetalle_Planes_de_Rutinas = permissionDetalle_Planes_de_Rutinas;


            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
				
				_tokenManager.GenerateToken();
				_ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _IPlanes_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Planes_de_RutinassData = _IPlanes_de_RutinasApiConsumer.ListaSelAll(0, 1000, "Planes_de_Rutinas.Folio=" + Id, "").Resource.Planes_de_Rutinass;
				
				if (Planes_de_RutinassData != null && Planes_de_RutinassData.Count > 0)
                {
					var Planes_de_RutinasData = Planes_de_RutinassData.First();
					varPlanes_de_Rutinas= new Planes_de_RutinasModel
					{
						Folio  = Planes_de_RutinasData.Folio 
	                    ,Fecha_de_Registro = (Planes_de_RutinasData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(Planes_de_RutinasData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = Planes_de_RutinasData.Hora_de_Registro
                    ,Usuario_que_Registra = Planes_de_RutinasData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(Planes_de_RutinasData.Usuario_que_Registra), "Spartan_User") ??  (string)Planes_de_RutinasData.Usuario_que_Registra_Spartan_User.Name
                    ,Paciente = Planes_de_RutinasData.Paciente
                    ,PacienteNombre_Completo = CultureHelper.GetTraduction(Convert.ToString(Planes_de_RutinasData.Paciente), "Pacientes") ??  (string)Planes_de_RutinasData.Paciente_Pacientes.Nombre_Completo
                    ,Nivel_de_dificultad = Planes_de_RutinasData.Nivel_de_dificultad
                    ,Nivel_de_dificultadDificultad = CultureHelper.GetTraduction(Convert.ToString(Planes_de_RutinasData.Nivel_de_dificultad), "Nivel_de_dificultad") ??  (string)Planes_de_RutinasData.Nivel_de_dificultad_Nivel_de_dificultad.Dificultad
                    ,Semana = Planes_de_RutinasData.Semana
                    ,SemanaSemana = CultureHelper.GetTraduction(Convert.ToString(Planes_de_RutinasData.Semana), "Semanas_Planes") ??  (string)Planes_de_RutinasData.Semana_Semanas_Planes.Semana
                    ,Fecha_inicio_del_Plan = (Planes_de_RutinasData.Fecha_inicio_del_Plan == null ? string.Empty : Convert.ToDateTime(Planes_de_RutinasData.Fecha_inicio_del_Plan).ToString(ConfigurationProperty.DateFormat))
                    ,Fecha_fin_del_Plan = (Planes_de_RutinasData.Fecha_fin_del_Plan == null ? string.Empty : Convert.ToDateTime(Planes_de_RutinasData.Fecha_fin_del_Plan).ToString(ConfigurationProperty.DateFormat))
                    ,Estatus = Planes_de_RutinasData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Planes_de_RutinasData.Estatus), "Estatus") ??  (string)Planes_de_RutinasData.Estatus_Estatus.Descripcion
                    ,Rutina = Planes_de_RutinasData.Rutina
                    ,RutinaNombre_de_la_Rutina = CultureHelper.GetTraduction(Convert.ToString(Planes_de_RutinasData.Rutina), "Rutinas") ??  (string)Planes_de_RutinasData.Rutina_Rutinas.Nombre_de_la_Rutina
                    ,Estatus_de_Seguimiento = Planes_de_RutinasData.Estatus_de_Seguimiento
                    ,Estatus_de_SeguimientoDescripcion = CultureHelper.GetTraduction(Convert.ToString(Planes_de_RutinasData.Estatus_de_Seguimiento), "Estatus_Plan_de_Rutinas") ??  (string)Planes_de_RutinasData.Estatus_de_Seguimiento_Estatus_Plan_de_Rutinas.Descripcion

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
            _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Pacientess_Paciente = _IPacientesApiConsumer.SelAll(true);
            if (Pacientess_Paciente != null && Pacientess_Paciente.Resource != null)
                ViewBag.Pacientess_Paciente = Pacientess_Paciente.Resource.Where(m => m.Nombre_Completo != null).OrderBy(m => m.Nombre_Completo).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Pacientes", "Nombre_Completo") ?? m.Nombre_Completo.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _INivel_de_dificultadApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Nivel_de_dificultads_Nivel_de_dificultad = _INivel_de_dificultadApiConsumer.SelAll(true);
            if (Nivel_de_dificultads_Nivel_de_dificultad != null && Nivel_de_dificultads_Nivel_de_dificultad.Resource != null)
                ViewBag.Nivel_de_dificultads_Nivel_de_dificultad = Nivel_de_dificultads_Nivel_de_dificultad.Resource.Where(m => m.Dificultad != null).OrderBy(m => m.Dificultad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Nivel_de_dificultad", "Dificultad") ?? m.Dificultad.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISemanas_PlanesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Semanas_Planess_Semana = _ISemanas_PlanesApiConsumer.SelAll(true);
            if (Semanas_Planess_Semana != null && Semanas_Planess_Semana.Resource != null)
                ViewBag.Semanas_Planess_Semana = Semanas_Planess_Semana.Resource.Where(m => m.Semana != null).OrderBy(m => m.Semana).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Semanas_Planes", "Semana") ?? m.Semana.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Rutinass_Rutina = _IRutinasApiConsumer.SelAll(true);
            if (Rutinass_Rutina != null && Rutinass_Rutina.Resource != null)
                ViewBag.Rutinass_Rutina = Rutinass_Rutina.Resource.Where(m => m.Nombre_de_la_Rutina != null).OrderBy(m => m.Nombre_de_la_Rutina).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Rutinas", "Nombre_de_la_Rutina") ?? m.Nombre_de_la_Rutina.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IEstatus_Plan_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_Plan_de_Rutinass_Estatus_de_Seguimiento = _IEstatus_Plan_de_RutinasApiConsumer.SelAll(true);
            if (Estatus_Plan_de_Rutinass_Estatus_de_Seguimiento != null && Estatus_Plan_de_Rutinass_Estatus_de_Seguimiento.Resource != null)
                ViewBag.Estatus_Plan_de_Rutinass_Estatus_de_Seguimiento = Estatus_Plan_de_Rutinass_Estatus_de_Seguimiento.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Estatus_Plan_de_Rutinas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
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

            /*CODMANINI-ADD*/
            if (permission.Role == (int)Spartane.Core.Enums.SpartanRoleEnum.PacienteParticular || permission.Role == (int)Spartane.Core.Enums.SpartanRoleEnum.PacienteEmpresa)
                return View("Planes", varPlanes_de_Rutinas);
            /*CODMANFIN-ADD*/
            return View(varPlanes_de_Rutinas);
        }


        /*CODMANINI-ADD*/
        public ActionResult MostrarEjercicios(int Id = 0, int consult = 0, int ModuleId = 0)
        {
            if (ModuleId == 0)
            {
                ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            }
            else
                Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44570, ModuleId);
            if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varPlanes_de_Rutinas = new Planes_de_RutinasModel();
            varPlanes_de_Rutinas.Folio = Id;

            ViewBag.ObjectId = "44570";
            ViewBag.Operation = "New";

            ViewBag.IsNew = true;

            var permissionDetalle_Planes_de_Rutinas = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44571, ModuleId);
            ViewBag.PermissionDetalle_Planes_de_Rutinas = permissionDetalle_Planes_de_Rutinas;


            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {
                ViewBag.IsNew = false;
                ViewBag.Operation = "Update";

                _tokenManager.GenerateToken();
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _IPlanes_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Planes_de_RutinassData = _IPlanes_de_RutinasApiConsumer.ListaSelAll(0, 1000, "Planes_de_Rutinas.Folio=" + Id, "").Resource.Planes_de_Rutinass;

                if (Planes_de_RutinassData != null && Planes_de_RutinassData.Count > 0)
                {
                    var Planes_de_RutinasData = Planes_de_RutinassData.First();
                    varPlanes_de_Rutinas = new Planes_de_RutinasModel
                    {
                        Folio = Planes_de_RutinasData.Folio
                        ,
                        Fecha_de_Registro = (Planes_de_RutinasData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(Planes_de_RutinasData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,
                        Hora_de_Registro = Planes_de_RutinasData.Hora_de_Registro
                    ,
                        Usuario_que_Registra = Planes_de_RutinasData.Usuario_que_Registra
                    ,
                        Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(Planes_de_RutinasData.Usuario_que_Registra), "Spartan_User") ?? (string)Planes_de_RutinasData.Usuario_que_Registra_Spartan_User.Name
                    ,
                        Paciente = Planes_de_RutinasData.Paciente
                    ,
                        PacienteNombre_Completo = CultureHelper.GetTraduction(Convert.ToString(Planes_de_RutinasData.Paciente), "Pacientes") ?? (string)Planes_de_RutinasData.Paciente_Pacientes.Nombre_Completo
                    ,
                        Nivel_de_dificultad = Planes_de_RutinasData.Nivel_de_dificultad
                    ,
                        Nivel_de_dificultadDificultad = CultureHelper.GetTraduction(Convert.ToString(Planes_de_RutinasData.Nivel_de_dificultad), "Nivel_de_dificultad") ?? (string)Planes_de_RutinasData.Nivel_de_dificultad_Nivel_de_dificultad.Dificultad
                    ,
                        Semana = Planes_de_RutinasData.Semana
                    ,
                        SemanaSemana = CultureHelper.GetTraduction(Convert.ToString(Planes_de_RutinasData.Semana), "Semanas_Planes") ?? (string)Planes_de_RutinasData.Semana_Semanas_Planes.Semana
                    ,
                        Fecha_inicio_del_Plan = (Planes_de_RutinasData.Fecha_inicio_del_Plan == null ? string.Empty : Convert.ToDateTime(Planes_de_RutinasData.Fecha_inicio_del_Plan).ToString(ConfigurationProperty.DateFormat))
                    ,
                        Fecha_fin_del_Plan = (Planes_de_RutinasData.Fecha_fin_del_Plan == null ? string.Empty : Convert.ToDateTime(Planes_de_RutinasData.Fecha_fin_del_Plan).ToString(ConfigurationProperty.DateFormat))
                    ,
                        Estatus = Planes_de_RutinasData.Estatus
                    ,
                        EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Planes_de_RutinasData.Estatus), "Estatus") ?? (string)Planes_de_RutinasData.Estatus_Estatus.Descripcion
                    ,
                        Rutina = Planes_de_RutinasData.Rutina
                    ,
                        RutinaNombre_de_la_Rutina = CultureHelper.GetTraduction(Convert.ToString(Planes_de_RutinasData.Rutina), "Rutinas") ?? (string)Planes_de_RutinasData.Rutina_Rutinas.Nombre_de_la_Rutina
                    ,
                        Estatus_de_Seguimiento = Planes_de_RutinasData.Estatus_de_Seguimiento
                    ,
                        Estatus_de_SeguimientoDescripcion = CultureHelper.GetTraduction(Convert.ToString(Planes_de_RutinasData.Estatus_de_Seguimiento), "Estatus_Plan_de_Rutinas") ?? (string)Planes_de_RutinasData.Estatus_de_Seguimiento_Estatus_Plan_de_Rutinas.Descripcion

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
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(),
                    Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Pacientess_Paciente = _IPacientesApiConsumer.SelAll(true);
            if (Pacientess_Paciente != null && Pacientess_Paciente.Resource != null)
                ViewBag.Pacientess_Paciente = Pacientess_Paciente.Resource.Where(m => m.Nombre_Completo != null).OrderBy(m => m.Nombre_Completo).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Pacientes", "Nombre_Completo") ?? m.Nombre_Completo.ToString(),
                    Value = Convert.ToString(m.Folio)
                }).ToList();
            _INivel_de_dificultadApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Nivel_de_dificultads_Nivel_de_dificultad = _INivel_de_dificultadApiConsumer.SelAll(true);
            if (Nivel_de_dificultads_Nivel_de_dificultad != null && Nivel_de_dificultads_Nivel_de_dificultad.Resource != null)
                ViewBag.Nivel_de_dificultads_Nivel_de_dificultad = Nivel_de_dificultads_Nivel_de_dificultad.Resource.Where(m => m.Dificultad != null).OrderBy(m => m.Dificultad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Nivel_de_dificultad", "Dificultad") ?? m.Dificultad.ToString(),
                    Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISemanas_PlanesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Semanas_Planess_Semana = _ISemanas_PlanesApiConsumer.SelAll(true);
            if (Semanas_Planess_Semana != null && Semanas_Planess_Semana.Resource != null)
                ViewBag.Semanas_Planess_Semana = Semanas_Planess_Semana.Resource.Where(m => m.Semana != null).OrderBy(m => m.Semana).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Semanas_Planes", "Semana") ?? m.Semana.ToString(),
                    Value = Convert.ToString(m.Folio)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(),
                    Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Rutinass_Rutina = _IRutinasApiConsumer.SelAll(true);
            if (Rutinass_Rutina != null && Rutinass_Rutina.Resource != null)
                ViewBag.Rutinass_Rutina = Rutinass_Rutina.Resource.Where(m => m.Nombre_de_la_Rutina != null).OrderBy(m => m.Nombre_de_la_Rutina).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Rutinas", "Nombre_de_la_Rutina") ?? m.Nombre_de_la_Rutina.ToString(),
                    Value = Convert.ToString(m.Folio)
                }).ToList();
            _IEstatus_Plan_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_Plan_de_Rutinass_Estatus_de_Seguimiento = _IEstatus_Plan_de_RutinasApiConsumer.SelAll(true);
            if (Estatus_Plan_de_Rutinass_Estatus_de_Seguimiento != null && Estatus_Plan_de_Rutinass_Estatus_de_Seguimiento.Resource != null)
                ViewBag.Estatus_Plan_de_Rutinass_Estatus_de_Seguimiento = Estatus_Plan_de_Rutinass_Estatus_de_Seguimiento.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Estatus_Plan_de_Rutinas", "Descripcion") ?? m.Descripcion.ToString(),
                    Value = Convert.ToString(m.Folio)
                }).ToList();


            ViewBag.Consult = consult == 1;
            if (consult == 1)
                ViewBag.Operation = "Consult";

            var isPartial = false;
            var isMR = false;
            var nameMR = string.Empty;
            var nameAttribute = string.Empty;

            if (Request.QueryString["isPartial"] != null)
                isPartial = Convert.ToBoolean(Request.QueryString["isPartial"]);

            if (Request.QueryString["isMR"] != null)
                isMR = Convert.ToBoolean(Request.QueryString["isMR"]);

            if (Request.QueryString["nameMR"] != null)
                nameMR = Request.QueryString["nameMR"].ToString();

            if (Request.QueryString["nameAttribute"] != null)
                nameAttribute = Request.QueryString["nameAttribute"].ToString();

            ViewBag.isPartial = isPartial;
            ViewBag.isMR = isMR;
            ViewBag.nameMR = nameMR;
            ViewBag.nameAttribute = nameAttribute;

            return View("ListaEjercicios", varPlanes_de_Rutinas);
        }
        /*CODMANFIN-ADD*/


        [HttpGet]
        public ActionResult AddPlanes_de_Rutinas(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44570);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IPlanes_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
			Planes_de_RutinasModel varPlanes_de_Rutinas= new Planes_de_RutinasModel();
            var permissionDetalle_Planes_de_Rutinas = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44571, ModuleId);
            ViewBag.PermissionDetalle_Planes_de_Rutinas = permissionDetalle_Planes_de_Rutinas;


            if (id.ToString() != "0")
            {
                var Planes_de_RutinassData = _IPlanes_de_RutinasApiConsumer.ListaSelAll(0, 1000, "Planes_de_Rutinas.Folio=" + id, "").Resource.Planes_de_Rutinass;
				
				if (Planes_de_RutinassData != null && Planes_de_RutinassData.Count > 0)
                {
					var Planes_de_RutinasData = Planes_de_RutinassData.First();
					varPlanes_de_Rutinas= new Planes_de_RutinasModel
					{
						Folio  = Planes_de_RutinasData.Folio 
	                    ,Fecha_de_Registro = (Planes_de_RutinasData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(Planes_de_RutinasData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = Planes_de_RutinasData.Hora_de_Registro
                    ,Usuario_que_Registra = Planes_de_RutinasData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(Planes_de_RutinasData.Usuario_que_Registra), "Spartan_User") ??  (string)Planes_de_RutinasData.Usuario_que_Registra_Spartan_User.Name
                    ,Paciente = Planes_de_RutinasData.Paciente
                    ,PacienteNombre_Completo = CultureHelper.GetTraduction(Convert.ToString(Planes_de_RutinasData.Paciente), "Pacientes") ??  (string)Planes_de_RutinasData.Paciente_Pacientes.Nombre_Completo
                    ,Nivel_de_dificultad = Planes_de_RutinasData.Nivel_de_dificultad
                    ,Nivel_de_dificultadDificultad = CultureHelper.GetTraduction(Convert.ToString(Planes_de_RutinasData.Nivel_de_dificultad), "Nivel_de_dificultad") ??  (string)Planes_de_RutinasData.Nivel_de_dificultad_Nivel_de_dificultad.Dificultad
                    ,Semana = Planes_de_RutinasData.Semana
                    ,SemanaSemana = CultureHelper.GetTraduction(Convert.ToString(Planes_de_RutinasData.Semana), "Semanas_Planes") ??  (string)Planes_de_RutinasData.Semana_Semanas_Planes.Semana
                    ,Fecha_inicio_del_Plan = (Planes_de_RutinasData.Fecha_inicio_del_Plan == null ? string.Empty : Convert.ToDateTime(Planes_de_RutinasData.Fecha_inicio_del_Plan).ToString(ConfigurationProperty.DateFormat))
                    ,Fecha_fin_del_Plan = (Planes_de_RutinasData.Fecha_fin_del_Plan == null ? string.Empty : Convert.ToDateTime(Planes_de_RutinasData.Fecha_fin_del_Plan).ToString(ConfigurationProperty.DateFormat))
                    ,Estatus = Planes_de_RutinasData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Planes_de_RutinasData.Estatus), "Estatus") ??  (string)Planes_de_RutinasData.Estatus_Estatus.Descripcion
                    ,Rutina = Planes_de_RutinasData.Rutina
                    ,RutinaNombre_de_la_Rutina = CultureHelper.GetTraduction(Convert.ToString(Planes_de_RutinasData.Rutina), "Rutinas") ??  (string)Planes_de_RutinasData.Rutina_Rutinas.Nombre_de_la_Rutina
                    ,Estatus_de_Seguimiento = Planes_de_RutinasData.Estatus_de_Seguimiento
                    ,Estatus_de_SeguimientoDescripcion = CultureHelper.GetTraduction(Convert.ToString(Planes_de_RutinasData.Estatus_de_Seguimiento), "Estatus_Plan_de_Rutinas") ??  (string)Planes_de_RutinasData.Estatus_de_Seguimiento_Estatus_Plan_de_Rutinas.Descripcion

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
            _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Pacientess_Paciente = _IPacientesApiConsumer.SelAll(true);
            if (Pacientess_Paciente != null && Pacientess_Paciente.Resource != null)
                ViewBag.Pacientess_Paciente = Pacientess_Paciente.Resource.Where(m => m.Nombre_Completo != null).OrderBy(m => m.Nombre_Completo).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Pacientes", "Nombre_Completo") ?? m.Nombre_Completo.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _INivel_de_dificultadApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Nivel_de_dificultads_Nivel_de_dificultad = _INivel_de_dificultadApiConsumer.SelAll(true);
            if (Nivel_de_dificultads_Nivel_de_dificultad != null && Nivel_de_dificultads_Nivel_de_dificultad.Resource != null)
                ViewBag.Nivel_de_dificultads_Nivel_de_dificultad = Nivel_de_dificultads_Nivel_de_dificultad.Resource.Where(m => m.Dificultad != null).OrderBy(m => m.Dificultad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Nivel_de_dificultad", "Dificultad") ?? m.Dificultad.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISemanas_PlanesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Semanas_Planess_Semana = _ISemanas_PlanesApiConsumer.SelAll(true);
            if (Semanas_Planess_Semana != null && Semanas_Planess_Semana.Resource != null)
                ViewBag.Semanas_Planess_Semana = Semanas_Planess_Semana.Resource.Where(m => m.Semana != null).OrderBy(m => m.Semana).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Semanas_Planes", "Semana") ?? m.Semana.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Rutinass_Rutina = _IRutinasApiConsumer.SelAll(true);
            if (Rutinass_Rutina != null && Rutinass_Rutina.Resource != null)
                ViewBag.Rutinass_Rutina = Rutinass_Rutina.Resource.Where(m => m.Nombre_de_la_Rutina != null).OrderBy(m => m.Nombre_de_la_Rutina).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Rutinas", "Nombre_de_la_Rutina") ?? m.Nombre_de_la_Rutina.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IEstatus_Plan_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_Plan_de_Rutinass_Estatus_de_Seguimiento = _IEstatus_Plan_de_RutinasApiConsumer.SelAll(true);
            if (Estatus_Plan_de_Rutinass_Estatus_de_Seguimiento != null && Estatus_Plan_de_Rutinass_Estatus_de_Seguimiento.Resource != null)
                ViewBag.Estatus_Plan_de_Rutinass_Estatus_de_Seguimiento = Estatus_Plan_de_Rutinass_Estatus_de_Seguimiento.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Estatus_Plan_de_Rutinas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            return PartialView("AddPlanes_de_Rutinas", varPlanes_de_Rutinas);
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
        public ActionResult GetPacientesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPacientesApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Nombre_Completo).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Pacientes", "Nombre_Completo")?? m.Nombre_Completo,
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
        public ActionResult GetSemanas_PlanesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISemanas_PlanesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISemanas_PlanesApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Semana).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Semanas_Planes", "Semana")?? m.Semana,
                    Value = Convert.ToString(m.Folio)
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
        [HttpGet]
        public ActionResult GetRutinasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IRutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IRutinasApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Nombre_de_la_Rutina).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Rutinas", "Nombre_de_la_Rutina")?? m.Nombre_de_la_Rutina,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetEstatus_Plan_de_RutinasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatus_Plan_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstatus_Plan_de_RutinasApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Estatus_Plan_de_Rutinas", "Descripcion")?? m.Descripcion,
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
        public ActionResult ShowAdvanceFilter(Planes_de_RutinasAdvanceSearchModel model, int idFilter = -1)
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
            _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Pacientess_Paciente = _IPacientesApiConsumer.SelAll(true);
            if (Pacientess_Paciente != null && Pacientess_Paciente.Resource != null)
                ViewBag.Pacientess_Paciente = Pacientess_Paciente.Resource.Where(m => m.Nombre_Completo != null).OrderBy(m => m.Nombre_Completo).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Pacientes", "Nombre_Completo") ?? m.Nombre_Completo.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _INivel_de_dificultadApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Nivel_de_dificultads_Nivel_de_dificultad = _INivel_de_dificultadApiConsumer.SelAll(true);
            if (Nivel_de_dificultads_Nivel_de_dificultad != null && Nivel_de_dificultads_Nivel_de_dificultad.Resource != null)
                ViewBag.Nivel_de_dificultads_Nivel_de_dificultad = Nivel_de_dificultads_Nivel_de_dificultad.Resource.Where(m => m.Dificultad != null).OrderBy(m => m.Dificultad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Nivel_de_dificultad", "Dificultad") ?? m.Dificultad.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISemanas_PlanesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Semanas_Planess_Semana = _ISemanas_PlanesApiConsumer.SelAll(true);
            if (Semanas_Planess_Semana != null && Semanas_Planess_Semana.Resource != null)
                ViewBag.Semanas_Planess_Semana = Semanas_Planess_Semana.Resource.Where(m => m.Semana != null).OrderBy(m => m.Semana).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Semanas_Planes", "Semana") ?? m.Semana.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Rutinass_Rutina = _IRutinasApiConsumer.SelAll(true);
            if (Rutinass_Rutina != null && Rutinass_Rutina.Resource != null)
                ViewBag.Rutinass_Rutina = Rutinass_Rutina.Resource.Where(m => m.Nombre_de_la_Rutina != null).OrderBy(m => m.Nombre_de_la_Rutina).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Rutinas", "Nombre_de_la_Rutina") ?? m.Nombre_de_la_Rutina.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IEstatus_Plan_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_Plan_de_Rutinass_Estatus_de_Seguimiento = _IEstatus_Plan_de_RutinasApiConsumer.SelAll(true);
            if (Estatus_Plan_de_Rutinass_Estatus_de_Seguimiento != null && Estatus_Plan_de_Rutinass_Estatus_de_Seguimiento.Resource != null)
                ViewBag.Estatus_Plan_de_Rutinass_Estatus_de_Seguimiento = Estatus_Plan_de_Rutinass_Estatus_de_Seguimiento.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Estatus_Plan_de_Rutinas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
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
            _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Pacientess_Paciente = _IPacientesApiConsumer.SelAll(true);
            if (Pacientess_Paciente != null && Pacientess_Paciente.Resource != null)
                ViewBag.Pacientess_Paciente = Pacientess_Paciente.Resource.Where(m => m.Nombre_Completo != null).OrderBy(m => m.Nombre_Completo).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Pacientes", "Nombre_Completo") ?? m.Nombre_Completo.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _INivel_de_dificultadApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Nivel_de_dificultads_Nivel_de_dificultad = _INivel_de_dificultadApiConsumer.SelAll(true);
            if (Nivel_de_dificultads_Nivel_de_dificultad != null && Nivel_de_dificultads_Nivel_de_dificultad.Resource != null)
                ViewBag.Nivel_de_dificultads_Nivel_de_dificultad = Nivel_de_dificultads_Nivel_de_dificultad.Resource.Where(m => m.Dificultad != null).OrderBy(m => m.Dificultad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Nivel_de_dificultad", "Dificultad") ?? m.Dificultad.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISemanas_PlanesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Semanas_Planess_Semana = _ISemanas_PlanesApiConsumer.SelAll(true);
            if (Semanas_Planess_Semana != null && Semanas_Planess_Semana.Resource != null)
                ViewBag.Semanas_Planess_Semana = Semanas_Planess_Semana.Resource.Where(m => m.Semana != null).OrderBy(m => m.Semana).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Semanas_Planes", "Semana") ?? m.Semana.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Rutinass_Rutina = _IRutinasApiConsumer.SelAll(true);
            if (Rutinass_Rutina != null && Rutinass_Rutina.Resource != null)
                ViewBag.Rutinass_Rutina = Rutinass_Rutina.Resource.Where(m => m.Nombre_de_la_Rutina != null).OrderBy(m => m.Nombre_de_la_Rutina).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Rutinas", "Nombre_de_la_Rutina") ?? m.Nombre_de_la_Rutina.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IEstatus_Plan_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_Plan_de_Rutinass_Estatus_de_Seguimiento = _IEstatus_Plan_de_RutinasApiConsumer.SelAll(true);
            if (Estatus_Plan_de_Rutinass_Estatus_de_Seguimiento != null && Estatus_Plan_de_Rutinass_Estatus_de_Seguimiento.Resource != null)
                ViewBag.Estatus_Plan_de_Rutinass_Estatus_de_Seguimiento = Estatus_Plan_de_Rutinass_Estatus_de_Seguimiento.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Estatus_Plan_de_Rutinas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            var previousFiltersObj = new Planes_de_RutinasAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Planes_de_RutinasAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Planes_de_RutinasAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Planes_de_RutinasPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IPlanes_de_RutinasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Planes_de_Rutinass == null)
                result.Planes_de_Rutinass = new List<Planes_de_Rutinas>();

            return Json(new
            {
                data = result.Planes_de_Rutinass.Select(m => new Planes_de_RutinasGridModel
                    {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,PacienteNombre_Completo = CultureHelper.GetTraduction(m.Paciente_Pacientes.Folio.ToString(), "Nombre_Completo") ?? (string)m.Paciente_Pacientes.Nombre_Completo
                        ,Nivel_de_dificultadDificultad = CultureHelper.GetTraduction(m.Nivel_de_dificultad_Nivel_de_dificultad.Folio.ToString(), "Dificultad") ?? (string)m.Nivel_de_dificultad_Nivel_de_dificultad.Dificultad
                        ,SemanaSemana = CultureHelper.GetTraduction(m.Semana_Semanas_Planes.Folio.ToString(), "Semana") ?? (string)m.Semana_Semanas_Planes.Semana
                        ,Fecha_inicio_del_Plan = (m.Fecha_inicio_del_Plan == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio_del_Plan).ToString(ConfigurationProperty.DateFormat))
                        ,Fecha_fin_del_Plan = (m.Fecha_fin_del_Plan == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin_del_Plan).ToString(ConfigurationProperty.DateFormat))
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion
                        ,RutinaNombre_de_la_Rutina = CultureHelper.GetTraduction(m.Rutina_Rutinas.Folio.ToString(), "Nombre_de_la_Rutina") ?? (string)m.Rutina_Rutinas.Nombre_de_la_Rutina
                        ,Estatus_de_SeguimientoDescripcion = CultureHelper.GetTraduction(m.Estatus_de_Seguimiento_Estatus_Plan_de_Rutinas.Folio.ToString(), "Descripcion") ?? (string)m.Estatus_de_Seguimiento_Estatus_Plan_de_Rutinas.Descripcion

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }
		/*
		 [HttpGet]
        public ActionResult GetPlanes_de_RutinasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPlanes_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPlanes_de_RutinasApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraductionNew(Convert.ToString(m.Folio), "Planes_de_Rutinas", m.),
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
        /// Get List of Planes_de_Rutinas from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Planes_de_Rutinas Entity</returns>
        public ActionResult GetPlanes_de_RutinasList(UrlParametersModel param)
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
            _IPlanes_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);

          
            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new Planes_de_RutinasPropertyMapper());
				
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
				if (Session["AdvanceSearch"].GetType() == typeof(Planes_de_RutinasAdvanceSearchModel))
                {
					var advanceFilter =
                    (Planes_de_RutinasAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            Planes_de_RutinasPropertyMapper oPlanes_de_RutinasPropertyMapper = new Planes_de_RutinasPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                 if (sortColumn != -1)
                    configuration.OrderByClause = oPlanes_de_RutinasPropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _IPlanes_de_RutinasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Planes_de_Rutinass == null)
                result.Planes_de_Rutinass = new List<Planes_de_Rutinas>();

            return Json(new
            {
                aaData = result.Planes_de_Rutinass.Select(m => new Planes_de_RutinasGridModel
            {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,PacienteNombre_Completo = CultureHelper.GetTraduction(m.Paciente_Pacientes.Folio.ToString(), "Nombre_Completo") ?? (string)m.Paciente_Pacientes.Nombre_Completo
                        ,Nivel_de_dificultadDificultad = CultureHelper.GetTraduction(m.Nivel_de_dificultad_Nivel_de_dificultad.Folio.ToString(), "Dificultad") ?? (string)m.Nivel_de_dificultad_Nivel_de_dificultad.Dificultad
                        ,SemanaSemana = CultureHelper.GetTraduction(m.Semana_Semanas_Planes.Folio.ToString(), "Semana") ?? (string)m.Semana_Semanas_Planes.Semana
                        ,Fecha_inicio_del_Plan = (m.Fecha_inicio_del_Plan == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio_del_Plan).ToString(ConfigurationProperty.DateFormat))
                        ,Fecha_fin_del_Plan = (m.Fecha_fin_del_Plan == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin_del_Plan).ToString(ConfigurationProperty.DateFormat))
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion
                        ,RutinaNombre_de_la_Rutina = CultureHelper.GetTraduction(m.Rutina_Rutinas.Folio.ToString(), "Nombre_de_la_Rutina") ?? (string)m.Rutina_Rutinas.Nombre_de_la_Rutina
                        ,Estatus_de_SeguimientoDescripcion = CultureHelper.GetTraduction(m.Estatus_de_Seguimiento_Estatus_Plan_de_Rutinas.Folio.ToString(), "Descripcion") ?? (string)m.Estatus_de_Seguimiento_Estatus_Plan_de_Rutinas.Descripcion

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }


       /*CODMANINI-ADD*/
        public ActionResult GetPlanes_de_RutinasListbyIdPaciente()
        {
            int sEcho = 0;

            if (!_tokenManager.GenerateToken())
                return null;
            _IPlanes_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
            _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);

            int userId = Convert.ToInt32(Session["USERID"]);

            string WhereClause = "Pacientes.Usuario_Registrado = " + userId.ToString();
            
            var pacientes  = _IPacientesApiConsumer.ListaSelAll(1, 200, WhereClause, "Pacientes.Folio desc").Resource;

            WhereClause = "Planes_de_Rutinas.Paciente = " + pacientes.Pacientess[0].Folio;
         
            var result = _IPlanes_de_RutinasApiConsumer.ListaSelAll( 1, 100, WhereClause, "").Resource;
            if (result.Planes_de_Rutinass == null)
                result.Planes_de_Rutinass = new List<Planes_de_Rutinas>();

            return Json(new
            {
                aaData = result.Planes_de_Rutinass.Select(m => new Planes_de_RutinasGridModel
                {
                    Folio = m.Folio
                        ,
                    Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
            ,
                    Hora_de_Registro = m.Hora_de_Registro
                        ,
                    Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,
                    PacienteNombre_Completo = CultureHelper.GetTraduction(m.Paciente_Pacientes.Folio.ToString(), "Nombre_Completo") ?? (string)m.Paciente_Pacientes.Nombre_Completo
                        ,
                    Nivel_de_dificultadDificultad = CultureHelper.GetTraduction(m.Nivel_de_dificultad_Nivel_de_dificultad.Folio.ToString(), "Dificultad") ?? (string)m.Nivel_de_dificultad_Nivel_de_dificultad.Dificultad
                        ,
                    SemanaSemana = CultureHelper.GetTraduction(m.Semana_Semanas_Planes.Folio.ToString(), "Semana") ?? (string)m.Semana_Semanas_Planes.Semana
                        ,
                    Fecha_inicio_del_Plan = (m.Fecha_inicio_del_Plan == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio_del_Plan).ToString(ConfigurationProperty.DateFormat))
                        ,
                    Fecha_fin_del_Plan = (m.Fecha_fin_del_Plan == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin_del_Plan).ToString(ConfigurationProperty.DateFormat))
                        ,
                    EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion
                        ,
                    RutinaNombre_de_la_Rutina = CultureHelper.GetTraduction(m.Rutina_Rutinas.Folio.ToString(), "Nombre_de_la_Rutina") ?? (string)m.Rutina_Rutinas.Nombre_de_la_Rutina
                        ,
                    Estatus_de_SeguimientoDescripcion = CultureHelper.GetTraduction(m.Estatus_de_Seguimiento_Estatus_Plan_de_Rutinas.Folio.ToString(), "Descripcion") ?? (string)m.Estatus_de_Seguimiento_Estatus_Plan_de_Rutinas.Descripcion

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDetalle_Planes_de_RutinaEjercicios(int Id)
        {
            try
            {
                int RowCount_Detalle_Planes_de_Rutinas;
                var Detalle_Planes_de_RutinasData = GetDetalle_Planes_de_RutinasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Planes_de_Rutinas);                
                return Json(Detalle_Planes_de_RutinasData.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
         /*CODMANFIN-ADD*/
//Grid GetAutoComplete






        [NonAction]
        public string GetAdvanceFilter(Planes_de_RutinasAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromFolio) || !string.IsNullOrEmpty(filter.ToFolio))
            {
                if (!string.IsNullOrEmpty(filter.FromFolio))
                    where += " AND Planes_de_Rutinas.Folio >= " + filter.FromFolio;
                if (!string.IsNullOrEmpty(filter.ToFolio))
                    where += " AND Planes_de_Rutinas.Folio <= " + filter.ToFolio;
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro) || !string.IsNullOrEmpty(filter.ToFecha_de_Registro))
            {
                var Fecha_de_RegistroFrom = DateTime.ParseExact(filter.FromFecha_de_Registro, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_de_RegistroTo = DateTime.ParseExact(filter.ToFecha_de_Registro, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro))
                    where += " AND Planes_de_Rutinas.Fecha_de_Registro >= '" + Fecha_de_RegistroFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_Registro))
                    where += " AND Planes_de_Rutinas.Fecha_de_Registro <= '" + Fecha_de_RegistroTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromHora_de_Registro) || !string.IsNullOrEmpty(filter.ToHora_de_Registro))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_de_Registro))
                    where += " AND Convert(TIME,Planes_de_Rutinas.Hora_de_Registro) >='" + filter.FromHora_de_Registro + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_de_Registro))
                    where += " AND Convert(TIME,Planes_de_Rutinas.Hora_de_Registro) <='" + filter.ToHora_de_Registro + "'";
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

                where += " AND Planes_de_Rutinas.Usuario_que_Registra In (" + Usuario_que_RegistraIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvancePaciente))
            {
                switch (filter.PacienteFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Pacientes.Nombre_Completo LIKE '" + filter.AdvancePaciente + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Pacientes.Nombre_Completo LIKE '%" + filter.AdvancePaciente + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Pacientes.Nombre_Completo = '" + filter.AdvancePaciente + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Pacientes.Nombre_Completo LIKE '%" + filter.AdvancePaciente + "%'";
                        break;
                }
            }
            else if (filter.AdvancePacienteMultiple != null && filter.AdvancePacienteMultiple.Count() > 0)
            {
                var PacienteIds = string.Join(",", filter.AdvancePacienteMultiple);

                where += " AND Planes_de_Rutinas.Paciente In (" + PacienteIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceNivel_de_dificultad))
            {
                switch (filter.Nivel_de_dificultadFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Nivel_de_dificultad.Dificultad LIKE '" + filter.AdvanceNivel_de_dificultad + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Nivel_de_dificultad.Dificultad LIKE '%" + filter.AdvanceNivel_de_dificultad + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Nivel_de_dificultad.Dificultad = '" + filter.AdvanceNivel_de_dificultad + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Nivel_de_dificultad.Dificultad LIKE '%" + filter.AdvanceNivel_de_dificultad + "%'";
                        break;
                }
            }
            else if (filter.AdvanceNivel_de_dificultadMultiple != null && filter.AdvanceNivel_de_dificultadMultiple.Count() > 0)
            {
                var Nivel_de_dificultadIds = string.Join(",", filter.AdvanceNivel_de_dificultadMultiple);

                where += " AND Planes_de_Rutinas.Nivel_de_dificultad In (" + Nivel_de_dificultadIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceSemana))
            {
                switch (filter.SemanaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Semanas_Planes.Semana LIKE '" + filter.AdvanceSemana + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Semanas_Planes.Semana LIKE '%" + filter.AdvanceSemana + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Semanas_Planes.Semana = '" + filter.AdvanceSemana + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Semanas_Planes.Semana LIKE '%" + filter.AdvanceSemana + "%'";
                        break;
                }
            }
            else if (filter.AdvanceSemanaMultiple != null && filter.AdvanceSemanaMultiple.Count() > 0)
            {
                var SemanaIds = string.Join(",", filter.AdvanceSemanaMultiple);

                where += " AND Planes_de_Rutinas.Semana In (" + SemanaIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_inicio_del_Plan) || !string.IsNullOrEmpty(filter.ToFecha_inicio_del_Plan))
            {
                var Fecha_inicio_del_PlanFrom = DateTime.ParseExact(filter.FromFecha_inicio_del_Plan, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_inicio_del_PlanTo = DateTime.ParseExact(filter.ToFecha_inicio_del_Plan, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_inicio_del_Plan))
                    where += " AND Planes_de_Rutinas.Fecha_inicio_del_Plan >= '" + Fecha_inicio_del_PlanFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_inicio_del_Plan))
                    where += " AND Planes_de_Rutinas.Fecha_inicio_del_Plan <= '" + Fecha_inicio_del_PlanTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_fin_del_Plan) || !string.IsNullOrEmpty(filter.ToFecha_fin_del_Plan))
            {
                var Fecha_fin_del_PlanFrom = DateTime.ParseExact(filter.FromFecha_fin_del_Plan, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_fin_del_PlanTo = DateTime.ParseExact(filter.ToFecha_fin_del_Plan, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_fin_del_Plan))
                    where += " AND Planes_de_Rutinas.Fecha_fin_del_Plan >= '" + Fecha_fin_del_PlanFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_fin_del_Plan))
                    where += " AND Planes_de_Rutinas.Fecha_fin_del_Plan <= '" + Fecha_fin_del_PlanTo.ToString("MM-dd-yyyy") + "'";
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

                where += " AND Planes_de_Rutinas.Estatus In (" + EstatusIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceRutina))
            {
                switch (filter.RutinaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Rutinas.Nombre_de_la_Rutina LIKE '" + filter.AdvanceRutina + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Rutinas.Nombre_de_la_Rutina LIKE '%" + filter.AdvanceRutina + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Rutinas.Nombre_de_la_Rutina = '" + filter.AdvanceRutina + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Rutinas.Nombre_de_la_Rutina LIKE '%" + filter.AdvanceRutina + "%'";
                        break;
                }
            }
            else if (filter.AdvanceRutinaMultiple != null && filter.AdvanceRutinaMultiple.Count() > 0)
            {
                var RutinaIds = string.Join(",", filter.AdvanceRutinaMultiple);

                where += " AND Planes_de_Rutinas.Rutina In (" + RutinaIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceEstatus_de_Seguimiento))
            {
                switch (filter.Estatus_de_SeguimientoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Estatus_Plan_de_Rutinas.Descripcion LIKE '" + filter.AdvanceEstatus_de_Seguimiento + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Estatus_Plan_de_Rutinas.Descripcion LIKE '%" + filter.AdvanceEstatus_de_Seguimiento + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Estatus_Plan_de_Rutinas.Descripcion = '" + filter.AdvanceEstatus_de_Seguimiento + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Estatus_Plan_de_Rutinas.Descripcion LIKE '%" + filter.AdvanceEstatus_de_Seguimiento + "%'";
                        break;
                }
            }
            else if (filter.AdvanceEstatus_de_SeguimientoMultiple != null && filter.AdvanceEstatus_de_SeguimientoMultiple.Count() > 0)
            {
                var Estatus_de_SeguimientoIds = string.Join(",", filter.AdvanceEstatus_de_SeguimientoMultiple);

                where += " AND Planes_de_Rutinas.Estatus_de_Seguimiento In (" + Estatus_de_SeguimientoIds + ")";
            }


            where = new Regex(Regex.Escape("AND ")).Replace(where, "", 1);
            return where;
        }

        [NonAction]
        public Grid_File ConvertSpartane_FileToGridFile(Spartane.Core.Domain.Spartane_File.Spartane_File file)
        {
            return file == null ? new Grid_File { FileId = 0, FileSize = 0, FileName = "" } : new Grid_File { FileId = file.File_Id, FileName = file.Description, FileSize = file.File_Size ?? 0, };
        }

        public ActionResult GetDetalle_Planes_de_Rutinas(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_Planes_de_RutinasGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Planes_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Planes_de_Rutinas.Folio_Planes_de_Rutinas=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Planes_de_Rutinas.Folio_Planes_de_Rutinas='" + RelationId + "'";
            }
            var result = _IDetalle_Planes_de_RutinasApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Planes_de_Rutinass == null)
                result.Detalle_Planes_de_Rutinass = new List<Detalle_Planes_de_Rutinas>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Planes_de_Rutinass.Select(m => new Detalle_Planes_de_RutinasGridModel
                {
                    Folio = m.Folio

                        ,Numero_de_Dia = m.Numero_de_Dia
                        ,Numero_de_DiaDia = CultureHelper.GetTraduction(m.Numero_de_Dia_Dias_de_la_semana.Clave.ToString(), "Dia") ??(string)m.Numero_de_Dia_Dias_de_la_semana.Dia
			,Fecha = (m.Fecha == null ? string.Empty : Convert.ToDateTime(m.Fecha).ToString(ConfigurationProperty.DateFormat))
			,Orden_de_Realizacion = m.Orden_de_Realizacion
			,Secuencia_del_Ejercicio = m.Secuencia_del_Ejercicio
                        ,Enfoque_del_Ejercicio = m.Enfoque_del_Ejercicio
                        ,Enfoque_del_EjercicioDescripcion = CultureHelper.GetTraduction(m.Enfoque_del_Ejercicio_Tipo_de_Enfoque_del_Ejercicio.Folio.ToString(), "Descripcion") ??(string)m.Enfoque_del_Ejercicio_Tipo_de_Enfoque_del_Ejercicio.Descripcion
                        ,Ejercicio = m.Ejercicio
                        ,EjercicioNombre_del_Ejercicio = CultureHelper.GetTraduction(m.Ejercicio_Ejercicios.Clave.ToString(), "Nombre_del_Ejercicio") ??(string)m.Ejercicio_Ejercicios.Nombre_del_Ejercicio
			,Realizado = m.Realizado

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_Planes_de_RutinasGridModel> GetDetalle_Planes_de_RutinasData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_Planes_de_RutinasGridModel> resultData = new List<Detalle_Planes_de_RutinasGridModel>();
            string where = "Detalle_Planes_de_Rutinas.Folio_Planes_de_Rutinas=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Planes_de_Rutinas.Folio_Planes_de_Rutinas='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Planes_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_Planes_de_RutinasApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Planes_de_Rutinass != null)
            {
                resultData = result.Detalle_Planes_de_Rutinass.Select(m => new Detalle_Planes_de_RutinasGridModel
                    {
                        Folio = m.Folio

                        ,Numero_de_Dia = m.Numero_de_Dia
                        ,Numero_de_DiaDia = CultureHelper.GetTraduction(m.Numero_de_Dia_Dias_de_la_semana.Clave.ToString(), "Dia") ??(string)m.Numero_de_Dia_Dias_de_la_semana.Dia
			,Fecha = (m.Fecha == null ? string.Empty : Convert.ToDateTime(m.Fecha).ToString(ConfigurationProperty.DateFormat))
			,Orden_de_Realizacion = m.Orden_de_Realizacion
			,Secuencia_del_Ejercicio = m.Secuencia_del_Ejercicio
                        ,Enfoque_del_Ejercicio = m.Enfoque_del_Ejercicio
                        ,Enfoque_del_EjercicioDescripcion = CultureHelper.GetTraduction(m.Enfoque_del_Ejercicio_Tipo_de_Enfoque_del_Ejercicio.Folio.ToString(), "Descripcion") ??(string)m.Enfoque_del_Ejercicio_Tipo_de_Enfoque_del_Ejercicio.Descripcion
                        ,Ejercicio = m.Ejercicio
                        ,EjercicioNombre_del_Ejercicio = CultureHelper.GetTraduction(m.Ejercicio_Ejercicios.Clave.ToString(), "Nombre_del_Ejercicio") ??(string)m.Ejercicio_Ejercicios.Nombre_del_Ejercicio
			,Realizado = m.Realizado


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
                _IPlanes_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);

                Planes_de_Rutinas varPlanes_de_Rutinas = null;
                if (id.ToString() != "0")
                {
                        string where = "";
                    _IDetalle_Planes_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Planes_de_Rutinas.Folio_Planes_de_Rutinas=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Planes_de_Rutinas.Folio_Planes_de_Rutinas='" + id + "'";
                    }
                    var Detalle_Planes_de_RutinasInfo =
                        _IDetalle_Planes_de_RutinasApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_Planes_de_RutinasInfo.Detalle_Planes_de_Rutinass.Count > 0)
                    {
                        var resultDetalle_Planes_de_Rutinas = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_Planes_de_RutinasItem in Detalle_Planes_de_RutinasInfo.Detalle_Planes_de_Rutinass)
                            resultDetalle_Planes_de_Rutinas = resultDetalle_Planes_de_Rutinas
                                              && _IDetalle_Planes_de_RutinasApiConsumer.Delete(Detalle_Planes_de_RutinasItem.Folio, null,null).Resource;

                        if (!resultDetalle_Planes_de_Rutinas)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                var result = _IPlanes_de_RutinasApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Planes_de_RutinasModel varPlanes_de_Rutinas)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IPlanes_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Planes_de_RutinasInfo = new Planes_de_Rutinas
                    {
                        Folio = varPlanes_de_Rutinas.Folio
                        ,Fecha_de_Registro = (!String.IsNullOrEmpty(varPlanes_de_Rutinas.Fecha_de_Registro)) ? DateTime.ParseExact(varPlanes_de_Rutinas.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varPlanes_de_Rutinas.Hora_de_Registro
                        ,Usuario_que_Registra = varPlanes_de_Rutinas.Usuario_que_Registra
                        ,Paciente = varPlanes_de_Rutinas.Paciente
                        ,Nivel_de_dificultad = varPlanes_de_Rutinas.Nivel_de_dificultad
                        ,Semana = varPlanes_de_Rutinas.Semana
                        ,Fecha_inicio_del_Plan = (!String.IsNullOrEmpty(varPlanes_de_Rutinas.Fecha_inicio_del_Plan)) ? DateTime.ParseExact(varPlanes_de_Rutinas.Fecha_inicio_del_Plan, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Fecha_fin_del_Plan = (!String.IsNullOrEmpty(varPlanes_de_Rutinas.Fecha_fin_del_Plan)) ? DateTime.ParseExact(varPlanes_de_Rutinas.Fecha_fin_del_Plan, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Estatus = varPlanes_de_Rutinas.Estatus
                        ,Rutina = varPlanes_de_Rutinas.Rutina
                        ,Estatus_de_Seguimiento = varPlanes_de_Rutinas.Estatus_de_Seguimiento

                    };

                    result = !IsNew ?
                        _IPlanes_de_RutinasApiConsumer.Update(Planes_de_RutinasInfo, null, null).Resource.ToString() :
                         _IPlanes_de_RutinasApiConsumer.Insert(Planes_de_RutinasInfo, null, null).Resource.ToString();
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
        public bool CopyDetalle_Planes_de_Rutinas(int MasterId, int referenceId, List<Detalle_Planes_de_RutinasGridModelPost> Detalle_Planes_de_RutinasItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_Planes_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_Planes_de_RutinasData = _IDetalle_Planes_de_RutinasApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Planes_de_Rutinas.Folio_Planes_de_Rutinas=" + referenceId,"").Resource;
                if (Detalle_Planes_de_RutinasData == null || Detalle_Planes_de_RutinasData.Detalle_Planes_de_Rutinass.Count == 0)
                    return true;

                var result = true;

                Detalle_Planes_de_RutinasGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Planes_de_Rutinas in Detalle_Planes_de_RutinasData.Detalle_Planes_de_Rutinass)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Planes_de_Rutinas Detalle_Planes_de_Rutinas1 = varDetalle_Planes_de_Rutinas;

                    if (Detalle_Planes_de_RutinasItems != null && Detalle_Planes_de_RutinasItems.Any(m => m.Folio == Detalle_Planes_de_Rutinas1.Folio))
                    {
                        modelDataToChange = Detalle_Planes_de_RutinasItems.FirstOrDefault(m => m.Folio == Detalle_Planes_de_Rutinas1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Planes_de_Rutinas.Folio_Planes_de_Rutinas = MasterId;
                    var insertId = _IDetalle_Planes_de_RutinasApiConsumer.Insert(varDetalle_Planes_de_Rutinas,null,null).Resource;
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
        public ActionResult PostDetalle_Planes_de_Rutinas(List<Detalle_Planes_de_RutinasGridModelPost> Detalle_Planes_de_RutinasItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Planes_de_Rutinas(MasterId, referenceId, Detalle_Planes_de_RutinasItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_Planes_de_RutinasItems != null && Detalle_Planes_de_RutinasItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_Planes_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_Planes_de_RutinasItem in Detalle_Planes_de_RutinasItems)
                    {









                        //Removal Request
                        if (Detalle_Planes_de_RutinasItem.Removed)
                        {
                            result = result && _IDetalle_Planes_de_RutinasApiConsumer.Delete(Detalle_Planes_de_RutinasItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_Planes_de_RutinasItem.Folio = 0;

                        var Detalle_Planes_de_RutinasData = new Detalle_Planes_de_Rutinas
                        {
                            Folio_Planes_de_Rutinas = MasterId
                            ,Folio = Detalle_Planes_de_RutinasItem.Folio
                            ,Numero_de_Dia = (Convert.ToInt32(Detalle_Planes_de_RutinasItem.Numero_de_Dia) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Planes_de_RutinasItem.Numero_de_Dia))
                            ,Fecha = (Detalle_Planes_de_RutinasItem.Fecha!= null) ? DateTime.ParseExact(Detalle_Planes_de_RutinasItem.Fecha, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                            ,Orden_de_Realizacion = Detalle_Planes_de_RutinasItem.Orden_de_Realizacion
                            ,Secuencia_del_Ejercicio = Detalle_Planes_de_RutinasItem.Secuencia_del_Ejercicio
                            ,Enfoque_del_Ejercicio = (Convert.ToInt32(Detalle_Planes_de_RutinasItem.Enfoque_del_Ejercicio) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Planes_de_RutinasItem.Enfoque_del_Ejercicio))
                            ,Ejercicio = (Convert.ToInt32(Detalle_Planes_de_RutinasItem.Ejercicio) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Planes_de_RutinasItem.Ejercicio))
                            ,Realizado = Detalle_Planes_de_RutinasItem.Realizado

                        };

                        var resultId = Detalle_Planes_de_RutinasItem.Folio > 0
                           ? _IDetalle_Planes_de_RutinasApiConsumer.Update(Detalle_Planes_de_RutinasData,null,null).Resource
                           : _IDetalle_Planes_de_RutinasApiConsumer.Insert(Detalle_Planes_de_RutinasData,null,null).Resource;

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
        public ActionResult GetDetalle_Planes_de_Rutinas_Dias_de_la_semanaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDias_de_la_semanaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IDias_de_la_semanaApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Dias_de_la_semana", "Dia");
                  item.Dia= trans??item.Dia;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }



        [HttpGet]
        public ActionResult GetDetalle_Planes_de_Rutinas_Tipo_de_Enfoque_del_EjercicioAll()
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
        [HttpGet]
        public ActionResult GetDetalle_Planes_de_Rutinas_EjerciciosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEjerciciosApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Ejercicios", "Nombre_del_Ejercicio");
                  item.Nombre_del_Ejercicio= trans??item.Nombre_del_Ejercicio;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }




        /// <summary>
        /// Write Element Array of Planes_de_Rutinas script
        /// </summary>
        /// <param name="oPlanes_de_RutinasElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew Planes_de_RutinasModuleAttributeList)
        {
            for (int i = 0; i < Planes_de_RutinasModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Planes_de_RutinasModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Planes_de_RutinasModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Planes_de_RutinasModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Planes_de_RutinasModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Planes_de_RutinasModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Planes_de_RutinasModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < Planes_de_RutinasModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(Planes_de_RutinasModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							Planes_de_RutinasModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(Planes_de_RutinasModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							Planes_de_RutinasModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strPlanes_de_RutinasScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Planes_de_Rutinas.js")))
            {
                strPlanes_de_RutinasScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Planes_de_Rutinas element attributes
            string userChangeJson = jsSerialize.Serialize(Planes_de_RutinasModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strPlanes_de_RutinasScript.IndexOf("inpuElementArray");
            string splittedString = strPlanes_de_RutinasScript.Substring(indexOfArray, strPlanes_de_RutinasScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Planes_de_RutinasModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Planes_de_RutinasModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strPlanes_de_RutinasScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strPlanes_de_RutinasScript.Substring(indexOfArrayHistory, strPlanes_de_RutinasScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strPlanes_de_RutinasScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strPlanes_de_RutinasScript.Substring(endIndexOfMainElement + indexOfArray, strPlanes_de_RutinasScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (Planes_de_RutinasModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in Planes_de_RutinasModuleAttributeList.ChildModuleAttributeList)
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
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Planes_de_Rutinas.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Planes_de_Rutinas.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Planes_de_Rutinas.js")))
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
        public ActionResult Planes_de_RutinasPropertyBag()
        {
            return PartialView("Planes_de_RutinasPropertyBag", "Planes_de_Rutinas");
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
        public ActionResult AddDetalle_Planes_de_Rutinas(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Planes_de_Rutinas/AddDetalle_Planes_de_Rutinas");
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
                var whereClauseFormat = "Object = 44570 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _IPlanes_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Planes_de_Rutinas.Folio= " + RecordId;
                            var result = _IPlanes_de_RutinasApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
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

            _IPlanes_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Planes_de_RutinasPropertyMapper());
			
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
                    (Planes_de_RutinasAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
			string sortDirection = "asc";

            Planes_de_RutinasPropertyMapper oPlanes_de_RutinasPropertyMapper = new Planes_de_RutinasPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oPlanes_de_RutinasPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IPlanes_de_RutinasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Planes_de_Rutinass == null)
                result.Planes_de_Rutinass = new List<Planes_de_Rutinas>();

            var data = result.Planes_de_Rutinass.Select(m => new Planes_de_RutinasGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,PacienteNombre_Completo = CultureHelper.GetTraduction(m.Paciente_Pacientes.Folio.ToString(), "Nombre_Completo") ?? (string)m.Paciente_Pacientes.Nombre_Completo
                        ,Nivel_de_dificultadDificultad = CultureHelper.GetTraduction(m.Nivel_de_dificultad_Nivel_de_dificultad.Folio.ToString(), "Dificultad") ?? (string)m.Nivel_de_dificultad_Nivel_de_dificultad.Dificultad
                        ,SemanaSemana = CultureHelper.GetTraduction(m.Semana_Semanas_Planes.Folio.ToString(), "Semana") ?? (string)m.Semana_Semanas_Planes.Semana
                        ,Fecha_inicio_del_Plan = (m.Fecha_inicio_del_Plan == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio_del_Plan).ToString(ConfigurationProperty.DateFormat))
                        ,Fecha_fin_del_Plan = (m.Fecha_fin_del_Plan == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin_del_Plan).ToString(ConfigurationProperty.DateFormat))
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion
                        ,RutinaNombre_de_la_Rutina = CultureHelper.GetTraduction(m.Rutina_Rutinas.Folio.ToString(), "Nombre_de_la_Rutina") ?? (string)m.Rutina_Rutinas.Nombre_de_la_Rutina
                        ,Estatus_de_SeguimientoDescripcion = CultureHelper.GetTraduction(m.Estatus_de_Seguimiento_Estatus_Plan_de_Rutinas.Folio.ToString(), "Descripcion") ?? (string)m.Estatus_de_Seguimiento_Estatus_Plan_de_Rutinas.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(44570, arrayColumnsVisible), "Planes_de_RutinasList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(44570, arrayColumnsVisible), "Planes_de_RutinasList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(44570, arrayColumnsVisible), "Planes_de_RutinasList_" + DateTime.Now.ToString());
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

            _IPlanes_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Planes_de_RutinasPropertyMapper());
				
				
            if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
			if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (Planes_de_RutinasAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            Planes_de_RutinasPropertyMapper oPlanes_de_RutinasPropertyMapper = new Planes_de_RutinasPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oPlanes_de_RutinasPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
			
			if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IPlanes_de_RutinasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Planes_de_Rutinass == null)
                result.Planes_de_Rutinass = new List<Planes_de_Rutinas>();

            var data = result.Planes_de_Rutinass.Select(m => new Planes_de_RutinasGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,PacienteNombre_Completo = CultureHelper.GetTraduction(m.Paciente_Pacientes.Folio.ToString(), "Nombre_Completo") ?? (string)m.Paciente_Pacientes.Nombre_Completo
                        ,Nivel_de_dificultadDificultad = CultureHelper.GetTraduction(m.Nivel_de_dificultad_Nivel_de_dificultad.Folio.ToString(), "Dificultad") ?? (string)m.Nivel_de_dificultad_Nivel_de_dificultad.Dificultad
                        ,SemanaSemana = CultureHelper.GetTraduction(m.Semana_Semanas_Planes.Folio.ToString(), "Semana") ?? (string)m.Semana_Semanas_Planes.Semana
                        ,Fecha_inicio_del_Plan = (m.Fecha_inicio_del_Plan == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio_del_Plan).ToString(ConfigurationProperty.DateFormat))
                        ,Fecha_fin_del_Plan = (m.Fecha_fin_del_Plan == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin_del_Plan).ToString(ConfigurationProperty.DateFormat))
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion
                        ,RutinaNombre_de_la_Rutina = CultureHelper.GetTraduction(m.Rutina_Rutinas.Folio.ToString(), "Nombre_de_la_Rutina") ?? (string)m.Rutina_Rutinas.Nombre_de_la_Rutina
                        ,Estatus_de_SeguimientoDescripcion = CultureHelper.GetTraduction(m.Estatus_de_Seguimiento_Estatus_Plan_de_Rutinas.Folio.ToString(), "Descripcion") ?? (string)m.Estatus_de_Seguimiento_Estatus_Plan_de_Rutinas.Descripcion

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
                _IPlanes_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPlanes_de_RutinasApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpPost]
        public ActionResult Post_Datos_Generales(Planes_de_Rutinas_Datos_GeneralesModel varPlanes_de_Rutinas)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPlanes_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Planes_de_Rutinas_Datos_GeneralesInfo = new Planes_de_Rutinas_Datos_Generales
                {
                    Folio = varPlanes_de_Rutinas.Folio
                                            ,Fecha_de_Registro = (!String.IsNullOrEmpty(varPlanes_de_Rutinas.Fecha_de_Registro)) ? DateTime.ParseExact(varPlanes_de_Rutinas.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varPlanes_de_Rutinas.Hora_de_Registro
                        ,Usuario_que_Registra = varPlanes_de_Rutinas.Usuario_que_Registra
                        ,Paciente = varPlanes_de_Rutinas.Paciente
                        ,Nivel_de_dificultad = varPlanes_de_Rutinas.Nivel_de_dificultad
                        ,Semana = varPlanes_de_Rutinas.Semana
                        ,Fecha_inicio_del_Plan = (!String.IsNullOrEmpty(varPlanes_de_Rutinas.Fecha_inicio_del_Plan)) ? DateTime.ParseExact(varPlanes_de_Rutinas.Fecha_inicio_del_Plan, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Fecha_fin_del_Plan = (!String.IsNullOrEmpty(varPlanes_de_Rutinas.Fecha_fin_del_Plan)) ? DateTime.ParseExact(varPlanes_de_Rutinas.Fecha_fin_del_Plan, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Estatus = varPlanes_de_Rutinas.Estatus
                        ,Rutina = varPlanes_de_Rutinas.Rutina
                    
                };

                result = _IPlanes_de_RutinasApiConsumer.Update_Datos_Generales(Planes_de_Rutinas_Datos_GeneralesInfo).Resource.ToString();
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
                _IPlanes_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IPlanes_de_RutinasApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Planes_de_Rutinas;
                var Detalle_Planes_de_RutinasData = GetDetalle_Planes_de_RutinasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Planes_de_Rutinas);

                var result = new Planes_de_Rutinas_Datos_GeneralesModel
                {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_Registra = m.Usuario_que_Registra
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,Paciente = m.Paciente
                        ,PacienteNombre_Completo = CultureHelper.GetTraduction(m.Paciente_Pacientes.Folio.ToString(), "Nombre_Completo") ?? (string)m.Paciente_Pacientes.Nombre_Completo
                        ,Nivel_de_dificultad = m.Nivel_de_dificultad
                        ,Nivel_de_dificultadDificultad = CultureHelper.GetTraduction(m.Nivel_de_dificultad_Nivel_de_dificultad.Folio.ToString(), "Dificultad") ?? (string)m.Nivel_de_dificultad_Nivel_de_dificultad.Dificultad
                        ,Semana = m.Semana
                        ,SemanaSemana = CultureHelper.GetTraduction(m.Semana_Semanas_Planes.Folio.ToString(), "Semana") ?? (string)m.Semana_Semanas_Planes.Semana
                        ,Fecha_inicio_del_Plan = (m.Fecha_inicio_del_Plan == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio_del_Plan).ToString(ConfigurationProperty.DateFormat))
                        ,Fecha_fin_del_Plan = (m.Fecha_fin_del_Plan == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin_del_Plan).ToString(ConfigurationProperty.DateFormat))
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion
                        ,Rutina = m.Rutina
                        ,RutinaNombre_de_la_Rutina = CultureHelper.GetTraduction(m.Rutina_Rutinas.Folio.ToString(), "Nombre_de_la_Rutina") ?? (string)m.Rutina_Rutinas.Nombre_de_la_Rutina

                    
                };
				var resultData = new
                {
                    data = result
                    ,Seguimiento_de_Rutina = Detalle_Planes_de_RutinasData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }

		[HttpPost]
        public ActionResult Post_Seguimiento_al_Plan(Planes_de_Rutinas_Seguimiento_al_PlanModel varPlanes_de_Rutinas)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPlanes_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Planes_de_Rutinas_Seguimiento_al_PlanInfo = new Planes_de_Rutinas_Seguimiento_al_Plan
                {
                    Folio = varPlanes_de_Rutinas.Folio
                                            ,Estatus_de_Seguimiento = varPlanes_de_Rutinas.Estatus_de_Seguimiento
                    
                };

                result = _IPlanes_de_RutinasApiConsumer.Update_Seguimiento_al_Plan(Planes_de_Rutinas_Seguimiento_al_PlanInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Seguimiento_al_Plan(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPlanes_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IPlanes_de_RutinasApiConsumer.Get_Seguimiento_al_Plan(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Planes_de_Rutinas;
                var Detalle_Planes_de_RutinasData = GetDetalle_Planes_de_RutinasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Planes_de_Rutinas);

                var result = new Planes_de_Rutinas_Seguimiento_al_PlanModel
                {
                    Folio = m.Folio
                        ,Estatus_de_Seguimiento = m.Estatus_de_Seguimiento
                        ,Estatus_de_SeguimientoDescripcion = CultureHelper.GetTraduction(m.Estatus_de_Seguimiento_Estatus_Plan_de_Rutinas.Folio.ToString(), "Descripcion") ?? (string)m.Estatus_de_Seguimiento_Estatus_Plan_de_Rutinas.Descripcion

                    
                };
				var resultData = new
                {
                    data = result
                    ,Seguimiento_de_Rutina = Detalle_Planes_de_RutinasData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }


    }
}

