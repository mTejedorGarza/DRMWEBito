using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Subgrupos_Ingredientes
{
    public partial class Subgrupos_IngredientesMap : EntityTypeConfiguration<Spartane.Core.Classes.Subgrupos_Ingredientes.Subgrupos_Ingredientes>
    {
        public Subgrupos_IngredientesMap()
        {
            this.ToTable("Subgrupos_Ingredientes");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
