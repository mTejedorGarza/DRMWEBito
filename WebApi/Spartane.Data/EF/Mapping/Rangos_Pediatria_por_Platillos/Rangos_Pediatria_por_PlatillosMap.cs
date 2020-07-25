using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Rangos_Pediatria_por_Platillos
{
    public partial class Rangos_Pediatria_por_PlatillosMap : EntityTypeConfiguration<Spartane.Core.Classes.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos>
    {
        public Rangos_Pediatria_por_PlatillosMap()
        {
            this.ToTable("Rangos_Pediatria_por_Platillos");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
