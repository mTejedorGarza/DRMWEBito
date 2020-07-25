using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Rangos_Pediatria_por_Platillos;
using Spartane.Core.Domain.MR_Padecimientos;

using Spartane.Core.Domain.Padecimientos;


using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Rangos_Pediatria_por_Platillos;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Rangos_Pediatria_por_Platillos;
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
    public class Rangos_Pediatria_por_PlatillosController : Controller
    {
        #region "variable declaration"

        private IRangos_Pediatria_por_PlatillosService service = null;
        private IRangos_Pediatria_por_PlatillosApiConsumer _IRangos_Pediatria_por_PlatillosApiConsumer;
        private IMR_PadecimientosApiConsumer _IMR_PadecimientosApiConsumer;

        private IPadecimientosApiConsumer _IPadecimientosApiConsumer;


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

        
        public Rangos_Pediatria_por_PlatillosController(IRangos_Pediatria_por_PlatillosService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IRangos_Pediatria_por_PlatillosApiConsumer Rangos_Pediatria_por_PlatillosApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer , IMR_PadecimientosApiConsumer MR_PadecimientosApiConsumer , IPadecimientosApiConsumer PadecimientosApiConsumer  )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IRangos_Pediatria_por_PlatillosApiConsumer = Rangos_Pediatria_por_PlatillosApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_FormatApiConsumer = Spartan_FormatApiConsumer;
            this._ISpartan_Format_PermissionsApiConsumer = Spartan_Format_PermissionsApiConsumer;
            this._IGeneratePDFApiConsumer = GeneratePDFApiConsumer;
			this._ISpartan_FormatRelatedApiConsumer = Spartan_Format_RelatedApiConsumer;
            this._IMR_PadecimientosApiConsumer = MR_PadecimientosApiConsumer;

            this._IPadecimientosApiConsumer = PadecimientosApiConsumer;


        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Rangos_Pediatria_por_Platillos
        [ObjectAuth(ObjectId = (ModuleObjectId)44792, PermissionType = PermissionTypes.Consult)]
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
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44792, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			          
            return View();
        }

        // GET: Frontal/Rangos_Pediatria_por_Platillos/Create
          [ObjectAuth(ObjectId = (ModuleObjectId)44792, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44792, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varRangos_Pediatria_por_Platillos = new Rangos_Pediatria_por_PlatillosModel();
			varRangos_Pediatria_por_Platillos.Folio = Id;
			
            ViewBag.ObjectId = "44792";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;

            var permissionMR_Padecimientos = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44793, ModuleId);
            ViewBag.PermissionMR_Padecimientos = permissionMR_Padecimientos;


            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
				
				_tokenManager.GenerateToken();
				_ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _IRangos_Pediatria_por_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Rangos_Pediatria_por_PlatillossData = _IRangos_Pediatria_por_PlatillosApiConsumer.ListaSelAll(0, 1000, "Rangos_Pediatria_por_Platillos.Folio=" + Id, "").Resource.Rangos_Pediatria_por_Platilloss;
				
				if (Rangos_Pediatria_por_PlatillossData != null && Rangos_Pediatria_por_PlatillossData.Count > 0)
                {
					var Rangos_Pediatria_por_PlatillosData = Rangos_Pediatria_por_PlatillossData.First();
					varRangos_Pediatria_por_Platillos= new Rangos_Pediatria_por_PlatillosModel
					{
						Folio  = Rangos_Pediatria_por_PlatillosData.Folio 
	                    ,Nombre_de_rango = Rangos_Pediatria_por_PlatillosData.Nombre_de_rango
                    ,Edad_minima = Rangos_Pediatria_por_PlatillosData.Edad_minima
                    ,Edad_maxima = Rangos_Pediatria_por_PlatillosData.Edad_maxima
                    ,Tiene_padecimientos = Rangos_Pediatria_por_PlatillosData.Tiene_padecimientos.GetValueOrDefault()

					};
				}
				
				
				
            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);



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

				
            return View(varRangos_Pediatria_por_Platillos);
        }
		
	[HttpGet]
        public ActionResult AddRangos_Pediatria_por_Platillos(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44792);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IRangos_Pediatria_por_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);
			Rangos_Pediatria_por_PlatillosModel varRangos_Pediatria_por_Platillos= new Rangos_Pediatria_por_PlatillosModel();
            var permissionMR_Padecimientos = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44793, ModuleId);
            ViewBag.PermissionMR_Padecimientos = permissionMR_Padecimientos;


            if (id.ToString() != "0")
            {
                var Rangos_Pediatria_por_PlatillossData = _IRangos_Pediatria_por_PlatillosApiConsumer.ListaSelAll(0, 1000, "Rangos_Pediatria_por_Platillos.Folio=" + id, "").Resource.Rangos_Pediatria_por_Platilloss;
				
				if (Rangos_Pediatria_por_PlatillossData != null && Rangos_Pediatria_por_PlatillossData.Count > 0)
                {
					var Rangos_Pediatria_por_PlatillosData = Rangos_Pediatria_por_PlatillossData.First();
					varRangos_Pediatria_por_Platillos= new Rangos_Pediatria_por_PlatillosModel
					{
						Folio  = Rangos_Pediatria_por_PlatillosData.Folio 
	                    ,Nombre_de_rango = Rangos_Pediatria_por_PlatillosData.Nombre_de_rango
                    ,Edad_minima = Rangos_Pediatria_por_PlatillosData.Edad_minima
                    ,Edad_maxima = Rangos_Pediatria_por_PlatillosData.Edad_maxima
                    ,Tiene_padecimientos = Rangos_Pediatria_por_PlatillosData.Tiene_padecimientos.GetValueOrDefault()

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);



            return PartialView("AddRangos_Pediatria_por_Platillos", varRangos_Pediatria_por_Platillos);
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




        [HttpPost]
        public JsonResult ClearAdvanceFilter()
        {
            Session["AdvanceSearch"] = null;
            return Json(new { result = Session["AdvanceSearch"] == null }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ShowAdvanceFilter(Rangos_Pediatria_por_PlatillosAdvanceSearchModel model, int idFilter = -1)
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



            return View(model);  
        }

        [HttpGet]
        public ActionResult ShowAdvanceFilter(string previousFilters = "")
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);



            var previousFiltersObj = new Rangos_Pediatria_por_PlatillosAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Rangos_Pediatria_por_PlatillosAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Rangos_Pediatria_por_PlatillosAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Rangos_Pediatria_por_PlatillosPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IRangos_Pediatria_por_PlatillosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Rangos_Pediatria_por_Platilloss == null)
                result.Rangos_Pediatria_por_Platilloss = new List<Rangos_Pediatria_por_Platillos>();

            return Json(new
            {
                data = result.Rangos_Pediatria_por_Platilloss.Select(m => new Rangos_Pediatria_por_PlatillosGridModel
                    {
                    Folio = m.Folio
			,Nombre_de_rango = m.Nombre_de_rango
			,Edad_minima = m.Edad_minima
			,Edad_maxima = m.Edad_maxima
			,Tiene_padecimientos = m.Tiene_padecimientos

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }
		/*
		 [HttpGet]
        public ActionResult GetRangos_Pediatria_por_PlatillosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IRangos_Pediatria_por_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IRangos_Pediatria_por_PlatillosApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraductionNew(Convert.ToString(m.Folio), "Rangos_Pediatria_por_Platillos", m.),
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
        /// Get List of Rangos_Pediatria_por_Platillos from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Rangos_Pediatria_por_Platillos Entity</returns>
        public ActionResult GetRangos_Pediatria_por_PlatillosList(UrlParametersModel param)
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
            _IRangos_Pediatria_por_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);

          
            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new Rangos_Pediatria_por_PlatillosPropertyMapper());
				
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
				if (Session["AdvanceSearch"].GetType() == typeof(Rangos_Pediatria_por_PlatillosAdvanceSearchModel))
                {
					var advanceFilter =
                    (Rangos_Pediatria_por_PlatillosAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            Rangos_Pediatria_por_PlatillosPropertyMapper oRangos_Pediatria_por_PlatillosPropertyMapper = new Rangos_Pediatria_por_PlatillosPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                 if (sortColumn != -1)
                    configuration.OrderByClause = oRangos_Pediatria_por_PlatillosPropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _IRangos_Pediatria_por_PlatillosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Rangos_Pediatria_por_Platilloss == null)
                result.Rangos_Pediatria_por_Platilloss = new List<Rangos_Pediatria_por_Platillos>();

            return Json(new
            {
                aaData = result.Rangos_Pediatria_por_Platilloss.Select(m => new Rangos_Pediatria_por_PlatillosGridModel
            {
                    Folio = m.Folio
			,Nombre_de_rango = m.Nombre_de_rango
			,Edad_minima = m.Edad_minima
			,Edad_maxima = m.Edad_maxima
			,Tiene_padecimientos = m.Tiene_padecimientos

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }


//Grid GetAutoComplete






        [NonAction]
        public string GetAdvanceFilter(Rangos_Pediatria_por_PlatillosAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromFolio) || !string.IsNullOrEmpty(filter.ToFolio))
            {
                if (!string.IsNullOrEmpty(filter.FromFolio))
                    where += " AND Rangos_Pediatria_por_Platillos.Folio >= " + filter.FromFolio;
                if (!string.IsNullOrEmpty(filter.ToFolio))
                    where += " AND Rangos_Pediatria_por_Platillos.Folio <= " + filter.ToFolio;
            }

            if (!string.IsNullOrEmpty(filter.Nombre_de_rango))
            {
                switch (filter.Nombre_de_rangoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Rangos_Pediatria_por_Platillos.Nombre_de_rango LIKE '" + filter.Nombre_de_rango + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Rangos_Pediatria_por_Platillos.Nombre_de_rango LIKE '%" + filter.Nombre_de_rango + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Rangos_Pediatria_por_Platillos.Nombre_de_rango = '" + filter.Nombre_de_rango + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Rangos_Pediatria_por_Platillos.Nombre_de_rango LIKE '%" + filter.Nombre_de_rango + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.FromEdad_minima) || !string.IsNullOrEmpty(filter.ToEdad_minima))
            {
                if (!string.IsNullOrEmpty(filter.FromEdad_minima))
                    where += " AND Rangos_Pediatria_por_Platillos.Edad_minima >= " + filter.FromEdad_minima;
                if (!string.IsNullOrEmpty(filter.ToEdad_minima))
                    where += " AND Rangos_Pediatria_por_Platillos.Edad_minima <= " + filter.ToEdad_minima;
            }

            if (!string.IsNullOrEmpty(filter.FromEdad_maxima) || !string.IsNullOrEmpty(filter.ToEdad_maxima))
            {
                if (!string.IsNullOrEmpty(filter.FromEdad_maxima))
                    where += " AND Rangos_Pediatria_por_Platillos.Edad_maxima >= " + filter.FromEdad_maxima;
                if (!string.IsNullOrEmpty(filter.ToEdad_maxima))
                    where += " AND Rangos_Pediatria_por_Platillos.Edad_maxima <= " + filter.ToEdad_maxima;
            }

            if (filter.Tiene_padecimientos != RadioOptions.NoApply)
                where += " AND Rangos_Pediatria_por_Platillos.Tiene_padecimientos = " + Convert.ToInt32(filter.Tiene_padecimientos);


            where = new Regex(Regex.Escape("AND ")).Replace(where, "", 1);
            return where;
        }

        [NonAction]
        public Grid_File ConvertSpartane_FileToGridFile(Spartane.Core.Domain.Spartane_File.Spartane_File file)
        {
            return file == null ? new Grid_File { FileId = 0, FileSize = 0, FileName = "" } : new Grid_File { FileId = file.File_Id, FileName = file.Description, FileSize = file.File_Size ?? 0, };
        }

        public ActionResult GetMR_Padecimientos(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<MR_PadecimientosGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IMR_PadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "MR_Padecimientos.Folio_Rangos_Pediatria_por_Platillos=" + RelationId;
            if("int" == "string")
            {
	           where = "MR_Padecimientos.Folio_Rangos_Pediatria_por_Platillos='" + RelationId + "'";
            }
            var result = _IMR_PadecimientosApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.MR_Padecimientoss == null)
                result.MR_Padecimientoss = new List<MR_Padecimientos>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.MR_Padecimientoss.Select(m => new MR_PadecimientosGridModel
                {
                    Folio = m.Folio

                        ,Padecimiento = m.Padecimiento
                        ,PadecimientoDescripcion = CultureHelper.GetTraduction(m.Padecimiento_Padecimientos.Clave.ToString(), "Descripcion") ??(string)m.Padecimiento_Padecimientos.Descripcion

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<MR_PadecimientosGridModel> GetMR_PadecimientosData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<MR_PadecimientosGridModel> resultData = new List<MR_PadecimientosGridModel>();
            string where = "MR_Padecimientos.Folio_Rangos_Pediatria_por_Platillos=" + Id;
            if("int" == "string")
            {
                where = "MR_Padecimientos.Folio_Rangos_Pediatria_por_Platillos='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IMR_PadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IMR_PadecimientosApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.MR_Padecimientoss != null)
            {
                resultData = result.MR_Padecimientoss.Select(m => new MR_PadecimientosGridModel
                    {
                        Folio = m.Folio

                        ,Padecimiento = m.Padecimiento
                        ,PadecimientoDescripcion = CultureHelper.GetTraduction(m.Padecimiento_Padecimientos.Clave.ToString(), "Descripcion") ??(string)m.Padecimiento_Padecimientos.Descripcion


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
                _IRangos_Pediatria_por_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);

                Rangos_Pediatria_por_Platillos varRangos_Pediatria_por_Platillos = null;
                if (id.ToString() != "0")
                {
                        string where = "";
                    _IMR_PadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "MR_Padecimientos.Folio_Rangos_Pediatria_por_Platillos=" + id;
                    if("int" == "string")
                    {
	                where = "MR_Padecimientos.Folio_Rangos_Pediatria_por_Platillos='" + id + "'";
                    }
                    var MR_PadecimientosInfo =
                        _IMR_PadecimientosApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (MR_PadecimientosInfo.MR_Padecimientoss.Count > 0)
                    {
                        var resultMR_Padecimientos = true;
                        //Removing associated job history with attachment
                        foreach (var MR_PadecimientosItem in MR_PadecimientosInfo.MR_Padecimientoss)
                            resultMR_Padecimientos = resultMR_Padecimientos
                                              && _IMR_PadecimientosApiConsumer.Delete(MR_PadecimientosItem.Folio, null,null).Resource;

                        if (!resultMR_Padecimientos)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                var result = _IRangos_Pediatria_por_PlatillosApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Rangos_Pediatria_por_PlatillosModel varRangos_Pediatria_por_Platillos)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IRangos_Pediatria_por_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Rangos_Pediatria_por_PlatillosInfo = new Rangos_Pediatria_por_Platillos
                    {
                        Folio = varRangos_Pediatria_por_Platillos.Folio
                        ,Nombre_de_rango = varRangos_Pediatria_por_Platillos.Nombre_de_rango
                        ,Edad_minima = varRangos_Pediatria_por_Platillos.Edad_minima
                        ,Edad_maxima = varRangos_Pediatria_por_Platillos.Edad_maxima
                        ,Tiene_padecimientos = varRangos_Pediatria_por_Platillos.Tiene_padecimientos

                    };

                    result = !IsNew ?
                        _IRangos_Pediatria_por_PlatillosApiConsumer.Update(Rangos_Pediatria_por_PlatillosInfo, null, null).Resource.ToString() :
                         _IRangos_Pediatria_por_PlatillosApiConsumer.Insert(Rangos_Pediatria_por_PlatillosInfo, null, null).Resource.ToString();
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
        public bool CopyMR_Padecimientos(int MasterId, int referenceId, List<MR_PadecimientosGridModelPost> MR_PadecimientosItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IMR_PadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);

                var MR_PadecimientosData = _IMR_PadecimientosApiConsumer.ListaSelAll(1, int.MaxValue, "MR_Padecimientos.Folio_Rangos_Pediatria_por_Platillos=" + referenceId,"").Resource;
                if (MR_PadecimientosData == null || MR_PadecimientosData.MR_Padecimientoss.Count == 0)
                    return true;

                var result = true;

                MR_PadecimientosGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varMR_Padecimientos in MR_PadecimientosData.MR_Padecimientoss)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    MR_Padecimientos MR_Padecimientos1 = varMR_Padecimientos;

                    if (MR_PadecimientosItems != null && MR_PadecimientosItems.Any(m => m.Folio == MR_Padecimientos1.Folio))
                    {
                        modelDataToChange = MR_PadecimientosItems.FirstOrDefault(m => m.Folio == MR_Padecimientos1.Folio);
                    }
                    //Chaning Id Value
                    varMR_Padecimientos.Folio_Rangos_Pediatria_por_Platillos = MasterId;
                    var insertId = _IMR_PadecimientosApiConsumer.Insert(varMR_Padecimientos,null,null).Resource;
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
        public ActionResult PostMR_Padecimientos(List<MR_PadecimientosGridModelPost> MR_PadecimientosItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyMR_Padecimientos(MasterId, referenceId, MR_PadecimientosItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (MR_PadecimientosItems != null && MR_PadecimientosItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IMR_PadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var MR_PadecimientosItem in MR_PadecimientosItems)
                    {



                        //Removal Request
                        if (MR_PadecimientosItem.Removed)
                        {
                            result = result && _IMR_PadecimientosApiConsumer.Delete(MR_PadecimientosItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							MR_PadecimientosItem.Folio = 0;

                        var MR_PadecimientosData = new MR_Padecimientos
                        {
                            Folio_Rangos_Pediatria_por_Platillos = MasterId
                            ,Folio = MR_PadecimientosItem.Folio
                            ,Padecimiento = (Convert.ToInt32(MR_PadecimientosItem.Padecimiento) == 0 ? (Int32?)null : Convert.ToInt32(MR_PadecimientosItem.Padecimiento))

                        };

                        var resultId = MR_PadecimientosItem.Folio > 0
                           ? _IMR_PadecimientosApiConsumer.Update(MR_PadecimientosData,null,null).Resource
                           : _IMR_PadecimientosApiConsumer.Insert(MR_PadecimientosData,null,null).Resource;

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
        public ActionResult GetMR_Padecimientos_PadecimientosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPadecimientosApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Padecimientos", "Descripcion");
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
        /// Write Element Array of Rangos_Pediatria_por_Platillos script
        /// </summary>
        /// <param name="oRangos_Pediatria_por_PlatillosElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew Rangos_Pediatria_por_PlatillosModuleAttributeList)
        {
            for (int i = 0; i < Rangos_Pediatria_por_PlatillosModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Rangos_Pediatria_por_PlatillosModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Rangos_Pediatria_por_PlatillosModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Rangos_Pediatria_por_PlatillosModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Rangos_Pediatria_por_PlatillosModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Rangos_Pediatria_por_PlatillosModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Rangos_Pediatria_por_PlatillosModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < Rangos_Pediatria_por_PlatillosModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(Rangos_Pediatria_por_PlatillosModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							Rangos_Pediatria_por_PlatillosModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(Rangos_Pediatria_por_PlatillosModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							Rangos_Pediatria_por_PlatillosModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strRangos_Pediatria_por_PlatillosScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Rangos_Pediatria_por_Platillos.js")))
            {
                strRangos_Pediatria_por_PlatillosScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Rangos_Pediatria_por_Platillos element attributes
            string userChangeJson = jsSerialize.Serialize(Rangos_Pediatria_por_PlatillosModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strRangos_Pediatria_por_PlatillosScript.IndexOf("inpuElementArray");
            string splittedString = strRangos_Pediatria_por_PlatillosScript.Substring(indexOfArray, strRangos_Pediatria_por_PlatillosScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Rangos_Pediatria_por_PlatillosModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Rangos_Pediatria_por_PlatillosModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strRangos_Pediatria_por_PlatillosScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strRangos_Pediatria_por_PlatillosScript.Substring(indexOfArrayHistory, strRangos_Pediatria_por_PlatillosScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strRangos_Pediatria_por_PlatillosScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strRangos_Pediatria_por_PlatillosScript.Substring(endIndexOfMainElement + indexOfArray, strRangos_Pediatria_por_PlatillosScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (Rangos_Pediatria_por_PlatillosModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in Rangos_Pediatria_por_PlatillosModuleAttributeList.ChildModuleAttributeList)
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
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Rangos_Pediatria_por_Platillos.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Rangos_Pediatria_por_Platillos.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Rangos_Pediatria_por_Platillos.js")))
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
        public ActionResult Rangos_Pediatria_por_PlatillosPropertyBag()
        {
            return PartialView("Rangos_Pediatria_por_PlatillosPropertyBag", "Rangos_Pediatria_por_Platillos");
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
        public ActionResult AddMR_Padecimientos(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../MR_Padecimientos/AddMR_Padecimientos");
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
                var whereClauseFormat = "Object = 44792 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _IRangos_Pediatria_por_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Rangos_Pediatria_por_Platillos.Folio= " + RecordId;
                            var result = _IRangos_Pediatria_por_PlatillosApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
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

            _IRangos_Pediatria_por_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Rangos_Pediatria_por_PlatillosPropertyMapper());
			
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
                    (Rangos_Pediatria_por_PlatillosAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
			string sortDirection = "asc";

            Rangos_Pediatria_por_PlatillosPropertyMapper oRangos_Pediatria_por_PlatillosPropertyMapper = new Rangos_Pediatria_por_PlatillosPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oRangos_Pediatria_por_PlatillosPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IRangos_Pediatria_por_PlatillosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Rangos_Pediatria_por_Platilloss == null)
                result.Rangos_Pediatria_por_Platilloss = new List<Rangos_Pediatria_por_Platillos>();

            var data = result.Rangos_Pediatria_por_Platilloss.Select(m => new Rangos_Pediatria_por_PlatillosGridModel
            {
                Folio = m.Folio
			,Nombre_de_rango = m.Nombre_de_rango
			,Edad_minima = m.Edad_minima
			,Edad_maxima = m.Edad_maxima
			,Tiene_padecimientos = m.Tiene_padecimientos

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(44792, arrayColumnsVisible), "Rangos_Pediatria_por_PlatillosList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(44792, arrayColumnsVisible), "Rangos_Pediatria_por_PlatillosList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(44792, arrayColumnsVisible), "Rangos_Pediatria_por_PlatillosList_" + DateTime.Now.ToString());
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

            _IRangos_Pediatria_por_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Rangos_Pediatria_por_PlatillosPropertyMapper());
				
				
            if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
			if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (Rangos_Pediatria_por_PlatillosAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            Rangos_Pediatria_por_PlatillosPropertyMapper oRangos_Pediatria_por_PlatillosPropertyMapper = new Rangos_Pediatria_por_PlatillosPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oRangos_Pediatria_por_PlatillosPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
			
			if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IRangos_Pediatria_por_PlatillosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Rangos_Pediatria_por_Platilloss == null)
                result.Rangos_Pediatria_por_Platilloss = new List<Rangos_Pediatria_por_Platillos>();

            var data = result.Rangos_Pediatria_por_Platilloss.Select(m => new Rangos_Pediatria_por_PlatillosGridModel
            {
                Folio = m.Folio
			,Nombre_de_rango = m.Nombre_de_rango
			,Edad_minima = m.Edad_minima
			,Edad_maxima = m.Edad_maxima
			,Tiene_padecimientos = m.Tiene_padecimientos

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
                _IRangos_Pediatria_por_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IRangos_Pediatria_por_PlatillosApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpPost]
        public ActionResult Post_Datos_Generales(Rangos_Pediatria_por_Platillos_Datos_GeneralesModel varRangos_Pediatria_por_Platillos)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IRangos_Pediatria_por_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Rangos_Pediatria_por_Platillos_Datos_GeneralesInfo = new Rangos_Pediatria_por_Platillos_Datos_Generales
                {
                    Folio = varRangos_Pediatria_por_Platillos.Folio
                                            ,Nombre_de_rango = varRangos_Pediatria_por_Platillos.Nombre_de_rango
                        ,Edad_minima = varRangos_Pediatria_por_Platillos.Edad_minima
                        ,Edad_maxima = varRangos_Pediatria_por_Platillos.Edad_maxima
                        ,Tiene_padecimientos = varRangos_Pediatria_por_Platillos.Tiene_padecimientos
                    
                };

                result = _IRangos_Pediatria_por_PlatillosApiConsumer.Update_Datos_Generales(Rangos_Pediatria_por_Platillos_Datos_GeneralesInfo).Resource.ToString();
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
                _IRangos_Pediatria_por_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IRangos_Pediatria_por_PlatillosApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_MR_Padecimientos;
                var MR_PadecimientosData = GetMR_PadecimientosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_MR_Padecimientos);

                var result = new Rangos_Pediatria_por_Platillos_Datos_GeneralesModel
                {
                    Folio = m.Folio
			,Nombre_de_rango = m.Nombre_de_rango
			,Edad_minima = m.Edad_minima
			,Edad_maxima = m.Edad_maxima
			,Tiene_padecimientos = m.Tiene_padecimientos

                    
                };
				var resultData = new
                {
                    data = result
                    ,Padecimientos = MR_PadecimientosData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }


    }
}

