using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllNombre_del_campo_en_MS : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Nombre_del_campo_en_MS_Clave { get; set; }
        public string Nombre_del_campo_en_MS_Descripcion { get; set; }
        public string Nombre_del_campo_en_MS_Nombre_Fisico_del_Campo { get; set; }
        public string Nombre_del_campo_en_MS_Nombre_Fisico_de_la_Tabla { get; set; }

    }
}
