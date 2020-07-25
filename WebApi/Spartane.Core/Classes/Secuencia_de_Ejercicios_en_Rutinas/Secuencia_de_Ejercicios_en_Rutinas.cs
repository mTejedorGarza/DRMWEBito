using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Secuencia_de_Ejercicios_en_Rutinas
{
    /// <summary>
    /// Secuencia_de_Ejercicios_en_Rutinas table
    /// </summary>
    public class Secuencia_de_Ejercicios_en_Rutinas: BaseEntity
    {
        public int Folio { get; set; }
        public string Descripcion { get; set; }


    }
}

