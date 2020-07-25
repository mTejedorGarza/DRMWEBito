using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllCodigos_de_Descuento : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Codigos_de_Descuento_Folio { get; set; }
        public DateTime? Codigos_de_Descuento_Fecha_de_Registro { get; set; }
        public string Codigos_de_Descuento_Hora_de_Registro { get; set; }
        public int? Codigos_de_Descuento_Usuario_que_Registra { get; set; }
        public string Codigos_de_Descuento_Usuario_que_Registra_Name { get; set; }
        public int? Codigos_de_Descuento_Tipo_de_Vendedor { get; set; }
        public string Codigos_de_Descuento_Tipo_de_Vendedor_Descripcion { get; set; }
        public int? Codigos_de_Descuento_Vendedor { get; set; }
        public string Codigos_de_Descuento_Vendedor_Name { get; set; }
        public int? Codigos_de_Descuento_Tipo_de_Descuento { get; set; }
        public string Codigos_de_Descuento_Tipo_de_Descuento_Nombre { get; set; }
        public decimal? Codigos_de_Descuento_Descuento { get; set; }
        public string Codigos_de_Descuento_Texto_promocional { get; set; }
        public DateTime? Codigos_de_Descuento_Fecha_inicio_vigencia { get; set; }
        public DateTime? Codigos_de_Descuento_Fecha_fin_vigencia { get; set; }
        public int? Codigos_de_Descuento_Cantidad_maxima_de_referenciados { get; set; }
        public string Codigos_de_Descuento_Codigo_de_descuento { get; set; }
        public int? Codigos_de_Descuento_Estatus { get; set; }
        public string Codigos_de_Descuento_Estatus_Nombre { get; set; }
        public DateTime? Codigos_de_Descuento_Fecha_de_autorizacion { get; set; }
        public string Codigos_de_Descuento_Hora_de_autorizacion { get; set; }
        public int? Codigos_de_Descuento_Usuario_que_autoriza { get; set; }
        public string Codigos_de_Descuento_Usuario_que_autoriza_Name { get; set; }
        public string Codigos_de_Descuento_Observaciones { get; set; }
        public int? Codigos_de_Descuento_Resultado { get; set; }
        public string Codigos_de_Descuento_Resultado_Nombre { get; set; }

    }
}
