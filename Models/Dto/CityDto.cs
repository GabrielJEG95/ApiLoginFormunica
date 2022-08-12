using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Paginado;

namespace ApiLoginFormunica.Models.Dto
{
    public class CityDto:Paginado
    {
        public CityDto()
        {
            OrdenarPor="IdCity";
            OrientarPor="DESC";
        }

        public int? IdCity {get;set;}
        public int? IdCountry {get;set;}
        public string? City {get;set;}
        private string _ordenarPor{get;set;}
        public new string OrdenarPor
        {
            get {return _ordenarPor;}
            set {_ordenarPor =value;}
        }

        public class ListCity 
        {
            public int IdCity {get;set;}
            public string City {get;set;}
            public string Country {get;set;}
            public string status {get;set;}
            public DateTime CreationTime {get;set;}
        }

        public class CreateCity
        {
            public string City1 {get;set;}
            public int IdCountry {get;set;}
            public bool status =>true;
            public DateTime CreationTime => DateTime.Now;
        }
    }
}