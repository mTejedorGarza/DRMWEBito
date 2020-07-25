using System;
using Spartane.Core.Classes.Tipo_de_Vigencia;
using System.Collections.Generic;


namespace Spartane.Services.Tipo_de_Vigencia
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ITipo_de_VigenciaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Tipo_de_Vigencia.Tipo_de_Vigencia> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Tipo_de_Vigencia.Tipo_de_Vigencia> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Tipo_de_Vigencia.Tipo_de_Vigencia> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Tipo_de_Vigencia.Tipo_de_Vigencia GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Tipo_de_Vigencia.Tipo_de_Vigencia entity);
        Int32 Update(Spartane.Core.Classes.Tipo_de_Vigencia.Tipo_de_Vigencia entity);
        IList<Spartane.Core.Classes.Tipo_de_Vigencia.Tipo_de_Vigencia> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Tipo_de_Vigencia.Tipo_de_Vigencia> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Tipo_de_Vigencia.Tipo_de_VigenciaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Tipo_de_Vigencia.Tipo_de_Vigencia> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Tipo_de_Vigencia.Tipo_de_Vigencia entity);

    }
}
