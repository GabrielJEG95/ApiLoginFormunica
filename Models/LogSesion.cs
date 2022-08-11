using System;
using System.Collections.Generic;

namespace ApiLoginFormunica.Models
{
    public partial class LogSesion
    {
        public int IdLogSesion { get; set; }
        public int? IdUsers { get; set; }
        public int? IdEntidad { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
