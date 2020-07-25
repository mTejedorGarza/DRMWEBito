using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Telefonos_de_AsistenciaModel
    {
        [Required]
        public int Folio { get; set; }
        public string Telefono { get; set; }
        public string Departamento { get; set; }

    }
	
	public class Telefonos_de_Asistencia_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Telefono { get; set; }
        public string Departamento { get; set; }

    }


}

