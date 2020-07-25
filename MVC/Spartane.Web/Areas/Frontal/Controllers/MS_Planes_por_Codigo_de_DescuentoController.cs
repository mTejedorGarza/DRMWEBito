using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.MS_Planes_por_Codigo_de_Descuento;
using Spartane.Core.Domain.Planes_de_Suscripcion;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.MS_Planes_por_Codigo_de_Descuento;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.MS_Planes_por_Codigo_de_Descuento;
using Spartane.Web.Areas.WebApiConsumer.Planes_de_Suscripcion;

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
    public class MS_Planes_por_Codigo_de_DescuentoController : Controller
    {
        #region "variable declaration"

        private IMS_Planes_por_Codigo_de_DescuentoService service = null;
        private IMS_Planes_por_Codigo_de_DescuentoApiConsumer _IMS_Planes_por_Codigo_de_DescuentoApiConsumer;
        private IPlanes_de_SuscripcionApiConsumer _IPlanes_de_SuscripcionApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public MS_Planes_por_Codigo_de_DescuentoController(IMS_Planes_por_Codigo_de_DescuentoService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IMS_Planes_por_Codigo_de_DescuentoApiConsumer MS_Planes_por_Codigo_de_DescuentoApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , IPlanes_de_SuscripcionApiConsumer Planes_de_SuscripcionApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IMS_Planes_por_Codigo_de_DescuentoApiConsumer = MS_Planes_por_Codigo_de_DescuentoApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._IPlanes_de_SuscripcionApiConsumer = Planes_de_SuscripcionApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/MS_Planes_por_Codigo_de_Descuento
        [ObjectAuth(ObjectId = (ModuleObjectId)44738, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44738);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/MS_Planes_por_Codigo_de_Descuento/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44738, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44738);
            ViewBag.Permission = permission;
            var varMS_Planes_por_Codigo_de_Descuento = new MS_Planes_por_Codigo_de_DescuentoModel();
			
            ViewBag.ObjectId = "44738";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMS_Planes_por_Codigo_de_DescuentoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var MS_Planes_por_Codigo_de_DescuentoData = _IMS_Planes_por_Codigo_de_DescuentoApiConsumer.GetByKeyComplete(Id).Resource.MS_Planes_por_Codigo_de_Descuentos[0];
                if (MS_Planes_por_Codigo_de_DescuentoData == null)
                    return HttpNotFound();

                varMS_Planes_por_Codigo_de_Descuento = new MS_Planes_por_Codigo_de_DescuentoModel
                {
                    Folio = (int)MS_Planes_por_Codigo_de_DescuentoData.Folio
                    ,Planes_de_Suscripcion = MS_Planes_por_Codigo_de_DescuentoData.Planes_de_Suscripcion
                    ,Planes_de_SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(Convert.ToString(MS_Planes_por_Codigo_de_DescuentoData.Planes_de_Suscripcion), "Planes_de_Suscripcion") ??  (string)MS_Planes_por_Codigo_de_DescuentoData.Planes_de_Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Planes_de_Suscripcions_Planes_de_Suscripcion = _IPlanes_de_SuscripcionApiConsumer.SelAll(true);
            if (Planes_de_Suscripcions_Planes_de_Suscripcion != null && Planes_de_Suscripcions_Planes_de_Suscripcion.Resource != null)
                ViewBag.Planes_de_Suscripcions_Planes_de_Suscripcion = Planes_de_Suscripcions_Planes_de_Suscripcion.Resource.Where(m => m.Nombre_del_Plan != null).OrderBy(m => m.Nombre_del_Plan).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Planes_de_Suscripcion", "Nombre_del_Plan") ?? m.Nombre_del_Plan.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varMS_Planes_por_Codigo_de_Descuento);
        }
		
	[HttpGet]
        public ActionResult AddMS_Planes_por_Codigo_de_Descuento(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44738);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IMS_Planes_por_Codigo_de_DescuentoApiConsumer.SetAuthHeader(_tokenManager.Token);
			MS_Planes_por_Codigo_de_DescuentoModel varMS_Planes_por_Codigo_de_Descuento= new MS_Planes_por_Codigo_de_DescuentoModel();


            if (id.ToString() != "0")
            {
                var MS_Planes_por_Codigo_de_DescuentosData = _IMS_Planes_por_Codigo_de_DescuentoApiConsumer.ListaSelAll(0, 1000, "MS_Planes_por_Codigo_de_Descuento.Folio=" + id, "").Resource.MS_Planes_por_Codigo_de_Descuentos;
				
				if (MS_Planes_por_Codigo_de_DescuentosData != null && MS_Planes_por_Codigo_de_DescuentosData.Count > 0)
                {
					var MS_Planes_por_Codigo_de_DescuentoData = MS_Planes_por_Codigo_de_DescuentosData.First();
					varMS_Planes_por_Codigo_de_Descuento= new MS_Planes_por_Codigo_de_DescuentoModel
					{
						Folio  = MS_Planes_por_Codigo_de_DescuentoData.Folio 
	                    ,Planes_de_Suscripcion = MS_Planes_por_Codigo_de_DescuentoData.Planes_de_Suscripcion
                    ,Planes_de_SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(Convert.ToString(MS_Planes_por_Codigo_de_DescuentoData.Planes_de_Suscripcion), "Planes_de_Suscripcion") ??  (string)MS_Planes_por_Codigo_de_DescuentoData.Planes_de_Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Planes_de_Suscripcions_Planes_de_Suscripcion = _IPlanes_de_SuscripcionApiConsumer.SelAll(true);
            if (Planes_de_Suscripcions_Planes_de_Suscripcion != null && Planes_de_Suscripcions_Planes_de_Suscripcion.Resource != null)
                ViewBag.Planes_de_Suscripcions_Planes_de_Suscripcion = Planes_de_Suscripcions_Planes_de_Suscripcion.Resource.Where(m => m.Nombre_del_Plan != null).OrderBy(m => m.Nombre_del_Plan).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Planes_de_Suscripcion", "Nombre_del_Plan") ?? m.Nombre_del_Plan.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            return PartialView("AddMS_Planes_por_Codigo_de_Descuento", varMS_Planes_por_Codigo_de_Descuento);
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
        public ActionResult GetPlanes_de_SuscripcionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPlanes_de_SuscripcionApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Nombre_del_Plan).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Planes_de_Suscripcion", "Nombre_del_Plan")?? m.Nombre_del_Plan,
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
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_Planes_por_Codigo_de_DescuentoPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IMS_Planes_por_Codigo_de_DescuentoApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Planes_por_Codigo_de_Descuentos == null)
                result.MS_Planes_por_Codigo_de_Descuentos = new List<MS_Planes_por_Codigo_de_Descuento>();

            return Json(new
            {
                data = result.MS_Planes_por_Codigo_de_Descuentos.Select(m => new MS_Planes_por_Codigo_de_DescuentoGridModel
                    {
                    Folio = m.Folio
                        ,Planes_de_SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(m.Planes_de_Suscripcion_Planes_de_Suscripcion.Folio.ToString(), "Nombre_del_Plan") ?? (string)m.Planes_de_Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan

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
                _IMS_Planes_por_Codigo_de_DescuentoApiConsumer.SetAuthHeader(_tokenManager.Token);

                MS_Planes_por_Codigo_de_Descuento varMS_Planes_por_Codigo_de_Descuento = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IMS_Planes_por_Codigo_de_DescuentoApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, MS_Planes_por_Codigo_de_DescuentoModel varMS_Planes_por_Codigo_de_Descuento)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IMS_Planes_por_Codigo_de_DescuentoApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var MS_Planes_por_Codigo_de_DescuentoInfo = new MS_Planes_por_Codigo_de_Descuento
                    {
                        Folio = varMS_Planes_por_Codigo_de_Descuento.Folio
                        ,Planes_de_Suscripcion = varMS_Planes_por_Codigo_de_Descuento.Planes_de_Suscripcion

                    };

                    result = !IsNew ?
                        _IMS_Planes_por_Codigo_de_DescuentoApiConsumer.Update(MS_Planes_por_Codigo_de_DescuentoInfo, null, null).Resource.ToString() :
                         _IMS_Planes_por_Codigo_de_DescuentoApiConsumer.Insert(MS_Planes_por_Codigo_de_DescuentoInfo, null, null).Resource.ToString();

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
        /// Write Element Array of MS_Planes_por_Codigo_de_Descuento script
        /// </summary>
        /// <param name="oMS_Planes_por_Codigo_de_DescuentoElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements MS_Planes_por_Codigo_de_DescuentoModuleAttributeList)
        {
            for (int i = 0; i < MS_Planes_por_Codigo_de_DescuentoModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(MS_Planes_por_Codigo_de_DescuentoModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    MS_Planes_por_Codigo_de_DescuentoModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(MS_Planes_por_Codigo_de_DescuentoModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    MS_Planes_por_Codigo_de_DescuentoModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (MS_Planes_por_Codigo_de_DescuentoModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < MS_Planes_por_Codigo_de_DescuentoModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(MS_Planes_por_Codigo_de_DescuentoModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						MS_Planes_por_Codigo_de_DescuentoModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(MS_Planes_por_Codigo_de_DescuentoModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						MS_Planes_por_Codigo_de_DescuentoModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strMS_Planes_por_Codigo_de_DescuentoScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/MS_Planes_por_Codigo_de_Descuento.js")))
            {
                strMS_Planes_por_Codigo_de_DescuentoScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change MS_Planes_por_Codigo_de_Descuento element attributes
            string userChangeJson = jsSerialize.Serialize(MS_Planes_por_Codigo_de_DescuentoModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strMS_Planes_por_Codigo_de_DescuentoScript.IndexOf("inpuElementArray");
            string splittedString = strMS_Planes_por_Codigo_de_DescuentoScript.Substring(indexOfArray, strMS_Planes_por_Codigo_de_DescuentoScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(MS_Planes_por_Codigo_de_DescuentoModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (MS_Planes_por_Codigo_de_DescuentoModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strMS_Planes_por_Codigo_de_DescuentoScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strMS_Planes_por_Codigo_de_DescuentoScript.Substring(indexOfArrayHistory, strMS_Planes_por_Codigo_de_DescuentoScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strMS_Planes_por_Codigo_de_DescuentoScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strMS_Planes_por_Codigo_de_DescuentoScript.Substring(endIndexOfMainElement + indexOfArray, strMS_Planes_por_Codigo_de_DescuentoScript.Length - (endIndexOfMainElement + indexOfArray));
            if (MS_Planes_por_Codigo_de_DescuentoModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strMS_Planes_por_Codigo_de_DescuentoScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strMS_Planes_por_Codigo_de_DescuentoScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strMS_Planes_por_Codigo_de_DescuentoScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strMS_Planes_por_Codigo_de_DescuentoScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/MS_Planes_por_Codigo_de_Descuento.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/MS_Planes_por_Codigo_de_Descuento.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/MS_Planes_por_Codigo_de_Descuento.js")))
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
        public ActionResult MS_Planes_por_Codigo_de_DescuentoPropertyBag()
        {
            return PartialView("MS_Planes_por_Codigo_de_DescuentoPropertyBag", "MS_Planes_por_Codigo_de_Descuento");
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

            _IMS_Planes_por_Codigo_de_DescuentoApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_Planes_por_Codigo_de_DescuentoPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMS_Planes_por_Codigo_de_DescuentoApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Planes_por_Codigo_de_Descuentos == null)
                result.MS_Planes_por_Codigo_de_Descuentos = new List<MS_Planes_por_Codigo_de_Descuento>();

            var data = result.MS_Planes_por_Codigo_de_Descuentos.Select(m => new MS_Planes_por_Codigo_de_DescuentoGridModel
            {
                Folio = m.Folio
                ,Planes_de_SuscripcionNombre_del_Plan = (string)m.Planes_de_Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "MS_Planes_por_Codigo_de_DescuentoList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "MS_Planes_por_Codigo_de_DescuentoList_" + DateTime.Now.ToString());
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

            _IMS_Planes_por_Codigo_de_DescuentoApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_Planes_por_Codigo_de_DescuentoPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMS_Planes_por_Codigo_de_DescuentoApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Planes_por_Codigo_de_Descuentos == null)
                result.MS_Planes_por_Codigo_de_Descuentos = new List<MS_Planes_por_Codigo_de_Descuento>();

            var data = result.MS_Planes_por_Codigo_de_Descuentos.Select(m => new MS_Planes_por_Codigo_de_DescuentoGridModel
            {
                Folio = m.Folio
                ,Planes_de_SuscripcionNombre_del_Plan = (string)m.Planes_de_Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
