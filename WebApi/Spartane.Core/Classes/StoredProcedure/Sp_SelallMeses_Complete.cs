using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallMeses_Complete : BaseEntity
    {
        public int Clave { get; set; }
        public string Nombre { get; set; }
        public short? Cantidad_de_dias { get; set; }

    }
}
