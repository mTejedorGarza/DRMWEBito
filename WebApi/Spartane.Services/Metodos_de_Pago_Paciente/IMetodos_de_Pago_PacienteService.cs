using System;
using Spartane.Core.Classes.Metodos_de_Pago_Paciente;
using System.Collections.Generic;


namespace Spartane.Services.Metodos_de_Pago_Paciente
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IMetodos_de_Pago_PacienteService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente entity);
        Int32 Update(Spartane.Core.Classes.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente entity);
        IList<Spartane.Core.Classes.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Metodos_de_Pago_Paciente.Metodos_de_Pago_PacientePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente entity);

    }
}
