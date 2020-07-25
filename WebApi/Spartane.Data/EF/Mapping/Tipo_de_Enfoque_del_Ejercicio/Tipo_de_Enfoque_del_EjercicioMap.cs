using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Tipo_de_Enfoque_del_Ejercicio
{
    public partial class Tipo_de_Enfoque_del_EjercicioMap : EntityTypeConfiguration<Spartane.Core.Classes.Tipo_de_Enfoque_del_Ejercicio.Tipo_de_Enfoque_del_Ejercicio>
    {
        public Tipo_de_Enfoque_del_EjercicioMap()
        {
            this.ToTable("Tipo_de_Enfoque_del_Ejercicio");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
