using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.MS_Tiempos_de_Comida_Platillos
{
    public partial class MS_Tiempos_de_Comida_PlatillosMap : EntityTypeConfiguration<Spartane.Core.Classes.MS_Tiempos_de_Comida_Platillos.MS_Tiempos_de_Comida_Platillos>
    {
        public MS_Tiempos_de_Comida_PlatillosMap()
        {
            this.ToTable("MS_Tiempos_de_Comida_Platillos");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
