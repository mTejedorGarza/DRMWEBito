using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllMS_Caracteristicas_Platillo : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int MS_Caracteristicas_Platillo_Folio { get; set; }
        public int MS_Caracteristicas_Platillo_Folio_Platillos { get; set; }
        public int? MS_Caracteristicas_Platillo_Caracteristicas { get; set; }
        public string MS_Caracteristicas_Platillo_Caracteristicas_Caracteristicas { get; set; }

    }
}
