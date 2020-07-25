﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallPlanes_de_Rutinas_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_Registra_Name { get; set; }
        public int? Paciente { get; set; }
        public string Paciente_Nombre_Completo { get; set; }
        public int? Nivel_de_dificultad { get; set; }
        public string Nivel_de_dificultad_Dificultad { get; set; }
        public int? Semana { get; set; }
        public string Semana_Semana { get; set; }
        public DateTime? Fecha_inicio_del_Plan { get; set; }
        public DateTime? Fecha_fin_del_Plan { get; set; }
        public int? Estatus { get; set; }
        public string Estatus_Descripcion { get; set; }
        public int? Rutina { get; set; }
        public string Rutina_Nombre_de_la_Rutina { get; set; }
        public int? Estatus_de_Seguimiento { get; set; }
        public string Estatus_de_Seguimiento_Descripcion { get; set; }

    }
}
