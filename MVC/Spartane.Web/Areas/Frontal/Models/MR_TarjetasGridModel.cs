using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class MR_TarjetasGridModel
    {
        public int Folio { get; set; }
        public int? Tipo_de_Tarjeta { get; set; }
        public string Tipo_de_TarjetaDescripcion { get; set; }
        public string Numero_de_Tarjeta { get; set; }
        public string Nombre_del_Titular { get; set; }
        public int? Ano_de_vigencia { get; set; }
        public int? Mes_de_vigencia { get; set; }
        public string Alias_de_la_Tarjeta { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }
        
    }
}

