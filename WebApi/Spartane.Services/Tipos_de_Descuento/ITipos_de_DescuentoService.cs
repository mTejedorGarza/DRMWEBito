using System;
using Spartane.Core.Classes.Tipos_de_Descuento;
using System.Collections.Generic;


namespace Spartane.Services.Tipos_de_Descuento
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ITipos_de_DescuentoService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Tipos_de_Descuento.Tipos_de_Descuento> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Tipos_de_Descuento.Tipos_de_Descuento> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Tipos_de_Descuento.Tipos_de_Descuento> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Tipos_de_Descuento.Tipos_de_Descuento GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Tipos_de_Descuento.Tipos_de_Descuento entity);
        Int32 Update(Spartane.Core.Classes.Tipos_de_Descuento.Tipos_de_Descuento entity);
        IList<Spartane.Core.Classes.Tipos_de_Descuento.Tipos_de_Descuento> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Tipos_de_Descuento.Tipos_de_Descuento> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Tipos_de_Descuento.Tipos_de_DescuentoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Tipos_de_Descuento.Tipos_de_Descuento> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Tipos_de_Descuento.Tipos_de_Descuento entity);

    }
}
