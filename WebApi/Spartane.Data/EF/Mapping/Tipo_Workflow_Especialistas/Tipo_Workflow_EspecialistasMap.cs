using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Tipo_Workflow_Especialistas
{
    public partial class Tipo_Workflow_EspecialistasMap : EntityTypeConfiguration<Spartane.Core.Classes.Tipo_Workflow_Especialistas.Tipo_Workflow_Especialistas>
    {
        public Tipo_Workflow_EspecialistasMap()
        {
            this.ToTable("Tipo_Workflow_Especialistas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
