using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Tipo_de_Notificacion
{
    public class Tipo_de_NotificacionPagingModel
    {
        public List<Spartane.Core.Classes.Tipo_de_Notificacion.Tipo_de_Notificacion> Tipo_de_Notificacions { set; get; }
        public int RowCount { set; get; }
    }
}
