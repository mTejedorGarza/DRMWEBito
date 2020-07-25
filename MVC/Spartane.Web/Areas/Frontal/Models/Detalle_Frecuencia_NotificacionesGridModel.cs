using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Frecuencia_NotificacionesGridModel
    {
        public int Folio { get; set; }
        public int? Frecuencia { get; set; }
        public string FrecuenciaDescripcion { get; set; }
        public int? Dia { get; set; }
        public string DiaDescripcion { get; set; }
        public string Hora { get; set; }
        
    }
}

