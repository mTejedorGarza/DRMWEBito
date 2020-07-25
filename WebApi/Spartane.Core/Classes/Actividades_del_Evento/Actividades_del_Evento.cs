﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_User;
using Spartane.Core.Classes.Eventos;
using Spartane.Core.Classes.Detalle_Actividades_Evento;
using Spartane.Core.Classes.Ubicaciones_Eventos_Empresa;
using Spartane.Core.Classes.Tipos_de_Actividades;
using Spartane.Core.Classes.Spartan_User;
using Spartane.Core.Classes.Especialidades;
using Spartane.Core.Classes.Estatus_Actividades_Evento;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Actividades_del_Evento
{
    /// <summary>
    /// Actividades_del_Evento table
    /// </summary>
    public class Actividades_del_Evento: BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public int? Evento { get; set; }
        public int? Actividad { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Dia { get; set; }
        public string Hora_inicio { get; set; }
        public string Hora_fin { get; set; }
        public bool? Tiene_receso { get; set; }
        public string Hora_inicio_receso { get; set; }
        public string Hora_fin_receso { get; set; }
        public int? Ubicacion { get; set; }
        public int? Tipo_de_Actividad { get; set; }
        public int? Quien_imparte { get; set; }
        public int? Especialidad { get; set; }
        public bool? Cupo_limitado { get; set; }
        public int? Cupo_maximo { get; set; }
        public int? Duracion_maxima_por_Paciente_mins { get; set; }
        public int? Estatus { get; set; }

        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Classes.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Evento")]
        public virtual Spartane.Core.Classes.Eventos.Eventos Evento_Eventos { get; set; }
        [ForeignKey("Actividad")]
        public virtual Spartane.Core.Classes.Detalle_Actividades_Evento.Detalle_Actividades_Evento Actividad_Detalle_Actividades_Evento { get; set; }
        [ForeignKey("Ubicacion")]
        public virtual Spartane.Core.Classes.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa Ubicacion_Ubicaciones_Eventos_Empresa { get; set; }
        [ForeignKey("Tipo_de_Actividad")]
        public virtual Spartane.Core.Classes.Tipos_de_Actividades.Tipos_de_Actividades Tipo_de_Actividad_Tipos_de_Actividades { get; set; }
        [ForeignKey("Quien_imparte")]
        public virtual Spartane.Core.Classes.Spartan_User.Spartan_User Quien_imparte_Spartan_User { get; set; }
        [ForeignKey("Especialidad")]
        public virtual Spartane.Core.Classes.Especialidades.Especialidades Especialidad_Especialidades { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_Evento Estatus_Estatus_Actividades_Evento { get; set; }

    }
}

