using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.MS_Semanas_Planes
{
    public partial class MS_Semanas_PlanesMap : EntityTypeConfiguration<Spartane.Core.Classes.MS_Semanas_Planes.MS_Semanas_Planes>
    {
        public MS_Semanas_PlanesMap()
        {
            this.ToTable("MS_Semanas_Planes");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
