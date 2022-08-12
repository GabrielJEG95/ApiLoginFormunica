using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLoginFormunica.Models;
using ApiLoginFormunica.Models.Dto;
using Common.Extensions;
using Common.Paginado;
using Common.Util;
using static ApiLoginFormunica.Models.Dto.PersonDto;

namespace ApiLoginFormunica.Services
{
    public interface IPersonInterface
    {
        PaginaCollection<ListPerson> ListarPersonas (PersonDto param);
        Task CrearPersona(CreatePerson obj);
    }
    public class PersonInterface:IPersonInterface
    {
        private readonly ApiSecFormunicaContext _context;
        public PersonInterface(ApiSecFormunicaContext context)
        {
            this._context=context;
        }

        public PaginaCollection<ListPerson> ListarPersonas (PersonDto param)
        {
            var data = _context.People.Where(w => 
                (param.IdPerson.IsNullOrDefault()||w.IdPerson==param.IdPerson)
                &&(param.WorkerCode.IsNullOrDefault()||w.WorkerCode==param.WorkerCode)
                &&(param.Name.IsNullOrEmpty()||w.Name.ToUpper().Contains(param.Name.ToUpper()))
            ).Select(s => new ListPerson
            {
                IdPerson=s.IdPerson,
                Name=s.Name,
                LastName=s.LastName,
                WorkerCode=(int)s.WorkerCode,
                CreationDate=(DateTime)s.CreationDate,
                Status=s.Status==true?"Activo":"Inactivo",
                informationC=_context.ContactInformations
                .Where(w => w.Person==s.IdPerson)
                .Select(s => new InformationC {
                    CodePhone=s.CodePhone,
                    Phone=s.Phone,
                    Email=s.Email,
                    Type=s.TypeContactNavigation.TypeContact1,
                    CreationDate=(DateTime)s.CreationDate,
                    Status=s.Status==true?"Activo":"Inactivo"
                    })
                .ToList()
            }).Paginar(param.pagina,param.registroPorPagina);

            return data;
        }

        public async Task CrearPersona(CreatePerson obj)
        {
            
            Person person = Mapper<CreatePerson,Person>.Map(obj);
            ContactInformation contactInformation = new ContactInformation();
            _context.People.Add(person);
            await _context.SaveChangesAsync();

            contactInformation.Person=person.IdPerson;
            var information = from s in obj.information select s;
            
            foreach(var item in information)
            {
                contactInformation.IdContactInformation=0;
                contactInformation.CodePhone=item.CodePhone;
                contactInformation.Phone=item.Phone;
                contactInformation.Email=item.Email;
                contactInformation.TypeContact=item.TypeContact;
                contactInformation.CreationDate=item.CreationDate;
                contactInformation.Status=item.Status;

                _context.ContactInformations.Add(contactInformation);
                await _context.SaveChangesAsync();
            }
        }
    }
}