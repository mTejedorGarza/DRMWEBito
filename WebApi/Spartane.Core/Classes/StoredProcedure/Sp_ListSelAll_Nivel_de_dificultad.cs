﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllNivel_de_dificultad : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Nivel_de_dificultad_Folio { get; set; }
        public string Nivel_de_dificultad_Dificultad { get; set; }
        public int? Nivel_de_dificultad_Imagen { get; set; }
        public string Nivel_de_dificultad_Imagen_Nombre { get; set; }

    }
}
