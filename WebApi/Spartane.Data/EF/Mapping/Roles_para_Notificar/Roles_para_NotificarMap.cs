using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Roles_para_Notificar
{
    public partial class Roles_para_NotificarMap : EntityTypeConfiguration<Spartane.Core.Classes.Roles_para_Notificar.Roles_para_Notificar>
    {
        public Roles_para_NotificarMap()
        {
            this.ToTable("Roles_para_Notificar");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
