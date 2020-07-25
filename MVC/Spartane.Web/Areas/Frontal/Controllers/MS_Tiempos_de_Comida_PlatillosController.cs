using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.MS_Tiempos_de_Comida_Platillos;
using Spartane.Core.Domain.Tiempos_de_Comida;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.MS_Tiempos_de_Comida_Platillos;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.MS_Tiempos_de_Comida_Platillos;
using Spartane.Web.Areas.WebApiConsumer.Tiempos_de_Comida;

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
    public class MS_Tiempos_de_Comida_PlatillosController : Controller
    {
        #region "variable declaration"

        private IMS_Tiempos_de_Comida_PlatillosService service = null;
        private IMS_Tiempos_de_Comida_PlatillosApiConsumer _IMS_Tiempos_de_Comida_PlatillosApiConsumer;
        private ITiempos_de_ComidaApiConsumer _ITiempos_de_ComidaApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public MS_Tiempos_de_Comida_PlatillosController(IMS_Tiempos_de_Comida_PlatillosService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IMS_Tiempos_de_Comida_PlatillosApiConsumer MS_Tiempos_de_Comida_PlatillosApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , ITiempos_de_ComidaApiConsumer Tiempos_de_ComidaApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IMS_Tiempos_de_Comida_PlatillosApiConsumer = MS_Tiempos_de_Comida_PlatillosApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ITiempos_de_ComidaApiConsumer = Tiempos_de_ComidaApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/MS_Tiempos_de_Comida_Platillos
        [ObjectAuth(ObjectId = (ModuleObjectId)44733, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44733);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/MS_Tiempos_de_Comida_Platillos/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44733, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44733);
            ViewBag.Permission = permission;
            var varMS_Tiempos_de_Comida_Platillos = new MS_Tiempos_de_Comida_PlatillosModel();
			
            ViewBag.ObjectId = "44733";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMS_Tiempos_de_Comida_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var MS_Tiempos_de_Comida_PlatillosData = _IMS_Tiempos_de_Comida_PlatillosApiConsumer.GetByKeyComplete(Id).Resource.MS_Tiempos_de_Comida_Platilloss[0];
                if (MS_Tiempos_de_Comida_PlatillosData == null)
                    return HttpNotFound();

                varMS_Tiempos_de_Comida_Platillos = new MS_Tiempos_de_Comida_PlatillosModel
                {
                    Folio = (int)MS_Tiempos_de_Comida_PlatillosData.Folio
                    ,Tiempo_de_Comida = MS_Tiempos_de_Comida_PlatillosData.Tiempo_de_Comida
                    ,Tiempo_de_ComidaComida = CultureHelper.GetTraduction(Convert.ToString(MS_Tiempos_de_Comida_PlatillosData.Tiempo_de_Comida), "Tiempos_de_Comida") ??  (string)MS_Tiempos_de_Comida_PlatillosData.Tiempo_de_Comida_Tiempos_de_Comida.Comida

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ITiempos_de_ComidaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tiempos_de_Comidas_Tiempo_de_Comida = _ITiempos_de_ComidaApiConsumer.SelAll(true);
            if (Tiempos_de_Comidas_Tiempo_de_Comida != null && Tiempos_de_Comidas_Tiempo_de_Comida.Resource != null)
                ViewBag.Tiempos_de_Comidas_Tiempo_de_Comida = Tiempos_de_Comidas_Tiempo_de_Comida.Resource.Where(m => m.Comida != null).OrderBy(m => m.Comida).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tiempos_de_Comida", "Comida") ?? m.Comida.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varMS_Tiempos_de_Comida_Platillos);
        }
		
	[HttpGet]
        public ActionResult AddMS_Tiempos_de_Comida_Platillos(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44733);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IMS_Tiempos_de_Comida_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);
			MS_Tiempos_de_Comida_PlatillosModel varMS_Tiempos_de_Comida_Platillos= new MS_Tiempos_de_Comida_PlatillosModel();


            if (id.ToString() != "0")
            {
                var MS_Tiempos_de_Comida_PlatillossData = _IMS_Tiempos_de_Comida_PlatillosApiConsumer.ListaSelAll(0, 1000, "MS_Tiempos_de_Comida_Platillos.Folio=" + id, "").Resource.MS_Tiempos_de_Comida_Platilloss;
				
				if (MS_Tiempos_de_Comida_PlatillossData != null && MS_Tiempos_de_Comida_PlatillossData.Count > 0)
                {
					var MS_Tiempos_de_Comida_PlatillosData = MS_Tiempos_de_Comida_PlatillossData.First();
					varMS_Tiempos_de_Comida_Platillos= new MS_Tiempos_de_Comida_PlatillosModel
					{
						Folio  = MS_Tiempos_de_Comida_PlatillosData.Folio 
	                    ,Tiempo_de_Comida = MS_Tiempos_de_Comida_PlatillosData.Tiempo_de_Comida
                    ,Tiempo_de_ComidaComida = CultureHelper.GetTraduction(Convert.ToString(MS_Tiempos_de_Comida_PlatillosData.Tiempo_de_Comida), "Tiempos_de_Comida") ??  (string)MS_Tiempos_de_Comida_PlatillosData.Tiempo_de_Comida_Tiempos_de_Comida.Comida

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ITiempos_de_ComidaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tiempos_de_Comidas_Tiempo_de_Comida = _ITiempos_de_ComidaApiConsumer.SelAll(true);
            if (Tiempos_de_Comidas_Tiempo_de_Comida != null && Tiempos_de_Comidas_Tiempo_de_Comida.Resource != null)
                ViewBag.Tiempos_de_Comidas_Tiempo_de_Comida = Tiempos_de_Comidas_Tiempo_de_Comida.Resource.Where(m => m.Comida != null).OrderBy(m => m.Comida).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tiempos_de_Comida", "Comida") ?? m.Comida.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddMS_Tiempos_de_Comida_Platillos", varMS_Tiempos_de_Comida_Platillos);
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
        public ActionResult GetTiempos_de_ComidaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITiempos_de_ComidaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITiempos_de_ComidaApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Comida).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tiempos_de_Comida", "Comida")?? m.Comida,
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
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_Tiempos_de_Comida_PlatillosPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IMS_Tiempos_de_Comida_PlatillosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Tiempos_de_Comida_Platilloss == null)
                result.MS_Tiempos_de_Comida_Platilloss = new List<MS_Tiempos_de_Comida_Platillos>();

            return Json(new
            {
                data = result.MS_Tiempos_de_Comida_Platilloss.Select(m => new MS_Tiempos_de_Comida_PlatillosGridModel
                    {
                    Folio = m.Folio
                        ,Tiempo_de_ComidaComida = CultureHelper.GetTraduction(m.Tiempo_de_Comida_Tiempos_de_Comida.Clave.ToString(), "Comida") ?? (string)m.Tiempo_de_Comida_Tiempos_de_Comida.Comida

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
                _IMS_Tiempos_de_Comida_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);

                MS_Tiempos_de_Comida_Platillos varMS_Tiempos_de_Comida_Platillos = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IMS_Tiempos_de_Comida_PlatillosApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, MS_Tiempos_de_Comida_PlatillosModel varMS_Tiempos_de_Comida_Platillos)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IMS_Tiempos_de_Comida_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var MS_Tiempos_de_Comida_PlatillosInfo = new MS_Tiempos_de_Comida_Platillos
                    {
                        Folio = varMS_Tiempos_de_Comida_Platillos.Folio
                        ,Tiempo_de_Comida = varMS_Tiempos_de_Comida_Platillos.Tiempo_de_Comida

                    };

                    result = !IsNew ?
                        _IMS_Tiempos_de_Comida_PlatillosApiConsumer.Update(MS_Tiempos_de_Comida_PlatillosInfo, null, null).Resource.ToString() :
                         _IMS_Tiempos_de_Comida_PlatillosApiConsumer.Insert(MS_Tiempos_de_Comida_PlatillosInfo, null, null).Resource.ToString();

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
        /// Write Element Array of MS_Tiempos_de_Comida_Platillos script
        /// </summary>
        /// <param name="oMS_Tiempos_de_Comida_PlatillosElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements MS_Tiempos_de_Comida_PlatillosModuleAttributeList)
        {
            for (int i = 0; i < MS_Tiempos_de_Comida_PlatillosModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(MS_Tiempos_de_Comida_PlatillosModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    MS_Tiempos_de_Comida_PlatillosModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(MS_Tiempos_de_Comida_PlatillosModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    MS_Tiempos_de_Comida_PlatillosModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (MS_Tiempos_de_Comida_PlatillosModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < MS_Tiempos_de_Comida_PlatillosModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(MS_Tiempos_de_Comida_PlatillosModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						MS_Tiempos_de_Comida_PlatillosModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(MS_Tiempos_de_Comida_PlatillosModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						MS_Tiempos_de_Comida_PlatillosModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strMS_Tiempos_de_Comida_PlatillosScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/MS_Tiempos_de_Comida_Platillos.js")))
            {
                strMS_Tiempos_de_Comida_PlatillosScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change MS_Tiempos_de_Comida_Platillos element attributes
            string userChangeJson = jsSerialize.Serialize(MS_Tiempos_de_Comida_PlatillosModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strMS_Tiempos_de_Comida_PlatillosScript.IndexOf("inpuElementArray");
            string splittedString = strMS_Tiempos_de_Comida_PlatillosScript.Substring(indexOfArray, strMS_Tiempos_de_Comida_PlatillosScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(MS_Tiempos_de_Comida_PlatillosModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (MS_Tiempos_de_Comida_PlatillosModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strMS_Tiempos_de_Comida_PlatillosScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strMS_Tiempos_de_Comida_PlatillosScript.Substring(indexOfArrayHistory, strMS_Tiempos_de_Comida_PlatillosScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strMS_Tiempos_de_Comida_PlatillosScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strMS_Tiempos_de_Comida_PlatillosScript.Substring(endIndexOfMainElement + indexOfArray, strMS_Tiempos_de_Comida_PlatillosScript.Length - (endIndexOfMainElement + indexOfArray));
            if (MS_Tiempos_de_Comida_PlatillosModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strMS_Tiempos_de_Comida_PlatillosScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strMS_Tiempos_de_Comida_PlatillosScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strMS_Tiempos_de_Comida_PlatillosScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strMS_Tiempos_de_Comida_PlatillosScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/MS_Tiempos_de_Comida_Platillos.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/MS_Tiempos_de_Comida_Platillos.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/MS_Tiempos_de_Comida_Platillos.js")))
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
        public ActionResult MS_Tiempos_de_Comida_PlatillosPropertyBag()
        {
            return PartialView("MS_Tiempos_de_Comida_PlatillosPropertyBag", "MS_Tiempos_de_Comida_Platillos");
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

            _IMS_Tiempos_de_Comida_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_Tiempos_de_Comida_PlatillosPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMS_Tiempos_de_Comida_PlatillosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Tiempos_de_Comida_Platilloss == null)
                result.MS_Tiempos_de_Comida_Platilloss = new List<MS_Tiempos_de_Comida_Platillos>();

            var data = result.MS_Tiempos_de_Comida_Platilloss.Select(m => new MS_Tiempos_de_Comida_PlatillosGridModel
            {
                Folio = m.Folio
                ,Tiempo_de_ComidaComida = (string)m.Tiempo_de_Comida_Tiempos_de_Comida.Comida

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "MS_Tiempos_de_Comida_PlatillosList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "MS_Tiempos_de_Comida_PlatillosList_" + DateTime.Now.ToString());
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

            _IMS_Tiempos_de_Comida_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_Tiempos_de_Comida_PlatillosPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMS_Tiempos_de_Comida_PlatillosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Tiempos_de_Comida_Platilloss == null)
                result.MS_Tiempos_de_Comida_Platilloss = new List<MS_Tiempos_de_Comida_Platillos>();

            var data = result.MS_Tiempos_de_Comida_Platilloss.Select(m => new MS_Tiempos_de_Comida_PlatillosGridModel
            {
                Folio = m.Folio
                ,Tiempo_de_ComidaComida = (string)m.Tiempo_de_Comida_Tiempos_de_Comida.Comida

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
