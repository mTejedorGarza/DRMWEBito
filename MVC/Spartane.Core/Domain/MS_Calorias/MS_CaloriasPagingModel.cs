using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.MS_Calorias
{
    public class MS_CaloriasPagingModel
    {
        public List<Spartane.Core.Domain.MS_Calorias.MS_Calorias> MS_Caloriass { set; get; }
        public int RowCount { set; get; }
    }
}
