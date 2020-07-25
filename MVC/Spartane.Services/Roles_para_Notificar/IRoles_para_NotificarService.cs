using System;
using Spartane.Core.Domain.Roles_para_Notificar;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Roles_para_Notificar
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IRoles_para_NotificarService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Roles_para_Notificar.Roles_para_Notificar> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Roles_para_Notificar.Roles_para_Notificar> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Roles_para_Notificar.Roles_para_Notificar> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Roles_para_Notificar.Roles_para_Notificar GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Roles_para_Notificar.Roles_para_Notificar entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Roles_para_Notificar.Roles_para_Notificar entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Roles_para_Notificar.Roles_para_Notificar> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Roles_para_Notificar.Roles_para_Notificar> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Roles_para_Notificar.Roles_para_NotificarPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Roles_para_Notificar.Roles_para_Notificar> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
