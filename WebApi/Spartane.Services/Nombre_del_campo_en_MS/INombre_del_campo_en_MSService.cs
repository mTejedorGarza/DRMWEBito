using System;
using Spartane.Core.Classes.Nombre_del_campo_en_MS;
using System.Collections.Generic;


namespace Spartane.Services.Nombre_del_campo_en_MS
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface INombre_del_campo_en_MSService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS entity);
        Int32 Update(Spartane.Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS entity);
        IList<Spartane.Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MSPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS entity);

    }
}
