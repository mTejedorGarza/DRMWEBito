using System;
using Spartane.Core.Domain.MS_Campos_por_Funcionalidad;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.MS_Campos_por_Funcionalidad
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IMS_Campos_por_FuncionalidadService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_FuncionalidadPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
