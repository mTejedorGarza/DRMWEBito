using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Configuracion_del_PacienteMainModel
    {
        public Configuracion_del_PacienteModel Configuracion_del_PacienteInfo { set; get; }
        public Detalle_Notificaciones_PacienteGridModelPost Detalle_Notificaciones_PacienteGridInfo { set; get; }

    }

    public class Detalle_Notificaciones_PacienteGridModelPost
    {
        public int Folio { get; set; }
        public int? Funcionalidad { get; set; }

        public bool Removed { set; get; }
    }



}

