using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Estatus_Ingredientes
{
    public class Estatus_IngredientesPagingModel
    {
        public List<Spartane.Core.Domain.Estatus_Ingredientes.Estatus_Ingredientes> Estatus_Ingredientess { set; get; }
        public int RowCount { set; get; }
    }
}
