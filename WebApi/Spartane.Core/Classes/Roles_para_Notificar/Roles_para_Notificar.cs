using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Configuracion_de_Notificaciones;
using Spartane.Core.Classes.Tipo_Paciente;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Roles_para_Notificar
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
        public virtual Spartane.Core.Classes.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones Folio_Configuracion_de_Notificaciones_Configuracion_de_Notificaciones { get; set; }
        [ForeignKey("Rol")]
        public virtual Spartane.Core.Classes.Tipo_Paciente.Tipo_Paciente Rol_Tipo_Paciente { get; set; }

    }
}

