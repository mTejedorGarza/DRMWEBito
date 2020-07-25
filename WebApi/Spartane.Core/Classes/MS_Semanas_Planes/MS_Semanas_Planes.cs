﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Planes_de_Suscripcion;
using Spartane.Core.Classes.Semanas_Planes;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.MS_Semanas_Planes
{
    /// <summary>
    /// MS_Semanas_Planes table
    /// </summary>
    public class MS_Semanas_Planes: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Planes_de_Suscripcion { get; set; }
        public int? Semanas { get; set; }

        [ForeignKey("Folio_Planes_de_Suscripcion")]
        public virtual Spartane.Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion Folio_Planes_de_Suscripcion_Planes_de_Suscripcion { get; set; }
        [ForeignKey("Semanas")]
        public virtual Spartane.Core.Classes.Semanas_Planes.Semanas_Planes Semanas_Semanas_Planes { get; set; }

    }
}

