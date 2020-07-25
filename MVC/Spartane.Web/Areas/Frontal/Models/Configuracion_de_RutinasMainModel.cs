using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Configuracion_de_RutinasMainModel
    {
        public Configuracion_de_RutinasModel Configuracion_de_RutinasInfo { set; get; }
        public Detalle_Secuencia_de_EjerciciosGridModelPost Detalle_Secuencia_de_EjerciciosGridInfo { set; get; }

    }

    public class Detalle_Secuencia_de_EjerciciosGridModelPost
    {
        public int Folio { get; set; }
        public int? Orden_del_Ejercicio { get; set; }
        public int? Tipo_de_Ejercicio { get; set; }
        public int? Enfoque { get; set; }
        public string Secuencia_del_Ejercicio { get; set; }

        public bool Removed { set; get; }
    }



}

