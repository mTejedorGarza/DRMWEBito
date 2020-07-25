using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Configuracion_de_NotificacionesGridModel
    {
        public int Folio { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public string Nombre_de_la_Notificacion { get; set; }
        public bool? Es_permanente { get; set; }
        public int? Funcionalidad { get; set; }
        public string FuncionalidadFuncionalidad { get; set; }
        public int? Tipo_de_Notificacion { get; set; }
        public string Tipo_de_NotificacionDescripcion { get; set; }
        public int? Tipo_de_Accion { get; set; }
        public string Tipo_de_AccionDescripcion { get; set; }
        public int? Tipo_de_Recordatorio { get; set; }
        public string Tipo_de_RecordatorioDescripcion { get; set; }
        public string Fecha_inicio { get; set; }
        public bool? Tiene_fecha_de_finalizacion_definida { get; set; }
        public int? Cantidad_de_dias_a_validar { get; set; }
        public int? Fecha_a_validar { get; set; }
        public string Fecha_a_validarDescripcion { get; set; }
        public string Fecha_fin { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }
        public bool? Notificar_por_correo { get; set; }
        public string Texto_que_llevara_el_correo { get; set; }
        public bool? Notificacion_push { get; set; }
        public string Texto_a_mostrar_en_la_notificacion_Push { get; set; }
        
    }
}

