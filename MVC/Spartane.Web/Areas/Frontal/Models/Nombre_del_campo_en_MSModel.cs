using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Nombre_del_campo_en_MSModel
    {
        [Required]
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public string Nombre_Fisico_del_Campo { get; set; }
        public string Nombre_Fisico_de_la_Tabla { get; set; }

    }
	
	public class Nombre_del_campo_en_MS_Datos_GeneralesModel
    {
        [Required]
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public string Nombre_Fisico_del_Campo { get; set; }
        public string Nombre_Fisico_de_la_Tabla { get; set; }

    }


}

