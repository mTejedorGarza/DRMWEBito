using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllEjercicios : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Ejercicios_Clave { get; set; }
        public DateTime? Ejercicios_Fecha_de_Registro { get; set; }
        public string Ejercicios_Hora_de_Registro { get; set; }
        public int? Ejercicios_Usuario_que_Registra { get; set; }
        public string Ejercicios_Usuario_que_Registra_Name { get; set; }
        public string Ejercicios_Nombre_del_Ejercicio { get; set; }
        public string Ejercicios_Descripcion_del_Ejercicio { get; set; }
        public int? Ejercicios_Imagen { get; set; }
        public string Ejercicios_Imagen_Nombre { get; set; }
        public int? Ejercicios_Video { get; set; }
        public string Ejercicios_Video_Nombre { get; set; }
        public int? Ejercicios_Enfoque_del_Ejercicio { get; set; }
        public string Ejercicios_Enfoque_del_Ejercicio_Descripcion { get; set; }
        public int? Ejercicios_Estatus { get; set; }
        public string Ejercicios_Estatus_Descripcion { get; set; }

    }
}
