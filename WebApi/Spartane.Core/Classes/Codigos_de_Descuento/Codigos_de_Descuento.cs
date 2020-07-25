using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_User;
using Spartane.Core.Classes.Tipos_de_Vendedor;
using Spartane.Core.Classes.Spartan_User;
using Spartane.Core.Classes.Tipos_de_Descuento;
using Spartane.Core.Classes.Estatus_de_Codigos_de_Descuento;
using Spartane.Core.Classes.Spartan_User;
using Spartane.Core.Classes.Resultado_de_Autorizacion;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Codigos_de_Descuento
{
    /// <summary>
    /// Codigos_de_Descuento table
    /// </summary>
    public class Codigos_de_Descuento: BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public int? Tipo_de_Vendedor { get; set; }
        public int? Vendedor { get; set; }
        public int? Tipo_de_Descuento { get; set; }
        public decimal? Descuento { get; set; }
        public string Texto_promocional { get; set; }
        public DateTime? Fecha_inicio_vigencia { get; set; }
        public DateTime? Fecha_fin_vigencia { get; set; }
        public int? Cantidad_maxima_de_referenciados { get; set; }
        public string Codigo_de_descuento { get; set; }
        public int? Estatus { get; set; }
        public DateTime? Fecha_de_autorizacion { get; set; }
        public string Hora_de_autorizacion { get; set; }
        public int? Usuario_que_autoriza { get; set; }
        public string Observaciones { get; set; }
        public int? Resultado { get; set; }

        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Classes.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Tipo_de_Vendedor")]
        public virtual Spartane.Core.Classes.Tipos_de_Vendedor.Tipos_de_Vendedor Tipo_de_Vendedor_Tipos_de_Vendedor { get; set; }
        [ForeignKey("Vendedor")]
        public virtual Spartane.Core.Classes.Spartan_User.Spartan_User Vendedor_Spartan_User { get; set; }
        [ForeignKey("Tipo_de_Descuento")]
        public virtual Spartane.Core.Classes.Tipos_de_Descuento.Tipos_de_Descuento Tipo_de_Descuento_Tipos_de_Descuento { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Classes.Estatus_de_Codigos_de_Descuento.Estatus_de_Codigos_de_Descuento Estatus_Estatus_de_Codigos_de_Descuento { get; set; }
        [ForeignKey("Usuario_que_autoriza")]
        public virtual Spartane.Core.Classes.Spartan_User.Spartan_User Usuario_que_autoriza_Spartan_User { get; set; }
        [ForeignKey("Resultado")]
        public virtual Spartane.Core.Classes.Resultado_de_Autorizacion.Resultado_de_Autorizacion Resultado_Resultado_de_Autorizacion { get; set; }

    }
}

