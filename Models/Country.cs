using System;
using System.Collections.Generic;

namespace ApiLoginFormunica.Models
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
            RelacionPaises = new HashSet<RelacionPaise>();
        }

        public int IdCountry { get; set; }
        public string Country1 { get; set; } = null!;
        public bool? Status { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? RemoveDate { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<RelacionPaise> RelacionPaises { get; set; }
    }
}
