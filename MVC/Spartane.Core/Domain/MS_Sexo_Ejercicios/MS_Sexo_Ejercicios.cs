using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Ejercicios;
using Spartane.Core.Domain.Sexo;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.MS_Sexo_Ejercicios
{
    /// <summary>
    /// MS_Sexo_Ejercicios table
    /// </summary>
    public class MS_Sexo_Ejercicios: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Ejercicios { get; set; }
        public int? Sexo { get; set; }

        [ForeignKey("Folio_Ejercicios")]
        public virtual Spartane.Core.Domain.Ejercicios.Ejercicios Folio_Ejercicios_Ejercicios { get; set; }
        [ForeignKey("Sexo")]
        public virtual Spartane.Core.Domain.Sexo.Sexo Sexo_Sexo { get; set; }

    }
	
	public class MS_Sexo_Ejercicios_Datos_Generales
    {
                public int Folio { get; set; }
        public int? Folio_Ejercicios { get; set; }
        public int? Sexo { get; set; }

		        [ForeignKey("Folio_Ejercicios")]
        public virtual Spartane.Core.Domain.Ejercicios.Ejercicios Folio_Ejercicios_Ejercicios { get; set; }
        [ForeignKey("Sexo")]
        public virtual Spartane.Core.Domain.Sexo.Sexo Sexo_Sexo { get; set; }

    }


}

