using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllMS_Padecimientos : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int MS_Padecimientos_Folio { get; set; }
        public int MS_Padecimientos_Folio_Platillos { get; set; }
        public int? MS_Padecimientos_Categoria { get; set; }
        public string MS_Padecimientos_Categoria_Categoria { get; set; }

    }
}
