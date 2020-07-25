using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Notificaciones_Paciente : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Notificaciones_Paciente_Folio { get; set; }
        public int Detalle_Notificaciones_Paciente_FolioConfiguracion { get; set; }
        public int? Detalle_Notificaciones_Paciente_Funcionalidad { get; set; }
        public string Detalle_Notificaciones_Paciente_Funcionalidad_Funcionalidad { get; set; }

    }
}
