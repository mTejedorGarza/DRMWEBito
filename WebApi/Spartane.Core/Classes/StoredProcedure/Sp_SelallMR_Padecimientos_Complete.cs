using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallMR_Padecimientos_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Rangos_Pediatria_por_Platillos { get; set; }
        public int? Padecimiento { get; set; }
        public string Padecimiento_Descripcion { get; set; }

    }
}
