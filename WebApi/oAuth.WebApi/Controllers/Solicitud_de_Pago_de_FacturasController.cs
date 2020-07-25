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
using Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas;
using Spartane.Services.Solicitud_de_Pago_de_Facturas;
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
    
    public partial class Solicitud_de_Pago_de_FacturasController : BaseApiController
    {
        #region Variables
        private ISolicitud_de_Pago_de_FacturasService service = null;
        public  static string ApiControllerUrl { get; set; }
		private ISpartan_Bitacora_SQLService serviceBitacora = null;
		private static int object_id = 44742;
        public string baseApi;
        #endregion Variables

        #region Constructor
        //TODO: Global Data y Data Rerence tienen que estar en un controlador base
        public Solicitud_de_Pago_de_FacturasController(ISolicitud_de_Pago_de_FacturasService service,ISpartan_Bitacora_SQLService bitacoraService)
        {
            this.service = service;
			serviceBitacora = bitacoraService;
            baseApi = ConfigurationManager.AppSettings["DBBaseURL"].ToString();
            ApiControllerUrl = "api/Solicitud_de_Pago_de_Facturas";
            
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
        public HttpResponseMessage Post(Solicitud_de_Pago_de_Facturas varSolicitud_de_Pago_de_Facturas)
        {
            if (ModelState.IsValid)
            {
                var data = "-1";
                try
                {
                    data = Convert.ToString(this.service.Insert(varSolicitud_de_Pago_de_Facturas));
					var bitacora = BitacoraHelper.GetBitacora(Request, object_id, Convert.ToInt32(data), BitacoraHelper.TypeSql.INSERT, "sp_InsSolicitud_de_Pago_de_Facturas" , new JavaScriptSerializer().Serialize(varSolicitud_de_Pago_de_Facturas), true);
                    serviceBitacora.Insert(bitacora);
                }
                catch (ServiceException ex)
                {
					var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_InsSolicitud_de_Pago_de_Facturas", new JavaScriptSerializer().Serialize(varSolicitud_de_Pago_de_Facturas), true);
                    serviceBitacora.Insert(bitacora);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                var errors= ModelState.SelectMany(m => m.Value.Errors.Select(err => err.ErrorMessage != string.Empty ? err.ErrorMessage : err.Exception.Message).ToList()).ToList();                
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_InsSolicitud_de_Pago_de_Facturas",new JavaScriptSerializer().Serialize(varSolicitud_de_Pago_de_Facturas), false, errors.ToString());
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }

        [Authorize]
        [HttpPut]
        public HttpResponseMessage Put(int id, Solicitud_de_Pago_de_Facturas varSolicitud_de_Pago_de_Facturas)
        {
            if (ModelState.IsValid && id == varSolicitud_de_Pago_de_Facturas.Folio)
            {
                var data = "-1";
                try
                {
                    data = Convert.ToString(this.service.Update(varSolicitud_de_Pago_de_Facturas));
					 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdSolicitud_de_Pago_de_Facturas", new JavaScriptSerializer().Serialize(varSolicitud_de_Pago_de_Facturas), true);
                    serviceBitacora.Insert(bitacora);
                }
                catch (ServiceException ex)
                {
				    var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdSolicitud_de_Pago_de_Facturas", new JavaScriptSerializer().Serialize(varSolicitud_de_Pago_de_Facturas), false, ex.Message);
                    serviceBitacora.Insert(bitacora);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
               var errors= ModelState.SelectMany(m => m.Value.Errors.Select(err => err.ErrorMessage != string.Empty ? err.ErrorMessage : err.Exception.Message).ToList()).ToList();                
               var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdSolicitud_de_Pago_de_Facturas", new JavaScriptSerializer().Serialize(varSolicitud_de_Pago_de_Facturas), false, String.Join(",", errors.ToArray()));
               serviceBitacora.Insert(bitacora);
               return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }
		
		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Datos_Generales(Solicitud_de_Pago_de_Facturas varSolicitud_de_Pago_de_Facturas_Datos_Generales)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Datos_Generales(varSolicitud_de_Pago_de_Facturas_Datos_Generales));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varSolicitud_de_Pago_de_Facturas_Datos_Generales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdSolicitud_de_Pago_de_Facturas", new JavaScriptSerializer().Serialize(varSolicitud_de_Pago_de_Facturas_Datos_Generales), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varSolicitud_de_Pago_de_Facturas_Datos_Generales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdSolicitud_de_Pago_de_Facturas", new JavaScriptSerializer().Serialize(varSolicitud_de_Pago_de_Facturas_Datos_Generales), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Datos_Generales(int id)
        {
            Solicitud_de_Pago_de_Facturas entity = this.service.ListaSelAll(1, 1, "Solicitud_de_Pago_de_Facturas.Folio='" + id.ToString() + "'", "").Solicitud_de_Pago_de_Facturass.First();
            Solicitud_de_Pago_de_Facturas result = new Solicitud_de_Pago_de_Facturas();
			result.Folio = entity.Folio;
result.Fecha_de_Registro = entity.Fecha_de_Registro;
result.Hora_de_Registro = entity.Hora_de_Registro;
result.Usuario_que_Registra = entity.Usuario_que_Registra;
result.Usuario_que_Registra_Spartan_User = entity.Usuario_que_Registra_Spartan_User;
result.Mes_Facturado = entity.Mes_Facturado;
result.Mes_Facturado_Meses = entity.Mes_Facturado_Meses;
result.Fecha_inicio_del_periodo_facturado = entity.Fecha_inicio_del_periodo_facturado;
result.Fecha_fin_del_periodo_facturado = entity.Fecha_fin_del_periodo_facturado;
result.Archivo_XML = entity.Archivo_XML;
result.Archivo_XML_Spartane_File = entity.Archivo_XML_Spartane_File;
result.Archivo_PDF = entity.Archivo_PDF;
result.Archivo_PDF_Spartane_File = entity.Archivo_PDF_Spartane_File;
result.Recibo_de_Solicitud_de_Pago = entity.Recibo_de_Solicitud_de_Pago;
result.Recibo_de_Solicitud_de_Pago_Spartane_File = entity.Recibo_de_Solicitud_de_Pago_Spartane_File;
result.Total = entity.Total;
result.Estatus = entity.Estatus;
result.Estatus_Estatus_Facturas = entity.Estatus_Estatus_Facturas;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Autorizacion(Solicitud_de_Pago_de_Facturas varSolicitud_de_Pago_de_Facturas_Autorizacion)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Autorizacion(varSolicitud_de_Pago_de_Facturas_Autorizacion));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varSolicitud_de_Pago_de_Facturas_Autorizacion.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdSolicitud_de_Pago_de_Facturas", new JavaScriptSerializer().Serialize(varSolicitud_de_Pago_de_Facturas_Autorizacion), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varSolicitud_de_Pago_de_Facturas_Autorizacion.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdSolicitud_de_Pago_de_Facturas", new JavaScriptSerializer().Serialize(varSolicitud_de_Pago_de_Facturas_Autorizacion), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Autorizacion(int id)
        {
            Solicitud_de_Pago_de_Facturas entity = this.service.ListaSelAll(1, 1, "Solicitud_de_Pago_de_Facturas.Folio='" + id.ToString() + "'", "").Solicitud_de_Pago_de_Facturass.First();
            Solicitud_de_Pago_de_Facturas result = new Solicitud_de_Pago_de_Facturas();
			result.Folio = entity.Folio;
result.Fecha_de_autorizacion = entity.Fecha_de_autorizacion;
result.Hora_de_autorizacion = entity.Hora_de_autorizacion;
result.Usuario_que_autoriza = entity.Usuario_que_autoriza;
result.Usuario_que_autoriza_Spartan_User = entity.Usuario_que_autoriza_Spartan_User;
result.Resultado_de_la_Revision = entity.Resultado_de_la_Revision;
result.Resultado_de_la_Revision_Resultados_de_Revision = entity.Resultado_de_la_Revision_Resultados_de_Revision;
result.Observaciones = entity.Observaciones;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Programacion_de_Pago(Solicitud_de_Pago_de_Facturas varSolicitud_de_Pago_de_Facturas_Programacion_de_Pago)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Programacion_de_Pago(varSolicitud_de_Pago_de_Facturas_Programacion_de_Pago));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varSolicitud_de_Pago_de_Facturas_Programacion_de_Pago.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdSolicitud_de_Pago_de_Facturas", new JavaScriptSerializer().Serialize(varSolicitud_de_Pago_de_Facturas_Programacion_de_Pago), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varSolicitud_de_Pago_de_Facturas_Programacion_de_Pago.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdSolicitud_de_Pago_de_Facturas", new JavaScriptSerializer().Serialize(varSolicitud_de_Pago_de_Facturas_Programacion_de_Pago), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Programacion_de_Pago(int id)
        {
            Solicitud_de_Pago_de_Facturas entity = this.service.ListaSelAll(1, 1, "Solicitud_de_Pago_de_Facturas.Folio='" + id.ToString() + "'", "").Solicitud_de_Pago_de_Facturass.First();
            Solicitud_de_Pago_de_Facturas result = new Solicitud_de_Pago_de_Facturas();
			result.Folio = entity.Folio;
result.Fecha_de_programacion = entity.Fecha_de_programacion;
result.Hora_de_programacion = entity.Hora_de_programacion;
result.Usuario_que_programa = entity.Usuario_que_programa;
result.Usuario_que_programa_Spartan_User = entity.Usuario_que_programa_Spartan_User;
result.Fecha_programada_de_Pago = entity.Fecha_programada_de_Pago;
result.Estatus_de_Pago = entity.Estatus_de_Pago;
result.Estatus_de_Pago_Estatus_de_Pago_de_Facturas = entity.Estatus_de_Pago_Estatus_de_Pago_de_Facturas;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Pago(Solicitud_de_Pago_de_Facturas varSolicitud_de_Pago_de_Facturas_Pago)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Pago(varSolicitud_de_Pago_de_Facturas_Pago));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varSolicitud_de_Pago_de_Facturas_Pago.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdSolicitud_de_Pago_de_Facturas", new JavaScriptSerializer().Serialize(varSolicitud_de_Pago_de_Facturas_Pago), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varSolicitud_de_Pago_de_Facturas_Pago.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdSolicitud_de_Pago_de_Facturas", new JavaScriptSerializer().Serialize(varSolicitud_de_Pago_de_Facturas_Pago), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Pago(int id)
        {
            Solicitud_de_Pago_de_Facturas entity = this.service.ListaSelAll(1, 1, "Solicitud_de_Pago_de_Facturas.Folio='" + id.ToString() + "'", "").Solicitud_de_Pago_de_Facturass.First();
            Solicitud_de_Pago_de_Facturas result = new Solicitud_de_Pago_de_Facturas();
			result.Folio = entity.Folio;
result.Fecha_de_actualizacion = entity.Fecha_de_actualizacion;
result.Hora_de_actualizacion = entity.Hora_de_actualizacion;
result.Usuario_que_actualiza = entity.Usuario_que_actualiza;
result.Usuario_que_actualiza_Spartan_User = entity.Usuario_que_actualiza_Spartan_User;
result.Fecha_de_Pago = entity.Fecha_de_Pago;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }


		
	[Authorize]
        [HttpGet]
        public HttpResponseMessage Solicitud_de_Pago_de_FacturasGenerateID()
        {
            Solicitud_de_Pago_de_Facturas varSolicitud_de_Pago_de_Facturas = new Solicitud_de_Pago_de_Facturas();
            var data = "-1";
            try
            {
                data = Convert.ToString(this.service.Insert(varSolicitud_de_Pago_de_Facturas));
                var bitacora = BitacoraHelper.GetBitacora(Request, object_id, Convert.ToInt32(data), BitacoraHelper.TypeSql.INSERT, "sp_Solicitud_de_Pago_de_FacturasGenerateID", new JavaScriptSerializer().Serialize(varSolicitud_de_Pago_de_Facturas), true);
                serviceBitacora.Insert(bitacora);
            }
            catch (ServiceException ex)
            {
                var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_Solicitud_de_Pago_de_FacturasGenerateID", new JavaScriptSerializer().Serialize(varSolicitud_de_Pago_de_Facturas), true);
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }	
        [Authorize]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            Solicitud_de_Pago_de_Facturas varSolicitud_de_Pago_de_Facturas = this.service.GetByKey(id, false);
            bool result = false;
            if (varSolicitud_de_Pago_de_Facturas == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
              result=  this.service.Delete(id);//, globalData, dataReference);
			  var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.DELETE, "sp_DelSolicitud_de_Pago_de_Facturas", new JavaScriptSerializer().Serialize(varSolicitud_de_Pago_de_Facturas), result);
              serviceBitacora.Insert(bitacora);
            }
            catch (ServiceException ex)
            {
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.DELETE, "sp_DelSolicitud_de_Pago_de_Facturas", new JavaScriptSerializer().Serialize(varSolicitud_de_Pago_de_Facturas), result, ex.Message);
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
                var Solicitud_de_Pago_de_FacturasDataTable = new JavaScriptSerializer().Deserialize<List<Solicitud_de_Pago_de_Facturas>>(result);
                return Request.CreateResponse(HttpStatusCode.OK, Solicitud_de_Pago_de_FacturasDataTable, Configuration.Formatters.JsonFormatter);
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
                var Solicitud_de_Pago_de_FacturasResult = new JavaScriptSerializer().Deserialize<Solicitud_de_Pago_de_Facturas>(result);
                return Request.CreateResponse(HttpStatusCode.OK, Solicitud_de_Pago_de_FacturasResult, Configuration.Formatters.JsonFormatter);            
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
        public HttpResponseMessage PostTunnel(Solicitud_de_Pago_de_Facturas emp,string user, string password)
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
        public HttpResponseMessage PutTunnel(Solicitud_de_Pago_de_Facturas emp, string user, string password)
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

