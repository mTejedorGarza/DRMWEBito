using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllMetodos_de_Pago_Paciente : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Metodos_de_Pago_Paciente_Folio { get; set; }
        public DateTime? Metodos_de_Pago_Paciente_Fecha_de_Registro { get; set; }
        public string Metodos_de_Pago_Paciente_Hora_de_Registro { get; set; }
        public int? Metodos_de_Pago_Paciente_Usuario_que_Registra { get; set; }
        public string Metodos_de_Pago_Paciente_Usuario_que_Registra_Name { get; set; }
        public int? Metodos_de_Pago_Paciente_Paciente { get; set; }
        public string Metodos_de_Pago_Paciente_Paciente_Name { get; set; }

    }
}
