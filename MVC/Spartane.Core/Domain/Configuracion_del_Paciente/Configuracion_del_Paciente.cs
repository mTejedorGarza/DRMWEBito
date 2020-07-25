using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_User;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Configuracion_del_Paciente
{
    /// <summary>
    /// Configuracion_del_Paciente table
    /// </summary>
    public class Configuracion_del_Paciente: BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_Registrado { get; set; }
        public string Rol { get; set; }
        public string Token { get; set; }
        public bool? Android { get; set; }
        public bool? iOS { get; set; }
        public bool? Permite_notificaciones_por_email { get; set; }
        public bool? Permite_notificaciones_push { get; set; }

        [ForeignKey("Usuario_Registrado")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_Registrado_Spartan_User { get; set; }

    }
	
	public class Configuracion_del_Paciente_Datos_Generales
    {
                public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_Registrado { get; set; }
        public string Rol { get; set; }
        public string Token { get; set; }
        public bool? Android { get; set; }
        public bool? iOS { get; set; }
        public bool? Permite_notificaciones_por_email { get; set; }
        public bool? Permite_notificaciones_push { get; set; }

		        [ForeignKey("Usuario_Registrado")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_Registrado_Spartan_User { get; set; }

    }


}

