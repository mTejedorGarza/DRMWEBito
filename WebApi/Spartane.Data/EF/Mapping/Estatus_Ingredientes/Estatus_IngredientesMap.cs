using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Estatus_Ingredientes
{
    public partial class Estatus_IngredientesMap : EntityTypeConfiguration<Spartane.Core.Classes.Estatus_Ingredientes.Estatus_Ingredientes>
    {
        public Estatus_IngredientesMap()
        {
            this.ToTable("Estatus_Ingredientes");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
