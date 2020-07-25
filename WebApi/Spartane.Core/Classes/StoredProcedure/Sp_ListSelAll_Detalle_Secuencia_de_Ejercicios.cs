using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Secuencia_de_Ejercicios : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Secuencia_de_Ejercicios_Folio { get; set; }
        public int Detalle_Secuencia_de_Ejercicios_Folio_Configuracion_Rutinas { get; set; }
        public int? Detalle_Secuencia_de_Ejercicios_Orden_del_Ejercicio { get; set; }
        public string Detalle_Secuencia_de_Ejercicios_Orden_del_Ejercicio_Descripcion { get; set; }
        public int? Detalle_Secuencia_de_Ejercicios_Tipo_de_Ejercicio { get; set; }
        public string Detalle_Secuencia_de_Ejercicios_Tipo_de_Ejercicio_Nombre_para_Secuencia { get; set; }
        public int? Detalle_Secuencia_de_Ejercicios_Enfoque { get; set; }
        public string Detalle_Secuencia_de_Ejercicios_Enfoque_Descripcion { get; set; }
        public string Detalle_Secuencia_de_Ejercicios_Secuencia_del_Ejercicio { get; set; }

    }
}
