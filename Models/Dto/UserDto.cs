using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Paginado;

namespace ApiLoginFormunica.Models.Dto
{
    public class UserDto:Paginado
    {
        public UserDto()
        {
            OrdenarPor="IdUsers";
            OrientarPor="DESC";
        }

        public int? IdUsers {get;set;}
        public string? Token {get;set;}
        public string? Name {get;set;}
        private string _ordenarPor{get;set;}
        public new string OrdenarPor
        {
            get {return _ordenarPor;}
            set {_ordenarPor =value;}
        }

        
        public class ListUsers
        {
            public int IdUsers {get;set;}
            public string UserName {get;set;}
            public string Email {get;set;}
            public string Name {get;set;}
            public string LastName {get;set;}
            public int WorkerCode {get;set;}
            public DateTime CreationDate {get;set;}
            public string Status {get;set;}
            
        }

        public class createUsers
        {
            public string UserName {get;set;}
            public string Email {get;set;}
            public int IdPerson {get;set;}
            public DateTime CreationDate => DateTime.Now;
            public bool Status => true;
        }
        
    }
}