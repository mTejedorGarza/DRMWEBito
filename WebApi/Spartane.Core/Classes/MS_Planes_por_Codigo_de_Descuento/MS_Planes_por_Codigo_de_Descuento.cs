using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Codigos_de_Descuento;
using Spartane.Core.Classes.Planes_de_Suscripcion;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.MS_Planes_por_Codigo_de_Descuento
{
    /// <summary>
    /// MS_Planes_por_Codigo_de_Descuento table
    /// </summary>
    public class MS_Planes_por_Codigo_de_Descuento: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Codigos_de_Descuento { get; set; }
        public int? Planes_de_Suscripcion { get; set; }

        [ForeignKey("Folio_Codigos_de_Descuento")]
        public virtual Spartane.Core.Classes.Codigos_de_Descuento.Codigos_de_Descuento Folio_Codigos_de_Descuento_Codigos_de_Descuento { get; set; }
        [ForeignKey("Planes_de_Suscripcion")]
        public virtual Spartane.Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion Planes_de_Suscripcion_Planes_de_Suscripcion { get; set; }

    }
}

