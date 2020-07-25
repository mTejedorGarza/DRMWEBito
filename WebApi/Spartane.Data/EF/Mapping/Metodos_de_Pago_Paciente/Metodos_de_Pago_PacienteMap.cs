using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Metodos_de_Pago_Paciente
{
    public partial class Metodos_de_Pago_PacienteMap : EntityTypeConfiguration<Spartane.Core.Classes.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente>
    {
        public Metodos_de_Pago_PacienteMap()
        {
            this.ToTable("Metodos_de_Pago_Paciente");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
