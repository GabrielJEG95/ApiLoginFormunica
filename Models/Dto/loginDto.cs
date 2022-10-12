using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiLoginFormunica.Models.Dto
{
    public class loginDto
    {
        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        public string UserName {get;set;}
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Password {get;set;}
    }
}