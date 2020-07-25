using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.MS_Padecimientos
{
    public partial class MS_PadecimientosMap : EntityTypeConfiguration<Spartane.Core.Classes.MS_Padecimientos.MS_Padecimientos>
    {
        public MS_PadecimientosMap()
        {
            this.ToTable("MS_Padecimientos");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
