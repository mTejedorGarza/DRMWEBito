using System;
using Spartane.Core.Domain.Resultado_de_Autorizacion;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Resultado_de_Autorizacion
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IResultado_de_AutorizacionService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Resultado_de_Autorizacion.Resultado_de_Autorizacion> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Resultado_de_Autorizacion.Resultado_de_Autorizacion> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Resultado_de_Autorizacion.Resultado_de_Autorizacion> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Resultado_de_Autorizacion.Resultado_de_Autorizacion GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Resultado_de_Autorizacion.Resultado_de_Autorizacion entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Resultado_de_Autorizacion.Resultado_de_Autorizacion entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Resultado_de_Autorizacion.Resultado_de_Autorizacion> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Resultado_de_Autorizacion.Resultado_de_Autorizacion> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Resultado_de_Autorizacion.Resultado_de_AutorizacionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Resultado_de_Autorizacion.Resultado_de_Autorizacion> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
