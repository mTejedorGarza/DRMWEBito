﻿using System;
using Spartane.Core.Domain.Duracion_de_Planes_de_Suscripcion;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Duracion_de_Planes_de_Suscripcion
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDuracion_de_Planes_de_SuscripcionService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Duracion_de_Planes_de_Suscripcion.Duracion_de_Planes_de_Suscripcion> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Duracion_de_Planes_de_Suscripcion.Duracion_de_Planes_de_Suscripcion> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Duracion_de_Planes_de_Suscripcion.Duracion_de_Planes_de_Suscripcion> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Duracion_de_Planes_de_Suscripcion.Duracion_de_Planes_de_Suscripcion GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Duracion_de_Planes_de_Suscripcion.Duracion_de_Planes_de_Suscripcion entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Duracion_de_Planes_de_Suscripcion.Duracion_de_Planes_de_Suscripcion entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Duracion_de_Planes_de_Suscripcion.Duracion_de_Planes_de_Suscripcion> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Duracion_de_Planes_de_Suscripcion.Duracion_de_Planes_de_Suscripcion> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Duracion_de_Planes_de_Suscripcion.Duracion_de_Planes_de_SuscripcionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Duracion_de_Planes_de_Suscripcion.Duracion_de_Planes_de_Suscripcion> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
