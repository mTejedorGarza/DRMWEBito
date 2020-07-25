using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallMS_Sexo_Ejercicios_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Ejercicios { get; set; }
        public int? Sexo { get; set; }
        public string Sexo_Descripcion { get; set; }

    }
}
