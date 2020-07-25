using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Actividades_del_Evento;
using Spartane.Core.Domain.Indicadores_Laboratorio;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Detalle_Laboratorios_Clinicos
{
    /// <summary>
    /// Detalle_Laboratorios_Clinicos table
    /// </summary>
    public class Detalle_Laboratorios_Clinicos: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Actividades_del_Evento { get; set; }
        public string Numero_de_Empleado_Titular { get; set; }
        public string Nombre_Completo { get; set; }
        public bool? Familiar_del_Empleado { get; set; }
        public string Numero_de_Empleado_Beneficiario { get; set; }
        public int? Indicador { get; set; }
        public int? Resultado { get; set; }
        public string Unidad { get; set; }
        public string Intervalo_de_referencia { get; set; }
        public DateTime? Fecha_de_Resultado { get; set; }
        public string Estatus_Indicador { get; set; }

        [ForeignKey("Folio_Actividades_del_Evento")]
        public virtual Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento Folio_Actividades_del_Evento_Actividades_del_Evento { get; set; }
        [ForeignKey("Indicador")]
        public virtual Spartane.Core.Domain.Indicadores_Laboratorio.Indicadores_Laboratorio Indicador_Indicadores_Laboratorio { get; set; }

    }
	
	public class Detalle_Laboratorios_Clinicos_Datos_Generales
    {
                public int Folio { get; set; }
        public int? Folio_Actividades_del_Evento { get; set; }
        public string Numero_de_Empleado_Titular { get; set; }
        public string Nombre_Completo { get; set; }
        public bool? Familiar_del_Empleado { get; set; }
        public string Numero_de_Empleado_Beneficiario { get; set; }
        public int? Indicador { get; set; }
        public int? Resultado { get; set; }
        public string Unidad { get; set; }
        public string Intervalo_de_referencia { get; set; }
        public DateTime? Fecha_de_Resultado { get; set; }
        public string Estatus_Indicador { get; set; }

		        [ForeignKey("Folio_Actividades_del_Evento")]
        public virtual Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento Folio_Actividades_del_Evento_Actividades_del_Evento { get; set; }
        [ForeignKey("Indicador")]
        public virtual Spartane.Core.Domain.Indicadores_Laboratorio.Indicadores_Laboratorio Indicador_Indicadores_Laboratorio { get; set; }

    }


}

