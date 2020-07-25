using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.MS_Uso_del_Ejercicio;
using Spartane.Core.Domain.Tipo_de_Ejercicio_Rutina;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.MS_Uso_del_Ejercicio;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.MS_Uso_del_Ejercicio;
using Spartane.Web.Areas.WebApiConsumer.Tipo_de_Ejercicio_Rutina;

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
    public class MS_Uso_del_EjercicioController : Controller
    {
        #region "variable declaration"

        private IMS_Uso_del_EjercicioService service = null;
        private IMS_Uso_del_EjercicioApiConsumer _IMS_Uso_del_EjercicioApiConsumer;
        private ITipo_de_Ejercicio_RutinaApiConsumer _ITipo_de_Ejercicio_RutinaApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public MS_Uso_del_EjercicioController(IMS_Uso_del_EjercicioService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IMS_Uso_del_EjercicioApiConsumer MS_Uso_del_EjercicioApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , ITipo_de_Ejercicio_RutinaApiConsumer Tipo_de_Ejercicio_RutinaApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IMS_Uso_del_EjercicioApiConsumer = MS_Uso_del_EjercicioApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ITipo_de_Ejercicio_RutinaApiConsumer = Tipo_de_Ejercicio_RutinaApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/MS_Uso_del_Ejercicio
        [ObjectAuth(ObjectId = (ModuleObjectId)44612, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44612);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/MS_Uso_del_Ejercicio/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44612, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44612);
            ViewBag.Permission = permission;
            var varMS_Uso_del_Ejercicio = new MS_Uso_del_EjercicioModel();
			
            ViewBag.ObjectId = "44612";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMS_Uso_del_EjercicioApiConsumer.SetAuthHeader(_tokenManager.Token);
                var MS_Uso_del_EjercicioData = _IMS_Uso_del_EjercicioApiConsumer.GetByKeyComplete(Id).Resource.MS_Uso_del_Ejercicios[0];
                if (MS_Uso_del_EjercicioData == null)
                    return HttpNotFound();

                varMS_Uso_del_Ejercicio = new MS_Uso_del_EjercicioModel
                {
                    Folio = (int)MS_Uso_del_EjercicioData.Folio
                    ,Uso_del_Ejercicio = MS_Uso_del_EjercicioData.Uso_del_Ejercicio
                    ,Uso_del_EjercicioDescripcion = CultureHelper.GetTraduction(Convert.ToString(MS_Uso_del_EjercicioData.Uso_del_Ejercicio), "Tipo_de_Ejercicio_Rutina") ??  (string)MS_Uso_del_EjercicioData.Uso_del_Ejercicio_Tipo_de_Ejercicio_Rutina.Descripcion

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ITipo_de_Ejercicio_RutinaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Ejercicio_Rutinas_Uso_del_Ejercicio = _ITipo_de_Ejercicio_RutinaApiConsumer.SelAll(true);
            if (Tipo_de_Ejercicio_Rutinas_Uso_del_Ejercicio != null && Tipo_de_Ejercicio_Rutinas_Uso_del_Ejercicio.Resource != null)
                ViewBag.Tipo_de_Ejercicio_Rutinas_Uso_del_Ejercicio = Tipo_de_Ejercicio_Rutinas_Uso_del_Ejercicio.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Tipo_de_Ejercicio_Rutina", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varMS_Uso_del_Ejercicio);
        }
		
	[HttpGet]
        public ActionResult AddMS_Uso_del_Ejercicio(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44612);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IMS_Uso_del_EjercicioApiConsumer.SetAuthHeader(_tokenManager.Token);
			MS_Uso_del_EjercicioModel varMS_Uso_del_Ejercicio= new MS_Uso_del_EjercicioModel();


            if (id.ToString() != "0")
            {
                var MS_Uso_del_EjerciciosData = _IMS_Uso_del_EjercicioApiConsumer.ListaSelAll(0, 1000, "MS_Uso_del_Ejercicio.Folio=" + id, "").Resource.MS_Uso_del_Ejercicios;
				
				if (MS_Uso_del_EjerciciosData != null && MS_Uso_del_EjerciciosData.Count > 0)
                {
					var MS_Uso_del_EjercicioData = MS_Uso_del_EjerciciosData.First();
					varMS_Uso_del_Ejercicio= new MS_Uso_del_EjercicioModel
					{
						Folio  = MS_Uso_del_EjercicioData.Folio 
	                    ,Uso_del_Ejercicio = MS_Uso_del_EjercicioData.Uso_del_Ejercicio
                    ,Uso_del_EjercicioDescripcion = CultureHelper.GetTraduction(Convert.ToString(MS_Uso_del_EjercicioData.Uso_del_Ejercicio), "Tipo_de_Ejercicio_Rutina") ??  (string)MS_Uso_del_EjercicioData.Uso_del_Ejercicio_Tipo_de_Ejercicio_Rutina.Descripcion

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ITipo_de_Ejercicio_RutinaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Ejercicio_Rutinas_Uso_del_Ejercicio = _ITipo_de_Ejercicio_RutinaApiConsumer.SelAll(true);
            if (Tipo_de_Ejercicio_Rutinas_Uso_del_Ejercicio != null && Tipo_de_Ejercicio_Rutinas_Uso_del_Ejercicio.Resource != null)
                ViewBag.Tipo_de_Ejercicio_Rutinas_Uso_del_Ejercicio = Tipo_de_Ejercicio_Rutinas_Uso_del_Ejercicio.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Tipo_de_Ejercicio_Rutina", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            return PartialView("AddMS_Uso_del_Ejercicio", varMS_Uso_del_Ejercicio);
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
        public ActionResult GetTipo_de_Ejercicio_RutinaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipo_de_Ejercicio_RutinaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipo_de_Ejercicio_RutinaApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Tipo_de_Ejercicio_Rutina", "Descripcion")?? m.Descripcion,
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
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_Uso_del_EjercicioPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IMS_Uso_del_EjercicioApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Uso_del_Ejercicios == null)
                result.MS_Uso_del_Ejercicios = new List<MS_Uso_del_Ejercicio>();

            return Json(new
            {
                data = result.MS_Uso_del_Ejercicios.Select(m => new MS_Uso_del_EjercicioGridModel
                    {
                    Folio = m.Folio
                        ,Uso_del_EjercicioDescripcion = CultureHelper.GetTraduction(m.Uso_del_Ejercicio_Tipo_de_Ejercicio_Rutina.Folio.ToString(), "Descripcion") ?? (string)m.Uso_del_Ejercicio_Tipo_de_Ejercicio_Rutina.Descripcion

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
                _IMS_Uso_del_EjercicioApiConsumer.SetAuthHeader(_tokenManager.Token);

                MS_Uso_del_Ejercicio varMS_Uso_del_Ejercicio = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IMS_Uso_del_EjercicioApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, MS_Uso_del_EjercicioModel varMS_Uso_del_Ejercicio)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IMS_Uso_del_EjercicioApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var MS_Uso_del_EjercicioInfo = new MS_Uso_del_Ejercicio
                    {
                        Folio = varMS_Uso_del_Ejercicio.Folio
                        ,Uso_del_Ejercicio = varMS_Uso_del_Ejercicio.Uso_del_Ejercicio

                    };

                    result = !IsNew ?
                        _IMS_Uso_del_EjercicioApiConsumer.Update(MS_Uso_del_EjercicioInfo, null, null).Resource.ToString() :
                         _IMS_Uso_del_EjercicioApiConsumer.Insert(MS_Uso_del_EjercicioInfo, null, null).Resource.ToString();

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
        /// Write Element Array of MS_Uso_del_Ejercicio script
        /// </summary>
        /// <param name="oMS_Uso_del_EjercicioElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements MS_Uso_del_EjercicioModuleAttributeList)
        {
            for (int i = 0; i < MS_Uso_del_EjercicioModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(MS_Uso_del_EjercicioModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    MS_Uso_del_EjercicioModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(MS_Uso_del_EjercicioModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    MS_Uso_del_EjercicioModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (MS_Uso_del_EjercicioModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < MS_Uso_del_EjercicioModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(MS_Uso_del_EjercicioModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						MS_Uso_del_EjercicioModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(MS_Uso_del_EjercicioModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						MS_Uso_del_EjercicioModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strMS_Uso_del_EjercicioScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/MS_Uso_del_Ejercicio.js")))
            {
                strMS_Uso_del_EjercicioScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change MS_Uso_del_Ejercicio element attributes
            string userChangeJson = jsSerialize.Serialize(MS_Uso_del_EjercicioModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strMS_Uso_del_EjercicioScript.IndexOf("inpuElementArray");
            string splittedString = strMS_Uso_del_EjercicioScript.Substring(indexOfArray, strMS_Uso_del_EjercicioScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(MS_Uso_del_EjercicioModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (MS_Uso_del_EjercicioModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strMS_Uso_del_EjercicioScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strMS_Uso_del_EjercicioScript.Substring(indexOfArrayHistory, strMS_Uso_del_EjercicioScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strMS_Uso_del_EjercicioScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strMS_Uso_del_EjercicioScript.Substring(endIndexOfMainElement + indexOfArray, strMS_Uso_del_EjercicioScript.Length - (endIndexOfMainElement + indexOfArray));
            if (MS_Uso_del_EjercicioModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strMS_Uso_del_EjercicioScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strMS_Uso_del_EjercicioScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strMS_Uso_del_EjercicioScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strMS_Uso_del_EjercicioScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/MS_Uso_del_Ejercicio.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/MS_Uso_del_Ejercicio.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/MS_Uso_del_Ejercicio.js")))
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
        public ActionResult MS_Uso_del_EjercicioPropertyBag()
        {
            return PartialView("MS_Uso_del_EjercicioPropertyBag", "MS_Uso_del_Ejercicio");
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

            _IMS_Uso_del_EjercicioApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_Uso_del_EjercicioPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMS_Uso_del_EjercicioApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Uso_del_Ejercicios == null)
                result.MS_Uso_del_Ejercicios = new List<MS_Uso_del_Ejercicio>();

            var data = result.MS_Uso_del_Ejercicios.Select(m => new MS_Uso_del_EjercicioGridModel
            {
                Folio = m.Folio
                ,Uso_del_EjercicioDescripcion = (string)m.Uso_del_Ejercicio_Tipo_de_Ejercicio_Rutina.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "MS_Uso_del_EjercicioList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "MS_Uso_del_EjercicioList_" + DateTime.Now.ToString());
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

            _IMS_Uso_del_EjercicioApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_Uso_del_EjercicioPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMS_Uso_del_EjercicioApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Uso_del_Ejercicios == null)
                result.MS_Uso_del_Ejercicios = new List<MS_Uso_del_Ejercicio>();

            var data = result.MS_Uso_del_Ejercicios.Select(m => new MS_Uso_del_EjercicioGridModel
            {
                Folio = m.Folio
                ,Uso_del_EjercicioDescripcion = (string)m.Uso_del_Ejercicio_Tipo_de_Ejercicio_Rutina.Descripcion

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
