using System;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using Common.Referencia;

namespace Common.Services.Models
{
    public class ConsultaPermiso
    {

        public ConsultaPermiso()
        {

        }
        public ConsultaPermiso(IConfiguration configuration)
        {
            this.Sistema = configuration["Sistema:ClaveSecreta"];
        }
        //Sistema
        public string Sistema { get; set; }

        [Required]
        public string Entidad { get; set; }
        public string[] Entidades { get; set; }
        [Required]
        public string Accion { get; set; }
        [Required]
        public string Pantalla { get; set; }

        public string Detalle { get; set; }
    }
    public class AuditoriaModel : ConsultaPermiso
    {
        public AuditoriaModel()
        {

        }
        public AuditoriaModel(IConfiguration configuration) : base(configuration)
        {

        }


    }

}