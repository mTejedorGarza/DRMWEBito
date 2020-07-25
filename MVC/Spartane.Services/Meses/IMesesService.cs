using System;
using Spartane.Core.Domain.Meses;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Meses
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IMesesService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Meses.Meses> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Meses.Meses> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Meses.Meses> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Meses.Meses GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Meses.Meses entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Meses.Meses entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Meses.Meses> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Meses.Meses> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Meses.MesesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Meses.Meses> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
