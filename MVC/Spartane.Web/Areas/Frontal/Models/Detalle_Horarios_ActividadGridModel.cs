using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Horarios_ActividadGridModel
    {
        public int Folio { get; set; }
        public bool? Reservada { get; set; }
        public int? Numero_de_Cita { get; set; }
        public string Hora_inicio { get; set; }
        public string Hora_fin { get; set; }
        public string Horario { get; set; }
        public int? Codigo_de_Reservacion { get; set; }
        public string Codigo_de_ReservacionCodigo_Reservacion { get; set; }
        public string Numero_de_Empleado { get; set; }
        public bool? Familiar_del_Empleado { get; set; }
        public string Nombre_Completo { get; set; }
        public int? Parentesco_con_el_Empleado { get; set; }
        public string Parentesco_con_el_EmpleadoDescripcion { get; set; }
        public int? Sexo { get; set; }
        public string SexoDescripcion { get; set; }
        public int? Edad { get; set; }
        public int? Estatus_de_la_Reservacion { get; set; }
        public string Estatus_de_la_ReservacionDescripcion { get; set; }
        public bool? Asistio { get; set; }
        public int? Frecuencia_Cardiaca_ppm { get; set; }
        public int? Presion_sistolica_mm_Hg { get; set; }
        public int? Presion_diastolica_mm_Hg { get; set; }
        public decimal? Peso_actual_kg { get; set; }
        public decimal? Estatura_m { get; set; }
        public int? Circunferencia_de_cintura_cm { get; set; }
        public int? Circunferencia_de_cadera_cm { get; set; }
        public string Diagnostico { get; set; }
        
    }
}

