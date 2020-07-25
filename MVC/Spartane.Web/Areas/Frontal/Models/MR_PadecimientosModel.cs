using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class MR_PadecimientosModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Padecimiento { get; set; }
        public string PadecimientoDescripcion { get; set; }

    }
	
	public class MR_Padecimientos_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Padecimiento { get; set; }
        public string PadecimientoDescripcion { get; set; }

    }


}

