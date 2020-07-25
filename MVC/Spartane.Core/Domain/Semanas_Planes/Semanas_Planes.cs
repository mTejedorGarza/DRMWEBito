using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Semanas_Planes
{
    /// <summary>
    /// Semanas_Planes table
    /// </summary>
    public class Semanas_Planes: BaseEntity
    {
        public int Folio { get; set; }
        public string Semana { get; set; }
        public int? Semanas_del_mes { get; set; }


    }
	
	public class Semanas_Planes_Datos_Generales
    {
                public int Folio { get; set; }
        public string Semana { get; set; }
        public int? Semanas_del_mes { get; set; }

		
    }


}

