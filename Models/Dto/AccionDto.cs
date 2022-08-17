using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Common.Paginado;

namespace ApiLoginFormunica.Models.Dto
{
    public class AccionDto:Paginado
    {
        public AccionDto()
        {
            OrdenarPor="IdAccion";
            OrientarPor="DESC";
        }
        public int? IdAccion {get;set;}
        public string? Accion {get;set;}
        private string _ordenarPor{get;set;}
        public new string OrdenarPor
        {
            get {return _ordenarPor;}
            set {_ordenarPor =value;}
        }

        public class ListAccion
        {
            public int IdAccion {get;set;}
            public string Accion {get;set;}
            public string Pantalla {get;set;}
            public string City {get;set;}
            public Guid Identificador {get;set;}
            public string Status {get;set;}
            public DateTime CreationDate {get;set;}
        }

        public class createAction
        {
            [Required(ErrorMessage = "Favor ingresar el nombre de la acción")]
            public string Accion1 {get;set;}
            [Required(ErrorMessage = "Favor seleccionar la pantalla de referencia")]
            public int IdPantalla {get;set;}
            [Required(ErrorMessage = "Favor seleccioanr la ciudad referente a la accion")]
            public int IdCity {get;set;}
            [JsonIgnore]
            public Guid Identificador => Guid.NewGuid();
            [JsonIgnore]
            public bool Status => true;
            [JsonIgnore]
            public DateTime CreationDate => DateTime.Now;
        }

        public class asocirAcciones
        {
            public int IdUsers {get;set;}
            public int IdAccion {get;set;}
            [JsonIgnore]
            public DateTime CreationDate => DateTime.Now;
            [JsonIgnore]
            public bool Status =>true;
        }
    }
}