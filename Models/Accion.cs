using System;
using System.Collections.Generic;

namespace ApiLoginFormunica.Models
{
    public partial class Accion
    {
        public Accion()
        {
            RelacionAcciones = new HashSet<RelacionAccione>();
        }

        public int IdAccion { get; set; }
        public string Accion1 { get; set; } = null!;
        public int IdPantalla { get; set; }
        public int IdCity { get; set; }
        public Guid Identificador { get; set; }
        public bool? Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? RemoveDate { get; set; }

        public virtual City IdCityNavigation { get; set; } = null!;
        public virtual Pantalla IdPantallaNavigation { get; set; } = null!;
        public virtual ICollection<RelacionAccione> RelacionAcciones { get; set; }
    }
}
