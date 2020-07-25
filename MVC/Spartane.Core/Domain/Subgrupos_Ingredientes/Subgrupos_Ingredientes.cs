using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Clasificacion_Ingredientes;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Subgrupos_Ingredientes
{
    /// <summary>
    /// Subgrupos_Ingredientes table
    /// </summary>
    public class Subgrupos_Ingredientes: BaseEntity
    {
        public int Folio { get; set; }
        public string Nombre { get; set; }
        public int? Clasificacion { get; set; }

        [ForeignKey("Clasificacion")]
        public virtual Spartane.Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes Clasificacion_Clasificacion_Ingredientes { get; set; }

    }
	
	public class Subgrupos_Ingredientes_Datos_Generales
    {
                public int Folio { get; set; }
        public string Nombre { get; set; }
        public int? Clasificacion { get; set; }

		        [ForeignKey("Clasificacion")]
        public virtual Spartane.Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes Clasificacion_Clasificacion_Ingredientes { get; set; }

    }


}

