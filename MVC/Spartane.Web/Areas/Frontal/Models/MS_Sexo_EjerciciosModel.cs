using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class MS_Sexo_EjerciciosModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Sexo { get; set; }
        public string SexoDescripcion { get; set; }

    }
	
	public class MS_Sexo_Ejercicios_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Sexo { get; set; }
        public string SexoDescripcion { get; set; }

    }


}

