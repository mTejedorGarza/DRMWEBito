using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Telefonos_de_Asistencia
{
    /// <summary>
    /// Telefonos_de_Asistencia table
    /// </summary>
    public class Telefonos_de_Asistencia: BaseEntity
    {
        public int Folio { get; set; }
        public string Telefono { get; set; }
        public string Departamento { get; set; }


    }
}

