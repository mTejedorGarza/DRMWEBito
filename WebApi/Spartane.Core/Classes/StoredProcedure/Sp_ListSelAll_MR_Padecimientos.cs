using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllMR_Padecimientos : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int MR_Padecimientos_Folio { get; set; }
        public int MR_Padecimientos_Folio_Rangos_Pediatria_por_Platillos { get; set; }
        public int? MR_Padecimientos_Padecimiento { get; set; }
        public string MR_Padecimientos_Padecimiento_Descripcion { get; set; }

    }
}
