using System;
using Spartane.Core.Classes.Detalle_Frecuencia_Notificaciones;
using System.Collections.Generic;


namespace Spartane.Services.Detalle_Frecuencia_Notificaciones
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Frecuencia_NotificacionesService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones entity);
        Int32 Update(Spartane.Core.Classes.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones entity);
        IList<Spartane.Core.Classes.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_NotificacionesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones entity);

    }
}
