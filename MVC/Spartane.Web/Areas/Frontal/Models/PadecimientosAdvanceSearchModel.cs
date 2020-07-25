using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class PadecimientosAdvanceSearchModel
    {
        public PadecimientosAdvanceSearchModel()
        {
            Visible_para_el_Paciente = RadioOptions.NoApply;

        }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromClave { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromClave", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToClave { set; get; }

        public Filters DescripcionFilter { set; get; }
        public string Descripcion { set; get; }

        public Filters Categoria_para_PlatillosFilter { set; get; }
        public string AdvanceCategoria_para_Platillos { set; get; }
        public int[] AdvanceCategoria_para_PlatillosMultiple { set; get; }

        public RadioOptions Visible_para_el_Paciente { set; get; }


    }
}
