using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Tipos_de_Descuento
{
    public partial class Tipos_de_DescuentoMap : EntityTypeConfiguration<Spartane.Core.Classes.Tipos_de_Descuento.Tipos_de_Descuento>
    {
        public Tipos_de_DescuentoMap()
        {
            this.ToTable("Tipos_de_Descuento");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
