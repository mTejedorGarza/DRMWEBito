using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Configuracion_de_NotificacionesMainModel
    {
        public Configuracion_de_NotificacionesModel Configuracion_de_NotificacionesInfo { set; get; }
        public Roles_para_NotificarGridModelPost Roles_para_NotificarGridInfo { set; get; }
        public Detalle_Frecuencia_NotificacionesGridModelPost Detalle_Frecuencia_NotificacionesGridInfo { set; get; }

    }

    public class Roles_para_NotificarGridModelPost
    {
        public int Folio { get; set; }
        public int? Rol { get; set; }

        public bool Removed { set; get; }
    }

    public class Detalle_Frecuencia_NotificacionesGridModelPost
    {
        public int Folio { get; set; }
        public int? Frecuencia { get; set; }
        public int? Dia { get; set; }
        public string Hora { get; set; }

        public bool Removed { set; get; }
    }



}

