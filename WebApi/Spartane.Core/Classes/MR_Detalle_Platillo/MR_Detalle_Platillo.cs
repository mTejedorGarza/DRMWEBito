using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Platillos;
using Spartane.Core.Classes.Ingredientes;
using Spartane.Core.Classes.Unidades_de_Medida;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.MR_Detalle_Platillo
{
    /// <summary>
    /// MR_Detalle_Platillo table
    /// </summary>
    public class MR_Detalle_Platillo: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Platillos { get; set; }
        public int? Ingrediente { get; set; }
        public string Cantidad { get; set; }
        public decimal? Cantidad_en_Fraccion { get; set; }
        public int? Unidad { get; set; }
        public string Cantidad_a_mostrar { get; set; }
        public string Ingrediente_a_mostrar { get; set; }

        [ForeignKey("Folio_Platillos")]
        public virtual Spartane.Core.Classes.Platillos.Platillos Folio_Platillos_Platillos { get; set; }
        [ForeignKey("Ingrediente")]
        public virtual Spartane.Core.Classes.Ingredientes.Ingredientes Ingrediente_Ingredientes { get; set; }
        [ForeignKey("Unidad")]
        public virtual Spartane.Core.Classes.Unidades_de_Medida.Unidades_de_Medida Unidad_Unidades_de_Medida { get; set; }

    }
}

