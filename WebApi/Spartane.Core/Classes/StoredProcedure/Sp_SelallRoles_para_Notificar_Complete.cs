using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallRoles_para_Notificar_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Configuracion_de_Notificaciones { get; set; }
        public int? Rol { get; set; }
        public string Rol_Descripcion { get; set; }

    }
}
