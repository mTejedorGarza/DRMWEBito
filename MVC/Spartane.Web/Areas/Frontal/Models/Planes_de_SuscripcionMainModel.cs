using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Planes_de_SuscripcionMainModel
    {
        public Planes_de_SuscripcionModel Planes_de_SuscripcionInfo { set; get; }
        public MS_Beneficiarios_SuscripcionGridModelPost MS_Beneficiarios_SuscripcionGridInfo { set; get; }
        public MS_Semanas_PlanesGridModelPost MS_Semanas_PlanesGridInfo { set; get; }

    }

    public class MS_Beneficiarios_SuscripcionGridModelPost
    {
        public int Folio { get; set; }
        public int? Beneficiario { get; set; }

        public bool Removed { set; get; }
    }

    public class MS_Semanas_PlanesGridModelPost
    {
        public int Folio { get; set; }
        public int? Semanas { get; set; }

        public bool Removed { set; get; }
    }



}

