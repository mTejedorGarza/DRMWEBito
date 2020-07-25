using System;
using Spartane.Core.Domain.Semanas_Planes;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Semanas_Planes
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISemanas_PlanesService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Semanas_Planes.Semanas_Planes> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Semanas_Planes.Semanas_Planes> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Semanas_Planes.Semanas_Planes> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Semanas_Planes.Semanas_Planes GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Semanas_Planes.Semanas_Planes entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Semanas_Planes.Semanas_Planes entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Semanas_Planes.Semanas_Planes> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Semanas_Planes.Semanas_Planes> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Semanas_Planes.Semanas_PlanesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Semanas_Planes.Semanas_Planes> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
