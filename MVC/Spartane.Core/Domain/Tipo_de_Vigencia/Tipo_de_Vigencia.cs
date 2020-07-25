using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Tipo_de_Vigencia
{
    /// <summary>
    /// Tipo_de_Vigencia table
    /// </summary>
    public class Tipo_de_Vigencia: BaseEntity
    {
        public int Clave { get; set; }
        public string Vigencia { get; set; }


    }
	
	public class Tipo_de_Vigencia_Datos_Generales
    {
                public int Clave { get; set; }
        public string Vigencia { get; set; }

		
    }


}

