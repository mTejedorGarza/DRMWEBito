﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Spartan_BR_Action_Configuration_Detail;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action_Configuration_Detail
{
    public class Spartan_BR_Action_Configuration_DetailApiConsumer : BaseApiConsumer,ISpartan_BR_Action_Configuration_DetailApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Spartan_BR_Action_Configuration_DetailApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Spartan_BR_Action_Configuration_Detail";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_Detail>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_Detail>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_Detail>>(true, varRecords);
            }
            catch (Exception)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_Detail>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_Detail>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_Detail>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_Detail>>(true, varRecords);
            }
            catch (Exception)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_Detail>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_Detail> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_Detail>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_Detail>(true, varRecords);
            }
            catch (Exception)
            {
                return new ApiResponse<Core.Domain.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_Detail>(false, null);
            }
        }

        public ApiResponse<Spartan_BR_Action_Configuration_DetailPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_DetailPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Spartan_BR_Action_Configuration_Detail.ActionConfigurationId='" + Key.ToString() + "'"
                        + "&Order=Spartan_BR_Action_Configuration_Detail.ActionConfigurationId ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_DetailPagingModel>(true, varRecords);

            }
            catch (Exception)
            {
                return new ApiResponse<Core.Domain.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_DetailPagingModel>(false, new Spartan_BR_Action_Configuration_DetailPagingModel() { Spartan_BR_Action_Configuration_Details = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Spartan_BR_Action_Configuration_DetailInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<bool>(baseApi, ApiControllerUrl + "/Delete?Id=" + Key,
                      Method.DELETE, ApiHeader);

                return new ApiResponse<bool>(true, result);
            }
            catch (Exception)
            {
                return new ApiResponse<bool>(false, false);
            }
        }

        public ApiResponse<int> Insert(Core.Domain.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_Detail entity, Core.Domain.User.GlobalData Spartan_BR_Action_Configuration_DetailInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Post",
                      Method.POST, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<int> Update(Core.Domain.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_Detail entity, Core.Domain.User.GlobalData Spartan_BR_Action_Configuration_DetailInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put?Id=" + entity.ActionConfigurationId,
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_Detail>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_Detail>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_Detail>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Spartan_BR_Action_Configuration_DetailPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_DetailPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_DetailPagingModel>(true, varRecords);


            }
            catch (Exception)
            {
                return new ApiResponse<Core.Domain.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_DetailPagingModel>(false, new Spartan_BR_Action_Configuration_DetailPagingModel() { Spartan_BR_Action_Configuration_Details = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_Detail>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
    }
}

