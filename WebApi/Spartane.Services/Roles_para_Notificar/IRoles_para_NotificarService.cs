using System;
using Spartane.Core.Classes.Roles_para_Notificar;
using System.Collections.Generic;


namespace Spartane.Services.Roles_para_Notificar
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IRoles_para_NotificarService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Roles_para_Notificar.Roles_para_Notificar> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Roles_para_Notificar.Roles_para_Notificar> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Roles_para_Notificar.Roles_para_Notificar> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Roles_para_Notificar.Roles_para_Notificar GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Roles_para_Notificar.Roles_para_Notificar entity);
        Int32 Update(Spartane.Core.Classes.Roles_para_Notificar.Roles_para_Notificar entity);
        IList<Spartane.Core.Classes.Roles_para_Notificar.Roles_para_Notificar> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Roles_para_Notificar.Roles_para_Notificar> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Roles_para_Notificar.Roles_para_NotificarPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Roles_para_Notificar.Roles_para_Notificar> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Roles_para_Notificar.Roles_para_Notificar entity);

    }
}
