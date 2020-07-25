using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Configuracion_de_Notificaciones;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Configuracion_de_Notificaciones
{
    public class Configuracion_de_NotificacionesApiConsumer : BaseApiConsumer,IConfiguracion_de_NotificacionesApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Configuracion_de_NotificacionesApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Configuracion_de_Notificaciones";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones>(false, null);
            }
        }

        public ApiResponse<Configuracion_de_NotificacionesPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_NotificacionesPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Configuracion_de_Notificaciones.Folio='" + Key.ToString() + "'"
                        + "&Order=Configuracion_de_Notificaciones.Folio ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_NotificacionesPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_NotificacionesPagingModel>(false, new Configuracion_de_NotificacionesPagingModel() { Configuracion_de_Notificacioness = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Configuracion_de_NotificacionesInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones entity, Core.Domain.User.GlobalData Configuracion_de_NotificacionesInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones entity, Core.Domain.User.GlobalData Configuracion_de_NotificacionesInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<IList<Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Configuracion_de_NotificacionesPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_NotificacionesPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_NotificacionesPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_NotificacionesPagingModel>(false, new Configuracion_de_NotificacionesPagingModel() { Configuracion_de_Notificacioness = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<int> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Configuracion_de_NotificacionesGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }
		
public ApiResponse<int> Update_Datos_Generales(Configuracion_de_Notificaciones_Datos_Generales entity)
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

        public ApiResponse<Configuracion_de_Notificaciones_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones_Datos_Generales>(false, null);
            }
        }


    }
}

