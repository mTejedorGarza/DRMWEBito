using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ModelBinding;
using Spartane.Core.Exceptions.Service;
using System.Web;
using Spartane.Core.Classes.Estatus_de_Funcionalidad_para_Notificacion;
using Spartane.Services.Estatus_de_Funcionalidad_para_Notificacion;
using System.Data;
using System.Web.Script.Serialization;
using oAuth.WebAPI.Consumer;
using oAuth.WebApi.Helpers;
using System.Configuration;
using System.Text;

using Spartane.Services.Spartan_Bitacora_SQL;
using Spartane.Core.Classes.Spartan_Bitacora_SQL;

namespace Spartane.WebApi.Controllers
{
    
    public partial class Estatus_de_Funcionalidad_para_NotificacionController : BaseApiController
    {
        #region Variables
        private IEstatus_de_Funcionalidad_para_NotificacionService service = null;
        public  static string ApiControllerUrl { get; set; }
		private ISpartan_Bitacora_SQLService serviceBitacora = null;
		private static int object_id = 44719;
        public string baseApi;
        #endregion Variables

        #region Constructor
        //TODO: Global Data y Data Rerence tienen que estar en un controlador base
        public Estatus_de_Funcionalidad_para_NotificacionController(IEstatus_de_Funcionalidad_para_NotificacionService service,ISpartan_Bitacora_SQLService bitacoraService)
        {
            this.service = service;
			serviceBitacora = bitacoraService;
            baseApi = ConfigurationManager.AppSettings["DBBaseURL"].ToString();
            ApiControllerUrl = "api/Estatus_de_Funcionalidad_para_Notificacion";
            
        }
        #endregion Constructor


        #region API Methods
        [Authorize]
        public HttpResponseMessage Get(int id)
        {
            var entity = this.service.GetByKey(id, false);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        [Authorize]
        public HttpResponseMessage GetAll()
        {
            var entity = this.service.SelAll(false);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        [Authorize]
        [HttpGet]
        public HttpResponseMessage ListaSelAll(int startRowIndex, int maximumRows, string where = "", string order = "")
        {
            var entity = this.service.ListaSelAll(startRowIndex, maximumRows, where, order);
            entity.RowCount = this.service.ListaSelAllCount(where);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        [Authorize]
        public HttpResponseMessage GetAllComplete()
        {
            var entity = this.service.SelAllComplete(false);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        [Authorize]
        public HttpResponseMessage GetAll(string where, string order)
        {
            var entity = this.service.SelAll(false, where, order);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        [Authorize]
        public HttpResponseMessage Post(Estatus_de_Funcionalidad_para_Notificacion varEstatus_de_Funcionalidad_para_Notificacion)
        {
            if (ModelState.IsValid)
            {
                var data = "-1";
                try
                {
                    data = Convert.ToString(this.service.Insert(varEstatus_de_Funcionalidad_para_Notificacion));
					var bitacora = BitacoraHelper.GetBitacora(Request, object_id, Convert.ToInt32(data), BitacoraHelper.TypeSql.INSERT, "sp_InsEstatus_de_Funcionalidad_para_Notificacion" , new JavaScriptSerializer().Serialize(varEstatus_de_Funcionalidad_para_Notificacion), true);
                    serviceBitacora.Insert(bitacora);
                }
                catch (ServiceException ex)
                {
					var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_InsEstatus_de_Funcionalidad_para_Notificacion", new JavaScriptSerializer().Serialize(varEstatus_de_Funcionalidad_para_Notificacion), true);
                    serviceBitacora.Insert(bitacora);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                var errors= ModelState.SelectMany(m => m.Value.Errors.Select(err => err.ErrorMessage != string.Empty ? err.ErrorMessage : err.Exception.Message).ToList()).ToList();                
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_InsEstatus_de_Funcionalidad_para_Notificacion",new JavaScriptSerializer().Serialize(varEstatus_de_Funcionalidad_para_Notificacion), false, errors.ToString());
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }

        [Authorize]
        [HttpPut]
        public HttpResponseMessage Put(int id, Estatus_de_Funcionalidad_para_Notificacion varEstatus_de_Funcionalidad_para_Notificacion)
        {
            if (ModelState.IsValid && id == varEstatus_de_Funcionalidad_para_Notificacion.Folio)
            {
                var data = "-1";
                try
                {
                    data = Convert.ToString(this.service.Update(varEstatus_de_Funcionalidad_para_Notificacion));
					 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdEstatus_de_Funcionalidad_para_Notificacion", new JavaScriptSerializer().Serialize(varEstatus_de_Funcionalidad_para_Notificacion), true);
                    serviceBitacora.Insert(bitacora);
                }
                catch (ServiceException ex)
                {
				    var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdEstatus_de_Funcionalidad_para_Notificacion", new JavaScriptSerializer().Serialize(varEstatus_de_Funcionalidad_para_Notificacion), false, ex.Message);
                    serviceBitacora.Insert(bitacora);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
               var errors= ModelState.SelectMany(m => m.Value.Errors.Select(err => err.ErrorMessage != string.Empty ? err.ErrorMessage : err.Exception.Message).ToList()).ToList();                
               var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdEstatus_de_Funcionalidad_para_Notificacion", new JavaScriptSerializer().Serialize(varEstatus_de_Funcionalidad_para_Notificacion), false, String.Join(",", errors.ToArray()));
               serviceBitacora.Insert(bitacora);
               return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }
		
		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Datos_Generales(Estatus_de_Funcionalidad_para_Notificacion varEstatus_de_Funcionalidad_para_Notificacion_Datos_Generales)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Datos_Generales(varEstatus_de_Funcionalidad_para_Notificacion_Datos_Generales));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varEstatus_de_Funcionalidad_para_Notificacion_Datos_Generales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdEstatus_de_Funcionalidad_para_Notificacion", new JavaScriptSerializer().Serialize(varEstatus_de_Funcionalidad_para_Notificacion_Datos_Generales), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varEstatus_de_Funcionalidad_para_Notificacion_Datos_Generales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdEstatus_de_Funcionalidad_para_Notificacion", new JavaScriptSerializer().Serialize(varEstatus_de_Funcionalidad_para_Notificacion_Datos_Generales), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Datos_Generales(int id)
        {
            Estatus_de_Funcionalidad_para_Notificacion entity = this.service.ListaSelAll(1, 1, "Estatus_de_Funcionalidad_para_Notificacion.Folio='" + id.ToString() + "'", "").Estatus_de_Funcionalidad_para_Notificacions.First();
            Estatus_de_Funcionalidad_para_Notificacion result = new Estatus_de_Funcionalidad_para_Notificacion();
			result.Folio = entity.Folio;
result.Campo_para_Estatus = entity.Campo_para_Estatus;
result.Nombre_Fisico_del_Campo = entity.Nombre_Fisico_del_Campo;
result.Nombre_Fisico_de_la_Tabla = entity.Nombre_Fisico_de_la_Tabla;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }


		
	[Authorize]
        [HttpGet]
        public HttpResponseMessage Estatus_de_Funcionalidad_para_NotificacionGenerateID()
        {
            Estatus_de_Funcionalidad_para_Notificacion varEstatus_de_Funcionalidad_para_Notificacion = new Estatus_de_Funcionalidad_para_Notificacion();
            var data = "-1";
            try
            {
                data = Convert.ToString(this.service.Insert(varEstatus_de_Funcionalidad_para_Notificacion));
                var bitacora = BitacoraHelper.GetBitacora(Request, object_id, Convert.ToInt32(data), BitacoraHelper.TypeSql.INSERT, "sp_Estatus_de_Funcionalidad_para_NotificacionGenerateID", new JavaScriptSerializer().Serialize(varEstatus_de_Funcionalidad_para_Notificacion), true);
                serviceBitacora.Insert(bitacora);
            }
            catch (ServiceException ex)
            {
                var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_Estatus_de_Funcionalidad_para_NotificacionGenerateID", new JavaScriptSerializer().Serialize(varEstatus_de_Funcionalidad_para_Notificacion), true);
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }	
        [Authorize]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            Estatus_de_Funcionalidad_para_Notificacion varEstatus_de_Funcionalidad_para_Notificacion = this.service.GetByKey(id, false);
            bool result = false;
            if (varEstatus_de_Funcionalidad_para_Notificacion == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
              result=  this.service.Delete(id);//, globalData, dataReference);
			  var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.DELETE, "sp_DelEstatus_de_Funcionalidad_para_Notificacion", new JavaScriptSerializer().Serialize(varEstatus_de_Funcionalidad_para_Notificacion), result);
              serviceBitacora.Insert(bitacora);
            }
            catch (ServiceException ex)
            {
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.DELETE, "sp_DelEstatus_de_Funcionalidad_para_Notificacion", new JavaScriptSerializer().Serialize(varEstatus_de_Funcionalidad_para_Notificacion), result, ex.Message);
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        #endregion API Methods

        #region TunnelMethod

        /// <summary>
        /// WebAPI GetALLTunnel
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetAllTunnel(string user, string password)
        {
                var client = new System.Net.WebClient();
                client.Headers = TokenManager.GetAuthenticationHeader(user,password);
                var result = client.DownloadString(baseApi + ApiControllerUrl + "/GetAll");
                var Estatus_de_Funcionalidad_para_NotificacionDataTable = new JavaScriptSerializer().Deserialize<List<Estatus_de_Funcionalidad_para_Notificacion>>(result);
                return Request.CreateResponse(HttpStatusCode.OK, Estatus_de_Funcionalidad_para_NotificacionDataTable, Configuration.Formatters.JsonFormatter);
        }

        /// <summary>
        /// WebAPI GET
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetTunnel(int id,string user, string password)
        {
                var client = new System.Net.WebClient();
                client.Headers = TokenManager.GetAuthenticationHeader(user,password);
                var result = client.DownloadString(baseApi + ApiControllerUrl + "/Get?id=" + id);
                var Estatus_de_Funcionalidad_para_NotificacionResult = new JavaScriptSerializer().Deserialize<Estatus_de_Funcionalidad_para_Notificacion>(result);
                return Request.CreateResponse(HttpStatusCode.OK, Estatus_de_Funcionalidad_para_NotificacionResult, Configuration.Formatters.JsonFormatter);            
        }

        /// <summary>
        /// WebAPI ListaSelAllTunnel
        /// </summary>
        /// <param name="startRowIndex"></param>
        /// <param name="maximumRows"></param>
        /// <param name="Where"></param>
        /// <param name="Order"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage ListaSelAllTunnel(int startRowIndex, int maximumRows, string Where, string Order,string user, string password)
        {
                var client = new System.Net.WebClient();
                client.Headers = TokenManager.GetAuthenticationHeader(user,password);
                client.Encoding = Encoding.UTF8;
                var result = client.DownloadString(baseApi + ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                        "&maximumRows=" + maximumRows +
                        (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                         (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order));
                var resp = new HttpResponseMessage(HttpStatusCode.OK);
                resp.Content = new StringContent(result, System.Text.Encoding.UTF8, "text/plain");
                return resp;
        }

        /// <summary>
        /// WebAPI PostTunnel
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage PostTunnel(Estatus_de_Funcionalidad_para_Notificacion emp,string user, string password)
        {
                var client = new System.Net.WebClient();
                client.Headers = TokenManager.GetAuthenticationHeader(user,password);

                client.Headers["Content-Type"] = "application/json";
                var dataString = new JavaScriptSerializer().Serialize(emp);

                var result = client.UploadString(new Uri(baseApi + ApiControllerUrl + "/Post"), "POST",
                    dataString);

                return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);            
        }

        /// <summary>
        /// WebAPI put tunnel
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage PutTunnel(Estatus_de_Funcionalidad_para_Notificacion emp, string user, string password)
        {
                var client = new System.Net.WebClient();
                client.Headers = TokenManager.GetAuthenticationHeader(user,password);
                client.Headers["Content-Type"] = "application/json";
                var dataString = new JavaScriptSerializer().Serialize(emp);

                var result = client.UploadString(new Uri(baseApi + ApiControllerUrl + "/Put?Id=" + emp.Folio), "PUT"
                , dataString);

                return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

        /// <summary>
        /// WebAPI Delete Tunnel
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteTunnel(int id,string user, string password)
        {
                var client = new System.Net.WebClient();
                client.Headers = TokenManager.GetAuthenticationHeader(user,password);
                client.Headers["Content-Type"] = "application/json";
                var result = client.UploadString(new Uri(baseApi + ApiControllerUrl + "/Delete?id=" + id), "DELETE"
                );
                return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

        #endregion TunnelMethod

    }
}

