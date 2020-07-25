using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Resultado_de_Autorizacion
{
    public partial class Resultado_de_AutorizacionMap : EntityTypeConfiguration<Spartane.Core.Classes.Resultado_de_Autorizacion.Resultado_de_Autorizacion>
    {
        public Resultado_de_AutorizacionMap()
        {
            this.ToTable("Resultado_de_Autorizacion");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
