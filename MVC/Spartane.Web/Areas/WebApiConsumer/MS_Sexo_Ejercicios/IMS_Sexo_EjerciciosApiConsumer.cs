using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.MS_Sexo_Ejercicios
{
    public interface IMS_Sexo_EjerciciosApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.MS_Sexo_Ejercicios.MS_Sexo_Ejercicios>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.MS_Sexo_Ejercicios.MS_Sexo_Ejercicios>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.MS_Sexo_Ejercicios.MS_Sexo_Ejercicios> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.MS_Sexo_Ejercicios.MS_Sexo_EjerciciosPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData MS_Sexo_EjerciciosInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.MS_Sexo_Ejercicios.MS_Sexo_Ejercicios entity, Spartane.Core.Domain.User.GlobalData MS_Sexo_EjerciciosInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.MS_Sexo_Ejercicios.MS_Sexo_Ejercicios entity, Spartane.Core.Domain.User.GlobalData MS_Sexo_EjerciciosInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.MS_Sexo_Ejercicios.MS_Sexo_Ejercicios>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.MS_Sexo_Ejercicios.MS_Sexo_Ejercicios>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.MS_Sexo_Ejercicios.MS_Sexo_Ejercicios>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.MS_Sexo_Ejercicios.MS_Sexo_EjerciciosPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.MS_Sexo_Ejercicios.MS_Sexo_Ejercicios>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.MS_Sexo_Ejercicios.MS_Sexo_Ejercicios_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.MS_Sexo_Ejercicios.MS_Sexo_Ejercicios_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

