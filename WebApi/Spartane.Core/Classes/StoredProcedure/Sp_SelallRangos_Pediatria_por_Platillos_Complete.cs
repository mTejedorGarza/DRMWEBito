using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallRangos_Pediatria_por_Platillos_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public string Nombre_de_rango { get; set; }
        public int? Edad_minima { get; set; }
        public int? Edad_maxima { get; set; }
        public bool? Tiene_padecimientos { get; set; }

    }
}
