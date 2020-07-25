using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Ejercicios_RutinasModel
    {
        [Required]
        public int Folio { get; set; }
        [Range(0, 9999999999)]
        public int? Orden_de_realizacion { get; set; }
        public string Secuencia { get; set; }
        public int? Enfoque_del_Ejercicio { get; set; }
        public string Enfoque_del_EjercicioDescripcion { get; set; }
        public int? Ejercicio { get; set; }
        public string EjercicioNombre_del_Ejercicio { get; set; }
        [Range(0, 9999999999)]
        public int? Cantidad_de_series { get; set; }
        [Range(0, 9999999999)]
        public int? Cantidad_de_repeticiones { get; set; }
        [Range(0, 9999999999)]
        public int? Descanso_en_segundos { get; set; }

    }
	
	public class Detalle_Ejercicios_Rutinas_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        [Range(0, 9999999999)]
        public int? Orden_de_realizacion { get; set; }
        public string Secuencia { get; set; }
        public int? Enfoque_del_Ejercicio { get; set; }
        public string Enfoque_del_EjercicioDescripcion { get; set; }
        public int? Ejercicio { get; set; }
        public string EjercicioNombre_del_Ejercicio { get; set; }
        [Range(0, 9999999999)]
        public int? Cantidad_de_series { get; set; }
        [Range(0, 9999999999)]
        public int? Cantidad_de_repeticiones { get; set; }
        [Range(0, 9999999999)]
        public int? Descanso_en_segundos { get; set; }

    }


}

