using System;
using Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Solicitud_de_Pago_de_Facturas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISolicitud_de_Pago_de_FacturasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_FacturasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
