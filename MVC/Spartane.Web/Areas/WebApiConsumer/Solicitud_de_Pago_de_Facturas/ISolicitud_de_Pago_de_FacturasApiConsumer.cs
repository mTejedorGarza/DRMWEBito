using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Solicitud_de_Pago_de_Facturas
{
    public interface ISolicitud_de_Pago_de_FacturasApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_FacturasPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Solicitud_de_Pago_de_FacturasInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas entity, Spartane.Core.Domain.User.GlobalData Solicitud_de_Pago_de_FacturasInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas entity, Spartane.Core.Domain.User.GlobalData Solicitud_de_Pago_de_FacturasInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_FacturasPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas_Datos_Generales> Get_Datos_Generales(string Key);

		ApiResponse<int> Update_Autorizacion(Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas_Autorizacion entity);
		ApiResponse<Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas_Autorizacion> Get_Autorizacion(string Key);

		ApiResponse<int> Update_Programacion_de_Pago(Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas_Programacion_de_Pago entity);
		ApiResponse<Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas_Programacion_de_Pago> Get_Programacion_de_Pago(string Key);

		ApiResponse<int> Update_Pago(Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas_Pago entity);
		ApiResponse<Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas_Pago> Get_Pago(string Key);


    }
}

