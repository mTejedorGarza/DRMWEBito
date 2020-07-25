using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllEstatus_Workflow_Especialistas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Estatus_Workflow_Especialistas_Clave { get; set; }
        public string Estatus_Workflow_Especialistas_Estatus { get; set; }

    }
}
