using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Resultado_de_Autorizacion
{
    public interface IResultado_de_AutorizacionApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Resultado_de_Autorizacion.Resultado_de_Autorizacion>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Resultado_de_Autorizacion.Resultado_de_Autorizacion>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Resultado_de_Autorizacion.Resultado_de_Autorizacion> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Resultado_de_Autorizacion.Resultado_de_AutorizacionPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Resultado_de_AutorizacionInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Resultado_de_Autorizacion.Resultado_de_Autorizacion entity, Spartane.Core.Domain.User.GlobalData Resultado_de_AutorizacionInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Resultado_de_Autorizacion.Resultado_de_Autorizacion entity, Spartane.Core.Domain.User.GlobalData Resultado_de_AutorizacionInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Resultado_de_Autorizacion.Resultado_de_Autorizacion>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Resultado_de_Autorizacion.Resultado_de_Autorizacion>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Resultado_de_Autorizacion.Resultado_de_Autorizacion>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Resultado_de_Autorizacion.Resultado_de_AutorizacionPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Resultado_de_Autorizacion.Resultado_de_Autorizacion>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Resultado_de_Autorizacion.Resultado_de_Autorizacion_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Resultado_de_Autorizacion.Resultado_de_Autorizacion_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

