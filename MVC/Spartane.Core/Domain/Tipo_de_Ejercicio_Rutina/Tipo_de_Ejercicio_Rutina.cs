using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Tipo_de_Ejercicio_Rutina
{
    /// <summary>
    /// Tipo_de_Ejercicio_Rutina table
    /// </summary>
    public class Tipo_de_Ejercicio_Rutina: BaseEntity
    {
        public int Folio { get; set; }
        public string Descripcion { get; set; }
        public string Tipo_de_Rutina { get; set; }
        public string Nombre_para_Secuencia { get; set; }


    }
	
	public class Tipo_de_Ejercicio_Rutina_Datos_Generales
    {
                public int Folio { get; set; }
        public string Descripcion { get; set; }
        public string Tipo_de_Rutina { get; set; }
        public string Nombre_para_Secuencia { get; set; }

		
    }


}

