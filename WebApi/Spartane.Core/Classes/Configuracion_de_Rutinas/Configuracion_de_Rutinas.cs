using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_User;
using Spartane.Core.Classes.Tipo_de_Ejercicio_Rutina;
using Spartane.Core.Classes.Nivel_de_dificultad;
using Spartane.Core.Classes.Sexo;
using Spartane.Core.Classes.Estatus;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Configuracion_de_Rutinas
{
    /// <summary>
    /// Configuracion_de_Rutinas table
    /// </summary>
    public class Configuracion_de_Rutinas: BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public int? Tipo_de_Rutina { get; set; }
        public int? Nivel_de_Dificultad { get; set; }
        public int? Sexo { get; set; }
        public short? Cantidad_de_ejercicios { get; set; }
        public short? Cantidad_de_series { get; set; }
        public short? Cantidad_de_repeticiones { get; set; }
        public int? Descanso_segundos { get; set; }
        public string Texto_Ejercicios { get; set; }
        public bool? Lleva_Calentamiento { get; set; }
        public bool? Lleva_Enfriamiento { get; set; }
        public int? Estatus { get; set; }

        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Classes.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Tipo_de_Rutina")]
        public virtual Spartane.Core.Classes.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina Tipo_de_Rutina_Tipo_de_Ejercicio_Rutina { get; set; }
        [ForeignKey("Nivel_de_Dificultad")]
        public virtual Spartane.Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad Nivel_de_Dificultad_Nivel_de_dificultad { get; set; }
        [ForeignKey("Sexo")]
        public virtual Spartane.Core.Classes.Sexo.Sexo Sexo_Sexo { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Classes.Estatus.Estatus Estatus_Estatus { get; set; }

    }
}

