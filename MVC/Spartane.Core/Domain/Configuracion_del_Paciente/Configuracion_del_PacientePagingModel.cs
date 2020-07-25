using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Configuracion_del_Paciente
{
    public class Configuracion_del_PacientePagingModel
    {
        public List<Spartane.Core.Domain.Configuracion_del_Paciente.Configuracion_del_Paciente> Configuracion_del_Pacientes { set; get; }
        public int RowCount { set; get; }
    }
}
