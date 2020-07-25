using System;
using Spartane.Core.Domain.Tipo_Frecuencia_Notificacion;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Tipo_Frecuencia_Notificacion
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ITipo_Frecuencia_NotificacionService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Tipo_Frecuencia_Notificacion.Tipo_Frecuencia_Notificacion> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Tipo_Frecuencia_Notificacion.Tipo_Frecuencia_Notificacion> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Tipo_Frecuencia_Notificacion.Tipo_Frecuencia_Notificacion> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Tipo_Frecuencia_Notificacion.Tipo_Frecuencia_Notificacion GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Tipo_Frecuencia_Notificacion.Tipo_Frecuencia_Notificacion entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Tipo_Frecuencia_Notificacion.Tipo_Frecuencia_Notificacion entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Tipo_Frecuencia_Notificacion.Tipo_Frecuencia_Notificacion> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Tipo_Frecuencia_Notificacion.Tipo_Frecuencia_Notificacion> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Tipo_Frecuencia_Notificacion.Tipo_Frecuencia_NotificacionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Tipo_Frecuencia_Notificacion.Tipo_Frecuencia_Notificacion> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
