using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLoginFormunica.Models;
using ApiLoginFormunica.Models.Dto;
using ApiLoginFormunica.Repository;
using Common.Exceptions;
using Common.Extensions;
using Common.Paginado;
using Common.Util;
using static ApiLoginFormunica.Models.Dto.ContactInformationDto;

namespace ApiLoginFormunica.Services
{
    public interface IContactInformationService
    {
        PaginaCollection<ListContactInformation> ListarInformacionContacto(ContactInformationDto param);
        Task CrearInformacionContact (CreateContactInformation obj);
        void ActualizarInformacionContact (int IdContactInformation, UpdateContactInformation obj);
        void EliminarInformacionContact (int IdContactInformation);
    }
    public class ContactInformationService:IContactInformationService
    {
        private readonly ApiSecFormunicaContext _context;
        private ContactInformationRepository _contactInformationRepository;
        public ContactInformationService(ApiSecFormunicaContext context)
        {
            this._context=context;
            this._contactInformationRepository=new ContactInformationRepository(context);
        }

        public PaginaCollection<ListContactInformation> ListarInformacionContacto(ContactInformationDto param)
        {
            var data = _context.ContactInformations.Where(w => 
                (param.IdContactInformation.IsNullOrDefault()||w.IdContactInformation==param.IdContactInformation)
                &&(param.IdPerson.IsNullOrDefault()||w.Person==param.IdPerson)
            ).Select(s => new ListContactInformation
            {
                IdContactInformation=s.IdContactInformation,
                Person=s.PersonNavigation.Name+" "+s.PersonNavigation.LastName,
                CellPhone="("+s.CodePhone+")"+s.Phone,
                Email=s.Email,
                TypeContact=s.TypeContactNavigation.TypeContact1,
                CreationDate=(DateTime)s.CreationDate,
                Status=s.Status==true?"Activo":"Inactivo"
            }).Paginar(param.pagina,param.registroPorPagina);

            return data;
        }

        public async Task CrearInformacionContact (CreateContactInformation obj)
        {
            ContactInformation contactInformation = Mapper<CreateContactInformation,ContactInformation>.Map(obj);
            await _context.ContactInformations.AddAsync(contactInformation);
            await _context.SaveChangesAsync();
        }

        public void ActualizarInformacionContact (int IdContactInformation, UpdateContactInformation obj)
        {
            ContactInformation contactInformation = ObtenerContactInfo(IdContactInformation);
            contactInformation = ContactUpdate.Map(contactInformation,obj);

            _context.ContactInformations.Update(contactInformation);
            _context.SaveChanges();
        }

        public ContactInformation ObtenerContactInfo(int IdContactInformation)
        {
            ContactInformation contactInformation = _contactInformationRepository.ObtenerContactInformation(IdContactInformation);
            if(contactInformation==null)
                throw new HttpStatusException(System.Net.HttpStatusCode.NotFound,"Información de Contacto no encontrada");
            return contactInformation;
        }

        public void EliminarInformacionContact (int IdContactInformation)
        {
            ContactInformation contactInformation = _contactInformationRepository.ObtenerContactInformation(IdContactInformation);
            if(contactInformation==null)
                throw new HttpStatusException(System.Net.HttpStatusCode.NotFound,"Información de Contacto no encontrada");

            contactInformation.Status=false;
            
            _context.ContactInformations.Update(contactInformation);
            _context.SaveChanges();
        }
    }
}