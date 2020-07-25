using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.MS_Beneficiarios_Suscripcion
{
    public partial class MS_Beneficiarios_SuscripcionMap : EntityTypeConfiguration<Spartane.Core.Classes.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion>
    {
        public MS_Beneficiarios_SuscripcionMap()
        {
            this.ToTable("MS_Beneficiarios_Suscripcion");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
