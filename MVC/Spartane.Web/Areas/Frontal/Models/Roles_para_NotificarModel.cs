using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Roles_para_NotificarModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Rol { get; set; }
        public string RolDescripcion { get; set; }

    }
	
	public class Roles_para_Notificar_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Rol { get; set; }
        public string RolDescripcion { get; set; }

    }


}

