﻿using System;
using Spartane.Core.Domain.Rutinas;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Rutinas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IRutinasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Rutinas.Rutinas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Rutinas.Rutinas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Rutinas.Rutinas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Rutinas.Rutinas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Rutinas.Rutinas entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Rutinas.Rutinas entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Rutinas.Rutinas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Rutinas.Rutinas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Rutinas.RutinasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Rutinas.Rutinas> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
