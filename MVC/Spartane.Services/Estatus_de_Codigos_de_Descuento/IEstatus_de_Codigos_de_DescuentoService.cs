using System;
using Spartane.Core.Domain.Estatus_de_Codigos_de_Descuento;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Estatus_de_Codigos_de_Descuento
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEstatus_de_Codigos_de_DescuentoService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Estatus_de_Codigos_de_Descuento.Estatus_de_Codigos_de_Descuento> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Estatus_de_Codigos_de_Descuento.Estatus_de_Codigos_de_Descuento> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Estatus_de_Codigos_de_Descuento.Estatus_de_Codigos_de_Descuento> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Estatus_de_Codigos_de_Descuento.Estatus_de_Codigos_de_Descuento GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Estatus_de_Codigos_de_Descuento.Estatus_de_Codigos_de_Descuento entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Estatus_de_Codigos_de_Descuento.Estatus_de_Codigos_de_Descuento entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Estatus_de_Codigos_de_Descuento.Estatus_de_Codigos_de_Descuento> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Estatus_de_Codigos_de_Descuento.Estatus_de_Codigos_de_Descuento> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Estatus_de_Codigos_de_Descuento.Estatus_de_Codigos_de_DescuentoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Estatus_de_Codigos_de_Descuento.Estatus_de_Codigos_de_Descuento> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
