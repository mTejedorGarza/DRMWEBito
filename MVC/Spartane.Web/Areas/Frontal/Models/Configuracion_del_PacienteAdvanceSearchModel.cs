using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Configuracion_del_PacienteAdvanceSearchModel
    {
        public Configuracion_del_PacienteAdvanceSearchModel()
        {
            Android = RadioOptions.NoApply;
            iOS = RadioOptions.NoApply;
            Permite_notificaciones_por_email = RadioOptions.NoApply;
            Permite_notificaciones_push = RadioOptions.NoApply;

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

        public Filters Usuario_RegistradoFilter { set; get; }
        public string AdvanceUsuario_Registrado { set; get; }
        public int[] AdvanceUsuario_RegistradoMultiple { set; get; }

        public Filters RolFilter { set; get; }
        public string Rol { set; get; }

        public Filters TokenFilter { set; get; }
        public string Token { set; get; }

        public RadioOptions Android { set; get; }

        public RadioOptions iOS { set; get; }

        public RadioOptions Permite_notificaciones_por_email { set; get; }

        public RadioOptions Permite_notificaciones_push { set; get; }


    }
}
