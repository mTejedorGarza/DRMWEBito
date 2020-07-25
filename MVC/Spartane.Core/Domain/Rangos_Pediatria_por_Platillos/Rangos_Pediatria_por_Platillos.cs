using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Rangos_Pediatria_por_Platillos
{
    /// <summary>
    /// Rangos_Pediatria_por_Platillos table
    /// </summary>
    public class Rangos_Pediatria_por_Platillos: BaseEntity
    {
        public int Folio { get; set; }
        public string Nombre_de_rango { get; set; }
        public int? Edad_minima { get; set; }
        public int? Edad_maxima { get; set; }
        public bool? Tiene_padecimientos { get; set; }


    }
	
	public class Rangos_Pediatria_por_Platillos_Datos_Generales
    {
                public int Folio { get; set; }
        public string Nombre_de_rango { get; set; }
        public int? Edad_minima { get; set; }
        public int? Edad_maxima { get; set; }
        public bool? Tiene_padecimientos { get; set; }

		
    }


}

