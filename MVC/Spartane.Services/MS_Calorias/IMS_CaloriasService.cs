using System;
using Spartane.Core.Domain.MS_Calorias;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.MS_Calorias
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IMS_CaloriasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.MS_Calorias.MS_Calorias> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.MS_Calorias.MS_Calorias> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.MS_Calorias.MS_Calorias> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.MS_Calorias.MS_Calorias GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.MS_Calorias.MS_Calorias entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.MS_Calorias.MS_Calorias entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.MS_Calorias.MS_Calorias> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.MS_Calorias.MS_Calorias> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.MS_Calorias.MS_CaloriasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.MS_Calorias.MS_Calorias> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
