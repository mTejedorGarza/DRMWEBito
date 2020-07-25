using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallMS_Semanas_Planes_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Planes_de_Suscripcion { get; set; }
        public int? Semanas { get; set; }
        public string Semanas_Semana { get; set; }

    }
}
