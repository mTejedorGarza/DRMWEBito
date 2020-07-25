using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.MR_Padecimientos;
using Spartane.Core.Domain.Padecimientos;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.MR_Padecimientos;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.MR_Padecimientos;
using Spartane.Web.Areas.WebApiConsumer.Padecimientos;

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
    public class MR_PadecimientosController : Controller
    {
        #region "variable declaration"

        private IMR_PadecimientosService service = null;
        private IMR_PadecimientosApiConsumer _IMR_PadecimientosApiConsumer;
        private IPadecimientosApiConsumer _IPadecimientosApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public MR_PadecimientosController(IMR_PadecimientosService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IMR_PadecimientosApiConsumer MR_PadecimientosApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , IPadecimientosApiConsumer PadecimientosApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IMR_PadecimientosApiConsumer = MR_PadecimientosApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._IPadecimientosApiConsumer = PadecimientosApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/MR_Padecimientos
        [ObjectAuth(ObjectId = (ModuleObjectId)44793, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44793);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/MR_Padecimientos/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44793, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44793);
            ViewBag.Permission = permission;
            var varMR_Padecimientos = new MR_PadecimientosModel();
			
            ViewBag.ObjectId = "44793";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMR_PadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var MR_PadecimientosData = _IMR_PadecimientosApiConsumer.GetByKeyComplete(Id).Resource.MR_Padecimientoss[0];
                if (MR_PadecimientosData == null)
                    return HttpNotFound();

                varMR_Padecimientos = new MR_PadecimientosModel
                {
                    Folio = (int)MR_PadecimientosData.Folio
                    ,Padecimiento = MR_PadecimientosData.Padecimiento
                    ,PadecimientoDescripcion = CultureHelper.GetTraduction(Convert.ToString(MR_PadecimientosData.Padecimiento), "Padecimientos") ??  (string)MR_PadecimientosData.Padecimiento_Padecimientos.Descripcion

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IPadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Padecimientoss_Padecimiento = _IPadecimientosApiConsumer.SelAll(true);
            if (Padecimientoss_Padecimiento != null && Padecimientoss_Padecimiento.Resource != null)
                ViewBag.Padecimientoss_Padecimiento = Padecimientoss_Padecimiento.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Padecimientos", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varMR_Padecimientos);
        }
		
	[HttpGet]
        public ActionResult AddMR_Padecimientos(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44793);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IMR_PadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);
			MR_PadecimientosModel varMR_Padecimientos= new MR_PadecimientosModel();


            if (id.ToString() != "0")
            {
                var MR_PadecimientossData = _IMR_PadecimientosApiConsumer.ListaSelAll(0, 1000, "MR_Padecimientos.Folio=" + id, "").Resource.MR_Padecimientoss;
				
				if (MR_PadecimientossData != null && MR_PadecimientossData.Count > 0)
                {
					var MR_PadecimientosData = MR_PadecimientossData.First();
					varMR_Padecimientos= new MR_PadecimientosModel
					{
						Folio  = MR_PadecimientosData.Folio 
	                    ,Padecimiento = MR_PadecimientosData.Padecimiento
                    ,PadecimientoDescripcion = CultureHelper.GetTraduction(Convert.ToString(MR_PadecimientosData.Padecimiento), "Padecimientos") ??  (string)MR_PadecimientosData.Padecimiento_Padecimientos.Descripcion

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IPadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Padecimientoss_Padecimiento = _IPadecimientosApiConsumer.SelAll(true);
            if (Padecimientoss_Padecimiento != null && Padecimientoss_Padecimiento.Resource != null)
                ViewBag.Padecimientoss_Padecimiento = Padecimientoss_Padecimiento.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Padecimientos", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddMR_Padecimientos", varMR_Padecimientos);
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
        public ActionResult GetPadecimientosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPadecimientosApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Padecimientos", "Descripcion")?? m.Descripcion,
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
                configuration = GridQueryHelper.GetConfiguration(filter, new MR_PadecimientosPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IMR_PadecimientosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MR_Padecimientoss == null)
                result.MR_Padecimientoss = new List<MR_Padecimientos>();

            return Json(new
            {
                data = result.MR_Padecimientoss.Select(m => new MR_PadecimientosGridModel
                    {
                    Folio = m.Folio
                        ,PadecimientoDescripcion = CultureHelper.GetTraduction(m.Padecimiento_Padecimientos.Clave.ToString(), "Descripcion") ?? (string)m.Padecimiento_Padecimientos.Descripcion

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
                _IMR_PadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);

                MR_Padecimientos varMR_Padecimientos = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IMR_PadecimientosApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, MR_PadecimientosModel varMR_Padecimientos)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IMR_PadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var MR_PadecimientosInfo = new MR_Padecimientos
                    {
                        Folio = varMR_Padecimientos.Folio
                        ,Padecimiento = varMR_Padecimientos.Padecimiento

                    };

                    result = !IsNew ?
                        _IMR_PadecimientosApiConsumer.Update(MR_PadecimientosInfo, null, null).Resource.ToString() :
                         _IMR_PadecimientosApiConsumer.Insert(MR_PadecimientosInfo, null, null).Resource.ToString();

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
        /// Write Element Array of MR_Padecimientos script
        /// </summary>
        /// <param name="oMR_PadecimientosElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements MR_PadecimientosModuleAttributeList)
        {
            for (int i = 0; i < MR_PadecimientosModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(MR_PadecimientosModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    MR_PadecimientosModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(MR_PadecimientosModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    MR_PadecimientosModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (MR_PadecimientosModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < MR_PadecimientosModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(MR_PadecimientosModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						MR_PadecimientosModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(MR_PadecimientosModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						MR_PadecimientosModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strMR_PadecimientosScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/MR_Padecimientos.js")))
            {
                strMR_PadecimientosScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change MR_Padecimientos element attributes
            string userChangeJson = jsSerialize.Serialize(MR_PadecimientosModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strMR_PadecimientosScript.IndexOf("inpuElementArray");
            string splittedString = strMR_PadecimientosScript.Substring(indexOfArray, strMR_PadecimientosScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(MR_PadecimientosModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (MR_PadecimientosModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strMR_PadecimientosScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strMR_PadecimientosScript.Substring(indexOfArrayHistory, strMR_PadecimientosScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strMR_PadecimientosScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strMR_PadecimientosScript.Substring(endIndexOfMainElement + indexOfArray, strMR_PadecimientosScript.Length - (endIndexOfMainElement + indexOfArray));
            if (MR_PadecimientosModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strMR_PadecimientosScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strMR_PadecimientosScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strMR_PadecimientosScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strMR_PadecimientosScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/MR_Padecimientos.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/MR_Padecimientos.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/MR_Padecimientos.js")))
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
        public ActionResult MR_PadecimientosPropertyBag()
        {
            return PartialView("MR_PadecimientosPropertyBag", "MR_Padecimientos");
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

            _IMR_PadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new MR_PadecimientosPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMR_PadecimientosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MR_Padecimientoss == null)
                result.MR_Padecimientoss = new List<MR_Padecimientos>();

            var data = result.MR_Padecimientoss.Select(m => new MR_PadecimientosGridModel
            {
                Folio = m.Folio
                ,PadecimientoDescripcion = (string)m.Padecimiento_Padecimientos.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "MR_PadecimientosList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "MR_PadecimientosList_" + DateTime.Now.ToString());
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

            _IMR_PadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new MR_PadecimientosPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMR_PadecimientosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MR_Padecimientoss == null)
                result.MR_Padecimientoss = new List<MR_Padecimientos>();

            var data = result.MR_Padecimientoss.Select(m => new MR_PadecimientosGridModel
            {
                Folio = m.Folio
                ,PadecimientoDescripcion = (string)m.Padecimiento_Padecimientos.Descripcion

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
