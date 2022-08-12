using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Common.Paginado;

namespace ApiLoginFormunica.Models.Dto
{
    public class EntidadDto:Paginado
    {
        public EntidadDto()
        {
            OrdenarPor="IdEntidad";
            OrientarPor="DESC";
        }
        public int? IdEntidad {get;set;}
        public string? Entidad {get;set;}
        private string _ordenarPor{get;set;}
        public new string OrdenarPor
        {
            get {return _ordenarPor;}
            set {_ordenarPor =value;}
        }

        public class ListEntidades
        {
            public int IdEntidad {get;set;}
            public string Entidad {get;set;}
            public Guid Identificador {get;set;}
            public string Url {get;set;}
            public DateTime Creationdate {get;set;}
            public string Status {get;set;}
            public string Photo {get;set;}
        }
        public class CreateEntidades
        {
            [Required(ErrorMessage = "Favor ingresar el nombre de la entidad")]
            public string Entidad {get;set;}
            [JsonIgnore]
            public Guid? Identificador => Guid.NewGuid();
            public string Url {get;set;}
            public IFormFile Image {get;set;}
            [JsonIgnore]
            public byte[]? Photo {get;set;}
            public bool Status => true;
            public DateTime CreationDate => DateTime.Now;
        }

        public class asociarEntidad
        {
            [Required(ErrorMessage = "Debe seleccionar una entidad")]
            public int IdEntidad {get;set;}
            [Required(ErrorMessage = "Debe seleccionar un usuario al cual asignarle la entidad")]
            public int IdUsers {get;set;}
            public DateTime CreationDate => DateTime.Now;
            public bool Status => true;
        }
    }

    public class UpdateEntidad
    {
        public string? Url {get;set;}
        public byte[]? Photo {get;set;}
        public IFormFile? Image {get;set;}
    }

    public partial class EntidadUpdate
    {
        public static Entidade Map(Entidade original,UpdateEntidad upt)
        {
            original.Url=upt.Url;
            original.Photo=upt.Photo;

            return original;
        }
    }
}