using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Tipos_de_Vendedor
{
    public partial class Tipos_de_VendedorMap : EntityTypeConfiguration<Spartane.Core.Classes.Tipos_de_Vendedor.Tipos_de_Vendedor>
    {
        public Tipos_de_VendedorMap()
        {
            this.ToTable("Tipos_de_Vendedor");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
