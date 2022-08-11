using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Common.Paginado;

namespace ApiLoginFormunica.Models.Dto
{
    public class PersonDto:Paginado
    {
        public PersonDto()
        {
            OrdenarPor="IdPerson";
            OrientarPor="DESC";
        }
        public int? IdPerson {get;set;}
        public int? WorkerCode {get;set;}
        public string Name {get;set;}
        private string _ordenarPor{get;set;}
        public new string OrdenarPor
        {
            get {return _ordenarPor;}
            set {_ordenarPor =value;}
        }

        public class ListPerson
        {
            public int IdPerson {get;set;}
            public string Name {get;set;}
            public string LasName {get;set;}
            public int WorkerCode {get;set;}
            public DateTime CreationDate {get;set;}
            public string Status {get;set;}
        }

        public class CreatePerson
        {
            [Required(ErrorMessage = "El campo nombre es obligatorio")]
            public string Name {get;set;}
            [Required(ErrorMessage = "El campo Apellido es obligatorio")]
            public string LasName {get;set;}
            [Required(ErrorMessage = "El numero de trabajador es obligatorio")]
            [MinLength(1)]
            [Range(1,20000)]
            public int WorkerCode {get;set;}
            public DateTime CreationDate => DateTime.Now;
            public bool Status =>true;
            public List<Information> information {get;set;}
        }

        public class Information
        {
            public int? CodePhone {get;set;}
            public int? Phone {get;set;}
            public string Email {get;set;}
            public int TypeContact {get;set;}
            [JsonIgnore]
            public int Person {get;set;}
            public DateTime CreationDate => DateTime.Now;
            public bool Status => true;
        }
    }
}