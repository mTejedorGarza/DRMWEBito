using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSemanas_Planes : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Semanas_Planes_Folio { get; set; }
        public string Semanas_Planes_Semana { get; set; }
        public int? Semanas_Planes_Semanas_del_mes { get; set; }

    }
}
