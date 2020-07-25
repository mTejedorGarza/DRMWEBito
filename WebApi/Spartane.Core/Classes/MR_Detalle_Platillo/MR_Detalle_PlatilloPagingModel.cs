using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.MR_Detalle_Platillo
{
    public class MR_Detalle_PlatilloPagingModel
    {
        public List<Spartane.Core.Classes.MR_Detalle_Platillo.MR_Detalle_Platillo> MR_Detalle_Platillos { set; get; }
        public int RowCount { set; get; }
    }
}
