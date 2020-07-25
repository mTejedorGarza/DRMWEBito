using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Pacientes;
using Spartane.Core.Classes.Spartan_User;
using Spartane.Core.Classes.Formas_de_Pago;
using Spartane.Core.Classes.Estatus_de_Pago;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Detalle_Pagos_Pacientes_OpenPay
{
    /// <summary>
    /// Detalle_Pagos_Pacientes_OpenPay table
    /// </summary>
    public class Detalle_Pagos_Pacientes_OpenPay: BaseEntity
    {
        public int Folio { get; set; }
        public int? FolioPacientes { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public DateTime? Fecha_de_Pago { get; set; }
        public string Hora_de_Pago { get; set; }
        public string TokenID { get; set; }
        public decimal? Importe { get; set; }
        public string Concepto { get; set; }
        public int? Forma_de_pago { get; set; }
        public string Autorizacion { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string DeviceID { get; set; }
        public bool? UsaPuntos { get; set; }
        public string PuntosID { get; set; }
        public int? Estatus { get; set; }

        [ForeignKey("FolioPacientes")]
        public virtual Spartane.Core.Classes.Pacientes.Pacientes FolioPacientes_Pacientes { get; set; }
        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Classes.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Forma_de_pago")]
        public virtual Spartane.Core.Classes.Formas_de_Pago.Formas_de_Pago Forma_de_pago_Formas_de_Pago { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Classes.Estatus_de_Pago.Estatus_de_Pago Estatus_Estatus_de_Pago { get; set; }

    }
}

