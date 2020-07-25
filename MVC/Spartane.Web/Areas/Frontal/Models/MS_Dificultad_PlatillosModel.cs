using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class MS_Dificultad_PlatillosModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Dificultad { get; set; }
        public string DificultadCategoria { get; set; }

    }
	
	public class MS_Dificultad_Platillos_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Dificultad { get; set; }
        public string DificultadCategoria { get; set; }

    }


}

