using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Solicitud_de_Pago_de_Facturas
{
    public class Solicitud_de_Pago_de_FacturasApiConsumer : BaseApiConsumer,ISolicitud_de_Pago_de_FacturasApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Solicitud_de_Pago_de_FacturasApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Solicitud_de_Pago_de_Facturas";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas>(false, null);
            }
        }

        public ApiResponse<Solicitud_de_Pago_de_FacturasPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_FacturasPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Solicitud_de_Pago_de_Facturas.Folio='" + Key.ToString() + "'"
                        + "&Order=Solicitud_de_Pago_de_Facturas.Folio ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_FacturasPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_FacturasPagingModel>(false, new Solicitud_de_Pago_de_FacturasPagingModel() { Solicitud_de_Pago_de_Facturass = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Solicitud_de_Pago_de_FacturasInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<bool>(baseApi, ApiControllerUrl + "/Delete?Id=" + Key,
                      Method.DELETE, ApiHeader);

                return new ApiResponse<bool>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>(false, false);
            }
        }

        public ApiResponse<int> Insert(Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas entity, Core.Domain.User.GlobalData Solicitud_de_Pago_de_FacturasInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Post",
                      Method.POST, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<int> Update(Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas entity, Core.Domain.User.GlobalData Solicitud_de_Pago_de_FacturasInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put?Id=" + entity.Folio,
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<IList<Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Solicitud_de_Pago_de_FacturasPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_FacturasPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_FacturasPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_FacturasPagingModel>(false, new Solicitud_de_Pago_de_FacturasPagingModel() { Solicitud_de_Pago_de_Facturass = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<int> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Solicitud_de_Pago_de_FacturasGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }
		
public ApiResponse<int> Update_Datos_Generales(Solicitud_de_Pago_de_Facturas_Datos_Generales entity)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put_Datos_Generales",
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<Solicitud_de_Pago_de_Facturas_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas_Datos_Generales>(false, null);
            }
        }

public ApiResponse<int> Update_Autorizacion(Solicitud_de_Pago_de_Facturas_Autorizacion entity)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put_Autorizacion",
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<Solicitud_de_Pago_de_Facturas_Autorizacion> Get_Autorizacion(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas_Autorizacion>(baseApi, ApiControllerUrl + "/Get_Autorizacion?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas_Autorizacion>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas_Autorizacion>(false, null);
            }
        }

public ApiResponse<int> Update_Programacion_de_Pago(Solicitud_de_Pago_de_Facturas_Programacion_de_Pago entity)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put_Programacion_de_Pago",
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<Solicitud_de_Pago_de_Facturas_Programacion_de_Pago> Get_Programacion_de_Pago(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas_Programacion_de_Pago>(baseApi, ApiControllerUrl + "/Get_Programacion_de_Pago?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas_Programacion_de_Pago>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas_Programacion_de_Pago>(false, null);
            }
        }

public ApiResponse<int> Update_Pago(Solicitud_de_Pago_de_Facturas_Pago entity)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put_Pago",
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<Solicitud_de_Pago_de_Facturas_Pago> Get_Pago(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas_Pago>(baseApi, ApiControllerUrl + "/Get_Pago?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas_Pago>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas_Pago>(false, null);
            }
        }


    }
}

