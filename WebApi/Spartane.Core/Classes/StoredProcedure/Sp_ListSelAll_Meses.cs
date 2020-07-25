using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllMeses : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Meses_Clave { get; set; }
        public string Meses_Nombre { get; set; }
        public short? Meses_Cantidad_de_dias { get; set; }

    }
}
