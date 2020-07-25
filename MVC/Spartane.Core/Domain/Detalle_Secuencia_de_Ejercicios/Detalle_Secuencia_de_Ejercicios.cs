using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Configuracion_de_Rutinas;
using Spartane.Core.Domain.Secuencia_de_Ejercicios_en_Rutinas;
using Spartane.Core.Domain.Tipo_de_Ejercicio_Rutina;
using Spartane.Core.Domain.Tipo_de_Enfoque_del_Ejercicio;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Detalle_Secuencia_de_Ejercicios
{
    /// <summary>
    /// Detalle_Secuencia_de_Ejercicios table
    /// </summary>
    public class Detalle_Secuencia_de_Ejercicios: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Configuracion_Rutinas { get; set; }
        public int? Orden_del_Ejercicio { get; set; }
        public int? Tipo_de_Ejercicio { get; set; }
        public int? Enfoque { get; set; }
        public string Secuencia_del_Ejercicio { get; set; }

        [ForeignKey("Folio_Configuracion_Rutinas")]
        public virtual Spartane.Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas Folio_Configuracion_Rutinas_Configuracion_de_Rutinas { get; set; }
        [ForeignKey("Orden_del_Ejercicio")]
        public virtual Spartane.Core.Domain.Secuencia_de_Ejercicios_en_Rutinas.Secuencia_de_Ejercicios_en_Rutinas Orden_del_Ejercicio_Secuencia_de_Ejercicios_en_Rutinas { get; set; }
        [ForeignKey("Tipo_de_Ejercicio")]
        public virtual Spartane.Core.Domain.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina Tipo_de_Ejercicio_Tipo_de_Ejercicio_Rutina { get; set; }
        [ForeignKey("Enfoque")]
        public virtual Spartane.Core.Domain.Tipo_de_Enfoque_del_Ejercicio.Tipo_de_Enfoque_del_Ejercicio Enfoque_Tipo_de_Enfoque_del_Ejercicio { get; set; }

    }
	
	public class Detalle_Secuencia_de_Ejercicios_Datos_Generales
    {
                public int Folio { get; set; }
        public int? Folio_Configuracion_Rutinas { get; set; }
        public int? Orden_del_Ejercicio { get; set; }
        public int? Tipo_de_Ejercicio { get; set; }
        public int? Enfoque { get; set; }
        public string Secuencia_del_Ejercicio { get; set; }

		        [ForeignKey("Folio_Configuracion_Rutinas")]
        public virtual Spartane.Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas Folio_Configuracion_Rutinas_Configuracion_de_Rutinas { get; set; }
        [ForeignKey("Orden_del_Ejercicio")]
        public virtual Spartane.Core.Domain.Secuencia_de_Ejercicios_en_Rutinas.Secuencia_de_Ejercicios_en_Rutinas Orden_del_Ejercicio_Secuencia_de_Ejercicios_en_Rutinas { get; set; }
        [ForeignKey("Tipo_de_Ejercicio")]
        public virtual Spartane.Core.Domain.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina Tipo_de_Ejercicio_Tipo_de_Ejercicio_Rutina { get; set; }
        [ForeignKey("Enfoque")]
        public virtual Spartane.Core.Domain.Tipo_de_Enfoque_del_Ejercicio.Tipo_de_Enfoque_del_Ejercicio Enfoque_Tipo_de_Enfoque_del_Ejercicio { get; set; }

    }


}

