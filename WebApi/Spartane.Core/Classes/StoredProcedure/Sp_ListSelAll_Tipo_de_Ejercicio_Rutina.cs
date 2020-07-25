using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllTipo_de_Ejercicio_Rutina : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Tipo_de_Ejercicio_Rutina_Folio { get; set; }
        public string Tipo_de_Ejercicio_Rutina_Descripcion { get; set; }
        public string Tipo_de_Ejercicio_Rutina_Tipo_de_Rutina { get; set; }
        public string Tipo_de_Ejercicio_Rutina_Nombre_para_Secuencia { get; set; }

    }
}
