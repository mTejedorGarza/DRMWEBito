using System;
using Spartane.Core.Classes.MS_Semanas_Planes;
using System.Collections.Generic;


namespace Spartane.Services.MS_Semanas_Planes
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IMS_Semanas_PlanesService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.MS_Semanas_Planes.MS_Semanas_Planes> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.MS_Semanas_Planes.MS_Semanas_Planes> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.MS_Semanas_Planes.MS_Semanas_Planes> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.MS_Semanas_Planes.MS_Semanas_Planes GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.MS_Semanas_Planes.MS_Semanas_Planes entity);
        Int32 Update(Spartane.Core.Classes.MS_Semanas_Planes.MS_Semanas_Planes entity);
        IList<Spartane.Core.Classes.MS_Semanas_Planes.MS_Semanas_Planes> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.MS_Semanas_Planes.MS_Semanas_Planes> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.MS_Semanas_Planes.MS_Semanas_PlanesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.MS_Semanas_Planes.MS_Semanas_Planes> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.MS_Semanas_Planes.MS_Semanas_Planes entity);

    }
}
