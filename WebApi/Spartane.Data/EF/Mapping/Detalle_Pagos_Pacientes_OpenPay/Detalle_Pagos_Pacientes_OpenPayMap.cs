using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Pagos_Pacientes_OpenPay
{
    public partial class Detalle_Pagos_Pacientes_OpenPayMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay>
    {
        public Detalle_Pagos_Pacientes_OpenPayMap()
        {
            this.ToTable("Detalle_Pagos_Pacientes_OpenPay");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
