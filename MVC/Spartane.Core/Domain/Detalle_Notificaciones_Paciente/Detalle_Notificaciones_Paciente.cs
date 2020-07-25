using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Configuracion_del_Paciente;
using Spartane.Core.Domain.Funcionalidades_para_Notificacion;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Detalle_Notificaciones_Paciente
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
        public virtual Spartane.Core.Domain.Configuracion_del_Paciente.Configuracion_del_Paciente FolioConfiguracion_Configuracion_del_Paciente { get; set; }
        [ForeignKey("Funcionalidad")]
        public virtual Spartane.Core.Domain.Funcionalidades_para_Notificacion.Funcionalidades_para_Notificacion Funcionalidad_Funcionalidades_para_Notificacion { get; set; }

    }
	
	public class Detalle_Notificaciones_Paciente_Datos_Generales
    {
                public int Folio { get; set; }
        public int? FolioConfiguracion { get; set; }
        public int? Funcionalidad { get; set; }

		        [ForeignKey("FolioConfiguracion")]
        public virtual Spartane.Core.Domain.Configuracion_del_Paciente.Configuracion_del_Paciente FolioConfiguracion_Configuracion_del_Paciente { get; set; }
        [ForeignKey("Funcionalidad")]
        public virtual Spartane.Core.Domain.Funcionalidades_para_Notificacion.Funcionalidades_para_Notificacion Funcionalidad_Funcionalidades_para_Notificacion { get; set; }

    }


}

