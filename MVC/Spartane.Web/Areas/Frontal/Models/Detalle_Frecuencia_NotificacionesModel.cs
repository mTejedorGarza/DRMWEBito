using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Frecuencia_NotificacionesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Frecuencia { get; set; }
        public string FrecuenciaDescripcion { get; set; }
        public int? Dia { get; set; }
        public string DiaDescripcion { get; set; }
        public string Hora { get; set; }

    }
	
	public class Detalle_Frecuencia_Notificaciones_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Frecuencia { get; set; }
        public string FrecuenciaDescripcion { get; set; }
        public int? Dia { get; set; }
        public string DiaDescripcion { get; set; }
        public string Hora { get; set; }

    }


}

