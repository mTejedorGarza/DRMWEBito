using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Metodos_de_Pago_Paciente;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Metodos_de_Pago_Paciente
{
    public class Metodos_de_Pago_PacienteApiConsumer : BaseApiConsumer,IMetodos_de_Pago_PacienteApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Metodos_de_Pago_PacienteApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Metodos_de_Pago_Paciente";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente>(false, null);
            }
        }

        public ApiResponse<Metodos_de_Pago_PacientePagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_PacientePagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Metodos_de_Pago_Paciente.Folio='" + Key.ToString() + "'"
                        + "&Order=Metodos_de_Pago_Paciente.Folio ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_PacientePagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_PacientePagingModel>(false, new Metodos_de_Pago_PacientePagingModel() { Metodos_de_Pago_Pacientes = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Metodos_de_Pago_PacienteInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente entity, Core.Domain.User.GlobalData Metodos_de_Pago_PacienteInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente entity, Core.Domain.User.GlobalData Metodos_de_Pago_PacienteInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<IList<Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Metodos_de_Pago_PacientePagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_PacientePagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_PacientePagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_PacientePagingModel>(false, new Metodos_de_Pago_PacientePagingModel() { Metodos_de_Pago_Pacientes = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<int> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Metodos_de_Pago_PacienteGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }
		
public ApiResponse<int> Update_Datos_Generales(Metodos_de_Pago_Paciente_Datos_Generales entity)
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

        public ApiResponse<Metodos_de_Pago_Paciente_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente_Datos_Generales>(false, null);
            }
        }


    }
}

