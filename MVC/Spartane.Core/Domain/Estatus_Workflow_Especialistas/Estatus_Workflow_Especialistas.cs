using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Estatus_Workflow_Especialistas
{
    /// <summary>
    /// Estatus_Workflow_Especialistas table
    /// </summary>
    public class Estatus_Workflow_Especialistas: BaseEntity
    {
        public int Clave { get; set; }
        public string Estatus { get; set; }


    }
	
	public class Estatus_Workflow_Especialistas_Datos_Generales
    {
                public int Clave { get; set; }
        public string Estatus { get; set; }

		
    }


}

