using System;
using Spartane.Core.Domain.Nombre_del_campo_en_MS;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Nombre_del_campo_en_MS
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface INombre_del_campo_en_MSService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MSPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
