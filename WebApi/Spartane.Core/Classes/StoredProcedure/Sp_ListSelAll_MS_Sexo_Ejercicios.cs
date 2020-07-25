using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllMS_Sexo_Ejercicios : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int MS_Sexo_Ejercicios_Folio { get; set; }
        public int MS_Sexo_Ejercicios_Folio_Ejercicios { get; set; }
        public int? MS_Sexo_Ejercicios_Sexo { get; set; }
        public string MS_Sexo_Ejercicios_Sexo_Descripcion { get; set; }

    }
}
