using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllConfiguracion_de_Rutinas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Configuracion_de_Rutinas_Folio { get; set; }
        public DateTime? Configuracion_de_Rutinas_Fecha_de_Registro { get; set; }
        public string Configuracion_de_Rutinas_Hora_de_Registro { get; set; }
        public int? Configuracion_de_Rutinas_Usuario_que_Registra { get; set; }
        public string Configuracion_de_Rutinas_Usuario_que_Registra_Name { get; set; }
        public int? Configuracion_de_Rutinas_Tipo_de_Rutina { get; set; }
        public string Configuracion_de_Rutinas_Tipo_de_Rutina_Tipo_de_Rutina { get; set; }
        public int? Configuracion_de_Rutinas_Nivel_de_Dificultad { get; set; }
        public string Configuracion_de_Rutinas_Nivel_de_Dificultad_Dificultad { get; set; }
        public int? Configuracion_de_Rutinas_Sexo { get; set; }
        public string Configuracion_de_Rutinas_Sexo_Descripcion { get; set; }
        public short? Configuracion_de_Rutinas_Cantidad_de_ejercicios { get; set; }
        public short? Configuracion_de_Rutinas_Cantidad_de_series { get; set; }
        public short? Configuracion_de_Rutinas_Cantidad_de_repeticiones { get; set; }
        public int? Configuracion_de_Rutinas_Descanso_segundos { get; set; }
        public string Configuracion_de_Rutinas_Texto_Ejercicios { get; set; }
        public bool? Configuracion_de_Rutinas_Lleva_Calentamiento { get; set; }
        public bool? Configuracion_de_Rutinas_Lleva_Enfriamiento { get; set; }
        public int? Configuracion_de_Rutinas_Estatus { get; set; }
        public string Configuracion_de_Rutinas_Estatus_Descripcion { get; set; }

    }
}
