using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Pagos_Pacientes_OpenPay : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Pagos_Pacientes_OpenPay_Folio { get; set; }
        public int Detalle_Pagos_Pacientes_OpenPay_FolioPacientes { get; set; }
        public int? Detalle_Pagos_Pacientes_OpenPay_Usuario_que_Registra { get; set; }
        public string Detalle_Pagos_Pacientes_OpenPay_Usuario_que_Registra_Name { get; set; }
        public DateTime? Detalle_Pagos_Pacientes_OpenPay_Fecha_de_Pago { get; set; }
        public string Detalle_Pagos_Pacientes_OpenPay_Hora_de_Pago { get; set; }
        public string Detalle_Pagos_Pacientes_OpenPay_TokenID { get; set; }
        public decimal? Detalle_Pagos_Pacientes_OpenPay_Importe { get; set; }
        public string Detalle_Pagos_Pacientes_OpenPay_Concepto { get; set; }
        public int? Detalle_Pagos_Pacientes_OpenPay_Forma_de_pago { get; set; }
        public string Detalle_Pagos_Pacientes_OpenPay_Forma_de_pago_Nombre { get; set; }
        public string Detalle_Pagos_Pacientes_OpenPay_Autorizacion { get; set; }
        public string Detalle_Pagos_Pacientes_OpenPay_Nombre { get; set; }
        public string Detalle_Pagos_Pacientes_OpenPay_Apellidos { get; set; }
        public string Detalle_Pagos_Pacientes_OpenPay_Telefono { get; set; }
        public string Detalle_Pagos_Pacientes_OpenPay_Email { get; set; }
        public string Detalle_Pagos_Pacientes_OpenPay_DeviceID { get; set; }
        public bool? Detalle_Pagos_Pacientes_OpenPay_UsaPuntos { get; set; }
        public string Detalle_Pagos_Pacientes_OpenPay_PuntosID { get; set; }
        public int? Detalle_Pagos_Pacientes_OpenPay_Estatus { get; set; }
        public string Detalle_Pagos_Pacientes_OpenPay_Estatus_Descripcion { get; set; }

    }
}
