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
using Spartane.Core.Classes.Configuracion_de_Notificaciones;
using Spartane.Services.Configuracion_de_Notificaciones;
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
    
    public partial class Configuracion_de_NotificacionesController : BaseApiController
    {
        #region Variables
        private IConfiguracion_de_NotificacionesService service = null;
        public  static string ApiControllerUrl { get; set; }
		private ISpartan_Bitacora_SQLService serviceBitacora = null;
		private static int object_id = 44689;
        public string baseApi;
        #endregion Variables

        #region Constructor
        //TODO: Global Data y Data Rerence tienen que estar en un controlador base
        public Configuracion_de_NotificacionesController(IConfiguracion_de_NotificacionesService service,ISpartan_Bitacora_SQLService bitacoraService)
        {
            this.service = service;
			serviceBitacora = bitacoraService;
            baseApi = ConfigurationManager.AppSettings["DBBaseURL"].ToString();
            ApiControllerUrl = "api/Configuracion_de_Notificaciones";
            
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
        public HttpResponseMessage Post(Configuracion_de_Notificaciones varConfiguracion_de_Notificaciones)
        {
            if (ModelState.IsValid)
            {
                var data = "-1";
                try
                {
                    data = Convert.ToString(this.service.Insert(varConfiguracion_de_Notificaciones));
					var bitacora = BitacoraHelper.GetBitacora(Request, object_id, Convert.ToInt32(data), BitacoraHelper.TypeSql.INSERT, "sp_InsConfiguracion_de_Notificaciones" , new JavaScriptSerializer().Serialize(varConfiguracion_de_Notificaciones), true);
                    serviceBitacora.Insert(bitacora);
                }
                catch (ServiceException ex)
                {
					var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_InsConfiguracion_de_Notificaciones", new JavaScriptSerializer().Serialize(varConfiguracion_de_Notificaciones), true);
                    serviceBitacora.Insert(bitacora);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                var errors= ModelState.SelectMany(m => m.Value.Errors.Select(err => err.ErrorMessage != string.Empty ? err.ErrorMessage : err.Exception.Message).ToList()).ToList();                
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_InsConfiguracion_de_Notificaciones",new JavaScriptSerializer().Serialize(varConfiguracion_de_Notificaciones), false, errors.ToString());
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }

        [Authorize]
        [HttpPut]
        public HttpResponseMessage Put(int id, Configuracion_de_Notificaciones varConfiguracion_de_Notificaciones)
        {
            if (ModelState.IsValid && id == varConfiguracion_de_Notificaciones.Folio)
            {
                var data = "-1";
                try
                {
                    data = Convert.ToString(this.service.Update(varConfiguracion_de_Notificaciones));
					 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdConfiguracion_de_Notificaciones", new JavaScriptSerializer().Serialize(varConfiguracion_de_Notificaciones), true);
                    serviceBitacora.Insert(bitacora);
                }
                catch (ServiceException ex)
                {
				    var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdConfiguracion_de_Notificaciones", new JavaScriptSerializer().Serialize(varConfiguracion_de_Notificaciones), false, ex.Message);
                    serviceBitacora.Insert(bitacora);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
               var errors= ModelState.SelectMany(m => m.Value.Errors.Select(err => err.ErrorMessage != string.Empty ? err.ErrorMessage : err.Exception.Message).ToList()).ToList();                
               var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdConfiguracion_de_Notificaciones", new JavaScriptSerializer().Serialize(varConfiguracion_de_Notificaciones), false, String.Join(",", errors.ToArray()));
               serviceBitacora.Insert(bitacora);
               return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }
		
		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Datos_Generales(Configuracion_de_Notificaciones varConfiguracion_de_Notificaciones_Datos_Generales)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Datos_Generales(varConfiguracion_de_Notificaciones_Datos_Generales));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varConfiguracion_de_Notificaciones_Datos_Generales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdConfiguracion_de_Notificaciones", new JavaScriptSerializer().Serialize(varConfiguracion_de_Notificaciones_Datos_Generales), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varConfiguracion_de_Notificaciones_Datos_Generales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdConfiguracion_de_Notificaciones", new JavaScriptSerializer().Serialize(varConfiguracion_de_Notificaciones_Datos_Generales), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Datos_Generales(int id)
        {
            Configuracion_de_Notificaciones entity = this.service.ListaSelAll(1, 1, "Configuracion_de_Notificaciones.Folio='" + id.ToString() + "'", "").Configuracion_de_Notificacioness.First();
            Configuracion_de_Notificaciones result = new Configuracion_de_Notificaciones();
			result.Folio = entity.Folio;
result.Fecha_de_Registro = entity.Fecha_de_Registro;
result.Hora_de_Registro = entity.Hora_de_Registro;
result.Usuario_que_Registra = entity.Usuario_que_Registra;
result.Usuario_que_Registra_Spartan_User = entity.Usuario_que_Registra_Spartan_User;
result.Nombre_de_la_Notificacion = entity.Nombre_de_la_Notificacion;
result.Es_permanente = entity.Es_permanente;
result.Funcionalidad = entity.Funcionalidad;
result.Funcionalidad_Funcionalidades_para_Notificacion = entity.Funcionalidad_Funcionalidades_para_Notificacion;
result.Tipo_de_Notificacion = entity.Tipo_de_Notificacion;
result.Tipo_de_Notificacion_Tipo_de_Notificacion = entity.Tipo_de_Notificacion_Tipo_de_Notificacion;
result.Tipo_de_Accion = entity.Tipo_de_Accion;
result.Tipo_de_Accion_Tipo_de_Accion_Notificacion = entity.Tipo_de_Accion_Tipo_de_Accion_Notificacion;
result.Tipo_de_Recordatorio = entity.Tipo_de_Recordatorio;
result.Tipo_de_Recordatorio_Tipo_de_Recordatorio_Notificacion = entity.Tipo_de_Recordatorio_Tipo_de_Recordatorio_Notificacion;
result.Fecha_inicio = entity.Fecha_inicio;
result.Tiene_fecha_de_finalizacion_definida = entity.Tiene_fecha_de_finalizacion_definida;
result.Cantidad_de_dias_a_validar = entity.Cantidad_de_dias_a_validar;
result.Fecha_a_validar = entity.Fecha_a_validar;
result.Fecha_a_validar_Nombre_del_campo_en_MS = entity.Fecha_a_validar_Nombre_del_campo_en_MS;
result.Fecha_fin = entity.Fecha_fin;
result.Estatus = entity.Estatus;
result.Estatus_Estatus = entity.Estatus_Estatus;
result.Notificar_por_correo = entity.Notificar_por_correo;
result.Texto_que_llevara_el_correo = entity.Texto_que_llevara_el_correo;
result.Notificacion_push = entity.Notificacion_push;
result.Texto_a_mostrar_en_la_notificacion_Push = entity.Texto_a_mostrar_en_la_notificacion_Push;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }


		
	[Authorize]
        [HttpGet]
        public HttpResponseMessage Configuracion_de_NotificacionesGenerateID()
        {
            Configuracion_de_Notificaciones varConfiguracion_de_Notificaciones = new Configuracion_de_Notificaciones();
            var data = "-1";
            try
            {
                data = Convert.ToString(this.service.Insert(varConfiguracion_de_Notificaciones));
                var bitacora = BitacoraHelper.GetBitacora(Request, object_id, Convert.ToInt32(data), BitacoraHelper.TypeSql.INSERT, "sp_Configuracion_de_NotificacionesGenerateID", new JavaScriptSerializer().Serialize(varConfiguracion_de_Notificaciones), true);
                serviceBitacora.Insert(bitacora);
            }
            catch (ServiceException ex)
            {
                var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_Configuracion_de_NotificacionesGenerateID", new JavaScriptSerializer().Serialize(varConfiguracion_de_Notificaciones), true);
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }	
        [Authorize]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            Configuracion_de_Notificaciones varConfiguracion_de_Notificaciones = this.service.GetByKey(id, false);
            bool result = false;
            if (varConfiguracion_de_Notificaciones == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
              result=  this.service.Delete(id);//, globalData, dataReference);
			  var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.DELETE, "sp_DelConfiguracion_de_Notificaciones", new JavaScriptSerializer().Serialize(varConfiguracion_de_Notificaciones), result);
              serviceBitacora.Insert(bitacora);
            }
            catch (ServiceException ex)
            {
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.DELETE, "sp_DelConfiguracion_de_Notificaciones", new JavaScriptSerializer().Serialize(varConfiguracion_de_Notificaciones), result, ex.Message);
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
                var Configuracion_de_NotificacionesDataTable = new JavaScriptSerializer().Deserialize<List<Configuracion_de_Notificaciones>>(result);
                return Request.CreateResponse(HttpStatusCode.OK, Configuracion_de_NotificacionesDataTable, Configuration.Formatters.JsonFormatter);
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
                var Configuracion_de_NotificacionesResult = new JavaScriptSerializer().Deserialize<Configuracion_de_Notificaciones>(result);
                return Request.CreateResponse(HttpStatusCode.OK, Configuracion_de_NotificacionesResult, Configuration.Formatters.JsonFormatter);            
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
        public HttpResponseMessage PostTunnel(Configuracion_de_Notificaciones emp,string user, string password)
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
        public HttpResponseMessage PutTunnel(Configuracion_de_Notificaciones emp, string user, string password)
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

