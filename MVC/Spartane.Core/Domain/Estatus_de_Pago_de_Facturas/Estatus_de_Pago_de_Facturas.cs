using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Estatus_de_Pago_de_Facturas
{
    /// <summary>
    /// Estatus_de_Pago_de_Facturas table
    /// </summary>
    public class Estatus_de_Pago_de_Facturas: BaseEntity
    {
        public int Folio { get; set; }
        public string Nombre { get; set; }


    }
	
	public class Estatus_de_Pago_de_Facturas_Datos_Generales
    {
                public int Folio { get; set; }
        public string Nombre { get; set; }

		
    }


}

