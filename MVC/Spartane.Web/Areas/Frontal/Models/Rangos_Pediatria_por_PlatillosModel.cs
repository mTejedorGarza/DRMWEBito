using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Rangos_Pediatria_por_PlatillosModel
    {
        [Required]
        public int Folio { get; set; }
        public string Nombre_de_rango { get; set; }
        [Range(0, 9999999999)]
        public int? Edad_minima { get; set; }
        [Range(0, 9999999999)]
        public int? Edad_maxima { get; set; }
        public bool Tiene_padecimientos { get; set; }

    }
	
	public class Rangos_Pediatria_por_Platillos_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Nombre_de_rango { get; set; }
        [Range(0, 9999999999)]
        public int? Edad_minima { get; set; }
        [Range(0, 9999999999)]
        public int? Edad_maxima { get; set; }
        public bool? Tiene_padecimientos { get; set; }

    }


}

