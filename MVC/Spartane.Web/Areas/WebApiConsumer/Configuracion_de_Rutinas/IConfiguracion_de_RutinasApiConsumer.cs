using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Configuracion_de_Rutinas
{
    public interface IConfiguracion_de_RutinasApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Configuracion_de_Rutinas.Configuracion_de_RutinasPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Configuracion_de_RutinasInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas entity, Spartane.Core.Domain.User.GlobalData Configuracion_de_RutinasInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas entity, Spartane.Core.Domain.User.GlobalData Configuracion_de_RutinasInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Configuracion_de_Rutinas.Configuracion_de_RutinasPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

