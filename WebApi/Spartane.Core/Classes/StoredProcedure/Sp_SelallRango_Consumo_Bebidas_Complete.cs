using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallRango_Consumo_Bebidas_Complete : BaseEntity
    {
        public int Clave { get; set; }
        public bool? Es_agua { get; set; }
        public int? Cantidad { get; set; }
        public string Unidad_de_Medida { get; set; }
        public string Descripcion { get; set; }

    }
}
