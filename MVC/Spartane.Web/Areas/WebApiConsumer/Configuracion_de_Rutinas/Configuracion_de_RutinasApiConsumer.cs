using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Configuracion_de_Rutinas;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Configuracion_de_Rutinas
{
    public class Configuracion_de_RutinasApiConsumer : BaseApiConsumer,IConfiguracion_de_RutinasApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Configuracion_de_RutinasApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Configuracion_de_Rutinas";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas>(false, null);
            }
        }

        public ApiResponse<Configuracion_de_RutinasPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Configuracion_de_Rutinas.Configuracion_de_RutinasPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Configuracion_de_Rutinas.Folio='" + Key.ToString() + "'"
                        + "&Order=Configuracion_de_Rutinas.Folio ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Configuracion_de_Rutinas.Configuracion_de_RutinasPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Configuracion_de_Rutinas.Configuracion_de_RutinasPagingModel>(false, new Configuracion_de_RutinasPagingModel() { Configuracion_de_Rutinass = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Configuracion_de_RutinasInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas entity, Core.Domain.User.GlobalData Configuracion_de_RutinasInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas entity, Core.Domain.User.GlobalData Configuracion_de_RutinasInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<IList<Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Configuracion_de_RutinasPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Configuracion_de_Rutinas.Configuracion_de_RutinasPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Configuracion_de_Rutinas.Configuracion_de_RutinasPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Configuracion_de_Rutinas.Configuracion_de_RutinasPagingModel>(false, new Configuracion_de_RutinasPagingModel() { Configuracion_de_Rutinass = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<int> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Configuracion_de_RutinasGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }
		
public ApiResponse<int> Update_Datos_Generales(Configuracion_de_Rutinas_Datos_Generales entity)
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

        public ApiResponse<Configuracion_de_Rutinas_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas_Datos_Generales>(false, null);
            }
        }


    }
}

