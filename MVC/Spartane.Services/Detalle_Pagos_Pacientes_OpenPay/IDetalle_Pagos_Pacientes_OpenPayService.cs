using System;
using Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Detalle_Pagos_Pacientes_OpenPay
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Pagos_Pacientes_OpenPayService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPayPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
