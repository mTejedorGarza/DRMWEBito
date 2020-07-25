using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Codigos_de_Descuento
{
    public class Codigos_de_DescuentoPagingModel
    {
        public List<Spartane.Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento> Codigos_de_Descuentos { set; get; }
        public int RowCount { set; get; }
    }
}
