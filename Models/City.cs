using System;
using System.Collections.Generic;

namespace ApiLoginFormunica.Models
{
    public partial class City
    {
        public City()
        {
            Accions = new HashSet<Accion>();
            Branches = new HashSet<Branch>();
        }

        public int IdCity { get; set; }
        public string City1 { get; set; } = null!;
        public int IdCountry { get; set; }
        public bool? Status { get; set; }
        public DateTime? CreationTime { get; set; }
        public DateTime? RemoveDate { get; set; }

        public virtual Country IdCountryNavigation { get; set; } = null!;
        public virtual ICollection<Accion> Accions { get; set; }
        public virtual ICollection<Branch> Branches { get; set; }
    }
}
