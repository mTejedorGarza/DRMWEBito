using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallMR_Detalle_Platillo_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Platillos { get; set; }
        public int? Ingrediente { get; set; }
        public string Ingrediente_Nombre_Ingrediente { get; set; }
        public string Cantidad { get; set; }
        public decimal? Cantidad_en_Fraccion { get; set; }
        public int? Unidad { get; set; }
        public string Unidad_Unidad { get; set; }
        public string Cantidad_a_mostrar { get; set; }
        public string Ingrediente_a_mostrar { get; set; }

    }
}
