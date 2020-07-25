using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.MR_Detalle_Platillo
{
    public partial class MR_Detalle_PlatilloMap : EntityTypeConfiguration<Spartane.Core.Classes.MR_Detalle_Platillo.MR_Detalle_Platillo>
    {
        public MR_Detalle_PlatilloMap()
        {
            this.ToTable("MR_Detalle_Platillo");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
