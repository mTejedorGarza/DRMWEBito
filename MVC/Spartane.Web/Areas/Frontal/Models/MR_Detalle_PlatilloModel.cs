using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class MR_Detalle_PlatilloModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Ingrediente { get; set; }
        public string IngredienteNombre_Ingrediente { get; set; }
        public string Cantidad { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Cantidad_en_Fraccion { get; set; }
        public int? Unidad { get; set; }
        public string UnidadUnidad { get; set; }
        public string Cantidad_a_mostrar { get; set; }
        public string Ingrediente_a_mostrar { get; set; }

    }
	
	public class MR_Detalle_Platillo_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Ingrediente { get; set; }
        public string IngredienteNombre_Ingrediente { get; set; }
        public string Cantidad { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Cantidad_en_Fraccion { get; set; }
        public int? Unidad { get; set; }
        public string UnidadUnidad { get; set; }
        public string Cantidad_a_mostrar { get; set; }
        public string Ingrediente_a_mostrar { get; set; }

    }


}

