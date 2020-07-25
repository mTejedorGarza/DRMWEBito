﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Interpretacion_de_porcentaje_de_grasa_corporal
{
    public class Interpretacion_de_porcentaje_de_grasa_corporalApiConsumer : BaseApiConsumer,IInterpretacion_de_porcentaje_de_grasa_corporalApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Interpretacion_de_porcentaje_de_grasa_corporalApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Interpretacion_de_porcentaje_de_grasa_corporal";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal>(false, null);
            }
        }

        public ApiResponse<Interpretacion_de_porcentaje_de_grasa_corporalPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporalPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Interpretacion_de_porcentaje_de_grasa_corporal.Folio='" + Key.ToString() + "'"
                        + "&Order=Interpretacion_de_porcentaje_de_grasa_corporal.Folio ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporalPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporalPagingModel>(false, new Interpretacion_de_porcentaje_de_grasa_corporalPagingModel() { Interpretacion_de_porcentaje_de_grasa_corporals = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Interpretacion_de_porcentaje_de_grasa_corporalInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal entity, Core.Domain.User.GlobalData Interpretacion_de_porcentaje_de_grasa_corporalInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal entity, Core.Domain.User.GlobalData Interpretacion_de_porcentaje_de_grasa_corporalInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<IList<Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Interpretacion_de_porcentaje_de_grasa_corporalPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporalPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporalPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporalPagingModel>(false, new Interpretacion_de_porcentaje_de_grasa_corporalPagingModel() { Interpretacion_de_porcentaje_de_grasa_corporals = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<int> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Interpretacion_de_porcentaje_de_grasa_corporalGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }
		
public ApiResponse<int> Update_Datos_Generales(Interpretacion_de_porcentaje_de_grasa_corporal_Datos_Generales entity)
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

        public ApiResponse<Interpretacion_de_porcentaje_de_grasa_corporal_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal_Datos_Generales>(false, null);
            }
        }


    }
}

