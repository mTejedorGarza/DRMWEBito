using System;
using Spartane.Core.Domain.MS_Caracteristicas_Platillo;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.MS_Caracteristicas_Platillo
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IMS_Caracteristicas_PlatilloService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.MS_Caracteristicas_Platillo.MS_Caracteristicas_PlatilloPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
