﻿using System;
using Spartane.Core.Domain.Spartan_BR_Action_Param_Type;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Spartan_BR_Action_Param_Type
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_BR_Action_Param_TypeService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Spartan_BR_Action_Param_Type.Spartan_BR_Action_Param_Type> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_BR_Action_Param_Type.Spartan_BR_Action_Param_Type> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_BR_Action_Param_Type.Spartan_BR_Action_Param_Type> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Spartan_BR_Action_Param_Type.Spartan_BR_Action_Param_Type GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Spartan_BR_Action_Param_Type.Spartan_BR_Action_Param_Type entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Spartan_BR_Action_Param_Type.Spartan_BR_Action_Param_Type entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Spartan_BR_Action_Param_Type.Spartan_BR_Action_Param_Type> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Spartan_BR_Action_Param_Type.Spartan_BR_Action_Param_Type> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Spartan_BR_Action_Param_Type.Spartan_BR_Action_Param_TypePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Spartan_BR_Action_Param_Type.Spartan_BR_Action_Param_Type> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
