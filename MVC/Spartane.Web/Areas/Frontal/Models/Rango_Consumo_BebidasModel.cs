using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Rango_Consumo_BebidasModel
    {
        [Required]
        public int Clave { get; set; }
        public bool Es_agua { get; set; }
        [Range(0, 9999999999)]
        public int? Cantidad { get; set; }
        public string Unidad_de_Medida { get; set; }
        public string Descripcion { get; set; }

    }
	
	public class Rango_Consumo_Bebidas_Datos_GeneralesModel
    {
        [Required]
        public int Clave { get; set; }
        public bool? Es_agua { get; set; }
        [Range(0, 9999999999)]
        public int? Cantidad { get; set; }
        public string Unidad_de_Medida { get; set; }
        public string Descripcion { get; set; }

    }


}

