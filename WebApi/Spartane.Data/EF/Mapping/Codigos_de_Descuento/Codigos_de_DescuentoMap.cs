using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Codigos_de_Descuento
{
    public partial class Codigos_de_DescuentoMap : EntityTypeConfiguration<Spartane.Core.Classes.Codigos_de_Descuento.Codigos_de_Descuento>
    {
        public Codigos_de_DescuentoMap()
        {
            this.ToTable("Codigos_de_Descuento");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
