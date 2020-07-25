using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllConfiguracion_de_Notificaciones : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Configuracion_de_Notificaciones_Folio { get; set; }
        public DateTime? Configuracion_de_Notificaciones_Fecha_de_Registro { get; set; }
        public string Configuracion_de_Notificaciones_Hora_de_Registro { get; set; }
        public int? Configuracion_de_Notificaciones_Usuario_que_Registra { get; set; }
        public string Configuracion_de_Notificaciones_Usuario_que_Registra_Name { get; set; }
        public string Configuracion_de_Notificaciones_Nombre_de_la_Notificacion { get; set; }
        public bool? Configuracion_de_Notificaciones_Es_permanente { get; set; }
        public int? Configuracion_de_Notificaciones_Funcionalidad { get; set; }
        public string Configuracion_de_Notificaciones_Funcionalidad_Funcionalidad { get; set; }
        public int? Configuracion_de_Notificaciones_Tipo_de_Notificacion { get; set; }
        public string Configuracion_de_Notificaciones_Tipo_de_Notificacion_Descripcion { get; set; }
        public int? Configuracion_de_Notificaciones_Tipo_de_Accion { get; set; }
        public string Configuracion_de_Notificaciones_Tipo_de_Accion_Descripcion { get; set; }
        public int? Configuracion_de_Notificaciones_Tipo_de_Recordatorio { get; set; }
        public string Configuracion_de_Notificaciones_Tipo_de_Recordatorio_Descripcion { get; set; }
        public DateTime? Configuracion_de_Notificaciones_Fecha_inicio { get; set; }
        public bool? Configuracion_de_Notificaciones_Tiene_fecha_de_finalizacion_definida { get; set; }
        public int? Configuracion_de_Notificaciones_Cantidad_de_dias_a_validar { get; set; }
        public int? Configuracion_de_Notificaciones_Fecha_a_validar { get; set; }
        public string Configuracion_de_Notificaciones_Fecha_a_validar_Descripcion { get; set; }
        public DateTime? Configuracion_de_Notificaciones_Fecha_fin { get; set; }
        public int? Configuracion_de_Notificaciones_Estatus { get; set; }
        public string Configuracion_de_Notificaciones_Estatus_Descripcion { get; set; }
        public bool? Configuracion_de_Notificaciones_Notificar_por_correo { get; set; }
        public string Configuracion_de_Notificaciones_Texto_que_llevara_el_correo { get; set; }
        public bool? Configuracion_de_Notificaciones_Notificacion_push { get; set; }
        public string Configuracion_de_Notificaciones_Texto_a_mostrar_en_la_notificacion_Push { get; set; }

    }
}
