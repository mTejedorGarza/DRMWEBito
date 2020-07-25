using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.MS_Dificultad_Platillos
{
    public interface IMS_Dificultad_PlatillosApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.MS_Dificultad_Platillos.MS_Dificultad_Platillos>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.MS_Dificultad_Platillos.MS_Dificultad_Platillos>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.MS_Dificultad_Platillos.MS_Dificultad_Platillos> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.MS_Dificultad_Platillos.MS_Dificultad_PlatillosPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData MS_Dificultad_PlatillosInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.MS_Dificultad_Platillos.MS_Dificultad_Platillos entity, Spartane.Core.Domain.User.GlobalData MS_Dificultad_PlatillosInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.MS_Dificultad_Platillos.MS_Dificultad_Platillos entity, Spartane.Core.Domain.User.GlobalData MS_Dificultad_PlatillosInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.MS_Dificultad_Platillos.MS_Dificultad_Platillos>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.MS_Dificultad_Platillos.MS_Dificultad_Platillos>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.MS_Dificultad_Platillos.MS_Dificultad_Platillos>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.MS_Dificultad_Platillos.MS_Dificultad_PlatillosPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.MS_Dificultad_Platillos.MS_Dificultad_Platillos>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.MS_Dificultad_Platillos.MS_Dificultad_Platillos_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.MS_Dificultad_Platillos.MS_Dificultad_Platillos_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

