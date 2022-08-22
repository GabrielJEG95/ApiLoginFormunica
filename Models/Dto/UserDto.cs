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

        public class userCountry:ListUsers
        {
            public List<CountryUser> countryUsers {get;set;}
        }

        public class CountryUser 
        {
            public int IdCountry {get;set;}
            public string Country {get;set;}
        }
        public class userEntidades:ListUsers
        {
            public List<EntidadUser> entidadUsers {get;set;}
        }
        public class EntidadUser
        {
            public int IdEntidad {get;set;}
            public string Entidad {get;set;}
            public string Photo {get;set;}
            public string url {get;set;}
        }

        public class userPantallas:ListUsers
        {
            public List<PantallaUser> pantallaUsers {get;set;}
        }
        public class PantallaUser
        {
            public int IdPantalla {get;set;}
            public string Pantalla {get;set;}
            public string Entidad {get;set;}
        }
        
    }
}