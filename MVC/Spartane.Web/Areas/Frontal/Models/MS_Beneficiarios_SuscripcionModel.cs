using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class MS_Beneficiarios_SuscripcionModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Beneficiario { get; set; }
        public string BeneficiarioDescripcion { get; set; }

    }
	
	public class MS_Beneficiarios_Suscripcion_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Beneficiario { get; set; }
        public string BeneficiarioDescripcion { get; set; }

    }


}

