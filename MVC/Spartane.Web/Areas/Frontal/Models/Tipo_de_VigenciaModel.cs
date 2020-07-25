using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Tipo_de_VigenciaModel
    {
        [Required]
        public int Clave { get; set; }
        public string Vigencia { get; set; }

    }
	
	public class Tipo_de_Vigencia_Datos_GeneralesModel
    {
        [Required]
        public int Clave { get; set; }
        public string Vigencia { get; set; }

    }


}

