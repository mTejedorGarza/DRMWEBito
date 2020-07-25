using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Pagos_Pacientes_OpenPay_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int FolioPacientes { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_Registra_Name { get; set; }
        public DateTime? Fecha_de_Pago { get; set; }
        public string Hora_de_Pago { get; set; }
        public string TokenID { get; set; }
        public decimal? Importe { get; set; }
        public string Concepto { get; set; }
        public int? Forma_de_pago { get; set; }
        public string Forma_de_pago_Nombre { get; set; }
        public string Autorizacion { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string DeviceID { get; set; }
        public bool? UsaPuntos { get; set; }
        public string PuntosID { get; set; }
        public int? Estatus { get; set; }
        public string Estatus_Descripcion { get; set; }

    }
}
