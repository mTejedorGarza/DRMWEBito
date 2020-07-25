using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSecuencia_de_Ejercicios_en_Rutinas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Secuencia_de_Ejercicios_en_Rutinas_Folio { get; set; }
        public string Secuencia_de_Ejercicios_en_Rutinas_Descripcion { get; set; }

    }
}
