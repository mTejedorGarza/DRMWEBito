using System;
using Spartane.Core.Classes.MS_Campos_por_Funcionalidad;
using System.Collections.Generic;


namespace Spartane.Services.MS_Campos_por_Funcionalidad
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IMS_Campos_por_FuncionalidadService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad entity);
        Int32 Update(Spartane.Core.Classes.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad entity);
        IList<Spartane.Core.Classes.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.MS_Campos_por_Funcionalidad.MS_Campos_por_FuncionalidadPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad entity);

    }
}
