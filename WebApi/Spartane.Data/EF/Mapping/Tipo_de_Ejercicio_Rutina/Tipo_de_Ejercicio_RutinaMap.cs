using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Tipo_de_Ejercicio_Rutina
{
    public partial class Tipo_de_Ejercicio_RutinaMap : EntityTypeConfiguration<Spartane.Core.Classes.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina>
    {
        public Tipo_de_Ejercicio_RutinaMap()
        {
            this.ToTable("Tipo_de_Ejercicio_Rutina");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
