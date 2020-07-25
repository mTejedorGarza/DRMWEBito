using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.MS_Padecimientos
{
    public class MS_PadecimientosPagingModel
    {
        public List<Spartane.Core.Domain.MS_Padecimientos.MS_Padecimientos> MS_Padecimientoss { set; get; }
        public int RowCount { set; get; }
    }
}
