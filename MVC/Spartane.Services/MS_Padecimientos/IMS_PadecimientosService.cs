using System;
using Spartane.Core.Domain.MS_Padecimientos;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.MS_Padecimientos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IMS_PadecimientosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.MS_Padecimientos.MS_Padecimientos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.MS_Padecimientos.MS_Padecimientos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.MS_Padecimientos.MS_Padecimientos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.MS_Padecimientos.MS_Padecimientos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.MS_Padecimientos.MS_Padecimientos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.MS_Padecimientos.MS_Padecimientos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.MS_Padecimientos.MS_Padecimientos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.MS_Padecimientos.MS_Padecimientos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.MS_Padecimientos.MS_PadecimientosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.MS_Padecimientos.MS_Padecimientos> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
