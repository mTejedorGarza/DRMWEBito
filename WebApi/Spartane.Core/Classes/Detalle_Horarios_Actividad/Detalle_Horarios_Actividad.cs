﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Actividades_del_Evento;
using Spartane.Core.Classes.Detalle_Registro_en_Actividad_Evento;
using Spartane.Core.Classes.Parentescos_Empleados;
using Spartane.Core.Classes.Sexo;
using Spartane.Core.Classes.Estatus_Reservaciones_Actividad;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Detalle_Horarios_Actividad
{
    /// <summary>
    /// Detalle_Horarios_Actividad table
    /// </summary>
    public class Detalle_Horarios_Actividad: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Actividades { get; set; }
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

        [ForeignKey("Folio_Actividades")]
        public virtual Spartane.Core.Classes.Actividades_del_Evento.Actividades_del_Evento Folio_Actividades_Actividades_del_Evento { get; set; }
        [ForeignKey("Codigo_de_Reservacion")]
        public virtual Spartane.Core.Classes.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento Codigo_de_Reservacion_Detalle_Registro_en_Actividad_Evento { get; set; }
        [ForeignKey("Parentesco_con_el_Empleado")]
        public virtual Spartane.Core.Classes.Parentescos_Empleados.Parentescos_Empleados Parentesco_con_el_Empleado_Parentescos_Empleados { get; set; }
        [ForeignKey("Sexo")]
        public virtual Spartane.Core.Classes.Sexo.Sexo Sexo_Sexo { get; set; }
        [ForeignKey("Estatus_de_la_Reservacion")]
        public virtual Spartane.Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad Estatus_de_la_Reservacion_Estatus_Reservaciones_Actividad { get; set; }

    }
}

