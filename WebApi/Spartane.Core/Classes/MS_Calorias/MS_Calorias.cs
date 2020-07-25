using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Platillos;
using Spartane.Core.Classes.Calorias;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.MS_Calorias
{
    /// <summary>
    /// MS_Calorias table
    /// </summary>
    public class MS_Calorias: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Platillo { get; set; }
        public int? Calorias { get; set; }

        [ForeignKey("Folio_Platillo")]
        public virtual Spartane.Core.Classes.Platillos.Platillos Folio_Platillo_Platillos { get; set; }
        [ForeignKey("Calorias")]
        public virtual Spartane.Core.Classes.Calorias.Calorias Calorias_Calorias { get; set; }

    }
}

