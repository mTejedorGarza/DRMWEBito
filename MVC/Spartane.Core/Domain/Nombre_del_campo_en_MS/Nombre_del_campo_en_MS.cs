using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Nombre_del_campo_en_MS
{
    /// <summary>
    /// Nombre_del_campo_en_MS table
    /// </summary>
    public class Nombre_del_campo_en_MS: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public string Nombre_Fisico_del_Campo { get; set; }
        public string Nombre_Fisico_de_la_Tabla { get; set; }


    }
	
	public class Nombre_del_campo_en_MS_Datos_Generales
    {
                public int Clave { get; set; }
        public string Descripcion { get; set; }
        public string Nombre_Fisico_del_Campo { get; set; }
        public string Nombre_Fisico_de_la_Tabla { get; set; }

		
    }


}

