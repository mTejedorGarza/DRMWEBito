using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallMS_Roles_de_Usuario_Notificacion_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Configuracion_Notificaciones { get; set; }
        public int? Nombre_del_Campo { get; set; }
        public string Nombre_del_Campo_Descripcion { get; set; }

    }
}
