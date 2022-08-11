using System;
using System.Collections.Generic;

namespace ApiLoginFormunica.Models
{
    public partial class ContactInformation
    {
        public int IdContactInformation { get; set; }
        public int? CodePhone { get; set; }
        public int? Phone { get; set; }
        public string? Email { get; set; }
        public int TypeContact { get; set; }
        public int Person { get; set; }
        public DateTime? CreationDate { get; set; }
        public bool Status { get; set; }

        public virtual Person PersonNavigation { get; set; } = null!;
        public virtual TypeContact TypeContactNavigation { get; set; } = null!;
    }
}
