using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Telefonos_de_Asistencia
{
    public partial class Telefonos_de_AsistenciaMap : EntityTypeConfiguration<Spartane.Core.Classes.Telefonos_de_Asistencia.Telefonos_de_Asistencia>
    {
        public Telefonos_de_AsistenciaMap()
        {
            this.ToTable("Telefonos_de_Asistencia");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
