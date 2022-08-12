using System;
using System.Collections.Generic;

namespace ApiLoginFormunica.Models
{
    public partial class User
    {
        public User()
        {
            RelacionAcciones = new HashSet<RelacionAccione>();
            RelacionEntidades = new HashSet<RelacionEntidade>();
            RelacionPaises = new HashSet<RelacionPaise>();
        }

        public int IdUsers { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int IdPerson { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? RemoveDate { get; set; }
        public string? Token { get; set; }
        public bool? Status { get; set; }

        public virtual Person IdPersonNavigation { get; set; } = null!;
        public virtual ICollection<RelacionAccione> RelacionAcciones { get; set; }
        public virtual ICollection<RelacionEntidade> RelacionEntidades { get; set; }
        public virtual ICollection<RelacionPaise> RelacionPaises { get; set; }
    }
}
