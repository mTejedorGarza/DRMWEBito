using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Resultados_de_Revision
{
    public partial class Resultados_de_RevisionMap : EntityTypeConfiguration<Spartane.Core.Classes.Resultados_de_Revision.Resultados_de_Revision>
    {
        public Resultados_de_RevisionMap()
        {
            this.ToTable("Resultados_de_Revision");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
