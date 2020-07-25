using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Semanas_PlanesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Semana { get; set; }
        [Range(0, 9999999999)]
        public int? Semanas_del_mes { get; set; }

    }
	
	public class Semanas_Planes_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Semana { get; set; }
        [Range(0, 9999999999)]
        public int? Semanas_del_mes { get; set; }

    }


}

