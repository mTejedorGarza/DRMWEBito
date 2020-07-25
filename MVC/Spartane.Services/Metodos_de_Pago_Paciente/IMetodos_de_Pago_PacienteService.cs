using System;
using Spartane.Core.Domain.Metodos_de_Pago_Paciente;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Metodos_de_Pago_Paciente
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IMetodos_de_Pago_PacienteService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_PacientePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
