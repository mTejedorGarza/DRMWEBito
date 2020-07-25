using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllPadecimientos : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Padecimientos_Clave { get; set; }
        public string Padecimientos_Descripcion { get; set; }
        public int? Padecimientos_Categoria_para_Platillos { get; set; }
        public string Padecimientos_Categoria_para_Platillos_Categoria { get; set; }
        public bool? Padecimientos_Visible_para_el_Paciente { get; set; }

    }
}
