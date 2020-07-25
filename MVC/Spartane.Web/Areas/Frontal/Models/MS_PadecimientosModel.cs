using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class MS_PadecimientosModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Categoria { get; set; }
        public string CategoriaCategoria { get; set; }

    }
	
	public class MS_Padecimientos_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Categoria { get; set; }
        public string CategoriaCategoria { get; set; }

    }


}

