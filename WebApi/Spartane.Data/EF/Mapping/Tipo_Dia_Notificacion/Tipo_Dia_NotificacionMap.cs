using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Tipo_Dia_Notificacion
{
    public partial class Tipo_Dia_NotificacionMap : EntityTypeConfiguration<Spartane.Core.Classes.Tipo_Dia_Notificacion.Tipo_Dia_Notificacion>
    {
        public Tipo_Dia_NotificacionMap()
        {
            this.ToTable("Tipo_Dia_Notificacion");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
