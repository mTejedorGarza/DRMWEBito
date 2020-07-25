using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSolicitud_de_Pago_de_Facturas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Solicitud_de_Pago_de_Facturas_Folio { get; set; }
        public DateTime? Solicitud_de_Pago_de_Facturas_Fecha_de_Registro { get; set; }
        public string Solicitud_de_Pago_de_Facturas_Hora_de_Registro { get; set; }
        public int? Solicitud_de_Pago_de_Facturas_Usuario_que_Registra { get; set; }
        public string Solicitud_de_Pago_de_Facturas_Usuario_que_Registra_Name { get; set; }
        public int? Solicitud_de_Pago_de_Facturas_Mes_Facturado { get; set; }
        public string Solicitud_de_Pago_de_Facturas_Mes_Facturado_Nombre { get; set; }
        public DateTime? Solicitud_de_Pago_de_Facturas_Fecha_inicio_del_periodo_facturado { get; set; }
        public DateTime? Solicitud_de_Pago_de_Facturas_Fecha_fin_del_periodo_facturado { get; set; }
        public int? Solicitud_de_Pago_de_Facturas_Archivo_XML { get; set; }
        public string Solicitud_de_Pago_de_Facturas_Archivo_XML_Nombre { get; set; }
        public int? Solicitud_de_Pago_de_Facturas_Archivo_PDF { get; set; }
        public string Solicitud_de_Pago_de_Facturas_Archivo_PDF_Nombre { get; set; }
        public int? Solicitud_de_Pago_de_Facturas_Recibo_de_Solicitud_de_Pago { get; set; }
        public string Solicitud_de_Pago_de_Facturas_Recibo_de_Solicitud_de_Pago_Nombre { get; set; }
        public decimal? Solicitud_de_Pago_de_Facturas_Total { get; set; }
        public int? Solicitud_de_Pago_de_Facturas_Estatus { get; set; }
        public string Solicitud_de_Pago_de_Facturas_Estatus_Descripcion { get; set; }
        public DateTime? Solicitud_de_Pago_de_Facturas_Fecha_de_autorizacion { get; set; }
        public string Solicitud_de_Pago_de_Facturas_Hora_de_autorizacion { get; set; }
        public int? Solicitud_de_Pago_de_Facturas_Usuario_que_autoriza { get; set; }
        public string Solicitud_de_Pago_de_Facturas_Usuario_que_autoriza_Name { get; set; }
        public int? Solicitud_de_Pago_de_Facturas_Resultado_de_la_Revision { get; set; }
        public string Solicitud_de_Pago_de_Facturas_Resultado_de_la_Revision_Nombre { get; set; }
        public string Solicitud_de_Pago_de_Facturas_Observaciones { get; set; }
        public DateTime? Solicitud_de_Pago_de_Facturas_Fecha_de_programacion { get; set; }
        public string Solicitud_de_Pago_de_Facturas_Hora_de_programacion { get; set; }
        public int? Solicitud_de_Pago_de_Facturas_Usuario_que_programa { get; set; }
        public string Solicitud_de_Pago_de_Facturas_Usuario_que_programa_Name { get; set; }
        public DateTime? Solicitud_de_Pago_de_Facturas_Fecha_programada_de_Pago { get; set; }
        public int? Solicitud_de_Pago_de_Facturas_Estatus_de_Pago { get; set; }
        public string Solicitud_de_Pago_de_Facturas_Estatus_de_Pago_Nombre { get; set; }
        public DateTime? Solicitud_de_Pago_de_Facturas_Fecha_de_actualizacion { get; set; }
        public string Solicitud_de_Pago_de_Facturas_Hora_de_actualizacion { get; set; }
        public int? Solicitud_de_Pago_de_Facturas_Usuario_que_actualiza { get; set; }
        public string Solicitud_de_Pago_de_Facturas_Usuario_que_actualiza_Name { get; set; }
        public DateTime? Solicitud_de_Pago_de_Facturas_Fecha_de_Pago { get; set; }

    }
}
