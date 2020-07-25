using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSolicitud_de_Pago_de_Facturas_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_Registra_Name { get; set; }
        public int? Mes_Facturado { get; set; }
        public string Mes_Facturado_Nombre { get; set; }
        public DateTime? Fecha_inicio_del_periodo_facturado { get; set; }
        public DateTime? Fecha_fin_del_periodo_facturado { get; set; }
        public int? Archivo_XML { get; set; }
        public int? Archivo_PDF { get; set; }
        public int? Recibo_de_Solicitud_de_Pago { get; set; }
        public decimal? Total { get; set; }
        public int? Estatus { get; set; }
        public string Estatus_Descripcion { get; set; }
        public DateTime? Fecha_de_autorizacion { get; set; }
        public string Hora_de_autorizacion { get; set; }
        public int? Usuario_que_autoriza { get; set; }
        public string Usuario_que_autoriza_Name { get; set; }
        public int? Resultado_de_la_Revision { get; set; }
        public string Resultado_de_la_Revision_Nombre { get; set; }
        public string Observaciones { get; set; }
        public DateTime? Fecha_de_programacion { get; set; }
        public string Hora_de_programacion { get; set; }
        public int? Usuario_que_programa { get; set; }
        public string Usuario_que_programa_Name { get; set; }
        public DateTime? Fecha_programada_de_Pago { get; set; }
        public int? Estatus_de_Pago { get; set; }
        public string Estatus_de_Pago_Nombre { get; set; }
        public DateTime? Fecha_de_actualizacion { get; set; }
        public string Hora_de_actualizacion { get; set; }
        public int? Usuario_que_actualiza { get; set; }
        public string Usuario_que_actualiza_Name { get; set; }
        public DateTime? Fecha_de_Pago { get; set; }

    }
}
