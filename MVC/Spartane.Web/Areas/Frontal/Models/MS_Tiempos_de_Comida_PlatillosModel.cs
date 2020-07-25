using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class MS_Tiempos_de_Comida_PlatillosModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Tiempo_de_Comida { get; set; }
        public string Tiempo_de_ComidaComida { get; set; }

    }
	
	public class MS_Tiempos_de_Comida_Platillos_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Tiempo_de_Comida { get; set; }
        public string Tiempo_de_ComidaComida { get; set; }

    }


}

