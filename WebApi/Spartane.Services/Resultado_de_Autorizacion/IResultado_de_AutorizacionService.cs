using System;
using Spartane.Core.Classes.Resultado_de_Autorizacion;
using System.Collections.Generic;


namespace Spartane.Services.Resultado_de_Autorizacion
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IResultado_de_AutorizacionService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Resultado_de_Autorizacion.Resultado_de_Autorizacion> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Resultado_de_Autorizacion.Resultado_de_Autorizacion> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Resultado_de_Autorizacion.Resultado_de_Autorizacion> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Resultado_de_Autorizacion.Resultado_de_Autorizacion GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Resultado_de_Autorizacion.Resultado_de_Autorizacion entity);
        Int32 Update(Spartane.Core.Classes.Resultado_de_Autorizacion.Resultado_de_Autorizacion entity);
        IList<Spartane.Core.Classes.Resultado_de_Autorizacion.Resultado_de_Autorizacion> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Resultado_de_Autorizacion.Resultado_de_Autorizacion> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Resultado_de_Autorizacion.Resultado_de_AutorizacionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Resultado_de_Autorizacion.Resultado_de_Autorizacion> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Resultado_de_Autorizacion.Resultado_de_Autorizacion entity);

    }
}
