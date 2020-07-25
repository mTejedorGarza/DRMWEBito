using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallMS_Campos_por_Funcionalidad_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Funcionalidades_Notificacion { get; set; }
        public int? Campo { get; set; }
        public string Campo_Descripcion { get; set; }

    }
}
