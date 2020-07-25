using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Meses
{
    /// <summary>
    /// Meses table
    /// </summary>
    public class Meses: BaseEntity
    {
        public int Clave { get; set; }
        public string Nombre { get; set; }
        public short? Cantidad_de_dias { get; set; }


    }
}

