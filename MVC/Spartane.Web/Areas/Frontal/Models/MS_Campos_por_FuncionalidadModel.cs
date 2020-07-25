using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class MS_Campos_por_FuncionalidadModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Campo { get; set; }
        public string CampoDescripcion { get; set; }

    }
	
	public class MS_Campos_por_Funcionalidad_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Campo { get; set; }
        public string CampoDescripcion { get; set; }

    }


}

