using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Codigos_de_DescuentoMainModel
    {
        public Codigos_de_DescuentoModel Codigos_de_DescuentoInfo { set; get; }
        public MS_Planes_por_Codigo_de_DescuentoGridModelPost MS_Planes_por_Codigo_de_DescuentoGridInfo { set; get; }
        public MR_Referenciados_Codigo_de_DescuentoGridModelPost MR_Referenciados_Codigo_de_DescuentoGridInfo { set; get; }

    }

    public class MS_Planes_por_Codigo_de_DescuentoGridModelPost
    {
        public int Folio { get; set; }
        public int? Planes_de_Suscripcion { get; set; }

        public bool Removed { set; get; }
    }

    public class MR_Referenciados_Codigo_de_DescuentoGridModelPost
    {
        public int Folio { get; set; }
        public int? Tipo_de_usuario { get; set; }
        public int? Usuario { get; set; }
        public string Fecha_de_aplicacion { get; set; }
        public decimal? Descuento_Total { get; set; }

        public bool Removed { set; get; }
    }



}

