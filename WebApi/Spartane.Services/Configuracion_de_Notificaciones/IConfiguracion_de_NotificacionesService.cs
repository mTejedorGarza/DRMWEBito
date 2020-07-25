using System;
using Spartane.Core.Classes.Configuracion_de_Notificaciones;
using System.Collections.Generic;


namespace Spartane.Services.Configuracion_de_Notificaciones
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IConfiguracion_de_NotificacionesService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones entity);
        Int32 Update(Spartane.Core.Classes.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones entity);
        IList<Spartane.Core.Classes.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Configuracion_de_Notificaciones.Configuracion_de_NotificacionesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones entity);

    }
}
