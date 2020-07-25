using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Metodos_de_Pago_Paciente;
using Spartane.Core.Classes.Tipo_de_Tarjeta;
using Spartane.Core.Classes.Estatus;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.MR_Tarjetas
{
    /// <summary>
    /// MR_Tarjetas table
    /// </summary>
    public class MR_Tarjetas: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Metodos_de_Pago_Paciente { get; set; }
        public int? Tipo_de_Tarjeta { get; set; }
        public string Numero_de_Tarjeta { get; set; }
        public string Nombre_del_Titular { get; set; }
        public int? Ano_de_vigencia { get; set; }
        public int? Mes_de_vigencia { get; set; }
        public string Alias_de_la_Tarjeta { get; set; }
        public int? Estatus { get; set; }

        [ForeignKey("Folio_Metodos_de_Pago_Paciente")]
        public virtual Spartane.Core.Classes.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente Folio_Metodos_de_Pago_Paciente_Metodos_de_Pago_Paciente { get; set; }
        [ForeignKey("Tipo_de_Tarjeta")]
        public virtual Spartane.Core.Classes.Tipo_de_Tarjeta.Tipo_de_Tarjeta Tipo_de_Tarjeta_Tipo_de_Tarjeta { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Classes.Estatus.Estatus Estatus_Estatus { get; set; }

    }
}

