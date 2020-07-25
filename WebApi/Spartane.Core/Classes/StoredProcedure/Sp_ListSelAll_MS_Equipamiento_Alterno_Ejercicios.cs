using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllMS_Equipamiento_Alterno_Ejercicios : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int MS_Equipamiento_Alterno_Ejercicios_Folio { get; set; }
        public int MS_Equipamiento_Alterno_Ejercicios_Folio_Ejercicios { get; set; }
        public int? MS_Equipamiento_Alterno_Ejercicios_Equipamiento_Alterno { get; set; }
        public string MS_Equipamiento_Alterno_Ejercicios_Equipamiento_Alterno_Descripcion { get; set; }

    }
}
