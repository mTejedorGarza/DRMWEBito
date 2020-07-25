using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Configuracion_de_Notificaciones
{
    public class Configuracion_de_NotificacionesPagingModel
    {
        public List<Spartane.Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones> Configuracion_de_Notificacioness { set; get; }
        public int RowCount { set; get; }
    }
}
