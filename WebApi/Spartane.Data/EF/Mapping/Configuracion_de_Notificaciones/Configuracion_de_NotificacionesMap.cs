using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Configuracion_de_Notificaciones
{
    public partial class Configuracion_de_NotificacionesMap : EntityTypeConfiguration<Spartane.Core.Classes.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones>
    {
        public Configuracion_de_NotificacionesMap()
        {
            this.ToTable("Configuracion_de_Notificaciones");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
