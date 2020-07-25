using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Detalle_Secuencia_de_Ejercicios;
using Spartane.Core.Domain.Secuencia_de_Ejercicios_en_Rutinas;
using Spartane.Core.Domain.Tipo_de_Ejercicio_Rutina;
using Spartane.Core.Domain.Tipo_de_Enfoque_del_Ejercicio;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Detalle_Secuencia_de_Ejercicios;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
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

namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class Detalle_Secuencia_de_EjerciciosController : Controller
    {
        #region "variable declaration"

        private IDetalle_Secuencia_de_EjerciciosService service = null;
        private IDetalle_Secuencia_de_EjerciciosApiConsumer _IDetalle_Secuencia_de_EjerciciosApiConsumer;
        private ISecuencia_de_Ejercicios_en_RutinasApiConsumer _ISecuencia_de_Ejercicios_en_RutinasApiConsumer;
        private ITipo_de_Ejercicio_RutinaApiConsumer _ITipo_de_Ejercicio_RutinaApiConsumer;
        private ITipo_de_Enfoque_del_EjercicioApiConsumer _ITipo_de_Enfoque_del_EjercicioApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Detalle_Secuencia_de_EjerciciosController(IDetalle_Secuencia_de_EjerciciosService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDetalle_Secuencia_de_EjerciciosApiConsumer Detalle_Secuencia_de_EjerciciosApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , ISecuencia_de_Ejercicios_en_RutinasApiConsumer Secuencia_de_Ejercicios_en_RutinasApiConsumer , ITipo_de_Ejercicio_RutinaApiConsumer Tipo_de_Ejercicio_RutinaApiConsumer , ITipo_de_Enfoque_del_EjercicioApiConsumer Tipo_de_Enfoque_del_EjercicioApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDetalle_Secuencia_de_EjerciciosApiConsumer = Detalle_Secuencia_de_EjerciciosApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISecuencia_de_Ejercicios_en_RutinasApiConsumer = Secuencia_de_Ejercicios_en_RutinasApiConsumer;
            this._ITipo_de_Ejercicio_RutinaApiConsumer = Tipo_de_Ejercicio_RutinaApiConsumer;
            this._ITipo_de_Enfoque_del_EjercicioApiConsumer = Tipo_de_Enfoque_del_EjercicioApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Detalle_Secuencia_de_Ejercicios
        [ObjectAuth(ObjectId = (ModuleObjectId)44614, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44614);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Detalle_Secuencia_de_Ejercicios/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44614, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44614);
            ViewBag.Permission = permission;
            var varDetalle_Secuencia_de_Ejercicios = new Detalle_Secuencia_de_EjerciciosModel();
			
            ViewBag.ObjectId = "44614";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Secuencia_de_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Detalle_Secuencia_de_EjerciciosData = _IDetalle_Secuencia_de_EjerciciosApiConsumer.GetByKeyComplete(Id).Resource.Detalle_Secuencia_de_Ejercicioss[0];
                if (Detalle_Secuencia_de_EjerciciosData == null)
                    return HttpNotFound();

                varDetalle_Secuencia_de_Ejercicios = new Detalle_Secuencia_de_EjerciciosModel
                {
                    Folio = (int)Detalle_Secuencia_de_EjerciciosData.Folio
                    ,Orden_del_Ejercicio = Detalle_Secuencia_de_EjerciciosData.Orden_del_Ejercicio
                    ,Orden_del_EjercicioDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Secuencia_de_EjerciciosData.Orden_del_Ejercicio), "Secuencia_de_Ejercicios_en_Rutinas") ??  (string)Detalle_Secuencia_de_EjerciciosData.Orden_del_Ejercicio_Secuencia_de_Ejercicios_en_Rutinas.Descripcion
                    ,Tipo_de_Ejercicio = Detalle_Secuencia_de_EjerciciosData.Tipo_de_Ejercicio
                    ,Tipo_de_EjercicioNombre_para_Secuencia = CultureHelper.GetTraduction(Convert.ToString(Detalle_Secuencia_de_EjerciciosData.Tipo_de_Ejercicio), "Tipo_de_Ejercicio_Rutina") ??  (string)Detalle_Secuencia_de_EjerciciosData.Tipo_de_Ejercicio_Tipo_de_Ejercicio_Rutina.Nombre_para_Secuencia
                    ,Enfoque = Detalle_Secuencia_de_EjerciciosData.Enfoque
                    ,EnfoqueDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Secuencia_de_EjerciciosData.Enfoque), "Tipo_de_Enfoque_del_Ejercicio") ??  (string)Detalle_Secuencia_de_EjerciciosData.Enfoque_Tipo_de_Enfoque_del_Ejercicio.Descripcion
                    ,Secuencia_del_Ejercicio = Detalle_Secuencia_de_EjerciciosData.Secuencia_del_Ejercicio

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISecuencia_de_Ejercicios_en_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Secuencia_de_Ejercicios_en_Rutinass_Orden_del_Ejercicio = _ISecuencia_de_Ejercicios_en_RutinasApiConsumer.SelAll(true);
            if (Secuencia_de_Ejercicios_en_Rutinass_Orden_del_Ejercicio != null && Secuencia_de_Ejercicios_en_Rutinass_Orden_del_Ejercicio.Resource != null)
                ViewBag.Secuencia_de_Ejercicios_en_Rutinass_Orden_del_Ejercicio = Secuencia_de_Ejercicios_en_Rutinass_Orden_del_Ejercicio.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Secuencia_de_Ejercicios_en_Rutinas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ITipo_de_Ejercicio_RutinaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Ejercicio_Rutinas_Tipo_de_Ejercicio = _ITipo_de_Ejercicio_RutinaApiConsumer.SelAll(true);
            if (Tipo_de_Ejercicio_Rutinas_Tipo_de_Ejercicio != null && Tipo_de_Ejercicio_Rutinas_Tipo_de_Ejercicio.Resource != null)
                ViewBag.Tipo_de_Ejercicio_Rutinas_Tipo_de_Ejercicio = Tipo_de_Ejercicio_Rutinas_Tipo_de_Ejercicio.Resource.Where(m => m.Nombre_para_Secuencia != null).OrderBy(m => m.Nombre_para_Secuencia).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Tipo_de_Ejercicio_Rutina", "Nombre_para_Secuencia") ?? m.Nombre_para_Secuencia.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ITipo_de_Enfoque_del_EjercicioApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Enfoque_del_Ejercicios_Enfoque = _ITipo_de_Enfoque_del_EjercicioApiConsumer.SelAll(true);
            if (Tipo_de_Enfoque_del_Ejercicios_Enfoque != null && Tipo_de_Enfoque_del_Ejercicios_Enfoque.Resource != null)
                ViewBag.Tipo_de_Enfoque_del_Ejercicios_Enfoque = Tipo_de_Enfoque_del_Ejercicios_Enfoque.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Tipo_de_Enfoque_del_Ejercicio", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varDetalle_Secuencia_de_Ejercicios);
        }
		
	[HttpGet]
        public ActionResult AddDetalle_Secuencia_de_Ejercicios(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44614);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDetalle_Secuencia_de_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
			Detalle_Secuencia_de_EjerciciosModel varDetalle_Secuencia_de_Ejercicios= new Detalle_Secuencia_de_EjerciciosModel();


            if (id.ToString() != "0")
            {
                var Detalle_Secuencia_de_EjerciciossData = _IDetalle_Secuencia_de_EjerciciosApiConsumer.ListaSelAll(0, 1000, "Detalle_Secuencia_de_Ejercicios.Folio=" + id, "").Resource.Detalle_Secuencia_de_Ejercicioss;
				
				if (Detalle_Secuencia_de_EjerciciossData != null && Detalle_Secuencia_de_EjerciciossData.Count > 0)
                {
					var Detalle_Secuencia_de_EjerciciosData = Detalle_Secuencia_de_EjerciciossData.First();
					varDetalle_Secuencia_de_Ejercicios= new Detalle_Secuencia_de_EjerciciosModel
					{
						Folio  = Detalle_Secuencia_de_EjerciciosData.Folio 
	                    ,Orden_del_Ejercicio = Detalle_Secuencia_de_EjerciciosData.Orden_del_Ejercicio
                    ,Orden_del_EjercicioDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Secuencia_de_EjerciciosData.Orden_del_Ejercicio), "Secuencia_de_Ejercicios_en_Rutinas") ??  (string)Detalle_Secuencia_de_EjerciciosData.Orden_del_Ejercicio_Secuencia_de_Ejercicios_en_Rutinas.Descripcion
                    ,Tipo_de_Ejercicio = Detalle_Secuencia_de_EjerciciosData.Tipo_de_Ejercicio
                    ,Tipo_de_EjercicioNombre_para_Secuencia = CultureHelper.GetTraduction(Convert.ToString(Detalle_Secuencia_de_EjerciciosData.Tipo_de_Ejercicio), "Tipo_de_Ejercicio_Rutina") ??  (string)Detalle_Secuencia_de_EjerciciosData.Tipo_de_Ejercicio_Tipo_de_Ejercicio_Rutina.Nombre_para_Secuencia
                    ,Enfoque = Detalle_Secuencia_de_EjerciciosData.Enfoque
                    ,EnfoqueDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Secuencia_de_EjerciciosData.Enfoque), "Tipo_de_Enfoque_del_Ejercicio") ??  (string)Detalle_Secuencia_de_EjerciciosData.Enfoque_Tipo_de_Enfoque_del_Ejercicio.Descripcion
                    ,Secuencia_del_Ejercicio = Detalle_Secuencia_de_EjerciciosData.Secuencia_del_Ejercicio

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISecuencia_de_Ejercicios_en_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Secuencia_de_Ejercicios_en_Rutinass_Orden_del_Ejercicio = _ISecuencia_de_Ejercicios_en_RutinasApiConsumer.SelAll(true);
            if (Secuencia_de_Ejercicios_en_Rutinass_Orden_del_Ejercicio != null && Secuencia_de_Ejercicios_en_Rutinass_Orden_del_Ejercicio.Resource != null)
                ViewBag.Secuencia_de_Ejercicios_en_Rutinass_Orden_del_Ejercicio = Secuencia_de_Ejercicios_en_Rutinass_Orden_del_Ejercicio.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Secuencia_de_Ejercicios_en_Rutinas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ITipo_de_Ejercicio_RutinaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Ejercicio_Rutinas_Tipo_de_Ejercicio = _ITipo_de_Ejercicio_RutinaApiConsumer.SelAll(true);
            if (Tipo_de_Ejercicio_Rutinas_Tipo_de_Ejercicio != null && Tipo_de_Ejercicio_Rutinas_Tipo_de_Ejercicio.Resource != null)
                ViewBag.Tipo_de_Ejercicio_Rutinas_Tipo_de_Ejercicio = Tipo_de_Ejercicio_Rutinas_Tipo_de_Ejercicio.Resource.Where(m => m.Nombre_para_Secuencia != null).OrderBy(m => m.Nombre_para_Secuencia).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Tipo_de_Ejercicio_Rutina", "Nombre_para_Secuencia") ?? m.Nombre_para_Secuencia.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ITipo_de_Enfoque_del_EjercicioApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Enfoque_del_Ejercicios_Enfoque = _ITipo_de_Enfoque_del_EjercicioApiConsumer.SelAll(true);
            if (Tipo_de_Enfoque_del_Ejercicios_Enfoque != null && Tipo_de_Enfoque_del_Ejercicios_Enfoque.Resource != null)
                ViewBag.Tipo_de_Enfoque_del_Ejercicios_Enfoque = Tipo_de_Enfoque_del_Ejercicios_Enfoque.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Tipo_de_Enfoque_del_Ejercicio", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            return PartialView("AddDetalle_Secuencia_de_Ejercicios", varDetalle_Secuencia_de_Ejercicios);
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
        public ActionResult GetSecuencia_de_Ejercicios_en_RutinasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISecuencia_de_Ejercicios_en_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISecuencia_de_Ejercicios_en_RutinasApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Secuencia_de_Ejercicios_en_Rutinas", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Folio)
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
                
                return Json(result.OrderBy(m => m.Nombre_para_Secuencia).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Tipo_de_Ejercicio_Rutina", "Nombre_para_Secuencia")?? m.Nombre_para_Secuencia,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetTipo_de_Enfoque_del_EjercicioAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipo_de_Enfoque_del_EjercicioApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipo_de_Enfoque_del_EjercicioApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Tipo_de_Enfoque_del_Ejercicio", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Folio)
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Secuencia_de_EjerciciosPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDetalle_Secuencia_de_EjerciciosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Secuencia_de_Ejercicioss == null)
                result.Detalle_Secuencia_de_Ejercicioss = new List<Detalle_Secuencia_de_Ejercicios>();

            return Json(new
            {
                data = result.Detalle_Secuencia_de_Ejercicioss.Select(m => new Detalle_Secuencia_de_EjerciciosGridModel
                    {
                    Folio = m.Folio
                        ,Orden_del_EjercicioDescripcion = CultureHelper.GetTraduction(m.Orden_del_Ejercicio_Secuencia_de_Ejercicios_en_Rutinas.Folio.ToString(), "Descripcion") ?? (string)m.Orden_del_Ejercicio_Secuencia_de_Ejercicios_en_Rutinas.Descripcion
                        ,Tipo_de_EjercicioNombre_para_Secuencia = CultureHelper.GetTraduction(m.Tipo_de_Ejercicio_Tipo_de_Ejercicio_Rutina.Folio.ToString(), "Nombre_para_Secuencia") ?? (string)m.Tipo_de_Ejercicio_Tipo_de_Ejercicio_Rutina.Nombre_para_Secuencia
                        ,EnfoqueDescripcion = CultureHelper.GetTraduction(m.Enfoque_Tipo_de_Enfoque_del_Ejercicio.Folio.ToString(), "Descripcion") ?? (string)m.Enfoque_Tipo_de_Enfoque_del_Ejercicio.Descripcion
			,Secuencia_del_Ejercicio = m.Secuencia_del_Ejercicio

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
                _IDetalle_Secuencia_de_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);

                Detalle_Secuencia_de_Ejercicios varDetalle_Secuencia_de_Ejercicios = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDetalle_Secuencia_de_EjerciciosApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Detalle_Secuencia_de_EjerciciosModel varDetalle_Secuencia_de_Ejercicios)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDetalle_Secuencia_de_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Detalle_Secuencia_de_EjerciciosInfo = new Detalle_Secuencia_de_Ejercicios
                    {
                        Folio = varDetalle_Secuencia_de_Ejercicios.Folio
                        ,Orden_del_Ejercicio = varDetalle_Secuencia_de_Ejercicios.Orden_del_Ejercicio
                        ,Tipo_de_Ejercicio = varDetalle_Secuencia_de_Ejercicios.Tipo_de_Ejercicio
                        ,Enfoque = varDetalle_Secuencia_de_Ejercicios.Enfoque
                        ,Secuencia_del_Ejercicio = varDetalle_Secuencia_de_Ejercicios.Secuencia_del_Ejercicio

                    };

                    result = !IsNew ?
                        _IDetalle_Secuencia_de_EjerciciosApiConsumer.Update(Detalle_Secuencia_de_EjerciciosInfo, null, null).Resource.ToString() :
                         _IDetalle_Secuencia_de_EjerciciosApiConsumer.Insert(Detalle_Secuencia_de_EjerciciosInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Detalle_Secuencia_de_Ejercicios script
        /// </summary>
        /// <param name="oDetalle_Secuencia_de_EjerciciosElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Detalle_Secuencia_de_EjerciciosModuleAttributeList)
        {
            for (int i = 0; i < Detalle_Secuencia_de_EjerciciosModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Detalle_Secuencia_de_EjerciciosModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Detalle_Secuencia_de_EjerciciosModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Detalle_Secuencia_de_EjerciciosModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Detalle_Secuencia_de_EjerciciosModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Detalle_Secuencia_de_EjerciciosModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Detalle_Secuencia_de_EjerciciosModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Detalle_Secuencia_de_EjerciciosModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Detalle_Secuencia_de_EjerciciosModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Detalle_Secuencia_de_EjerciciosModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Detalle_Secuencia_de_EjerciciosModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strDetalle_Secuencia_de_EjerciciosScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Secuencia_de_Ejercicios.js")))
            {
                strDetalle_Secuencia_de_EjerciciosScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Detalle_Secuencia_de_Ejercicios element attributes
            string userChangeJson = jsSerialize.Serialize(Detalle_Secuencia_de_EjerciciosModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDetalle_Secuencia_de_EjerciciosScript.IndexOf("inpuElementArray");
            string splittedString = strDetalle_Secuencia_de_EjerciciosScript.Substring(indexOfArray, strDetalle_Secuencia_de_EjerciciosScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Detalle_Secuencia_de_EjerciciosModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Detalle_Secuencia_de_EjerciciosModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDetalle_Secuencia_de_EjerciciosScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strDetalle_Secuencia_de_EjerciciosScript.Substring(indexOfArrayHistory, strDetalle_Secuencia_de_EjerciciosScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strDetalle_Secuencia_de_EjerciciosScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDetalle_Secuencia_de_EjerciciosScript.Substring(endIndexOfMainElement + indexOfArray, strDetalle_Secuencia_de_EjerciciosScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Detalle_Secuencia_de_EjerciciosModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strDetalle_Secuencia_de_EjerciciosScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strDetalle_Secuencia_de_EjerciciosScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strDetalle_Secuencia_de_EjerciciosScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strDetalle_Secuencia_de_EjerciciosScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Detalle_Secuencia_de_Ejercicios.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Detalle_Secuencia_de_Ejercicios.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Secuencia_de_Ejercicios.js")))
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
        public ActionResult Detalle_Secuencia_de_EjerciciosPropertyBag()
        {
            return PartialView("Detalle_Secuencia_de_EjerciciosPropertyBag", "Detalle_Secuencia_de_Ejercicios");
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

            _IDetalle_Secuencia_de_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Secuencia_de_EjerciciosPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Secuencia_de_EjerciciosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Secuencia_de_Ejercicioss == null)
                result.Detalle_Secuencia_de_Ejercicioss = new List<Detalle_Secuencia_de_Ejercicios>();

            var data = result.Detalle_Secuencia_de_Ejercicioss.Select(m => new Detalle_Secuencia_de_EjerciciosGridModel
            {
                Folio = m.Folio
                ,Orden_del_EjercicioDescripcion = (string)m.Orden_del_Ejercicio_Secuencia_de_Ejercicios_en_Rutinas.Descripcion
                ,Tipo_de_EjercicioNombre_para_Secuencia = (string)m.Tipo_de_Ejercicio_Tipo_de_Ejercicio_Rutina.Nombre_para_Secuencia
                ,EnfoqueDescripcion = (string)m.Enfoque_Tipo_de_Enfoque_del_Ejercicio.Descripcion
                ,Secuencia_del_Ejercicio = m.Secuencia_del_Ejercicio

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Detalle_Secuencia_de_EjerciciosList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Detalle_Secuencia_de_EjerciciosList_" + DateTime.Now.ToString());
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

            _IDetalle_Secuencia_de_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Secuencia_de_EjerciciosPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Secuencia_de_EjerciciosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Secuencia_de_Ejercicioss == null)
                result.Detalle_Secuencia_de_Ejercicioss = new List<Detalle_Secuencia_de_Ejercicios>();

            var data = result.Detalle_Secuencia_de_Ejercicioss.Select(m => new Detalle_Secuencia_de_EjerciciosGridModel
            {
                Folio = m.Folio
                ,Orden_del_EjercicioDescripcion = (string)m.Orden_del_Ejercicio_Secuencia_de_Ejercicios_en_Rutinas.Descripcion
                ,Tipo_de_EjercicioNombre_para_Secuencia = (string)m.Tipo_de_Ejercicio_Tipo_de_Ejercicio_Rutina.Nombre_para_Secuencia
                ,EnfoqueDescripcion = (string)m.Enfoque_Tipo_de_Enfoque_del_Ejercicio.Descripcion
                ,Secuencia_del_Ejercicio = m.Secuencia_del_Ejercicio

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
