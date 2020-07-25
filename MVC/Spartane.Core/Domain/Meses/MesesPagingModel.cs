using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Meses
{
    public class MesesPagingModel
    {
        public List<Spartane.Core.Domain.Meses.Meses> Mesess { set; get; }
        public int RowCount { set; get; }
    }
}
