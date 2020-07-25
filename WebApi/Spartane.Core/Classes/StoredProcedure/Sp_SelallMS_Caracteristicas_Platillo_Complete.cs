using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallMS_Caracteristicas_Platillo_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Platillos { get; set; }
        public int? Caracteristicas { get; set; }
        public string Caracteristicas_Caracteristicas { get; set; }

    }
}
