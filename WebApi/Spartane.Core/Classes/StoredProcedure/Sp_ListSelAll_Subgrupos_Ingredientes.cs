using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSubgrupos_Ingredientes : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Subgrupos_Ingredientes_Folio { get; set; }
        public string Subgrupos_Ingredientes_Nombre { get; set; }
        public int? Subgrupos_Ingredientes_Clasificacion { get; set; }
        public string Subgrupos_Ingredientes_Clasificacion_Descripcion { get; set; }

    }
}
