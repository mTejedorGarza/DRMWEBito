using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Telefonos_de_Asistencia
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
	
	public class Telefonos_de_Asistencia_Datos_Generales
    {
                public int Folio { get; set; }
        public string Telefono { get; set; }
        public string Departamento { get; set; }

		
    }


}

