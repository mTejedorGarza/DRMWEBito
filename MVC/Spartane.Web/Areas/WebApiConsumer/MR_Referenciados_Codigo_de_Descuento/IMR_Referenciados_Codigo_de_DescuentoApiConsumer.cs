using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.MR_Referenciados_Codigo_de_Descuento
{
    public interface IMR_Referenciados_Codigo_de_DescuentoApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_DescuentoPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData MR_Referenciados_Codigo_de_DescuentoInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento entity, Spartane.Core.Domain.User.GlobalData MR_Referenciados_Codigo_de_DescuentoInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento entity, Spartane.Core.Domain.User.GlobalData MR_Referenciados_Codigo_de_DescuentoInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_DescuentoPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

