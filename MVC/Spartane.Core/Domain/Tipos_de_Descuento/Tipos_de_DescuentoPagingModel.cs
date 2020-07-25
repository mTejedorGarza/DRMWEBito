using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Tipos_de_Descuento
{
    public class Tipos_de_DescuentoPagingModel
    {
        public List<Spartane.Core.Domain.Tipos_de_Descuento.Tipos_de_Descuento> Tipos_de_Descuentos { set; get; }
        public int RowCount { set; get; }
    }
}
