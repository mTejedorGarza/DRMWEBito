using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Tipo_Workflow_Especialistas
{
    /// <summary>
    /// Tipo_Workflow_Especialistas table
    /// </summary>
    public class Tipo_Workflow_Especialistas: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }


    }
}

