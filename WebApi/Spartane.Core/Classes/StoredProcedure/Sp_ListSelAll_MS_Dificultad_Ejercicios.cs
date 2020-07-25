using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllMS_Dificultad_Ejercicios : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int MS_Dificultad_Ejercicios_Folio { get; set; }
        public int MS_Dificultad_Ejercicios_Folio_Ejercicios { get; set; }
        public int? MS_Dificultad_Ejercicios_Nivel_de_Dificultad { get; set; }
        public string MS_Dificultad_Ejercicios_Nivel_de_Dificultad_Dificultad { get; set; }

    }
}
