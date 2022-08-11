using System;
using System.Collections.Generic;

namespace ApiLoginFormunica.Models
{
    public partial class RelacionEntidade
    {
        public int IdRelationEntidad { get; set; }
        public int IdEntidad { get; set; }
        public int IdUsers { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? RemoveDate { get; set; }
        public bool? Status { get; set; }
    }
}
