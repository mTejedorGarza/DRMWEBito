using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.User
{
    /// <summary>
    /// User table
    /// </summary>
    public partial class TTUsuario: BaseEntity
    {
		/*CODMANINI-UPD*/
        public int IdUsuario { get; set; }
		/*CODMANFIN-UPD*/
        public string Nombre { get; set; }
        public string Clave_de_Acceso { get; set; }
        public string Contrasena { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<short> IdGrupoUsuarios { get; set; }
    }
}
