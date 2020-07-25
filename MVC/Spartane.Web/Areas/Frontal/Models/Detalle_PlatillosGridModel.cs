using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_PlatillosGridModel
    {
        public int Folio { get; set; }
        public string Cantidad { get; set; }
        public int? Unidad { get; set; }
        public int? Ingrediente { get; set; }
        public string IngredienteNombre_Ingrediente { get; set; }
        public int? Unidad_SMAE { get; set; }
        public int? Porciones { get; set; }
        public string Texto_para_mostrar { get; set; }
        
    }
}

