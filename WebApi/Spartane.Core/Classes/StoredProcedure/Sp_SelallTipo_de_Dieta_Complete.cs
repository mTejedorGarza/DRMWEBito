using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallTipo_de_Dieta_Complete : BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public int? Categoria_para_Platillos { get; set; }
        public string Categoria_para_Platillos_Categoria { get; set; }

    }
}
