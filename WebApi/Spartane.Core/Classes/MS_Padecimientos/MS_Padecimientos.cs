using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Platillos;
using Spartane.Core.Classes.Categorias_de_platillos;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.MS_Padecimientos
{
    /// <summary>
    /// MS_Padecimientos table
    /// </summary>
    public class MS_Padecimientos: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Platillos { get; set; }
        public int? Categoria { get; set; }

        [ForeignKey("Folio_Platillos")]
        public virtual Spartane.Core.Classes.Platillos.Platillos Folio_Platillos_Platillos { get; set; }
        [ForeignKey("Categoria")]
        public virtual Spartane.Core.Classes.Categorias_de_platillos.Categorias_de_platillos Categoria_Categorias_de_platillos { get; set; }

    }
}

