using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Configuracion_de_Notificaciones;
using Spartane.Core.Domain.Tipo_Frecuencia_Notificacion;
using Spartane.Core.Domain.Tipo_Dia_Notificacion;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Detalle_Frecuencia_Notificaciones
{
    /// <summary>
    /// Detalle_Frecuencia_Notificaciones table
    /// </summary>
    public class Detalle_Frecuencia_Notificaciones: BaseEntity
    {
        public int Folio { get; set; }
        public int? FolioNotificacion { get; set; }
        public int? Frecuencia { get; set; }
        public int? Dia { get; set; }
        public string Hora { get; set; }

        [ForeignKey("FolioNotificacion")]
        public virtual Spartane.Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones FolioNotificacion_Configuracion_de_Notificaciones { get; set; }
        [ForeignKey("Frecuencia")]
        public virtual Spartane.Core.Domain.Tipo_Frecuencia_Notificacion.Tipo_Frecuencia_Notificacion Frecuencia_Tipo_Frecuencia_Notificacion { get; set; }
        [ForeignKey("Dia")]
        public virtual Spartane.Core.Domain.Tipo_Dia_Notificacion.Tipo_Dia_Notificacion Dia_Tipo_Dia_Notificacion { get; set; }

    }
	
	public class Detalle_Frecuencia_Notificaciones_Datos_Generales
    {
                public int Folio { get; set; }
        public int? FolioNotificacion { get; set; }
        public int? Frecuencia { get; set; }
        public int? Dia { get; set; }
        public string Hora { get; set; }

		        [ForeignKey("FolioNotificacion")]
        public virtual Spartane.Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones FolioNotificacion_Configuracion_de_Notificaciones { get; set; }
        [ForeignKey("Frecuencia")]
        public virtual Spartane.Core.Domain.Tipo_Frecuencia_Notificacion.Tipo_Frecuencia_Notificacion Frecuencia_Tipo_Frecuencia_Notificacion { get; set; }
        [ForeignKey("Dia")]
        public virtual Spartane.Core.Domain.Tipo_Dia_Notificacion.Tipo_Dia_Notificacion Dia_Tipo_Dia_Notificacion { get; set; }

    }


}

