﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllIngredientes : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Ingredientes_Clave { get; set; }
        public bool? Ingredientes_Es_un_ingrediente_de_SMAE { get; set; }
        public int? Ingredientes_Clasificacion { get; set; }
        public string Ingredientes_Clasificacion_Descripcion { get; set; }
        public int? Ingredientes_Subgrupo { get; set; }
        public string Ingredientes_Subgrupo_Nombre { get; set; }
        public string Ingredientes_Nombre_Ingrediente { get; set; }
        public string Ingredientes_Ingrediente { get; set; }
        public int? Ingredientes_Imagen { get; set; }
        public string Ingredientes_Imagen_Nombre { get; set; }
        public string Ingredientes_Cantidad_sugerida { get; set; }
        public decimal? Ingredientes_Cantidad_Sugerida_Decimal { get; set; }
        public int? Ingredientes_Unidad { get; set; }
        public string Ingredientes_Unidad_Unidad { get; set; }
        public decimal? Ingredientes_Peso_bruto_redondeado_g { get; set; }
        public decimal? Ingredientes_Peso_neto_g { get; set; }
        public int? Ingredientes_Estatus { get; set; }
        public string Ingredientes_Estatus_Descripcion { get; set; }

    }
}
