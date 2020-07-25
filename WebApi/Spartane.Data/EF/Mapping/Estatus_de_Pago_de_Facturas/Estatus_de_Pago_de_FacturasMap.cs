using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Estatus_de_Pago_de_Facturas
{
    public partial class Estatus_de_Pago_de_FacturasMap : EntityTypeConfiguration<Spartane.Core.Classes.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_Facturas>
    {
        public Estatus_de_Pago_de_FacturasMap()
        {
            this.ToTable("Estatus_de_Pago_de_Facturas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
