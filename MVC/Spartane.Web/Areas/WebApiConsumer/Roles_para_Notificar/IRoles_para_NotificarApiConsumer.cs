using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Roles_para_Notificar
{
    public interface IRoles_para_NotificarApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Roles_para_Notificar.Roles_para_Notificar>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Roles_para_Notificar.Roles_para_Notificar>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Roles_para_Notificar.Roles_para_Notificar> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Roles_para_Notificar.Roles_para_NotificarPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Roles_para_NotificarInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Roles_para_Notificar.Roles_para_Notificar entity, Spartane.Core.Domain.User.GlobalData Roles_para_NotificarInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Roles_para_Notificar.Roles_para_Notificar entity, Spartane.Core.Domain.User.GlobalData Roles_para_NotificarInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Roles_para_Notificar.Roles_para_Notificar>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Roles_para_Notificar.Roles_para_Notificar>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Roles_para_Notificar.Roles_para_Notificar>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Roles_para_Notificar.Roles_para_NotificarPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Roles_para_Notificar.Roles_para_Notificar>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Roles_para_Notificar.Roles_para_Notificar_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Roles_para_Notificar.Roles_para_Notificar_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

