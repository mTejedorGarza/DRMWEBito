﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Clasificacion_Ingredientes
{
    public class Clasificacion_IngredientesPagingModel
    {
        public List<Spartane.Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes> Clasificacion_Ingredientess { set; get; }
        public int RowCount { set; get; }
    }
}
