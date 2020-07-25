using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Tipos_de_Vendedor
{
    public class Tipos_de_VendedorPagingModel
    {
        public List<Spartane.Core.Classes.Tipos_de_Vendedor.Tipos_de_Vendedor> Tipos_de_Vendedors { set; get; }
        public int RowCount { set; get; }
    }
}
