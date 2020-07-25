using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Planes_de_Suscripcion;
using Spartane.Core.Classes.Tipo_Paciente;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.MS_Beneficiarios_Suscripcion
{
    /// <summary>
    /// MS_Beneficiarios_Suscripcion table
    /// </summary>
    public class MS_Beneficiarios_Suscripcion: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Planes_de_Suscripcion { get; set; }
        public int? Beneficiario { get; set; }

        [ForeignKey("Folio_Planes_de_Suscripcion")]
        public virtual Spartane.Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion Folio_Planes_de_Suscripcion_Planes_de_Suscripcion { get; set; }
        [ForeignKey("Beneficiario")]
        public virtual Spartane.Core.Classes.Tipo_Paciente.Tipo_Paciente Beneficiario_Tipo_Paciente { get; set; }

    }
}

