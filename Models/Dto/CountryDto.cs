using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Paginado;

namespace ApiLoginFormunica.Models.Dto
{
    public class CountryDto:Paginado
    {
        public CountryDto()
        {
            OrdenarPor="IdCountry";
            OrientarPor="DESC";
        }

        public int? IdCountry {get;set;}
        public string? Country {get;set;}
        private string _ordenarPor{get;set;}
        public new string OrdenarPor
        {
            get {return _ordenarPor;}
            set {_ordenarPor =value;}
        }

        public class ListCountry
        {
            public int IdCountry {get;set;}
            public string Country {get;set;}
            public DateTime CreationDate {get;set;}
            public string Status {get;set;}
        }

        public class CreateCountry
        {
            public string Country1 {get;set;}
            public bool Status => true;
            public DateTime CreationDate => DateTime.Now;
        }

        public class asociarPais
        {
            public int IdCountry {get;set;}
            public int IdUsers {get;set;}
            public bool Status => true;
        }
    }
}