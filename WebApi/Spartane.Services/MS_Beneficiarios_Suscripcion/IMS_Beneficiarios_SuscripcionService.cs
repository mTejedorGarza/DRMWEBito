using System;
using Spartane.Core.Classes.MS_Beneficiarios_Suscripcion;
using System.Collections.Generic;


namespace Spartane.Services.MS_Beneficiarios_Suscripcion
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IMS_Beneficiarios_SuscripcionService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion entity);
        Int32 Update(Spartane.Core.Classes.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion entity);
        IList<Spartane.Core.Classes.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_SuscripcionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion entity);

    }
}
