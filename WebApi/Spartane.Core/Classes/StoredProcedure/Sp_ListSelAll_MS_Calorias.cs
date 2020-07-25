using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllMS_Calorias : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int MS_Calorias_Folio { get; set; }
        public int MS_Calorias_Folio_Platillo { get; set; }
        public int? MS_Calorias_Calorias { get; set; }
        public string MS_Calorias_Calorias_Cantidad { get; set; }

    }
}
