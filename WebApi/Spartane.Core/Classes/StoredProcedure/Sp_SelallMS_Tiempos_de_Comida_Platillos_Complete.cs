using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallMS_Tiempos_de_Comida_Platillos_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Platillos { get; set; }
        public int? Tiempo_de_Comida { get; set; }
        public string Tiempo_de_Comida_Comida { get; set; }

    }
}
