using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.MS_Dificultad_Platillos
{
    public partial class MS_Dificultad_PlatillosMap : EntityTypeConfiguration<Spartane.Core.Classes.MS_Dificultad_Platillos.MS_Dificultad_Platillos>
    {
        public MS_Dificultad_PlatillosMap()
        {
            this.ToTable("MS_Dificultad_Platillos");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
