using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllFuncionalidades_para_Notificacion : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Funcionalidades_para_Notificacion_Folio { get; set; }
        public string Funcionalidades_para_Notificacion_Funcionalidad { get; set; }
        public string Funcionalidades_para_Notificacion_Nombre_de_la_Tabla { get; set; }
        public int? Funcionalidades_para_Notificacion_Campos_de_Estatus { get; set; }
        public string Funcionalidades_para_Notificacion_Campos_de_Estatus_Campo_para_Estatus { get; set; }
        public string Funcionalidades_para_Notificacion_Validacion_Obligatoria { get; set; }

    }
}
