using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Funcionalidades_para_Notificacion;
using Spartane.Core.Domain.Nombre_del_campo_en_MS;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.MS_Campos_por_Funcionalidad
{
    /// <summary>
    /// MS_Campos_por_Funcionalidad table
    /// </summary>
    public class MS_Campos_por_Funcionalidad: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Funcionalidades_Notificacion { get; set; }
        public int? Campo { get; set; }

        [ForeignKey("Folio_Funcionalidades_Notificacion")]
        public virtual Spartane.Core.Domain.Funcionalidades_para_Notificacion.Funcionalidades_para_Notificacion Folio_Funcionalidades_Notificacion_Funcionalidades_para_Notificacion { get; set; }
        [ForeignKey("Campo")]
        public virtual Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS Campo_Nombre_del_campo_en_MS { get; set; }

    }
	
	public class MS_Campos_por_Funcionalidad_Datos_Generales
    {
                public int Folio { get; set; }
        public int? Folio_Funcionalidades_Notificacion { get; set; }
        public int? Campo { get; set; }

		        [ForeignKey("Folio_Funcionalidades_Notificacion")]
        public virtual Spartane.Core.Domain.Funcionalidades_para_Notificacion.Funcionalidades_para_Notificacion Folio_Funcionalidades_Notificacion_Funcionalidades_para_Notificacion { get; set; }
        [ForeignKey("Campo")]
        public virtual Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS Campo_Nombre_del_campo_en_MS { get; set; }

    }


}

