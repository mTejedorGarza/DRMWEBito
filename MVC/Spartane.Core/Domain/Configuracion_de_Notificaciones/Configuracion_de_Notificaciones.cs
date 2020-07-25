using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Funcionalidades_para_Notificacion;
using Spartane.Core.Domain.Tipo_de_Notificacion;
using Spartane.Core.Domain.Tipo_de_Accion_Notificacion;
using Spartane.Core.Domain.Tipo_de_Recordatorio_Notificacion;
using Spartane.Core.Domain.Nombre_del_campo_en_MS;
using Spartane.Core.Domain.Estatus;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Configuracion_de_Notificaciones
{
    /// <summary>
    /// Configuracion_de_Notificaciones table
    /// </summary>
    public class Configuracion_de_Notificaciones: BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Nombre_de_la_Notificacion { get; set; }
        public bool? Es_permanente { get; set; }
        public int? Funcionalidad { get; set; }
        public int? Tipo_de_Notificacion { get; set; }
        public int? Tipo_de_Accion { get; set; }
        public int? Tipo_de_Recordatorio { get; set; }
        public DateTime? Fecha_inicio { get; set; }
        public bool? Tiene_fecha_de_finalizacion_definida { get; set; }
        public int? Cantidad_de_dias_a_validar { get; set; }
        public int? Fecha_a_validar { get; set; }
        public DateTime? Fecha_fin { get; set; }
        public int? Estatus { get; set; }
        public bool? Notificar_por_correo { get; set; }
        public string Texto_que_llevara_el_correo { get; set; }
        public bool? Notificacion_push { get; set; }
        public string Texto_a_mostrar_en_la_notificacion_Push { get; set; }

        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Funcionalidad")]
        public virtual Spartane.Core.Domain.Funcionalidades_para_Notificacion.Funcionalidades_para_Notificacion Funcionalidad_Funcionalidades_para_Notificacion { get; set; }
        [ForeignKey("Tipo_de_Notificacion")]
        public virtual Spartane.Core.Domain.Tipo_de_Notificacion.Tipo_de_Notificacion Tipo_de_Notificacion_Tipo_de_Notificacion { get; set; }
        [ForeignKey("Tipo_de_Accion")]
        public virtual Spartane.Core.Domain.Tipo_de_Accion_Notificacion.Tipo_de_Accion_Notificacion Tipo_de_Accion_Tipo_de_Accion_Notificacion { get; set; }
        [ForeignKey("Tipo_de_Recordatorio")]
        public virtual Spartane.Core.Domain.Tipo_de_Recordatorio_Notificacion.Tipo_de_Recordatorio_Notificacion Tipo_de_Recordatorio_Tipo_de_Recordatorio_Notificacion { get; set; }
        [ForeignKey("Fecha_a_validar")]
        public virtual Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS Fecha_a_validar_Nombre_del_campo_en_MS { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus.Estatus Estatus_Estatus { get; set; }

    }
	
	public class Configuracion_de_Notificaciones_Datos_Generales
    {
                public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Nombre_de_la_Notificacion { get; set; }
        public bool? Es_permanente { get; set; }
        public int? Funcionalidad { get; set; }
        public int? Tipo_de_Notificacion { get; set; }
        public int? Tipo_de_Accion { get; set; }
        public int? Tipo_de_Recordatorio { get; set; }
        public DateTime? Fecha_inicio { get; set; }
        public bool? Tiene_fecha_de_finalizacion_definida { get; set; }
        public int? Cantidad_de_dias_a_validar { get; set; }
        public int? Fecha_a_validar { get; set; }
        public DateTime? Fecha_fin { get; set; }
        public int? Estatus { get; set; }
        public bool? Notificar_por_correo { get; set; }
        public string Texto_que_llevara_el_correo { get; set; }
        public bool? Notificacion_push { get; set; }
        public string Texto_a_mostrar_en_la_notificacion_Push { get; set; }

		        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Funcionalidad")]
        public virtual Spartane.Core.Domain.Funcionalidades_para_Notificacion.Funcionalidades_para_Notificacion Funcionalidad_Funcionalidades_para_Notificacion { get; set; }
        [ForeignKey("Tipo_de_Notificacion")]
        public virtual Spartane.Core.Domain.Tipo_de_Notificacion.Tipo_de_Notificacion Tipo_de_Notificacion_Tipo_de_Notificacion { get; set; }
        [ForeignKey("Tipo_de_Accion")]
        public virtual Spartane.Core.Domain.Tipo_de_Accion_Notificacion.Tipo_de_Accion_Notificacion Tipo_de_Accion_Tipo_de_Accion_Notificacion { get; set; }
        [ForeignKey("Tipo_de_Recordatorio")]
        public virtual Spartane.Core.Domain.Tipo_de_Recordatorio_Notificacion.Tipo_de_Recordatorio_Notificacion Tipo_de_Recordatorio_Tipo_de_Recordatorio_Notificacion { get; set; }
        [ForeignKey("Fecha_a_validar")]
        public virtual Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS Fecha_a_validar_Nombre_del_campo_en_MS { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus.Estatus Estatus_Estatus { get; set; }

    }


}

