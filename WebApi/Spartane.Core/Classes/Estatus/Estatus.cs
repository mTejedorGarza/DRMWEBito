﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Estatus
{
    /// <summary>
    /// Estatus table
    /// </summary>
    public class Estatus: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }


    }
}

