using System;
using Spartane.Core.Classes.Detalle_Pagos_Pacientes_OpenPay;
using System.Collections.Generic;


namespace Spartane.Services.Detalle_Pagos_Pacientes_OpenPay
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Pagos_Pacientes_OpenPayService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay entity);
        Int32 Update(Spartane.Core.Classes.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay entity);
        IList<Spartane.Core.Classes.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPayPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay entity);

    }
}
