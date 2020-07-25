using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallConfiguracion_de_Notificaciones_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_Registra_Name { get; set; }
        public string Nombre_de_la_Notificacion { get; set; }
        public bool? Es_permanente { get; set; }
        public int? Funcionalidad { get; set; }
        public string Funcionalidad_Funcionalidad { get; set; }
        public int? Tipo_de_Notificacion { get; set; }
        public string Tipo_de_Notificacion_Descripcion { get; set; }
        public int? Tipo_de_Accion { get; set; }
        public string Tipo_de_Accion_Descripcion { get; set; }
        public int? Tipo_de_Recordatorio { get; set; }
        public string Tipo_de_Recordatorio_Descripcion { get; set; }
        public DateTime? Fecha_inicio { get; set; }
        public bool? Tiene_fecha_de_finalizacion_definida { get; set; }
        public int? Cantidad_de_dias_a_validar { get; set; }
        public int? Fecha_a_validar { get; set; }
        public string Fecha_a_validar_Descripcion { get; set; }
        public DateTime? Fecha_fin { get; set; }
        public int? Estatus { get; set; }
        public string Estatus_Descripcion { get; set; }
        public bool? Notificar_por_correo { get; set; }
        public string Texto_que_llevara_el_correo { get; set; }
        public bool? Notificacion_push { get; set; }
        public string Texto_a_mostrar_en_la_notificacion_Push { get; set; }

    }
}
