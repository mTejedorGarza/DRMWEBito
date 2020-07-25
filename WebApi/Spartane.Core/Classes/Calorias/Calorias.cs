﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Calorias
{
    /// <summary>
    /// Calorias table
    /// </summary>
    public class Calorias: BaseEntity
    {
        public int Clave { get; set; }
        public string Cantidad { get; set; }


    }
}

