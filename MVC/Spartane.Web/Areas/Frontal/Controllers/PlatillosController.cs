using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Platillos;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.MS_Calorias;

using Spartane.Core.Domain.Calorias;

using Spartane.Core.Domain.MS_Dificultad_Platillos;

using Spartane.Core.Domain.Dificultad_de_platillos;

using Spartane.Core.Domain.MS_Padecimientos;

using Spartane.Core.Domain.Categorias_de_platillos;

using Spartane.Core.Domain.MS_Tiempos_de_Comida_Platillos;

using Spartane.Core.Domain.Tiempos_de_Comida;

using Spartane.Core.Domain.Tipo_de_comida_platillos;
using Spartane.Core.Domain.MS_Caracteristicas_Platillo;

using Spartane.Core.Domain.Caracteristicas_platillo;

using Spartane.Core.Domain.MR_Detalle_Platillo;

using Spartane.Core.Domain.Ingredientes;


using Spartane.Core.Domain.Unidades_de_Medida;




using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Platillos;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Platillos;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.MS_Calorias;

using Spartane.Web.Areas.WebApiConsumer.Calorias;

using Spartane.Web.Areas.WebApiConsumer.MS_Dificultad_Platillos;

using Spartane.Web.Areas.WebApiConsumer.Dificultad_de_platillos;

using Spartane.Web.Areas.WebApiConsumer.MS_Padecimientos;

using Spartane.Web.Areas.WebApiConsumer.Categorias_de_platillos;

using Spartane.Web.Areas.WebApiConsumer.MS_Tiempos_de_Comida_Platillos;

using Spartane.Web.Areas.WebApiConsumer.Tiempos_de_Comida;

using Spartane.Web.Areas.WebApiConsumer.Tipo_de_comida_platillos;
using Spartane.Web.Areas.WebApiConsumer.MS_Caracteristicas_Platillo;

using Spartane.Web.Areas.WebApiConsumer.Caracteristicas_platillo;

using Spartane.Web.Areas.WebApiConsumer.MR_Detalle_Platillo;

using Spartane.Web.Areas.WebApiConsumer.Ingredientes;

using Spartane.Web.Areas.WebApiConsumer.Unidades_de_Medida;


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
    public class PlatillosController : Controller
    {
        #region "variable declaration"

        private IPlatillosService service = null;
        private IPlatillosApiConsumer _IPlatillosApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private IMS_CaloriasApiConsumer _IMS_CaloriasApiConsumer;

        private ICaloriasApiConsumer _ICaloriasApiConsumer;

        private IMS_Dificultad_PlatillosApiConsumer _IMS_Dificultad_PlatillosApiConsumer;

        private IDificultad_de_platillosApiConsumer _IDificultad_de_platillosApiConsumer;

        private IMS_PadecimientosApiConsumer _IMS_PadecimientosApiConsumer;

        private ICategorias_de_platillosApiConsumer _ICategorias_de_platillosApiConsumer;

        private IMS_Tiempos_de_Comida_PlatillosApiConsumer _IMS_Tiempos_de_Comida_PlatillosApiConsumer;

        private ITiempos_de_ComidaApiConsumer _ITiempos_de_ComidaApiConsumer;

        private ITipo_de_comida_platillosApiConsumer _ITipo_de_comida_platillosApiConsumer;
        private IMS_Caracteristicas_PlatilloApiConsumer _IMS_Caracteristicas_PlatilloApiConsumer;

        private ICaracteristicas_platilloApiConsumer _ICaracteristicas_platilloApiConsumer;

        private IMR_Detalle_PlatilloApiConsumer _IMR_Detalle_PlatilloApiConsumer;

        private IIngredientesApiConsumer _IIngredientesApiConsumer;

        private IUnidades_de_MedidaApiConsumer _IUnidades_de_MedidaApiConsumer;


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

        
        public PlatillosController(IPlatillosService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IPlatillosApiConsumer PlatillosApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer , IMS_CaloriasApiConsumer MS_CaloriasApiConsumer , ICaloriasApiConsumer CaloriasApiConsumer  , IMS_Dificultad_PlatillosApiConsumer MS_Dificultad_PlatillosApiConsumer , IDificultad_de_platillosApiConsumer Dificultad_de_platillosApiConsumer  , IMS_PadecimientosApiConsumer MS_PadecimientosApiConsumer , ICategorias_de_platillosApiConsumer Categorias_de_platillosApiConsumer  , IMS_Tiempos_de_Comida_PlatillosApiConsumer MS_Tiempos_de_Comida_PlatillosApiConsumer , ITiempos_de_ComidaApiConsumer Tiempos_de_ComidaApiConsumer  , ITipo_de_comida_platillosApiConsumer Tipo_de_comida_platillosApiConsumer , IMS_Caracteristicas_PlatilloApiConsumer MS_Caracteristicas_PlatilloApiConsumer , ICaracteristicas_platilloApiConsumer Caracteristicas_platilloApiConsumer  , IMR_Detalle_PlatilloApiConsumer MR_Detalle_PlatilloApiConsumer , IIngredientesApiConsumer IngredientesApiConsumer , IUnidades_de_MedidaApiConsumer Unidades_de_MedidaApiConsumer  )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IPlatillosApiConsumer = PlatillosApiConsumer;
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
            this._IMS_CaloriasApiConsumer = MS_CaloriasApiConsumer;

            this._ICaloriasApiConsumer = CaloriasApiConsumer;

            this._IMS_Dificultad_PlatillosApiConsumer = MS_Dificultad_PlatillosApiConsumer;

            this._IDificultad_de_platillosApiConsumer = Dificultad_de_platillosApiConsumer;

            this._IMS_PadecimientosApiConsumer = MS_PadecimientosApiConsumer;

            this._ICategorias_de_platillosApiConsumer = Categorias_de_platillosApiConsumer;

            this._IMS_Tiempos_de_Comida_PlatillosApiConsumer = MS_Tiempos_de_Comida_PlatillosApiConsumer;

            this._ITiempos_de_ComidaApiConsumer = Tiempos_de_ComidaApiConsumer;

            this._ITipo_de_comida_platillosApiConsumer = Tipo_de_comida_platillosApiConsumer;
            this._IMS_Caracteristicas_PlatilloApiConsumer = MS_Caracteristicas_PlatilloApiConsumer;

            this._ICaracteristicas_platilloApiConsumer = Caracteristicas_platilloApiConsumer;

            this._IMR_Detalle_PlatilloApiConsumer = MR_Detalle_PlatilloApiConsumer;

            this._IIngredientesApiConsumer = IngredientesApiConsumer;

            this._IUnidades_de_MedidaApiConsumer = Unidades_de_MedidaApiConsumer;


        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Platillos
        [ObjectAuth(ObjectId = (ModuleObjectId)43967, PermissionType = PermissionTypes.Consult)]
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
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 43967, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			          
            return View();
        }

        // GET: Frontal/Platillos/Create
          [ObjectAuth(ObjectId = (ModuleObjectId)43967, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 43967, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varPlatillos = new PlatillosModel();
			varPlatillos.Folio = Id;
			
            ViewBag.ObjectId = "43967";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;

            var permissionMS_Calorias = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44729, ModuleId);
            ViewBag.PermissionMS_Calorias = permissionMS_Calorias;
            var permissionMS_Dificultad_Platillos = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44732, ModuleId);
            ViewBag.PermissionMS_Dificultad_Platillos = permissionMS_Dificultad_Platillos;
            var permissionMS_Padecimientos = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44730, ModuleId);
            ViewBag.PermissionMS_Padecimientos = permissionMS_Padecimientos;
            var permissionMS_Tiempos_de_Comida_Platillos = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44733, ModuleId);
            ViewBag.PermissionMS_Tiempos_de_Comida_Platillos = permissionMS_Tiempos_de_Comida_Platillos;
            var permissionMS_Caracteristicas_Platillo = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44734, ModuleId);
            ViewBag.PermissionMS_Caracteristicas_Platillo = permissionMS_Caracteristicas_Platillo;
            var permissionMR_Detalle_Platillo = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44723, ModuleId);
            ViewBag.PermissionMR_Detalle_Platillo = permissionMR_Detalle_Platillo;


            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
				
				_tokenManager.GenerateToken();
				_ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _IPlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var PlatillossData = _IPlatillosApiConsumer.ListaSelAll(0, 1000, "Platillos.Folio=" + Id, "").Resource.Platilloss;
				
				if (PlatillossData != null && PlatillossData.Count > 0)
                {
					var PlatillosData = PlatillossData.First();
					varPlatillos= new PlatillosModel
					{
						Folio  = PlatillosData.Folio 
	                    ,Fecha_de_Registro = (PlatillosData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(PlatillosData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = PlatillosData.Hora_de_Registro
                    ,Usuario_que_Registra = PlatillosData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(PlatillosData.Usuario_que_Registra), "Spartan_User") ??  (string)PlatillosData.Usuario_que_Registra_Spartan_User.Name
                    ,Nombre_de_Platillo = PlatillosData.Nombre_de_Platillo
                    ,Imagen = PlatillosData.Imagen
                    ,Tipo_de_comida = PlatillosData.Tipo_de_comida
                    ,Tipo_de_comidaTipo_de_comida = CultureHelper.GetTraduction(Convert.ToString(PlatillosData.Tipo_de_comida), "Tipo_de_comida_platillos") ??  (string)PlatillosData.Tipo_de_comida_Tipo_de_comida_platillos.Tipo_de_comida
                    ,Calificacion = PlatillosData.Calificacion
                    ,Modo_de_Preparacion = PlatillosData.Modo_de_Preparacion

					};
				}
				
				                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.ImagenSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varPlatillos.Imagen).Resource;

				
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
            _ITipo_de_comida_platillosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_comida_platilloss_Tipo_de_comida = _ITipo_de_comida_platillosApiConsumer.SelAll(true);
            if (Tipo_de_comida_platilloss_Tipo_de_comida != null && Tipo_de_comida_platilloss_Tipo_de_comida.Resource != null)
                ViewBag.Tipo_de_comida_platilloss_Tipo_de_comida = Tipo_de_comida_platilloss_Tipo_de_comida.Resource.Where(m => m.Tipo_de_comida != null).OrderBy(m => m.Tipo_de_comida).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Tipo_de_comida_platillos", "Tipo_de_comida") ?? m.Tipo_de_comida.ToString(), Value = Convert.ToString(m.Folio)
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

				
            return View(varPlatillos);
        }
		
	[HttpGet]
        public ActionResult AddPlatillos(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 43967);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IPlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);
			PlatillosModel varPlatillos= new PlatillosModel();
            var permissionMS_Calorias = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44729, ModuleId);
            ViewBag.PermissionMS_Calorias = permissionMS_Calorias;
            var permissionMS_Dificultad_Platillos = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44732, ModuleId);
            ViewBag.PermissionMS_Dificultad_Platillos = permissionMS_Dificultad_Platillos;
            var permissionMS_Padecimientos = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44730, ModuleId);
            ViewBag.PermissionMS_Padecimientos = permissionMS_Padecimientos;
            var permissionMS_Tiempos_de_Comida_Platillos = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44733, ModuleId);
            ViewBag.PermissionMS_Tiempos_de_Comida_Platillos = permissionMS_Tiempos_de_Comida_Platillos;
            var permissionMS_Caracteristicas_Platillo = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44734, ModuleId);
            ViewBag.PermissionMS_Caracteristicas_Platillo = permissionMS_Caracteristicas_Platillo;
            var permissionMR_Detalle_Platillo = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44723, ModuleId);
            ViewBag.PermissionMR_Detalle_Platillo = permissionMR_Detalle_Platillo;


            if (id.ToString() != "0")
            {
                var PlatillossData = _IPlatillosApiConsumer.ListaSelAll(0, 1000, "Platillos.Folio=" + id, "").Resource.Platilloss;
				
				if (PlatillossData != null && PlatillossData.Count > 0)
                {
					var PlatillosData = PlatillossData.First();
					varPlatillos= new PlatillosModel
					{
						Folio  = PlatillosData.Folio 
	                    ,Fecha_de_Registro = (PlatillosData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(PlatillosData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = PlatillosData.Hora_de_Registro
                    ,Usuario_que_Registra = PlatillosData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(PlatillosData.Usuario_que_Registra), "Spartan_User") ??  (string)PlatillosData.Usuario_que_Registra_Spartan_User.Name
                    ,Nombre_de_Platillo = PlatillosData.Nombre_de_Platillo
                    ,Imagen = PlatillosData.Imagen
                    ,Tipo_de_comida = PlatillosData.Tipo_de_comida
                    ,Tipo_de_comidaTipo_de_comida = CultureHelper.GetTraduction(Convert.ToString(PlatillosData.Tipo_de_comida), "Tipo_de_comida_platillos") ??  (string)PlatillosData.Tipo_de_comida_Tipo_de_comida_platillos.Tipo_de_comida
                    ,Calificacion = PlatillosData.Calificacion
                    ,Modo_de_Preparacion = PlatillosData.Modo_de_Preparacion

					};
				}
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.ImagenSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varPlatillos.Imagen).Resource;

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
            _ITipo_de_comida_platillosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_comida_platilloss_Tipo_de_comida = _ITipo_de_comida_platillosApiConsumer.SelAll(true);
            if (Tipo_de_comida_platilloss_Tipo_de_comida != null && Tipo_de_comida_platilloss_Tipo_de_comida.Resource != null)
                ViewBag.Tipo_de_comida_platilloss_Tipo_de_comida = Tipo_de_comida_platilloss_Tipo_de_comida.Resource.Where(m => m.Tipo_de_comida != null).OrderBy(m => m.Tipo_de_comida).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Tipo_de_comida_platillos", "Tipo_de_comida") ?? m.Tipo_de_comida.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            return PartialView("AddPlatillos", varPlatillos);
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
        public ActionResult GetTipo_de_comida_platillosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipo_de_comida_platillosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipo_de_comida_platillosApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Tipo_de_comida).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Tipo_de_comida_platillos", "Tipo_de_comida")?? m.Tipo_de_comida,
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
        public ActionResult ShowAdvanceFilter(PlatillosAdvanceSearchModel model, int idFilter = -1)
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
            _ITipo_de_comida_platillosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_comida_platilloss_Tipo_de_comida = _ITipo_de_comida_platillosApiConsumer.SelAll(true);
            if (Tipo_de_comida_platilloss_Tipo_de_comida != null && Tipo_de_comida_platilloss_Tipo_de_comida.Resource != null)
                ViewBag.Tipo_de_comida_platilloss_Tipo_de_comida = Tipo_de_comida_platilloss_Tipo_de_comida.Resource.Where(m => m.Tipo_de_comida != null).OrderBy(m => m.Tipo_de_comida).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Tipo_de_comida_platillos", "Tipo_de_comida") ?? m.Tipo_de_comida.ToString(), Value = Convert.ToString(m.Folio)
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
            _ITipo_de_comida_platillosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_comida_platilloss_Tipo_de_comida = _ITipo_de_comida_platillosApiConsumer.SelAll(true);
            if (Tipo_de_comida_platilloss_Tipo_de_comida != null && Tipo_de_comida_platilloss_Tipo_de_comida.Resource != null)
                ViewBag.Tipo_de_comida_platilloss_Tipo_de_comida = Tipo_de_comida_platilloss_Tipo_de_comida.Resource.Where(m => m.Tipo_de_comida != null).OrderBy(m => m.Tipo_de_comida).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Tipo_de_comida_platillos", "Tipo_de_comida") ?? m.Tipo_de_comida.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            var previousFiltersObj = new PlatillosAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (PlatillosAdvanceSearchModel)(Session["AdvanceSearch"] ?? new PlatillosAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new PlatillosPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IPlatillosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Platilloss == null)
                result.Platilloss = new List<Platillos>();

            return Json(new
            {
                data = result.Platilloss.Select(m => new PlatillosGridModel
                    {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre_de_Platillo = m.Nombre_de_Platillo
			,Imagen = m.Imagen
                        ,Tipo_de_comidaTipo_de_comida = CultureHelper.GetTraduction(m.Tipo_de_comida_Tipo_de_comida_platillos.Folio.ToString(), "Tipo_de_comida") ?? (string)m.Tipo_de_comida_Tipo_de_comida_platillos.Tipo_de_comida
			,Calificacion = m.Calificacion
			,Modo_de_Preparacion = m.Modo_de_Preparacion

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }
		/*
		 [HttpGet]
        public ActionResult GetPlatillosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPlatillosApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraductionNew(Convert.ToString(m.Folio), "Platillos", m.),
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
        /// Get List of Platillos from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Platillos Entity</returns>
        public ActionResult GetPlatillosList(UrlParametersModel param)
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
            _IPlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);

          
            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new PlatillosPropertyMapper());
				
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
				if (Session["AdvanceSearch"].GetType() == typeof(PlatillosAdvanceSearchModel))
                {
					var advanceFilter =
                    (PlatillosAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            PlatillosPropertyMapper oPlatillosPropertyMapper = new PlatillosPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                 if (sortColumn != -1)
                    configuration.OrderByClause = oPlatillosPropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _IPlatillosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Platilloss == null)
                result.Platilloss = new List<Platillos>();

            return Json(new
            {
                aaData = result.Platilloss.Select(m => new PlatillosGridModel
            {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre_de_Platillo = m.Nombre_de_Platillo
			,Imagen = m.Imagen
                        ,Tipo_de_comidaTipo_de_comida = CultureHelper.GetTraduction(m.Tipo_de_comida_Tipo_de_comida_platillos.Folio.ToString(), "Tipo_de_comida") ?? (string)m.Tipo_de_comida_Tipo_de_comida_platillos.Tipo_de_comida
			,Calificacion = m.Calificacion
			,Modo_de_Preparacion = m.Modo_de_Preparacion

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }


//Grid GetAutoComplete

//Grid GetAutoComplete

//Grid GetAutoComplete

//Grid GetAutoComplete

//Grid GetAutoComplete

//Grid GetAutoComplete






        [NonAction]
        public string GetAdvanceFilter(PlatillosAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromFolio) || !string.IsNullOrEmpty(filter.ToFolio))
            {
                if (!string.IsNullOrEmpty(filter.FromFolio))
                    where += " AND Platillos.Folio >= " + filter.FromFolio;
                if (!string.IsNullOrEmpty(filter.ToFolio))
                    where += " AND Platillos.Folio <= " + filter.ToFolio;
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro) || !string.IsNullOrEmpty(filter.ToFecha_de_Registro))
            {
                var Fecha_de_RegistroFrom = DateTime.ParseExact(filter.FromFecha_de_Registro, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_de_RegistroTo = DateTime.ParseExact(filter.ToFecha_de_Registro, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro))
                    where += " AND Platillos.Fecha_de_Registro >= '" + Fecha_de_RegistroFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_Registro))
                    where += " AND Platillos.Fecha_de_Registro <= '" + Fecha_de_RegistroTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromHora_de_Registro) || !string.IsNullOrEmpty(filter.ToHora_de_Registro))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_de_Registro))
                    where += " AND Convert(TIME,Platillos.Hora_de_Registro) >='" + filter.FromHora_de_Registro + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_de_Registro))
                    where += " AND Convert(TIME,Platillos.Hora_de_Registro) <='" + filter.ToHora_de_Registro + "'";
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

                where += " AND Platillos.Usuario_que_Registra In (" + Usuario_que_RegistraIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Nombre_de_Platillo))
            {
                switch (filter.Nombre_de_PlatilloFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Platillos.Nombre_de_Platillo LIKE '" + filter.Nombre_de_Platillo + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Platillos.Nombre_de_Platillo LIKE '%" + filter.Nombre_de_Platillo + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Platillos.Nombre_de_Platillo = '" + filter.Nombre_de_Platillo + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Platillos.Nombre_de_Platillo LIKE '%" + filter.Nombre_de_Platillo + "%'";
                        break;
                }
            }

            if (filter.Imagen != RadioOptions.NoApply)
                where += " AND Platillos.Imagen " + (filter.Imagen == RadioOptions.Yes ? ">" : "==") + " 0";

            if (!string.IsNullOrEmpty(filter.AdvanceTipo_de_comida))
            {
                switch (filter.Tipo_de_comidaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Tipo_de_comida_platillos.Tipo_de_comida LIKE '" + filter.AdvanceTipo_de_comida + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Tipo_de_comida_platillos.Tipo_de_comida LIKE '%" + filter.AdvanceTipo_de_comida + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Tipo_de_comida_platillos.Tipo_de_comida = '" + filter.AdvanceTipo_de_comida + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Tipo_de_comida_platillos.Tipo_de_comida LIKE '%" + filter.AdvanceTipo_de_comida + "%'";
                        break;
                }
            }
            else if (filter.AdvanceTipo_de_comidaMultiple != null && filter.AdvanceTipo_de_comidaMultiple.Count() > 0)
            {
                var Tipo_de_comidaIds = string.Join(",", filter.AdvanceTipo_de_comidaMultiple);

                where += " AND Platillos.Tipo_de_comida In (" + Tipo_de_comidaIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Calificacion))
            {
                switch (filter.CalificacionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Platillos.Calificacion LIKE '" + filter.Calificacion + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Platillos.Calificacion LIKE '%" + filter.Calificacion + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Platillos.Calificacion = '" + filter.Calificacion + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Platillos.Calificacion LIKE '%" + filter.Calificacion + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Modo_de_Preparacion))
            {
                switch (filter.Modo_de_PreparacionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Platillos.Modo_de_Preparacion LIKE '" + filter.Modo_de_Preparacion + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Platillos.Modo_de_Preparacion LIKE '%" + filter.Modo_de_Preparacion + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Platillos.Modo_de_Preparacion = '" + filter.Modo_de_Preparacion + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Platillos.Modo_de_Preparacion LIKE '%" + filter.Modo_de_Preparacion + "%'";
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
        public ActionResult GetCalorias_MS_CaloriasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                
                _ICaloriasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ICaloriasApiConsumer.SelAll(false).Resource;

                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetMS_Calorias(int draw, int start, int length, int RelationId = 0)
        {
            if (RelationId == 0)
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<MS_CaloriasGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IMS_CaloriasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
			
var result = _IMS_CaloriasApiConsumer.ListaSelAll(start, pageSize, "MS_Calorias.Folio_Platillo=" + RelationId,"").Resource;

            if (result.MS_Caloriass == null)
                result.MS_Caloriass = new List<MS_Calorias>();

            var jsonResult = Json(new
            {
                data = result.MS_Caloriass.Select(m => new MS_CaloriasGridModel
                {
                    Folio = m.Folio
					
                ,Calorias = m.Calorias
		,CaloriasCantidad = m.Calorias_Calorias.Cantidad


                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
[HttpGet]
        public ActionResult GetDificultad_MS_Dificultad_PlatillosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                
                _IDificultad_de_platillosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IDificultad_de_platillosApiConsumer.SelAll(false).Resource;

                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetMS_Dificultad_Platillos(int draw, int start, int length, int RelationId = 0)
        {
            if (RelationId == 0)
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<MS_Dificultad_PlatillosGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IMS_Dificultad_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
			
var result = _IMS_Dificultad_PlatillosApiConsumer.ListaSelAll(start, pageSize, "MS_Dificultad_Platillos.Folio_Platillos=" + RelationId,"").Resource;

            if (result.MS_Dificultad_Platilloss == null)
                result.MS_Dificultad_Platilloss = new List<MS_Dificultad_Platillos>();

            var jsonResult = Json(new
            {
                data = result.MS_Dificultad_Platilloss.Select(m => new MS_Dificultad_PlatillosGridModel
                {
                    Folio = m.Folio
					
                ,Dificultad = m.Dificultad
		,DificultadCategoria = m.Dificultad_Dificultad_de_platillos.Categoria


                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
[HttpGet]
        public ActionResult GetCategoria_del_Platillo_MS_PadecimientosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                
                _ICategorias_de_platillosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ICategorias_de_platillosApiConsumer.SelAll(false).Resource;

                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetMS_Padecimientos(int draw, int start, int length, int RelationId = 0)
        {
            if (RelationId == 0)
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<MS_PadecimientosGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IMS_PadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
			
var result = _IMS_PadecimientosApiConsumer.ListaSelAll(start, pageSize, "MS_Padecimientos.Folio_Platillos=" + RelationId,"").Resource;

            if (result.MS_Padecimientoss == null)
                result.MS_Padecimientoss = new List<MS_Padecimientos>();

            var jsonResult = Json(new
            {
                data = result.MS_Padecimientoss.Select(m => new MS_PadecimientosGridModel
                {
                    Folio = m.Folio
					
                ,Categoria = m.Categoria
		,CategoriaCategoria = m.Categoria_Categorias_de_platillos.Categoria


                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
[HttpGet]
        public ActionResult GetTiempo_de_comida_MS_Tiempos_de_Comida_PlatillosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                
                _ITiempos_de_ComidaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITiempos_de_ComidaApiConsumer.SelAll(false).Resource;

                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetMS_Tiempos_de_Comida_Platillos(int draw, int start, int length, int RelationId = 0)
        {
            if (RelationId == 0)
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<MS_Tiempos_de_Comida_PlatillosGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IMS_Tiempos_de_Comida_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
			
var result = _IMS_Tiempos_de_Comida_PlatillosApiConsumer.ListaSelAll(start, pageSize, "MS_Tiempos_de_Comida_Platillos.Folio_Platillos=" + RelationId,"").Resource;

            if (result.MS_Tiempos_de_Comida_Platilloss == null)
                result.MS_Tiempos_de_Comida_Platilloss = new List<MS_Tiempos_de_Comida_Platillos>();

            var jsonResult = Json(new
            {
                data = result.MS_Tiempos_de_Comida_Platilloss.Select(m => new MS_Tiempos_de_Comida_PlatillosGridModel
                {
                    Folio = m.Folio
					
                ,Tiempo_de_Comida = m.Tiempo_de_Comida
		,Tiempo_de_ComidaComida = m.Tiempo_de_Comida_Tiempos_de_Comida.Comida


                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
[HttpGet]
        public ActionResult GetCaracteristicas_MS_Caracteristicas_PlatilloAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                
                _ICaracteristicas_platilloApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ICaracteristicas_platilloApiConsumer.SelAll(false).Resource;

                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetMS_Caracteristicas_Platillo(int draw, int start, int length, int RelationId = 0)
        {
            if (RelationId == 0)
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<MS_Caracteristicas_PlatilloGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IMS_Caracteristicas_PlatilloApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
			
var result = _IMS_Caracteristicas_PlatilloApiConsumer.ListaSelAll(start, pageSize, "MS_Caracteristicas_Platillo.Folio_Platillos=" + RelationId,"").Resource;

            if (result.MS_Caracteristicas_Platillos == null)
                result.MS_Caracteristicas_Platillos = new List<MS_Caracteristicas_Platillo>();

            var jsonResult = Json(new
            {
                data = result.MS_Caracteristicas_Platillos.Select(m => new MS_Caracteristicas_PlatilloGridModel
                {
                    Folio = m.Folio
					
                ,Caracteristicas = m.Caracteristicas
		,CaracteristicasCaracteristicas = m.Caracteristicas_Caracteristicas_platillo.Caracteristicas


                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public ActionResult GetMR_Detalle_Platillo(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<MR_Detalle_PlatilloGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IMR_Detalle_PlatilloApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "MR_Detalle_Platillo.Folio_Platillos=" + RelationId;
            if("int" == "string")
            {
	           where = "MR_Detalle_Platillo.Folio_Platillos='" + RelationId + "'";
            }
            var result = _IMR_Detalle_PlatilloApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.MR_Detalle_Platillos == null)
                result.MR_Detalle_Platillos = new List<MR_Detalle_Platillo>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.MR_Detalle_Platillos.Select(m => new MR_Detalle_PlatilloGridModel
                {
                    Folio = m.Folio

                        ,Ingrediente = m.Ingrediente
                        ,IngredienteNombre_Ingrediente = CultureHelper.GetTraduction(m.Ingrediente_Ingredientes.Clave.ToString(), "Nombre_Ingrediente") ??(string)m.Ingrediente_Ingredientes.Nombre_Ingrediente
			,Cantidad = m.Cantidad
			,Cantidad_en_Fraccion = m.Cantidad_en_Fraccion
                        ,Unidad = m.Unidad
                        ,UnidadUnidad = CultureHelper.GetTraduction(m.Unidad_Unidades_de_Medida.Clave.ToString(), "Unidad") ??(string)m.Unidad_Unidades_de_Medida.Unidad
			,Cantidad_a_mostrar = m.Cantidad_a_mostrar
			,Ingrediente_a_mostrar = m.Ingrediente_a_mostrar

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<MR_Detalle_PlatilloGridModel> GetMR_Detalle_PlatilloData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<MR_Detalle_PlatilloGridModel> resultData = new List<MR_Detalle_PlatilloGridModel>();
            string where = "MR_Detalle_Platillo.Folio_Platillos=" + Id;
            if("int" == "string")
            {
                where = "MR_Detalle_Platillo.Folio_Platillos='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IMR_Detalle_PlatilloApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IMR_Detalle_PlatilloApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.MR_Detalle_Platillos != null)
            {
                resultData = result.MR_Detalle_Platillos.Select(m => new MR_Detalle_PlatilloGridModel
                    {
                        Folio = m.Folio

                        ,Ingrediente = m.Ingrediente
                        ,IngredienteNombre_Ingrediente = CultureHelper.GetTraduction(m.Ingrediente_Ingredientes.Clave.ToString(), "Nombre_Ingrediente") ??(string)m.Ingrediente_Ingredientes.Nombre_Ingrediente
			,Cantidad = m.Cantidad
			,Cantidad_en_Fraccion = m.Cantidad_en_Fraccion
                        ,Unidad = m.Unidad
                        ,UnidadUnidad = CultureHelper.GetTraduction(m.Unidad_Unidades_de_Medida.Clave.ToString(), "Unidad") ??(string)m.Unidad_Unidades_de_Medida.Unidad
			,Cantidad_a_mostrar = m.Cantidad_a_mostrar
			,Ingrediente_a_mostrar = m.Ingrediente_a_mostrar


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
                _IPlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);

                Platillos varPlatillos = null;
                if (id.ToString() != "0")
                {
                        string where = "";
                    _IMS_CaloriasApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "MS_Calorias.Folio_Platillo=" + id;
                    if("int" == "string")
                    {
	                where = "MS_Calorias.Folio_Platillo='" + id + "'";
                    }
                    var MS_CaloriasInfo =
                        _IMS_CaloriasApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (MS_CaloriasInfo.MS_Caloriass.Count > 0)
                    {
                        var resultMS_Calorias = true;
                        //Removing associated job history with attachment
                        foreach (var MS_CaloriasItem in MS_CaloriasInfo.MS_Caloriass)
                            resultMS_Calorias = resultMS_Calorias
                                              && _IMS_CaloriasApiConsumer.Delete(MS_CaloriasItem.Folio, null,null).Resource;

                        if (!resultMS_Calorias)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _IMS_Dificultad_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "MS_Dificultad_Platillos.Folio_Platillos=" + id;
                    if("int" == "string")
                    {
	                where = "MS_Dificultad_Platillos.Folio_Platillos='" + id + "'";
                    }
                    var MS_Dificultad_PlatillosInfo =
                        _IMS_Dificultad_PlatillosApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (MS_Dificultad_PlatillosInfo.MS_Dificultad_Platilloss.Count > 0)
                    {
                        var resultMS_Dificultad_Platillos = true;
                        //Removing associated job history with attachment
                        foreach (var MS_Dificultad_PlatillosItem in MS_Dificultad_PlatillosInfo.MS_Dificultad_Platilloss)
                            resultMS_Dificultad_Platillos = resultMS_Dificultad_Platillos
                                              && _IMS_Dificultad_PlatillosApiConsumer.Delete(MS_Dificultad_PlatillosItem.Folio, null,null).Resource;

                        if (!resultMS_Dificultad_Platillos)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _IMS_PadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "MS_Padecimientos.Folio_Platillos=" + id;
                    if("int" == "string")
                    {
	                where = "MS_Padecimientos.Folio_Platillos='" + id + "'";
                    }
                    var MS_PadecimientosInfo =
                        _IMS_PadecimientosApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (MS_PadecimientosInfo.MS_Padecimientoss.Count > 0)
                    {
                        var resultMS_Padecimientos = true;
                        //Removing associated job history with attachment
                        foreach (var MS_PadecimientosItem in MS_PadecimientosInfo.MS_Padecimientoss)
                            resultMS_Padecimientos = resultMS_Padecimientos
                                              && _IMS_PadecimientosApiConsumer.Delete(MS_PadecimientosItem.Folio, null,null).Resource;

                        if (!resultMS_Padecimientos)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _IMS_Tiempos_de_Comida_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "MS_Tiempos_de_Comida_Platillos.Folio_Platillos=" + id;
                    if("int" == "string")
                    {
	                where = "MS_Tiempos_de_Comida_Platillos.Folio_Platillos='" + id + "'";
                    }
                    var MS_Tiempos_de_Comida_PlatillosInfo =
                        _IMS_Tiempos_de_Comida_PlatillosApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (MS_Tiempos_de_Comida_PlatillosInfo.MS_Tiempos_de_Comida_Platilloss.Count > 0)
                    {
                        var resultMS_Tiempos_de_Comida_Platillos = true;
                        //Removing associated job history with attachment
                        foreach (var MS_Tiempos_de_Comida_PlatillosItem in MS_Tiempos_de_Comida_PlatillosInfo.MS_Tiempos_de_Comida_Platilloss)
                            resultMS_Tiempos_de_Comida_Platillos = resultMS_Tiempos_de_Comida_Platillos
                                              && _IMS_Tiempos_de_Comida_PlatillosApiConsumer.Delete(MS_Tiempos_de_Comida_PlatillosItem.Folio, null,null).Resource;

                        if (!resultMS_Tiempos_de_Comida_Platillos)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _IMS_Caracteristicas_PlatilloApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "MS_Caracteristicas_Platillo.Folio_Platillos=" + id;
                    if("int" == "string")
                    {
	                where = "MS_Caracteristicas_Platillo.Folio_Platillos='" + id + "'";
                    }
                    var MS_Caracteristicas_PlatilloInfo =
                        _IMS_Caracteristicas_PlatilloApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (MS_Caracteristicas_PlatilloInfo.MS_Caracteristicas_Platillos.Count > 0)
                    {
                        var resultMS_Caracteristicas_Platillo = true;
                        //Removing associated job history with attachment
                        foreach (var MS_Caracteristicas_PlatilloItem in MS_Caracteristicas_PlatilloInfo.MS_Caracteristicas_Platillos)
                            resultMS_Caracteristicas_Platillo = resultMS_Caracteristicas_Platillo
                                              && _IMS_Caracteristicas_PlatilloApiConsumer.Delete(MS_Caracteristicas_PlatilloItem.Folio, null,null).Resource;

                        if (!resultMS_Caracteristicas_Platillo)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _IMR_Detalle_PlatilloApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "MR_Detalle_Platillo.Folio_Platillos=" + id;
                    if("int" == "string")
                    {
	                where = "MR_Detalle_Platillo.Folio_Platillos='" + id + "'";
                    }
                    var MR_Detalle_PlatilloInfo =
                        _IMR_Detalle_PlatilloApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (MR_Detalle_PlatilloInfo.MR_Detalle_Platillos.Count > 0)
                    {
                        var resultMR_Detalle_Platillo = true;
                        //Removing associated job history with attachment
                        foreach (var MR_Detalle_PlatilloItem in MR_Detalle_PlatilloInfo.MR_Detalle_Platillos)
                            resultMR_Detalle_Platillo = resultMR_Detalle_Platillo
                                              && _IMR_Detalle_PlatilloApiConsumer.Delete(MR_Detalle_PlatilloItem.Folio, null,null).Resource;

                        if (!resultMR_Detalle_Platillo)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                var result = _IPlatillosApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, PlatillosModel varPlatillos)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IPlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);


                    if (varPlatillos.ImagenRemoveAttachment != 0 && varPlatillos.ImagenFile == null)
                    {
                        varPlatillos.Imagen = 0;
                    }

                    if (varPlatillos.ImagenFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varPlatillos.ImagenFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varPlatillos.Imagen = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varPlatillos.ImagenFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }

                    
                    var result = "";
                    var PlatillosInfo = new Platillos
                    {
                        Folio = varPlatillos.Folio
                        ,Fecha_de_Registro = (!String.IsNullOrEmpty(varPlatillos.Fecha_de_Registro)) ? DateTime.ParseExact(varPlatillos.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varPlatillos.Hora_de_Registro
                        ,Usuario_que_Registra = varPlatillos.Usuario_que_Registra
                        ,Nombre_de_Platillo = varPlatillos.Nombre_de_Platillo
                        ,Imagen = (varPlatillos.Imagen.HasValue && varPlatillos.Imagen != 0) ? ((int?)Convert.ToInt32(varPlatillos.Imagen.Value)) : null

                        ,Tipo_de_comida = varPlatillos.Tipo_de_comida
                        ,Calificacion = varPlatillos.Calificacion
                        ,Modo_de_Preparacion = varPlatillos.Modo_de_Preparacion

                    };

                    result = !IsNew ?
                        _IPlatillosApiConsumer.Update(PlatillosInfo, null, null).Resource.ToString() :
                         _IPlatillosApiConsumer.Insert(PlatillosInfo, null, null).Resource.ToString();
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
        public bool CopyMS_Calorias(int MasterId, int referenceId, List<MS_CaloriasGridModelPost> MS_CaloriasItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IMS_CaloriasApiConsumer.SetAuthHeader(_tokenManager.Token);

                var MS_CaloriasData = _IMS_CaloriasApiConsumer.ListaSelAll(1, int.MaxValue, "MS_Calorias.Folio_Platillo=" + referenceId,"").Resource;
                if (MS_CaloriasData == null || MS_CaloriasData.MS_Caloriass.Count == 0)
                    return true;

                var result = true;

                MS_CaloriasGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varMS_Calorias in MS_CaloriasData.MS_Caloriass)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    MS_Calorias MS_Calorias1 = varMS_Calorias;

                    if (MS_CaloriasItems != null && MS_CaloriasItems.Any(m => m.Folio == MS_Calorias1.Folio))
                    {
                        modelDataToChange = MS_CaloriasItems.FirstOrDefault(m => m.Folio == MS_Calorias1.Folio);
                    }
                    //Chaning Id Value
                    varMS_Calorias.Folio_Platillo = MasterId;
                    var insertId = _IMS_CaloriasApiConsumer.Insert(varMS_Calorias,null,null).Resource;
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
        public ActionResult PostMS_Calorias(List<MS_CaloriasGridModelPost> MS_CaloriasItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyMS_Calorias(MasterId, referenceId, MS_CaloriasItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (MS_CaloriasItems != null && MS_CaloriasItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IMS_CaloriasApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var MS_CaloriasItem in MS_CaloriasItems)
                    {



                        //Removal Request
                        if (MS_CaloriasItem.Removed)
                        {
                            result = result && _IMS_CaloriasApiConsumer.Delete(MS_CaloriasItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							MS_CaloriasItem.Folio = 0;

                        var MS_CaloriasData = new MS_Calorias
                        {
                            Folio_Platillo = MasterId
                            ,Folio = MS_CaloriasItem.Folio
                            ,Calorias = (Convert.ToInt32(MS_CaloriasItem.Calorias) == 0 ? (Int32?)null : Convert.ToInt32(MS_CaloriasItem.Calorias))

                        };

                        var resultId = MS_CaloriasItem.Folio > 0
                           ? _IMS_CaloriasApiConsumer.Update(MS_CaloriasData,null,null).Resource
                           : _IMS_CaloriasApiConsumer.Insert(MS_CaloriasData,null,null).Resource;

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
        public ActionResult GetMS_Calorias_CaloriasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ICaloriasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ICaloriasApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Calorias", "Cantidad");
                  item.Cantidad= trans??item.Cantidad;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [NonAction]
        public bool CopyMS_Dificultad_Platillos(int MasterId, int referenceId, List<MS_Dificultad_PlatillosGridModelPost> MS_Dificultad_PlatillosItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IMS_Dificultad_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);

                var MS_Dificultad_PlatillosData = _IMS_Dificultad_PlatillosApiConsumer.ListaSelAll(1, int.MaxValue, "MS_Dificultad_Platillos.Folio_Platillos=" + referenceId,"").Resource;
                if (MS_Dificultad_PlatillosData == null || MS_Dificultad_PlatillosData.MS_Dificultad_Platilloss.Count == 0)
                    return true;

                var result = true;

                MS_Dificultad_PlatillosGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varMS_Dificultad_Platillos in MS_Dificultad_PlatillosData.MS_Dificultad_Platilloss)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    MS_Dificultad_Platillos MS_Dificultad_Platillos1 = varMS_Dificultad_Platillos;

                    if (MS_Dificultad_PlatillosItems != null && MS_Dificultad_PlatillosItems.Any(m => m.Folio == MS_Dificultad_Platillos1.Folio))
                    {
                        modelDataToChange = MS_Dificultad_PlatillosItems.FirstOrDefault(m => m.Folio == MS_Dificultad_Platillos1.Folio);
                    }
                    //Chaning Id Value
                    varMS_Dificultad_Platillos.Folio_Platillos = MasterId;
                    var insertId = _IMS_Dificultad_PlatillosApiConsumer.Insert(varMS_Dificultad_Platillos,null,null).Resource;
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
        public ActionResult PostMS_Dificultad_Platillos(List<MS_Dificultad_PlatillosGridModelPost> MS_Dificultad_PlatillosItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyMS_Dificultad_Platillos(MasterId, referenceId, MS_Dificultad_PlatillosItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (MS_Dificultad_PlatillosItems != null && MS_Dificultad_PlatillosItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IMS_Dificultad_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var MS_Dificultad_PlatillosItem in MS_Dificultad_PlatillosItems)
                    {



                        //Removal Request
                        if (MS_Dificultad_PlatillosItem.Removed)
                        {
                            result = result && _IMS_Dificultad_PlatillosApiConsumer.Delete(MS_Dificultad_PlatillosItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							MS_Dificultad_PlatillosItem.Folio = 0;

                        var MS_Dificultad_PlatillosData = new MS_Dificultad_Platillos
                        {
                            Folio_Platillos = MasterId
                            ,Folio = MS_Dificultad_PlatillosItem.Folio
                            ,Dificultad = (Convert.ToInt32(MS_Dificultad_PlatillosItem.Dificultad) == 0 ? (Int32?)null : Convert.ToInt32(MS_Dificultad_PlatillosItem.Dificultad))

                        };

                        var resultId = MS_Dificultad_PlatillosItem.Folio > 0
                           ? _IMS_Dificultad_PlatillosApiConsumer.Update(MS_Dificultad_PlatillosData,null,null).Resource
                           : _IMS_Dificultad_PlatillosApiConsumer.Insert(MS_Dificultad_PlatillosData,null,null).Resource;

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
        public ActionResult GetMS_Dificultad_Platillos_Dificultad_de_platillosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDificultad_de_platillosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IDificultad_de_platillosApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Dificultad_de_platillos", "Categoria");
                  item.Categoria= trans??item.Categoria;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [NonAction]
        public bool CopyMS_Padecimientos(int MasterId, int referenceId, List<MS_PadecimientosGridModelPost> MS_PadecimientosItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IMS_PadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);

                var MS_PadecimientosData = _IMS_PadecimientosApiConsumer.ListaSelAll(1, int.MaxValue, "MS_Padecimientos.Folio_Platillos=" + referenceId,"").Resource;
                if (MS_PadecimientosData == null || MS_PadecimientosData.MS_Padecimientoss.Count == 0)
                    return true;

                var result = true;

                MS_PadecimientosGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varMS_Padecimientos in MS_PadecimientosData.MS_Padecimientoss)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    MS_Padecimientos MS_Padecimientos1 = varMS_Padecimientos;

                    if (MS_PadecimientosItems != null && MS_PadecimientosItems.Any(m => m.Folio == MS_Padecimientos1.Folio))
                    {
                        modelDataToChange = MS_PadecimientosItems.FirstOrDefault(m => m.Folio == MS_Padecimientos1.Folio);
                    }
                    //Chaning Id Value
                    varMS_Padecimientos.Folio_Platillos = MasterId;
                    var insertId = _IMS_PadecimientosApiConsumer.Insert(varMS_Padecimientos,null,null).Resource;
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
        public ActionResult PostMS_Padecimientos(List<MS_PadecimientosGridModelPost> MS_PadecimientosItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyMS_Padecimientos(MasterId, referenceId, MS_PadecimientosItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (MS_PadecimientosItems != null && MS_PadecimientosItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IMS_PadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var MS_PadecimientosItem in MS_PadecimientosItems)
                    {



                        //Removal Request
                        if (MS_PadecimientosItem.Removed)
                        {
                            result = result && _IMS_PadecimientosApiConsumer.Delete(MS_PadecimientosItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							MS_PadecimientosItem.Folio = 0;

                        var MS_PadecimientosData = new MS_Padecimientos
                        {
                            Folio_Platillos = MasterId
                            ,Folio = MS_PadecimientosItem.Folio
                            ,Categoria = (Convert.ToInt32(MS_PadecimientosItem.Categoria) == 0 ? (Int32?)null : Convert.ToInt32(MS_PadecimientosItem.Categoria))

                        };

                        var resultId = MS_PadecimientosItem.Folio > 0
                           ? _IMS_PadecimientosApiConsumer.Update(MS_PadecimientosData,null,null).Resource
                           : _IMS_PadecimientosApiConsumer.Insert(MS_PadecimientosData,null,null).Resource;

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
        public ActionResult GetMS_Padecimientos_Categorias_de_platillosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ICategorias_de_platillosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ICategorias_de_platillosApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Categorias_de_platillos", "Categoria");
                  item.Categoria= trans??item.Categoria;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [NonAction]
        public bool CopyMS_Tiempos_de_Comida_Platillos(int MasterId, int referenceId, List<MS_Tiempos_de_Comida_PlatillosGridModelPost> MS_Tiempos_de_Comida_PlatillosItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IMS_Tiempos_de_Comida_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);

                var MS_Tiempos_de_Comida_PlatillosData = _IMS_Tiempos_de_Comida_PlatillosApiConsumer.ListaSelAll(1, int.MaxValue, "MS_Tiempos_de_Comida_Platillos.Folio_Platillos=" + referenceId,"").Resource;
                if (MS_Tiempos_de_Comida_PlatillosData == null || MS_Tiempos_de_Comida_PlatillosData.MS_Tiempos_de_Comida_Platilloss.Count == 0)
                    return true;

                var result = true;

                MS_Tiempos_de_Comida_PlatillosGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varMS_Tiempos_de_Comida_Platillos in MS_Tiempos_de_Comida_PlatillosData.MS_Tiempos_de_Comida_Platilloss)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    MS_Tiempos_de_Comida_Platillos MS_Tiempos_de_Comida_Platillos1 = varMS_Tiempos_de_Comida_Platillos;

                    if (MS_Tiempos_de_Comida_PlatillosItems != null && MS_Tiempos_de_Comida_PlatillosItems.Any(m => m.Folio == MS_Tiempos_de_Comida_Platillos1.Folio))
                    {
                        modelDataToChange = MS_Tiempos_de_Comida_PlatillosItems.FirstOrDefault(m => m.Folio == MS_Tiempos_de_Comida_Platillos1.Folio);
                    }
                    //Chaning Id Value
                    varMS_Tiempos_de_Comida_Platillos.Folio_Platillos = MasterId;
                    var insertId = _IMS_Tiempos_de_Comida_PlatillosApiConsumer.Insert(varMS_Tiempos_de_Comida_Platillos,null,null).Resource;
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
        public ActionResult PostMS_Tiempos_de_Comida_Platillos(List<MS_Tiempos_de_Comida_PlatillosGridModelPost> MS_Tiempos_de_Comida_PlatillosItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyMS_Tiempos_de_Comida_Platillos(MasterId, referenceId, MS_Tiempos_de_Comida_PlatillosItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (MS_Tiempos_de_Comida_PlatillosItems != null && MS_Tiempos_de_Comida_PlatillosItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IMS_Tiempos_de_Comida_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var MS_Tiempos_de_Comida_PlatillosItem in MS_Tiempos_de_Comida_PlatillosItems)
                    {



                        //Removal Request
                        if (MS_Tiempos_de_Comida_PlatillosItem.Removed)
                        {
                            result = result && _IMS_Tiempos_de_Comida_PlatillosApiConsumer.Delete(MS_Tiempos_de_Comida_PlatillosItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							MS_Tiempos_de_Comida_PlatillosItem.Folio = 0;

                        var MS_Tiempos_de_Comida_PlatillosData = new MS_Tiempos_de_Comida_Platillos
                        {
                            Folio_Platillos = MasterId
                            ,Folio = MS_Tiempos_de_Comida_PlatillosItem.Folio
                            ,Tiempo_de_Comida = (Convert.ToInt32(MS_Tiempos_de_Comida_PlatillosItem.Tiempo_de_Comida) == 0 ? (Int32?)null : Convert.ToInt32(MS_Tiempos_de_Comida_PlatillosItem.Tiempo_de_Comida))

                        };

                        var resultId = MS_Tiempos_de_Comida_PlatillosItem.Folio > 0
                           ? _IMS_Tiempos_de_Comida_PlatillosApiConsumer.Update(MS_Tiempos_de_Comida_PlatillosData,null,null).Resource
                           : _IMS_Tiempos_de_Comida_PlatillosApiConsumer.Insert(MS_Tiempos_de_Comida_PlatillosData,null,null).Resource;

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
        public ActionResult GetMS_Tiempos_de_Comida_Platillos_Tiempos_de_ComidaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITiempos_de_ComidaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITiempos_de_ComidaApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Tiempos_de_Comida", "Comida");
                  item.Comida= trans??item.Comida;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [NonAction]
        public bool CopyMS_Caracteristicas_Platillo(int MasterId, int referenceId, List<MS_Caracteristicas_PlatilloGridModelPost> MS_Caracteristicas_PlatilloItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IMS_Caracteristicas_PlatilloApiConsumer.SetAuthHeader(_tokenManager.Token);

                var MS_Caracteristicas_PlatilloData = _IMS_Caracteristicas_PlatilloApiConsumer.ListaSelAll(1, int.MaxValue, "MS_Caracteristicas_Platillo.Folio_Platillos=" + referenceId,"").Resource;
                if (MS_Caracteristicas_PlatilloData == null || MS_Caracteristicas_PlatilloData.MS_Caracteristicas_Platillos.Count == 0)
                    return true;

                var result = true;

                MS_Caracteristicas_PlatilloGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varMS_Caracteristicas_Platillo in MS_Caracteristicas_PlatilloData.MS_Caracteristicas_Platillos)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    MS_Caracteristicas_Platillo MS_Caracteristicas_Platillo1 = varMS_Caracteristicas_Platillo;

                    if (MS_Caracteristicas_PlatilloItems != null && MS_Caracteristicas_PlatilloItems.Any(m => m.Folio == MS_Caracteristicas_Platillo1.Folio))
                    {
                        modelDataToChange = MS_Caracteristicas_PlatilloItems.FirstOrDefault(m => m.Folio == MS_Caracteristicas_Platillo1.Folio);
                    }
                    //Chaning Id Value
                    varMS_Caracteristicas_Platillo.Folio_Platillos = MasterId;
                    var insertId = _IMS_Caracteristicas_PlatilloApiConsumer.Insert(varMS_Caracteristicas_Platillo,null,null).Resource;
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
        public ActionResult PostMS_Caracteristicas_Platillo(List<MS_Caracteristicas_PlatilloGridModelPost> MS_Caracteristicas_PlatilloItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyMS_Caracteristicas_Platillo(MasterId, referenceId, MS_Caracteristicas_PlatilloItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (MS_Caracteristicas_PlatilloItems != null && MS_Caracteristicas_PlatilloItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IMS_Caracteristicas_PlatilloApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var MS_Caracteristicas_PlatilloItem in MS_Caracteristicas_PlatilloItems)
                    {



                        //Removal Request
                        if (MS_Caracteristicas_PlatilloItem.Removed)
                        {
                            result = result && _IMS_Caracteristicas_PlatilloApiConsumer.Delete(MS_Caracteristicas_PlatilloItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							MS_Caracteristicas_PlatilloItem.Folio = 0;

                        var MS_Caracteristicas_PlatilloData = new MS_Caracteristicas_Platillo
                        {
                            Folio_Platillos = MasterId
                            ,Folio = MS_Caracteristicas_PlatilloItem.Folio
                            ,Caracteristicas = (Convert.ToInt32(MS_Caracteristicas_PlatilloItem.Caracteristicas) == 0 ? (Int32?)null : Convert.ToInt32(MS_Caracteristicas_PlatilloItem.Caracteristicas))

                        };

                        var resultId = MS_Caracteristicas_PlatilloItem.Folio > 0
                           ? _IMS_Caracteristicas_PlatilloApiConsumer.Update(MS_Caracteristicas_PlatilloData,null,null).Resource
                           : _IMS_Caracteristicas_PlatilloApiConsumer.Insert(MS_Caracteristicas_PlatilloData,null,null).Resource;

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
        public ActionResult GetMS_Caracteristicas_Platillo_Caracteristicas_platilloAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ICaracteristicas_platilloApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ICaracteristicas_platilloApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Folio), "Caracteristicas_platillo", "Caracteristicas");
                  item.Caracteristicas= trans??item.Caracteristicas;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [NonAction]
        public bool CopyMR_Detalle_Platillo(int MasterId, int referenceId, List<MR_Detalle_PlatilloGridModelPost> MR_Detalle_PlatilloItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IMR_Detalle_PlatilloApiConsumer.SetAuthHeader(_tokenManager.Token);

                var MR_Detalle_PlatilloData = _IMR_Detalle_PlatilloApiConsumer.ListaSelAll(1, int.MaxValue, "MR_Detalle_Platillo.Folio_Platillos=" + referenceId,"").Resource;
                if (MR_Detalle_PlatilloData == null || MR_Detalle_PlatilloData.MR_Detalle_Platillos.Count == 0)
                    return true;

                var result = true;

                MR_Detalle_PlatilloGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varMR_Detalle_Platillo in MR_Detalle_PlatilloData.MR_Detalle_Platillos)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    MR_Detalle_Platillo MR_Detalle_Platillo1 = varMR_Detalle_Platillo;

                    if (MR_Detalle_PlatilloItems != null && MR_Detalle_PlatilloItems.Any(m => m.Folio == MR_Detalle_Platillo1.Folio))
                    {
                        modelDataToChange = MR_Detalle_PlatilloItems.FirstOrDefault(m => m.Folio == MR_Detalle_Platillo1.Folio);
                    }
                    //Chaning Id Value
                    varMR_Detalle_Platillo.Folio_Platillos = MasterId;
                    var insertId = _IMR_Detalle_PlatilloApiConsumer.Insert(varMR_Detalle_Platillo,null,null).Resource;
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
        public ActionResult PostMR_Detalle_Platillo(List<MR_Detalle_PlatilloGridModelPost> MR_Detalle_PlatilloItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyMR_Detalle_Platillo(MasterId, referenceId, MR_Detalle_PlatilloItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (MR_Detalle_PlatilloItems != null && MR_Detalle_PlatilloItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IMR_Detalle_PlatilloApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var MR_Detalle_PlatilloItem in MR_Detalle_PlatilloItems)
                    {








                        //Removal Request
                        if (MR_Detalle_PlatilloItem.Removed)
                        {
                            result = result && _IMR_Detalle_PlatilloApiConsumer.Delete(MR_Detalle_PlatilloItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							MR_Detalle_PlatilloItem.Folio = 0;

                        var MR_Detalle_PlatilloData = new MR_Detalle_Platillo
                        {
                            Folio_Platillos = MasterId
                            ,Folio = MR_Detalle_PlatilloItem.Folio
                            ,Ingrediente = (Convert.ToInt32(MR_Detalle_PlatilloItem.Ingrediente) == 0 ? (Int32?)null : Convert.ToInt32(MR_Detalle_PlatilloItem.Ingrediente))
                            ,Cantidad = MR_Detalle_PlatilloItem.Cantidad
                            ,Cantidad_en_Fraccion = MR_Detalle_PlatilloItem.Cantidad_en_Fraccion
                            ,Unidad = (Convert.ToInt32(MR_Detalle_PlatilloItem.Unidad) == 0 ? (Int32?)null : Convert.ToInt32(MR_Detalle_PlatilloItem.Unidad))
                            ,Cantidad_a_mostrar = MR_Detalle_PlatilloItem.Cantidad_a_mostrar
                            ,Ingrediente_a_mostrar = MR_Detalle_PlatilloItem.Ingrediente_a_mostrar

                        };

                        var resultId = MR_Detalle_PlatilloItem.Folio > 0
                           ? _IMR_Detalle_PlatilloApiConsumer.Update(MR_Detalle_PlatilloData,null,null).Resource
                           : _IMR_Detalle_PlatilloApiConsumer.Insert(MR_Detalle_PlatilloData,null,null).Resource;

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
        public ActionResult GetMR_Detalle_Platillo_IngredientesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IIngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IIngredientesApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Ingredientes", "Nombre_Ingrediente");
                  item.Nombre_Ingrediente= trans??item.Nombre_Ingrediente;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public ActionResult GetMR_Detalle_Platillo_Unidades_de_MedidaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IUnidades_de_MedidaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IUnidades_de_MedidaApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Unidades_de_Medida", "Unidad");
                  item.Unidad= trans??item.Unidad;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }





        /// <summary>
        /// Write Element Array of Platillos script
        /// </summary>
        /// <param name="oPlatillosElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew PlatillosModuleAttributeList)
        {
            for (int i = 0; i < PlatillosModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(PlatillosModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    PlatillosModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(PlatillosModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    PlatillosModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (PlatillosModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < PlatillosModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < PlatillosModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(PlatillosModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							PlatillosModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(PlatillosModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							PlatillosModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strPlatillosScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Platillos.js")))
            {
                strPlatillosScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Platillos element attributes
            string userChangeJson = jsSerialize.Serialize(PlatillosModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strPlatillosScript.IndexOf("inpuElementArray");
            string splittedString = strPlatillosScript.Substring(indexOfArray, strPlatillosScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(PlatillosModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (PlatillosModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strPlatillosScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strPlatillosScript.Substring(indexOfArrayHistory, strPlatillosScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strPlatillosScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strPlatillosScript.Substring(endIndexOfMainElement + indexOfArray, strPlatillosScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (PlatillosModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in PlatillosModuleAttributeList.ChildModuleAttributeList)
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
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Platillos.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Platillos.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Platillos.js")))
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
        public ActionResult PlatillosPropertyBag()
        {
            return PartialView("PlatillosPropertyBag", "Platillos");
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
        public ActionResult AddMS_Calorias(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../MS_Calorias/AddMS_Calorias");
        }

        [HttpGet]
        public ActionResult AddMS_Dificultad_Platillos(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../MS_Dificultad_Platillos/AddMS_Dificultad_Platillos");
        }

        [HttpGet]
        public ActionResult AddMS_Padecimientos(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../MS_Padecimientos/AddMS_Padecimientos");
        }

        [HttpGet]
        public ActionResult AddMS_Tiempos_de_Comida_Platillos(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../MS_Tiempos_de_Comida_Platillos/AddMS_Tiempos_de_Comida_Platillos");
        }

        [HttpGet]
        public ActionResult AddMS_Caracteristicas_Platillo(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../MS_Caracteristicas_Platillo/AddMS_Caracteristicas_Platillo");
        }

        [HttpGet]
        public ActionResult AddMR_Detalle_Platillo(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../MR_Detalle_Platillo/AddMR_Detalle_Platillo");
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
                var whereClauseFormat = "Object = 43967 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _IPlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Platillos.Folio= " + RecordId;
                            var result = _IPlatillosApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
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

            _IPlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new PlatillosPropertyMapper());
			
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
                    (PlatillosAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
			string sortDirection = "asc";

            PlatillosPropertyMapper oPlatillosPropertyMapper = new PlatillosPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oPlatillosPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IPlatillosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Platilloss == null)
                result.Platilloss = new List<Platillos>();

            var data = result.Platilloss.Select(m => new PlatillosGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre_de_Platillo = m.Nombre_de_Platillo
			,Imagen = m.Imagen
                        ,Tipo_de_comidaTipo_de_comida = CultureHelper.GetTraduction(m.Tipo_de_comida_Tipo_de_comida_platillos.Folio.ToString(), "Tipo_de_comida") ?? (string)m.Tipo_de_comida_Tipo_de_comida_platillos.Tipo_de_comida
			,Calificacion = m.Calificacion
			,Modo_de_Preparacion = m.Modo_de_Preparacion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(43967, arrayColumnsVisible), "PlatillosList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(43967, arrayColumnsVisible), "PlatillosList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(43967, arrayColumnsVisible), "PlatillosList_" + DateTime.Now.ToString());
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

            _IPlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new PlatillosPropertyMapper());
				
				
            if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
			if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (PlatillosAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            PlatillosPropertyMapper oPlatillosPropertyMapper = new PlatillosPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oPlatillosPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
			
			if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IPlatillosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Platilloss == null)
                result.Platilloss = new List<Platillos>();

            var data = result.Platilloss.Select(m => new PlatillosGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre_de_Platillo = m.Nombre_de_Platillo
			,Imagen = m.Imagen
                        ,Tipo_de_comidaTipo_de_comida = CultureHelper.GetTraduction(m.Tipo_de_comida_Tipo_de_comida_platillos.Folio.ToString(), "Tipo_de_comida") ?? (string)m.Tipo_de_comida_Tipo_de_comida_platillos.Tipo_de_comida
			,Calificacion = m.Calificacion
			,Modo_de_Preparacion = m.Modo_de_Preparacion

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
                _IPlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPlatillosApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpPost]
        public ActionResult Post_Datos_Generales(Platillos_Datos_GeneralesModel varPlatillos)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);
				                    if (varPlatillos.ImagenRemoveAttachment != 0 && varPlatillos.ImagenFile == null)
                    {
                        varPlatillos.Imagen = 0;
                    }

                    if (varPlatillos.ImagenFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varPlatillos.ImagenFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varPlatillos.Imagen = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varPlatillos.ImagenFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }

                var result = "";
                var Platillos_Datos_GeneralesInfo = new Platillos_Datos_Generales
                {
                    Folio = varPlatillos.Folio
                                            ,Fecha_de_Registro = (!String.IsNullOrEmpty(varPlatillos.Fecha_de_Registro)) ? DateTime.ParseExact(varPlatillos.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varPlatillos.Hora_de_Registro
                        ,Usuario_que_Registra = varPlatillos.Usuario_que_Registra
                        ,Nombre_de_Platillo = varPlatillos.Nombre_de_Platillo
                        ,Imagen = (varPlatillos.Imagen.HasValue && varPlatillos.Imagen != 0) ? ((int?)Convert.ToInt32(varPlatillos.Imagen.Value)) : null

                        ,Tipo_de_comida = varPlatillos.Tipo_de_comida
                        ,Calificacion = varPlatillos.Calificacion
                        ,Modo_de_Preparacion = varPlatillos.Modo_de_Preparacion
                    
                };

                result = _IPlatillosApiConsumer.Update_Datos_Generales(Platillos_Datos_GeneralesInfo).Resource.ToString();
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
                _IPlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IPlatillosApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_MR_Detalle_Platillo;
                var MR_Detalle_PlatilloData = GetMR_Detalle_PlatilloData(Id.ToString(), 0, Int16.MaxValue, out RowCount_MR_Detalle_Platillo);

                var result = new Platillos_Datos_GeneralesModel
                {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_Registra = m.Usuario_que_Registra
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre_de_Platillo = m.Nombre_de_Platillo
			,Imagen = m.Imagen
                        ,Tipo_de_comida = m.Tipo_de_comida
                        ,Tipo_de_comidaTipo_de_comida = CultureHelper.GetTraduction(m.Tipo_de_comida_Tipo_de_comida_platillos.Folio.ToString(), "Tipo_de_comida") ?? (string)m.Tipo_de_comida_Tipo_de_comida_platillos.Tipo_de_comida
			,Calificacion = m.Calificacion
			,Modo_de_Preparacion = m.Modo_de_Preparacion

                    
                };
				var resultData = new
                {
                    data = result
                    ,Ingredientes_del_Platillo = MR_Detalle_PlatilloData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }


    }
}

