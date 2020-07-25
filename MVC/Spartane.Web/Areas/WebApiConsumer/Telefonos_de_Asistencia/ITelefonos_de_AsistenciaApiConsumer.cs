using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Telefonos_de_Asistencia
{
    public interface ITelefonos_de_AsistenciaApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_AsistenciaPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Telefonos_de_AsistenciaInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia entity, Spartane.Core.Domain.User.GlobalData Telefonos_de_AsistenciaInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia entity, Spartane.Core.Domain.User.GlobalData Telefonos_de_AsistenciaInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_AsistenciaPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

