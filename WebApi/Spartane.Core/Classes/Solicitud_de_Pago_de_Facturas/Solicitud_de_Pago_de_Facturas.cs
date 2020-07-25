using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_User;
using Spartane.Core.Classes.Meses;
using Spartane.Core.Classes.Spartane_File;
using Spartane.Core.Classes.Spartane_File;
using Spartane.Core.Classes.Spartane_File;
using Spartane.Core.Classes.Estatus_Facturas;
using Spartane.Core.Classes.Spartan_User;
using Spartane.Core.Classes.Resultados_de_Revision;
using Spartane.Core.Classes.Spartan_User;
using Spartane.Core.Classes.Estatus_de_Pago_de_Facturas;
using Spartane.Core.Classes.Spartan_User;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas
{
    /// <summary>
    /// Solicitud_de_Pago_de_Facturas table
    /// </summary>
    public class Solicitud_de_Pago_de_Facturas: BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public int? Mes_Facturado { get; set; }
        public DateTime? Fecha_inicio_del_periodo_facturado { get; set; }
        public DateTime? Fecha_fin_del_periodo_facturado { get; set; }
        public int? Archivo_XML { get; set; }
        //public string Archivo_XML_URL { get; set; }
        public int? Archivo_PDF { get; set; }
        //public string Archivo_PDF_URL { get; set; }
        public int? Recibo_de_Solicitud_de_Pago { get; set; }
        //public string Recibo_de_Solicitud_de_Pago_URL { get; set; }
        public decimal? Total { get; set; }
        public int? Estatus { get; set; }
        public DateTime? Fecha_de_autorizacion { get; set; }
        public string Hora_de_autorizacion { get; set; }
        public int? Usuario_que_autoriza { get; set; }
        public int? Resultado_de_la_Revision { get; set; }
        public string Observaciones { get; set; }
        public DateTime? Fecha_de_programacion { get; set; }
        public string Hora_de_programacion { get; set; }
        public int? Usuario_que_programa { get; set; }
        public DateTime? Fecha_programada_de_Pago { get; set; }
        public int? Estatus_de_Pago { get; set; }
        public DateTime? Fecha_de_actualizacion { get; set; }
        public string Hora_de_actualizacion { get; set; }
        public int? Usuario_que_actualiza { get; set; }
        public DateTime? Fecha_de_Pago { get; set; }

        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Classes.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Mes_Facturado")]
        public virtual Spartane.Core.Classes.Meses.Meses Mes_Facturado_Meses { get; set; }
        [ForeignKey("Archivo_XML")]
        public virtual Spartane.Core.Classes.Spartane_File.Spartane_File Archivo_XML_Spartane_File { get; set; }
        [ForeignKey("Archivo_PDF")]
        public virtual Spartane.Core.Classes.Spartane_File.Spartane_File Archivo_PDF_Spartane_File { get; set; }
        [ForeignKey("Recibo_de_Solicitud_de_Pago")]
        public virtual Spartane.Core.Classes.Spartane_File.Spartane_File Recibo_de_Solicitud_de_Pago_Spartane_File { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Classes.Estatus_Facturas.Estatus_Facturas Estatus_Estatus_Facturas { get; set; }
        [ForeignKey("Usuario_que_autoriza")]
        public virtual Spartane.Core.Classes.Spartan_User.Spartan_User Usuario_que_autoriza_Spartan_User { get; set; }
        [ForeignKey("Resultado_de_la_Revision")]
        public virtual Spartane.Core.Classes.Resultados_de_Revision.Resultados_de_Revision Resultado_de_la_Revision_Resultados_de_Revision { get; set; }
        [ForeignKey("Usuario_que_programa")]
        public virtual Spartane.Core.Classes.Spartan_User.Spartan_User Usuario_que_programa_Spartan_User { get; set; }
        [ForeignKey("Estatus_de_Pago")]
        public virtual Spartane.Core.Classes.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_Facturas Estatus_de_Pago_Estatus_de_Pago_de_Facturas { get; set; }
        [ForeignKey("Usuario_que_actualiza")]
        public virtual Spartane.Core.Classes.Spartan_User.Spartan_User Usuario_que_actualiza_Spartan_User { get; set; }

    }
}

