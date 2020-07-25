using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.MS_Caracteristicas_Platillo
{
    public partial class MS_Caracteristicas_PlatilloMap : EntityTypeConfiguration<Spartane.Core.Classes.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo>
    {
        public MS_Caracteristicas_PlatilloMap()
        {
            this.ToTable("MS_Caracteristicas_Platillo");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
