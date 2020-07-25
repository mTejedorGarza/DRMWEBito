using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.MR_Referenciados_Codigo_de_Descuento;
using Spartane.Core.Domain.Tipo_Paciente;
using Spartane.Core.Domain.Spartan_User;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.MR_Referenciados_Codigo_de_Descuento;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.MR_Referenciados_Codigo_de_Descuento;
using Spartane.Web.Areas.WebApiConsumer.Tipo_Paciente;
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

namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class MR_Referenciados_Codigo_de_DescuentoController : Controller
    {
        #region "variable declaration"

        private IMR_Referenciados_Codigo_de_DescuentoService service = null;
        private IMR_Referenciados_Codigo_de_DescuentoApiConsumer _IMR_Referenciados_Codigo_de_DescuentoApiConsumer;
        private ITipo_PacienteApiConsumer _ITipo_PacienteApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public MR_Referenciados_Codigo_de_DescuentoController(IMR_Referenciados_Codigo_de_DescuentoService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IMR_Referenciados_Codigo_de_DescuentoApiConsumer MR_Referenciados_Codigo_de_DescuentoApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , ITipo_PacienteApiConsumer Tipo_PacienteApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IMR_Referenciados_Codigo_de_DescuentoApiConsumer = MR_Referenciados_Codigo_de_DescuentoApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ITipo_PacienteApiConsumer = Tipo_PacienteApiConsumer;
            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/MR_Referenciados_Codigo_de_Descuento
        [ObjectAuth(ObjectId = (ModuleObjectId)44740, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44740);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/MR_Referenciados_Codigo_de_Descuento/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44740, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44740);
            ViewBag.Permission = permission;
            var varMR_Referenciados_Codigo_de_Descuento = new MR_Referenciados_Codigo_de_DescuentoModel();
			
            ViewBag.ObjectId = "44740";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMR_Referenciados_Codigo_de_DescuentoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var MR_Referenciados_Codigo_de_DescuentoData = _IMR_Referenciados_Codigo_de_DescuentoApiConsumer.GetByKeyComplete(Id).Resource.MR_Referenciados_Codigo_de_Descuentos[0];
                if (MR_Referenciados_Codigo_de_DescuentoData == null)
                    return HttpNotFound();

                varMR_Referenciados_Codigo_de_Descuento = new MR_Referenciados_Codigo_de_DescuentoModel
                {
                    Folio = (int)MR_Referenciados_Codigo_de_DescuentoData.Folio
                    ,Tipo_de_usuario = MR_Referenciados_Codigo_de_DescuentoData.Tipo_de_usuario
                    ,Tipo_de_usuarioDescripcion = CultureHelper.GetTraduction(Convert.ToString(MR_Referenciados_Codigo_de_DescuentoData.Tipo_de_usuario), "Tipo_Paciente") ??  (string)MR_Referenciados_Codigo_de_DescuentoData.Tipo_de_usuario_Tipo_Paciente.Descripcion
                    ,Usuario = MR_Referenciados_Codigo_de_DescuentoData.Usuario
                    ,UsuarioName = CultureHelper.GetTraduction(Convert.ToString(MR_Referenciados_Codigo_de_DescuentoData.Usuario), "Spartan_User") ??  (string)MR_Referenciados_Codigo_de_DescuentoData.Usuario_Spartan_User.Name
                    ,Fecha_de_aplicacion = (MR_Referenciados_Codigo_de_DescuentoData.Fecha_de_aplicacion == null ? string.Empty : Convert.ToDateTime(MR_Referenciados_Codigo_de_DescuentoData.Fecha_de_aplicacion).ToString(ConfigurationProperty.DateFormat))
                    ,Descuento_Total = MR_Referenciados_Codigo_de_DescuentoData.Descuento_Total

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ITipo_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_Pacientes_Tipo_de_usuario = _ITipo_PacienteApiConsumer.SelAll(true);
            if (Tipo_Pacientes_Tipo_de_usuario != null && Tipo_Pacientes_Tipo_de_usuario.Resource != null)
                ViewBag.Tipo_Pacientes_Tipo_de_usuario = Tipo_Pacientes_Tipo_de_usuario.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Paciente", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario != null && Spartan_Users_Usuario.Resource != null)
                ViewBag.Spartan_Users_Usuario = Spartan_Users_Usuario.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varMR_Referenciados_Codigo_de_Descuento);
        }
		
	[HttpGet]
        public ActionResult AddMR_Referenciados_Codigo_de_Descuento(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44740);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IMR_Referenciados_Codigo_de_DescuentoApiConsumer.SetAuthHeader(_tokenManager.Token);
			MR_Referenciados_Codigo_de_DescuentoModel varMR_Referenciados_Codigo_de_Descuento= new MR_Referenciados_Codigo_de_DescuentoModel();


            if (id.ToString() != "0")
            {
                var MR_Referenciados_Codigo_de_DescuentosData = _IMR_Referenciados_Codigo_de_DescuentoApiConsumer.ListaSelAll(0, 1000, "MR_Referenciados_Codigo_de_Descuento.Folio=" + id, "").Resource.MR_Referenciados_Codigo_de_Descuentos;
				
				if (MR_Referenciados_Codigo_de_DescuentosData != null && MR_Referenciados_Codigo_de_DescuentosData.Count > 0)
                {
					var MR_Referenciados_Codigo_de_DescuentoData = MR_Referenciados_Codigo_de_DescuentosData.First();
					varMR_Referenciados_Codigo_de_Descuento= new MR_Referenciados_Codigo_de_DescuentoModel
					{
						Folio  = MR_Referenciados_Codigo_de_DescuentoData.Folio 
	                    ,Tipo_de_usuario = MR_Referenciados_Codigo_de_DescuentoData.Tipo_de_usuario
                    ,Tipo_de_usuarioDescripcion = CultureHelper.GetTraduction(Convert.ToString(MR_Referenciados_Codigo_de_DescuentoData.Tipo_de_usuario), "Tipo_Paciente") ??  (string)MR_Referenciados_Codigo_de_DescuentoData.Tipo_de_usuario_Tipo_Paciente.Descripcion
                    ,Usuario = MR_Referenciados_Codigo_de_DescuentoData.Usuario
                    ,UsuarioName = CultureHelper.GetTraduction(Convert.ToString(MR_Referenciados_Codigo_de_DescuentoData.Usuario), "Spartan_User") ??  (string)MR_Referenciados_Codigo_de_DescuentoData.Usuario_Spartan_User.Name
                    ,Fecha_de_aplicacion = (MR_Referenciados_Codigo_de_DescuentoData.Fecha_de_aplicacion == null ? string.Empty : Convert.ToDateTime(MR_Referenciados_Codigo_de_DescuentoData.Fecha_de_aplicacion).ToString(ConfigurationProperty.DateFormat))
                    ,Descuento_Total = MR_Referenciados_Codigo_de_DescuentoData.Descuento_Total

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ITipo_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_Pacientes_Tipo_de_usuario = _ITipo_PacienteApiConsumer.SelAll(true);
            if (Tipo_Pacientes_Tipo_de_usuario != null && Tipo_Pacientes_Tipo_de_usuario.Resource != null)
                ViewBag.Tipo_Pacientes_Tipo_de_usuario = Tipo_Pacientes_Tipo_de_usuario.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Paciente", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario != null && Spartan_Users_Usuario.Resource != null)
                ViewBag.Spartan_Users_Usuario = Spartan_Users_Usuario.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();


            return PartialView("AddMR_Referenciados_Codigo_de_Descuento", varMR_Referenciados_Codigo_de_Descuento);
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
        public ActionResult GetTipo_PacienteAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipo_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipo_PacienteApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Paciente", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
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



        public ActionResult Get()
        {
            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new MR_Referenciados_Codigo_de_DescuentoPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IMR_Referenciados_Codigo_de_DescuentoApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MR_Referenciados_Codigo_de_Descuentos == null)
                result.MR_Referenciados_Codigo_de_Descuentos = new List<MR_Referenciados_Codigo_de_Descuento>();

            return Json(new
            {
                data = result.MR_Referenciados_Codigo_de_Descuentos.Select(m => new MR_Referenciados_Codigo_de_DescuentoGridModel
                    {
                    Folio = m.Folio
                        ,Tipo_de_usuarioDescripcion = CultureHelper.GetTraduction(m.Tipo_de_usuario_Tipo_Paciente.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_usuario_Tipo_Paciente.Descripcion
                        ,UsuarioName = CultureHelper.GetTraduction(m.Usuario_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_Spartan_User.Name
                        ,Fecha_de_aplicacion = (m.Fecha_de_aplicacion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_aplicacion).ToString(ConfigurationProperty.DateFormat))
			,Descuento_Total = m.Descuento_Total

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
                _IMR_Referenciados_Codigo_de_DescuentoApiConsumer.SetAuthHeader(_tokenManager.Token);

                MR_Referenciados_Codigo_de_Descuento varMR_Referenciados_Codigo_de_Descuento = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IMR_Referenciados_Codigo_de_DescuentoApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, MR_Referenciados_Codigo_de_DescuentoModel varMR_Referenciados_Codigo_de_Descuento)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IMR_Referenciados_Codigo_de_DescuentoApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var MR_Referenciados_Codigo_de_DescuentoInfo = new MR_Referenciados_Codigo_de_Descuento
                    {
                        Folio = varMR_Referenciados_Codigo_de_Descuento.Folio
                        ,Tipo_de_usuario = varMR_Referenciados_Codigo_de_Descuento.Tipo_de_usuario
                        ,Usuario = varMR_Referenciados_Codigo_de_Descuento.Usuario
                        ,Fecha_de_aplicacion = (!String.IsNullOrEmpty(varMR_Referenciados_Codigo_de_Descuento.Fecha_de_aplicacion)) ? DateTime.ParseExact(varMR_Referenciados_Codigo_de_Descuento.Fecha_de_aplicacion, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Descuento_Total = varMR_Referenciados_Codigo_de_Descuento.Descuento_Total

                    };

                    result = !IsNew ?
                        _IMR_Referenciados_Codigo_de_DescuentoApiConsumer.Update(MR_Referenciados_Codigo_de_DescuentoInfo, null, null).Resource.ToString() :
                         _IMR_Referenciados_Codigo_de_DescuentoApiConsumer.Insert(MR_Referenciados_Codigo_de_DescuentoInfo, null, null).Resource.ToString();

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
        /// Write Element Array of MR_Referenciados_Codigo_de_Descuento script
        /// </summary>
        /// <param name="oMR_Referenciados_Codigo_de_DescuentoElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements MR_Referenciados_Codigo_de_DescuentoModuleAttributeList)
        {
            for (int i = 0; i < MR_Referenciados_Codigo_de_DescuentoModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(MR_Referenciados_Codigo_de_DescuentoModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    MR_Referenciados_Codigo_de_DescuentoModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(MR_Referenciados_Codigo_de_DescuentoModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    MR_Referenciados_Codigo_de_DescuentoModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (MR_Referenciados_Codigo_de_DescuentoModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < MR_Referenciados_Codigo_de_DescuentoModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(MR_Referenciados_Codigo_de_DescuentoModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						MR_Referenciados_Codigo_de_DescuentoModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(MR_Referenciados_Codigo_de_DescuentoModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						MR_Referenciados_Codigo_de_DescuentoModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strMR_Referenciados_Codigo_de_DescuentoScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/MR_Referenciados_Codigo_de_Descuento.js")))
            {
                strMR_Referenciados_Codigo_de_DescuentoScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change MR_Referenciados_Codigo_de_Descuento element attributes
            string userChangeJson = jsSerialize.Serialize(MR_Referenciados_Codigo_de_DescuentoModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strMR_Referenciados_Codigo_de_DescuentoScript.IndexOf("inpuElementArray");
            string splittedString = strMR_Referenciados_Codigo_de_DescuentoScript.Substring(indexOfArray, strMR_Referenciados_Codigo_de_DescuentoScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(MR_Referenciados_Codigo_de_DescuentoModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (MR_Referenciados_Codigo_de_DescuentoModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strMR_Referenciados_Codigo_de_DescuentoScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strMR_Referenciados_Codigo_de_DescuentoScript.Substring(indexOfArrayHistory, strMR_Referenciados_Codigo_de_DescuentoScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strMR_Referenciados_Codigo_de_DescuentoScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strMR_Referenciados_Codigo_de_DescuentoScript.Substring(endIndexOfMainElement + indexOfArray, strMR_Referenciados_Codigo_de_DescuentoScript.Length - (endIndexOfMainElement + indexOfArray));
            if (MR_Referenciados_Codigo_de_DescuentoModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strMR_Referenciados_Codigo_de_DescuentoScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strMR_Referenciados_Codigo_de_DescuentoScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strMR_Referenciados_Codigo_de_DescuentoScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strMR_Referenciados_Codigo_de_DescuentoScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/MR_Referenciados_Codigo_de_Descuento.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/MR_Referenciados_Codigo_de_Descuento.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/MR_Referenciados_Codigo_de_Descuento.js")))
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
        public ActionResult MR_Referenciados_Codigo_de_DescuentoPropertyBag()
        {
            return PartialView("MR_Referenciados_Codigo_de_DescuentoPropertyBag", "MR_Referenciados_Codigo_de_Descuento");
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

            _IMR_Referenciados_Codigo_de_DescuentoApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new MR_Referenciados_Codigo_de_DescuentoPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMR_Referenciados_Codigo_de_DescuentoApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MR_Referenciados_Codigo_de_Descuentos == null)
                result.MR_Referenciados_Codigo_de_Descuentos = new List<MR_Referenciados_Codigo_de_Descuento>();

            var data = result.MR_Referenciados_Codigo_de_Descuentos.Select(m => new MR_Referenciados_Codigo_de_DescuentoGridModel
            {
                Folio = m.Folio
                ,Tipo_de_usuarioDescripcion = (string)m.Tipo_de_usuario_Tipo_Paciente.Descripcion
                ,UsuarioName = (string)m.Usuario_Spartan_User.Name
                ,Fecha_de_aplicacion = (m.Fecha_de_aplicacion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_aplicacion).ToString(ConfigurationProperty.DateFormat))
                ,Descuento_Total = m.Descuento_Total

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "MR_Referenciados_Codigo_de_DescuentoList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "MR_Referenciados_Codigo_de_DescuentoList_" + DateTime.Now.ToString());
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

            _IMR_Referenciados_Codigo_de_DescuentoApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new MR_Referenciados_Codigo_de_DescuentoPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMR_Referenciados_Codigo_de_DescuentoApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MR_Referenciados_Codigo_de_Descuentos == null)
                result.MR_Referenciados_Codigo_de_Descuentos = new List<MR_Referenciados_Codigo_de_Descuento>();

            var data = result.MR_Referenciados_Codigo_de_Descuentos.Select(m => new MR_Referenciados_Codigo_de_DescuentoGridModel
            {
                Folio = m.Folio
                ,Tipo_de_usuarioDescripcion = (string)m.Tipo_de_usuario_Tipo_Paciente.Descripcion
                ,UsuarioName = (string)m.Usuario_Spartan_User.Name
                ,Fecha_de_aplicacion = (m.Fecha_de_aplicacion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_aplicacion).ToString(ConfigurationProperty.DateFormat))
                ,Descuento_Total = m.Descuento_Total

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
