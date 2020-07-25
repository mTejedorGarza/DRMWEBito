using System;
using Spartane.Core.Classes.MR_Tarjetas;
using System.Collections.Generic;


namespace Spartane.Services.MR_Tarjetas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IMR_TarjetasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.MR_Tarjetas.MR_Tarjetas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.MR_Tarjetas.MR_Tarjetas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.MR_Tarjetas.MR_Tarjetas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.MR_Tarjetas.MR_Tarjetas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.MR_Tarjetas.MR_Tarjetas entity);
        Int32 Update(Spartane.Core.Classes.MR_Tarjetas.MR_Tarjetas entity);
        IList<Spartane.Core.Classes.MR_Tarjetas.MR_Tarjetas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.MR_Tarjetas.MR_Tarjetas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.MR_Tarjetas.MR_TarjetasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.MR_Tarjetas.MR_Tarjetas> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.MR_Tarjetas.MR_Tarjetas entity);

    }
}
