using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Tipo_de_Ejercicio_Rutina
{
    /// <summary>
    /// Tipo_de_Ejercicio_Rutina table
    /// </summary>
    public class Tipo_de_Ejercicio_Rutina: BaseEntity
    {
        public int Folio { get; set; }
        public string Descripcion { get; set; }
        public string Tipo_de_Rutina { get; set; }
        public string Nombre_para_Secuencia { get; set; }


    }
}

