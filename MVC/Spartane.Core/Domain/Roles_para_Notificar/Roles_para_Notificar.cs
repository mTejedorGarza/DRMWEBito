using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Configuracion_de_Notificaciones;
using Spartane.Core.Domain.Tipo_Paciente;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Roles_para_Notificar
{
    /// <summary>
    /// Roles_para_Notificar table
    /// </summary>
    public class Roles_para_Notificar: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Configuracion_de_Notificaciones { get; set; }
        public int? Rol { get; set; }

        [ForeignKey("Folio_Configuracion_de_Notificaciones")]
        public virtual Spartane.Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones Folio_Configuracion_de_Notificaciones_Configuracion_de_Notificaciones { get; set; }
        [ForeignKey("Rol")]
        public virtual Spartane.Core.Domain.Tipo_Paciente.Tipo_Paciente Rol_Tipo_Paciente { get; set; }

    }
	
	public class Roles_para_Notificar_Datos_Generales
    {
                public int Folio { get; set; }
        public int? Folio_Configuracion_de_Notificaciones { get; set; }
        public int? Rol { get; set; }

		        [ForeignKey("Folio_Configuracion_de_Notificaciones")]
        public virtual Spartane.Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones Folio_Configuracion_de_Notificaciones_Configuracion_de_Notificaciones { get; set; }
        [ForeignKey("Rol")]
        public virtual Spartane.Core.Domain.Tipo_Paciente.Tipo_Paciente Rol_Tipo_Paciente { get; set; }

    }


}

