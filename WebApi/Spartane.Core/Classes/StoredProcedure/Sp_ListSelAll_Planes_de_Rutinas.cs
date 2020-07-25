using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllPlanes_de_Rutinas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Planes_de_Rutinas_Folio { get; set; }
        public DateTime? Planes_de_Rutinas_Fecha_de_Registro { get; set; }
        public string Planes_de_Rutinas_Hora_de_Registro { get; set; }
        public int? Planes_de_Rutinas_Usuario_que_Registra { get; set; }
        public string Planes_de_Rutinas_Usuario_que_Registra_Name { get; set; }
        public int? Planes_de_Rutinas_Paciente { get; set; }
        public string Planes_de_Rutinas_Paciente_Nombre_Completo { get; set; }
        public int? Planes_de_Rutinas_Nivel_de_dificultad { get; set; }
        public string Planes_de_Rutinas_Nivel_de_dificultad_Dificultad { get; set; }
        public int? Planes_de_Rutinas_Semana { get; set; }
        public string Planes_de_Rutinas_Semana_Semana { get; set; }
        public DateTime? Planes_de_Rutinas_Fecha_inicio_del_Plan { get; set; }
        public DateTime? Planes_de_Rutinas_Fecha_fin_del_Plan { get; set; }
        public int? Planes_de_Rutinas_Estatus { get; set; }
        public string Planes_de_Rutinas_Estatus_Descripcion { get; set; }
        public int? Planes_de_Rutinas_Rutina { get; set; }
        public string Planes_de_Rutinas_Rutina_Nombre_de_la_Rutina { get; set; }
        public int? Planes_de_Rutinas_Estatus_de_Seguimiento { get; set; }
        public string Planes_de_Rutinas_Estatus_de_Seguimiento_Descripcion { get; set; }

    }
}
