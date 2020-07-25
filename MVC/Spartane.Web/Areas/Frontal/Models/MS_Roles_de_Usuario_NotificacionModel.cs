using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class MS_Roles_de_Usuario_NotificacionModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Nombre_del_Campo { get; set; }
        public string Nombre_del_CampoDescripcion { get; set; }

    }
	
	public class MS_Roles_de_Usuario_Notificacion_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Nombre_del_Campo { get; set; }
        public string Nombre_del_CampoDescripcion { get; set; }

    }


}

