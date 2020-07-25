using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Rangos_Pediatria_por_PlatillosMainModel
    {
        public Rangos_Pediatria_por_PlatillosModel Rangos_Pediatria_por_PlatillosInfo { set; get; }
        public MR_PadecimientosGridModelPost MR_PadecimientosGridInfo { set; get; }

    }

    public class MR_PadecimientosGridModelPost
    {
        public int Folio { get; set; }
        public int? Padecimiento { get; set; }

        public bool Removed { set; get; }
    }



}

