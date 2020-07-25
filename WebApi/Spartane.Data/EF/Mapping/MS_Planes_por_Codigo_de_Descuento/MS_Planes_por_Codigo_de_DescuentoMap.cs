using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.MS_Planes_por_Codigo_de_Descuento
{
    public partial class MS_Planes_por_Codigo_de_DescuentoMap : EntityTypeConfiguration<Spartane.Core.Classes.MS_Planes_por_Codigo_de_Descuento.MS_Planes_por_Codigo_de_Descuento>
    {
        public MS_Planes_por_Codigo_de_DescuentoMap()
        {
            this.ToTable("MS_Planes_por_Codigo_de_Descuento");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
