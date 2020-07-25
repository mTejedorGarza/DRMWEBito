using System;
using Spartane.Core.Classes.Tipo_de_Accion_Notificacion;
using System.Collections.Generic;


namespace Spartane.Services.Tipo_de_Accion_Notificacion
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ITipo_de_Accion_NotificacionService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Tipo_de_Accion_Notificacion.Tipo_de_Accion_Notificacion> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Tipo_de_Accion_Notificacion.Tipo_de_Accion_Notificacion> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Tipo_de_Accion_Notificacion.Tipo_de_Accion_Notificacion> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Tipo_de_Accion_Notificacion.Tipo_de_Accion_Notificacion GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Tipo_de_Accion_Notificacion.Tipo_de_Accion_Notificacion entity);
        Int32 Update(Spartane.Core.Classes.Tipo_de_Accion_Notificacion.Tipo_de_Accion_Notificacion entity);
        IList<Spartane.Core.Classes.Tipo_de_Accion_Notificacion.Tipo_de_Accion_Notificacion> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Tipo_de_Accion_Notificacion.Tipo_de_Accion_Notificacion> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Tipo_de_Accion_Notificacion.Tipo_de_Accion_NotificacionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Tipo_de_Accion_Notificacion.Tipo_de_Accion_Notificacion> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Tipo_de_Accion_Notificacion.Tipo_de_Accion_Notificacion entity);

    }
}
