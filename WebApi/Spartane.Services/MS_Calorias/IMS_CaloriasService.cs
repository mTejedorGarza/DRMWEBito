using System;
using Spartane.Core.Classes.MS_Calorias;
using System.Collections.Generic;


namespace Spartane.Services.MS_Calorias
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IMS_CaloriasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.MS_Calorias.MS_Calorias> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.MS_Calorias.MS_Calorias> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.MS_Calorias.MS_Calorias> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.MS_Calorias.MS_Calorias GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.MS_Calorias.MS_Calorias entity);
        Int32 Update(Spartane.Core.Classes.MS_Calorias.MS_Calorias entity);
        IList<Spartane.Core.Classes.MS_Calorias.MS_Calorias> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.MS_Calorias.MS_Calorias> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.MS_Calorias.MS_CaloriasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.MS_Calorias.MS_Calorias> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.MS_Calorias.MS_Calorias entity);

    }
}
