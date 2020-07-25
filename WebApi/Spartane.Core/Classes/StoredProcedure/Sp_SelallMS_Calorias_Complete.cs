using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallMS_Calorias_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Platillo { get; set; }
        public int? Calorias { get; set; }
        public string Calorias_Cantidad { get; set; }

    }
}
