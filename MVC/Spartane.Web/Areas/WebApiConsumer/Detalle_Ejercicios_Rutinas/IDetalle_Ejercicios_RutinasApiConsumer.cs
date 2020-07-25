﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Detalle_Ejercicios_Rutinas
{
    public interface IDetalle_Ejercicios_RutinasApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_RutinasPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Ejercicios_RutinasInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas entity, Spartane.Core.Domain.User.GlobalData Detalle_Ejercicios_RutinasInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas entity, Spartane.Core.Domain.User.GlobalData Detalle_Ejercicios_RutinasInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_RutinasPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

