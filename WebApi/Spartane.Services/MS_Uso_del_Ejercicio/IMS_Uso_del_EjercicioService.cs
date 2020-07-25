﻿using System;
using Spartane.Core.Classes.MS_Uso_del_Ejercicio;
using System.Collections.Generic;


namespace Spartane.Services.MS_Uso_del_Ejercicio
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IMS_Uso_del_EjercicioService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio entity);
        Int32 Update(Spartane.Core.Classes.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio entity);
        IList<Spartane.Core.Classes.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.MS_Uso_del_Ejercicio.MS_Uso_del_EjercicioPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio entity);

    }
}
