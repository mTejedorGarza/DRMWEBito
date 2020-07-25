using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Secuencia_de_EjerciciosGridModel
    {
        public int Folio { get; set; }
        public int? Orden_del_Ejercicio { get; set; }
        public string Orden_del_EjercicioDescripcion { get; set; }
        public int? Tipo_de_Ejercicio { get; set; }
        public string Tipo_de_EjercicioNombre_para_Secuencia { get; set; }
        public int? Enfoque { get; set; }
        public string EnfoqueDescripcion { get; set; }
        public string Secuencia_del_Ejercicio { get; set; }
        
    }
}

