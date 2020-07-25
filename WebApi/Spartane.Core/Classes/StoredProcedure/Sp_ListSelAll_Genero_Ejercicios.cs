using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllGenero_Ejercicios : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Genero_Ejercicios_Folio { get; set; }
        public string Genero_Ejercicios_Descripcion { get; set; }

    }
}
