using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Tipo_de_Enfoque_del_Ejercicio
{
    /// <summary>
    /// Tipo_de_Enfoque_del_Ejercicio table
    /// </summary>
    public class Tipo_de_Enfoque_del_Ejercicio: BaseEntity
    {
        public int Folio { get; set; }
        public string Descripcion { get; set; }


    }
	
	public class Tipo_de_Enfoque_del_Ejercicio_Datos_Generales
    {
                public int Folio { get; set; }
        public string Descripcion { get; set; }

		
    }


}

