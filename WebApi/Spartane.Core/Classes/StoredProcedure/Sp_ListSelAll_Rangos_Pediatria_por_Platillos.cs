using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllRangos_Pediatria_por_Platillos : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Rangos_Pediatria_por_Platillos_Folio { get; set; }
        public string Rangos_Pediatria_por_Platillos_Nombre_de_rango { get; set; }
        public int? Rangos_Pediatria_por_Platillos_Edad_minima { get; set; }
        public int? Rangos_Pediatria_por_Platillos_Edad_maxima { get; set; }
        public bool? Rangos_Pediatria_por_Platillos_Tiene_padecimientos { get; set; }

    }
}
