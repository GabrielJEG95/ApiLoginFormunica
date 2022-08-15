using System;
using System.Collections.Generic;

namespace ApiLoginFormunica.Models
{
    public partial class ActionsAudit
    {
        public int IdActionsAudit { get; set; }
        public int IdAccion { get; set; }
        public int IdPantalla { get; set; }
        public int IdEntidad { get; set; }
        public int IdUser { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual Accion IdAccionNavigation { get; set; } = null!;
        public virtual Entidade IdEntidadNavigation { get; set; } = null!;
        public virtual Pantalla IdPantallaNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
