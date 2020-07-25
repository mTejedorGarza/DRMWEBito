using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.MS_Calorias
{
    public partial class MS_CaloriasMap : EntityTypeConfiguration<Spartane.Core.Classes.MS_Calorias.MS_Calorias>
    {
        public MS_CaloriasMap()
        {
            this.ToTable("MS_Calorias");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
