using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallMS_Dificultad_Ejercicios_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Ejercicios { get; set; }
        public int? Nivel_de_Dificultad { get; set; }
        public string Nivel_de_Dificultad_Dificultad { get; set; }

    }
}
