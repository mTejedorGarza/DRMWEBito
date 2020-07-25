using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Codigos_de_Descuento;
using Spartane.Core.Domain.Tipo_Paciente;
using Spartane.Core.Domain.Spartan_User;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.MR_Referenciados_Codigo_de_Descuento
{
    /// <summary>
    /// MR_Referenciados_Codigo_de_Descuento table
    /// </summary>
    public class MR_Referenciados_Codigo_de_Descuento: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Codigos_de_Descuento { get; set; }
        public int? Tipo_de_usuario { get; set; }
        public int? Usuario { get; set; }
        public DateTime? Fecha_de_aplicacion { get; set; }
        public decimal? Descuento_Total { get; set; }

        [ForeignKey("Folio_Codigos_de_Descuento")]
        public virtual Spartane.Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento Folio_Codigos_de_Descuento_Codigos_de_Descuento { get; set; }
        [ForeignKey("Tipo_de_usuario")]
        public virtual Spartane.Core.Domain.Tipo_Paciente.Tipo_Paciente Tipo_de_usuario_Tipo_Paciente { get; set; }
        [ForeignKey("Usuario")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_Spartan_User { get; set; }

    }
	
	public class MR_Referenciados_Codigo_de_Descuento_Datos_Generales
    {
                public int Folio { get; set; }
        public int? Folio_Codigos_de_Descuento { get; set; }
        public int? Tipo_de_usuario { get; set; }
        public int? Usuario { get; set; }
        public DateTime? Fecha_de_aplicacion { get; set; }
        public decimal? Descuento_Total { get; set; }

		        [ForeignKey("Folio_Codigos_de_Descuento")]
        public virtual Spartane.Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento Folio_Codigos_de_Descuento_Codigos_de_Descuento { get; set; }
        [ForeignKey("Tipo_de_usuario")]
        public virtual Spartane.Core.Domain.Tipo_Paciente.Tipo_Paciente Tipo_de_usuario_Tipo_Paciente { get; set; }
        [ForeignKey("Usuario")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_Spartan_User { get; set; }

    }


}

