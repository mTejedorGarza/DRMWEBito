using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Notificaciones_Paciente_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int FolioConfiguracion { get; set; }
        public int? Funcionalidad { get; set; }
        public string Funcionalidad_Funcionalidad { get; set; }

    }
}
