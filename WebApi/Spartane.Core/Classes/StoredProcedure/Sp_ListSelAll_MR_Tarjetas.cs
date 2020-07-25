using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllMR_Tarjetas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int MR_Tarjetas_Folio { get; set; }
        public int MR_Tarjetas_Folio_Metodos_de_Pago_Paciente { get; set; }
        public int? MR_Tarjetas_Tipo_de_Tarjeta { get; set; }
        public string MR_Tarjetas_Tipo_de_Tarjeta_Descripcion { get; set; }
        public string MR_Tarjetas_Numero_de_Tarjeta { get; set; }
        public string MR_Tarjetas_Nombre_del_Titular { get; set; }
        public int? MR_Tarjetas_Ano_de_vigencia { get; set; }
        public int? MR_Tarjetas_Mes_de_vigencia { get; set; }
        public string MR_Tarjetas_Alias_de_la_Tarjeta { get; set; }
        public int? MR_Tarjetas_Estatus { get; set; }
        public string MR_Tarjetas_Estatus_Descripcion { get; set; }

    }
}
