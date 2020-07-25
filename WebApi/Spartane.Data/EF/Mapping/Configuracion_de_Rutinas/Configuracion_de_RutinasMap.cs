using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Configuracion_de_Rutinas
{
    public partial class Configuracion_de_RutinasMap : EntityTypeConfiguration<Spartane.Core.Classes.Configuracion_de_Rutinas.Configuracion_de_Rutinas>
    {
        public Configuracion_de_RutinasMap()
        {
            this.ToTable("Configuracion_de_Rutinas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
