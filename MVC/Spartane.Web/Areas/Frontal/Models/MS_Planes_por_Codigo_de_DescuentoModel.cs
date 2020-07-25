using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class MS_Planes_por_Codigo_de_DescuentoModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Planes_de_Suscripcion { get; set; }
        public string Planes_de_SuscripcionNombre_del_Plan { get; set; }

    }
	
	public class MS_Planes_por_Codigo_de_Descuento_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Planes_de_Suscripcion { get; set; }
        public string Planes_de_SuscripcionNombre_del_Plan { get; set; }

    }


}

