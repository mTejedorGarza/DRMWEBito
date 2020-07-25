using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.MS_Caracteristicas_Platillo
{
    public class MS_Caracteristicas_PlatilloPagingModel
    {
        public List<Spartane.Core.Domain.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo> MS_Caracteristicas_Platillos { set; get; }
        public int RowCount { set; get; }
    }
}
