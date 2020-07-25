using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Meses;
using Spartane.Core.Domain.Estatus_Facturas;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Resultados_de_Revision;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Estatus_de_Pago_de_Facturas;
using Spartane.Core.Domain.Spartan_User;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Solicitud_de_Pago_de_Facturas;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Solicitud_de_Pago_de_Facturas;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Meses;
using Spartane.Web.Areas.WebApiConsumer.Estatus_Facturas;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Resultados_de_Revision;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Estatus_de_Pago_de_Facturas;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;

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
    public class Solicitud_de_Pago_de_FacturasController : Controller
    {
        #region "variable declaration"

        private ISolicitud_de_Pago_de_FacturasService service = null;
        private ISolicitud_de_Pago_de_FacturasApiConsumer _ISolicitud_de_Pago_de_FacturasApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private IMesesApiConsumer _IMesesApiConsumer;
        private IEstatus_FacturasApiConsumer _IEstatus_FacturasApiConsumer;
        private IResultados_de_RevisionApiConsumer _IResultados_de_RevisionApiConsumer;
        private IEstatus_de_Pago_de_FacturasApiConsumer _IEstatus_de_Pago_de_FacturasApiConsumer;

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

        
        public Solicitud_de_Pago_de_FacturasController(ISolicitud_de_Pago_de_FacturasService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ISolicitud_de_Pago_de_FacturasApiConsumer Solicitud_de_Pago_de_FacturasApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer , IMesesApiConsumer MesesApiConsumer , IEstatus_FacturasApiConsumer Estatus_FacturasApiConsumer , IResultados_de_RevisionApiConsumer Resultados_de_RevisionApiConsumer , IEstatus_de_Pago_de_FacturasApiConsumer Estatus_de_Pago_de_FacturasApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._ISolicitud_de_Pago_de_FacturasApiConsumer = Solicitud_de_Pago_de_FacturasApiConsumer;
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
            this._IMesesApiConsumer = MesesApiConsumer;
            this._IEstatus_FacturasApiConsumer = Estatus_FacturasApiConsumer;
            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;
            this._IResultados_de_RevisionApiConsumer = Resultados_de_RevisionApiConsumer;
            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;
            this._IEstatus_de_Pago_de_FacturasApiConsumer = Estatus_de_Pago_de_FacturasApiConsumer;
            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Solicitud_de_Pago_de_Facturas
        [ObjectAuth(ObjectId = (ModuleObjectId)44742, PermissionType = PermissionTypes.Consult)]
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
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44742, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			          
            return View();
        }

        // GET: Frontal/Solicitud_de_Pago_de_Facturas/Create
          [ObjectAuth(ObjectId = (ModuleObjectId)44742, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44742, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varSolicitud_de_Pago_de_Facturas = new Solicitud_de_Pago_de_FacturasModel();
			varSolicitud_de_Pago_de_Facturas.Folio = Id;
			
            ViewBag.ObjectId = "44742";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
				
				_tokenManager.GenerateToken();
				_ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _ISolicitud_de_Pago_de_FacturasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Solicitud_de_Pago_de_FacturassData = _ISolicitud_de_Pago_de_FacturasApiConsumer.ListaSelAll(0, 1000, "Solicitud_de_Pago_de_Facturas.Folio=" + Id, "").Resource.Solicitud_de_Pago_de_Facturass;
				
				if (Solicitud_de_Pago_de_FacturassData != null && Solicitud_de_Pago_de_FacturassData.Count > 0)
                {
					var Solicitud_de_Pago_de_FacturasData = Solicitud_de_Pago_de_FacturassData.First();
					varSolicitud_de_Pago_de_Facturas= new Solicitud_de_Pago_de_FacturasModel
					{
						Folio  = Solicitud_de_Pago_de_FacturasData.Folio 
	                    ,Fecha_de_Registro = (Solicitud_de_Pago_de_FacturasData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(Solicitud_de_Pago_de_FacturasData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = Solicitud_de_Pago_de_FacturasData.Hora_de_Registro
                    ,Usuario_que_Registra = Solicitud_de_Pago_de_FacturasData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(Solicitud_de_Pago_de_FacturasData.Usuario_que_Registra), "Spartan_User") ??  (string)Solicitud_de_Pago_de_FacturasData.Usuario_que_Registra_Spartan_User.Name
                    ,Mes_Facturado = Solicitud_de_Pago_de_FacturasData.Mes_Facturado
                    ,Mes_FacturadoNombre = CultureHelper.GetTraduction(Convert.ToString(Solicitud_de_Pago_de_FacturasData.Mes_Facturado), "Meses") ??  (string)Solicitud_de_Pago_de_FacturasData.Mes_Facturado_Meses.Nombre
                    ,Fecha_inicio_del_periodo_facturado = (Solicitud_de_Pago_de_FacturasData.Fecha_inicio_del_periodo_facturado == null ? string.Empty : Convert.ToDateTime(Solicitud_de_Pago_de_FacturasData.Fecha_inicio_del_periodo_facturado).ToString(ConfigurationProperty.DateFormat))
                    ,Fecha_fin_del_periodo_facturado = (Solicitud_de_Pago_de_FacturasData.Fecha_fin_del_periodo_facturado == null ? string.Empty : Convert.ToDateTime(Solicitud_de_Pago_de_FacturasData.Fecha_fin_del_periodo_facturado).ToString(ConfigurationProperty.DateFormat))
                    ,Archivo_XML = Solicitud_de_Pago_de_FacturasData.Archivo_XML
                    ,Archivo_PDF = Solicitud_de_Pago_de_FacturasData.Archivo_PDF
                    ,Recibo_de_Solicitud_de_Pago = Solicitud_de_Pago_de_FacturasData.Recibo_de_Solicitud_de_Pago
                    ,Total = Solicitud_de_Pago_de_FacturasData.Total
                    ,Estatus = Solicitud_de_Pago_de_FacturasData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Solicitud_de_Pago_de_FacturasData.Estatus), "Estatus_Facturas") ??  (string)Solicitud_de_Pago_de_FacturasData.Estatus_Estatus_Facturas.Descripcion
                    ,Fecha_de_autorizacion = (Solicitud_de_Pago_de_FacturasData.Fecha_de_autorizacion == null ? string.Empty : Convert.ToDateTime(Solicitud_de_Pago_de_FacturasData.Fecha_de_autorizacion).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_autorizacion = Solicitud_de_Pago_de_FacturasData.Hora_de_autorizacion
                    ,Usuario_que_autoriza = Solicitud_de_Pago_de_FacturasData.Usuario_que_autoriza
                    ,Usuario_que_autorizaName = CultureHelper.GetTraduction(Convert.ToString(Solicitud_de_Pago_de_FacturasData.Usuario_que_autoriza), "Spartan_User") ??  (string)Solicitud_de_Pago_de_FacturasData.Usuario_que_autoriza_Spartan_User.Name
                    ,Resultado_de_la_Revision = Solicitud_de_Pago_de_FacturasData.Resultado_de_la_Revision
                    ,Resultado_de_la_RevisionNombre = CultureHelper.GetTraduction(Convert.ToString(Solicitud_de_Pago_de_FacturasData.Resultado_de_la_Revision), "Resultados_de_Revision") ??  (string)Solicitud_de_Pago_de_FacturasData.Resultado_de_la_Revision_Resultados_de_Revision.Nombre
                    ,Observaciones = Solicitud_de_Pago_de_FacturasData.Observaciones
                    ,Fecha_de_programacion = (Solicitud_de_Pago_de_FacturasData.Fecha_de_programacion == null ? string.Empty : Convert.ToDateTime(Solicitud_de_Pago_de_FacturasData.Fecha_de_programacion).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_programacion = Solicitud_de_Pago_de_FacturasData.Hora_de_programacion
                    ,Usuario_que_programa = Solicitud_de_Pago_de_FacturasData.Usuario_que_programa
                    ,Usuario_que_programaName = CultureHelper.GetTraduction(Convert.ToString(Solicitud_de_Pago_de_FacturasData.Usuario_que_programa), "Spartan_User") ??  (string)Solicitud_de_Pago_de_FacturasData.Usuario_que_programa_Spartan_User.Name
                    ,Fecha_programada_de_Pago = (Solicitud_de_Pago_de_FacturasData.Fecha_programada_de_Pago == null ? string.Empty : Convert.ToDateTime(Solicitud_de_Pago_de_FacturasData.Fecha_programada_de_Pago).ToString(ConfigurationProperty.DateFormat))
                    ,Estatus_de_Pago = Solicitud_de_Pago_de_FacturasData.Estatus_de_Pago
                    ,Estatus_de_PagoNombre = CultureHelper.GetTraduction(Convert.ToString(Solicitud_de_Pago_de_FacturasData.Estatus_de_Pago), "Estatus_de_Pago_de_Facturas") ??  (string)Solicitud_de_Pago_de_FacturasData.Estatus_de_Pago_Estatus_de_Pago_de_Facturas.Nombre
                    ,Fecha_de_actualizacion = (Solicitud_de_Pago_de_FacturasData.Fecha_de_actualizacion == null ? string.Empty : Convert.ToDateTime(Solicitud_de_Pago_de_FacturasData.Fecha_de_actualizacion).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_actualizacion = Solicitud_de_Pago_de_FacturasData.Hora_de_actualizacion
                    ,Usuario_que_actualiza = Solicitud_de_Pago_de_FacturasData.Usuario_que_actualiza
                    ,Usuario_que_actualizaName = CultureHelper.GetTraduction(Convert.ToString(Solicitud_de_Pago_de_FacturasData.Usuario_que_actualiza), "Spartan_User") ??  (string)Solicitud_de_Pago_de_FacturasData.Usuario_que_actualiza_Spartan_User.Name
                    ,Fecha_de_Pago = (Solicitud_de_Pago_de_FacturasData.Fecha_de_Pago == null ? string.Empty : Convert.ToDateTime(Solicitud_de_Pago_de_FacturasData.Fecha_de_Pago).ToString(ConfigurationProperty.DateFormat))

					};
				}
				
				                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.Archivo_XMLSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varSolicitud_de_Pago_de_Facturas.Archivo_XML).Resource;
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.Archivo_PDFSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varSolicitud_de_Pago_de_Facturas.Archivo_PDF).Resource;
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.Recibo_de_Solicitud_de_PagoSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varSolicitud_de_Pago_de_Facturas.Recibo_de_Solicitud_de_Pago).Resource;

				
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
            _IMesesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Mesess_Mes_Facturado = _IMesesApiConsumer.SelAll(true);
            if (Mesess_Mes_Facturado != null && Mesess_Mes_Facturado.Resource != null)
                ViewBag.Mesess_Mes_Facturado = Mesess_Mes_Facturado.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Meses", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatus_FacturasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_Facturass_Estatus = _IEstatus_FacturasApiConsumer.SelAll(true);
            if (Estatus_Facturass_Estatus != null && Estatus_Facturass_Estatus.Resource != null)
                ViewBag.Estatus_Facturass_Estatus = Estatus_Facturass_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_Facturas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_que_autoriza = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_que_autoriza != null && Spartan_Users_Usuario_que_autoriza.Resource != null)
                ViewBag.Spartan_Users_Usuario_que_autoriza = Spartan_Users_Usuario_que_autoriza.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IResultados_de_RevisionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Resultados_de_Revisions_Resultado_de_la_Revision = _IResultados_de_RevisionApiConsumer.SelAll(true);
            if (Resultados_de_Revisions_Resultado_de_la_Revision != null && Resultados_de_Revisions_Resultado_de_la_Revision.Resource != null)
                ViewBag.Resultados_de_Revisions_Resultado_de_la_Revision = Resultados_de_Revisions_Resultado_de_la_Revision.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Resultados_de_Revision", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_que_programa = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_que_programa != null && Spartan_Users_Usuario_que_programa.Resource != null)
                ViewBag.Spartan_Users_Usuario_que_programa = Spartan_Users_Usuario_que_programa.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IEstatus_de_Pago_de_FacturasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_de_Pago_de_Facturass_Estatus_de_Pago = _IEstatus_de_Pago_de_FacturasApiConsumer.SelAll(true);
            if (Estatus_de_Pago_de_Facturass_Estatus_de_Pago != null && Estatus_de_Pago_de_Facturass_Estatus_de_Pago.Resource != null)
                ViewBag.Estatus_de_Pago_de_Facturass_Estatus_de_Pago = Estatus_de_Pago_de_Facturass_Estatus_de_Pago.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Estatus_de_Pago_de_Facturas", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_que_actualiza = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_que_actualiza != null && Spartan_Users_Usuario_que_actualiza.Resource != null)
                ViewBag.Spartan_Users_Usuario_que_actualiza = Spartan_Users_Usuario_que_actualiza.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
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

				
            return View(varSolicitud_de_Pago_de_Facturas);
        }
		
	[HttpGet]
        public ActionResult AddSolicitud_de_Pago_de_Facturas(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44742);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _ISolicitud_de_Pago_de_FacturasApiConsumer.SetAuthHeader(_tokenManager.Token);
			Solicitud_de_Pago_de_FacturasModel varSolicitud_de_Pago_de_Facturas= new Solicitud_de_Pago_de_FacturasModel();


            if (id.ToString() != "0")
            {
                var Solicitud_de_Pago_de_FacturassData = _ISolicitud_de_Pago_de_FacturasApiConsumer.ListaSelAll(0, 1000, "Solicitud_de_Pago_de_Facturas.Folio=" + id, "").Resource.Solicitud_de_Pago_de_Facturass;
				
				if (Solicitud_de_Pago_de_FacturassData != null && Solicitud_de_Pago_de_FacturassData.Count > 0)
                {
					var Solicitud_de_Pago_de_FacturasData = Solicitud_de_Pago_de_FacturassData.First();
					varSolicitud_de_Pago_de_Facturas= new Solicitud_de_Pago_de_FacturasModel
					{
						Folio  = Solicitud_de_Pago_de_FacturasData.Folio 
	                    ,Fecha_de_Registro = (Solicitud_de_Pago_de_FacturasData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(Solicitud_de_Pago_de_FacturasData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = Solicitud_de_Pago_de_FacturasData.Hora_de_Registro
                    ,Usuario_que_Registra = Solicitud_de_Pago_de_FacturasData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(Solicitud_de_Pago_de_FacturasData.Usuario_que_Registra), "Spartan_User") ??  (string)Solicitud_de_Pago_de_FacturasData.Usuario_que_Registra_Spartan_User.Name
                    ,Mes_Facturado = Solicitud_de_Pago_de_FacturasData.Mes_Facturado
                    ,Mes_FacturadoNombre = CultureHelper.GetTraduction(Convert.ToString(Solicitud_de_Pago_de_FacturasData.Mes_Facturado), "Meses") ??  (string)Solicitud_de_Pago_de_FacturasData.Mes_Facturado_Meses.Nombre
                    ,Fecha_inicio_del_periodo_facturado = (Solicitud_de_Pago_de_FacturasData.Fecha_inicio_del_periodo_facturado == null ? string.Empty : Convert.ToDateTime(Solicitud_de_Pago_de_FacturasData.Fecha_inicio_del_periodo_facturado).ToString(ConfigurationProperty.DateFormat))
                    ,Fecha_fin_del_periodo_facturado = (Solicitud_de_Pago_de_FacturasData.Fecha_fin_del_periodo_facturado == null ? string.Empty : Convert.ToDateTime(Solicitud_de_Pago_de_FacturasData.Fecha_fin_del_periodo_facturado).ToString(ConfigurationProperty.DateFormat))
                    ,Archivo_XML = Solicitud_de_Pago_de_FacturasData.Archivo_XML
                    ,Archivo_PDF = Solicitud_de_Pago_de_FacturasData.Archivo_PDF
                    ,Recibo_de_Solicitud_de_Pago = Solicitud_de_Pago_de_FacturasData.Recibo_de_Solicitud_de_Pago
                    ,Total = Solicitud_de_Pago_de_FacturasData.Total
                    ,Estatus = Solicitud_de_Pago_de_FacturasData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Solicitud_de_Pago_de_FacturasData.Estatus), "Estatus_Facturas") ??  (string)Solicitud_de_Pago_de_FacturasData.Estatus_Estatus_Facturas.Descripcion
                    ,Fecha_de_autorizacion = (Solicitud_de_Pago_de_FacturasData.Fecha_de_autorizacion == null ? string.Empty : Convert.ToDateTime(Solicitud_de_Pago_de_FacturasData.Fecha_de_autorizacion).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_autorizacion = Solicitud_de_Pago_de_FacturasData.Hora_de_autorizacion
                    ,Usuario_que_autoriza = Solicitud_de_Pago_de_FacturasData.Usuario_que_autoriza
                    ,Usuario_que_autorizaName = CultureHelper.GetTraduction(Convert.ToString(Solicitud_de_Pago_de_FacturasData.Usuario_que_autoriza), "Spartan_User") ??  (string)Solicitud_de_Pago_de_FacturasData.Usuario_que_autoriza_Spartan_User.Name
                    ,Resultado_de_la_Revision = Solicitud_de_Pago_de_FacturasData.Resultado_de_la_Revision
                    ,Resultado_de_la_RevisionNombre = CultureHelper.GetTraduction(Convert.ToString(Solicitud_de_Pago_de_FacturasData.Resultado_de_la_Revision), "Resultados_de_Revision") ??  (string)Solicitud_de_Pago_de_FacturasData.Resultado_de_la_Revision_Resultados_de_Revision.Nombre
                    ,Observaciones = Solicitud_de_Pago_de_FacturasData.Observaciones
                    ,Fecha_de_programacion = (Solicitud_de_Pago_de_FacturasData.Fecha_de_programacion == null ? string.Empty : Convert.ToDateTime(Solicitud_de_Pago_de_FacturasData.Fecha_de_programacion).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_programacion = Solicitud_de_Pago_de_FacturasData.Hora_de_programacion
                    ,Usuario_que_programa = Solicitud_de_Pago_de_FacturasData.Usuario_que_programa
                    ,Usuario_que_programaName = CultureHelper.GetTraduction(Convert.ToString(Solicitud_de_Pago_de_FacturasData.Usuario_que_programa), "Spartan_User") ??  (string)Solicitud_de_Pago_de_FacturasData.Usuario_que_programa_Spartan_User.Name
                    ,Fecha_programada_de_Pago = (Solicitud_de_Pago_de_FacturasData.Fecha_programada_de_Pago == null ? string.Empty : Convert.ToDateTime(Solicitud_de_Pago_de_FacturasData.Fecha_programada_de_Pago).ToString(ConfigurationProperty.DateFormat))
                    ,Estatus_de_Pago = Solicitud_de_Pago_de_FacturasData.Estatus_de_Pago
                    ,Estatus_de_PagoNombre = CultureHelper.GetTraduction(Convert.ToString(Solicitud_de_Pago_de_FacturasData.Estatus_de_Pago), "Estatus_de_Pago_de_Facturas") ??  (string)Solicitud_de_Pago_de_FacturasData.Estatus_de_Pago_Estatus_de_Pago_de_Facturas.Nombre
                    ,Fecha_de_actualizacion = (Solicitud_de_Pago_de_FacturasData.Fecha_de_actualizacion == null ? string.Empty : Convert.ToDateTime(Solicitud_de_Pago_de_FacturasData.Fecha_de_actualizacion).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_actualizacion = Solicitud_de_Pago_de_FacturasData.Hora_de_actualizacion
                    ,Usuario_que_actualiza = Solicitud_de_Pago_de_FacturasData.Usuario_que_actualiza
                    ,Usuario_que_actualizaName = CultureHelper.GetTraduction(Convert.ToString(Solicitud_de_Pago_de_FacturasData.Usuario_que_actualiza), "Spartan_User") ??  (string)Solicitud_de_Pago_de_FacturasData.Usuario_que_actualiza_Spartan_User.Name
                    ,Fecha_de_Pago = (Solicitud_de_Pago_de_FacturasData.Fecha_de_Pago == null ? string.Empty : Convert.ToDateTime(Solicitud_de_Pago_de_FacturasData.Fecha_de_Pago).ToString(ConfigurationProperty.DateFormat))

					};
				}
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.Archivo_XMLSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varSolicitud_de_Pago_de_Facturas.Archivo_XML).Resource;
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.Archivo_PDFSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varSolicitud_de_Pago_de_Facturas.Archivo_PDF).Resource;
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.Recibo_de_Solicitud_de_PagoSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varSolicitud_de_Pago_de_Facturas.Recibo_de_Solicitud_de_Pago).Resource;

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
            _IMesesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Mesess_Mes_Facturado = _IMesesApiConsumer.SelAll(true);
            if (Mesess_Mes_Facturado != null && Mesess_Mes_Facturado.Resource != null)
                ViewBag.Mesess_Mes_Facturado = Mesess_Mes_Facturado.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Meses", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatus_FacturasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_Facturass_Estatus = _IEstatus_FacturasApiConsumer.SelAll(true);
            if (Estatus_Facturass_Estatus != null && Estatus_Facturass_Estatus.Resource != null)
                ViewBag.Estatus_Facturass_Estatus = Estatus_Facturass_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_Facturas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_que_autoriza = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_que_autoriza != null && Spartan_Users_Usuario_que_autoriza.Resource != null)
                ViewBag.Spartan_Users_Usuario_que_autoriza = Spartan_Users_Usuario_que_autoriza.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IResultados_de_RevisionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Resultados_de_Revisions_Resultado_de_la_Revision = _IResultados_de_RevisionApiConsumer.SelAll(true);
            if (Resultados_de_Revisions_Resultado_de_la_Revision != null && Resultados_de_Revisions_Resultado_de_la_Revision.Resource != null)
                ViewBag.Resultados_de_Revisions_Resultado_de_la_Revision = Resultados_de_Revisions_Resultado_de_la_Revision.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Resultados_de_Revision", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_que_programa = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_que_programa != null && Spartan_Users_Usuario_que_programa.Resource != null)
                ViewBag.Spartan_Users_Usuario_que_programa = Spartan_Users_Usuario_que_programa.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IEstatus_de_Pago_de_FacturasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_de_Pago_de_Facturass_Estatus_de_Pago = _IEstatus_de_Pago_de_FacturasApiConsumer.SelAll(true);
            if (Estatus_de_Pago_de_Facturass_Estatus_de_Pago != null && Estatus_de_Pago_de_Facturass_Estatus_de_Pago.Resource != null)
                ViewBag.Estatus_de_Pago_de_Facturass_Estatus_de_Pago = Estatus_de_Pago_de_Facturass_Estatus_de_Pago.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Estatus_de_Pago_de_Facturas", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_que_actualiza = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_que_actualiza != null && Spartan_Users_Usuario_que_actualiza.Resource != null)
                ViewBag.Spartan_Users_Usuario_que_actualiza = Spartan_Users_Usuario_que_actualiza.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();


            return PartialView("AddSolicitud_de_Pago_de_Facturas", varSolicitud_de_Pago_de_Facturas);
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
        public ActionResult GetMesesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMesesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IMesesApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Meses", "Nombre")?? m.Nombre,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetEstatus_FacturasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatus_FacturasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstatus_FacturasApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_Facturas", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetResultados_de_RevisionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IResultados_de_RevisionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IResultados_de_RevisionApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Resultados_de_Revision", "Nombre")?? m.Nombre,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetEstatus_de_Pago_de_FacturasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatus_de_Pago_de_FacturasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstatus_de_Pago_de_FacturasApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Estatus_de_Pago_de_Facturas", "Nombre")?? m.Nombre,
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
        public ActionResult ShowAdvanceFilter(Solicitud_de_Pago_de_FacturasAdvanceSearchModel model, int idFilter = -1)
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
            _IMesesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Mesess_Mes_Facturado = _IMesesApiConsumer.SelAll(true);
            if (Mesess_Mes_Facturado != null && Mesess_Mes_Facturado.Resource != null)
                ViewBag.Mesess_Mes_Facturado = Mesess_Mes_Facturado.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Meses", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatus_FacturasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_Facturass_Estatus = _IEstatus_FacturasApiConsumer.SelAll(true);
            if (Estatus_Facturass_Estatus != null && Estatus_Facturass_Estatus.Resource != null)
                ViewBag.Estatus_Facturass_Estatus = Estatus_Facturass_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_Facturas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_que_autoriza = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_que_autoriza != null && Spartan_Users_Usuario_que_autoriza.Resource != null)
                ViewBag.Spartan_Users_Usuario_que_autoriza = Spartan_Users_Usuario_que_autoriza.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IResultados_de_RevisionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Resultados_de_Revisions_Resultado_de_la_Revision = _IResultados_de_RevisionApiConsumer.SelAll(true);
            if (Resultados_de_Revisions_Resultado_de_la_Revision != null && Resultados_de_Revisions_Resultado_de_la_Revision.Resource != null)
                ViewBag.Resultados_de_Revisions_Resultado_de_la_Revision = Resultados_de_Revisions_Resultado_de_la_Revision.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Resultados_de_Revision", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_que_programa = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_que_programa != null && Spartan_Users_Usuario_que_programa.Resource != null)
                ViewBag.Spartan_Users_Usuario_que_programa = Spartan_Users_Usuario_que_programa.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IEstatus_de_Pago_de_FacturasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_de_Pago_de_Facturass_Estatus_de_Pago = _IEstatus_de_Pago_de_FacturasApiConsumer.SelAll(true);
            if (Estatus_de_Pago_de_Facturass_Estatus_de_Pago != null && Estatus_de_Pago_de_Facturass_Estatus_de_Pago.Resource != null)
                ViewBag.Estatus_de_Pago_de_Facturass_Estatus_de_Pago = Estatus_de_Pago_de_Facturass_Estatus_de_Pago.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Estatus_de_Pago_de_Facturas", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_que_actualiza = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_que_actualiza != null && Spartan_Users_Usuario_que_actualiza.Resource != null)
                ViewBag.Spartan_Users_Usuario_que_actualiza = Spartan_Users_Usuario_que_actualiza.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
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
            _IMesesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Mesess_Mes_Facturado = _IMesesApiConsumer.SelAll(true);
            if (Mesess_Mes_Facturado != null && Mesess_Mes_Facturado.Resource != null)
                ViewBag.Mesess_Mes_Facturado = Mesess_Mes_Facturado.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Meses", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatus_FacturasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_Facturass_Estatus = _IEstatus_FacturasApiConsumer.SelAll(true);
            if (Estatus_Facturass_Estatus != null && Estatus_Facturass_Estatus.Resource != null)
                ViewBag.Estatus_Facturass_Estatus = Estatus_Facturass_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_Facturas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_que_autoriza = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_que_autoriza != null && Spartan_Users_Usuario_que_autoriza.Resource != null)
                ViewBag.Spartan_Users_Usuario_que_autoriza = Spartan_Users_Usuario_que_autoriza.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IResultados_de_RevisionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Resultados_de_Revisions_Resultado_de_la_Revision = _IResultados_de_RevisionApiConsumer.SelAll(true);
            if (Resultados_de_Revisions_Resultado_de_la_Revision != null && Resultados_de_Revisions_Resultado_de_la_Revision.Resource != null)
                ViewBag.Resultados_de_Revisions_Resultado_de_la_Revision = Resultados_de_Revisions_Resultado_de_la_Revision.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Resultados_de_Revision", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_que_programa = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_que_programa != null && Spartan_Users_Usuario_que_programa.Resource != null)
                ViewBag.Spartan_Users_Usuario_que_programa = Spartan_Users_Usuario_que_programa.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IEstatus_de_Pago_de_FacturasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_de_Pago_de_Facturass_Estatus_de_Pago = _IEstatus_de_Pago_de_FacturasApiConsumer.SelAll(true);
            if (Estatus_de_Pago_de_Facturass_Estatus_de_Pago != null && Estatus_de_Pago_de_Facturass_Estatus_de_Pago.Resource != null)
                ViewBag.Estatus_de_Pago_de_Facturass_Estatus_de_Pago = Estatus_de_Pago_de_Facturass_Estatus_de_Pago.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Estatus_de_Pago_de_Facturas", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_que_actualiza = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_que_actualiza != null && Spartan_Users_Usuario_que_actualiza.Resource != null)
                ViewBag.Spartan_Users_Usuario_que_actualiza = Spartan_Users_Usuario_que_actualiza.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();


            var previousFiltersObj = new Solicitud_de_Pago_de_FacturasAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Solicitud_de_Pago_de_FacturasAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Solicitud_de_Pago_de_FacturasAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Solicitud_de_Pago_de_FacturasPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _ISolicitud_de_Pago_de_FacturasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Solicitud_de_Pago_de_Facturass == null)
                result.Solicitud_de_Pago_de_Facturass = new List<Solicitud_de_Pago_de_Facturas>();

            return Json(new
            {
                data = result.Solicitud_de_Pago_de_Facturass.Select(m => new Solicitud_de_Pago_de_FacturasGridModel
                    {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,Mes_FacturadoNombre = CultureHelper.GetTraduction(m.Mes_Facturado_Meses.Clave.ToString(), "Nombre") ?? (string)m.Mes_Facturado_Meses.Nombre
                        ,Fecha_inicio_del_periodo_facturado = (m.Fecha_inicio_del_periodo_facturado == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio_del_periodo_facturado).ToString(ConfigurationProperty.DateFormat))
                        ,Fecha_fin_del_periodo_facturado = (m.Fecha_fin_del_periodo_facturado == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin_del_periodo_facturado).ToString(ConfigurationProperty.DateFormat))
			,Archivo_XML = m.Archivo_XML
			,Archivo_PDF = m.Archivo_PDF
			,Recibo_de_Solicitud_de_Pago = m.Recibo_de_Solicitud_de_Pago
			,Total = m.Total
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_Facturas.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus_Facturas.Descripcion
                        ,Fecha_de_autorizacion = (m.Fecha_de_autorizacion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_autorizacion).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_autorizacion = m.Hora_de_autorizacion
                        ,Usuario_que_autorizaName = CultureHelper.GetTraduction(m.Usuario_que_autoriza_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_autoriza_Spartan_User.Name
                        ,Resultado_de_la_RevisionNombre = CultureHelper.GetTraduction(m.Resultado_de_la_Revision_Resultados_de_Revision.Folio.ToString(), "Nombre") ?? (string)m.Resultado_de_la_Revision_Resultados_de_Revision.Nombre
			,Observaciones = m.Observaciones
                        ,Fecha_de_programacion = (m.Fecha_de_programacion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_programacion).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_programacion = m.Hora_de_programacion
                        ,Usuario_que_programaName = CultureHelper.GetTraduction(m.Usuario_que_programa_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_programa_Spartan_User.Name
                        ,Fecha_programada_de_Pago = (m.Fecha_programada_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_programada_de_Pago).ToString(ConfigurationProperty.DateFormat))
                        ,Estatus_de_PagoNombre = CultureHelper.GetTraduction(m.Estatus_de_Pago_Estatus_de_Pago_de_Facturas.Folio.ToString(), "Nombre") ?? (string)m.Estatus_de_Pago_Estatus_de_Pago_de_Facturas.Nombre
                        ,Fecha_de_actualizacion = (m.Fecha_de_actualizacion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_actualizacion).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_actualizacion = m.Hora_de_actualizacion
                        ,Usuario_que_actualizaName = CultureHelper.GetTraduction(m.Usuario_que_actualiza_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_actualiza_Spartan_User.Name
                        ,Fecha_de_Pago = (m.Fecha_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Pago).ToString(ConfigurationProperty.DateFormat))

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }
		/*
		 [HttpGet]
        public ActionResult GetSolicitud_de_Pago_de_FacturasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISolicitud_de_Pago_de_FacturasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISolicitud_de_Pago_de_FacturasApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraductionNew(Convert.ToString(m.Folio), "Solicitud_de_Pago_de_Facturas", m.),
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
        /// Get List of Solicitud_de_Pago_de_Facturas from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Solicitud_de_Pago_de_Facturas Entity</returns>
        public ActionResult GetSolicitud_de_Pago_de_FacturasList(UrlParametersModel param)
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
            _ISolicitud_de_Pago_de_FacturasApiConsumer.SetAuthHeader(_tokenManager.Token);

          
            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new Solicitud_de_Pago_de_FacturasPropertyMapper());
				
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
				if (Session["AdvanceSearch"].GetType() == typeof(Solicitud_de_Pago_de_FacturasAdvanceSearchModel))
                {
					var advanceFilter =
                    (Solicitud_de_Pago_de_FacturasAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            Solicitud_de_Pago_de_FacturasPropertyMapper oSolicitud_de_Pago_de_FacturasPropertyMapper = new Solicitud_de_Pago_de_FacturasPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                 if (sortColumn != -1)
                    configuration.OrderByClause = oSolicitud_de_Pago_de_FacturasPropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _ISolicitud_de_Pago_de_FacturasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Solicitud_de_Pago_de_Facturass == null)
                result.Solicitud_de_Pago_de_Facturass = new List<Solicitud_de_Pago_de_Facturas>();

            return Json(new
            {
                aaData = result.Solicitud_de_Pago_de_Facturass.Select(m => new Solicitud_de_Pago_de_FacturasGridModel
            {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,Mes_FacturadoNombre = CultureHelper.GetTraduction(m.Mes_Facturado_Meses.Clave.ToString(), "Nombre") ?? (string)m.Mes_Facturado_Meses.Nombre
                        ,Fecha_inicio_del_periodo_facturado = (m.Fecha_inicio_del_periodo_facturado == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio_del_periodo_facturado).ToString(ConfigurationProperty.DateFormat))
                        ,Fecha_fin_del_periodo_facturado = (m.Fecha_fin_del_periodo_facturado == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin_del_periodo_facturado).ToString(ConfigurationProperty.DateFormat))
			,Archivo_XML = m.Archivo_XML
			,Archivo_PDF = m.Archivo_PDF
			,Recibo_de_Solicitud_de_Pago = m.Recibo_de_Solicitud_de_Pago
			,Total = m.Total
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_Facturas.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus_Facturas.Descripcion
                        ,Fecha_de_autorizacion = (m.Fecha_de_autorizacion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_autorizacion).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_autorizacion = m.Hora_de_autorizacion
                        ,Usuario_que_autorizaName = CultureHelper.GetTraduction(m.Usuario_que_autoriza_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_autoriza_Spartan_User.Name
                        ,Resultado_de_la_RevisionNombre = CultureHelper.GetTraduction(m.Resultado_de_la_Revision_Resultados_de_Revision.Folio.ToString(), "Nombre") ?? (string)m.Resultado_de_la_Revision_Resultados_de_Revision.Nombre
			,Observaciones = m.Observaciones
                        ,Fecha_de_programacion = (m.Fecha_de_programacion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_programacion).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_programacion = m.Hora_de_programacion
                        ,Usuario_que_programaName = CultureHelper.GetTraduction(m.Usuario_que_programa_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_programa_Spartan_User.Name
                        ,Fecha_programada_de_Pago = (m.Fecha_programada_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_programada_de_Pago).ToString(ConfigurationProperty.DateFormat))
                        ,Estatus_de_PagoNombre = CultureHelper.GetTraduction(m.Estatus_de_Pago_Estatus_de_Pago_de_Facturas.Folio.ToString(), "Nombre") ?? (string)m.Estatus_de_Pago_Estatus_de_Pago_de_Facturas.Nombre
                        ,Fecha_de_actualizacion = (m.Fecha_de_actualizacion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_actualizacion).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_actualizacion = m.Hora_de_actualizacion
                        ,Usuario_que_actualizaName = CultureHelper.GetTraduction(m.Usuario_que_actualiza_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_actualiza_Spartan_User.Name
                        ,Fecha_de_Pago = (m.Fecha_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Pago).ToString(ConfigurationProperty.DateFormat))

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }







        [NonAction]
        public string GetAdvanceFilter(Solicitud_de_Pago_de_FacturasAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromFolio) || !string.IsNullOrEmpty(filter.ToFolio))
            {
                if (!string.IsNullOrEmpty(filter.FromFolio))
                    where += " AND Solicitud_de_Pago_de_Facturas.Folio >= " + filter.FromFolio;
                if (!string.IsNullOrEmpty(filter.ToFolio))
                    where += " AND Solicitud_de_Pago_de_Facturas.Folio <= " + filter.ToFolio;
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro) || !string.IsNullOrEmpty(filter.ToFecha_de_Registro))
            {
                var Fecha_de_RegistroFrom = DateTime.ParseExact(filter.FromFecha_de_Registro, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_de_RegistroTo = DateTime.ParseExact(filter.ToFecha_de_Registro, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro))
                    where += " AND Solicitud_de_Pago_de_Facturas.Fecha_de_Registro >= '" + Fecha_de_RegistroFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_Registro))
                    where += " AND Solicitud_de_Pago_de_Facturas.Fecha_de_Registro <= '" + Fecha_de_RegistroTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromHora_de_Registro) || !string.IsNullOrEmpty(filter.ToHora_de_Registro))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_de_Registro))
                    where += " AND Convert(TIME,Solicitud_de_Pago_de_Facturas.Hora_de_Registro) >='" + filter.FromHora_de_Registro + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_de_Registro))
                    where += " AND Convert(TIME,Solicitud_de_Pago_de_Facturas.Hora_de_Registro) <='" + filter.ToHora_de_Registro + "'";
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

                where += " AND Solicitud_de_Pago_de_Facturas.Usuario_que_Registra In (" + Usuario_que_RegistraIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceMes_Facturado))
            {
                switch (filter.Mes_FacturadoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Meses.Nombre LIKE '" + filter.AdvanceMes_Facturado + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Meses.Nombre LIKE '%" + filter.AdvanceMes_Facturado + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Meses.Nombre = '" + filter.AdvanceMes_Facturado + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Meses.Nombre LIKE '%" + filter.AdvanceMes_Facturado + "%'";
                        break;
                }
            }
            else if (filter.AdvanceMes_FacturadoMultiple != null && filter.AdvanceMes_FacturadoMultiple.Count() > 0)
            {
                var Mes_FacturadoIds = string.Join(",", filter.AdvanceMes_FacturadoMultiple);

                where += " AND Solicitud_de_Pago_de_Facturas.Mes_Facturado In (" + Mes_FacturadoIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_inicio_del_periodo_facturado) || !string.IsNullOrEmpty(filter.ToFecha_inicio_del_periodo_facturado))
            {
                var Fecha_inicio_del_periodo_facturadoFrom = DateTime.ParseExact(filter.FromFecha_inicio_del_periodo_facturado, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_inicio_del_periodo_facturadoTo = DateTime.ParseExact(filter.ToFecha_inicio_del_periodo_facturado, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_inicio_del_periodo_facturado))
                    where += " AND Solicitud_de_Pago_de_Facturas.Fecha_inicio_del_periodo_facturado >= '" + Fecha_inicio_del_periodo_facturadoFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_inicio_del_periodo_facturado))
                    where += " AND Solicitud_de_Pago_de_Facturas.Fecha_inicio_del_periodo_facturado <= '" + Fecha_inicio_del_periodo_facturadoTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_fin_del_periodo_facturado) || !string.IsNullOrEmpty(filter.ToFecha_fin_del_periodo_facturado))
            {
                var Fecha_fin_del_periodo_facturadoFrom = DateTime.ParseExact(filter.FromFecha_fin_del_periodo_facturado, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_fin_del_periodo_facturadoTo = DateTime.ParseExact(filter.ToFecha_fin_del_periodo_facturado, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_fin_del_periodo_facturado))
                    where += " AND Solicitud_de_Pago_de_Facturas.Fecha_fin_del_periodo_facturado >= '" + Fecha_fin_del_periodo_facturadoFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_fin_del_periodo_facturado))
                    where += " AND Solicitud_de_Pago_de_Facturas.Fecha_fin_del_periodo_facturado <= '" + Fecha_fin_del_periodo_facturadoTo.ToString("MM-dd-yyyy") + "'";
            }

            if (filter.Archivo_XML != RadioOptions.NoApply)
                where += " AND Solicitud_de_Pago_de_Facturas.Archivo_XML " + (filter.Archivo_XML == RadioOptions.Yes ? ">" : "==") + " 0";

            if (filter.Archivo_PDF != RadioOptions.NoApply)
                where += " AND Solicitud_de_Pago_de_Facturas.Archivo_PDF " + (filter.Archivo_PDF == RadioOptions.Yes ? ">" : "==") + " 0";

            if (filter.Recibo_de_Solicitud_de_Pago != RadioOptions.NoApply)
                where += " AND Solicitud_de_Pago_de_Facturas.Recibo_de_Solicitud_de_Pago " + (filter.Recibo_de_Solicitud_de_Pago == RadioOptions.Yes ? ">" : "==") + " 0";

            if (!string.IsNullOrEmpty(filter.FromTotal) || !string.IsNullOrEmpty(filter.ToTotal))
            {
                if (!string.IsNullOrEmpty(filter.FromTotal))
                    where += " AND Solicitud_de_Pago_de_Facturas.Total >= " + filter.FromTotal;
                if (!string.IsNullOrEmpty(filter.ToTotal))
                    where += " AND Solicitud_de_Pago_de_Facturas.Total <= " + filter.ToTotal;
            }

            if (!string.IsNullOrEmpty(filter.AdvanceEstatus))
            {
                switch (filter.EstatusFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Estatus_Facturas.Descripcion LIKE '" + filter.AdvanceEstatus + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Estatus_Facturas.Descripcion LIKE '%" + filter.AdvanceEstatus + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Estatus_Facturas.Descripcion = '" + filter.AdvanceEstatus + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Estatus_Facturas.Descripcion LIKE '%" + filter.AdvanceEstatus + "%'";
                        break;
                }
            }
            else if (filter.AdvanceEstatusMultiple != null && filter.AdvanceEstatusMultiple.Count() > 0)
            {
                var EstatusIds = string.Join(",", filter.AdvanceEstatusMultiple);

                where += " AND Solicitud_de_Pago_de_Facturas.Estatus In (" + EstatusIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_de_autorizacion) || !string.IsNullOrEmpty(filter.ToFecha_de_autorizacion))
            {
                var Fecha_de_autorizacionFrom = DateTime.ParseExact(filter.FromFecha_de_autorizacion, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_de_autorizacionTo = DateTime.ParseExact(filter.ToFecha_de_autorizacion, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_de_autorizacion))
                    where += " AND Solicitud_de_Pago_de_Facturas.Fecha_de_autorizacion >= '" + Fecha_de_autorizacionFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_autorizacion))
                    where += " AND Solicitud_de_Pago_de_Facturas.Fecha_de_autorizacion <= '" + Fecha_de_autorizacionTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromHora_de_autorizacion) || !string.IsNullOrEmpty(filter.ToHora_de_autorizacion))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_de_autorizacion))
                    where += " AND Convert(TIME,Solicitud_de_Pago_de_Facturas.Hora_de_autorizacion) >='" + filter.FromHora_de_autorizacion + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_de_autorizacion))
                    where += " AND Convert(TIME,Solicitud_de_Pago_de_Facturas.Hora_de_autorizacion) <='" + filter.ToHora_de_autorizacion + "'";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceUsuario_que_autoriza))
            {
                switch (filter.Usuario_que_autorizaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_User.Name LIKE '" + filter.AdvanceUsuario_que_autoriza + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceUsuario_que_autoriza + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_User.Name = '" + filter.AdvanceUsuario_que_autoriza + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceUsuario_que_autoriza + "%'";
                        break;
                }
            }
            else if (filter.AdvanceUsuario_que_autorizaMultiple != null && filter.AdvanceUsuario_que_autorizaMultiple.Count() > 0)
            {
                var Usuario_que_autorizaIds = string.Join(",", filter.AdvanceUsuario_que_autorizaMultiple);

                where += " AND Solicitud_de_Pago_de_Facturas.Usuario_que_autoriza In (" + Usuario_que_autorizaIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceResultado_de_la_Revision))
            {
                switch (filter.Resultado_de_la_RevisionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Resultados_de_Revision.Nombre LIKE '" + filter.AdvanceResultado_de_la_Revision + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Resultados_de_Revision.Nombre LIKE '%" + filter.AdvanceResultado_de_la_Revision + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Resultados_de_Revision.Nombre = '" + filter.AdvanceResultado_de_la_Revision + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Resultados_de_Revision.Nombre LIKE '%" + filter.AdvanceResultado_de_la_Revision + "%'";
                        break;
                }
            }
            else if (filter.AdvanceResultado_de_la_RevisionMultiple != null && filter.AdvanceResultado_de_la_RevisionMultiple.Count() > 0)
            {
                var Resultado_de_la_RevisionIds = string.Join(",", filter.AdvanceResultado_de_la_RevisionMultiple);

                where += " AND Solicitud_de_Pago_de_Facturas.Resultado_de_la_Revision In (" + Resultado_de_la_RevisionIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Observaciones))
            {
                switch (filter.ObservacionesFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Solicitud_de_Pago_de_Facturas.Observaciones LIKE '" + filter.Observaciones + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Solicitud_de_Pago_de_Facturas.Observaciones LIKE '%" + filter.Observaciones + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Solicitud_de_Pago_de_Facturas.Observaciones = '" + filter.Observaciones + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Solicitud_de_Pago_de_Facturas.Observaciones LIKE '%" + filter.Observaciones + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_de_programacion) || !string.IsNullOrEmpty(filter.ToFecha_de_programacion))
            {
                var Fecha_de_programacionFrom = DateTime.ParseExact(filter.FromFecha_de_programacion, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_de_programacionTo = DateTime.ParseExact(filter.ToFecha_de_programacion, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_de_programacion))
                    where += " AND Solicitud_de_Pago_de_Facturas.Fecha_de_programacion >= '" + Fecha_de_programacionFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_programacion))
                    where += " AND Solicitud_de_Pago_de_Facturas.Fecha_de_programacion <= '" + Fecha_de_programacionTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromHora_de_programacion) || !string.IsNullOrEmpty(filter.ToHora_de_programacion))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_de_programacion))
                    where += " AND Convert(TIME,Solicitud_de_Pago_de_Facturas.Hora_de_programacion) >='" + filter.FromHora_de_programacion + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_de_programacion))
                    where += " AND Convert(TIME,Solicitud_de_Pago_de_Facturas.Hora_de_programacion) <='" + filter.ToHora_de_programacion + "'";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceUsuario_que_programa))
            {
                switch (filter.Usuario_que_programaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_User.Name LIKE '" + filter.AdvanceUsuario_que_programa + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceUsuario_que_programa + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_User.Name = '" + filter.AdvanceUsuario_que_programa + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceUsuario_que_programa + "%'";
                        break;
                }
            }
            else if (filter.AdvanceUsuario_que_programaMultiple != null && filter.AdvanceUsuario_que_programaMultiple.Count() > 0)
            {
                var Usuario_que_programaIds = string.Join(",", filter.AdvanceUsuario_que_programaMultiple);

                where += " AND Solicitud_de_Pago_de_Facturas.Usuario_que_programa In (" + Usuario_que_programaIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_programada_de_Pago) || !string.IsNullOrEmpty(filter.ToFecha_programada_de_Pago))
            {
                var Fecha_programada_de_PagoFrom = DateTime.ParseExact(filter.FromFecha_programada_de_Pago, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_programada_de_PagoTo = DateTime.ParseExact(filter.ToFecha_programada_de_Pago, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_programada_de_Pago))
                    where += " AND Solicitud_de_Pago_de_Facturas.Fecha_programada_de_Pago >= '" + Fecha_programada_de_PagoFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_programada_de_Pago))
                    where += " AND Solicitud_de_Pago_de_Facturas.Fecha_programada_de_Pago <= '" + Fecha_programada_de_PagoTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceEstatus_de_Pago))
            {
                switch (filter.Estatus_de_PagoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Estatus_de_Pago_de_Facturas.Nombre LIKE '" + filter.AdvanceEstatus_de_Pago + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Estatus_de_Pago_de_Facturas.Nombre LIKE '%" + filter.AdvanceEstatus_de_Pago + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Estatus_de_Pago_de_Facturas.Nombre = '" + filter.AdvanceEstatus_de_Pago + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Estatus_de_Pago_de_Facturas.Nombre LIKE '%" + filter.AdvanceEstatus_de_Pago + "%'";
                        break;
                }
            }
            else if (filter.AdvanceEstatus_de_PagoMultiple != null && filter.AdvanceEstatus_de_PagoMultiple.Count() > 0)
            {
                var Estatus_de_PagoIds = string.Join(",", filter.AdvanceEstatus_de_PagoMultiple);

                where += " AND Solicitud_de_Pago_de_Facturas.Estatus_de_Pago In (" + Estatus_de_PagoIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_de_actualizacion) || !string.IsNullOrEmpty(filter.ToFecha_de_actualizacion))
            {
                var Fecha_de_actualizacionFrom = DateTime.ParseExact(filter.FromFecha_de_actualizacion, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_de_actualizacionTo = DateTime.ParseExact(filter.ToFecha_de_actualizacion, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_de_actualizacion))
                    where += " AND Solicitud_de_Pago_de_Facturas.Fecha_de_actualizacion >= '" + Fecha_de_actualizacionFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_actualizacion))
                    where += " AND Solicitud_de_Pago_de_Facturas.Fecha_de_actualizacion <= '" + Fecha_de_actualizacionTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromHora_de_actualizacion) || !string.IsNullOrEmpty(filter.ToHora_de_actualizacion))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_de_actualizacion))
                    where += " AND Convert(TIME,Solicitud_de_Pago_de_Facturas.Hora_de_actualizacion) >='" + filter.FromHora_de_actualizacion + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_de_actualizacion))
                    where += " AND Convert(TIME,Solicitud_de_Pago_de_Facturas.Hora_de_actualizacion) <='" + filter.ToHora_de_actualizacion + "'";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceUsuario_que_actualiza))
            {
                switch (filter.Usuario_que_actualizaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_User.Name LIKE '" + filter.AdvanceUsuario_que_actualiza + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceUsuario_que_actualiza + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_User.Name = '" + filter.AdvanceUsuario_que_actualiza + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceUsuario_que_actualiza + "%'";
                        break;
                }
            }
            else if (filter.AdvanceUsuario_que_actualizaMultiple != null && filter.AdvanceUsuario_que_actualizaMultiple.Count() > 0)
            {
                var Usuario_que_actualizaIds = string.Join(",", filter.AdvanceUsuario_que_actualizaMultiple);

                where += " AND Solicitud_de_Pago_de_Facturas.Usuario_que_actualiza In (" + Usuario_que_actualizaIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_de_Pago) || !string.IsNullOrEmpty(filter.ToFecha_de_Pago))
            {
                var Fecha_de_PagoFrom = DateTime.ParseExact(filter.FromFecha_de_Pago, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_de_PagoTo = DateTime.ParseExact(filter.ToFecha_de_Pago, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_de_Pago))
                    where += " AND Solicitud_de_Pago_de_Facturas.Fecha_de_Pago >= '" + Fecha_de_PagoFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_Pago))
                    where += " AND Solicitud_de_Pago_de_Facturas.Fecha_de_Pago <= '" + Fecha_de_PagoTo.ToString("MM-dd-yyyy") + "'";
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
                _ISolicitud_de_Pago_de_FacturasApiConsumer.SetAuthHeader(_tokenManager.Token);

                Solicitud_de_Pago_de_Facturas varSolicitud_de_Pago_de_Facturas = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _ISolicitud_de_Pago_de_FacturasApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Solicitud_de_Pago_de_FacturasModel varSolicitud_de_Pago_de_Facturas)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _ISolicitud_de_Pago_de_FacturasApiConsumer.SetAuthHeader(_tokenManager.Token);


                    if (varSolicitud_de_Pago_de_Facturas.Archivo_XMLRemoveAttachment != 0 && varSolicitud_de_Pago_de_Facturas.Archivo_XMLFile == null)
                    {
                        varSolicitud_de_Pago_de_Facturas.Archivo_XML = 0;
                    }

                    if (varSolicitud_de_Pago_de_Facturas.Archivo_XMLFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varSolicitud_de_Pago_de_Facturas.Archivo_XMLFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varSolicitud_de_Pago_de_Facturas.Archivo_XML = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varSolicitud_de_Pago_de_Facturas.Archivo_XMLFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }
                    if (varSolicitud_de_Pago_de_Facturas.Archivo_PDFRemoveAttachment != 0 && varSolicitud_de_Pago_de_Facturas.Archivo_PDFFile == null)
                    {
                        varSolicitud_de_Pago_de_Facturas.Archivo_PDF = 0;
                    }

                    if (varSolicitud_de_Pago_de_Facturas.Archivo_PDFFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varSolicitud_de_Pago_de_Facturas.Archivo_PDFFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varSolicitud_de_Pago_de_Facturas.Archivo_PDF = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varSolicitud_de_Pago_de_Facturas.Archivo_PDFFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }
                    if (varSolicitud_de_Pago_de_Facturas.Recibo_de_Solicitud_de_PagoRemoveAttachment != 0 && varSolicitud_de_Pago_de_Facturas.Recibo_de_Solicitud_de_PagoFile == null)
                    {
                        varSolicitud_de_Pago_de_Facturas.Recibo_de_Solicitud_de_Pago = 0;
                    }

                    if (varSolicitud_de_Pago_de_Facturas.Recibo_de_Solicitud_de_PagoFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varSolicitud_de_Pago_de_Facturas.Recibo_de_Solicitud_de_PagoFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varSolicitud_de_Pago_de_Facturas.Recibo_de_Solicitud_de_Pago = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varSolicitud_de_Pago_de_Facturas.Recibo_de_Solicitud_de_PagoFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }

                    
                    var result = "";
                    var Solicitud_de_Pago_de_FacturasInfo = new Solicitud_de_Pago_de_Facturas
                    {
                        Folio = varSolicitud_de_Pago_de_Facturas.Folio
                        ,Fecha_de_Registro = (!String.IsNullOrEmpty(varSolicitud_de_Pago_de_Facturas.Fecha_de_Registro)) ? DateTime.ParseExact(varSolicitud_de_Pago_de_Facturas.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varSolicitud_de_Pago_de_Facturas.Hora_de_Registro
                        ,Usuario_que_Registra = varSolicitud_de_Pago_de_Facturas.Usuario_que_Registra
                        ,Mes_Facturado = varSolicitud_de_Pago_de_Facturas.Mes_Facturado
                        ,Fecha_inicio_del_periodo_facturado = (!String.IsNullOrEmpty(varSolicitud_de_Pago_de_Facturas.Fecha_inicio_del_periodo_facturado)) ? DateTime.ParseExact(varSolicitud_de_Pago_de_Facturas.Fecha_inicio_del_periodo_facturado, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Fecha_fin_del_periodo_facturado = (!String.IsNullOrEmpty(varSolicitud_de_Pago_de_Facturas.Fecha_fin_del_periodo_facturado)) ? DateTime.ParseExact(varSolicitud_de_Pago_de_Facturas.Fecha_fin_del_periodo_facturado, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Archivo_XML = (varSolicitud_de_Pago_de_Facturas.Archivo_XML.HasValue && varSolicitud_de_Pago_de_Facturas.Archivo_XML != 0) ? ((int?)Convert.ToInt32(varSolicitud_de_Pago_de_Facturas.Archivo_XML.Value)) : null

                        ,Archivo_PDF = (varSolicitud_de_Pago_de_Facturas.Archivo_PDF.HasValue && varSolicitud_de_Pago_de_Facturas.Archivo_PDF != 0) ? ((int?)Convert.ToInt32(varSolicitud_de_Pago_de_Facturas.Archivo_PDF.Value)) : null

                        ,Recibo_de_Solicitud_de_Pago = (varSolicitud_de_Pago_de_Facturas.Recibo_de_Solicitud_de_Pago.HasValue && varSolicitud_de_Pago_de_Facturas.Recibo_de_Solicitud_de_Pago != 0) ? ((int?)Convert.ToInt32(varSolicitud_de_Pago_de_Facturas.Recibo_de_Solicitud_de_Pago.Value)) : null

                        ,Total = varSolicitud_de_Pago_de_Facturas.Total
                        ,Estatus = varSolicitud_de_Pago_de_Facturas.Estatus
                        ,Fecha_de_autorizacion = (!String.IsNullOrEmpty(varSolicitud_de_Pago_de_Facturas.Fecha_de_autorizacion)) ? DateTime.ParseExact(varSolicitud_de_Pago_de_Facturas.Fecha_de_autorizacion, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_autorizacion = varSolicitud_de_Pago_de_Facturas.Hora_de_autorizacion
                        ,Usuario_que_autoriza = varSolicitud_de_Pago_de_Facturas.Usuario_que_autoriza
                        ,Resultado_de_la_Revision = varSolicitud_de_Pago_de_Facturas.Resultado_de_la_Revision
                        ,Observaciones = varSolicitud_de_Pago_de_Facturas.Observaciones
                        ,Fecha_de_programacion = (!String.IsNullOrEmpty(varSolicitud_de_Pago_de_Facturas.Fecha_de_programacion)) ? DateTime.ParseExact(varSolicitud_de_Pago_de_Facturas.Fecha_de_programacion, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_programacion = varSolicitud_de_Pago_de_Facturas.Hora_de_programacion
                        ,Usuario_que_programa = varSolicitud_de_Pago_de_Facturas.Usuario_que_programa
                        ,Fecha_programada_de_Pago = (!String.IsNullOrEmpty(varSolicitud_de_Pago_de_Facturas.Fecha_programada_de_Pago)) ? DateTime.ParseExact(varSolicitud_de_Pago_de_Facturas.Fecha_programada_de_Pago, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Estatus_de_Pago = varSolicitud_de_Pago_de_Facturas.Estatus_de_Pago
                        ,Fecha_de_actualizacion = (!String.IsNullOrEmpty(varSolicitud_de_Pago_de_Facturas.Fecha_de_actualizacion)) ? DateTime.ParseExact(varSolicitud_de_Pago_de_Facturas.Fecha_de_actualizacion, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_actualizacion = varSolicitud_de_Pago_de_Facturas.Hora_de_actualizacion
                        ,Usuario_que_actualiza = varSolicitud_de_Pago_de_Facturas.Usuario_que_actualiza
                        ,Fecha_de_Pago = (!String.IsNullOrEmpty(varSolicitud_de_Pago_de_Facturas.Fecha_de_Pago)) ? DateTime.ParseExact(varSolicitud_de_Pago_de_Facturas.Fecha_de_Pago, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null

                    };

                    result = !IsNew ?
                        _ISolicitud_de_Pago_de_FacturasApiConsumer.Update(Solicitud_de_Pago_de_FacturasInfo, null, null).Resource.ToString() :
                         _ISolicitud_de_Pago_de_FacturasApiConsumer.Insert(Solicitud_de_Pago_de_FacturasInfo, null, null).Resource.ToString();
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
        /// Write Element Array of Solicitud_de_Pago_de_Facturas script
        /// </summary>
        /// <param name="oSolicitud_de_Pago_de_FacturasElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew Solicitud_de_Pago_de_FacturasModuleAttributeList)
        {
            for (int i = 0; i < Solicitud_de_Pago_de_FacturasModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Solicitud_de_Pago_de_FacturasModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Solicitud_de_Pago_de_FacturasModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Solicitud_de_Pago_de_FacturasModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Solicitud_de_Pago_de_FacturasModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Solicitud_de_Pago_de_FacturasModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Solicitud_de_Pago_de_FacturasModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < Solicitud_de_Pago_de_FacturasModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(Solicitud_de_Pago_de_FacturasModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							Solicitud_de_Pago_de_FacturasModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(Solicitud_de_Pago_de_FacturasModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							Solicitud_de_Pago_de_FacturasModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strSolicitud_de_Pago_de_FacturasScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Solicitud_de_Pago_de_Facturas.js")))
            {
                strSolicitud_de_Pago_de_FacturasScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Solicitud_de_Pago_de_Facturas element attributes
            string userChangeJson = jsSerialize.Serialize(Solicitud_de_Pago_de_FacturasModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strSolicitud_de_Pago_de_FacturasScript.IndexOf("inpuElementArray");
            string splittedString = strSolicitud_de_Pago_de_FacturasScript.Substring(indexOfArray, strSolicitud_de_Pago_de_FacturasScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Solicitud_de_Pago_de_FacturasModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Solicitud_de_Pago_de_FacturasModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strSolicitud_de_Pago_de_FacturasScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strSolicitud_de_Pago_de_FacturasScript.Substring(indexOfArrayHistory, strSolicitud_de_Pago_de_FacturasScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strSolicitud_de_Pago_de_FacturasScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strSolicitud_de_Pago_de_FacturasScript.Substring(endIndexOfMainElement + indexOfArray, strSolicitud_de_Pago_de_FacturasScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (Solicitud_de_Pago_de_FacturasModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in Solicitud_de_Pago_de_FacturasModuleAttributeList.ChildModuleAttributeList)
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
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Solicitud_de_Pago_de_Facturas.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Solicitud_de_Pago_de_Facturas.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Solicitud_de_Pago_de_Facturas.js")))
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
        public ActionResult Solicitud_de_Pago_de_FacturasPropertyBag()
        {
            return PartialView("Solicitud_de_Pago_de_FacturasPropertyBag", "Solicitud_de_Pago_de_Facturas");
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
                var whereClauseFormat = "Object = 44742 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _ISolicitud_de_Pago_de_FacturasApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Solicitud_de_Pago_de_Facturas.Folio= " + RecordId;
                            var result = _ISolicitud_de_Pago_de_FacturasApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
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

            _ISolicitud_de_Pago_de_FacturasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Solicitud_de_Pago_de_FacturasPropertyMapper());
			
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
                    (Solicitud_de_Pago_de_FacturasAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
			string sortDirection = "asc";

            Solicitud_de_Pago_de_FacturasPropertyMapper oSolicitud_de_Pago_de_FacturasPropertyMapper = new Solicitud_de_Pago_de_FacturasPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oSolicitud_de_Pago_de_FacturasPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISolicitud_de_Pago_de_FacturasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Solicitud_de_Pago_de_Facturass == null)
                result.Solicitud_de_Pago_de_Facturass = new List<Solicitud_de_Pago_de_Facturas>();

            var data = result.Solicitud_de_Pago_de_Facturass.Select(m => new Solicitud_de_Pago_de_FacturasGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,Mes_FacturadoNombre = CultureHelper.GetTraduction(m.Mes_Facturado_Meses.Clave.ToString(), "Nombre") ?? (string)m.Mes_Facturado_Meses.Nombre
                        ,Fecha_inicio_del_periodo_facturado = (m.Fecha_inicio_del_periodo_facturado == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio_del_periodo_facturado).ToString(ConfigurationProperty.DateFormat))
                        ,Fecha_fin_del_periodo_facturado = (m.Fecha_fin_del_periodo_facturado == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin_del_periodo_facturado).ToString(ConfigurationProperty.DateFormat))
			,Archivo_XML = m.Archivo_XML
			,Archivo_PDF = m.Archivo_PDF
			,Recibo_de_Solicitud_de_Pago = m.Recibo_de_Solicitud_de_Pago
			,Total = m.Total
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_Facturas.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus_Facturas.Descripcion
                        ,Fecha_de_autorizacion = (m.Fecha_de_autorizacion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_autorizacion).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_autorizacion = m.Hora_de_autorizacion
                        ,Usuario_que_autorizaName = CultureHelper.GetTraduction(m.Usuario_que_autoriza_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_autoriza_Spartan_User.Name
                        ,Resultado_de_la_RevisionNombre = CultureHelper.GetTraduction(m.Resultado_de_la_Revision_Resultados_de_Revision.Folio.ToString(), "Nombre") ?? (string)m.Resultado_de_la_Revision_Resultados_de_Revision.Nombre
			,Observaciones = m.Observaciones
                        ,Fecha_de_programacion = (m.Fecha_de_programacion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_programacion).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_programacion = m.Hora_de_programacion
                        ,Usuario_que_programaName = CultureHelper.GetTraduction(m.Usuario_que_programa_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_programa_Spartan_User.Name
                        ,Fecha_programada_de_Pago = (m.Fecha_programada_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_programada_de_Pago).ToString(ConfigurationProperty.DateFormat))
                        ,Estatus_de_PagoNombre = CultureHelper.GetTraduction(m.Estatus_de_Pago_Estatus_de_Pago_de_Facturas.Folio.ToString(), "Nombre") ?? (string)m.Estatus_de_Pago_Estatus_de_Pago_de_Facturas.Nombre
                        ,Fecha_de_actualizacion = (m.Fecha_de_actualizacion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_actualizacion).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_actualizacion = m.Hora_de_actualizacion
                        ,Usuario_que_actualizaName = CultureHelper.GetTraduction(m.Usuario_que_actualiza_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_actualiza_Spartan_User.Name
                        ,Fecha_de_Pago = (m.Fecha_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Pago).ToString(ConfigurationProperty.DateFormat))

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(44742, arrayColumnsVisible), "Solicitud_de_Pago_de_FacturasList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(44742, arrayColumnsVisible), "Solicitud_de_Pago_de_FacturasList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(44742, arrayColumnsVisible), "Solicitud_de_Pago_de_FacturasList_" + DateTime.Now.ToString());
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

            _ISolicitud_de_Pago_de_FacturasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Solicitud_de_Pago_de_FacturasPropertyMapper());
				
				
            if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
			if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (Solicitud_de_Pago_de_FacturasAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            Solicitud_de_Pago_de_FacturasPropertyMapper oSolicitud_de_Pago_de_FacturasPropertyMapper = new Solicitud_de_Pago_de_FacturasPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oSolicitud_de_Pago_de_FacturasPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
			
			if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISolicitud_de_Pago_de_FacturasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Solicitud_de_Pago_de_Facturass == null)
                result.Solicitud_de_Pago_de_Facturass = new List<Solicitud_de_Pago_de_Facturas>();

            var data = result.Solicitud_de_Pago_de_Facturass.Select(m => new Solicitud_de_Pago_de_FacturasGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,Mes_FacturadoNombre = CultureHelper.GetTraduction(m.Mes_Facturado_Meses.Clave.ToString(), "Nombre") ?? (string)m.Mes_Facturado_Meses.Nombre
                        ,Fecha_inicio_del_periodo_facturado = (m.Fecha_inicio_del_periodo_facturado == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio_del_periodo_facturado).ToString(ConfigurationProperty.DateFormat))
                        ,Fecha_fin_del_periodo_facturado = (m.Fecha_fin_del_periodo_facturado == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin_del_periodo_facturado).ToString(ConfigurationProperty.DateFormat))
			,Archivo_XML = m.Archivo_XML
			,Archivo_PDF = m.Archivo_PDF
			,Recibo_de_Solicitud_de_Pago = m.Recibo_de_Solicitud_de_Pago
			,Total = m.Total
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_Facturas.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus_Facturas.Descripcion
                        ,Fecha_de_autorizacion = (m.Fecha_de_autorizacion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_autorizacion).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_autorizacion = m.Hora_de_autorizacion
                        ,Usuario_que_autorizaName = CultureHelper.GetTraduction(m.Usuario_que_autoriza_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_autoriza_Spartan_User.Name
                        ,Resultado_de_la_RevisionNombre = CultureHelper.GetTraduction(m.Resultado_de_la_Revision_Resultados_de_Revision.Folio.ToString(), "Nombre") ?? (string)m.Resultado_de_la_Revision_Resultados_de_Revision.Nombre
			,Observaciones = m.Observaciones
                        ,Fecha_de_programacion = (m.Fecha_de_programacion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_programacion).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_programacion = m.Hora_de_programacion
                        ,Usuario_que_programaName = CultureHelper.GetTraduction(m.Usuario_que_programa_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_programa_Spartan_User.Name
                        ,Fecha_programada_de_Pago = (m.Fecha_programada_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_programada_de_Pago).ToString(ConfigurationProperty.DateFormat))
                        ,Estatus_de_PagoNombre = CultureHelper.GetTraduction(m.Estatus_de_Pago_Estatus_de_Pago_de_Facturas.Folio.ToString(), "Nombre") ?? (string)m.Estatus_de_Pago_Estatus_de_Pago_de_Facturas.Nombre
                        ,Fecha_de_actualizacion = (m.Fecha_de_actualizacion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_actualizacion).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_actualizacion = m.Hora_de_actualizacion
                        ,Usuario_que_actualizaName = CultureHelper.GetTraduction(m.Usuario_que_actualiza_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_actualiza_Spartan_User.Name
                        ,Fecha_de_Pago = (m.Fecha_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Pago).ToString(ConfigurationProperty.DateFormat))

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
                _ISolicitud_de_Pago_de_FacturasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISolicitud_de_Pago_de_FacturasApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpPost]
        public ActionResult Post_Datos_Generales(Solicitud_de_Pago_de_Facturas_Datos_GeneralesModel varSolicitud_de_Pago_de_Facturas)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISolicitud_de_Pago_de_FacturasApiConsumer.SetAuthHeader(_tokenManager.Token);
				                    if (varSolicitud_de_Pago_de_Facturas.Archivo_XMLRemoveAttachment != 0 && varSolicitud_de_Pago_de_Facturas.Archivo_XMLFile == null)
                    {
                        varSolicitud_de_Pago_de_Facturas.Archivo_XML = 0;
                    }

                    if (varSolicitud_de_Pago_de_Facturas.Archivo_XMLFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varSolicitud_de_Pago_de_Facturas.Archivo_XMLFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varSolicitud_de_Pago_de_Facturas.Archivo_XML = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varSolicitud_de_Pago_de_Facturas.Archivo_XMLFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }
                    if (varSolicitud_de_Pago_de_Facturas.Archivo_PDFRemoveAttachment != 0 && varSolicitud_de_Pago_de_Facturas.Archivo_PDFFile == null)
                    {
                        varSolicitud_de_Pago_de_Facturas.Archivo_PDF = 0;
                    }

                    if (varSolicitud_de_Pago_de_Facturas.Archivo_PDFFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varSolicitud_de_Pago_de_Facturas.Archivo_PDFFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varSolicitud_de_Pago_de_Facturas.Archivo_PDF = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varSolicitud_de_Pago_de_Facturas.Archivo_PDFFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }
                    if (varSolicitud_de_Pago_de_Facturas.Recibo_de_Solicitud_de_PagoRemoveAttachment != 0 && varSolicitud_de_Pago_de_Facturas.Recibo_de_Solicitud_de_PagoFile == null)
                    {
                        varSolicitud_de_Pago_de_Facturas.Recibo_de_Solicitud_de_Pago = 0;
                    }

                    if (varSolicitud_de_Pago_de_Facturas.Recibo_de_Solicitud_de_PagoFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varSolicitud_de_Pago_de_Facturas.Recibo_de_Solicitud_de_PagoFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varSolicitud_de_Pago_de_Facturas.Recibo_de_Solicitud_de_Pago = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varSolicitud_de_Pago_de_Facturas.Recibo_de_Solicitud_de_PagoFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }

                var result = "";
                var Solicitud_de_Pago_de_Facturas_Datos_GeneralesInfo = new Solicitud_de_Pago_de_Facturas_Datos_Generales
                {
                    Folio = varSolicitud_de_Pago_de_Facturas.Folio
                                            ,Fecha_de_Registro = (!String.IsNullOrEmpty(varSolicitud_de_Pago_de_Facturas.Fecha_de_Registro)) ? DateTime.ParseExact(varSolicitud_de_Pago_de_Facturas.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varSolicitud_de_Pago_de_Facturas.Hora_de_Registro
                        ,Usuario_que_Registra = varSolicitud_de_Pago_de_Facturas.Usuario_que_Registra
                        ,Mes_Facturado = varSolicitud_de_Pago_de_Facturas.Mes_Facturado
                        ,Fecha_inicio_del_periodo_facturado = (!String.IsNullOrEmpty(varSolicitud_de_Pago_de_Facturas.Fecha_inicio_del_periodo_facturado)) ? DateTime.ParseExact(varSolicitud_de_Pago_de_Facturas.Fecha_inicio_del_periodo_facturado, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Fecha_fin_del_periodo_facturado = (!String.IsNullOrEmpty(varSolicitud_de_Pago_de_Facturas.Fecha_fin_del_periodo_facturado)) ? DateTime.ParseExact(varSolicitud_de_Pago_de_Facturas.Fecha_fin_del_periodo_facturado, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Archivo_XML = (varSolicitud_de_Pago_de_Facturas.Archivo_XML.HasValue && varSolicitud_de_Pago_de_Facturas.Archivo_XML != 0) ? ((int?)Convert.ToInt32(varSolicitud_de_Pago_de_Facturas.Archivo_XML.Value)) : null

                        ,Archivo_PDF = (varSolicitud_de_Pago_de_Facturas.Archivo_PDF.HasValue && varSolicitud_de_Pago_de_Facturas.Archivo_PDF != 0) ? ((int?)Convert.ToInt32(varSolicitud_de_Pago_de_Facturas.Archivo_PDF.Value)) : null

                        ,Recibo_de_Solicitud_de_Pago = (varSolicitud_de_Pago_de_Facturas.Recibo_de_Solicitud_de_Pago.HasValue && varSolicitud_de_Pago_de_Facturas.Recibo_de_Solicitud_de_Pago != 0) ? ((int?)Convert.ToInt32(varSolicitud_de_Pago_de_Facturas.Recibo_de_Solicitud_de_Pago.Value)) : null

                        ,Total = varSolicitud_de_Pago_de_Facturas.Total
                        ,Estatus = varSolicitud_de_Pago_de_Facturas.Estatus
                    
                };

                result = _ISolicitud_de_Pago_de_FacturasApiConsumer.Update_Datos_Generales(Solicitud_de_Pago_de_Facturas_Datos_GeneralesInfo).Resource.ToString();
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
                _ISolicitud_de_Pago_de_FacturasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _ISolicitud_de_Pago_de_FacturasApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				
                var result = new Solicitud_de_Pago_de_Facturas_Datos_GeneralesModel
                {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_Registra = m.Usuario_que_Registra
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,Mes_Facturado = m.Mes_Facturado
                        ,Mes_FacturadoNombre = CultureHelper.GetTraduction(m.Mes_Facturado_Meses.Clave.ToString(), "Nombre") ?? (string)m.Mes_Facturado_Meses.Nombre
                        ,Fecha_inicio_del_periodo_facturado = (m.Fecha_inicio_del_periodo_facturado == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio_del_periodo_facturado).ToString(ConfigurationProperty.DateFormat))
                        ,Fecha_fin_del_periodo_facturado = (m.Fecha_fin_del_periodo_facturado == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin_del_periodo_facturado).ToString(ConfigurationProperty.DateFormat))
			,Archivo_XML = m.Archivo_XML
			,Archivo_PDF = m.Archivo_PDF
			,Recibo_de_Solicitud_de_Pago = m.Recibo_de_Solicitud_de_Pago
			,Total = m.Total
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_Facturas.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus_Facturas.Descripcion

                    
                };
				var resultData = new
                {
                    data = result

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }

		[HttpPost]
        public ActionResult Post_Autorizacion(Solicitud_de_Pago_de_Facturas_AutorizacionModel varSolicitud_de_Pago_de_Facturas)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISolicitud_de_Pago_de_FacturasApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Solicitud_de_Pago_de_Facturas_AutorizacionInfo = new Solicitud_de_Pago_de_Facturas_Autorizacion
                {
                    Folio = varSolicitud_de_Pago_de_Facturas.Folio
                                            ,Fecha_de_autorizacion = (!String.IsNullOrEmpty(varSolicitud_de_Pago_de_Facturas.Fecha_de_autorizacion)) ? DateTime.ParseExact(varSolicitud_de_Pago_de_Facturas.Fecha_de_autorizacion, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_autorizacion = varSolicitud_de_Pago_de_Facturas.Hora_de_autorizacion
                        ,Usuario_que_autoriza = varSolicitud_de_Pago_de_Facturas.Usuario_que_autoriza
                        ,Resultado_de_la_Revision = varSolicitud_de_Pago_de_Facturas.Resultado_de_la_Revision
                        ,Observaciones = varSolicitud_de_Pago_de_Facturas.Observaciones
                    
                };

                result = _ISolicitud_de_Pago_de_FacturasApiConsumer.Update_Autorizacion(Solicitud_de_Pago_de_Facturas_AutorizacionInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Autorizacion(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISolicitud_de_Pago_de_FacturasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _ISolicitud_de_Pago_de_FacturasApiConsumer.Get_Autorizacion(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				
                var result = new Solicitud_de_Pago_de_Facturas_AutorizacionModel
                {
                    Folio = m.Folio
                        ,Fecha_de_autorizacion = (m.Fecha_de_autorizacion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_autorizacion).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_autorizacion = m.Hora_de_autorizacion
                        ,Usuario_que_autoriza = m.Usuario_que_autoriza
                        ,Usuario_que_autorizaName = CultureHelper.GetTraduction(m.Usuario_que_autoriza_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_autoriza_Spartan_User.Name
                        ,Resultado_de_la_Revision = m.Resultado_de_la_Revision
                        ,Resultado_de_la_RevisionNombre = CultureHelper.GetTraduction(m.Resultado_de_la_Revision_Resultados_de_Revision.Folio.ToString(), "Nombre") ?? (string)m.Resultado_de_la_Revision_Resultados_de_Revision.Nombre
			,Observaciones = m.Observaciones

                    
                };
				var resultData = new
                {
                    data = result

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }

		[HttpPost]
        public ActionResult Post_Programacion_de_Pago(Solicitud_de_Pago_de_Facturas_Programacion_de_PagoModel varSolicitud_de_Pago_de_Facturas)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISolicitud_de_Pago_de_FacturasApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Solicitud_de_Pago_de_Facturas_Programacion_de_PagoInfo = new Solicitud_de_Pago_de_Facturas_Programacion_de_Pago
                {
                    Folio = varSolicitud_de_Pago_de_Facturas.Folio
                                            ,Fecha_de_programacion = (!String.IsNullOrEmpty(varSolicitud_de_Pago_de_Facturas.Fecha_de_programacion)) ? DateTime.ParseExact(varSolicitud_de_Pago_de_Facturas.Fecha_de_programacion, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_programacion = varSolicitud_de_Pago_de_Facturas.Hora_de_programacion
                        ,Usuario_que_programa = varSolicitud_de_Pago_de_Facturas.Usuario_que_programa
                        ,Fecha_programada_de_Pago = (!String.IsNullOrEmpty(varSolicitud_de_Pago_de_Facturas.Fecha_programada_de_Pago)) ? DateTime.ParseExact(varSolicitud_de_Pago_de_Facturas.Fecha_programada_de_Pago, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Estatus_de_Pago = varSolicitud_de_Pago_de_Facturas.Estatus_de_Pago
                    
                };

                result = _ISolicitud_de_Pago_de_FacturasApiConsumer.Update_Programacion_de_Pago(Solicitud_de_Pago_de_Facturas_Programacion_de_PagoInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Programacion_de_Pago(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISolicitud_de_Pago_de_FacturasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _ISolicitud_de_Pago_de_FacturasApiConsumer.Get_Programacion_de_Pago(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				
                var result = new Solicitud_de_Pago_de_Facturas_Programacion_de_PagoModel
                {
                    Folio = m.Folio
                        ,Fecha_de_programacion = (m.Fecha_de_programacion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_programacion).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_programacion = m.Hora_de_programacion
                        ,Usuario_que_programa = m.Usuario_que_programa
                        ,Usuario_que_programaName = CultureHelper.GetTraduction(m.Usuario_que_programa_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_programa_Spartan_User.Name
                        ,Fecha_programada_de_Pago = (m.Fecha_programada_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_programada_de_Pago).ToString(ConfigurationProperty.DateFormat))
                        ,Estatus_de_Pago = m.Estatus_de_Pago
                        ,Estatus_de_PagoNombre = CultureHelper.GetTraduction(m.Estatus_de_Pago_Estatus_de_Pago_de_Facturas.Folio.ToString(), "Nombre") ?? (string)m.Estatus_de_Pago_Estatus_de_Pago_de_Facturas.Nombre

                    
                };
				var resultData = new
                {
                    data = result

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }

		[HttpPost]
        public ActionResult Post_Pago(Solicitud_de_Pago_de_Facturas_PagoModel varSolicitud_de_Pago_de_Facturas)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISolicitud_de_Pago_de_FacturasApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Solicitud_de_Pago_de_Facturas_PagoInfo = new Solicitud_de_Pago_de_Facturas_Pago
                {
                    Folio = varSolicitud_de_Pago_de_Facturas.Folio
                                            ,Fecha_de_actualizacion = (!String.IsNullOrEmpty(varSolicitud_de_Pago_de_Facturas.Fecha_de_actualizacion)) ? DateTime.ParseExact(varSolicitud_de_Pago_de_Facturas.Fecha_de_actualizacion, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_actualizacion = varSolicitud_de_Pago_de_Facturas.Hora_de_actualizacion
                        ,Usuario_que_actualiza = varSolicitud_de_Pago_de_Facturas.Usuario_que_actualiza
                        ,Fecha_de_Pago = (!String.IsNullOrEmpty(varSolicitud_de_Pago_de_Facturas.Fecha_de_Pago)) ? DateTime.ParseExact(varSolicitud_de_Pago_de_Facturas.Fecha_de_Pago, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                    
                };

                result = _ISolicitud_de_Pago_de_FacturasApiConsumer.Update_Pago(Solicitud_de_Pago_de_Facturas_PagoInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Pago(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISolicitud_de_Pago_de_FacturasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _ISolicitud_de_Pago_de_FacturasApiConsumer.Get_Pago(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				
                var result = new Solicitud_de_Pago_de_Facturas_PagoModel
                {
                    Folio = m.Folio
                        ,Fecha_de_actualizacion = (m.Fecha_de_actualizacion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_actualizacion).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_actualizacion = m.Hora_de_actualizacion
                        ,Usuario_que_actualiza = m.Usuario_que_actualiza
                        ,Usuario_que_actualizaName = CultureHelper.GetTraduction(m.Usuario_que_actualiza_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_actualiza_Spartan_User.Name
                        ,Fecha_de_Pago = (m.Fecha_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Pago).ToString(ConfigurationProperty.DateFormat))

                    
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

