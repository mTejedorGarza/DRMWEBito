using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Funcionalidades_para_Notificacion;
using Spartane.Core.Classes.Nombre_del_campo_en_MS;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.MS_Roles_de_Usuario_Notificacion
{
    /// <summary>
    /// MS_Roles_de_Usuario_Notificacion table
    /// </summary>
    public class MS_Roles_de_Usuario_Notificacion: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Configuracion_Notificaciones { get; set; }
        public int? Nombre_del_Campo { get; set; }

        [ForeignKey("Folio_Configuracion_Notificaciones")]
        public virtual Spartane.Core.Classes.Funcionalidades_para_Notificacion.Funcionalidades_para_Notificacion Folio_Configuracion_Notificaciones_Funcionalidades_para_Notificacion { get; set; }
        [ForeignKey("Nombre_del_Campo")]
        public virtual Spartane.Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS Nombre_del_Campo_Nombre_del_campo_en_MS { get; set; }

    }
}

