﻿using System;
using Spartane.Core.Classes.Planes_de_Rutinas;
using System.Collections.Generic;


namespace Spartane.Services.Planes_de_Rutinas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IPlanes_de_RutinasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Planes_de_Rutinas.Planes_de_Rutinas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Planes_de_Rutinas.Planes_de_Rutinas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Planes_de_Rutinas.Planes_de_Rutinas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Planes_de_Rutinas.Planes_de_Rutinas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Planes_de_Rutinas.Planes_de_Rutinas entity);
        Int32 Update(Spartane.Core.Classes.Planes_de_Rutinas.Planes_de_Rutinas entity);
        IList<Spartane.Core.Classes.Planes_de_Rutinas.Planes_de_Rutinas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Planes_de_Rutinas.Planes_de_Rutinas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Planes_de_Rutinas.Planes_de_RutinasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Planes_de_Rutinas.Planes_de_Rutinas> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Planes_de_Rutinas.Planes_de_Rutinas entity);
       int Update_Seguimiento_al_Plan(Spartane.Core.Classes.Planes_de_Rutinas.Planes_de_Rutinas entity);

    }
}
