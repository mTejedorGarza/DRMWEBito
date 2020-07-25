﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_Attribute_Control_Type
{
    public interface ISpartan_Attribute_Control_TypeApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type> GetByKey(short Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_TypePagingModel> GetByKeyComplete(short Key);
        ApiResponse<bool> Delete(short Key, Spartane.Core.Domain.User.GlobalData Spartan_Attribute_Control_TypeInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int16> Insert(Spartane.Core.Domain.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type entity, Spartane.Core.Domain.User.GlobalData Spartan_Attribute_Control_TypeInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int16> Update(Spartane.Core.Domain.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type entity, Spartane.Core.Domain.User.GlobalData Spartan_Attribute_Control_TypeInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_TypePagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type>> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

