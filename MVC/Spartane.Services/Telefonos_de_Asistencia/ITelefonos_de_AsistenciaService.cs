using System;
using Spartane.Core.Domain.Telefonos_de_Asistencia;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Telefonos_de_Asistencia
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ITelefonos_de_AsistenciaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_AsistenciaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
