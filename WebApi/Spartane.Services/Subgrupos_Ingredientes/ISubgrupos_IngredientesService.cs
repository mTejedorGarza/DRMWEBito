using System;
using Spartane.Core.Classes.Subgrupos_Ingredientes;
using System.Collections.Generic;


namespace Spartane.Services.Subgrupos_Ingredientes
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISubgrupos_IngredientesService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Subgrupos_Ingredientes.Subgrupos_Ingredientes> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Subgrupos_Ingredientes.Subgrupos_Ingredientes> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Subgrupos_Ingredientes.Subgrupos_Ingredientes> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Subgrupos_Ingredientes.Subgrupos_Ingredientes GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Subgrupos_Ingredientes.Subgrupos_Ingredientes entity);
        Int32 Update(Spartane.Core.Classes.Subgrupos_Ingredientes.Subgrupos_Ingredientes entity);
        IList<Spartane.Core.Classes.Subgrupos_Ingredientes.Subgrupos_Ingredientes> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Subgrupos_Ingredientes.Subgrupos_Ingredientes> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Subgrupos_Ingredientes.Subgrupos_IngredientesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Subgrupos_Ingredientes.Subgrupos_Ingredientes> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Subgrupos_Ingredientes.Subgrupos_Ingredientes entity);

    }
}
