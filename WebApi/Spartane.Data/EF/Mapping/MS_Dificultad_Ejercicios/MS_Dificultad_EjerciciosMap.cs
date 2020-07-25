using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.MS_Dificultad_Ejercicios
{
    public partial class MS_Dificultad_EjerciciosMap : EntityTypeConfiguration<Spartane.Core.Classes.MS_Dificultad_Ejercicios.MS_Dificultad_Ejercicios>
    {
        public MS_Dificultad_EjerciciosMap()
        {
            this.ToTable("MS_Dificultad_Ejercicios");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
