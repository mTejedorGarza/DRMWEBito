using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Configuracion_del_Paciente
{
    public partial class Configuracion_del_PacienteMap : EntityTypeConfiguration<Spartane.Core.Classes.Configuracion_del_Paciente.Configuracion_del_Paciente>
    {
        public Configuracion_del_PacienteMap()
        {
            this.ToTable("Configuracion_del_Paciente");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
