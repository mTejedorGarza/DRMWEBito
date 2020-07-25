using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Metodos_de_Pago_PacienteMainModel
    {
        public Metodos_de_Pago_PacienteModel Metodos_de_Pago_PacienteInfo { set; get; }
        public MR_TarjetasGridModelPost MR_TarjetasGridInfo { set; get; }

    }

    public class MR_TarjetasGridModelPost
    {
        public int Folio { get; set; }
        public int? Tipo_de_Tarjeta { get; set; }
        public string Numero_de_Tarjeta { get; set; }
        public string Nombre_del_Titular { get; set; }
        public int? Ano_de_vigencia { get; set; }
        public int? Mes_de_vigencia { get; set; }
        public string Alias_de_la_Tarjeta { get; set; }
        public int? Estatus { get; set; }

        public bool Removed { set; get; }
    }



}

