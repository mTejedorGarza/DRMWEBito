using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Telefonos_de_Asistencia
{
    public class Telefonos_de_AsistenciaPagingModel
    {
        public List<Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia> Telefonos_de_Asistencias { set; get; }
        public int RowCount { set; get; }
    }
}
