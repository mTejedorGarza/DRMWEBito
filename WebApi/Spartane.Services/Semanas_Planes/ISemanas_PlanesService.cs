using System;
using Spartane.Core.Classes.Semanas_Planes;
using System.Collections.Generic;


namespace Spartane.Services.Semanas_Planes
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISemanas_PlanesService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Semanas_Planes.Semanas_Planes> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Semanas_Planes.Semanas_Planes> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Semanas_Planes.Semanas_Planes> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Semanas_Planes.Semanas_Planes GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Semanas_Planes.Semanas_Planes entity);
        Int32 Update(Spartane.Core.Classes.Semanas_Planes.Semanas_Planes entity);
        IList<Spartane.Core.Classes.Semanas_Planes.Semanas_Planes> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Semanas_Planes.Semanas_Planes> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Semanas_Planes.Semanas_PlanesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Semanas_Planes.Semanas_Planes> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Semanas_Planes.Semanas_Planes entity);

    }
}
