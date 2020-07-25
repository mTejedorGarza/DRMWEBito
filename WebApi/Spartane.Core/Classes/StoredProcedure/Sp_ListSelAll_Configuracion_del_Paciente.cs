using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllConfiguracion_del_Paciente : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Configuracion_del_Paciente_Folio { get; set; }
        public DateTime? Configuracion_del_Paciente_Fecha_de_Registro { get; set; }
        public string Configuracion_del_Paciente_Hora_de_Registro { get; set; }
        public int? Configuracion_del_Paciente_Usuario_Registrado { get; set; }
        public string Configuracion_del_Paciente_Usuario_Registrado_Name { get; set; }
        public string Configuracion_del_Paciente_Rol { get; set; }
        public string Configuracion_del_Paciente_Token { get; set; }
        public bool? Configuracion_del_Paciente_Android { get; set; }
        public bool? Configuracion_del_Paciente_iOS { get; set; }
        public bool? Configuracion_del_Paciente_Permite_notificaciones_por_email { get; set; }
        public bool? Configuracion_del_Paciente_Permite_notificaciones_push { get; set; }

    }
}
