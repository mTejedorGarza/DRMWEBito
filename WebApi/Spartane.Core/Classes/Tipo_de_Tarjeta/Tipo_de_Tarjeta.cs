using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Tipo_de_Tarjeta
{
    /// <summary>
    /// Tipo_de_Tarjeta table
    /// </summary>
    public class Tipo_de_Tarjeta: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }


    }
}

