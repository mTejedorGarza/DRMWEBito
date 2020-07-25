using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallMR_Referenciados_Codigo_de_Descuento_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Codigos_de_Descuento { get; set; }
        public int? Tipo_de_usuario { get; set; }
        public string Tipo_de_usuario_Descripcion { get; set; }
        public int? Usuario { get; set; }
        public string Usuario_Name { get; set; }
        public DateTime? Fecha_de_aplicacion { get; set; }
        public decimal? Descuento_Total { get; set; }

    }
}
