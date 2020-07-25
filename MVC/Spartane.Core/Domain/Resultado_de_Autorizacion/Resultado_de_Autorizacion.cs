using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Resultado_de_Autorizacion
{
    /// <summary>
    /// Resultado_de_Autorizacion table
    /// </summary>
    public class Resultado_de_Autorizacion: BaseEntity
    {
        public int Folio { get; set; }
        public string Nombre { get; set; }


    }
	
	public class Resultado_de_Autorizacion_Datos_Generales
    {
                public int Folio { get; set; }
        public string Nombre { get; set; }

		
    }


}

