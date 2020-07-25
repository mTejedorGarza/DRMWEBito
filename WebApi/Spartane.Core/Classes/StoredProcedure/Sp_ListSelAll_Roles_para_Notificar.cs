using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllRoles_para_Notificar : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Roles_para_Notificar_Folio { get; set; }
        public int Roles_para_Notificar_Folio_Configuracion_de_Notificaciones { get; set; }
        public int? Roles_para_Notificar_Rol { get; set; }
        public string Roles_para_Notificar_Rol_Descripcion { get; set; }

    }
}
