using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.MS_Campos_por_Funcionalidad;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.MS_Campos_por_Funcionalidad
{
    public class MS_Campos_por_FuncionalidadApiConsumer : BaseApiConsumer,IMS_Campos_por_FuncionalidadApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public MS_Campos_por_FuncionalidadApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/MS_Campos_por_Funcionalidad";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad>(false, null);
            }
        }

        public ApiResponse<MS_Campos_por_FuncionalidadPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_FuncionalidadPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=MS_Campos_por_Funcionalidad.Folio='" + Key.ToString() + "'"
                        + "&Order=MS_Campos_por_Funcionalidad.Folio ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_FuncionalidadPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_FuncionalidadPagingModel>(false, new MS_Campos_por_FuncionalidadPagingModel() { MS_Campos_por_Funcionalidads = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData MS_Campos_por_FuncionalidadInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad entity, Core.Domain.User.GlobalData MS_Campos_por_FuncionalidadInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad entity, Core.Domain.User.GlobalData MS_Campos_por_FuncionalidadInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<IList<Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<MS_Campos_por_FuncionalidadPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_FuncionalidadPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_FuncionalidadPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_FuncionalidadPagingModel>(false, new MS_Campos_por_FuncionalidadPagingModel() { MS_Campos_por_Funcionalidads = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<int> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/MS_Campos_por_FuncionalidadGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }
		
public ApiResponse<int> Update_Datos_Generales(MS_Campos_por_Funcionalidad_Datos_Generales entity)
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

        public ApiResponse<MS_Campos_por_Funcionalidad_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad_Datos_Generales>(false, null);
            }
        }


    }
}

