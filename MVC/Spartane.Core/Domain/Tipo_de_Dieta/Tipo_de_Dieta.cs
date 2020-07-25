using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Categorias_de_platillos;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Tipo_de_Dieta
{
    /// <summary>
    /// Tipo_de_Dieta table
    /// </summary>
    public class Tipo_de_Dieta: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public int? Categoria_para_Platillos { get; set; }

        [ForeignKey("Categoria_para_Platillos")]
        public virtual Spartane.Core.Domain.Categorias_de_platillos.Categorias_de_platillos Categoria_para_Platillos_Categorias_de_platillos { get; set; }

    }
	
	public class Tipo_de_Dieta_Datos_Generales
    {
                public int Clave { get; set; }
        public string Descripcion { get; set; }
        public int? Categoria_para_Platillos { get; set; }

		        [ForeignKey("Categoria_para_Platillos")]
        public virtual Spartane.Core.Domain.Categorias_de_platillos.Categorias_de_platillos Categoria_para_Platillos_Categorias_de_platillos { get; set; }

    }


}

