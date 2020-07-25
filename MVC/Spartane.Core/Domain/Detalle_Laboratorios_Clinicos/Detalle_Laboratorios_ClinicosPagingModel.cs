using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Detalle_Laboratorios_Clinicos
{
    public class Detalle_Laboratorios_ClinicosPagingModel
    {
        public List<Spartane.Core.Domain.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos> Detalle_Laboratorios_Clinicoss { set; get; }
        public int RowCount { set; get; }
    }
}
