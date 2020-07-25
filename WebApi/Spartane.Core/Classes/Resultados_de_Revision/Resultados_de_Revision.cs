using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Resultados_de_Revision
{
    /// <summary>
    /// Resultados_de_Revision table
    /// </summary>
    public class Resultados_de_Revision: BaseEntity
    {
        public int Folio { get; set; }
        public string Nombre { get; set; }


    }
}

