using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Funcionalidades_para_NotificacionAdvanceSearchModel
    {
        public Funcionalidades_para_NotificacionAdvanceSearchModel()
        {

        }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromFolio { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromFolio", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToFolio { set; get; }

        public Filters FuncionalidadFilter { set; get; }
        public string Funcionalidad { set; get; }

        public Filters Nombre_de_la_TablaFilter { set; get; }
        public string Nombre_de_la_Tabla { set; get; }

        public Filters Campos_de_EstatusFilter { set; get; }
        public string AdvanceCampos_de_Estatus { set; get; }
        public int[] AdvanceCampos_de_EstatusMultiple { set; get; }

        public Filters Validacion_ObligatoriaFilter { set; get; }
        public string Validacion_Obligatoria { set; get; }


    }
}
