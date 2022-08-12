using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Paginado;

namespace ApiLoginFormunica.Models.Dto
{
  
    public class TypeContactDto:Paginado
    {
        public TypeContactDto()
        {
            OrdenarPor="IdTypeContact";
            OrientarPor="DESC";
        }

        public int? IdTypeContact {get;set;}
        public string? TypeContact {get;set;}

        private string _ordenarPor{get;set;}
        public new string OrdenarPor
        {
            get {return _ordenarPor;}
            set {_ordenarPor =value;}
        }

        public class ListTypeContact
        {
            public int IdTypeContact {get;set;}
            public string TypeContact {get;set;}
            public string Status {get;set;}
        }

        public class CreateTypeContact
        {
            public string TypeContact1 {get;set;}
            public bool Status => true;
        }

    }
}