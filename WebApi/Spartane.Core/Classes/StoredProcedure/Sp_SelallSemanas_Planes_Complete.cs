﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSemanas_Planes_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public string Semana { get; set; }
        public int? Semanas_del_mes { get; set; }

    }
}
