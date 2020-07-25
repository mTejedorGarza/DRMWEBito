using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Subgrupos_IngredientesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Nombre { get; set; }
        public int? Clasificacion { get; set; }
        public string ClasificacionDescripcion { get; set; }

    }
	
	public class Subgrupos_Ingredientes_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Nombre { get; set; }
        public int? Clasificacion { get; set; }
        public string ClasificacionDescripcion { get; set; }

    }


}

