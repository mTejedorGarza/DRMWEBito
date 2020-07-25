using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Tipo_Frecuencia_Notificacion
{
    public interface ITipo_Frecuencia_NotificacionApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Tipo_Frecuencia_Notificacion.Tipo_Frecuencia_Notificacion>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Tipo_Frecuencia_Notificacion.Tipo_Frecuencia_Notificacion>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Tipo_Frecuencia_Notificacion.Tipo_Frecuencia_Notificacion> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Tipo_Frecuencia_Notificacion.Tipo_Frecuencia_NotificacionPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Tipo_Frecuencia_NotificacionInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Tipo_Frecuencia_Notificacion.Tipo_Frecuencia_Notificacion entity, Spartane.Core.Domain.User.GlobalData Tipo_Frecuencia_NotificacionInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Tipo_Frecuencia_Notificacion.Tipo_Frecuencia_Notificacion entity, Spartane.Core.Domain.User.GlobalData Tipo_Frecuencia_NotificacionInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Tipo_Frecuencia_Notificacion.Tipo_Frecuencia_Notificacion>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Tipo_Frecuencia_Notificacion.Tipo_Frecuencia_Notificacion>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Tipo_Frecuencia_Notificacion.Tipo_Frecuencia_Notificacion>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Tipo_Frecuencia_Notificacion.Tipo_Frecuencia_NotificacionPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Tipo_Frecuencia_Notificacion.Tipo_Frecuencia_Notificacion>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Tipo_Frecuencia_Notificacion.Tipo_Frecuencia_Notificacion_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Tipo_Frecuencia_Notificacion.Tipo_Frecuencia_Notificacion_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

