using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllTipo_Workflow_Especialistas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Tipo_Workflow_Especialistas_Clave { get; set; }
        public string Tipo_Workflow_Especialistas_Descripcion { get; set; }

    }
}
