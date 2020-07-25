using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Detalle_Notificaciones_Paciente
{
    public class Detalle_Notificaciones_PacientePagingModel
    {
        public List<Spartane.Core.Classes.Detalle_Notificaciones_Paciente.Detalle_Notificaciones_Paciente> Detalle_Notificaciones_Pacientes { set; get; }
        public int RowCount { set; get; }
    }
}
