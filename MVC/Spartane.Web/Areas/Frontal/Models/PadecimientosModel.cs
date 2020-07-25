using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class PadecimientosModel
    {
        [Required]
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public int? Categoria_para_Platillos { get; set; }
        public string Categoria_para_PlatillosCategoria { get; set; }
        public bool Visible_para_el_Paciente { get; set; }

    }
	
	public class Padecimientos_Datos_GeneralesModel
    {
        [Required]
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public int? Categoria_para_Platillos { get; set; }
        public string Categoria_para_PlatillosCategoria { get; set; }
        public bool? Visible_para_el_Paciente { get; set; }

    }


}

