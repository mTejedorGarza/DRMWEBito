using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.MR_Detalle_Platillo;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.MR_Detalle_Platillo
{
    public class MR_Detalle_PlatilloApiConsumer : BaseApiConsumer,IMR_Detalle_PlatilloApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public MR_Detalle_PlatilloApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/MR_Detalle_Platillo";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo>(false, null);
            }
        }

        public ApiResponse<MR_Detalle_PlatilloPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.MR_Detalle_Platillo.MR_Detalle_PlatilloPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=MR_Detalle_Platillo.Folio='" + Key.ToString() + "'"
                        + "&Order=MR_Detalle_Platillo.Folio ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.MR_Detalle_Platillo.MR_Detalle_PlatilloPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.MR_Detalle_Platillo.MR_Detalle_PlatilloPagingModel>(false, new MR_Detalle_PlatilloPagingModel() { MR_Detalle_Platillos = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData MR_Detalle_PlatilloInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo entity, Core.Domain.User.GlobalData MR_Detalle_PlatilloInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo entity, Core.Domain.User.GlobalData MR_Detalle_PlatilloInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<IList<Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<MR_Detalle_PlatilloPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.MR_Detalle_Platillo.MR_Detalle_PlatilloPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.MR_Detalle_Platillo.MR_Detalle_PlatilloPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.MR_Detalle_Platillo.MR_Detalle_PlatilloPagingModel>(false, new MR_Detalle_PlatilloPagingModel() { MR_Detalle_Platillos = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<int> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/MR_Detalle_PlatilloGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }
		
public ApiResponse<int> Update_Datos_Generales(MR_Detalle_Platillo_Datos_Generales entity)
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

        public ApiResponse<MR_Detalle_Platillo_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo_Datos_Generales>(false, null);
            }
        }


    }
}

