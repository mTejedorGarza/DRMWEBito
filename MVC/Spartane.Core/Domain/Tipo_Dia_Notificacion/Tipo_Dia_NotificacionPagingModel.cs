using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Tipo_Dia_Notificacion
{
    public class Tipo_Dia_NotificacionPagingModel
    {
        public List<Spartane.Core.Domain.Tipo_Dia_Notificacion.Tipo_Dia_Notificacion> Tipo_Dia_Notificacions { set; get; }
        public int RowCount { set; get; }
    }
}
