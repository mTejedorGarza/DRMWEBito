using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Formas_de_Pago;
using Spartane.Core.Domain.Estatus_de_Pago;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Detalle_Pagos_Pacientes_OpenPay;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Pagos_Pacientes_OpenPay;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Formas_de_Pago;
using Spartane.Web.Areas.WebApiConsumer.Estatus_de_Pago;

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

namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class Detalle_Pagos_Pacientes_OpenPayController : Controller
    {
        #region "variable declaration"

        private IDetalle_Pagos_Pacientes_OpenPayService service = null;
        private IDetalle_Pagos_Pacientes_OpenPayApiConsumer _IDetalle_Pagos_Pacientes_OpenPayApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private IFormas_de_PagoApiConsumer _IFormas_de_PagoApiConsumer;
        private IEstatus_de_PagoApiConsumer _IEstatus_de_PagoApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Detalle_Pagos_Pacientes_OpenPayController(IDetalle_Pagos_Pacientes_OpenPayService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDetalle_Pagos_Pacientes_OpenPayApiConsumer Detalle_Pagos_Pacientes_OpenPayApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer , IFormas_de_PagoApiConsumer Formas_de_PagoApiConsumer , IEstatus_de_PagoApiConsumer Estatus_de_PagoApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDetalle_Pagos_Pacientes_OpenPayApiConsumer = Detalle_Pagos_Pacientes_OpenPayApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;
            this._IFormas_de_PagoApiConsumer = Formas_de_PagoApiConsumer;
            this._IEstatus_de_PagoApiConsumer = Estatus_de_PagoApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Detalle_Pagos_Pacientes_OpenPay
        [ObjectAuth(ObjectId = (ModuleObjectId)44717, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44717);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Detalle_Pagos_Pacientes_OpenPay/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44717, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44717);
            ViewBag.Permission = permission;
            var varDetalle_Pagos_Pacientes_OpenPay = new Detalle_Pagos_Pacientes_OpenPayModel();
			
            ViewBag.ObjectId = "44717";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Pagos_Pacientes_OpenPayApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Detalle_Pagos_Pacientes_OpenPayData = _IDetalle_Pagos_Pacientes_OpenPayApiConsumer.GetByKeyComplete(Id).Resource.Detalle_Pagos_Pacientes_OpenPays[0];
                if (Detalle_Pagos_Pacientes_OpenPayData == null)
                    return HttpNotFound();

                varDetalle_Pagos_Pacientes_OpenPay = new Detalle_Pagos_Pacientes_OpenPayModel
                {
                    Folio = (int)Detalle_Pagos_Pacientes_OpenPayData.Folio
                    ,Usuario_que_Registra = Detalle_Pagos_Pacientes_OpenPayData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(Detalle_Pagos_Pacientes_OpenPayData.Usuario_que_Registra), "Spartan_User") ??  (string)Detalle_Pagos_Pacientes_OpenPayData.Usuario_que_Registra_Spartan_User.Name
                    ,Fecha_de_Pago = (Detalle_Pagos_Pacientes_OpenPayData.Fecha_de_Pago == null ? string.Empty : Convert.ToDateTime(Detalle_Pagos_Pacientes_OpenPayData.Fecha_de_Pago).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Pago = Detalle_Pagos_Pacientes_OpenPayData.Hora_de_Pago
                    ,TokenID = Detalle_Pagos_Pacientes_OpenPayData.TokenID
                    ,Importe = Detalle_Pagos_Pacientes_OpenPayData.Importe
                    ,Concepto = Detalle_Pagos_Pacientes_OpenPayData.Concepto
                    ,Forma_de_pago = Detalle_Pagos_Pacientes_OpenPayData.Forma_de_pago
                    ,Forma_de_pagoNombre = CultureHelper.GetTraduction(Convert.ToString(Detalle_Pagos_Pacientes_OpenPayData.Forma_de_pago), "Formas_de_Pago") ??  (string)Detalle_Pagos_Pacientes_OpenPayData.Forma_de_pago_Formas_de_Pago.Nombre
                    ,Autorizacion = Detalle_Pagos_Pacientes_OpenPayData.Autorizacion
                    ,Nombre = Detalle_Pagos_Pacientes_OpenPayData.Nombre
                    ,Apellidos = Detalle_Pagos_Pacientes_OpenPayData.Apellidos
                    ,Telefono = Detalle_Pagos_Pacientes_OpenPayData.Telefono
                    ,Email = Detalle_Pagos_Pacientes_OpenPayData.Email
                    ,DeviceID = Detalle_Pagos_Pacientes_OpenPayData.DeviceID
                    ,UsaPuntos = Detalle_Pagos_Pacientes_OpenPayData.UsaPuntos.GetValueOrDefault()
                    ,PuntosID = Detalle_Pagos_Pacientes_OpenPayData.PuntosID
                    ,Estatus = Detalle_Pagos_Pacientes_OpenPayData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Pagos_Pacientes_OpenPayData.Estatus), "Estatus_de_Pago") ??  (string)Detalle_Pagos_Pacientes_OpenPayData.Estatus_Estatus_de_Pago.Descripcion

                };

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
            _IFormas_de_PagoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Formas_de_Pagos_Forma_de_pago = _IFormas_de_PagoApiConsumer.SelAll(true);
            if (Formas_de_Pagos_Forma_de_pago != null && Formas_de_Pagos_Forma_de_pago.Resource != null)
                ViewBag.Formas_de_Pagos_Forma_de_pago = Formas_de_Pagos_Forma_de_pago.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Formas_de_Pago", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatus_de_PagoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_de_Pagos_Estatus = _IEstatus_de_PagoApiConsumer.SelAll(true);
            if (Estatus_de_Pagos_Estatus != null && Estatus_de_Pagos_Estatus.Resource != null)
                ViewBag.Estatus_de_Pagos_Estatus = Estatus_de_Pagos_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_de_Pago", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varDetalle_Pagos_Pacientes_OpenPay);
        }
		
	[HttpGet]
        public ActionResult AddDetalle_Pagos_Pacientes_OpenPay(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44717);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDetalle_Pagos_Pacientes_OpenPayApiConsumer.SetAuthHeader(_tokenManager.Token);
			Detalle_Pagos_Pacientes_OpenPayModel varDetalle_Pagos_Pacientes_OpenPay= new Detalle_Pagos_Pacientes_OpenPayModel();


            if (id.ToString() != "0")
            {
                var Detalle_Pagos_Pacientes_OpenPaysData = _IDetalle_Pagos_Pacientes_OpenPayApiConsumer.ListaSelAll(0, 1000, "Detalle_Pagos_Pacientes_OpenPay.Folio=" + id, "").Resource.Detalle_Pagos_Pacientes_OpenPays;
				
				if (Detalle_Pagos_Pacientes_OpenPaysData != null && Detalle_Pagos_Pacientes_OpenPaysData.Count > 0)
                {
					var Detalle_Pagos_Pacientes_OpenPayData = Detalle_Pagos_Pacientes_OpenPaysData.First();
					varDetalle_Pagos_Pacientes_OpenPay= new Detalle_Pagos_Pacientes_OpenPayModel
					{
						Folio  = Detalle_Pagos_Pacientes_OpenPayData.Folio 
	                    ,Usuario_que_Registra = Detalle_Pagos_Pacientes_OpenPayData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(Detalle_Pagos_Pacientes_OpenPayData.Usuario_que_Registra), "Spartan_User") ??  (string)Detalle_Pagos_Pacientes_OpenPayData.Usuario_que_Registra_Spartan_User.Name
                    ,Fecha_de_Pago = (Detalle_Pagos_Pacientes_OpenPayData.Fecha_de_Pago == null ? string.Empty : Convert.ToDateTime(Detalle_Pagos_Pacientes_OpenPayData.Fecha_de_Pago).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Pago = Detalle_Pagos_Pacientes_OpenPayData.Hora_de_Pago
                    ,TokenID = Detalle_Pagos_Pacientes_OpenPayData.TokenID
                    ,Importe = Detalle_Pagos_Pacientes_OpenPayData.Importe
                    ,Concepto = Detalle_Pagos_Pacientes_OpenPayData.Concepto
                    ,Forma_de_pago = Detalle_Pagos_Pacientes_OpenPayData.Forma_de_pago
                    ,Forma_de_pagoNombre = CultureHelper.GetTraduction(Convert.ToString(Detalle_Pagos_Pacientes_OpenPayData.Forma_de_pago), "Formas_de_Pago") ??  (string)Detalle_Pagos_Pacientes_OpenPayData.Forma_de_pago_Formas_de_Pago.Nombre
                    ,Autorizacion = Detalle_Pagos_Pacientes_OpenPayData.Autorizacion
                    ,Nombre = Detalle_Pagos_Pacientes_OpenPayData.Nombre
                    ,Apellidos = Detalle_Pagos_Pacientes_OpenPayData.Apellidos
                    ,Telefono = Detalle_Pagos_Pacientes_OpenPayData.Telefono
                    ,Email = Detalle_Pagos_Pacientes_OpenPayData.Email
                    ,DeviceID = Detalle_Pagos_Pacientes_OpenPayData.DeviceID
                    ,UsaPuntos = Detalle_Pagos_Pacientes_OpenPayData.UsaPuntos.GetValueOrDefault()
                    ,PuntosID = Detalle_Pagos_Pacientes_OpenPayData.PuntosID
                    ,Estatus = Detalle_Pagos_Pacientes_OpenPayData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Pagos_Pacientes_OpenPayData.Estatus), "Estatus_de_Pago") ??  (string)Detalle_Pagos_Pacientes_OpenPayData.Estatus_Estatus_de_Pago.Descripcion

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
            _IFormas_de_PagoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Formas_de_Pagos_Forma_de_pago = _IFormas_de_PagoApiConsumer.SelAll(true);
            if (Formas_de_Pagos_Forma_de_pago != null && Formas_de_Pagos_Forma_de_pago.Resource != null)
                ViewBag.Formas_de_Pagos_Forma_de_pago = Formas_de_Pagos_Forma_de_pago.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Formas_de_Pago", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatus_de_PagoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_de_Pagos_Estatus = _IEstatus_de_PagoApiConsumer.SelAll(true);
            if (Estatus_de_Pagos_Estatus != null && Estatus_de_Pagos_Estatus.Resource != null)
                ViewBag.Estatus_de_Pagos_Estatus = Estatus_de_Pagos_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_de_Pago", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddDetalle_Pagos_Pacientes_OpenPay", varDetalle_Pagos_Pacientes_OpenPay);
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
        public ActionResult GetFormas_de_PagoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IFormas_de_PagoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IFormas_de_PagoApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Formas_de_Pago", "Nombre")?? m.Nombre,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetEstatus_de_PagoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatus_de_PagoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstatus_de_PagoApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_de_Pago", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }



        public ActionResult Get()
        {
            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Pagos_Pacientes_OpenPayPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDetalle_Pagos_Pacientes_OpenPayApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Pagos_Pacientes_OpenPays == null)
                result.Detalle_Pagos_Pacientes_OpenPays = new List<Detalle_Pagos_Pacientes_OpenPay>();

            return Json(new
            {
                data = result.Detalle_Pagos_Pacientes_OpenPays.Select(m => new Detalle_Pagos_Pacientes_OpenPayGridModel
                    {
                    Folio = m.Folio
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,Fecha_de_Pago = (m.Fecha_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Pago).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Pago = m.Hora_de_Pago
			,TokenID = m.TokenID
			,Importe = m.Importe
			,Concepto = m.Concepto
                        ,Forma_de_pagoNombre = CultureHelper.GetTraduction(m.Forma_de_pago_Formas_de_Pago.Clave.ToString(), "Nombre") ?? (string)m.Forma_de_pago_Formas_de_Pago.Nombre
			,Autorizacion = m.Autorizacion
			,Nombre = m.Nombre
			,Apellidos = m.Apellidos
			,Telefono = m.Telefono
			,Email = m.Email
			,DeviceID = m.DeviceID
			,UsaPuntos = m.UsaPuntos
			,PuntosID = m.PuntosID
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_de_Pago.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus_de_Pago.Descripcion

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
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
                _IDetalle_Pagos_Pacientes_OpenPayApiConsumer.SetAuthHeader(_tokenManager.Token);

                Detalle_Pagos_Pacientes_OpenPay varDetalle_Pagos_Pacientes_OpenPay = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDetalle_Pagos_Pacientes_OpenPayApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Detalle_Pagos_Pacientes_OpenPayModel varDetalle_Pagos_Pacientes_OpenPay)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDetalle_Pagos_Pacientes_OpenPayApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Detalle_Pagos_Pacientes_OpenPayInfo = new Detalle_Pagos_Pacientes_OpenPay
                    {
                        Folio = varDetalle_Pagos_Pacientes_OpenPay.Folio
                        ,Usuario_que_Registra = varDetalle_Pagos_Pacientes_OpenPay.Usuario_que_Registra
                        ,Fecha_de_Pago = (!String.IsNullOrEmpty(varDetalle_Pagos_Pacientes_OpenPay.Fecha_de_Pago)) ? DateTime.ParseExact(varDetalle_Pagos_Pacientes_OpenPay.Fecha_de_Pago, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Pago = varDetalle_Pagos_Pacientes_OpenPay.Hora_de_Pago
                        ,TokenID = varDetalle_Pagos_Pacientes_OpenPay.TokenID
                        ,Importe = varDetalle_Pagos_Pacientes_OpenPay.Importe
                        ,Concepto = varDetalle_Pagos_Pacientes_OpenPay.Concepto
                        ,Forma_de_pago = varDetalle_Pagos_Pacientes_OpenPay.Forma_de_pago
                        ,Autorizacion = varDetalle_Pagos_Pacientes_OpenPay.Autorizacion
                        ,Nombre = varDetalle_Pagos_Pacientes_OpenPay.Nombre
                        ,Apellidos = varDetalle_Pagos_Pacientes_OpenPay.Apellidos
                        ,Telefono = varDetalle_Pagos_Pacientes_OpenPay.Telefono
                        ,Email = varDetalle_Pagos_Pacientes_OpenPay.Email
                        ,DeviceID = varDetalle_Pagos_Pacientes_OpenPay.DeviceID
                        ,UsaPuntos = varDetalle_Pagos_Pacientes_OpenPay.UsaPuntos
                        ,PuntosID = varDetalle_Pagos_Pacientes_OpenPay.PuntosID
                        ,Estatus = varDetalle_Pagos_Pacientes_OpenPay.Estatus

                    };

                    result = !IsNew ?
                        _IDetalle_Pagos_Pacientes_OpenPayApiConsumer.Update(Detalle_Pagos_Pacientes_OpenPayInfo, null, null).Resource.ToString() :
                         _IDetalle_Pagos_Pacientes_OpenPayApiConsumer.Insert(Detalle_Pagos_Pacientes_OpenPayInfo, null, null).Resource.ToString();

                    return Json(result, JsonRequestBehavior.AllowGet);
				}
				return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }



        /// <summary>
        /// Write Element Array of Detalle_Pagos_Pacientes_OpenPay script
        /// </summary>
        /// <param name="oDetalle_Pagos_Pacientes_OpenPayElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Detalle_Pagos_Pacientes_OpenPayModuleAttributeList)
        {
            for (int i = 0; i < Detalle_Pagos_Pacientes_OpenPayModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Detalle_Pagos_Pacientes_OpenPayModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Detalle_Pagos_Pacientes_OpenPayModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Detalle_Pagos_Pacientes_OpenPayModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Detalle_Pagos_Pacientes_OpenPayModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Detalle_Pagos_Pacientes_OpenPayModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Detalle_Pagos_Pacientes_OpenPayModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Detalle_Pagos_Pacientes_OpenPayModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Detalle_Pagos_Pacientes_OpenPayModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Detalle_Pagos_Pacientes_OpenPayModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Detalle_Pagos_Pacientes_OpenPayModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strDetalle_Pagos_Pacientes_OpenPayScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Pagos_Pacientes_OpenPay.js")))
            {
                strDetalle_Pagos_Pacientes_OpenPayScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Detalle_Pagos_Pacientes_OpenPay element attributes
            string userChangeJson = jsSerialize.Serialize(Detalle_Pagos_Pacientes_OpenPayModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDetalle_Pagos_Pacientes_OpenPayScript.IndexOf("inpuElementArray");
            string splittedString = strDetalle_Pagos_Pacientes_OpenPayScript.Substring(indexOfArray, strDetalle_Pagos_Pacientes_OpenPayScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Detalle_Pagos_Pacientes_OpenPayModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Detalle_Pagos_Pacientes_OpenPayModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDetalle_Pagos_Pacientes_OpenPayScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strDetalle_Pagos_Pacientes_OpenPayScript.Substring(indexOfArrayHistory, strDetalle_Pagos_Pacientes_OpenPayScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strDetalle_Pagos_Pacientes_OpenPayScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDetalle_Pagos_Pacientes_OpenPayScript.Substring(endIndexOfMainElement + indexOfArray, strDetalle_Pagos_Pacientes_OpenPayScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Detalle_Pagos_Pacientes_OpenPayModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strDetalle_Pagos_Pacientes_OpenPayScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strDetalle_Pagos_Pacientes_OpenPayScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strDetalle_Pagos_Pacientes_OpenPayScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strDetalle_Pagos_Pacientes_OpenPayScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Detalle_Pagos_Pacientes_OpenPay.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Detalle_Pagos_Pacientes_OpenPay.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Pagos_Pacientes_OpenPay.js")))
                {
                    strCustomScript = r.ReadToEnd();
                
                }

                int indexOfArray = strCustomScript.IndexOf("inpuElementArray");
                string splittedString = strCustomScript.Substring(indexOfArray, strCustomScript.Length - indexOfArray);                
                int indexOfMainElement = splittedString.IndexOf('[');                
                int endIndexOfMainElement = splittedString.IndexOf(']') + 1;                
                string mainJsonArray = splittedString.Substring(indexOfMainElement, endIndexOfMainElement - indexOfMainElement);

                int indexOfChildArray = strCustomScript.IndexOf("inpuElementChildArray");
				string childJsonArray = "";
                if (indexOfChildArray != -1)
                {
					string splittedChildString = strCustomScript.Substring(indexOfChildArray, strCustomScript.Length - indexOfChildArray);
					int indexOfChildElement = splittedChildString.IndexOf('[');
					int endIndexOfChildElement = splittedChildString.IndexOf(']') + 1;
					childJsonArray = splittedChildString.Substring(indexOfChildElement, endIndexOfChildElement - indexOfChildElement);
				}
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
        public ActionResult Detalle_Pagos_Pacientes_OpenPayPropertyBag()
        {
            return PartialView("Detalle_Pagos_Pacientes_OpenPayPropertyBag", "Detalle_Pagos_Pacientes_OpenPay");
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
        public void Export(string format, int pageIndex, int pageSize)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);

            if (!_tokenManager.GenerateToken())
                return;

            _IDetalle_Pagos_Pacientes_OpenPayApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Pagos_Pacientes_OpenPayPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Pagos_Pacientes_OpenPayApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Pagos_Pacientes_OpenPays == null)
                result.Detalle_Pagos_Pacientes_OpenPays = new List<Detalle_Pagos_Pacientes_OpenPay>();

            var data = result.Detalle_Pagos_Pacientes_OpenPays.Select(m => new Detalle_Pagos_Pacientes_OpenPayGridModel
            {
                Folio = m.Folio
                ,Usuario_que_RegistraName = (string)m.Usuario_que_Registra_Spartan_User.Name
                ,Fecha_de_Pago = (m.Fecha_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Pago).ToString(ConfigurationProperty.DateFormat))
                ,Hora_de_Pago = m.Hora_de_Pago
                ,TokenID = m.TokenID
                ,Importe = m.Importe
                ,Concepto = m.Concepto
                ,Forma_de_pagoNombre = (string)m.Forma_de_pago_Formas_de_Pago.Nombre
                ,Autorizacion = m.Autorizacion
                ,Nombre = m.Nombre
                ,Apellidos = m.Apellidos
                ,Telefono = m.Telefono
                ,Email = m.Email
                ,DeviceID = m.DeviceID
                ,UsaPuntos = m.UsaPuntos
                ,PuntosID = m.PuntosID
                ,EstatusDescripcion = (string)m.Estatus_Estatus_de_Pago.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Detalle_Pagos_Pacientes_OpenPayList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Detalle_Pagos_Pacientes_OpenPayList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(), "EmployeeList_" + DateTime.Now.ToString());
                    break;
            }
        }

        [HttpGet]
        //[ObjectAuth(ObjectId = ModuleObjectId.EMPLEADOS_OBJECT, PermissionType = PermissionTypes.Export)]
        public ActionResult Print(string format, int pageIndex, int pageSize)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);

            if (!_tokenManager.GenerateToken())
                return null;

            _IDetalle_Pagos_Pacientes_OpenPayApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Pagos_Pacientes_OpenPayPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Pagos_Pacientes_OpenPayApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Pagos_Pacientes_OpenPays == null)
                result.Detalle_Pagos_Pacientes_OpenPays = new List<Detalle_Pagos_Pacientes_OpenPay>();

            var data = result.Detalle_Pagos_Pacientes_OpenPays.Select(m => new Detalle_Pagos_Pacientes_OpenPayGridModel
            {
                Folio = m.Folio
                ,Usuario_que_RegistraName = (string)m.Usuario_que_Registra_Spartan_User.Name
                ,Fecha_de_Pago = (m.Fecha_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Pago).ToString(ConfigurationProperty.DateFormat))
                ,Hora_de_Pago = m.Hora_de_Pago
                ,TokenID = m.TokenID
                ,Importe = m.Importe
                ,Concepto = m.Concepto
                ,Forma_de_pagoNombre = (string)m.Forma_de_pago_Formas_de_Pago.Nombre
                ,Autorizacion = m.Autorizacion
                ,Nombre = m.Nombre
                ,Apellidos = m.Apellidos
                ,Telefono = m.Telefono
                ,Email = m.Email
                ,DeviceID = m.DeviceID
                ,UsaPuntos = m.UsaPuntos
                ,PuntosID = m.PuntosID
                ,EstatusDescripcion = (string)m.Estatus_Estatus_de_Pago.Descripcion

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
