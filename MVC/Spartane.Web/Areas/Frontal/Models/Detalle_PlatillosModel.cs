using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_PlatillosModel
    {
        [Required]
        public int Folio { get; set; }
        public string Cantidad { get; set; }
        [Range(0, 9999999999)]
        public int? Unidad { get; set; }
        public int? Ingrediente { get; set; }
        public string IngredienteNombre_Ingrediente { get; set; }
        [Range(0, 9999999999)]
        public int? Unidad_SMAE { get; set; }
        [Range(0, 9999999999)]
        public int? Porciones { get; set; }
        public string Texto_para_mostrar { get; set; }

    }
	
	public class Detalle_Platillos_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Cantidad { get; set; }
        [Range(0, 9999999999)]
        public int? Unidad { get; set; }
        public int? Ingrediente { get; set; }
        public string IngredienteNombre_Ingrediente { get; set; }
        [Range(0, 9999999999)]
        public int? Unidad_SMAE { get; set; }
        [Range(0, 9999999999)]
        public int? Porciones { get; set; }
        public string Texto_para_mostrar { get; set; }

    }


}

