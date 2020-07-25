using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Pagos_Pacientes_OpenPayGridModel
    {
        public int Folio { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public string Fecha_de_Pago { get; set; }
        public string Hora_de_Pago { get; set; }
        public string TokenID { get; set; }
        public decimal? Importe { get; set; }
        public string Concepto { get; set; }
        public int? Forma_de_pago { get; set; }
        public string Forma_de_pagoNombre { get; set; }
        public string Autorizacion { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string DeviceID { get; set; }
        public bool? UsaPuntos { get; set; }
        public string PuntosID { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }
        
    }
}

