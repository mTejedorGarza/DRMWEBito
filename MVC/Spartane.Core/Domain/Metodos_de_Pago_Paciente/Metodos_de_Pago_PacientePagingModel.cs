using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Metodos_de_Pago_Paciente
{
    public class Metodos_de_Pago_PacientePagingModel
    {
        public List<Spartane.Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente> Metodos_de_Pago_Pacientes { set; get; }
        public int RowCount { set; get; }
    }
}
