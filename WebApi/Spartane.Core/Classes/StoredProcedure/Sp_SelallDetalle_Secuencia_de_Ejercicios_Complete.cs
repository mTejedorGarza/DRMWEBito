using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Secuencia_de_Ejercicios_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Configuracion_Rutinas { get; set; }
        public int? Orden_del_Ejercicio { get; set; }
        public string Orden_del_Ejercicio_Descripcion { get; set; }
        public int? Tipo_de_Ejercicio { get; set; }
        public string Tipo_de_Ejercicio_Nombre_para_Secuencia { get; set; }
        public int? Enfoque { get; set; }
        public string Enfoque_Descripcion { get; set; }
        public string Secuencia_del_Ejercicio { get; set; }

    }
}
