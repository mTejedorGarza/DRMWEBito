using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Platillos;
using Spartane.Core.Classes.Dificultad_de_platillos;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.MS_Dificultad_Platillos
{
    /// <summary>
    /// MS_Dificultad_Platillos table
    /// </summary>
    public class MS_Dificultad_Platillos: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Platillos { get; set; }
        public int? Dificultad { get; set; }

        [ForeignKey("Folio_Platillos")]
        public virtual Spartane.Core.Classes.Platillos.Platillos Folio_Platillos_Platillos { get; set; }
        [ForeignKey("Dificultad")]
        public virtual Spartane.Core.Classes.Dificultad_de_platillos.Dificultad_de_platillos Dificultad_Dificultad_de_platillos { get; set; }

    }
}

