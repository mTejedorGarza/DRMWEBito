using System;
using Spartane.Core.Domain.Resultados_de_Revision;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Resultados_de_Revision
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IResultados_de_RevisionService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Resultados_de_Revision.Resultados_de_Revision> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Resultados_de_Revision.Resultados_de_Revision> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Resultados_de_Revision.Resultados_de_Revision> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Resultados_de_Revision.Resultados_de_Revision GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Resultados_de_Revision.Resultados_de_Revision entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Resultados_de_Revision.Resultados_de_Revision entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Resultados_de_Revision.Resultados_de_Revision> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Resultados_de_Revision.Resultados_de_Revision> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Resultados_de_Revision.Resultados_de_RevisionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Resultados_de_Revision.Resultados_de_Revision> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
