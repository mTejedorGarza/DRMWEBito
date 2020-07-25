using System;
using Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas;
using System.Collections.Generic;


namespace Spartane.Services.Solicitud_de_Pago_de_Facturas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISolicitud_de_Pago_de_FacturasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas entity);
        Int32 Update(Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas entity);
        IList<Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_FacturasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas entity);
       int Update_Autorizacion(Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas entity);
       int Update_Programacion_de_Pago(Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas entity);
       int Update_Pago(Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas entity);

    }
}
