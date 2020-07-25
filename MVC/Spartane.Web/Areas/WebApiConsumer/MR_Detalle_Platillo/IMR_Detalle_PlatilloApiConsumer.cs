using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.MR_Detalle_Platillo
{
    public interface IMR_Detalle_PlatilloApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.MR_Detalle_Platillo.MR_Detalle_PlatilloPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData MR_Detalle_PlatilloInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo entity, Spartane.Core.Domain.User.GlobalData MR_Detalle_PlatilloInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo entity, Spartane.Core.Domain.User.GlobalData MR_Detalle_PlatilloInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.MR_Detalle_Platillo.MR_Detalle_PlatilloPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

