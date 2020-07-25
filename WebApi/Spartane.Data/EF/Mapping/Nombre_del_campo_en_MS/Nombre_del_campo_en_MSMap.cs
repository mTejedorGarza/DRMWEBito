using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Nombre_del_campo_en_MS
{
    public partial class Nombre_del_campo_en_MSMap : EntityTypeConfiguration<Spartane.Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS>
    {
        public Nombre_del_campo_en_MSMap()
        {
            this.ToTable("Nombre_del_campo_en_MS");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
