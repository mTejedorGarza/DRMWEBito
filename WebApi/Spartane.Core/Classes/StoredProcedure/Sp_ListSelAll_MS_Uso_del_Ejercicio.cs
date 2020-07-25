using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllMS_Uso_del_Ejercicio : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int MS_Uso_del_Ejercicio_Folio { get; set; }
        public int MS_Uso_del_Ejercicio_Folio_Ejercicios { get; set; }
        public int? MS_Uso_del_Ejercicio_Uso_del_Ejercicio { get; set; }
        public string MS_Uso_del_Ejercicio_Uso_del_Ejercicio_Descripcion { get; set; }

    }
}
