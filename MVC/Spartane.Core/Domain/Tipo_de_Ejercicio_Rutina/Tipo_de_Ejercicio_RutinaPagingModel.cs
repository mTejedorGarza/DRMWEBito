using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Tipo_de_Ejercicio_Rutina
{
    public class Tipo_de_Ejercicio_RutinaPagingModel
    {
        public List<Spartane.Core.Domain.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina> Tipo_de_Ejercicio_Rutinas { set; get; }
        public int RowCount { set; get; }
    }
}
