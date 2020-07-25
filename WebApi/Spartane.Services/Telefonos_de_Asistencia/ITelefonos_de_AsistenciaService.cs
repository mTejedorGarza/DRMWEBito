using System;
using Spartane.Core.Classes.Telefonos_de_Asistencia;
using System.Collections.Generic;


namespace Spartane.Services.Telefonos_de_Asistencia
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ITelefonos_de_AsistenciaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Telefonos_de_Asistencia.Telefonos_de_Asistencia> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Telefonos_de_Asistencia.Telefonos_de_Asistencia> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Telefonos_de_Asistencia.Telefonos_de_Asistencia> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Telefonos_de_Asistencia.Telefonos_de_Asistencia GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Telefonos_de_Asistencia.Telefonos_de_Asistencia entity);
        Int32 Update(Spartane.Core.Classes.Telefonos_de_Asistencia.Telefonos_de_Asistencia entity);
        IList<Spartane.Core.Classes.Telefonos_de_Asistencia.Telefonos_de_Asistencia> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Telefonos_de_Asistencia.Telefonos_de_Asistencia> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Telefonos_de_Asistencia.Telefonos_de_AsistenciaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Telefonos_de_Asistencia.Telefonos_de_Asistencia> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Telefonos_de_Asistencia.Telefonos_de_Asistencia entity);

    }
}
