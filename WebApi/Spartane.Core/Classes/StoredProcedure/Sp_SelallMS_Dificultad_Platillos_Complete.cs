using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallMS_Dificultad_Platillos_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Platillos { get; set; }
        public int? Dificultad { get; set; }
        public string Dificultad_Categoria { get; set; }

    }
}
