using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Platillos;
using Spartane.Core.Domain.Tiempos_de_Comida;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.MS_Tiempos_de_Comida_Platillos
{
    /// <summary>
    /// MS_Tiempos_de_Comida_Platillos table
    /// </summary>
    public class MS_Tiempos_de_Comida_Platillos: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Platillos { get; set; }
        public int? Tiempo_de_Comida { get; set; }

        [ForeignKey("Folio_Platillos")]
        public virtual Spartane.Core.Domain.Platillos.Platillos Folio_Platillos_Platillos { get; set; }
        [ForeignKey("Tiempo_de_Comida")]
        public virtual Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida Tiempo_de_Comida_Tiempos_de_Comida { get; set; }

    }
	
	public class MS_Tiempos_de_Comida_Platillos_Datos_Generales
    {
                public int Folio { get; set; }
        public int? Folio_Platillos { get; set; }
        public int? Tiempo_de_Comida { get; set; }

		        [ForeignKey("Folio_Platillos")]
        public virtual Spartane.Core.Domain.Platillos.Platillos Folio_Platillos_Platillos { get; set; }
        [ForeignKey("Tiempo_de_Comida")]
        public virtual Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida Tiempo_de_Comida_Tiempos_de_Comida { get; set; }

    }


}

