﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Spartan_User_Role_Status;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_User_Role_Status
{
    public class Spartan_User_Role_StatusApiConsumer : BaseApiConsumer,ISpartan_User_Role_StatusApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Spartan_User_Role_StatusApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Spartan_User_Role_Status";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status>(false, null);
            }
        }

        public ApiResponse<Spartan_User_Role_StatusPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_StatusPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Spartan_User_Role_Status.User_Role_Status_Id='" + Key.ToString() + "'"
                        + "&Order=Spartan_User_Role_Status.User_Role_Status_Id ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_StatusPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_StatusPagingModel>(false, new Spartan_User_Role_StatusPagingModel() { Spartan_User_Role_Statuss = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Spartan_User_Role_StatusInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status entity, Core.Domain.User.GlobalData Spartan_User_Role_StatusInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status entity, Core.Domain.User.GlobalData Spartan_User_Role_StatusInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put?Id=" + entity.User_Role_Status_Id,
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Spartan_User_Role_StatusPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_StatusPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_StatusPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_StatusPagingModel>(false, new Spartan_User_Role_StatusPagingModel() { Spartan_User_Role_Statuss = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Spartane.Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status>> GetAll(bool ConRelaciones)
        {
            try
            {
                var products = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Spartane.Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status>>(true, products);
            }
            catch (Exception)
            {
                return new ApiResponse<IList<Spartane.Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status>>(false, null);
            }

        }
    }
}

