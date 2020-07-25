using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Tipo_de_Vigencia
{
    public partial class Tipo_de_VigenciaMap : EntityTypeConfiguration<Spartane.Core.Classes.Tipo_de_Vigencia.Tipo_de_Vigencia>
    {
        public Tipo_de_VigenciaMap()
        {
            this.ToTable("Tipo_de_Vigencia");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
