using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Nombre_del_campo_en_MS
{
    public interface INombre_del_campo_en_MSApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MSPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Nombre_del_campo_en_MSInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS entity, Spartane.Core.Domain.User.GlobalData Nombre_del_campo_en_MSInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS entity, Spartane.Core.Domain.User.GlobalData Nombre_del_campo_en_MSInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MSPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

