using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllTelefonos_de_Asistencia : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Telefonos_de_Asistencia_Folio { get; set; }
        public string Telefonos_de_Asistencia_Telefono { get; set; }
        public string Telefonos_de_Asistencia_Departamento { get; set; }

    }
}
