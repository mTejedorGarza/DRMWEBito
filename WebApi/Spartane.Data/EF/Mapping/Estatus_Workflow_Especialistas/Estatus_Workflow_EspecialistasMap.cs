using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Estatus_Workflow_Especialistas
{
    public partial class Estatus_Workflow_EspecialistasMap : EntityTypeConfiguration<Spartane.Core.Classes.Estatus_Workflow_Especialistas.Estatus_Workflow_Especialistas>
    {
        public Estatus_Workflow_EspecialistasMap()
        {
            this.ToTable("Estatus_Workflow_Especialistas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
