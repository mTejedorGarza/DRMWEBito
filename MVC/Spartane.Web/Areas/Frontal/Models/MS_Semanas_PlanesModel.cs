using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class MS_Semanas_PlanesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Semanas { get; set; }
        public string SemanasSemana { get; set; }

    }
	
	public class MS_Semanas_Planes_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Semanas { get; set; }
        public string SemanasSemana { get; set; }

    }


}

