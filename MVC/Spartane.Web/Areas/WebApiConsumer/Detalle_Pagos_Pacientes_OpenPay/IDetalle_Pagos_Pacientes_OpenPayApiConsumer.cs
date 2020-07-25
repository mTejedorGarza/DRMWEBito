using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Detalle_Pagos_Pacientes_OpenPay
{
    public interface IDetalle_Pagos_Pacientes_OpenPayApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPayPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Pagos_Pacientes_OpenPayInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay entity, Spartane.Core.Domain.User.GlobalData Detalle_Pagos_Pacientes_OpenPayInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay entity, Spartane.Core.Domain.User.GlobalData Detalle_Pagos_Pacientes_OpenPayInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPayPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

