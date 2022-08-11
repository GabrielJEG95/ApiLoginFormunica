using System;
using System.Collections.Generic;

namespace ApiLoginFormunica.Models
{
    public partial class ActionsAudit
    {
        public int IdActionsAudit { get; set; }
        public Guid IdAccion { get; set; }
        public Guid IdPantalla { get; set; }
        public Guid IdEntidad { get; set; }
        public int IdUser { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
