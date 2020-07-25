using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class MR_PadecimientosGridModel
    {
        public int Folio { get; set; }
        public int? Padecimiento { get; set; }
        public string PadecimientoDescripcion { get; set; }
        
    }
}

