using System;
using System.Collections.Generic;

namespace ApiLoginFormunica.Models
{
    public partial class Pantalla
    {
        public Pantalla()
        {
            Accions = new HashSet<Accion>();
            ActionsAudits = new HashSet<ActionsAudit>();
            RelacionPantallas = new HashSet<RelacionPantalla>();
        }

        public int IdPantalla { get; set; }
        public string Pantalla1 { get; set; } = null!;
        public int IdEntidad { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? RemoveDate { get; set; }
        public Guid Identificador { get; set; }
        public bool? Status { get; set; }

        public virtual Entidade IdEntidadNavigation { get; set; } = null!;
        public virtual ICollection<Accion> Accions { get; set; }
        public virtual ICollection<ActionsAudit> ActionsAudits { get; set; }
        public virtual ICollection<RelacionPantalla> RelacionPantallas { get; set; }
    }
}
