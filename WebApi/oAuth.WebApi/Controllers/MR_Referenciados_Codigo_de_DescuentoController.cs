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
using Spartane.Core.Classes.MR_Referenciados_Codigo_de_Descuento;
using Spartane.Services.MR_Referenciados_Codigo_de_Descuento;
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
    
    public partial class MR_Referenciados_Codigo_de_DescuentoController : BaseApiController
    {
        #region Variables
        private IMR_Referenciados_Codigo_de_DescuentoService service = null;
        public  static string ApiControllerUrl { get; set; }
		private ISpartan_Bitacora_SQLService serviceBitacora = null;
		private static int object_id = 44740;
        public string baseApi;
        #endregion Variables

        #region Constructor
        //TODO: Global Data y Data Rerence tienen que estar en un controlador base
        public MR_Referenciados_Codigo_de_DescuentoController(IMR_Referenciados_Codigo_de_DescuentoService service,ISpartan_Bitacora_SQLService bitacoraService)
        {
            this.service = service;
			serviceBitacora = bitacoraService;
            baseApi = ConfigurationManager.AppSettings["DBBaseURL"].ToString();
            ApiControllerUrl = "api/MR_Referenciados_Codigo_de_Descuento";
            
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
        public HttpResponseMessage Post(MR_Referenciados_Codigo_de_Descuento varMR_Referenciados_Codigo_de_Descuento)
        {
            if (ModelState.IsValid)
            {
                var data = "-1";
                try
                {
                    data = Convert.ToString(this.service.Insert(varMR_Referenciados_Codigo_de_Descuento));
					var bitacora = BitacoraHelper.GetBitacora(Request, object_id, Convert.ToInt32(data), BitacoraHelper.TypeSql.INSERT, "sp_InsMR_Referenciados_Codigo_de_Descuento" , new JavaScriptSerializer().Serialize(varMR_Referenciados_Codigo_de_Descuento), true);
                    serviceBitacora.Insert(bitacora);
                }
                catch (ServiceException ex)
                {
					var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_InsMR_Referenciados_Codigo_de_Descuento", new JavaScriptSerializer().Serialize(varMR_Referenciados_Codigo_de_Descuento), true);
                    serviceBitacora.Insert(bitacora);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                var errors= ModelState.SelectMany(m => m.Value.Errors.Select(err => err.ErrorMessage != string.Empty ? err.ErrorMessage : err.Exception.Message).ToList()).ToList();                
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_InsMR_Referenciados_Codigo_de_Descuento",new JavaScriptSerializer().Serialize(varMR_Referenciados_Codigo_de_Descuento), false, errors.ToString());
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }

        [Authorize]
        [HttpPut]
        public HttpResponseMessage Put(int id, MR_Referenciados_Codigo_de_Descuento varMR_Referenciados_Codigo_de_Descuento)
        {
            if (ModelState.IsValid && id == varMR_Referenciados_Codigo_de_Descuento.Folio)
            {
                var data = "-1";
                try
                {
                    data = Convert.ToString(this.service.Update(varMR_Referenciados_Codigo_de_Descuento));
					 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdMR_Referenciados_Codigo_de_Descuento", new JavaScriptSerializer().Serialize(varMR_Referenciados_Codigo_de_Descuento), true);
                    serviceBitacora.Insert(bitacora);
                }
                catch (ServiceException ex)
                {
				    var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdMR_Referenciados_Codigo_de_Descuento", new JavaScriptSerializer().Serialize(varMR_Referenciados_Codigo_de_Descuento), false, ex.Message);
                    serviceBitacora.Insert(bitacora);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
               var errors= ModelState.SelectMany(m => m.Value.Errors.Select(err => err.ErrorMessage != string.Empty ? err.ErrorMessage : err.Exception.Message).ToList()).ToList();                
               var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdMR_Referenciados_Codigo_de_Descuento", new JavaScriptSerializer().Serialize(varMR_Referenciados_Codigo_de_Descuento), false, String.Join(",", errors.ToArray()));
               serviceBitacora.Insert(bitacora);
               return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }
		
		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Datos_Generales(MR_Referenciados_Codigo_de_Descuento varMR_Referenciados_Codigo_de_Descuento_Datos_Generales)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Datos_Generales(varMR_Referenciados_Codigo_de_Descuento_Datos_Generales));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varMR_Referenciados_Codigo_de_Descuento_Datos_Generales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdMR_Referenciados_Codigo_de_Descuento", new JavaScriptSerializer().Serialize(varMR_Referenciados_Codigo_de_Descuento_Datos_Generales), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varMR_Referenciados_Codigo_de_Descuento_Datos_Generales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdMR_Referenciados_Codigo_de_Descuento", new JavaScriptSerializer().Serialize(varMR_Referenciados_Codigo_de_Descuento_Datos_Generales), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Datos_Generales(int id)
        {
            MR_Referenciados_Codigo_de_Descuento entity = this.service.ListaSelAll(1, 1, "MR_Referenciados_Codigo_de_Descuento.Folio='" + id.ToString() + "'", "").MR_Referenciados_Codigo_de_Descuentos.First();
            MR_Referenciados_Codigo_de_Descuento result = new MR_Referenciados_Codigo_de_Descuento();
			result.Folio = entity.Folio;
result.Tipo_de_usuario = entity.Tipo_de_usuario;
result.Tipo_de_usuario_Tipo_Paciente = entity.Tipo_de_usuario_Tipo_Paciente;
result.Usuario = entity.Usuario;
result.Usuario_Spartan_User = entity.Usuario_Spartan_User;
result.Fecha_de_aplicacion = entity.Fecha_de_aplicacion;
result.Descuento_Total = entity.Descuento_Total;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }


		
	[Authorize]
        [HttpGet]
        public HttpResponseMessage MR_Referenciados_Codigo_de_DescuentoGenerateID()
        {
            MR_Referenciados_Codigo_de_Descuento varMR_Referenciados_Codigo_de_Descuento = new MR_Referenciados_Codigo_de_Descuento();
            var data = "-1";
            try
            {
                data = Convert.ToString(this.service.Insert(varMR_Referenciados_Codigo_de_Descuento));
                var bitacora = BitacoraHelper.GetBitacora(Request, object_id, Convert.ToInt32(data), BitacoraHelper.TypeSql.INSERT, "sp_MR_Referenciados_Codigo_de_DescuentoGenerateID", new JavaScriptSerializer().Serialize(varMR_Referenciados_Codigo_de_Descuento), true);
                serviceBitacora.Insert(bitacora);
            }
            catch (ServiceException ex)
            {
                var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_MR_Referenciados_Codigo_de_DescuentoGenerateID", new JavaScriptSerializer().Serialize(varMR_Referenciados_Codigo_de_Descuento), true);
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }	
        [Authorize]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            MR_Referenciados_Codigo_de_Descuento varMR_Referenciados_Codigo_de_Descuento = this.service.GetByKey(id, false);
            bool result = false;
            if (varMR_Referenciados_Codigo_de_Descuento == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
              result=  this.service.Delete(id);//, globalData, dataReference);
			  var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.DELETE, "sp_DelMR_Referenciados_Codigo_de_Descuento", new JavaScriptSerializer().Serialize(varMR_Referenciados_Codigo_de_Descuento), result);
              serviceBitacora.Insert(bitacora);
            }
            catch (ServiceException ex)
            {
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.DELETE, "sp_DelMR_Referenciados_Codigo_de_Descuento", new JavaScriptSerializer().Serialize(varMR_Referenciados_Codigo_de_Descuento), result, ex.Message);
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
                var MR_Referenciados_Codigo_de_DescuentoDataTable = new JavaScriptSerializer().Deserialize<List<MR_Referenciados_Codigo_de_Descuento>>(result);
                return Request.CreateResponse(HttpStatusCode.OK, MR_Referenciados_Codigo_de_DescuentoDataTable, Configuration.Formatters.JsonFormatter);
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
                var MR_Referenciados_Codigo_de_DescuentoResult = new JavaScriptSerializer().Deserialize<MR_Referenciados_Codigo_de_Descuento>(result);
                return Request.CreateResponse(HttpStatusCode.OK, MR_Referenciados_Codigo_de_DescuentoResult, Configuration.Formatters.JsonFormatter);            
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
        public HttpResponseMessage PostTunnel(MR_Referenciados_Codigo_de_Descuento emp,string user, string password)
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
        public HttpResponseMessage PutTunnel(MR_Referenciados_Codigo_de_Descuento emp, string user, string password)
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

