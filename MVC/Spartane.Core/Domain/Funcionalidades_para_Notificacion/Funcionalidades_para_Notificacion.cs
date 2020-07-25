using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Estatus_de_Funcionalidad_para_Notificacion;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Funcionalidades_para_Notificacion
{
    /// <summary>
    /// Funcionalidades_para_Notificacion table
    /// </summary>
    public class Funcionalidades_para_Notificacion: BaseEntity
    {
        public int Folio { get; set; }
        public string Funcionalidad { get; set; }
        public string Nombre_de_la_Tabla { get; set; }
        public int? Campos_de_Estatus { get; set; }
        public string Validacion_Obligatoria { get; set; }

        [ForeignKey("Campos_de_Estatus")]
        public virtual Spartane.Core.Domain.Estatus_de_Funcionalidad_para_Notificacion.Estatus_de_Funcionalidad_para_Notificacion Campos_de_Estatus_Estatus_de_Funcionalidad_para_Notificacion { get; set; }

    }
	
	public class Funcionalidades_para_Notificacion_Datos_Generales
    {
                public int Folio { get; set; }
        public string Funcionalidad { get; set; }
        public string Nombre_de_la_Tabla { get; set; }
        public int? Campos_de_Estatus { get; set; }
        public string Validacion_Obligatoria { get; set; }

		        [ForeignKey("Campos_de_Estatus")]
        public virtual Spartane.Core.Domain.Estatus_de_Funcionalidad_para_Notificacion.Estatus_de_Funcionalidad_para_Notificacion Campos_de_Estatus_Estatus_de_Funcionalidad_para_Notificacion { get; set; }

    }


}

