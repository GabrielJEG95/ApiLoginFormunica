using System;
using System.Collections.Generic;

namespace ApiLoginFormunica.Models
{
    public partial class Branch
    {
        public int IdBranch { get; set; }
        public string Branch1 { get; set; } = null!;
        public Guid Identifier { get; set; }
        public int IdCity { get; set; }
        public bool? Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? RemoveDate { get; set; }

        public virtual City IdCityNavigation { get; set; } = null!;
    }
}
