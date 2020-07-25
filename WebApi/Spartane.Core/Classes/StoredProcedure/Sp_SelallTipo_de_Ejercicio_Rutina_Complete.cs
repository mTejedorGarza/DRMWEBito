using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallTipo_de_Ejercicio_Rutina_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public string Descripcion { get; set; }
        public string Tipo_de_Rutina { get; set; }
        public string Nombre_para_Secuencia { get; set; }

    }
}
