﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Codigos_de_Descuento;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Codigos_de_Descuento
{
    public class Codigos_de_DescuentoApiConsumer : BaseApiConsumer,ICodigos_de_DescuentoApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Codigos_de_DescuentoApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Codigos_de_Descuento";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento>(false, null);
            }
        }

        public ApiResponse<Codigos_de_DescuentoPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Codigos_de_Descuento.Codigos_de_DescuentoPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Codigos_de_Descuento.Folio='" + Key.ToString() + "'"
                        + "&Order=Codigos_de_Descuento.Folio ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Codigos_de_Descuento.Codigos_de_DescuentoPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Codigos_de_Descuento.Codigos_de_DescuentoPagingModel>(false, new Codigos_de_DescuentoPagingModel() { Codigos_de_Descuentos = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Codigos_de_DescuentoInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento entity, Core.Domain.User.GlobalData Codigos_de_DescuentoInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento entity, Core.Domain.User.GlobalData Codigos_de_DescuentoInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<IList<Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Codigos_de_DescuentoPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Codigos_de_Descuento.Codigos_de_DescuentoPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Codigos_de_Descuento.Codigos_de_DescuentoPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Codigos_de_Descuento.Codigos_de_DescuentoPagingModel>(false, new Codigos_de_DescuentoPagingModel() { Codigos_de_Descuentos = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<int> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Codigos_de_DescuentoGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }
		
public ApiResponse<int> Update_Datos_Generales(Codigos_de_Descuento_Datos_Generales entity)
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

        public ApiResponse<Codigos_de_Descuento_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento_Datos_Generales>(false, null);
            }
        }

public ApiResponse<int> Update_Autorizacion(Codigos_de_Descuento_Autorizacion entity)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put_Autorizacion",
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<Codigos_de_Descuento_Autorizacion> Get_Autorizacion(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento_Autorizacion>(baseApi, ApiControllerUrl + "/Get_Autorizacion?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento_Autorizacion>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento_Autorizacion>(false, null);
            }
        }

public ApiResponse<int> Update_Referenciados(Codigos_de_Descuento_Referenciados entity)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put_Referenciados",
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<Codigos_de_Descuento_Referenciados> Get_Referenciados(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento_Referenciados>(baseApi, ApiControllerUrl + "/Get_Referenciados?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento_Referenciados>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento_Referenciados>(false, null);
            }
        }


    }
}

