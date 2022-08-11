using System;
using System.Collections.Generic;

namespace Common.Services.Models
{

    public class UsuarioDto
    {
        public Guid FilaGuid { get; set; }
        public int IdUsuario { get; set; }
        public int IdPersona { get; set; }
        public string Usuario { get; set; }
        public string NombreCompleto { get; set; }
        public int IdTipoUsuario { get; set; }
        public String TipoUsuario { get; set; }
        public int CodigoTrabajador { get; set; }
        public bool Interno { get; set; }

        public IList<EntidadRoles> EntidadRoles { get; set; }

    }
    public class EntidadRoles
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public IEnumerable<RolDto> Roles { get; set; }
    }
    public class RolDto
    {
        public int IdRol { get; set; }
        public string Rol { get; set; }
    }

    public class Empleado
    {
        public string Area { get; set; }
        public string Cargo { get; set; }
        public string Foto { get; set; }
        public string Permanencia { get; set; }
        public string Estado { get; set; }
        public string CorreoInstitucional { get; set; }
    }
}

