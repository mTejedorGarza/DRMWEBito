using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Platillos;
using Spartane.Core.Domain.Dificultad_de_platillos;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.MS_Dificultad_Platillos
{
    /// <summary>
    /// MS_Dificultad_Platillos table
    /// </summary>
    public class MS_Dificultad_Platillos: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Platillos { get; set; }
        public int? Dificultad { get; set; }

        [ForeignKey("Folio_Platillos")]
        public virtual Spartane.Core.Domain.Platillos.Platillos Folio_Platillos_Platillos { get; set; }
        [ForeignKey("Dificultad")]
        public virtual Spartane.Core.Domain.Dificultad_de_platillos.Dificultad_de_platillos Dificultad_Dificultad_de_platillos { get; set; }

    }
	
	public class MS_Dificultad_Platillos_Datos_Generales
    {
                public int Folio { get; set; }
        public int? Folio_Platillos { get; set; }
        public int? Dificultad { get; set; }

		        [ForeignKey("Folio_Platillos")]
        public virtual Spartane.Core.Domain.Platillos.Platillos Folio_Platillos_Platillos { get; set; }
        [ForeignKey("Dificultad")]
        public virtual Spartane.Core.Domain.Dificultad_de_platillos.Dificultad_de_platillos Dificultad_Dificultad_de_platillos { get; set; }

    }


}

