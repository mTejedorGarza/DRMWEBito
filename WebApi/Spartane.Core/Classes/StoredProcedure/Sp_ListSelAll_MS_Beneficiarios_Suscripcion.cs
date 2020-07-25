using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllMS_Beneficiarios_Suscripcion : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int MS_Beneficiarios_Suscripcion_Folio { get; set; }
        public int MS_Beneficiarios_Suscripcion_Folio_Planes_de_Suscripcion { get; set; }
        public int? MS_Beneficiarios_Suscripcion_Beneficiario { get; set; }
        public string MS_Beneficiarios_Suscripcion_Beneficiario_Descripcion { get; set; }

    }
}
