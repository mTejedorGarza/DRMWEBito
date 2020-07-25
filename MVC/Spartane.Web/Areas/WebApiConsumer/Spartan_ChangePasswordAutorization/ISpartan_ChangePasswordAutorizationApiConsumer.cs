﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_ChangePasswordAutorization
{
    public interface ISpartan_ChangePasswordAutorizationApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorizationPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_ChangePasswordAutorizationInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization entity, Spartane.Core.Domain.User.GlobalData Spartan_ChangePasswordAutorizationInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization entity, Spartane.Core.Domain.User.GlobalData Spartan_ChangePasswordAutorizationInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorizationPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization>> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

