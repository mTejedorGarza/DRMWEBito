﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class RutinasGridModel
    {
        public int Folio { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public int? Tipo_de_Rutina { get; set; }
        public string Tipo_de_RutinaTipo_de_Rutina { get; set; }
        public int? Nivel_de_dificultad { get; set; }
        public string Nivel_de_dificultadDificultad { get; set; }
        public int? Sexo { get; set; }
        public string SexoDescripcion { get; set; }
        public string Nombre_de_la_Rutina { get; set; }
        public string Descripcion { get; set; }
        public string Equipamiento { get; set; }
        public string Equipamiento_alterno { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }
        
    }
}

