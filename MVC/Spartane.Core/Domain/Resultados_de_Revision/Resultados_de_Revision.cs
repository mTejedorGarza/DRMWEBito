using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Resultados_de_Revision
{
    /// <summary>
    /// Resultados_de_Revision table
    /// </summary>
    public class Resultados_de_Revision: BaseEntity
    {
        public int Folio { get; set; }
        public string Nombre { get; set; }


    }
	
	public class Resultados_de_Revision_Datos_Generales
    {
                public int Folio { get; set; }
        public string Nombre { get; set; }

		
    }


}

