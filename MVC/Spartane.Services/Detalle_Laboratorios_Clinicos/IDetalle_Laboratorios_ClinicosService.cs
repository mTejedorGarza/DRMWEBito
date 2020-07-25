using System;
using Spartane.Core.Domain.Detalle_Laboratorios_Clinicos;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Detalle_Laboratorios_Clinicos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Laboratorios_ClinicosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_ClinicosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
