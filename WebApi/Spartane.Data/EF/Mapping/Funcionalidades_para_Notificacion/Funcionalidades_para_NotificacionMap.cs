using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Funcionalidades_para_Notificacion
{
    public partial class Funcionalidades_para_NotificacionMap : EntityTypeConfiguration<Spartane.Core.Classes.Funcionalidades_para_Notificacion.Funcionalidades_para_Notificacion>
    {
        public Funcionalidades_para_NotificacionMap()
        {
            this.ToTable("Funcionalidades_para_Notificacion");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
