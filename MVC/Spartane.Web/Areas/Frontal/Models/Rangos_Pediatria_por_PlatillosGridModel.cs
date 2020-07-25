using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Rangos_Pediatria_por_PlatillosGridModel
    {
        public int Folio { get; set; }
        public string Nombre_de_rango { get; set; }
        public int? Edad_minima { get; set; }
        public int? Edad_maxima { get; set; }
        public bool? Tiene_padecimientos { get; set; }
        
    }
}

