﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllTipo_de_Dieta : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Tipo_de_Dieta_Clave { get; set; }
        public string Tipo_de_Dieta_Descripcion { get; set; }
        public int? Tipo_de_Dieta_Categoria_para_Platillos { get; set; }
        public string Tipo_de_Dieta_Categoria_para_Platillos_Categoria { get; set; }

    }
}
