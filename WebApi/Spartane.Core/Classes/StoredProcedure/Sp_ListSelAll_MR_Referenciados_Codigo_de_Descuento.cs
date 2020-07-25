using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllMR_Referenciados_Codigo_de_Descuento : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int MR_Referenciados_Codigo_de_Descuento_Folio { get; set; }
        public int MR_Referenciados_Codigo_de_Descuento_Folio_Codigos_de_Descuento { get; set; }
        public int? MR_Referenciados_Codigo_de_Descuento_Tipo_de_usuario { get; set; }
        public string MR_Referenciados_Codigo_de_Descuento_Tipo_de_usuario_Descripcion { get; set; }
        public int? MR_Referenciados_Codigo_de_Descuento_Usuario { get; set; }
        public string MR_Referenciados_Codigo_de_Descuento_Usuario_Name { get; set; }
        public DateTime? MR_Referenciados_Codigo_de_Descuento_Fecha_de_aplicacion { get; set; }
        public decimal? MR_Referenciados_Codigo_de_Descuento_Descuento_Total { get; set; }

    }
}
