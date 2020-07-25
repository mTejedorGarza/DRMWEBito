using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Semanas_Planes
{
    public partial class Semanas_PlanesMap : EntityTypeConfiguration<Spartane.Core.Classes.Semanas_Planes.Semanas_Planes>
    {
        public Semanas_PlanesMap()
        {
            this.ToTable("Semanas_Planes");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
