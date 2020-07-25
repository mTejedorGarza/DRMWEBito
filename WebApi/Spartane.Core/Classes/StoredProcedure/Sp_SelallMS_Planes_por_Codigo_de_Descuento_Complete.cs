using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallMS_Planes_por_Codigo_de_Descuento_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Codigos_de_Descuento { get; set; }
        public int? Planes_de_Suscripcion { get; set; }
        public string Planes_de_Suscripcion_Nombre_del_Plan { get; set; }

    }
}
