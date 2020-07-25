using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Secuencia_de_Ejercicios_en_Rutinas
{
    /// <summary>
    /// Secuencia_de_Ejercicios_en_Rutinas table
    /// </summary>
    public class Secuencia_de_Ejercicios_en_Rutinas: BaseEntity
    {
        public int Folio { get; set; }
        public string Descripcion { get; set; }


    }
	
	public class Secuencia_de_Ejercicios_en_Rutinas_Datos_Generales
    {
                public int Folio { get; set; }
        public string Descripcion { get; set; }

		
    }


}

