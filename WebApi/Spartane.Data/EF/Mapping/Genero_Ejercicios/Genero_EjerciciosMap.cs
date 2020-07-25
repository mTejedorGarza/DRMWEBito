using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Genero_Ejercicios
{
    public partial class Genero_EjerciciosMap : EntityTypeConfiguration<Spartane.Core.Classes.Genero_Ejercicios.Genero_Ejercicios>
    {
        public Genero_EjerciciosMap()
        {
            this.ToTable("Genero_Ejercicios");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
