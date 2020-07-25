using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllResultados_de_Revision : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Resultados_de_Revision_Folio { get; set; }
        public string Resultados_de_Revision_Nombre { get; set; }

    }
}
