﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Planes_de_SuscripcionModel
    {
        [Required]
        public int Folio { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public string Nombre { get; set; }
        public string Nombre_del_Plan { get; set; }
        [Range(0, 9999999999)]
        public int? Duracion_en_meses { get; set; }
        [Range(0, 9999999999)]
        public int? Duracion { get; set; }
        [Range(0, 9999999999)]
        public int? Dietas_por_mes { get; set; }
        [Range(0, 9999999999)]
        public int? Rutinas_por_mes { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Costo_mensual { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Precio_Final { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }
	
	public class Planes_de_Suscripcion_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public string Nombre { get; set; }
        public string Nombre_del_Plan { get; set; }
        [Range(0, 9999999999)]
        public int? Duracion_en_meses { get; set; }
        [Range(0, 9999999999)]
        public int? Duracion { get; set; }
        [Range(0, 9999999999)]
        public int? Dietas_por_mes { get; set; }
        [Range(0, 9999999999)]
        public int? Rutinas_por_mes { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Costo_mensual { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Precio_Final { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }


}

