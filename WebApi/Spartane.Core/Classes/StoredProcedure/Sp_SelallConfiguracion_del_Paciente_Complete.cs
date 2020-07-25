using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallConfiguracion_del_Paciente_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_Registrado { get; set; }
        public string Usuario_Registrado_Name { get; set; }
        public string Rol { get; set; }
        public string Token { get; set; }
        public bool? Android { get; set; }
        public bool? iOS { get; set; }
        public bool? Permite_notificaciones_por_email { get; set; }
        public bool? Permite_notificaciones_push { get; set; }

    }
}
