using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Metodos_de_Pago_Paciente;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.MR_Tarjetas;

using Spartane.Core.Domain.Tipo_de_Tarjeta;





using Spartane.Core.Domain.Estatus;


using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Metodos_de_Pago_Paciente;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Metodos_de_Pago_Paciente;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.MR_Tarjetas;

using Spartane.Web.Areas.WebApiConsumer.Tipo_de_Tarjeta;
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
    public class Metodos_de_Pago_PacienteController : Controller
    {
        #region "variable declaration"

        private IMetodos_de_Pago_PacienteService service = null;
        private IMetodos_de_Pago_PacienteApiConsumer _IMetodos_de_Pago_PacienteApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private IMR_TarjetasApiConsumer _IMR_TarjetasApiConsumer;

        private ITipo_de_TarjetaApiConsumer _ITipo_de_TarjetaApiConsumer;
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

        
        public Metodos_de_Pago_PacienteController(IMetodos_de_Pago_PacienteService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IMetodos_de_Pago_PacienteApiConsumer Metodos_de_Pago_PacienteApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer , IMR_TarjetasApiConsumer MR_TarjetasApiConsumer , ITipo_de_TarjetaApiConsumer Tipo_de_TarjetaApiConsumer , IEstatusApiConsumer EstatusApiConsumer  )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IMetodos_de_Pago_PacienteApiConsumer = Metodos_de_Pago_PacienteApiConsumer;
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
            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;
            this._IMR_TarjetasApiConsumer = MR_TarjetasApiConsumer;

            this._ITipo_de_TarjetaApiConsumer = Tipo_de_TarjetaApiConsumer;
            this._IEstatusApiConsumer = EstatusApiConsumer;


        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Metodos_de_Pago_Paciente
        [ObjectAuth(ObjectId = (ModuleObjectId)44788, PermissionType = PermissionTypes.Consult)]
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
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44788, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			          
            return View();
        }

        // GET: Frontal/Metodos_de_Pago_Paciente/Create
          [ObjectAuth(ObjectId = (ModuleObjectId)44788, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44788, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varMetodos_de_Pago_Paciente = new Metodos_de_Pago_PacienteModel();
			varMetodos_de_Pago_Paciente.Folio = Id;
			
            ViewBag.ObjectId = "44788";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;

            var permissionMR_Tarjetas = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44790, ModuleId);
            ViewBag.PermissionMR_Tarjetas = permissionMR_Tarjetas;


            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
				
				_tokenManager.GenerateToken();
				_ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _IMetodos_de_Pago_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Metodos_de_Pago_PacientesData = _IMetodos_de_Pago_PacienteApiConsumer.ListaSelAll(0, 1000, "Metodos_de_Pago_Paciente.Folio=" + Id, "").Resource.Metodos_de_Pago_Pacientes;
				
				if (Metodos_de_Pago_PacientesData != null && Metodos_de_Pago_PacientesData.Count > 0)
                {
					var Metodos_de_Pago_PacienteData = Metodos_de_Pago_PacientesData.First();
					varMetodos_de_Pago_Paciente= new Metodos_de_Pago_PacienteModel
					{
						Folio  = Metodos_de_Pago_PacienteData.Folio 
	                    ,Fecha_de_Registro = (Metodos_de_Pago_PacienteData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(Metodos_de_Pago_PacienteData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = Metodos_de_Pago_PacienteData.Hora_de_Registro
                    ,Usuario_que_Registra = Metodos_de_Pago_PacienteData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(Metodos_de_Pago_PacienteData.Usuario_que_Registra), "Spartan_User") ??  (string)Metodos_de_Pago_PacienteData.Usuario_que_Registra_Spartan_User.Name
                    ,Paciente = Metodos_de_Pago_PacienteData.Paciente
                    ,PacienteName = CultureHelper.GetTraduction(Convert.ToString(Metodos_de_Pago_PacienteData.Paciente), "Spartan_User") ??  (string)Metodos_de_Pago_PacienteData.Paciente_Spartan_User.Name

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
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Paciente = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Paciente != null && Spartan_Users_Paciente.Resource != null)
                ViewBag.Spartan_Users_Paciente = Spartan_Users_Paciente.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
				
			var viewInEframe = false;
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
				
			if (Request.QueryString["viewInEframe"] != null)
                viewInEframe = Convert.ToBoolean(Request.QueryString["viewInEframe"]);	
				
			ViewBag.isPartial=isPartial;
			ViewBag.isMR=isMR;
			ViewBag.nameMR=nameMR;
			ViewBag.nameAttribute=nameAttribute;
			ViewBag.viewInEframe = viewInEframe;

				
            return View(varMetodos_de_Pago_Paciente);
        }
		
	[HttpGet]
        public ActionResult AddMetodos_de_Pago_Paciente(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44788);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IMetodos_de_Pago_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
			Metodos_de_Pago_PacienteModel varMetodos_de_Pago_Paciente= new Metodos_de_Pago_PacienteModel();
            var permissionMR_Tarjetas = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44790, ModuleId);
            ViewBag.PermissionMR_Tarjetas = permissionMR_Tarjetas;


            if (id.ToString() != "0")
            {
                var Metodos_de_Pago_PacientesData = _IMetodos_de_Pago_PacienteApiConsumer.ListaSelAll(0, 1000, "Metodos_de_Pago_Paciente.Folio=" + id, "").Resource.Metodos_de_Pago_Pacientes;
				
				if (Metodos_de_Pago_PacientesData != null && Metodos_de_Pago_PacientesData.Count > 0)
                {
					var Metodos_de_Pago_PacienteData = Metodos_de_Pago_PacientesData.First();
					varMetodos_de_Pago_Paciente= new Metodos_de_Pago_PacienteModel
					{
						Folio  = Metodos_de_Pago_PacienteData.Folio 
	                    ,Fecha_de_Registro = (Metodos_de_Pago_PacienteData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(Metodos_de_Pago_PacienteData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = Metodos_de_Pago_PacienteData.Hora_de_Registro
                    ,Usuario_que_Registra = Metodos_de_Pago_PacienteData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(Metodos_de_Pago_PacienteData.Usuario_que_Registra), "Spartan_User") ??  (string)Metodos_de_Pago_PacienteData.Usuario_que_Registra_Spartan_User.Name
                    ,Paciente = Metodos_de_Pago_PacienteData.Paciente
                    ,PacienteName = CultureHelper.GetTraduction(Convert.ToString(Metodos_de_Pago_PacienteData.Paciente), "Spartan_User") ??  (string)Metodos_de_Pago_PacienteData.Paciente_Spartan_User.Name

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
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Paciente = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Paciente != null && Spartan_Users_Paciente.Resource != null)
                ViewBag.Spartan_Users_Paciente = Spartan_Users_Paciente.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();


            return PartialView("AddMetodos_de_Pago_Paciente", varMetodos_de_Pago_Paciente);
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
        public ActionResult ShowAdvanceFilter(Metodos_de_Pago_PacienteAdvanceSearchModel model, int idFilter = -1)
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
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Paciente = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Paciente != null && Spartan_Users_Paciente.Resource != null)
                ViewBag.Spartan_Users_Paciente = Spartan_Users_Paciente.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
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
            var Spartan_Users_Usuario_que_Registra = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_que_Registra != null && Spartan_Users_Usuario_que_Registra.Resource != null)
                ViewBag.Spartan_Users_Usuario_que_Registra = Spartan_Users_Usuario_que_Registra.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Paciente = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Paciente != null && Spartan_Users_Paciente.Resource != null)
                ViewBag.Spartan_Users_Paciente = Spartan_Users_Paciente.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();


            var previousFiltersObj = new Metodos_de_Pago_PacienteAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Metodos_de_Pago_PacienteAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Metodos_de_Pago_PacienteAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Metodos_de_Pago_PacientePropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IMetodos_de_Pago_PacienteApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Metodos_de_Pago_Pacientes == null)
                result.Metodos_de_Pago_Pacientes = new List<Metodos_de_Pago_Paciente>();

            return Json(new
            {
                data = result.Metodos_de_Pago_Pacientes.Select(m => new Metodos_de_Pago_PacienteGridModel
                    {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,PacienteName = CultureHelper.GetTraduction(m.Paciente_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Paciente_Spartan_User.Name

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }
		/*
		 [HttpGet]
        public ActionResult GetMetodos_de_Pago_PacienteAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMetodos_de_Pago_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IMetodos_de_Pago_PacienteApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraductionNew(Convert.ToString(m.Folio), "Metodos_de_Pago_Paciente", m.),
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
        /// Get List of Metodos_de_Pago_Paciente from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Metodos_de_Pago_Paciente Entity</returns>
        public ActionResult GetMetodos_de_Pago_PacienteList(UrlParametersModel param)
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
            _IMetodos_de_Pago_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);

          
            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new Metodos_de_Pago_PacientePropertyMapper());
				
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
				if (Session["AdvanceSearch"].GetType() == typeof(Metodos_de_Pago_PacienteAdvanceSearchModel))
                {
					var advanceFilter =
                    (Metodos_de_Pago_PacienteAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            Metodos_de_Pago_PacientePropertyMapper oMetodos_de_Pago_PacientePropertyMapper = new Metodos_de_Pago_PacientePropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                 if (sortColumn != -1)
                    configuration.OrderByClause = oMetodos_de_Pago_PacientePropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _IMetodos_de_Pago_PacienteApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Metodos_de_Pago_Pacientes == null)
                result.Metodos_de_Pago_Pacientes = new List<Metodos_de_Pago_Paciente>();

            return Json(new
            {
                aaData = result.Metodos_de_Pago_Pacientes.Select(m => new Metodos_de_Pago_PacienteGridModel
            {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,PacienteName = CultureHelper.GetTraduction(m.Paciente_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Paciente_Spartan_User.Name

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }


//Grid GetAutoComplete






        [NonAction]
        public string GetAdvanceFilter(Metodos_de_Pago_PacienteAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromFolio) || !string.IsNullOrEmpty(filter.ToFolio))
            {
                if (!string.IsNullOrEmpty(filter.FromFolio))
                    where += " AND Metodos_de_Pago_Paciente.Folio >= " + filter.FromFolio;
                if (!string.IsNullOrEmpty(filter.ToFolio))
                    where += " AND Metodos_de_Pago_Paciente.Folio <= " + filter.ToFolio;
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro) || !string.IsNullOrEmpty(filter.ToFecha_de_Registro))
            {
                var Fecha_de_RegistroFrom = DateTime.ParseExact(filter.FromFecha_de_Registro, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_de_RegistroTo = DateTime.ParseExact(filter.ToFecha_de_Registro, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro))
                    where += " AND Metodos_de_Pago_Paciente.Fecha_de_Registro >= '" + Fecha_de_RegistroFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_Registro))
                    where += " AND Metodos_de_Pago_Paciente.Fecha_de_Registro <= '" + Fecha_de_RegistroTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromHora_de_Registro) || !string.IsNullOrEmpty(filter.ToHora_de_Registro))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_de_Registro))
                    where += " AND Convert(TIME,Metodos_de_Pago_Paciente.Hora_de_Registro) >='" + filter.FromHora_de_Registro + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_de_Registro))
                    where += " AND Convert(TIME,Metodos_de_Pago_Paciente.Hora_de_Registro) <='" + filter.ToHora_de_Registro + "'";
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

                where += " AND Metodos_de_Pago_Paciente.Usuario_que_Registra In (" + Usuario_que_RegistraIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvancePaciente))
            {
                switch (filter.PacienteFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_User.Name LIKE '" + filter.AdvancePaciente + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvancePaciente + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_User.Name = '" + filter.AdvancePaciente + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvancePaciente + "%'";
                        break;
                }
            }
            else if (filter.AdvancePacienteMultiple != null && filter.AdvancePacienteMultiple.Count() > 0)
            {
                var PacienteIds = string.Join(",", filter.AdvancePacienteMultiple);

                where += " AND Metodos_de_Pago_Paciente.Paciente In (" + PacienteIds + ")";
            }


            where = new Regex(Regex.Escape("AND ")).Replace(where, "", 1);
            return where;
        }

        [NonAction]
        public Grid_File ConvertSpartane_FileToGridFile(Spartane.Core.Domain.Spartane_File.Spartane_File file)
        {
            return file == null ? new Grid_File { FileId = 0, FileSize = 0, FileName = "" } : new Grid_File { FileId = file.File_Id, FileName = file.Description, FileSize = file.File_Size ?? 0, };
        }

        public ActionResult GetMR_Tarjetas(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<MR_TarjetasGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IMR_TarjetasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "MR_Tarjetas.Folio_Metodos_de_Pago_Paciente=" + RelationId;
            if("int" == "string")
            {
	           where = "MR_Tarjetas.Folio_Metodos_de_Pago_Paciente='" + RelationId + "'";
            }
            var result = _IMR_TarjetasApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.MR_Tarjetass == null)
                result.MR_Tarjetass = new List<MR_Tarjetas>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.MR_Tarjetass.Select(m => new MR_TarjetasGridModel
                {
                    Folio = m.Folio

                        ,Tipo_de_Tarjeta = m.Tipo_de_Tarjeta
                        ,Tipo_de_TarjetaDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Tarjeta_Tipo_de_Tarjeta.Clave.ToString(), "Descripcion") ??(string)m.Tipo_de_Tarjeta_Tipo_de_Tarjeta.Descripcion
			,Numero_de_Tarjeta = m.Numero_de_Tarjeta
			,Nombre_del_Titular = m.Nombre_del_Titular
			,Ano_de_vigencia = m.Ano_de_vigencia
			,Mes_de_vigencia = m.Mes_de_vigencia
			,Alias_de_la_Tarjeta = m.Alias_de_la_Tarjeta
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ??(string)m.Estatus_Estatus.Descripcion

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<MR_TarjetasGridModel> GetMR_TarjetasData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<MR_TarjetasGridModel> resultData = new List<MR_TarjetasGridModel>();
            string where = "MR_Tarjetas.Folio_Metodos_de_Pago_Paciente=" + Id;
            if("int" == "string")
            {
                where = "MR_Tarjetas.Folio_Metodos_de_Pago_Paciente='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IMR_TarjetasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IMR_TarjetasApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.MR_Tarjetass != null)
            {
                resultData = result.MR_Tarjetass.Select(m => new MR_TarjetasGridModel
                    {
                        Folio = m.Folio

                        ,Tipo_de_Tarjeta = m.Tipo_de_Tarjeta
                        ,Tipo_de_TarjetaDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Tarjeta_Tipo_de_Tarjeta.Clave.ToString(), "Descripcion") ??(string)m.Tipo_de_Tarjeta_Tipo_de_Tarjeta.Descripcion
			,Numero_de_Tarjeta = m.Numero_de_Tarjeta
			,Nombre_del_Titular = m.Nombre_del_Titular
			,Ano_de_vigencia = m.Ano_de_vigencia
			,Mes_de_vigencia = m.Mes_de_vigencia
			,Alias_de_la_Tarjeta = m.Alias_de_la_Tarjeta
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ??(string)m.Estatus_Estatus.Descripcion


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
                _IMetodos_de_Pago_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);

                Metodos_de_Pago_Paciente varMetodos_de_Pago_Paciente = null;
                if (id.ToString() != "0")
                {
                        string where = "";
                    _IMR_TarjetasApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "MR_Tarjetas.Folio_Metodos_de_Pago_Paciente=" + id;
                    if("int" == "string")
                    {
	                where = "MR_Tarjetas.Folio_Metodos_de_Pago_Paciente='" + id + "'";
                    }
                    var MR_TarjetasInfo =
                        _IMR_TarjetasApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (MR_TarjetasInfo.MR_Tarjetass.Count > 0)
                    {
                        var resultMR_Tarjetas = true;
                        //Removing associated job history with attachment
                        foreach (var MR_TarjetasItem in MR_TarjetasInfo.MR_Tarjetass)
                            resultMR_Tarjetas = resultMR_Tarjetas
                                              && _IMR_TarjetasApiConsumer.Delete(MR_TarjetasItem.Folio, null,null).Resource;

                        if (!resultMR_Tarjetas)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                var result = _IMetodos_de_Pago_PacienteApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Metodos_de_Pago_PacienteModel varMetodos_de_Pago_Paciente)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IMetodos_de_Pago_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Metodos_de_Pago_PacienteInfo = new Metodos_de_Pago_Paciente
                    {
                        Folio = varMetodos_de_Pago_Paciente.Folio
                        ,Fecha_de_Registro = (!String.IsNullOrEmpty(varMetodos_de_Pago_Paciente.Fecha_de_Registro)) ? DateTime.ParseExact(varMetodos_de_Pago_Paciente.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varMetodos_de_Pago_Paciente.Hora_de_Registro
                        ,Usuario_que_Registra = varMetodos_de_Pago_Paciente.Usuario_que_Registra
                        ,Paciente = varMetodos_de_Pago_Paciente.Paciente

                    };

                    result = !IsNew ?
                        _IMetodos_de_Pago_PacienteApiConsumer.Update(Metodos_de_Pago_PacienteInfo, null, null).Resource.ToString() :
                         _IMetodos_de_Pago_PacienteApiConsumer.Insert(Metodos_de_Pago_PacienteInfo, null, null).Resource.ToString();
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
        public bool CopyMR_Tarjetas(int MasterId, int referenceId, List<MR_TarjetasGridModelPost> MR_TarjetasItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IMR_TarjetasApiConsumer.SetAuthHeader(_tokenManager.Token);

                var MR_TarjetasData = _IMR_TarjetasApiConsumer.ListaSelAll(1, int.MaxValue, "MR_Tarjetas.Folio_Metodos_de_Pago_Paciente=" + referenceId,"").Resource;
                if (MR_TarjetasData == null || MR_TarjetasData.MR_Tarjetass.Count == 0)
                    return true;

                var result = true;

                MR_TarjetasGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varMR_Tarjetas in MR_TarjetasData.MR_Tarjetass)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    MR_Tarjetas MR_Tarjetas1 = varMR_Tarjetas;

                    if (MR_TarjetasItems != null && MR_TarjetasItems.Any(m => m.Folio == MR_Tarjetas1.Folio))
                    {
                        modelDataToChange = MR_TarjetasItems.FirstOrDefault(m => m.Folio == MR_Tarjetas1.Folio);
                    }
                    //Chaning Id Value
                    varMR_Tarjetas.Folio_Metodos_de_Pago_Paciente = MasterId;
                    var insertId = _IMR_TarjetasApiConsumer.Insert(varMR_Tarjetas,null,null).Resource;
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
        public ActionResult PostMR_Tarjetas(List<MR_TarjetasGridModelPost> MR_TarjetasItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyMR_Tarjetas(MasterId, referenceId, MR_TarjetasItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (MR_TarjetasItems != null && MR_TarjetasItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IMR_TarjetasApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var MR_TarjetasItem in MR_TarjetasItems)
                    {









                        //Removal Request
                        if (MR_TarjetasItem.Removed)
                        {
                            result = result && _IMR_TarjetasApiConsumer.Delete(MR_TarjetasItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							MR_TarjetasItem.Folio = 0;

                        var MR_TarjetasData = new MR_Tarjetas
                        {
                            Folio_Metodos_de_Pago_Paciente = MasterId
                            ,Folio = MR_TarjetasItem.Folio
                            ,Tipo_de_Tarjeta = (Convert.ToInt32(MR_TarjetasItem.Tipo_de_Tarjeta) == 0 ? (Int32?)null : Convert.ToInt32(MR_TarjetasItem.Tipo_de_Tarjeta))
                            ,Numero_de_Tarjeta = MR_TarjetasItem.Numero_de_Tarjeta
                            ,Nombre_del_Titular = MR_TarjetasItem.Nombre_del_Titular
                            ,Ano_de_vigencia = MR_TarjetasItem.Ano_de_vigencia
                            ,Mes_de_vigencia = MR_TarjetasItem.Mes_de_vigencia
                            ,Alias_de_la_Tarjeta = MR_TarjetasItem.Alias_de_la_Tarjeta
                            ,Estatus = (Convert.ToInt32(MR_TarjetasItem.Estatus) == 0 ? (Int32?)null : Convert.ToInt32(MR_TarjetasItem.Estatus))

                        };

                        var resultId = MR_TarjetasItem.Folio > 0
                           ? _IMR_TarjetasApiConsumer.Update(MR_TarjetasData,null,null).Resource
                           : _IMR_TarjetasApiConsumer.Insert(MR_TarjetasData,null,null).Resource;

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
        public ActionResult GetMR_Tarjetas_Tipo_de_TarjetaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipo_de_TarjetaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipo_de_TarjetaApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Tipo_de_Tarjeta", "Descripcion");
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
        public ActionResult GetMR_Tarjetas_EstatusAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstatusApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Estatus", "Descripcion");
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
        /// Write Element Array of Metodos_de_Pago_Paciente script
        /// </summary>
        /// <param name="oMetodos_de_Pago_PacienteElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew Metodos_de_Pago_PacienteModuleAttributeList)
        {
            for (int i = 0; i < Metodos_de_Pago_PacienteModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Metodos_de_Pago_PacienteModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Metodos_de_Pago_PacienteModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Metodos_de_Pago_PacienteModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Metodos_de_Pago_PacienteModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Metodos_de_Pago_PacienteModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Metodos_de_Pago_PacienteModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < Metodos_de_Pago_PacienteModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(Metodos_de_Pago_PacienteModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							Metodos_de_Pago_PacienteModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(Metodos_de_Pago_PacienteModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							Metodos_de_Pago_PacienteModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strMetodos_de_Pago_PacienteScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Metodos_de_Pago_Paciente.js")))
            {
                strMetodos_de_Pago_PacienteScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Metodos_de_Pago_Paciente element attributes
            string userChangeJson = jsSerialize.Serialize(Metodos_de_Pago_PacienteModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strMetodos_de_Pago_PacienteScript.IndexOf("inpuElementArray");
            string splittedString = strMetodos_de_Pago_PacienteScript.Substring(indexOfArray, strMetodos_de_Pago_PacienteScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Metodos_de_Pago_PacienteModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Metodos_de_Pago_PacienteModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strMetodos_de_Pago_PacienteScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strMetodos_de_Pago_PacienteScript.Substring(indexOfArrayHistory, strMetodos_de_Pago_PacienteScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strMetodos_de_Pago_PacienteScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strMetodos_de_Pago_PacienteScript.Substring(endIndexOfMainElement + indexOfArray, strMetodos_de_Pago_PacienteScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (Metodos_de_Pago_PacienteModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in Metodos_de_Pago_PacienteModuleAttributeList.ChildModuleAttributeList)
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
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Metodos_de_Pago_Paciente.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Metodos_de_Pago_Paciente.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Metodos_de_Pago_Paciente.js")))
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
        public ActionResult Metodos_de_Pago_PacientePropertyBag()
        {
            return PartialView("Metodos_de_Pago_PacientePropertyBag", "Metodos_de_Pago_Paciente");
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
        public ActionResult AddMR_Tarjetas(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../MR_Tarjetas/AddMR_Tarjetas");
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
                var whereClauseFormat = "Object = 44788 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _IMetodos_de_Pago_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Metodos_de_Pago_Paciente.Folio= " + RecordId;
                            var result = _IMetodos_de_Pago_PacienteApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
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

            _IMetodos_de_Pago_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Metodos_de_Pago_PacientePropertyMapper());
			
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
                    (Metodos_de_Pago_PacienteAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
			string sortDirection = "asc";

            Metodos_de_Pago_PacientePropertyMapper oMetodos_de_Pago_PacientePropertyMapper = new Metodos_de_Pago_PacientePropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oMetodos_de_Pago_PacientePropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMetodos_de_Pago_PacienteApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Metodos_de_Pago_Pacientes == null)
                result.Metodos_de_Pago_Pacientes = new List<Metodos_de_Pago_Paciente>();

            var data = result.Metodos_de_Pago_Pacientes.Select(m => new Metodos_de_Pago_PacienteGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,PacienteName = CultureHelper.GetTraduction(m.Paciente_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Paciente_Spartan_User.Name

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(44788, arrayColumnsVisible), "Metodos_de_Pago_PacienteList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(44788, arrayColumnsVisible), "Metodos_de_Pago_PacienteList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(44788, arrayColumnsVisible), "Metodos_de_Pago_PacienteList_" + DateTime.Now.ToString());
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

            _IMetodos_de_Pago_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Metodos_de_Pago_PacientePropertyMapper());
				
				
            if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
			if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (Metodos_de_Pago_PacienteAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            Metodos_de_Pago_PacientePropertyMapper oMetodos_de_Pago_PacientePropertyMapper = new Metodos_de_Pago_PacientePropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oMetodos_de_Pago_PacientePropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
			
			if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMetodos_de_Pago_PacienteApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Metodos_de_Pago_Pacientes == null)
                result.Metodos_de_Pago_Pacientes = new List<Metodos_de_Pago_Paciente>();

            var data = result.Metodos_de_Pago_Pacientes.Select(m => new Metodos_de_Pago_PacienteGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,PacienteName = CultureHelper.GetTraduction(m.Paciente_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Paciente_Spartan_User.Name

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
                _IMetodos_de_Pago_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IMetodos_de_Pago_PacienteApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpPost]
        public ActionResult Post_Datos_Generales(Metodos_de_Pago_Paciente_Datos_GeneralesModel varMetodos_de_Pago_Paciente)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMetodos_de_Pago_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Metodos_de_Pago_Paciente_Datos_GeneralesInfo = new Metodos_de_Pago_Paciente_Datos_Generales
                {
                    Folio = varMetodos_de_Pago_Paciente.Folio
                                            ,Fecha_de_Registro = (!String.IsNullOrEmpty(varMetodos_de_Pago_Paciente.Fecha_de_Registro)) ? DateTime.ParseExact(varMetodos_de_Pago_Paciente.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varMetodos_de_Pago_Paciente.Hora_de_Registro
                        ,Usuario_que_Registra = varMetodos_de_Pago_Paciente.Usuario_que_Registra
                        ,Paciente = varMetodos_de_Pago_Paciente.Paciente
                    
                };

                result = _IMetodos_de_Pago_PacienteApiConsumer.Update_Datos_Generales(Metodos_de_Pago_Paciente_Datos_GeneralesInfo).Resource.ToString();
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
                _IMetodos_de_Pago_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IMetodos_de_Pago_PacienteApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_MR_Tarjetas;
                var MR_TarjetasData = GetMR_TarjetasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_MR_Tarjetas);

                var result = new Metodos_de_Pago_Paciente_Datos_GeneralesModel
                {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_Registra = m.Usuario_que_Registra
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,Paciente = m.Paciente
                        ,PacienteName = CultureHelper.GetTraduction(m.Paciente_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Paciente_Spartan_User.Name

                    
                };
				var resultData = new
                {
                    data = result
                    ,MR_Tarjetas = MR_TarjetasData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }


    }
}

