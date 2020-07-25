using System;
using Spartane.Core.Classes.MS_Caracteristicas_Platillo;
using System.Collections.Generic;


namespace Spartane.Services.MS_Caracteristicas_Platillo
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IMS_Caracteristicas_PlatilloService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo entity);
        Int32 Update(Spartane.Core.Classes.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo entity);
        IList<Spartane.Core.Classes.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.MS_Caracteristicas_Platillo.MS_Caracteristicas_PlatilloPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo entity);

    }
}
