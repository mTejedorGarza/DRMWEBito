using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class MS_Caracteristicas_PlatilloModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Caracteristicas { get; set; }
        public string CaracteristicasCaracteristicas { get; set; }

    }
	
	public class MS_Caracteristicas_Platillo_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Caracteristicas { get; set; }
        public string CaracteristicasCaracteristicas { get; set; }

    }


}

