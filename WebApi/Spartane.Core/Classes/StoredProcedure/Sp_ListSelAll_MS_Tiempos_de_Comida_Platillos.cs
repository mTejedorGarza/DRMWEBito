using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllMS_Tiempos_de_Comida_Platillos : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int MS_Tiempos_de_Comida_Platillos_Folio { get; set; }
        public int MS_Tiempos_de_Comida_Platillos_Folio_Platillos { get; set; }
        public int? MS_Tiempos_de_Comida_Platillos_Tiempo_de_Comida { get; set; }
        public string MS_Tiempos_de_Comida_Platillos_Tiempo_de_Comida_Comida { get; set; }

    }
}
