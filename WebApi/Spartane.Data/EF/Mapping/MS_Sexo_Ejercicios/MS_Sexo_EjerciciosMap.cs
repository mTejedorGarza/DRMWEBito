using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.MS_Sexo_Ejercicios
{
    public partial class MS_Sexo_EjerciciosMap : EntityTypeConfiguration<Spartane.Core.Classes.MS_Sexo_Ejercicios.MS_Sexo_Ejercicios>
    {
        public MS_Sexo_EjerciciosMap()
        {
            this.ToTable("MS_Sexo_Ejercicios");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
