using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Common.Paginado;

namespace ApiLoginFormunica.Models.Dto
{
    public class BranchDto:Paginado
    {
        public BranchDto()
        {
            OrdenarPor="IdBranch";
            OrientarPor="DESC";
        }

        public int? IdBranch {get;set;}
        public string? Branch {get;set;}
        public int? IdCity {get;set;}
        private string _ordenarPor{get;set;}
        public new string OrdenarPor
        {
            get {return _ordenarPor;}
            set {_ordenarPor =value;}
        }

        public class ListBrach
        {
            public int IdBranch {get;set;}
            public string Branch {get;set;}
            public Guid Identifier {get;set;}
            public string City {get;set;}
            public string Status {get;set;}
            public DateTime CreationDate {get;set;}
        }
        public class CreateBranch
        {
            public string Branch1 {get;set;}
            [JsonIgnore]
            public Guid Identifier => Guid.NewGuid();
            public int IdCity {get;set;}
            public bool Status =>true;
            public DateTime CreationDate => DateTime.Now;
        }
    }
}