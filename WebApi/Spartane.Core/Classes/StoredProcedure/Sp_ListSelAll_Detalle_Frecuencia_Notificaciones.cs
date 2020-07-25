using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Frecuencia_Notificaciones : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Frecuencia_Notificaciones_Folio { get; set; }
        public int Detalle_Frecuencia_Notificaciones_FolioNotificacion { get; set; }
        public int? Detalle_Frecuencia_Notificaciones_Frecuencia { get; set; }
        public string Detalle_Frecuencia_Notificaciones_Frecuencia_Descripcion { get; set; }
        public int? Detalle_Frecuencia_Notificaciones_Dia { get; set; }
        public string Detalle_Frecuencia_Notificaciones_Dia_Descripcion { get; set; }
        public string Detalle_Frecuencia_Notificaciones_Hora { get; set; }

    }
}
