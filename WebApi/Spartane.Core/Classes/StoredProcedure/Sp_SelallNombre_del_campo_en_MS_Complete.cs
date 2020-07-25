using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallNombre_del_campo_en_MS_Complete : BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public string Nombre_Fisico_del_Campo { get; set; }
        public string Nombre_Fisico_de_la_Tabla { get; set; }

    }
}
