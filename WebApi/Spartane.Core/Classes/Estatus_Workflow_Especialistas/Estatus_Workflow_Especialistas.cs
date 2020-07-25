using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Estatus_Workflow_Especialistas
{
    /// <summary>
    /// Estatus_Workflow_Especialistas table
    /// </summary>
    public class Estatus_Workflow_Especialistas: BaseEntity
    {
        public int Clave { get; set; }
        public string Estatus { get; set; }


    }
}

