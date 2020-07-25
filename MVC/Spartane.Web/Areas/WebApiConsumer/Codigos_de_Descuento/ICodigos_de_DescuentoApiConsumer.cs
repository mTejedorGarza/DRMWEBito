using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Codigos_de_Descuento
{
    public interface ICodigos_de_DescuentoApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Codigos_de_Descuento.Codigos_de_DescuentoPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Codigos_de_DescuentoInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento entity, Spartane.Core.Domain.User.GlobalData Codigos_de_DescuentoInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento entity, Spartane.Core.Domain.User.GlobalData Codigos_de_DescuentoInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Codigos_de_Descuento.Codigos_de_DescuentoPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento_Datos_Generales> Get_Datos_Generales(string Key);

		ApiResponse<int> Update_Autorizacion(Spartane.Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento_Autorizacion entity);
		ApiResponse<Spartane.Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento_Autorizacion> Get_Autorizacion(string Key);

		ApiResponse<int> Update_Referenciados(Spartane.Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento_Referenciados entity);
		ApiResponse<Spartane.Core.Domain.Codigos_de_Descuento.Codigos_de_Descuento_Referenciados> Get_Referenciados(string Key);


    }
}

