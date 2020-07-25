using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Ejercicios_Rutinas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Ejercicios_Rutinas_Folio { get; set; }
        public int Detalle_Ejercicios_Rutinas_Folio_Rutinas { get; set; }
        public int? Detalle_Ejercicios_Rutinas_Orden_de_realizacion { get; set; }
        public string Detalle_Ejercicios_Rutinas_Secuencia { get; set; }
        public int? Detalle_Ejercicios_Rutinas_Enfoque_del_Ejercicio { get; set; }
        public string Detalle_Ejercicios_Rutinas_Enfoque_del_Ejercicio_Descripcion { get; set; }
        public int? Detalle_Ejercicios_Rutinas_Ejercicio { get; set; }
        public string Detalle_Ejercicios_Rutinas_Ejercicio_Nombre_del_Ejercicio { get; set; }
        public int? Detalle_Ejercicios_Rutinas_Cantidad_de_series { get; set; }
        public int? Detalle_Ejercicios_Rutinas_Cantidad_de_repeticiones { get; set; }
        public int? Detalle_Ejercicios_Rutinas_Descanso_en_segundos { get; set; }

    }
}
