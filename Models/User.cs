using System;
using System.Collections.Generic;

namespace ApiLoginFormunica.Models
{
    public partial class User
    {
        public int IdUsers { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int IdPerson { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? RemoveDate { get; set; }
        public string? Token { get; set; }
        public bool? Status { get; set; }

        public virtual Person IdPersonNavigation { get; set; } = null!;
    }
}
