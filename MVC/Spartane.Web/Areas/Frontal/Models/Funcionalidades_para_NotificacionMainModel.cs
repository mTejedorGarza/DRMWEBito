using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Funcionalidades_para_NotificacionMainModel
    {
        public Funcionalidades_para_NotificacionModel Funcionalidades_para_NotificacionInfo { set; get; }
        public MS_Campos_por_FuncionalidadGridModelPost MS_Campos_por_FuncionalidadGridInfo { set; get; }

    }

    public class MS_Campos_por_FuncionalidadGridModelPost
    {
        public int Folio { get; set; }
        public int? Campo { get; set; }

        public bool Removed { set; get; }
    }



}

