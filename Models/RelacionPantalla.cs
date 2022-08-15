using System;
using System.Collections.Generic;

namespace ApiLoginFormunica.Models
{
    public partial class RelacionPantalla
    {
        public int IdRelationPantalla { get; set; }
        public int IdUsers { get; set; }
        public int IdPantalla { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? RemoveDate { get; set; }
        public bool? Status { get; set; }

        public virtual Pantalla IdPantallaNavigation { get; set; } = null!;
        public virtual User IdUsersNavigation { get; set; } = null!;
    }
}
