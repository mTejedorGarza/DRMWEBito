using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Secuencia_de_Ejercicios_en_Rutinas
{
    public partial class Secuencia_de_Ejercicios_en_RutinasMap : EntityTypeConfiguration<Spartane.Core.Classes.Secuencia_de_Ejercicios_en_Rutinas.Secuencia_de_Ejercicios_en_Rutinas>
    {
        public Secuencia_de_Ejercicios_en_RutinasMap()
        {
            this.ToTable("Secuencia_de_Ejercicios_en_Rutinas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
