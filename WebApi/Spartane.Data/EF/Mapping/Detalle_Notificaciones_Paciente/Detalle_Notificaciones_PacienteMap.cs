using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Notificaciones_Paciente
{
    public partial class Detalle_Notificaciones_PacienteMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Notificaciones_Paciente.Detalle_Notificaciones_Paciente>
    {
        public Detalle_Notificaciones_PacienteMap()
        {
            this.ToTable("Detalle_Notificaciones_Paciente");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
