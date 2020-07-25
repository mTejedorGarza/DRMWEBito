using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class MS_Dificultad_EjerciciosModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Nivel_de_Dificultad { get; set; }
        public string Nivel_de_DificultadDificultad { get; set; }

    }
	
	public class MS_Dificultad_Ejercicios_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Nivel_de_Dificultad { get; set; }
        public string Nivel_de_DificultadDificultad { get; set; }

    }


}

