using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Subgrupos_Ingredientes
{
    public class Subgrupos_IngredientesPagingModel
    {
        public List<Spartane.Core.Domain.Subgrupos_Ingredientes.Subgrupos_Ingredientes> Subgrupos_Ingredientess { set; get; }
        public int RowCount { set; get; }
    }
}
