using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Configuracion_de_NotificacionesAdvanceSearchModel
    {
        public Configuracion_de_NotificacionesAdvanceSearchModel()
        {
            Es_permanente = RadioOptions.NoApply;
            Tiene_fecha_de_finalizacion_definida = RadioOptions.NoApply;
            Notificar_por_correo = RadioOptions.NoApply;
            Notificacion_push = RadioOptions.NoApply;

        }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromFolio { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromFolio", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToFolio { set; get; }

        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        public string FromFecha_de_Registro { set; get; }
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        [IsDateAfter("FromFecha_de_Registro", true, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToFecha_de_Registro { set; get; }

        public string ToHora_de_Registro { set; get; }
        public string FromHora_de_Registro { set; get; }

        public Filters Usuario_que_RegistraFilter { set; get; }
        public string AdvanceUsuario_que_Registra { set; get; }
        public int[] AdvanceUsuario_que_RegistraMultiple { set; get; }

        public Filters Nombre_de_la_NotificacionFilter { set; get; }
        public string Nombre_de_la_Notificacion { set; get; }

        public RadioOptions Es_permanente { set; get; }

        public Filters FuncionalidadFilter { set; get; }
        public string AdvanceFuncionalidad { set; get; }
        public int[] AdvanceFuncionalidadMultiple { set; get; }

        public Filters Tipo_de_NotificacionFilter { set; get; }
        public string AdvanceTipo_de_Notificacion { set; get; }
        public int[] AdvanceTipo_de_NotificacionMultiple { set; get; }

        public Filters Tipo_de_AccionFilter { set; get; }
        public string AdvanceTipo_de_Accion { set; get; }
        public int[] AdvanceTipo_de_AccionMultiple { set; get; }

        public Filters Tipo_de_RecordatorioFilter { set; get; }
        public string AdvanceTipo_de_Recordatorio { set; get; }
        public int[] AdvanceTipo_de_RecordatorioMultiple { set; get; }

        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        public string FromFecha_inicio { set; get; }
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        [IsDateAfter("FromFecha_inicio", true, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToFecha_inicio { set; get; }

        public RadioOptions Tiene_fecha_de_finalizacion_definida { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromCantidad_de_dias_a_validar { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromCantidad_de_dias_a_validar", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToCantidad_de_dias_a_validar { set; get; }

        public Filters Fecha_a_validarFilter { set; get; }
        public string AdvanceFecha_a_validar { set; get; }
        public int[] AdvanceFecha_a_validarMultiple { set; get; }

        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        public string FromFecha_fin { set; get; }
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        [IsDateAfter("FromFecha_fin", true, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToFecha_fin { set; get; }

        public Filters EstatusFilter { set; get; }
        public string AdvanceEstatus { set; get; }
        public int[] AdvanceEstatusMultiple { set; get; }

        public RadioOptions Notificar_por_correo { set; get; }

        public Filters Texto_que_llevara_el_correoFilter { set; get; }
        public string Texto_que_llevara_el_correo { set; get; }

        public RadioOptions Notificacion_push { set; get; }

        public Filters Texto_a_mostrar_en_la_notificacion_PushFilter { set; get; }
        public string Texto_a_mostrar_en_la_notificacion_Push { set; get; }


    }
}
