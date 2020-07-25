using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.MR_Tarjetas
{
    public partial class MR_TarjetasMap : EntityTypeConfiguration<Spartane.Core.Classes.MR_Tarjetas.MR_Tarjetas>
    {
        public MR_TarjetasMap()
        {
            this.ToTable("MR_Tarjetas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
