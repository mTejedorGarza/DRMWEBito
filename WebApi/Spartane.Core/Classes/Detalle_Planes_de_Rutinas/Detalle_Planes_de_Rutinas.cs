using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Planes_de_Rutinas;
using Spartane.Core.Classes.Dias_de_la_semana;
using Spartane.Core.Classes.Tipo_de_Enfoque_del_Ejercicio;
using Spartane.Core.Classes.Ejercicios;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Detalle_Planes_de_Rutinas
{
    /// <summary>
    /// Detalle_Planes_de_Rutinas table
    /// </summary>
    public class Detalle_Planes_de_Rutinas: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Planes_de_Rutinas { get; set; }
        public int? Numero_de_Dia { get; set; }
        public DateTime? Fecha { get; set; }
        public int? Orden_de_Realizacion { get; set; }
        public string Secuencia_del_Ejercicio { get; set; }
        public int? Enfoque_del_Ejercicio { get; set; }
        public int? Ejercicio { get; set; }
        public bool? Realizado { get; set; }

        [ForeignKey("Folio_Planes_de_Rutinas")]
        public virtual Spartane.Core.Classes.Planes_de_Rutinas.Planes_de_Rutinas Folio_Planes_de_Rutinas_Planes_de_Rutinas { get; set; }
        [ForeignKey("Numero_de_Dia")]
        public virtual Spartane.Core.Classes.Dias_de_la_semana.Dias_de_la_semana Numero_de_Dia_Dias_de_la_semana { get; set; }
        [ForeignKey("Enfoque_del_Ejercicio")]
        public virtual Spartane.Core.Classes.Tipo_de_Enfoque_del_Ejercicio.Tipo_de_Enfoque_del_Ejercicio Enfoque_del_Ejercicio_Tipo_de_Enfoque_del_Ejercicio { get; set; }
        [ForeignKey("Ejercicio")]
        public virtual Spartane.Core.Classes.Ejercicios.Ejercicios Ejercicio_Ejercicios { get; set; }

    }
}

