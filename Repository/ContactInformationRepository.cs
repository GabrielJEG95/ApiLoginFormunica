using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLoginFormunica.Models;

namespace ApiLoginFormunica.Repository
{
   
    public class ContactInformationRepository
    {
        private readonly ApiSecFormunicaContext _context;
        public ContactInformationRepository(ApiSecFormunicaContext context)
        {
            this._context=context;
        }

        public ContactInformation ObtenerContactInformation(int IdContactInformation)
        {
            ContactInformation contactInformation = _context.ContactInformations.Find(IdContactInformation);
            if(contactInformation==null || !contactInformation.Status)
                return null;
            return contactInformation;
        }

        public bool ValidaContactInfo(int IdContactInformation)
        {
            ContactInformation contactInformation = _context.ContactInformations.Find(IdContactInformation);
            if(!contactInformation.Status)
                return false;
            return true;
        }
    }
}