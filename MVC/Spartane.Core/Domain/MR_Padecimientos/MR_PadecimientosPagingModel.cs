using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.MR_Padecimientos
{
    public class MR_PadecimientosPagingModel
    {
        public List<Spartane.Core.Domain.MR_Padecimientos.MR_Padecimientos> MR_Padecimientoss { set; get; }
        public int RowCount { set; get; }
    }
}
