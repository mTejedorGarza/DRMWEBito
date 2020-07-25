using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllMS_Roles_de_Usuario_Notificacion : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int MS_Roles_de_Usuario_Notificacion_Folio { get; set; }
        public int MS_Roles_de_Usuario_Notificacion_Folio_Configuracion_Notificaciones { get; set; }
        public int? MS_Roles_de_Usuario_Notificacion_Nombre_del_Campo { get; set; }
        public string MS_Roles_de_Usuario_Notificacion_Nombre_del_Campo_Descripcion { get; set; }

    }
}
