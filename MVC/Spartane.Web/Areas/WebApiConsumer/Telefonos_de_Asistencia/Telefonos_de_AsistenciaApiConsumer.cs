using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Telefonos_de_Asistencia;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Telefonos_de_Asistencia
{
    public class Telefonos_de_AsistenciaApiConsumer : BaseApiConsumer,ITelefonos_de_AsistenciaApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Telefonos_de_AsistenciaApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Telefonos_de_Asistencia";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia>(false, null);
            }
        }

        public ApiResponse<Telefonos_de_AsistenciaPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_AsistenciaPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Telefonos_de_Asistencia.Folio='" + Key.ToString() + "'"
                        + "&Order=Telefonos_de_Asistencia.Folio ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Telefonos_de_Asistencia.Telefonos_de_AsistenciaPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Telefonos_de_Asistencia.Telefonos_de_AsistenciaPagingModel>(false, new Telefonos_de_AsistenciaPagingModel() { Telefonos_de_Asistencias = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Telefonos_de_AsistenciaInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia entity, Core.Domain.User.GlobalData Telefonos_de_AsistenciaInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia entity, Core.Domain.User.GlobalData Telefonos_de_AsistenciaInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<IList<Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Telefonos_de_AsistenciaPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_AsistenciaPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Telefonos_de_Asistencia.Telefonos_de_AsistenciaPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Telefonos_de_Asistencia.Telefonos_de_AsistenciaPagingModel>(false, new Telefonos_de_AsistenciaPagingModel() { Telefonos_de_Asistencias = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<int> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Telefonos_de_AsistenciaGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }
		
public ApiResponse<int> Update_Datos_Generales(Telefonos_de_Asistencia_Datos_Generales entity)
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

        public ApiResponse<Telefonos_de_Asistencia_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia_Datos_Generales>(false, null);
            }
        }


    }
}

