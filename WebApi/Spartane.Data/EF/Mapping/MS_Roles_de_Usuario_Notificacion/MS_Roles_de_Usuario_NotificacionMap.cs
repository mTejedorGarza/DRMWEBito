using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.MS_Roles_de_Usuario_Notificacion
{
    public partial class MS_Roles_de_Usuario_NotificacionMap : EntityTypeConfiguration<Spartane.Core.Classes.MS_Roles_de_Usuario_Notificacion.MS_Roles_de_Usuario_Notificacion>
    {
        public MS_Roles_de_Usuario_NotificacionMap()
        {
            this.ToTable("MS_Roles_de_Usuario_Notificacion");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
