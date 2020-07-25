using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.MS_Equipamiento_Alterno_Ejercicios
{
    public partial class MS_Equipamiento_Alterno_EjerciciosMap : EntityTypeConfiguration<Spartane.Core.Classes.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios>
    {
        public MS_Equipamiento_Alterno_EjerciciosMap()
        {
            this.ToTable("MS_Equipamiento_Alterno_Ejercicios");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
