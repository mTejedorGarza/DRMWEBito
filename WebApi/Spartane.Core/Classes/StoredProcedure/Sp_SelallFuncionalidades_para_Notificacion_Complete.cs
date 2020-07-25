using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallFuncionalidades_para_Notificacion_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public string Funcionalidad { get; set; }
        public string Nombre_de_la_Tabla { get; set; }
        public int? Campos_de_Estatus { get; set; }
        public string Campos_de_Estatus_Campo_para_Estatus { get; set; }
        public string Validacion_Obligatoria { get; set; }

    }
}
