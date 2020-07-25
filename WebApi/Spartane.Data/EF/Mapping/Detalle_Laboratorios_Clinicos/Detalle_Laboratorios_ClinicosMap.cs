using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Laboratorios_Clinicos
{
    public partial class Detalle_Laboratorios_ClinicosMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos>
    {
        public Detalle_Laboratorios_ClinicosMap()
        {
            this.ToTable("Detalle_Laboratorios_Clinicos");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
