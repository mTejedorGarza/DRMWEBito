using System;
using Spartane.Core.Classes.MR_Detalle_Platillo;
using System.Collections.Generic;


namespace Spartane.Services.MR_Detalle_Platillo
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IMR_Detalle_PlatilloService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.MR_Detalle_Platillo.MR_Detalle_Platillo> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.MR_Detalle_Platillo.MR_Detalle_Platillo> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.MR_Detalle_Platillo.MR_Detalle_Platillo> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.MR_Detalle_Platillo.MR_Detalle_Platillo GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.MR_Detalle_Platillo.MR_Detalle_Platillo entity);
        Int32 Update(Spartane.Core.Classes.MR_Detalle_Platillo.MR_Detalle_Platillo entity);
        IList<Spartane.Core.Classes.MR_Detalle_Platillo.MR_Detalle_Platillo> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.MR_Detalle_Platillo.MR_Detalle_Platillo> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.MR_Detalle_Platillo.MR_Detalle_PlatilloPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.MR_Detalle_Platillo.MR_Detalle_Platillo> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.MR_Detalle_Platillo.MR_Detalle_Platillo entity);

    }
}
