using System;
using System.Collections.Generic;

namespace ApiLoginFormunica.Models
{
    public partial class Entidade
    {
        public Entidade()
        {
            Pantallas = new HashSet<Pantalla>();
        }

        public int IdEntidad { get; set; }
        public string Entidad { get; set; } = null!;
        public Guid Identificador { get; set; }
        public string Url { get; set; } = null!;
        public byte[]? Photo { get; set; }
        public bool? Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? RemoveDate { get; set; }

        public virtual ICollection<Pantalla> Pantallas { get; set; }
    }
}
