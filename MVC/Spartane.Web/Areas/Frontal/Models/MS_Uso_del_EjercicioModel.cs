using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class MS_Uso_del_EjercicioModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Uso_del_Ejercicio { get; set; }
        public string Uso_del_EjercicioDescripcion { get; set; }

    }
	
	public class MS_Uso_del_Ejercicio_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Uso_del_Ejercicio { get; set; }
        public string Uso_del_EjercicioDescripcion { get; set; }

    }


}

