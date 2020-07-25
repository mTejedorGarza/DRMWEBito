using System;
using Spartane.Core.Classes.Resultados_de_Revision;
using System.Collections.Generic;


namespace Spartane.Services.Resultados_de_Revision
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IResultados_de_RevisionService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Resultados_de_Revision.Resultados_de_Revision> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Resultados_de_Revision.Resultados_de_Revision> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Resultados_de_Revision.Resultados_de_Revision> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Resultados_de_Revision.Resultados_de_Revision GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Resultados_de_Revision.Resultados_de_Revision entity);
        Int32 Update(Spartane.Core.Classes.Resultados_de_Revision.Resultados_de_Revision entity);
        IList<Spartane.Core.Classes.Resultados_de_Revision.Resultados_de_Revision> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Resultados_de_Revision.Resultados_de_Revision> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Resultados_de_Revision.Resultados_de_RevisionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Resultados_de_Revision.Resultados_de_Revision> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Resultados_de_Revision.Resultados_de_Revision entity);

    }
}
