using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Paginado;

namespace ApiLoginFormunica.Models.Dto
{
    public class ActionAuditDto:Paginado
    {
        public ActionAuditDto()
        {
            OrdenarPor="IdActionsAudit";
            OrientarPor="DESC";
        }

        public int? IDUsers {get;set;}
        public int? IdPantalla {get;set;}

        private string _ordenarPor{get;set;}
        public new string OrdenarPor
        {
            get {return _ordenarPor;}
            set {_ordenarPor =value;}
        }

        public class ListAudit
        {
            public int IdActionsAudit {get;set;}
            public string Accion {get;set;}
            public string Pantalla {get;set;}
            public string Entidad {get;set;}
            public string User {get;set;}
            public DateTime CreationDate {get;set;}
            
        }
        public class CreateAudit
        {
            public int IdAccion {get;set;}
            public int IdPantalla {get;set;}
            public int IdEntidad {get;set;}
            public int IdUser {get;set;}
            public DateTime CreationDate =>DateTime.Now;
        }
    }
}