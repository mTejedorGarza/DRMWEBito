using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallMS_Padecimientos_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Platillos { get; set; }
        public int? Categoria { get; set; }
        public string Categoria_Categoria { get; set; }

    }
}
