using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Configuracion_del_Paciente;
using Spartane.Core.Classes.Funcionalidades_para_Notificacion;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Detalle_Notificaciones_Paciente
{
    /// <summary>
    /// Detalle_Notificaciones_Paciente table
    /// </summary>
    public class Detalle_Notificaciones_Paciente: BaseEntity
    {
        public int Folio { get; set; }
        public int? FolioConfiguracion { get; set; }
        public int? Funcionalidad { get; set; }

        [ForeignKey("FolioConfiguracion")]
        public virtual Spartane.Core.Classes.Configuracion_del_Paciente.Configuracion_del_Paciente FolioConfiguracion_Configuracion_del_Paciente { get; set; }
        [ForeignKey("Funcionalidad")]
        public virtual Spartane.Core.Classes.Funcionalidades_para_Notificacion.Funcionalidades_para_Notificacion Funcionalidad_Funcionalidades_para_Notificacion { get; set; }

    }
}

