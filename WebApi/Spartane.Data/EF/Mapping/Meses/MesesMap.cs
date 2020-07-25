using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Meses
{
    public partial class MesesMap : EntityTypeConfiguration<Spartane.Core.Classes.Meses.Meses>
    {
        public MesesMap()
        {
            this.ToTable("Meses");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
