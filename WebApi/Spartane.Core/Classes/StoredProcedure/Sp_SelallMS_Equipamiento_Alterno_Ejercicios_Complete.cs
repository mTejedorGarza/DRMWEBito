using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallMS_Equipamiento_Alterno_Ejercicios_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Ejercicios { get; set; }
        public int? Equipamiento_Alterno { get; set; }
        public string Equipamiento_Alterno_Descripcion { get; set; }

    }
}
