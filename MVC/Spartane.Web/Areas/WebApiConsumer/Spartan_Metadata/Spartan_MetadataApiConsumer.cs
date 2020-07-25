﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Spartan_Metadata;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_Metadata
{
    public class Spartan_MetadataApiConsumer : BaseApiConsumer, ISpartan_MetadataApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Spartan_MetadataApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Spartan_Metadata";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_Metadata.Spartan_Metadata>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_Metadata.Spartan_Metadata>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_Metadata.Spartan_Metadata>>(true, varRecords);
            }
            catch (Exception)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_Metadata.Spartan_Metadata>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Spartan_Metadata.Spartan_Metadata>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_Metadata.Spartan_Metadata>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_Metadata.Spartan_Metadata>>(true, varRecords);
            }
            catch (Exception)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_Metadata.Spartan_Metadata>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Spartan_Metadata.Spartan_Metadata> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_Metadata.Spartan_Metadata>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_Metadata.Spartan_Metadata>(true, varRecords);
            }
            catch (Exception)
            {
                return new ApiResponse<Core.Domain.Spartan_Metadata.Spartan_Metadata>(false, null);
            }
        }

        public ApiResponse<Spartan_MetadataPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_Metadata.Spartan_MetadataPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1"
                    + "&Where=Spartan_Metadata.AttributeId='" + Key.ToString() + "'"
                    + "&Order=Spartan_Metadata.AttributeId ASC",
                 Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_Metadata.Spartan_MetadataPagingModel>(true, varRecords);

            }
            catch (Exception)
            {
                return new ApiResponse<Core.Domain.Spartan_Metadata.Spartan_MetadataPagingModel>(false, new Spartan_MetadataPagingModel() { Spartan_Metadatas = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Spartan_MetadataInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Spartan_Metadata.Spartan_Metadata entity, Core.Domain.User.GlobalData Spartan_MetadataInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Post",
                      Method.POST, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception)
            {
                return new ApiResponse<int>(false, -1);
            }
        }

        public ApiResponse<int> Update(Core.Domain.Spartan_Metadata.Spartan_Metadata entity, Core.Domain.User.GlobalData Spartan_MetadataInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put?Id=" + entity.AttributeId,
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception)
            {
                return new ApiResponse<int>(false, -1);
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_Metadata.Spartan_Metadata>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_Metadata.Spartan_Metadata>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_Metadata.Spartan_Metadata>>(baseApi, ApiControllerUrl + "/GetAll?" +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_Metadata.Spartan_Metadata>>(true, varRecords);


            }
            catch (Exception)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_Metadata.Spartan_Metadata>>(false, null);
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_Metadata.Spartan_Metadata>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Spartan_MetadataPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_Metadata.Spartan_MetadataPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_Metadata.Spartan_MetadataPagingModel>(true, varRecords);


            }
            catch (Exception)
            {
                return new ApiResponse<Core.Domain.Spartan_Metadata.Spartan_MetadataPagingModel>(false, new Spartan_MetadataPagingModel() { Spartan_Metadatas = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_Metadata.Spartan_Metadata>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
    }
}

