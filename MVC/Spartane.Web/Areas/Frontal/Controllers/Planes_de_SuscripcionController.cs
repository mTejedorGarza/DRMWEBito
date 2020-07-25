using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Planes_de_Suscripcion;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.MS_Beneficiarios_Suscripcion;

using Spartane.Core.Domain.Tipo_Paciente;

using Spartane.Core.Domain.MS_Semanas_Planes;

using Spartane.Core.Domain.Semanas_Planes;

using Spartane.Core.Domain.Estatus;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Planes_de_Suscripcion;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Planes_de_Suscripcion;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.MS_Beneficiarios_Suscripcion;

using Spartane.Web.Areas.WebApiConsumer.Tipo_Paciente;

using Spartane.Web.Areas.WebApiConsumer.MS_Semanas_Planes;

using Spartane.Web.Areas.WebApiConsumer.Semanas_Planes;

using Spartane.Web.Areas.WebApiConsumer.Estatus;

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
    public class Planes_de_SuscripcionController : Controller
    {
        #region "variable declaration"

        private IPlanes_de_SuscripcionService service = null;
        private IPlanes_de_SuscripcionApiConsumer _IPlanes_de_SuscripcionApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private IMS_Beneficiarios_SuscripcionApiConsumer _IMS_Beneficiarios_SuscripcionApiConsumer;

        private ITipo_PacienteApiConsumer _ITipo_PacienteApiConsumer;

        private IMS_Semanas_PlanesApiConsumer _IMS_Semanas_PlanesApiConsumer;

        private ISemanas_PlanesApiConsumer _ISemanas_PlanesApiConsumer;

        private IEstatusApiConsumer _IEstatusApiConsumer;

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

        
        public Planes_de_SuscripcionController(IPlanes_de_SuscripcionService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IPlanes_de_SuscripcionApiConsumer Planes_de_SuscripcionApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer , IMS_Beneficiarios_SuscripcionApiConsumer MS_Beneficiarios_SuscripcionApiConsumer , ITipo_PacienteApiConsumer Tipo_PacienteApiConsumer  , IMS_Semanas_PlanesApiConsumer MS_Semanas_PlanesApiConsumer , ISemanas_PlanesApiConsumer Semanas_PlanesApiConsumer  , IEstatusApiConsumer EstatusApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IPlanes_de_SuscripcionApiConsumer = Planes_de_SuscripcionApiConsumer;
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
            this._IMS_Beneficiarios_SuscripcionApiConsumer = MS_Beneficiarios_SuscripcionApiConsumer;

            this._ITipo_PacienteApiConsumer = Tipo_PacienteApiConsumer;

            this._IMS_Semanas_PlanesApiConsumer = MS_Semanas_PlanesApiConsumer;

            this._ISemanas_PlanesApiConsumer = Semanas_PlanesApiConsumer;

            this._IEstatusApiConsumer = EstatusApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Planes_de_Suscripcion
        [ObjectAuth(ObjectId = (ModuleObjectId)44396, PermissionType = PermissionTypes.Consult)]
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
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44396, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			          
            return View();
        }

        // GET: Frontal/Planes_de_Suscripcion/Create
          [ObjectAuth(ObjectId = (ModuleObjectId)44396, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44396, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varPlanes_de_Suscripcion = new Planes_de_SuscripcionModel();
			varPlanes_de_Suscripcion.Folio = Id;
			
            ViewBag.ObjectId = "44396";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;

            var permissionMS_Beneficiarios_Suscripcion = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44600, ModuleId);
            ViewBag.PermissionMS_Beneficiarios_Suscripcion = permissionMS_Beneficiarios_Suscripcion;
            var permissionMS_Semanas_Planes = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44602, ModuleId);
            ViewBag.PermissionMS_Semanas_Planes = permissionMS_Semanas_Planes;


            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
				
				_tokenManager.GenerateToken();
				_ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Planes_de_SuscripcionsData = _IPlanes_de_SuscripcionApiConsumer.ListaSelAll(0, 1000, "Planes_de_Suscripcion.Folio=" + Id, "").Resource.Planes_de_Suscripcions;
				
				if (Planes_de_SuscripcionsData != null && Planes_de_SuscripcionsData.Count > 0)
                {
					var Planes_de_SuscripcionData = Planes_de_SuscripcionsData.First();
					varPlanes_de_Suscripcion= new Planes_de_SuscripcionModel
					{
						Folio  = Planes_de_SuscripcionData.Folio 
	                    ,Fecha_de_Registro = (Planes_de_SuscripcionData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(Planes_de_SuscripcionData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = Planes_de_SuscripcionData.Hora_de_Registro
                    ,Usuario_que_Registra = Planes_de_SuscripcionData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(Planes_de_SuscripcionData.Usuario_que_Registra), "Spartan_User") ??  (string)Planes_de_SuscripcionData.Usuario_que_Registra_Spartan_User.Name
                    ,Nombre = Planes_de_SuscripcionData.Nombre
                    ,Nombre_del_Plan = Planes_de_SuscripcionData.Nombre_del_Plan
                    ,Duracion_en_meses = Planes_de_SuscripcionData.Duracion_en_meses
                    ,Duracion = Planes_de_SuscripcionData.Duracion
                    ,Dietas_por_mes = Planes_de_SuscripcionData.Dietas_por_mes
                    ,Rutinas_por_mes = Planes_de_SuscripcionData.Rutinas_por_mes
                    ,Costo_mensual = Planes_de_SuscripcionData.Costo_mensual
                    ,Precio_Final = Planes_de_SuscripcionData.Precio_Final
                    ,Estatus = Planes_de_SuscripcionData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Planes_de_SuscripcionData.Estatus), "Estatus") ??  (string)Planes_de_SuscripcionData.Estatus_Estatus.Descripcion

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

				
            return View(varPlanes_de_Suscripcion);
        }
		
	[HttpGet]
        public ActionResult AddPlanes_de_Suscripcion(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44396);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
			Planes_de_SuscripcionModel varPlanes_de_Suscripcion= new Planes_de_SuscripcionModel();
            var permissionMS_Beneficiarios_Suscripcion = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44600, ModuleId);
            ViewBag.PermissionMS_Beneficiarios_Suscripcion = permissionMS_Beneficiarios_Suscripcion;
            var permissionMS_Semanas_Planes = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44602, ModuleId);
            ViewBag.PermissionMS_Semanas_Planes = permissionMS_Semanas_Planes;


            if (id.ToString() != "0")
            {
                var Planes_de_SuscripcionsData = _IPlanes_de_SuscripcionApiConsumer.ListaSelAll(0, 1000, "Planes_de_Suscripcion.Folio=" + id, "").Resource.Planes_de_Suscripcions;
				
				if (Planes_de_SuscripcionsData != null && Planes_de_SuscripcionsData.Count > 0)
                {
					var Planes_de_SuscripcionData = Planes_de_SuscripcionsData.First();
					varPlanes_de_Suscripcion= new Planes_de_SuscripcionModel
					{
						Folio  = Planes_de_SuscripcionData.Folio 
	                    ,Fecha_de_Registro = (Planes_de_SuscripcionData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(Planes_de_SuscripcionData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = Planes_de_SuscripcionData.Hora_de_Registro
                    ,Usuario_que_Registra = Planes_de_SuscripcionData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(Planes_de_SuscripcionData.Usuario_que_Registra), "Spartan_User") ??  (string)Planes_de_SuscripcionData.Usuario_que_Registra_Spartan_User.Name
                    ,Nombre = Planes_de_SuscripcionData.Nombre
                    ,Nombre_del_Plan = Planes_de_SuscripcionData.Nombre_del_Plan
                    ,Duracion_en_meses = Planes_de_SuscripcionData.Duracion_en_meses
                    ,Duracion = Planes_de_SuscripcionData.Duracion
                    ,Dietas_por_mes = Planes_de_SuscripcionData.Dietas_por_mes
                    ,Rutinas_por_mes = Planes_de_SuscripcionData.Rutinas_por_mes
                    ,Costo_mensual = Planes_de_SuscripcionData.Costo_mensual
                    ,Precio_Final = Planes_de_SuscripcionData.Precio_Final
                    ,Estatus = Planes_de_SuscripcionData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Planes_de_SuscripcionData.Estatus), "Estatus") ??  (string)Planes_de_SuscripcionData.Estatus_Estatus.Descripcion

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
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddPlanes_de_Suscripcion", varPlanes_de_Suscripcion);
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
        public ActionResult ShowAdvanceFilter(Planes_de_SuscripcionAdvanceSearchModel model, int idFilter = -1)
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
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            var previousFiltersObj = new Planes_de_SuscripcionAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Planes_de_SuscripcionAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Planes_de_SuscripcionAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Planes_de_SuscripcionPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IPlanes_de_SuscripcionApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Planes_de_Suscripcions == null)
                result.Planes_de_Suscripcions = new List<Planes_de_Suscripcion>();

            return Json(new
            {
                data = result.Planes_de_Suscripcions.Select(m => new Planes_de_SuscripcionGridModel
                    {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre = m.Nombre
			,Nombre_del_Plan = m.Nombre_del_Plan
			,Duracion_en_meses = m.Duracion_en_meses
			,Duracion = m.Duracion
			,Dietas_por_mes = m.Dietas_por_mes
			,Rutinas_por_mes = m.Rutinas_por_mes
			,Costo_mensual = m.Costo_mensual
			,Precio_Final = m.Precio_Final
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }
		/*
		 [HttpGet]
        public ActionResult GetPlanes_de_SuscripcionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPlanes_de_SuscripcionApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraductionNew(Convert.ToString(m.Folio), "Planes_de_Suscripcion", m.),
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
        /// Get List of Planes_de_Suscripcion from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Planes_de_Suscripcion Entity</returns>
        public ActionResult GetPlanes_de_SuscripcionList(UrlParametersModel param)
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
            _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);

          
            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new Planes_de_SuscripcionPropertyMapper());
				
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
				if (Session["AdvanceSearch"].GetType() == typeof(Planes_de_SuscripcionAdvanceSearchModel))
                {
					var advanceFilter =
                    (Planes_de_SuscripcionAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            Planes_de_SuscripcionPropertyMapper oPlanes_de_SuscripcionPropertyMapper = new Planes_de_SuscripcionPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                 if (sortColumn != -1)
                    configuration.OrderByClause = oPlanes_de_SuscripcionPropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _IPlanes_de_SuscripcionApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Planes_de_Suscripcions == null)
                result.Planes_de_Suscripcions = new List<Planes_de_Suscripcion>();

            return Json(new
            {
                aaData = result.Planes_de_Suscripcions.Select(m => new Planes_de_SuscripcionGridModel
            {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre = m.Nombre
			,Nombre_del_Plan = m.Nombre_del_Plan
			,Duracion_en_meses = m.Duracion_en_meses
			,Duracion = m.Duracion
			,Dietas_por_mes = m.Dietas_por_mes
			,Rutinas_por_mes = m.Rutinas_por_mes
			,Costo_mensual = m.Costo_mensual
			,Precio_Final = m.Precio_Final
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }


//Grid GetAutoComplete

//Grid GetAutoComplete






        [NonAction]
        public string GetAdvanceFilter(Planes_de_SuscripcionAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromFolio) || !string.IsNullOrEmpty(filter.ToFolio))
            {
                if (!string.IsNullOrEmpty(filter.FromFolio))
                    where += " AND Planes_de_Suscripcion.Folio >= " + filter.FromFolio;
                if (!string.IsNullOrEmpty(filter.ToFolio))
                    where += " AND Planes_de_Suscripcion.Folio <= " + filter.ToFolio;
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro) || !string.IsNullOrEmpty(filter.ToFecha_de_Registro))
            {
                var Fecha_de_RegistroFrom = DateTime.ParseExact(filter.FromFecha_de_Registro, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_de_RegistroTo = DateTime.ParseExact(filter.ToFecha_de_Registro, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro))
                    where += " AND Planes_de_Suscripcion.Fecha_de_Registro >= '" + Fecha_de_RegistroFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_Registro))
                    where += " AND Planes_de_Suscripcion.Fecha_de_Registro <= '" + Fecha_de_RegistroTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromHora_de_Registro) || !string.IsNullOrEmpty(filter.ToHora_de_Registro))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_de_Registro))
                    where += " AND Convert(TIME,Planes_de_Suscripcion.Hora_de_Registro) >='" + filter.FromHora_de_Registro + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_de_Registro))
                    where += " AND Convert(TIME,Planes_de_Suscripcion.Hora_de_Registro) <='" + filter.ToHora_de_Registro + "'";
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

                where += " AND Planes_de_Suscripcion.Usuario_que_Registra In (" + Usuario_que_RegistraIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Nombre))
            {
                switch (filter.NombreFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Planes_de_Suscripcion.Nombre LIKE '" + filter.Nombre + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Planes_de_Suscripcion.Nombre LIKE '%" + filter.Nombre + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Planes_de_Suscripcion.Nombre = '" + filter.Nombre + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Planes_de_Suscripcion.Nombre LIKE '%" + filter.Nombre + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Nombre_del_Plan))
            {
                switch (filter.Nombre_del_PlanFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Planes_de_Suscripcion.Nombre_del_Plan LIKE '" + filter.Nombre_del_Plan + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Planes_de_Suscripcion.Nombre_del_Plan LIKE '%" + filter.Nombre_del_Plan + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Planes_de_Suscripcion.Nombre_del_Plan = '" + filter.Nombre_del_Plan + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Planes_de_Suscripcion.Nombre_del_Plan LIKE '%" + filter.Nombre_del_Plan + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.FromDuracion_en_meses) || !string.IsNullOrEmpty(filter.ToDuracion_en_meses))
            {
                if (!string.IsNullOrEmpty(filter.FromDuracion_en_meses))
                    where += " AND Planes_de_Suscripcion.Duracion_en_meses >= " + filter.FromDuracion_en_meses;
                if (!string.IsNullOrEmpty(filter.ToDuracion_en_meses))
                    where += " AND Planes_de_Suscripcion.Duracion_en_meses <= " + filter.ToDuracion_en_meses;
            }

            if (!string.IsNullOrEmpty(filter.FromDuracion) || !string.IsNullOrEmpty(filter.ToDuracion))
            {
                if (!string.IsNullOrEmpty(filter.FromDuracion))
                    where += " AND Planes_de_Suscripcion.Duracion >= " + filter.FromDuracion;
                if (!string.IsNullOrEmpty(filter.ToDuracion))
                    where += " AND Planes_de_Suscripcion.Duracion <= " + filter.ToDuracion;
            }

            if (!string.IsNullOrEmpty(filter.FromDietas_por_mes) || !string.IsNullOrEmpty(filter.ToDietas_por_mes))
            {
                if (!string.IsNullOrEmpty(filter.FromDietas_por_mes))
                    where += " AND Planes_de_Suscripcion.Dietas_por_mes >= " + filter.FromDietas_por_mes;
                if (!string.IsNullOrEmpty(filter.ToDietas_por_mes))
                    where += " AND Planes_de_Suscripcion.Dietas_por_mes <= " + filter.ToDietas_por_mes;
            }

            if (!string.IsNullOrEmpty(filter.FromRutinas_por_mes) || !string.IsNullOrEmpty(filter.ToRutinas_por_mes))
            {
                if (!string.IsNullOrEmpty(filter.FromRutinas_por_mes))
                    where += " AND Planes_de_Suscripcion.Rutinas_por_mes >= " + filter.FromRutinas_por_mes;
                if (!string.IsNullOrEmpty(filter.ToRutinas_por_mes))
                    where += " AND Planes_de_Suscripcion.Rutinas_por_mes <= " + filter.ToRutinas_por_mes;
            }

            if (!string.IsNullOrEmpty(filter.FromCosto_mensual) || !string.IsNullOrEmpty(filter.ToCosto_mensual))
            {
                if (!string.IsNullOrEmpty(filter.FromCosto_mensual))
                    where += " AND Planes_de_Suscripcion.Costo_mensual >= " + filter.FromCosto_mensual;
                if (!string.IsNullOrEmpty(filter.ToCosto_mensual))
                    where += " AND Planes_de_Suscripcion.Costo_mensual <= " + filter.ToCosto_mensual;
            }

            if (!string.IsNullOrEmpty(filter.FromPrecio_Final) || !string.IsNullOrEmpty(filter.ToPrecio_Final))
            {
                if (!string.IsNullOrEmpty(filter.FromPrecio_Final))
                    where += " AND Planes_de_Suscripcion.Precio_Final >= " + filter.FromPrecio_Final;
                if (!string.IsNullOrEmpty(filter.ToPrecio_Final))
                    where += " AND Planes_de_Suscripcion.Precio_Final <= " + filter.ToPrecio_Final;
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

                where += " AND Planes_de_Suscripcion.Estatus In (" + EstatusIds + ")";
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
        public ActionResult GetTipo_de_Beneficiario_MS_Beneficiarios_SuscripcionAll()
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

        public ActionResult GetMS_Beneficiarios_Suscripcion(int draw, int start, int length, int RelationId = 0)
        {
            if (RelationId == 0)
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<MS_Beneficiarios_SuscripcionGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IMS_Beneficiarios_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
			
var result = _IMS_Beneficiarios_SuscripcionApiConsumer.ListaSelAll(start, pageSize, "MS_Beneficiarios_Suscripcion.Folio_Planes_de_Suscripcion=" + RelationId,"").Resource;

            if (result.MS_Beneficiarios_Suscripcions == null)
                result.MS_Beneficiarios_Suscripcions = new List<MS_Beneficiarios_Suscripcion>();

            var jsonResult = Json(new
            {
                data = result.MS_Beneficiarios_Suscripcions.Select(m => new MS_Beneficiarios_SuscripcionGridModel
                {
                    Folio = m.Folio
					
                ,Beneficiario = m.Beneficiario
		,BeneficiarioDescripcion = m.Beneficiario_Tipo_Paciente.Descripcion


                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
[HttpGet]
        public ActionResult GetSemanas_del_Plan_MS_Semanas_PlanesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                
                _ISemanas_PlanesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISemanas_PlanesApiConsumer.SelAll(false).Resource;

                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetMS_Semanas_Planes(int draw, int start, int length, int RelationId = 0)
        {
            if (RelationId == 0)
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<MS_Semanas_PlanesGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IMS_Semanas_PlanesApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
			
var result = _IMS_Semanas_PlanesApiConsumer.ListaSelAll(start, pageSize, "MS_Semanas_Planes.Folio_Planes_de_Suscripcion=" + RelationId,"").Resource;

            if (result.MS_Semanas_Planess == null)
                result.MS_Semanas_Planess = new List<MS_Semanas_Planes>();

            var jsonResult = Json(new
            {
                data = result.MS_Semanas_Planess.Select(m => new MS_Semanas_PlanesGridModel
                {
                    Folio = m.Folio
					
                ,Semanas = m.Semanas
		,SemanasSemana = m.Semanas_Semanas_Planes.Semana


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
                _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);

                Planes_de_Suscripcion varPlanes_de_Suscripcion = null;
                if (id.ToString() != "0")
                {
                        string where = "";
                    _IMS_Beneficiarios_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "MS_Beneficiarios_Suscripcion.Folio_Planes_de_Suscripcion=" + id;
                    if("int" == "string")
                    {
	                where = "MS_Beneficiarios_Suscripcion.Folio_Planes_de_Suscripcion='" + id + "'";
                    }
                    var MS_Beneficiarios_SuscripcionInfo =
                        _IMS_Beneficiarios_SuscripcionApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (MS_Beneficiarios_SuscripcionInfo.MS_Beneficiarios_Suscripcions.Count > 0)
                    {
                        var resultMS_Beneficiarios_Suscripcion = true;
                        //Removing associated job history with attachment
                        foreach (var MS_Beneficiarios_SuscripcionItem in MS_Beneficiarios_SuscripcionInfo.MS_Beneficiarios_Suscripcions)
                            resultMS_Beneficiarios_Suscripcion = resultMS_Beneficiarios_Suscripcion
                                              && _IMS_Beneficiarios_SuscripcionApiConsumer.Delete(MS_Beneficiarios_SuscripcionItem.Folio, null,null).Resource;

                        if (!resultMS_Beneficiarios_Suscripcion)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _IMS_Semanas_PlanesApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "MS_Semanas_Planes.Folio_Planes_de_Suscripcion=" + id;
                    if("int" == "string")
                    {
	                where = "MS_Semanas_Planes.Folio_Planes_de_Suscripcion='" + id + "'";
                    }
                    var MS_Semanas_PlanesInfo =
                        _IMS_Semanas_PlanesApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (MS_Semanas_PlanesInfo.MS_Semanas_Planess.Count > 0)
                    {
                        var resultMS_Semanas_Planes = true;
                        //Removing associated job history with attachment
                        foreach (var MS_Semanas_PlanesItem in MS_Semanas_PlanesInfo.MS_Semanas_Planess)
                            resultMS_Semanas_Planes = resultMS_Semanas_Planes
                                              && _IMS_Semanas_PlanesApiConsumer.Delete(MS_Semanas_PlanesItem.Folio, null,null).Resource;

                        if (!resultMS_Semanas_Planes)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                var result = _IPlanes_de_SuscripcionApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Planes_de_SuscripcionModel varPlanes_de_Suscripcion)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Planes_de_SuscripcionInfo = new Planes_de_Suscripcion
                    {
                        Folio = varPlanes_de_Suscripcion.Folio
                        ,Fecha_de_Registro = (!String.IsNullOrEmpty(varPlanes_de_Suscripcion.Fecha_de_Registro)) ? DateTime.ParseExact(varPlanes_de_Suscripcion.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varPlanes_de_Suscripcion.Hora_de_Registro
                        ,Usuario_que_Registra = varPlanes_de_Suscripcion.Usuario_que_Registra
                        ,Nombre = varPlanes_de_Suscripcion.Nombre
                        ,Nombre_del_Plan = varPlanes_de_Suscripcion.Nombre_del_Plan
                        ,Duracion_en_meses = varPlanes_de_Suscripcion.Duracion_en_meses
                        ,Duracion = varPlanes_de_Suscripcion.Duracion
                        ,Dietas_por_mes = varPlanes_de_Suscripcion.Dietas_por_mes
                        ,Rutinas_por_mes = varPlanes_de_Suscripcion.Rutinas_por_mes
                        ,Costo_mensual = varPlanes_de_Suscripcion.Costo_mensual
                        ,Precio_Final = varPlanes_de_Suscripcion.Precio_Final
                        ,Estatus = varPlanes_de_Suscripcion.Estatus

                    };

                    result = !IsNew ?
                        _IPlanes_de_SuscripcionApiConsumer.Update(Planes_de_SuscripcionInfo, null, null).Resource.ToString() :
                         _IPlanes_de_SuscripcionApiConsumer.Insert(Planes_de_SuscripcionInfo, null, null).Resource.ToString();
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
        public bool CopyMS_Beneficiarios_Suscripcion(int MasterId, int referenceId, List<MS_Beneficiarios_SuscripcionGridModelPost> MS_Beneficiarios_SuscripcionItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IMS_Beneficiarios_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);

                var MS_Beneficiarios_SuscripcionData = _IMS_Beneficiarios_SuscripcionApiConsumer.ListaSelAll(1, int.MaxValue, "MS_Beneficiarios_Suscripcion.Folio_Planes_de_Suscripcion=" + referenceId,"").Resource;
                if (MS_Beneficiarios_SuscripcionData == null || MS_Beneficiarios_SuscripcionData.MS_Beneficiarios_Suscripcions.Count == 0)
                    return true;

                var result = true;

                MS_Beneficiarios_SuscripcionGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varMS_Beneficiarios_Suscripcion in MS_Beneficiarios_SuscripcionData.MS_Beneficiarios_Suscripcions)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    MS_Beneficiarios_Suscripcion MS_Beneficiarios_Suscripcion1 = varMS_Beneficiarios_Suscripcion;

                    if (MS_Beneficiarios_SuscripcionItems != null && MS_Beneficiarios_SuscripcionItems.Any(m => m.Folio == MS_Beneficiarios_Suscripcion1.Folio))
                    {
                        modelDataToChange = MS_Beneficiarios_SuscripcionItems.FirstOrDefault(m => m.Folio == MS_Beneficiarios_Suscripcion1.Folio);
                    }
                    //Chaning Id Value
                    varMS_Beneficiarios_Suscripcion.Folio_Planes_de_Suscripcion = MasterId;
                    var insertId = _IMS_Beneficiarios_SuscripcionApiConsumer.Insert(varMS_Beneficiarios_Suscripcion,null,null).Resource;
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
        public ActionResult PostMS_Beneficiarios_Suscripcion(List<MS_Beneficiarios_SuscripcionGridModelPost> MS_Beneficiarios_SuscripcionItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyMS_Beneficiarios_Suscripcion(MasterId, referenceId, MS_Beneficiarios_SuscripcionItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (MS_Beneficiarios_SuscripcionItems != null && MS_Beneficiarios_SuscripcionItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IMS_Beneficiarios_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var MS_Beneficiarios_SuscripcionItem in MS_Beneficiarios_SuscripcionItems)
                    {



                        //Removal Request
                        if (MS_Beneficiarios_SuscripcionItem.Removed)
                        {
                            result = result && _IMS_Beneficiarios_SuscripcionApiConsumer.Delete(MS_Beneficiarios_SuscripcionItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							MS_Beneficiarios_SuscripcionItem.Folio = 0;

                        var MS_Beneficiarios_SuscripcionData = new MS_Beneficiarios_Suscripcion
                        {
                            Folio_Planes_de_Suscripcion = MasterId
                            ,Folio = MS_Beneficiarios_SuscripcionItem.Folio
                            ,Beneficiario = (Convert.ToInt32(MS_Beneficiarios_SuscripcionItem.Beneficiario) == 0 ? (Int32?)null : Convert.ToInt32(MS_Beneficiarios_SuscripcionItem.Beneficiario))

                        };

                        var resultId = MS_Beneficiarios_SuscripcionItem.Folio > 0
                           ? _IMS_Beneficiarios_SuscripcionApiConsumer.Update(MS_Beneficiarios_SuscripcionData,null,null).Resource
                           : _IMS_Beneficiarios_SuscripcionApiConsumer.Insert(MS_Beneficiarios_SuscripcionData,null,null).Resource;

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
        public ActionResult GetMS_Beneficiarios_Suscripcion_Tipo_PacienteAll()
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
        public bool CopyMS_Semanas_Planes(int MasterId, int referenceId, List<MS_Semanas_PlanesGridModelPost> MS_Semanas_PlanesItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IMS_Semanas_PlanesApiConsumer.SetAuthHeader(_tokenManager.Token);

                var MS_Semanas_PlanesData = _IMS_Semanas_PlanesApiConsumer.ListaSelAll(1, int.MaxValue, "MS_Semanas_Planes.Folio_Planes_de_Suscripcion=" + referenceId,"").Resource;
                if (MS_Semanas_PlanesData == null || MS_Semanas_PlanesData.MS_Semanas_Planess.Count == 0)
                    return true;

                var result = true;

                MS_Semanas_PlanesGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varMS_Semanas_Planes in MS_Semanas_PlanesData.MS_Semanas_Planess)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    MS_Semanas_Planes MS_Semanas_Planes1 = varMS_Semanas_Planes;

                    if (MS_Semanas_PlanesItems != null && MS_Semanas_PlanesItems.Any(m => m.Folio == MS_Semanas_Planes1.Folio))
                    {
                        modelDataToChange = MS_Semanas_PlanesItems.FirstOrDefault(m => m.Folio == MS_Semanas_Planes1.Folio);
                    }
                    //Chaning Id Value
                    varMS_Semanas_Planes.Folio_Planes_de_Suscripcion = MasterId;
                    var insertId = _IMS_Semanas_PlanesApiConsumer.Insert(varMS_Semanas_Planes,null,null).Resource;
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
        public ActionResult PostMS_Semanas_Planes(List<MS_Semanas_PlanesGridModelPost> MS_Semanas_PlanesItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyMS_Semanas_Planes(MasterId, referenceId, MS_Semanas_PlanesItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (MS_Semanas_PlanesItems != null && MS_Semanas_PlanesItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IMS_Semanas_PlanesApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var MS_Semanas_PlanesItem in MS_Semanas_PlanesItems)
                    {



                        //Removal Request
                        if (MS_Semanas_PlanesItem.Removed)
                        {
                            result = result && _IMS_Semanas_PlanesApiConsumer.Delete(MS_Semanas_PlanesItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							MS_Semanas_PlanesItem.Folio = 0;

                        var MS_Semanas_PlanesData = new MS_Semanas_Planes
                        {
                            Folio_Planes_de_Suscripcion = MasterId
                            ,Folio = MS_Semanas_PlanesItem.Folio
                            ,Semanas = (Convert.ToInt32(MS_Semanas_PlanesItem.Semanas) == 0 ? (Int32?)null : Convert.ToInt32(MS_Semanas_PlanesItem.Semanas))

                        };

                        var resultId = MS_Semanas_PlanesItem.Folio > 0
                           ? _IMS_Semanas_PlanesApiConsumer.Update(MS_Semanas_PlanesData,null,null).Resource
                           : _IMS_Semanas_PlanesApiConsumer.Insert(MS_Semanas_PlanesData,null,null).Resource;

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
        public ActionResult GetMS_Semanas_Planes_Semanas_PlanesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISemanas_PlanesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISemanas_PlanesApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Folio), "Semanas_Planes", "Semana");
                  item.Semana= trans??item.Semana;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }



        /// <summary>
        /// Write Element Array of Planes_de_Suscripcion script
        /// </summary>
        /// <param name="oPlanes_de_SuscripcionElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew Planes_de_SuscripcionModuleAttributeList)
        {
            for (int i = 0; i < Planes_de_SuscripcionModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Planes_de_SuscripcionModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Planes_de_SuscripcionModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Planes_de_SuscripcionModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Planes_de_SuscripcionModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Planes_de_SuscripcionModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Planes_de_SuscripcionModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < Planes_de_SuscripcionModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(Planes_de_SuscripcionModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							Planes_de_SuscripcionModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(Planes_de_SuscripcionModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							Planes_de_SuscripcionModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strPlanes_de_SuscripcionScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Planes_de_Suscripcion.js")))
            {
                strPlanes_de_SuscripcionScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Planes_de_Suscripcion element attributes
            string userChangeJson = jsSerialize.Serialize(Planes_de_SuscripcionModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strPlanes_de_SuscripcionScript.IndexOf("inpuElementArray");
            string splittedString = strPlanes_de_SuscripcionScript.Substring(indexOfArray, strPlanes_de_SuscripcionScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Planes_de_SuscripcionModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Planes_de_SuscripcionModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strPlanes_de_SuscripcionScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strPlanes_de_SuscripcionScript.Substring(indexOfArrayHistory, strPlanes_de_SuscripcionScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strPlanes_de_SuscripcionScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strPlanes_de_SuscripcionScript.Substring(endIndexOfMainElement + indexOfArray, strPlanes_de_SuscripcionScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (Planes_de_SuscripcionModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in Planes_de_SuscripcionModuleAttributeList.ChildModuleAttributeList)
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
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Planes_de_Suscripcion.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Planes_de_Suscripcion.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Planes_de_Suscripcion.js")))
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
        public ActionResult Planes_de_SuscripcionPropertyBag()
        {
            return PartialView("Planes_de_SuscripcionPropertyBag", "Planes_de_Suscripcion");
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
        public ActionResult AddMS_Beneficiarios_Suscripcion(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../MS_Beneficiarios_Suscripcion/AddMS_Beneficiarios_Suscripcion");
        }

        [HttpGet]
        public ActionResult AddMS_Semanas_Planes(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../MS_Semanas_Planes/AddMS_Semanas_Planes");
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
                var whereClauseFormat = "Object = 44396 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Planes_de_Suscripcion.Folio= " + RecordId;
                            var result = _IPlanes_de_SuscripcionApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
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

            _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Planes_de_SuscripcionPropertyMapper());
			
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
                    (Planes_de_SuscripcionAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
			string sortDirection = "asc";

            Planes_de_SuscripcionPropertyMapper oPlanes_de_SuscripcionPropertyMapper = new Planes_de_SuscripcionPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oPlanes_de_SuscripcionPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IPlanes_de_SuscripcionApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Planes_de_Suscripcions == null)
                result.Planes_de_Suscripcions = new List<Planes_de_Suscripcion>();

            var data = result.Planes_de_Suscripcions.Select(m => new Planes_de_SuscripcionGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre = m.Nombre
			,Nombre_del_Plan = m.Nombre_del_Plan
			,Duracion_en_meses = m.Duracion_en_meses
			,Duracion = m.Duracion
			,Dietas_por_mes = m.Dietas_por_mes
			,Rutinas_por_mes = m.Rutinas_por_mes
			,Costo_mensual = m.Costo_mensual
			,Precio_Final = m.Precio_Final
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(44396, arrayColumnsVisible), "Planes_de_SuscripcionList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(44396, arrayColumnsVisible), "Planes_de_SuscripcionList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(44396, arrayColumnsVisible), "Planes_de_SuscripcionList_" + DateTime.Now.ToString());
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

            _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Planes_de_SuscripcionPropertyMapper());
				
				
            if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
			if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (Planes_de_SuscripcionAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            Planes_de_SuscripcionPropertyMapper oPlanes_de_SuscripcionPropertyMapper = new Planes_de_SuscripcionPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oPlanes_de_SuscripcionPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
			
			if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IPlanes_de_SuscripcionApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Planes_de_Suscripcions == null)
                result.Planes_de_Suscripcions = new List<Planes_de_Suscripcion>();

            var data = result.Planes_de_Suscripcions.Select(m => new Planes_de_SuscripcionGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre = m.Nombre
			,Nombre_del_Plan = m.Nombre_del_Plan
			,Duracion_en_meses = m.Duracion_en_meses
			,Duracion = m.Duracion
			,Dietas_por_mes = m.Dietas_por_mes
			,Rutinas_por_mes = m.Rutinas_por_mes
			,Costo_mensual = m.Costo_mensual
			,Precio_Final = m.Precio_Final
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
                _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPlanes_de_SuscripcionApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpPost]
        public ActionResult Post_Datos_Generales(Planes_de_Suscripcion_Datos_GeneralesModel varPlanes_de_Suscripcion)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Planes_de_Suscripcion_Datos_GeneralesInfo = new Planes_de_Suscripcion_Datos_Generales
                {
                    Folio = varPlanes_de_Suscripcion.Folio
                                            ,Fecha_de_Registro = (!String.IsNullOrEmpty(varPlanes_de_Suscripcion.Fecha_de_Registro)) ? DateTime.ParseExact(varPlanes_de_Suscripcion.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varPlanes_de_Suscripcion.Hora_de_Registro
                        ,Usuario_que_Registra = varPlanes_de_Suscripcion.Usuario_que_Registra
                        ,Nombre = varPlanes_de_Suscripcion.Nombre
                        ,Nombre_del_Plan = varPlanes_de_Suscripcion.Nombre_del_Plan
                        ,Duracion_en_meses = varPlanes_de_Suscripcion.Duracion_en_meses
                        ,Duracion = varPlanes_de_Suscripcion.Duracion
                        ,Dietas_por_mes = varPlanes_de_Suscripcion.Dietas_por_mes
                        ,Rutinas_por_mes = varPlanes_de_Suscripcion.Rutinas_por_mes
                        ,Costo_mensual = varPlanes_de_Suscripcion.Costo_mensual
                        ,Precio_Final = varPlanes_de_Suscripcion.Precio_Final
                        ,Estatus = varPlanes_de_Suscripcion.Estatus
                    
                };

                result = _IPlanes_de_SuscripcionApiConsumer.Update_Datos_Generales(Planes_de_Suscripcion_Datos_GeneralesInfo).Resource.ToString();
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
                _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IPlanes_de_SuscripcionApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				
                var result = new Planes_de_Suscripcion_Datos_GeneralesModel
                {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_Registra = m.Usuario_que_Registra
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre = m.Nombre
			,Nombre_del_Plan = m.Nombre_del_Plan
			,Duracion_en_meses = m.Duracion_en_meses
			,Duracion = m.Duracion
			,Dietas_por_mes = m.Dietas_por_mes
			,Rutinas_por_mes = m.Rutinas_por_mes
			,Costo_mensual = m.Costo_mensual
			,Precio_Final = m.Precio_Final
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion

                    
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

