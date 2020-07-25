using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallMS_Uso_del_Ejercicio_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Ejercicios { get; set; }
        public int? Uso_del_Ejercicio { get; set; }
        public string Uso_del_Ejercicio_Descripcion { get; set; }

    }
}
