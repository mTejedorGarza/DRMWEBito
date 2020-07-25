using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.MR_Padecimientos
{
    public partial class MR_PadecimientosMap : EntityTypeConfiguration<Spartane.Core.Classes.MR_Padecimientos.MR_Padecimientos>
    {
        public MR_PadecimientosMap()
        {
            this.ToTable("MR_Padecimientos");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
