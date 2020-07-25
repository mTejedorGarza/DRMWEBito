using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.MR_Tarjetas
{
    public class MR_TarjetasPagingModel
    {
        public List<Spartane.Core.Domain.MR_Tarjetas.MR_Tarjetas> MR_Tarjetass { set; get; }
        public int RowCount { set; get; }
    }
}
