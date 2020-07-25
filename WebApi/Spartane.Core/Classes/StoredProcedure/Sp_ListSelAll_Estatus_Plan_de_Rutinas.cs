using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllEstatus_Plan_de_Rutinas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Estatus_Plan_de_Rutinas_Folio { get; set; }
        public string Estatus_Plan_de_Rutinas_Descripcion { get; set; }

    }
}
