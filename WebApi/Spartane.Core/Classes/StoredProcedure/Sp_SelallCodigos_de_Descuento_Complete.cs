using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallCodigos_de_Descuento_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_Registra_Name { get; set; }
        public int? Tipo_de_Vendedor { get; set; }
        public string Tipo_de_Vendedor_Descripcion { get; set; }
        public int? Vendedor { get; set; }
        public string Vendedor_Name { get; set; }
        public int? Tipo_de_Descuento { get; set; }
        public string Tipo_de_Descuento_Nombre { get; set; }
        public decimal? Descuento { get; set; }
        public string Texto_promocional { get; set; }
        public DateTime? Fecha_inicio_vigencia { get; set; }
        public DateTime? Fecha_fin_vigencia { get; set; }
        public int? Cantidad_maxima_de_referenciados { get; set; }
        public string Codigo_de_descuento { get; set; }
        public int? Estatus { get; set; }
        public string Estatus_Nombre { get; set; }
        public DateTime? Fecha_de_autorizacion { get; set; }
        public string Hora_de_autorizacion { get; set; }
        public int? Usuario_que_autoriza { get; set; }
        public string Usuario_que_autoriza_Name { get; set; }
        public string Observaciones { get; set; }
        public int? Resultado { get; set; }
        public string Resultado_Nombre { get; set; }

    }
}
