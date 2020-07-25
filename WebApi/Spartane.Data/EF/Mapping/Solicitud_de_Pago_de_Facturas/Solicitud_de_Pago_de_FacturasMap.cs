using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Solicitud_de_Pago_de_Facturas
{
    public partial class Solicitud_de_Pago_de_FacturasMap : EntityTypeConfiguration<Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas>
    {
        public Solicitud_de_Pago_de_FacturasMap()
        {
            this.ToTable("Solicitud_de_Pago_de_Facturas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
