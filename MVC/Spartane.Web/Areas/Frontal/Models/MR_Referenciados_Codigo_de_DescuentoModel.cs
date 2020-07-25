using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class MR_Referenciados_Codigo_de_DescuentoModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Tipo_de_usuario { get; set; }
        public string Tipo_de_usuarioDescripcion { get; set; }
        public int? Usuario { get; set; }
        public string UsuarioName { get; set; }
        public string Fecha_de_aplicacion { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Descuento_Total { get; set; }

    }
	
	public class MR_Referenciados_Codigo_de_Descuento_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Tipo_de_usuario { get; set; }
        public string Tipo_de_usuarioDescripcion { get; set; }
        public int? Usuario { get; set; }
        public string UsuarioName { get; set; }
        public string Fecha_de_aplicacion { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Descuento_Total { get; set; }

    }


}

