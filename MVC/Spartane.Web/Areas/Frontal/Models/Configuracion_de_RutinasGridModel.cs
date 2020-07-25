using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Configuracion_de_RutinasGridModel
    {
        public int Folio { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public int? Tipo_de_Rutina { get; set; }
        public string Tipo_de_RutinaTipo_de_Rutina { get; set; }
        public int? Nivel_de_Dificultad { get; set; }
        public string Nivel_de_DificultadDificultad { get; set; }
        public int? Sexo { get; set; }
        public string SexoDescripcion { get; set; }
        public short? Cantidad_de_ejercicios { get; set; }
        public short? Cantidad_de_series { get; set; }
        public short? Cantidad_de_repeticiones { get; set; }
        public int? Descanso_segundos { get; set; }
        public string Texto_Ejercicios { get; set; }
        public bool? Lleva_Calentamiento { get; set; }
        public bool? Lleva_Enfriamiento { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }
        
    }
}

