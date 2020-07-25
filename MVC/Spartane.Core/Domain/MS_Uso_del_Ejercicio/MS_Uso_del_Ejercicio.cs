﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Ejercicios;
using Spartane.Core.Domain.Tipo_de_Ejercicio_Rutina;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.MS_Uso_del_Ejercicio
{
    /// <summary>
    /// MS_Uso_del_Ejercicio table
    /// </summary>
    public class MS_Uso_del_Ejercicio: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Ejercicios { get; set; }
        public int? Uso_del_Ejercicio { get; set; }

        [ForeignKey("Folio_Ejercicios")]
        public virtual Spartane.Core.Domain.Ejercicios.Ejercicios Folio_Ejercicios_Ejercicios { get; set; }
        [ForeignKey("Uso_del_Ejercicio")]
        public virtual Spartane.Core.Domain.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina Uso_del_Ejercicio_Tipo_de_Ejercicio_Rutina { get; set; }

    }
	
	public class MS_Uso_del_Ejercicio_Datos_Generales
    {
                public int Folio { get; set; }
        public int? Folio_Ejercicios { get; set; }
        public int? Uso_del_Ejercicio { get; set; }

		        [ForeignKey("Folio_Ejercicios")]
        public virtual Spartane.Core.Domain.Ejercicios.Ejercicios Folio_Ejercicios_Ejercicios { get; set; }
        [ForeignKey("Uso_del_Ejercicio")]
        public virtual Spartane.Core.Domain.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina Uso_del_Ejercicio_Tipo_de_Ejercicio_Rutina { get; set; }

    }


}

