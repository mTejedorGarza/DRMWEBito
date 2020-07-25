using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Tipos_de_Vendedor
{
    /// <summary>
    /// Tipos_de_Vendedor table
    /// </summary>
    public class Tipos_de_Vendedor: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public int? Clave_Rol { get; set; }


    }
	
	public class Tipos_de_Vendedor_Datos_Generales
    {
                public int Clave { get; set; }
        public string Descripcion { get; set; }
        public int? Clave_Rol { get; set; }

		
    }


}

