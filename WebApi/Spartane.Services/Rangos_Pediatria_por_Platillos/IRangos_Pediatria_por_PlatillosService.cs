using System;
using Spartane.Core.Classes.Rangos_Pediatria_por_Platillos;
using System.Collections.Generic;


namespace Spartane.Services.Rangos_Pediatria_por_Platillos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IRangos_Pediatria_por_PlatillosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos entity);
        Int32 Update(Spartane.Core.Classes.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos entity);
        IList<Spartane.Core.Classes.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_PlatillosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos entity);

    }
}
