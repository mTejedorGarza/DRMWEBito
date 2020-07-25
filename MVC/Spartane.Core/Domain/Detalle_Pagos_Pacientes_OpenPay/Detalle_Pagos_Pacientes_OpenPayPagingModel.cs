using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay
{
    public class Detalle_Pagos_Pacientes_OpenPayPagingModel
    {
        public List<Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay> Detalle_Pagos_Pacientes_OpenPays { set; get; }
        public int RowCount { set; get; }
    }
}
