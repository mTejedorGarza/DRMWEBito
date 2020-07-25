using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Estatus_Plan_de_Rutinas
{
    public partial class Estatus_Plan_de_RutinasMap : EntityTypeConfiguration<Spartane.Core.Classes.Estatus_Plan_de_Rutinas.Estatus_Plan_de_Rutinas>
    {
        public Estatus_Plan_de_RutinasMap()
        {
            this.ToTable("Estatus_Plan_de_Rutinas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
