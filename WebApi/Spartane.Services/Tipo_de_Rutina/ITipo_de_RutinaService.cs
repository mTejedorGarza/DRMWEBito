using System;
using Spartane.Core.Classes.Tipo_de_Rutina;
using System.Collections.Generic;


namespace Spartane.Services.Tipo_de_Rutina
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ITipo_de_RutinaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Tipo_de_Rutina.Tipo_de_Rutina> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Tipo_de_Rutina.Tipo_de_Rutina> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Tipo_de_Rutina.Tipo_de_Rutina> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Tipo_de_Rutina.Tipo_de_Rutina GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Tipo_de_Rutina.Tipo_de_Rutina entity);
        Int32 Update(Spartane.Core.Classes.Tipo_de_Rutina.Tipo_de_Rutina entity);
        IList<Spartane.Core.Classes.Tipo_de_Rutina.Tipo_de_Rutina> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Tipo_de_Rutina.Tipo_de_Rutina> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Tipo_de_Rutina.Tipo_de_RutinaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Tipo_de_Rutina.Tipo_de_Rutina> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Tipo_de_Rutina.Tipo_de_Rutina entity);

    }
}
