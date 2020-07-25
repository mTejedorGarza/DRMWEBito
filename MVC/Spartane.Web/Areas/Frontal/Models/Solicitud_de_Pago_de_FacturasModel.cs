using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Solicitud_de_Pago_de_FacturasModel
    {
        [Required]
        public int Folio { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public int? Mes_Facturado { get; set; }
        public string Mes_FacturadoNombre { get; set; }
        public string Fecha_inicio_del_periodo_facturado { get; set; }
        public string Fecha_fin_del_periodo_facturado { get; set; }
        public int? Archivo_XML { get; set; }
        public HttpPostedFileBase Archivo_XMLFile { set; get; }
        public int Archivo_XMLRemoveAttachment { set; get; }
        public int? Archivo_PDF { get; set; }
        public HttpPostedFileBase Archivo_PDFFile { set; get; }
        public int Archivo_PDFRemoveAttachment { set; get; }
        public int? Recibo_de_Solicitud_de_Pago { get; set; }
        public HttpPostedFileBase Recibo_de_Solicitud_de_PagoFile { set; get; }
        public int Recibo_de_Solicitud_de_PagoRemoveAttachment { set; get; }
        [Range(0.00, 999999.99)]
        public decimal? Total { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }
        public string Fecha_de_autorizacion { get; set; }
        public string Hora_de_autorizacion { get; set; }
        public int? Usuario_que_autoriza { get; set; }
        public string Usuario_que_autorizaName { get; set; }
        public int? Resultado_de_la_Revision { get; set; }
        public string Resultado_de_la_RevisionNombre { get; set; }
        public string Observaciones { get; set; }
        public string Fecha_de_programacion { get; set; }
        public string Hora_de_programacion { get; set; }
        public int? Usuario_que_programa { get; set; }
        public string Usuario_que_programaName { get; set; }
        public string Fecha_programada_de_Pago { get; set; }
        public int? Estatus_de_Pago { get; set; }
        public string Estatus_de_PagoNombre { get; set; }
        public string Fecha_de_actualizacion { get; set; }
        public string Hora_de_actualizacion { get; set; }
        public int? Usuario_que_actualiza { get; set; }
        public string Usuario_que_actualizaName { get; set; }
        public string Fecha_de_Pago { get; set; }

    }
	
	public class Solicitud_de_Pago_de_Facturas_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public int? Mes_Facturado { get; set; }
        public string Mes_FacturadoNombre { get; set; }
        public string Fecha_inicio_del_periodo_facturado { get; set; }
        public string Fecha_fin_del_periodo_facturado { get; set; }
        public int? Archivo_XML { get; set; }
        public HttpPostedFileBase Archivo_XMLFile { set; get; }
        public int Archivo_XMLRemoveAttachment { set; get; }
        public int? Archivo_PDF { get; set; }
        public HttpPostedFileBase Archivo_PDFFile { set; get; }
        public int Archivo_PDFRemoveAttachment { set; get; }
        public int? Recibo_de_Solicitud_de_Pago { get; set; }
        public HttpPostedFileBase Recibo_de_Solicitud_de_PagoFile { set; get; }
        public int Recibo_de_Solicitud_de_PagoRemoveAttachment { set; get; }
        [Range(0.00, 999999.99)]
        public decimal? Total { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }

	public class Solicitud_de_Pago_de_Facturas_AutorizacionModel
    {
        [Required]
        public int Folio { get; set; }
        public string Fecha_de_autorizacion { get; set; }
        public string Hora_de_autorizacion { get; set; }
        public int? Usuario_que_autoriza { get; set; }
        public string Usuario_que_autorizaName { get; set; }
        public int? Resultado_de_la_Revision { get; set; }
        public string Resultado_de_la_RevisionNombre { get; set; }
        public string Observaciones { get; set; }

    }

	public class Solicitud_de_Pago_de_Facturas_Programacion_de_PagoModel
    {
        [Required]
        public int Folio { get; set; }
        public string Fecha_de_programacion { get; set; }
        public string Hora_de_programacion { get; set; }
        public int? Usuario_que_programa { get; set; }
        public string Usuario_que_programaName { get; set; }
        public string Fecha_programada_de_Pago { get; set; }
        public int? Estatus_de_Pago { get; set; }
        public string Estatus_de_PagoNombre { get; set; }

    }

	public class Solicitud_de_Pago_de_Facturas_PagoModel
    {
        [Required]
        public int Folio { get; set; }
        public string Fecha_de_actualizacion { get; set; }
        public string Hora_de_actualizacion { get; set; }
        public int? Usuario_que_actualiza { get; set; }
        public string Usuario_que_actualizaName { get; set; }
        public string Fecha_de_Pago { get; set; }

    }


}

