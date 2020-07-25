using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Laboratorios_Clinicos_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Actividades_del_Evento { get; set; }
        public string Numero_de_Empleado_Titular { get; set; }
        public string Nombre_Completo { get; set; }
        public bool? Familiar_del_Empleado { get; set; }
        public string Numero_de_Empleado_Beneficiario { get; set; }
        public int? Indicador { get; set; }
        public string Indicador_Indicador { get; set; }
        public int? Resultado { get; set; }
        public string Unidad { get; set; }
        public string Intervalo_de_referencia { get; set; }
        public DateTime? Fecha_de_Resultado { get; set; }
        public string Estatus_Indicador { get; set; }

    }
}
