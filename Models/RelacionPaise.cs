﻿using System;
using System.Collections.Generic;

namespace ApiLoginFormunica.Models
{
    public partial class RelacionPaise
    {
        public int IdRelationCountry { get; set; }
        public int IdCountry { get; set; }
        public int Idusers { get; set; }
        public bool? Status { get; set; }
    }
}
