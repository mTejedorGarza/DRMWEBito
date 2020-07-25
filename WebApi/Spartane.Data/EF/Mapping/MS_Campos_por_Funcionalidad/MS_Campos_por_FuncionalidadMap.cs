using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.MS_Campos_por_Funcionalidad
{
    public partial class MS_Campos_por_FuncionalidadMap : EntityTypeConfiguration<Spartane.Core.Classes.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad>
    {
        public MS_Campos_por_FuncionalidadMap()
        {
            this.ToTable("MS_Campos_por_Funcionalidad");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
