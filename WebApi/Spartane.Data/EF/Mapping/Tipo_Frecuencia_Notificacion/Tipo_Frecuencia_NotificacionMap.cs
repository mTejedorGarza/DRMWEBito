using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Tipo_Frecuencia_Notificacion
{
    public partial class Tipo_Frecuencia_NotificacionMap : EntityTypeConfiguration<Spartane.Core.Classes.Tipo_Frecuencia_Notificacion.Tipo_Frecuencia_Notificacion>
    {
        public Tipo_Frecuencia_NotificacionMap()
        {
            this.ToTable("Tipo_Frecuencia_Notificacion");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
