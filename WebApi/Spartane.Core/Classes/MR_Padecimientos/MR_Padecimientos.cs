using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Rangos_Pediatria_por_Platillos;
using Spartane.Core.Classes.Padecimientos;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.MR_Padecimientos
{
    /// <summary>
    /// MR_Padecimientos table
    /// </summary>
    public class MR_Padecimientos: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Rangos_Pediatria_por_Platillos { get; set; }
        public int? Padecimiento { get; set; }

        [ForeignKey("Folio_Rangos_Pediatria_por_Platillos")]
        public virtual Spartane.Core.Classes.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos Folio_Rangos_Pediatria_por_Platillos_Rangos_Pediatria_por_Platillos { get; set; }
        [ForeignKey("Padecimiento")]
        public virtual Spartane.Core.Classes.Padecimientos.Padecimientos Padecimiento_Padecimientos { get; set; }

    }
}

