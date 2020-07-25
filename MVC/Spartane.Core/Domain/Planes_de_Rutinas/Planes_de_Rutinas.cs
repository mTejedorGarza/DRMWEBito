using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Pacientes;
using Spartane.Core.Domain.Nivel_de_dificultad;
using Spartane.Core.Domain.Semanas_Planes;
using Spartane.Core.Domain.Estatus;
using Spartane.Core.Domain.Rutinas;
using Spartane.Core.Domain.Estatus_Plan_de_Rutinas;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Planes_de_Rutinas
{
    /// <summary>
    /// Planes_de_Rutinas table
    /// </summary>
    public class Planes_de_Rutinas: BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public int? Paciente { get; set; }
        public int? Nivel_de_dificultad { get; set; }
        public int? Semana { get; set; }
        public DateTime? Fecha_inicio_del_Plan { get; set; }
        public DateTime? Fecha_fin_del_Plan { get; set; }
        public int? Estatus { get; set; }
        public int? Rutina { get; set; }
        public int? Estatus_de_Seguimiento { get; set; }

        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Paciente")]
        public virtual Spartane.Core.Domain.Pacientes.Pacientes Paciente_Pacientes { get; set; }
        [ForeignKey("Nivel_de_dificultad")]
        public virtual Spartane.Core.Domain.Nivel_de_dificultad.Nivel_de_dificultad Nivel_de_dificultad_Nivel_de_dificultad { get; set; }
        [ForeignKey("Semana")]
        public virtual Spartane.Core.Domain.Semanas_Planes.Semanas_Planes Semana_Semanas_Planes { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus.Estatus Estatus_Estatus { get; set; }
        [ForeignKey("Rutina")]
        public virtual Spartane.Core.Domain.Rutinas.Rutinas Rutina_Rutinas { get; set; }
        [ForeignKey("Estatus_de_Seguimiento")]
        public virtual Spartane.Core.Domain.Estatus_Plan_de_Rutinas.Estatus_Plan_de_Rutinas Estatus_de_Seguimiento_Estatus_Plan_de_Rutinas { get; set; }

    }
	
	public class Planes_de_Rutinas_Datos_Generales
    {
                public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public int? Paciente { get; set; }
        public int? Nivel_de_dificultad { get; set; }
        public int? Semana { get; set; }
        public DateTime? Fecha_inicio_del_Plan { get; set; }
        public DateTime? Fecha_fin_del_Plan { get; set; }
        public int? Estatus { get; set; }
        public int? Rutina { get; set; }

		        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Paciente")]
        public virtual Spartane.Core.Domain.Pacientes.Pacientes Paciente_Pacientes { get; set; }
        [ForeignKey("Nivel_de_dificultad")]
        public virtual Spartane.Core.Domain.Nivel_de_dificultad.Nivel_de_dificultad Nivel_de_dificultad_Nivel_de_dificultad { get; set; }
        [ForeignKey("Semana")]
        public virtual Spartane.Core.Domain.Semanas_Planes.Semanas_Planes Semana_Semanas_Planes { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus.Estatus Estatus_Estatus { get; set; }
        [ForeignKey("Rutina")]
        public virtual Spartane.Core.Domain.Rutinas.Rutinas Rutina_Rutinas { get; set; }

    }

	public class Planes_de_Rutinas_Seguimiento_al_Plan
    {
                public int Folio { get; set; }
        public int? Estatus_de_Seguimiento { get; set; }

		        [ForeignKey("Estatus_de_Seguimiento")]
        public virtual Spartane.Core.Domain.Estatus_Plan_de_Rutinas.Estatus_Plan_de_Rutinas Estatus_de_Seguimiento_Estatus_Plan_de_Rutinas { get; set; }

    }


}

