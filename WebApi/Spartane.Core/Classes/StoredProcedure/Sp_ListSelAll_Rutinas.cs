using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllRutinas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Rutinas_Folio { get; set; }
        public DateTime? Rutinas_Fecha_de_Registro { get; set; }
        public string Rutinas_Hora_de_Registro { get; set; }
        public int? Rutinas_Usuario_que_Registra { get; set; }
        public string Rutinas_Usuario_que_Registra_Name { get; set; }
        public int? Rutinas_Tipo_de_Rutina { get; set; }
        public string Rutinas_Tipo_de_Rutina_Tipo_de_Rutina { get; set; }
        public int? Rutinas_Nivel_de_dificultad { get; set; }
        public string Rutinas_Nivel_de_dificultad_Dificultad { get; set; }
        public int? Rutinas_Sexo { get; set; }
        public string Rutinas_Sexo_Descripcion { get; set; }
        public string Rutinas_Nombre_de_la_Rutina { get; set; }
        public string Rutinas_Descripcion { get; set; }
        public string Rutinas_Equipamiento { get; set; }
        public string Rutinas_Equipamiento_alterno { get; set; }
        public int? Rutinas_Estatus { get; set; }
        public string Rutinas_Estatus_Descripcion { get; set; }

    }
}
