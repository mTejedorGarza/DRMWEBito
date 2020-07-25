using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Tipo_de_Notificacion
{
    public partial class Tipo_de_NotificacionMap : EntityTypeConfiguration<Spartane.Core.Classes.Tipo_de_Notificacion.Tipo_de_Notificacion>
    {
        public Tipo_de_NotificacionMap()
        {
            this.ToTable("Tipo_de_Notificacion");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
