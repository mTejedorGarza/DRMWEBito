using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Platillos : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Platillos_Folio { get; set; }
        public int Detalle_Platillos_Folio_Platillos { get; set; }
        public string Detalle_Platillos_Cantidad { get; set; }
        public int? Detalle_Platillos_Unidad { get; set; }
        public int? Detalle_Platillos_Ingrediente { get; set; }
        public string Detalle_Platillos_Ingrediente_Nombre_Ingrediente { get; set; }
        public int? Detalle_Platillos_Unidad_SMAE { get; set; }
        public int? Detalle_Platillos_Porciones { get; set; }
        public string Detalle_Platillos_Texto_para_mostrar { get; set; }

    }
}
