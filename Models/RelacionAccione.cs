using System;
using System.Collections.Generic;

namespace ApiLoginFormunica.Models
{
    public partial class RelacionAccione
    {
        public int IdRelationAction { get; set; }
        public int IdUsers { get; set; }
        public int IdAccion { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? RemoveDate { get; set; }
        public bool? Status { get; set; }

        public virtual Accion IdAccionNavigation { get; set; } = null!;
        public virtual User IdUsersNavigation { get; set; } = null!;
    }
}
