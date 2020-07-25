using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Estatus_de_Funcionalidad_para_Notificacion
{
    public partial class Estatus_de_Funcionalidad_para_NotificacionMap : EntityTypeConfiguration<Spartane.Core.Classes.Estatus_de_Funcionalidad_para_Notificacion.Estatus_de_Funcionalidad_para_Notificacion>
    {
        public Estatus_de_Funcionalidad_para_NotificacionMap()
        {
            this.ToTable("Estatus_de_Funcionalidad_para_Notificacion");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
