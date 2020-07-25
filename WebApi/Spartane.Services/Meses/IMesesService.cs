using System;
using Spartane.Core.Classes.Meses;
using System.Collections.Generic;


namespace Spartane.Services.Meses
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IMesesService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Meses.Meses> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Meses.Meses> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Meses.Meses> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Meses.Meses GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Meses.Meses entity);
        Int32 Update(Spartane.Core.Classes.Meses.Meses entity);
        IList<Spartane.Core.Classes.Meses.Meses> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Meses.Meses> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Meses.MesesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Meses.Meses> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Meses.Meses entity);

    }
}
