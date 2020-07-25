using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallTelefonos_de_Asistencia_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public string Telefono { get; set; }
        public string Departamento { get; set; }

    }
}
