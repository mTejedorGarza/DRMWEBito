using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllEstatus_de_Funcionalidad_para_Notificacion : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Estatus_de_Funcionalidad_para_Notificacion_Folio { get; set; }
        public string Estatus_de_Funcionalidad_para_Notificacion_Campo_para_Estatus { get; set; }
        public string Estatus_de_Funcionalidad_para_Notificacion_Nombre_Fisico_del_Campo { get; set; }
        public string Estatus_de_Funcionalidad_para_Notificacion_Nombre_Fisico_de_la_Tabla { get; set; }

    }
}
