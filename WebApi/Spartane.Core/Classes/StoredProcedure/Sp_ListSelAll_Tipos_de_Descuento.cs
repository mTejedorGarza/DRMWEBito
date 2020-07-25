using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllTipos_de_Descuento : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Tipos_de_Descuento_Clave { get; set; }
        public string Tipos_de_Descuento_Nombre { get; set; }

    }
}
