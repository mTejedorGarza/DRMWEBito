using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Detalle_Frecuencia_Notificaciones
{
    public interface IDetalle_Frecuencia_NotificacionesApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_NotificacionesPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Frecuencia_NotificacionesInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones entity, Spartane.Core.Domain.User.GlobalData Detalle_Frecuencia_NotificacionesInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones entity, Spartane.Core.Domain.User.GlobalData Detalle_Frecuencia_NotificacionesInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_NotificacionesPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

