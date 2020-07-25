using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Rangos_Pediatria_por_Platillos;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Rangos_Pediatria_por_Platillos
{
    public class Rangos_Pediatria_por_PlatillosApiConsumer : BaseApiConsumer,IRangos_Pediatria_por_PlatillosApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Rangos_Pediatria_por_PlatillosApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Rangos_Pediatria_por_Platillos";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos>(false, null);
            }
        }

        public ApiResponse<Rangos_Pediatria_por_PlatillosPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_PlatillosPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Rangos_Pediatria_por_Platillos.Folio='" + Key.ToString() + "'"
                        + "&Order=Rangos_Pediatria_por_Platillos.Folio ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_PlatillosPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_PlatillosPagingModel>(false, new Rangos_Pediatria_por_PlatillosPagingModel() { Rangos_Pediatria_por_Platilloss = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Rangos_Pediatria_por_PlatillosInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos entity, Core.Domain.User.GlobalData Rangos_Pediatria_por_PlatillosInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos entity, Core.Domain.User.GlobalData Rangos_Pediatria_por_PlatillosInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<IList<Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Rangos_Pediatria_por_PlatillosPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_PlatillosPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_PlatillosPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_PlatillosPagingModel>(false, new Rangos_Pediatria_por_PlatillosPagingModel() { Rangos_Pediatria_por_Platilloss = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<int> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Rangos_Pediatria_por_PlatillosGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }
		
public ApiResponse<int> Update_Datos_Generales(Rangos_Pediatria_por_Platillos_Datos_Generales entity)
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

        public ApiResponse<Rangos_Pediatria_por_Platillos_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos_Datos_Generales>(false, null);
            }
        }


    }
}

