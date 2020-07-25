using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Tipo_de_Tarjeta
{
    public class Tipo_de_TarjetaPagingModel
    {
        public List<Spartane.Core.Classes.Tipo_de_Tarjeta.Tipo_de_Tarjeta> Tipo_de_Tarjetas { set; get; }
        public int RowCount { set; get; }
    }
}
