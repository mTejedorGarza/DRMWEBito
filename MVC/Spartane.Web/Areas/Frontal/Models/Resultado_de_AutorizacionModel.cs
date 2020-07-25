using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Resultado_de_AutorizacionModel
    {
        [Required]
        public int Folio { get; set; }
        public string Nombre { get; set; }

    }
	
	public class Resultado_de_Autorizacion_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Nombre { get; set; }

    }


}

