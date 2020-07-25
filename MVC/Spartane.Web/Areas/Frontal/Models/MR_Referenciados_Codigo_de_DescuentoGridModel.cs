using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class MR_Referenciados_Codigo_de_DescuentoGridModel
    {
        public int Folio { get; set; }
        public int? Tipo_de_usuario { get; set; }
        public string Tipo_de_usuarioDescripcion { get; set; }
        public int? Usuario { get; set; }
        public string UsuarioName { get; set; }
        public string Fecha_de_aplicacion { get; set; }
        public decimal? Descuento_Total { get; set; }
        
    }
}

