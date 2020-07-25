using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllMS_Campos_por_Funcionalidad : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int MS_Campos_por_Funcionalidad_Folio { get; set; }
        public int MS_Campos_por_Funcionalidad_Folio_Funcionalidades_Notificacion { get; set; }
        public int? MS_Campos_por_Funcionalidad_Campo { get; set; }
        public string MS_Campos_por_Funcionalidad_Campo_Descripcion { get; set; }

    }
}
