using System;
using System.Collections.Generic;

namespace ApiLoginFormunica.Models
{
    public partial class User
    {
        public User()
        {
            ActionsAudits = new HashSet<ActionsAudit>();
            RelacionAcciones = new HashSet<RelacionAccione>();
            RelacionEntidades = new HashSet<RelacionEntidade>();
            RelacionPaises = new HashSet<RelacionPaise>();
            RelacionPantallas = new HashSet<RelacionPantalla>();
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
        public virtual ICollection<ActionsAudit> ActionsAudits { get; set; }
        public virtual ICollection<RelacionAccione> RelacionAcciones { get; set; }
        public virtual ICollection<RelacionEntidade> RelacionEntidades { get; set; }
        public virtual ICollection<RelacionPaise> RelacionPaises { get; set; }
        public virtual ICollection<RelacionPantalla> RelacionPantallas { get; set; }
    }
}
