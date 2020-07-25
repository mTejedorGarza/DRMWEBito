﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_BR_Operation_DetailModel
    {
        [Required]
        public int OperationDetailId { get; set; }
        public short? Operation { get; set; }
        public string OperationDescription { get; set; }

    }
}

