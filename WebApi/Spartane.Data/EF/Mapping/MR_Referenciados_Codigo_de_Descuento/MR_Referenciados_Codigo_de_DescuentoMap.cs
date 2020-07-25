using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.MR_Referenciados_Codigo_de_Descuento
{
    public partial class MR_Referenciados_Codigo_de_DescuentoMap : EntityTypeConfiguration<Spartane.Core.Classes.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento>
    {
        public MR_Referenciados_Codigo_de_DescuentoMap()
        {
            this.ToTable("MR_Referenciados_Codigo_de_Descuento");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
