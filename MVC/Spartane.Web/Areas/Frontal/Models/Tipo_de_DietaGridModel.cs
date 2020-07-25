using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Tipo_de_DietaGridModel
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public int? Categoria_para_Platillos { get; set; }
        public string Categoria_para_PlatillosCategoria { get; set; }
        
    }
}

