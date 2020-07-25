using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class EjerciciosMainModel
    {
        public EjerciciosModel EjerciciosInfo { set; get; }
        public MS_Uso_del_EjercicioGridModelPost MS_Uso_del_EjercicioGridInfo { set; get; }
        public MS_MusculosGridModelPost MS_MusculosGridInfo { set; get; }
        public MS_Equipamiento_para_EjerciciosGridModelPost MS_Equipamiento_para_EjerciciosGridInfo { set; get; }
        public MS_Equipamiento_Alterno_EjerciciosGridModelPost MS_Equipamiento_Alterno_EjerciciosGridInfo { set; get; }
        public MS_Sexo_EjerciciosGridModelPost MS_Sexo_EjerciciosGridInfo { set; get; }
        public MS_Dificultad_EjerciciosGridModelPost MS_Dificultad_EjerciciosGridInfo { set; get; }

    }

    public class MS_Uso_del_EjercicioGridModelPost
    {
        public int Folio { get; set; }
        public int? Uso_del_Ejercicio { get; set; }

        public bool Removed { set; get; }
    }

    public class MS_MusculosGridModelPost
    {
        public int Folio { get; set; }
        public int? Musculo { get; set; }

        public bool Removed { set; get; }
    }

    public class MS_Equipamiento_para_EjerciciosGridModelPost
    {
        public int Folio { get; set; }
        public int? Equipamento { get; set; }

        public bool Removed { set; get; }
    }

    public class MS_Equipamiento_Alterno_EjerciciosGridModelPost
    {
        public int Folio { get; set; }
        public int? Equipamiento_Alterno { get; set; }

        public bool Removed { set; get; }
    }

    public class MS_Sexo_EjerciciosGridModelPost
    {
        public int Folio { get; set; }
        public int? Sexo { get; set; }

        public bool Removed { set; get; }
    }

    public class MS_Dificultad_EjerciciosGridModelPost
    {
        public int Folio { get; set; }
        public int? Nivel_de_Dificultad { get; set; }

        public bool Removed { set; get; }
    }



}

