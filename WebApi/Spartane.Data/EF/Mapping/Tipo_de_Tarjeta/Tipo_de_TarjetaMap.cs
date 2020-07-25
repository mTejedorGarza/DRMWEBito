using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Tipo_de_Tarjeta
{
    public partial class Tipo_de_TarjetaMap : EntityTypeConfiguration<Spartane.Core.Classes.Tipo_de_Tarjeta.Tipo_de_Tarjeta>
    {
        public Tipo_de_TarjetaMap()
        {
            this.ToTable("Tipo_de_Tarjeta");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
