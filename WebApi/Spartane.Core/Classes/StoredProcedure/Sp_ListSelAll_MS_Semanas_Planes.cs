using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllMS_Semanas_Planes : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int MS_Semanas_Planes_Folio { get; set; }
        public int MS_Semanas_Planes_Folio_Planes_de_Suscripcion { get; set; }
        public int? MS_Semanas_Planes_Semanas { get; set; }
        public string MS_Semanas_Planes_Semanas_Semana { get; set; }

    }
}
