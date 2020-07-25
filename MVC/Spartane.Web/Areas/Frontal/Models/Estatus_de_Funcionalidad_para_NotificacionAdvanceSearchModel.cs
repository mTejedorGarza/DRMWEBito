using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Estatus_de_Funcionalidad_para_NotificacionAdvanceSearchModel
    {
        public Estatus_de_Funcionalidad_para_NotificacionAdvanceSearchModel()
        {

        }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromFolio { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromFolio", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToFolio { set; get; }

        public Filters Campo_para_EstatusFilter { set; get; }
        public string Campo_para_Estatus { set; get; }

        public Filters Nombre_Fisico_del_CampoFilter { set; get; }
        public string Nombre_Fisico_del_Campo { set; get; }

        public Filters Nombre_Fisico_de_la_TablaFilter { set; get; }
        public string Nombre_Fisico_de_la_Tabla { set; get; }


    }
}
