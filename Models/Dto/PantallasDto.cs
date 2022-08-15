using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Common.Paginado;

namespace ApiLoginFormunica.Models.Dto
{
    public class PantallasDto:Paginado
    {
        public PantallasDto()
        {
            OrdenarPor="IdPantalla";
            OrientarPor="DESC";
        }

        public int? IdPantalla {get;set;}
        public string? Pantalla {get;set;}
        public int? IdEntidad {get;set;}
        private string _ordenarPor{get;set;}
        public new string OrdenarPor
        {
            get {return _ordenarPor;}
            set {_ordenarPor =value;}
        }

        public class ListPantalla
        {
            public int IdPantalla {get;set;}
            public string Pantalla {get;set;}
            public string Entidad {get;set;}
            public Guid Identifier {get;set;}
            public DateTime CreationDate {get;set;}
            public string Status {get;set;}
        }

        public class cretePantalla
        {
            [Required(ErrorMessage = "El nombre de la pantalla es obligatorio")]
            public string Pantalla1 {get;set;}
            [Required(ErrorMessage = "Debe seleccionar una entidad")]
            public int IdEntidad {get;set;}
            [JsonIgnore]
            public Guid Identificador => Guid.NewGuid();
            [JsonIgnore]
            public bool Status => true;
            [JsonIgnore]
            public DateTime CreationDate => DateTime.Now;
        }

        public class asociarPantalla
        {
            public int IdPantalla {get;set;}
            public int IdUsers {get;set;}
            [JsonIgnore]
            public DateTime CreationDate => DateTime.Now;
            [JsonIgnore]
            public bool Status => true;
        }
    }
}