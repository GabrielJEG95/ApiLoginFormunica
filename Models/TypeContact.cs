using System;
using System.Collections.Generic;

namespace ApiLoginFormunica.Models
{
    public partial class TypeContact
    {
        public TypeContact()
        {
            ContactInformations = new HashSet<ContactInformation>();
        }

        public int IdTypeContact { get; set; }
        public string TypeContact1 { get; set; } = null!;
        public bool Status { get; set; }

        public virtual ICollection<ContactInformation> ContactInformations { get; set; }
    }
}
