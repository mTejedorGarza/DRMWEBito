﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Spartan_Traduction_Object;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Object
{
    public class Spartan_Traduction_ObjectApiConsumer : BaseApiConsumer,ISpartan_Traduction_ObjectApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Spartan_Traduction_ObjectApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Spartan_Traduction_Object";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_Object>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_Object>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_Object>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_Object>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_Object>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_Object>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_Object>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_Object>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_Object> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_Object>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_Object>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_Object>(false, null);
            }
        }

        public ApiResponse<Spartan_Traduction_ObjectPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_ObjectPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Spartan_Traduction_Object.IdObject='" + Key.ToString() + "'"
                        + "&Order=Spartan_Traduction_Object.IdObject ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_ObjectPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_ObjectPagingModel>(false, new Spartan_Traduction_ObjectPagingModel() { Spartan_Traduction_Objects = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Spartan_Traduction_ObjectInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_Object entity, Core.Domain.User.GlobalData Spartan_Traduction_ObjectInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_Object entity, Core.Domain.User.GlobalData Spartan_Traduction_ObjectInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put?Id=" + entity.IdObject,
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_Object>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_Object>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_Object>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Spartan_Traduction_ObjectPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_ObjectPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_ObjectPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_ObjectPagingModel>(false, new Spartan_Traduction_ObjectPagingModel() { Spartan_Traduction_Objects = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_Object>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
    }
}

