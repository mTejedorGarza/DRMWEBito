using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class MS_CaloriasModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Calorias { get; set; }
        public string CaloriasCantidad { get; set; }

    }
	
	public class MS_Calorias_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Calorias { get; set; }
        public string CaloriasCantidad { get; set; }

    }


}

