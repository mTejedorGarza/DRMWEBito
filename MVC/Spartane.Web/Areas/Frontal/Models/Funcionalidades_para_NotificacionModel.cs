using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Funcionalidades_para_NotificacionModel
    {
        [Required]
        public int Folio { get; set; }
        public string Funcionalidad { get; set; }
        public string Nombre_de_la_Tabla { get; set; }
        public int? Campos_de_Estatus { get; set; }
        public string Campos_de_EstatusCampo_para_Estatus { get; set; }
        public string Validacion_Obligatoria { get; set; }

    }
	
	public class Funcionalidades_para_Notificacion_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Funcionalidad { get; set; }
        public string Nombre_de_la_Tabla { get; set; }
        public int? Campos_de_Estatus { get; set; }
        public string Campos_de_EstatusCampo_para_Estatus { get; set; }
        public string Validacion_Obligatoria { get; set; }

    }


}

