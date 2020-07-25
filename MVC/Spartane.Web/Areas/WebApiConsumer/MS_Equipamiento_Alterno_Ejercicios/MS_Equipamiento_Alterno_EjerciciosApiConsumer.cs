﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.MS_Equipamiento_Alterno_Ejercicios;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.MS_Equipamiento_Alterno_Ejercicios
{
    public class MS_Equipamiento_Alterno_EjerciciosApiConsumer : BaseApiConsumer,IMS_Equipamiento_Alterno_EjerciciosApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public MS_Equipamiento_Alterno_EjerciciosApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/MS_Equipamiento_Alterno_Ejercicios";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios>(false, null);
            }
        }

        public ApiResponse<MS_Equipamiento_Alterno_EjerciciosPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_EjerciciosPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=MS_Equipamiento_Alterno_Ejercicios.Folio='" + Key.ToString() + "'"
                        + "&Order=MS_Equipamiento_Alterno_Ejercicios.Folio ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_EjerciciosPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_EjerciciosPagingModel>(false, new MS_Equipamiento_Alterno_EjerciciosPagingModel() { MS_Equipamiento_Alterno_Ejercicioss = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData MS_Equipamiento_Alterno_EjerciciosInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios entity, Core.Domain.User.GlobalData MS_Equipamiento_Alterno_EjerciciosInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios entity, Core.Domain.User.GlobalData MS_Equipamiento_Alterno_EjerciciosInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<IList<Core.Domain.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<MS_Equipamiento_Alterno_EjerciciosPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_EjerciciosPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_EjerciciosPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_EjerciciosPagingModel>(false, new MS_Equipamiento_Alterno_EjerciciosPagingModel() { MS_Equipamiento_Alterno_Ejercicioss = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<int> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/MS_Equipamiento_Alterno_EjerciciosGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }
		
public ApiResponse<int> Update_Datos_Generales(MS_Equipamiento_Alterno_Ejercicios_Datos_Generales entity)
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

        public ApiResponse<MS_Equipamiento_Alterno_Ejercicios_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios_Datos_Generales>(false, null);
            }
        }


    }
}

