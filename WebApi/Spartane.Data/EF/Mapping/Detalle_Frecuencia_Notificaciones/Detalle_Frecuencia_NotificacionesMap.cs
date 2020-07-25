using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Frecuencia_Notificaciones
{
    public partial class Detalle_Frecuencia_NotificacionesMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones>
    {
        public Detalle_Frecuencia_NotificacionesMap()
        {
            this.ToTable("Detalle_Frecuencia_Notificaciones");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
