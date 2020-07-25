using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Laboratorios_Clinicos : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Laboratorios_Clinicos_Folio { get; set; }
        public int Detalle_Laboratorios_Clinicos_Folio_Actividades_del_Evento { get; set; }
        public string Detalle_Laboratorios_Clinicos_Numero_de_Empleado_Titular { get; set; }
        public string Detalle_Laboratorios_Clinicos_Nombre_Completo { get; set; }
        public bool? Detalle_Laboratorios_Clinicos_Familiar_del_Empleado { get; set; }
        public string Detalle_Laboratorios_Clinicos_Numero_de_Empleado_Beneficiario { get; set; }
        public int? Detalle_Laboratorios_Clinicos_Indicador { get; set; }
        public string Detalle_Laboratorios_Clinicos_Indicador_Indicador { get; set; }
        public int? Detalle_Laboratorios_Clinicos_Resultado { get; set; }
        public string Detalle_Laboratorios_Clinicos_Unidad { get; set; }
        public string Detalle_Laboratorios_Clinicos_Intervalo_de_referencia { get; set; }
        public DateTime? Detalle_Laboratorios_Clinicos_Fecha_de_Resultado { get; set; }
        public string Detalle_Laboratorios_Clinicos_Estatus_Indicador { get; set; }

    }
}
