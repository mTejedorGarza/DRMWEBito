using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Secuencia_de_Ejercicios
{
    public partial class Detalle_Secuencia_de_EjerciciosMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Secuencia_de_Ejercicios.Detalle_Secuencia_de_Ejercicios>
    {
        public Detalle_Secuencia_de_EjerciciosMap()
        {
            this.ToTable("Detalle_Secuencia_de_Ejercicios");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
