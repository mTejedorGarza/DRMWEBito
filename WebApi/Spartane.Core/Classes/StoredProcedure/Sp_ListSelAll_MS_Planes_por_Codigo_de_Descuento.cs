using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllMS_Planes_por_Codigo_de_Descuento : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int MS_Planes_por_Codigo_de_Descuento_Folio { get; set; }
        public int MS_Planes_por_Codigo_de_Descuento_Folio_Codigos_de_Descuento { get; set; }
        public int? MS_Planes_por_Codigo_de_Descuento_Planes_de_Suscripcion { get; set; }
        public string MS_Planes_por_Codigo_de_Descuento_Planes_de_Suscripcion_Nombre_del_Plan { get; set; }

    }
}
