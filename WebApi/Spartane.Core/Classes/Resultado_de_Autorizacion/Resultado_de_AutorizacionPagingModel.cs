using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Resultado_de_Autorizacion
{
    public class Resultado_de_AutorizacionPagingModel
    {
        public List<Spartane.Core.Classes.Resultado_de_Autorizacion.Resultado_de_Autorizacion> Resultado_de_Autorizacions { set; get; }
        public int RowCount { set; get; }
    }
}
