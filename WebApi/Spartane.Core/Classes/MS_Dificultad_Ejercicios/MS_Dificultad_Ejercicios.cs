using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Ejercicios;
using Spartane.Core.Classes.Nivel_de_dificultad;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.MS_Dificultad_Ejercicios
{
    /// <summary>
    /// MS_Dificultad_Ejercicios table
    /// </summary>
    public class MS_Dificultad_Ejercicios: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Ejercicios { get; set; }
        public int? Nivel_de_Dificultad { get; set; }

        [ForeignKey("Folio_Ejercicios")]
        public virtual Spartane.Core.Classes.Ejercicios.Ejercicios Folio_Ejercicios_Ejercicios { get; set; }
        [ForeignKey("Nivel_de_Dificultad")]
        public virtual Spartane.Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad Nivel_de_Dificultad_Nivel_de_dificultad { get; set; }

    }
}

