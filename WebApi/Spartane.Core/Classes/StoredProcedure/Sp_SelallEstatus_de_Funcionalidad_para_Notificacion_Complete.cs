using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallEstatus_de_Funcionalidad_para_Notificacion_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public string Campo_para_Estatus { get; set; }
        public string Nombre_Fisico_del_Campo { get; set; }
        public string Nombre_Fisico_de_la_Tabla { get; set; }

    }
}
