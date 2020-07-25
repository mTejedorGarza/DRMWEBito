using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Planes_de_Rutinas_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Planes_de_Rutinas { get; set; }
        public int? Numero_de_Dia { get; set; }
        public string Numero_de_Dia_Dia { get; set; }
        public DateTime? Fecha { get; set; }
        public int? Orden_de_Realizacion { get; set; }
        public string Secuencia_del_Ejercicio { get; set; }
        public int? Enfoque_del_Ejercicio { get; set; }
        public string Enfoque_del_Ejercicio_Descripcion { get; set; }
        public int? Ejercicio { get; set; }
        public string Ejercicio_Nombre_del_Ejercicio { get; set; }
        public bool? Realizado { get; set; }

    }
}
