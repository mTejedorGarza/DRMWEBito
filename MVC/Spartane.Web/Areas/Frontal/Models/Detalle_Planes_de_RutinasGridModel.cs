using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Planes_de_RutinasGridModel
    {
        public int Folio { get; set; }
        public int? Numero_de_Dia { get; set; }
        public string Numero_de_DiaDia { get; set; }
        public string Fecha { get; set; }
        public int? Orden_de_Realizacion { get; set; }
        public string Secuencia_del_Ejercicio { get; set; }
        public int? Enfoque_del_Ejercicio { get; set; }
        public string Enfoque_del_EjercicioDescripcion { get; set; }
        public int? Ejercicio { get; set; }
        public string EjercicioNombre_del_Ejercicio { get; set; }
        public bool? Realizado { get; set; }
        
    }
}

