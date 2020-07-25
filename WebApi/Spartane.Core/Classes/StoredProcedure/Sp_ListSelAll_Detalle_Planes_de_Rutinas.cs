﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Planes_de_Rutinas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Planes_de_Rutinas_Folio { get; set; }
        public int Detalle_Planes_de_Rutinas_Folio_Planes_de_Rutinas { get; set; }
        public int? Detalle_Planes_de_Rutinas_Numero_de_Dia { get; set; }
        public string Detalle_Planes_de_Rutinas_Numero_de_Dia_Dia { get; set; }
        public DateTime? Detalle_Planes_de_Rutinas_Fecha { get; set; }
        public int? Detalle_Planes_de_Rutinas_Orden_de_Realizacion { get; set; }
        public string Detalle_Planes_de_Rutinas_Secuencia_del_Ejercicio { get; set; }
        public int? Detalle_Planes_de_Rutinas_Enfoque_del_Ejercicio { get; set; }
        public string Detalle_Planes_de_Rutinas_Enfoque_del_Ejercicio_Descripcion { get; set; }
        public int? Detalle_Planes_de_Rutinas_Ejercicio { get; set; }
        public string Detalle_Planes_de_Rutinas_Ejercicio_Nombre_del_Ejercicio { get; set; }
        public bool? Detalle_Planes_de_Rutinas_Realizado { get; set; }

    }
}
