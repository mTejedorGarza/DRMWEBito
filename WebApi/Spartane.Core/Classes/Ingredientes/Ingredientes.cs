using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Clasificacion_Ingredientes;
using Spartane.Core.Classes.Subgrupos_Ingredientes;
using Spartane.Core.Classes.Spartane_File;
using Spartane.Core.Classes.Unidades_de_Medida;
using Spartane.Core.Classes.Estatus_Ingredientes;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Ingredientes
{
    /// <summary>
    /// Ingredientes table
    /// </summary>
    public class Ingredientes: BaseEntity
    {
        public int Clave { get; set; }
        public bool? Es_un_ingrediente_de_SMAE { get; set; }
        public int? Clasificacion { get; set; }
        public int? Subgrupo { get; set; }
        public string Nombre_Ingrediente { get; set; }
        public string Ingrediente { get; set; }
        public int? Imagen { get; set; }
        //public string Imagen_URL { get; set; }
        public string Cantidad_sugerida { get; set; }
        public decimal? Cantidad_Sugerida_Decimal { get; set; }
        public int? Unidad { get; set; }
        public decimal? Peso_bruto_redondeado_g { get; set; }
        public decimal? Peso_neto_g { get; set; }
        public int? Estatus { get; set; }

        [ForeignKey("Clasificacion")]
        public virtual Spartane.Core.Classes.Clasificacion_Ingredientes.Clasificacion_Ingredientes Clasificacion_Clasificacion_Ingredientes { get; set; }
        [ForeignKey("Subgrupo")]
        public virtual Spartane.Core.Classes.Subgrupos_Ingredientes.Subgrupos_Ingredientes Subgrupo_Subgrupos_Ingredientes { get; set; }
        [ForeignKey("Imagen")]
        public virtual Spartane.Core.Classes.Spartane_File.Spartane_File Imagen_Spartane_File { get; set; }
        [ForeignKey("Unidad")]
        public virtual Spartane.Core.Classes.Unidades_de_Medida.Unidades_de_Medida Unidad_Unidades_de_Medida { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Classes.Estatus_Ingredientes.Estatus_Ingredientes Estatus_Estatus_Ingredientes { get; set; }

    }
}

