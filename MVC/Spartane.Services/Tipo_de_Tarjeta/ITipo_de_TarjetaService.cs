using System;
using Spartane.Core.Domain.Tipo_de_Tarjeta;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Tipo_de_Tarjeta
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ITipo_de_TarjetaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Tipo_de_Tarjeta.Tipo_de_Tarjeta> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Tipo_de_Tarjeta.Tipo_de_Tarjeta> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Tipo_de_Tarjeta.Tipo_de_Tarjeta> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Tipo_de_Tarjeta.Tipo_de_Tarjeta GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Tipo_de_Tarjeta.Tipo_de_Tarjeta entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Tipo_de_Tarjeta.Tipo_de_Tarjeta entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Tipo_de_Tarjeta.Tipo_de_Tarjeta> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Tipo_de_Tarjeta.Tipo_de_Tarjeta> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Tipo_de_Tarjeta.Tipo_de_TarjetaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Tipo_de_Tarjeta.Tipo_de_Tarjeta> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
