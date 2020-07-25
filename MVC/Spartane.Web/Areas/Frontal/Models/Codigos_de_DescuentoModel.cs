using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Codigos_de_DescuentoModel
    {
        [Required]
        public int Folio { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public int? Tipo_de_Vendedor { get; set; }
        public string Tipo_de_VendedorDescripcion { get; set; }
        public int? Vendedor { get; set; }
        public string VendedorName { get; set; }
        public int? Tipo_de_Descuento { get; set; }
        public string Tipo_de_DescuentoNombre { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Descuento { get; set; }
        public string Texto_promocional { get; set; }
        public string Fecha_inicio_vigencia { get; set; }
        public string Fecha_fin_vigencia { get; set; }
        [Range(0, 9999999999)]
        public int? Cantidad_maxima_de_referenciados { get; set; }
        public string Codigo_de_descuento { get; set; }
        public int? Estatus { get; set; }
        public string EstatusNombre { get; set; }
        public string Fecha_de_autorizacion { get; set; }
        public string Hora_de_autorizacion { get; set; }
        public int? Usuario_que_autoriza { get; set; }
        public string Usuario_que_autorizaName { get; set; }
        public string Observaciones { get; set; }
        public int? Resultado { get; set; }
        public string ResultadoNombre { get; set; }

    }
	
	public class Codigos_de_Descuento_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public int? Tipo_de_Vendedor { get; set; }
        public string Tipo_de_VendedorDescripcion { get; set; }
        public int? Vendedor { get; set; }
        public string VendedorName { get; set; }
        public int? Tipo_de_Descuento { get; set; }
        public string Tipo_de_DescuentoNombre { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Descuento { get; set; }
        public string Texto_promocional { get; set; }
        public string Fecha_inicio_vigencia { get; set; }
        public string Fecha_fin_vigencia { get; set; }
        [Range(0, 9999999999)]
        public int? Cantidad_maxima_de_referenciados { get; set; }
        public string Codigo_de_descuento { get; set; }
        public int? Estatus { get; set; }
        public string EstatusNombre { get; set; }

    }

	public class Codigos_de_Descuento_AutorizacionModel
    {
        [Required]
        public int Folio { get; set; }
        public string Fecha_de_autorizacion { get; set; }
        public string Hora_de_autorizacion { get; set; }
        public int? Usuario_que_autoriza { get; set; }
        public string Usuario_que_autorizaName { get; set; }
        public string Observaciones { get; set; }
        public int? Resultado { get; set; }
        public string ResultadoNombre { get; set; }

    }

	public class Codigos_de_Descuento_ReferenciadosModel
    {
        [Required]
        public int Folio { get; set; }

    }


}

