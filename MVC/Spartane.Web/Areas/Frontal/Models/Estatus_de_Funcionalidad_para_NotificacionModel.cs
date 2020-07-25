using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Estatus_de_Funcionalidad_para_NotificacionModel
    {
        [Required]
        public int Folio { get; set; }
        public string Campo_para_Estatus { get; set; }
        public string Nombre_Fisico_del_Campo { get; set; }
        public string Nombre_Fisico_de_la_Tabla { get; set; }

    }
	
	public class Estatus_de_Funcionalidad_para_Notificacion_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Campo_para_Estatus { get; set; }
        public string Nombre_Fisico_del_Campo { get; set; }
        public string Nombre_Fisico_de_la_Tabla { get; set; }

    }


}

