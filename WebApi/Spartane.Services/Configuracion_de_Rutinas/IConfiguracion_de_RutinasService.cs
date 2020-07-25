﻿using System;
using Spartane.Core.Classes.Configuracion_de_Rutinas;
using System.Collections.Generic;


namespace Spartane.Services.Configuracion_de_Rutinas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IConfiguracion_de_RutinasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Configuracion_de_Rutinas.Configuracion_de_Rutinas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Configuracion_de_Rutinas.Configuracion_de_Rutinas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Configuracion_de_Rutinas.Configuracion_de_Rutinas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Configuracion_de_Rutinas.Configuracion_de_Rutinas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Configuracion_de_Rutinas.Configuracion_de_Rutinas entity);
        Int32 Update(Spartane.Core.Classes.Configuracion_de_Rutinas.Configuracion_de_Rutinas entity);
        IList<Spartane.Core.Classes.Configuracion_de_Rutinas.Configuracion_de_Rutinas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Configuracion_de_Rutinas.Configuracion_de_Rutinas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Configuracion_de_Rutinas.Configuracion_de_RutinasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Configuracion_de_Rutinas.Configuracion_de_Rutinas> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Configuracion_de_Rutinas.Configuracion_de_Rutinas entity);

    }
}
