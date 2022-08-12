using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Common.Paginado;

namespace ApiLoginFormunica.Models.Dto
{
    public class ContactInformationDto:Paginado
    {
        public ContactInformationDto()
        {
            OrdenarPor="IdContactInformation";
            OrientarPor="DESC";
        }

        public int? IdContactInformation {get;set;}
        public int? Phone {get;set;}
        public string? Email {get;set;}
        public int? IdPerson {get;set;}
        private string _ordenarPor{get;set;}
        public new string OrdenarPor
        {
            get {return _ordenarPor;}
            set {_ordenarPor =value;}
        }

        public class ListContactInformation
        {
            public int IdContactInformation {get;set;}
            public string CellPhone {get;set;}
            public string Email {get;set;}
            public string TypeContact {get;set;}
            public string Person {get;set;}
            public DateTime CreationDate {get;set;}
            public string Status {get;set;}
        }

        public class CreateContactInformation
        {
            public int? CodePhone {get;set;}
            public int? Phone {get;set;}
            public string Email {get;set;}
            [Required(ErrorMessage = "Debe especificar el tipo de contacto")]
            public int TypeContact {get;set;}
            [Required(ErrorMessage = "Debe seleccionar un colaborador al cual asociar esta información")]
            public int Person {get;set;}
            public DateTime CreationDate => DateTime.Now;
            public bool Status => true;
        }

        public class UpdateContactInformation
        {
            public int? CodePhone {get;set;}
            public int? Phone {get;set;}
            public string Email {get;set;}
        }

        public partial class ContactUpdate
        {
            public static ContactInformation Map(ContactInformation original,UpdateContactInformation upt)
            {
                original.CodePhone=upt.CodePhone;
                original.Phone=upt.Phone;
                original.Email=upt.Email;

                return original;
            }
        }
    }
}