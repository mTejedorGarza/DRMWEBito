using System;
using Spartane.Core.Classes.MS_Roles_de_Usuario_Notificacion;
using System.Collections.Generic;


namespace Spartane.Services.MS_Roles_de_Usuario_Notificacion
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IMS_Roles_de_Usuario_NotificacionService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.MS_Roles_de_Usuario_Notificacion.MS_Roles_de_Usuario_Notificacion> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.MS_Roles_de_Usuario_Notificacion.MS_Roles_de_Usuario_Notificacion> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.MS_Roles_de_Usuario_Notificacion.MS_Roles_de_Usuario_Notificacion> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.MS_Roles_de_Usuario_Notificacion.MS_Roles_de_Usuario_Notificacion GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.MS_Roles_de_Usuario_Notificacion.MS_Roles_de_Usuario_Notificacion entity);
        Int32 Update(Spartane.Core.Classes.MS_Roles_de_Usuario_Notificacion.MS_Roles_de_Usuario_Notificacion entity);
        IList<Spartane.Core.Classes.MS_Roles_de_Usuario_Notificacion.MS_Roles_de_Usuario_Notificacion> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.MS_Roles_de_Usuario_Notificacion.MS_Roles_de_Usuario_Notificacion> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.MS_Roles_de_Usuario_Notificacion.MS_Roles_de_Usuario_NotificacionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.MS_Roles_de_Usuario_Notificacion.MS_Roles_de_Usuario_Notificacion> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.MS_Roles_de_Usuario_Notificacion.MS_Roles_de_Usuario_Notificacion entity);

    }
}
