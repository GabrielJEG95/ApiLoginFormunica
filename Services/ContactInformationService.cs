using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLoginFormunica.Models;
using ApiLoginFormunica.Models.Dto;
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
    }
    public class ContactInformationService:IContactInformationService
    {
        private readonly ApiSecFormunicaContext _context;
        public ContactInformationService(ApiSecFormunicaContext context)
        {
            this._context=context;
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
    }
}