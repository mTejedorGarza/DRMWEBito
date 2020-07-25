using System;
using Spartane.Core.Domain.Estatus_Plan_de_Rutinas;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Estatus_Plan_de_Rutinas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEstatus_Plan_de_RutinasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Estatus_Plan_de_Rutinas.Estatus_Plan_de_Rutinas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Estatus_Plan_de_Rutinas.Estatus_Plan_de_Rutinas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Estatus_Plan_de_Rutinas.Estatus_Plan_de_Rutinas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Estatus_Plan_de_Rutinas.Estatus_Plan_de_Rutinas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Estatus_Plan_de_Rutinas.Estatus_Plan_de_Rutinas entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Estatus_Plan_de_Rutinas.Estatus_Plan_de_Rutinas entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Estatus_Plan_de_Rutinas.Estatus_Plan_de_Rutinas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Estatus_Plan_de_Rutinas.Estatus_Plan_de_Rutinas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Estatus_Plan_de_Rutinas.Estatus_Plan_de_RutinasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Estatus_Plan_de_Rutinas.Estatus_Plan_de_Rutinas> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
