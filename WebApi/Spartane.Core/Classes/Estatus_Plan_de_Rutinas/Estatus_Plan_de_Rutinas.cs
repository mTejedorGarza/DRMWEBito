using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Estatus_Plan_de_Rutinas
{
    /// <summary>
    /// Estatus_Plan_de_Rutinas table
    /// </summary>
    public class Estatus_Plan_de_Rutinas: BaseEntity
    {
        public int Folio { get; set; }
        public string Descripcion { get; set; }


    }
}

