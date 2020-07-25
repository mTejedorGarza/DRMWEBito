using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllTipo_Frecuencia_Notificacion : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Tipo_Frecuencia_Notificacion_Clave { get; set; }
        public string Tipo_Frecuencia_Notificacion_Descripcion { get; set; }

    }
}
