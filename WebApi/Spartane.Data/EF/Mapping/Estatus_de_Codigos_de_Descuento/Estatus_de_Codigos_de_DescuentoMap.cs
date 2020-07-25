using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Estatus_de_Codigos_de_Descuento
{
    public partial class Estatus_de_Codigos_de_DescuentoMap : EntityTypeConfiguration<Spartane.Core.Classes.Estatus_de_Codigos_de_Descuento.Estatus_de_Codigos_de_Descuento>
    {
        public Estatus_de_Codigos_de_DescuentoMap()
        {
            this.ToTable("Estatus_de_Codigos_de_Descuento");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
