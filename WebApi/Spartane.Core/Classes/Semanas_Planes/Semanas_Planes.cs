using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Semanas_Planes
{
    /// <summary>
    /// Semanas_Planes table
    /// </summary>
    public class Semanas_Planes: BaseEntity
    {
        public int Folio { get; set; }
        public string Semana { get; set; }
        public int? Semanas_del_mes { get; set; }


    }
}

