using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllMR_Detalle_Platillo : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int MR_Detalle_Platillo_Folio { get; set; }
        public int MR_Detalle_Platillo_Folio_Platillos { get; set; }
        public int? MR_Detalle_Platillo_Ingrediente { get; set; }
        public string MR_Detalle_Platillo_Ingrediente_Nombre_Ingrediente { get; set; }
        public string MR_Detalle_Platillo_Cantidad { get; set; }
        public decimal? MR_Detalle_Platillo_Cantidad_en_Fraccion { get; set; }
        public int? MR_Detalle_Platillo_Unidad { get; set; }
        public string MR_Detalle_Platillo_Unidad_Unidad { get; set; }
        public string MR_Detalle_Platillo_Cantidad_a_mostrar { get; set; }
        public string MR_Detalle_Platillo_Ingrediente_a_mostrar { get; set; }

    }
}
