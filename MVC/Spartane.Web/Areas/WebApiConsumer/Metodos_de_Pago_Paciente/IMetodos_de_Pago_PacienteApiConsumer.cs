using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Metodos_de_Pago_Paciente
{
    public interface IMetodos_de_Pago_PacienteApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_PacientePagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Metodos_de_Pago_PacienteInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente entity, Spartane.Core.Domain.User.GlobalData Metodos_de_Pago_PacienteInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente entity, Spartane.Core.Domain.User.GlobalData Metodos_de_Pago_PacienteInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_PacientePagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

