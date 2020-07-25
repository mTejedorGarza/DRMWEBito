using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Frecuencia_Notificaciones_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int FolioNotificacion { get; set; }
        public int? Frecuencia { get; set; }
        public string Frecuencia_Descripcion { get; set; }
        public int? Dia { get; set; }
        public string Dia_Descripcion { get; set; }
        public string Hora { get; set; }

    }
}
