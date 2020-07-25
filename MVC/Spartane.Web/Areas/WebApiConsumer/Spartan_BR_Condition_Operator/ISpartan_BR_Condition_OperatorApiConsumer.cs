﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Condition_Operator
{
    public interface ISpartan_BR_Condition_OperatorApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator> GetByKey(short Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_OperatorPagingModel> GetByKeyComplete(short Key);
        ApiResponse<bool> Delete(short Key, Spartane.Core.Domain.User.GlobalData Spartan_BR_Condition_OperatorInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int16> Insert(Spartane.Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator entity, Spartane.Core.Domain.User.GlobalData Spartan_BR_Condition_OperatorInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int16> Update(Spartane.Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator entity, Spartane.Core.Domain.User.GlobalData Spartan_BR_Condition_OperatorInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_OperatorPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator>> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

