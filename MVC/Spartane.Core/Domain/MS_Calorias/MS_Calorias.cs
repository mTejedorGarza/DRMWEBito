using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Platillos;
using Spartane.Core.Domain.Calorias;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.MS_Calorias
{
    /// <summary>
    /// MS_Calorias table
    /// </summary>
    public class MS_Calorias: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Platillo { get; set; }
        public int? Calorias { get; set; }

        [ForeignKey("Folio_Platillo")]
        public virtual Spartane.Core.Domain.Platillos.Platillos Folio_Platillo_Platillos { get; set; }
        [ForeignKey("Calorias")]
        public virtual Spartane.Core.Domain.Calorias.Calorias Calorias_Calorias { get; set; }

    }
	
	public class MS_Calorias_Datos_Generales
    {
                public int Folio { get; set; }
        public int? Folio_Platillo { get; set; }
        public int? Calorias { get; set; }

		        [ForeignKey("Folio_Platillo")]
        public virtual Spartane.Core.Domain.Platillos.Platillos Folio_Platillo_Platillos { get; set; }
        [ForeignKey("Calorias")]
        public virtual Spartane.Core.Domain.Calorias.Calorias Calorias_Calorias { get; set; }

    }


}

