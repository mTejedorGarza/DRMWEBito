using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Planes_de_RutinasGridModel
    {
        public int Folio { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public int? Paciente { get; set; }
        public string PacienteNombre_Completo { get; set; }
        public int? Nivel_de_dificultad { get; set; }
        public string Nivel_de_dificultadDificultad { get; set; }
        public int? Semana { get; set; }
        public string SemanaSemana { get; set; }
        public string Fecha_inicio_del_Plan { get; set; }
        public string Fecha_fin_del_Plan { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }
        public int? Rutina { get; set; }
        public string RutinaNombre_de_la_Rutina { get; set; }
        public int? Estatus_de_Seguimiento { get; set; }
        public string Estatus_de_SeguimientoDescripcion { get; set; }
        
    }
}

