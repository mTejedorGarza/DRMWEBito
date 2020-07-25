﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Empresas;
using Spartane.Core.Classes.areas_Empresas;
using Spartane.Core.Classes.Estatus;
using Spartane.Core.Classes.Spartan_User;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Detalle_Contactos_Empresa
{
    /// <summary>
    /// Detalle_Contactos_Empresa table
    /// </summary>
    public class Detalle_Contactos_Empresa: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Empresas { get; set; }
        public string Nombre_completo { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public bool? Contacto_Principal { get; set; }
        public int? Area { get; set; }
        public bool? Acceso_al_Sistema { get; set; }
        public string Nombre_de_usuario { get; set; }
        public bool? Recibe_Alertas { get; set; }
        public int? Estatus { get; set; }
        public int? Folio_Usuario { get; set; }

        [ForeignKey("Folio_Empresas")]
        public virtual Spartane.Core.Classes.Empresas.Empresas Folio_Empresas_Empresas { get; set; }
        [ForeignKey("Area")]
        public virtual Spartane.Core.Classes.areas_Empresas.areas_Empresas Area_areas_Empresas { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Classes.Estatus.Estatus Estatus_Estatus { get; set; }
        [ForeignKey("Folio_Usuario")]
        public virtual Spartane.Core.Classes.Spartan_User.Spartan_User Folio_Usuario_Spartan_User { get; set; }

    }
}

