using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Tipo_de_Ejercicio_RutinaModel
    {
        [Required]
        public int Folio { get; set; }
        public string Descripcion { get; set; }
        public string Tipo_de_Rutina { get; set; }
        public string Nombre_para_Secuencia { get; set; }

    }
	
	public class Tipo_de_Ejercicio_Rutina_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Descripcion { get; set; }
        public string Tipo_de_Rutina { get; set; }
        public string Nombre_para_Secuencia { get; set; }

    }


}

