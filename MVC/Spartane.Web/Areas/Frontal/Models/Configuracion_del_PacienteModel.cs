using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Configuracion_del_PacienteModel
    {
        [Required]
        public int Folio { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_Registrado { get; set; }
        public string Usuario_RegistradoName { get; set; }
        public string Rol { get; set; }
        public string Token { get; set; }
        public bool Android { get; set; }
        public bool iOS { get; set; }
        public bool Permite_notificaciones_por_email { get; set; }
        public bool Permite_notificaciones_push { get; set; }

    }
	
	public class Configuracion_del_Paciente_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_Registrado { get; set; }
        public string Usuario_RegistradoName { get; set; }
        public string Rol { get; set; }
        public string Token { get; set; }
        public bool? Android { get; set; }
        public bool? iOS { get; set; }
        public bool? Permite_notificaciones_por_email { get; set; }
        public bool? Permite_notificaciones_push { get; set; }

    }


}

