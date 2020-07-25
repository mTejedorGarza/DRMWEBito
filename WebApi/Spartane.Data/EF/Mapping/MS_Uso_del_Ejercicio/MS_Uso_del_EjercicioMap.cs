using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.MS_Uso_del_Ejercicio
{
    public partial class MS_Uso_del_EjercicioMap : EntityTypeConfiguration<Spartane.Core.Classes.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio>
    {
        public MS_Uso_del_EjercicioMap()
        {
            this.ToTable("MS_Uso_del_Ejercicio");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
