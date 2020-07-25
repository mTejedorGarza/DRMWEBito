using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Platillos_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Platillos { get; set; }
        public string Cantidad { get; set; }
        public int? Unidad { get; set; }
        public int? Ingrediente { get; set; }
        public string Ingrediente_Nombre_Ingrediente { get; set; }
        public int? Unidad_SMAE { get; set; }
        public int? Porciones { get; set; }
        public string Texto_para_mostrar { get; set; }

    }
}
