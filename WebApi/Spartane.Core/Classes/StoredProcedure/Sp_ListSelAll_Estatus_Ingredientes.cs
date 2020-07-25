using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllEstatus_Ingredientes : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Estatus_Ingredientes_Clave { get; set; }
        public string Estatus_Ingredientes_Descripcion { get; set; }

    }
}
