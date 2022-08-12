using System;
using System.Collections.Generic;
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