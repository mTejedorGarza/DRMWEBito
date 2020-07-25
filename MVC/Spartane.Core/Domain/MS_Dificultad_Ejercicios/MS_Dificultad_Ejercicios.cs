using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Ejercicios;
using Spartane.Core.Domain.Nivel_de_dificultad;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.MS_Dificultad_Ejercicios
{
    /// <summary>
    /// MS_Dificultad_Ejercicios table
    /// </summary>
    public class MS_Dificultad_Ejercicios: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Ejercicios { get; set; }
        public int? Nivel_de_Dificultad { get; set; }

        [ForeignKey("Folio_Ejercicios")]
        public virtual Spartane.Core.Domain.Ejercicios.Ejercicios Folio_Ejercicios_Ejercicios { get; set; }
        [ForeignKey("Nivel_de_Dificultad")]
        public virtual Spartane.Core.Domain.Nivel_de_dificultad.Nivel_de_dificultad Nivel_de_Dificultad_Nivel_de_dificultad { get; set; }

    }
	
	public class MS_Dificultad_Ejercicios_Datos_Generales
    {
                public int Folio { get; set; }
        public int? Folio_Ejercicios { get; set; }
        public int? Nivel_de_Dificultad { get; set; }

		        [ForeignKey("Folio_Ejercicios")]
        public virtual Spartane.Core.Domain.Ejercicios.Ejercicios Folio_Ejercicios_Ejercicios { get; set; }
        [ForeignKey("Nivel_de_Dificultad")]
        public virtual Spartane.Core.Domain.Nivel_de_dificultad.Nivel_de_dificultad Nivel_de_Dificultad_Nivel_de_dificultad { get; set; }

    }


}

