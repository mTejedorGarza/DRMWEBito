using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllMS_Dificultad_Platillos : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int MS_Dificultad_Platillos_Folio { get; set; }
        public int MS_Dificultad_Platillos_Folio_Platillos { get; set; }
        public int? MS_Dificultad_Platillos_Dificultad { get; set; }
        public string MS_Dificultad_Platillos_Dificultad_Categoria { get; set; }

    }
}
