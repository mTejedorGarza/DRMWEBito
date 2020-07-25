﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Actividades_del_Evento;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Actividades_del_Evento
{
    public class Actividades_del_EventoApiConsumer : BaseApiConsumer,IActividades_del_EventoApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Actividades_del_EventoApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Actividades_del_Evento";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Actividades_del_Evento.Actividades_del_Evento>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Actividades_del_Evento.Actividades_del_Evento>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Actividades_del_Evento.Actividades_del_Evento>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Actividades_del_Evento.Actividades_del_Evento>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Actividades_del_Evento.Actividades_del_Evento>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Actividades_del_Evento.Actividades_del_Evento>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Actividades_del_Evento.Actividades_del_Evento> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Actividades_del_Evento.Actividades_del_Evento>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Actividades_del_Evento.Actividades_del_Evento>(false, null);
            }
        }

        public ApiResponse<Actividades_del_EventoPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_EventoPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Actividades_del_Evento.Folio='" + Key.ToString() + "'"
                        + "&Order=Actividades_del_Evento.Folio ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Actividades_del_Evento.Actividades_del_EventoPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Actividades_del_Evento.Actividades_del_EventoPagingModel>(false, new Actividades_del_EventoPagingModel() { Actividades_del_Eventos = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Actividades_del_EventoInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Actividades_del_Evento.Actividades_del_Evento entity, Core.Domain.User.GlobalData Actividades_del_EventoInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Actividades_del_Evento.Actividades_del_Evento entity, Core.Domain.User.GlobalData Actividades_del_EventoInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<IList<Core.Domain.Actividades_del_Evento.Actividades_del_Evento>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Actividades_del_Evento.Actividades_del_Evento>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Actividades_del_Evento.Actividades_del_Evento>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Actividades_del_EventoPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_EventoPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Actividades_del_Evento.Actividades_del_EventoPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Actividades_del_Evento.Actividades_del_EventoPagingModel>(false, new Actividades_del_EventoPagingModel() { Actividades_del_Eventos = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Actividades_del_Evento.Actividades_del_Evento>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<int> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Actividades_del_EventoGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }
		
public ApiResponse<int> Update_Datos_Generales(Actividades_del_Evento_Datos_Generales entity)
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

        public ApiResponse<Actividades_del_Evento_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Actividades_del_Evento.Actividades_del_Evento_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Actividades_del_Evento.Actividades_del_Evento_Datos_Generales>(false, null);
            }
        }

public ApiResponse<int> Update_Agenda(Actividades_del_Evento_Agenda entity)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put_Agenda",
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<Actividades_del_Evento_Agenda> Get_Agenda(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento_Agenda>(baseApi, ApiControllerUrl + "/Get_Agenda?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Actividades_del_Evento.Actividades_del_Evento_Agenda>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Actividades_del_Evento.Actividades_del_Evento_Agenda>(false, null);
            }
        }

public ApiResponse<int> Update_Laboratorios_Clinicos(Actividades_del_Evento_Laboratorios_Clinicos entity)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put_Laboratorios_Clinicos",
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<Actividades_del_Evento_Laboratorios_Clinicos> Get_Laboratorios_Clinicos(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento_Laboratorios_Clinicos>(baseApi, ApiControllerUrl + "/Get_Laboratorios_Clinicos?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Actividades_del_Evento.Actividades_del_Evento_Laboratorios_Clinicos>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Actividades_del_Evento.Actividades_del_Evento_Laboratorios_Clinicos>(false, null);
            }
        }


    }
}

