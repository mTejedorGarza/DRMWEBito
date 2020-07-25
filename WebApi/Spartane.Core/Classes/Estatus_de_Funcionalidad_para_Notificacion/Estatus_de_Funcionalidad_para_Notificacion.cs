using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Estatus_de_Funcionalidad_para_Notificacion
{
    /// <summary>
    /// Estatus_de_Funcionalidad_para_Notificacion table
    /// </summary>
    public class Estatus_de_Funcionalidad_para_Notificacion: BaseEntity
    {
        public int Folio { get; set; }
        public string Campo_para_Estatus { get; set; }
        public string Nombre_Fisico_del_Campo { get; set; }
        public string Nombre_Fisico_de_la_Tabla { get; set; }


    }
}

