using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Actividades_del_EventoMainModel
    {
        public Actividades_del_EventoModel Actividades_del_EventoInfo { set; get; }
        public Detalle_Horarios_ActividadGridModelPost Detalle_Horarios_ActividadGridInfo { set; get; }
        public Detalle_Laboratorios_ClinicosGridModelPost Detalle_Laboratorios_ClinicosGridInfo { set; get; }

    }

    public class Detalle_Horarios_ActividadGridModelPost
    {
        public int Folio { get; set; }
        public bool? Reservada { get; set; }
        public int? Numero_de_Cita { get; set; }
        public string Hora_inicio { get; set; }
        public string Hora_fin { get; set; }
        public string Horario { get; set; }
        public int? Codigo_de_Reservacion { get; set; }
        public string Numero_de_Empleado { get; set; }
        public bool? Familiar_del_Empleado { get; set; }
        public string Nombre_Completo { get; set; }
        public int? Parentesco_con_el_Empleado { get; set; }
        public int? Sexo { get; set; }
        public int? Edad { get; set; }
        public int? Estatus_de_la_Reservacion { get; set; }
        public bool? Asistio { get; set; }
        public int? Frecuencia_Cardiaca_ppm { get; set; }
        public int? Presion_sistolica_mm_Hg { get; set; }
        public int? Presion_diastolica_mm_Hg { get; set; }
        public decimal? Peso_actual_kg { get; set; }
        public decimal? Estatura_m { get; set; }
        public int? Circunferencia_de_cintura_cm { get; set; }
        public int? Circunferencia_de_cadera_cm { get; set; }
        public string Diagnostico { get; set; }

        public bool Removed { set; get; }
    }

    public class Detalle_Laboratorios_ClinicosGridModelPost
    {
        public int Folio { get; set; }
        public string Numero_de_Empleado_Titular { get; set; }
        public string Nombre_Completo { get; set; }
        public bool? Familiar_del_Empleado { get; set; }
        public string Numero_de_Empleado_Beneficiario { get; set; }
        public int? Indicador { get; set; }
        public int? Resultado { get; set; }
        public string Unidad { get; set; }
        public string Intervalo_de_referencia { get; set; }
        public string Fecha_de_Resultado { get; set; }
        public string Estatus_Indicador { get; set; }

        public bool Removed { set; get; }
    }



}

