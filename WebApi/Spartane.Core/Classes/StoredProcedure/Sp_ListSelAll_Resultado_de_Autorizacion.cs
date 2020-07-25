using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllResultado_de_Autorizacion : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Resultado_de_Autorizacion_Folio { get; set; }
        public string Resultado_de_Autorizacion_Nombre { get; set; }

    }
}
