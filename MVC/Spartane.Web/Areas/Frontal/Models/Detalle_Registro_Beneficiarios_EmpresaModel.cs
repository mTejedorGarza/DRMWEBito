using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Registro_Beneficiarios_EmpresaModel
    {
        [Required]
        public int Folio { get; set; }
        public string Numero_de_Empleado_Titular { get; set; }
        public string Numero_de_Empleado { get; set; }
        public int? Usuario { get; set; }
        public string UsuarioName { get; set; }
        public bool Activo { get; set; }
        public int? Suscripcion { get; set; }
        public string SuscripcionNombre_del_Plan { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }
	
	public class Detalle_Registro_Beneficiarios_Empresa_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Numero_de_Empleado_Titular { get; set; }
        public string Numero_de_Empleado { get; set; }
        public int? Usuario { get; set; }
        public string UsuarioName { get; set; }
        public bool? Activo { get; set; }
        public int? Suscripcion { get; set; }
        public string SuscripcionNombre_del_Plan { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }


}

