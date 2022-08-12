using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLoginFormunica.Models;
using ApiLoginFormunica.Models.Dto;
using Common.Extensions;
using Common.Paginado;
using Common.Util;
using static ApiLoginFormunica.Models.Dto.TypeContactDto;

namespace ApiLoginFormunica.Services
{
    public interface ITypeContactService
    {
        PaginaCollection<ListTypeContact> ListarTipoContacto (TypeContactDto param);
        Task CrearTipoContacto(CreateTypeContact obj);
    }
    public class TypeContactService:ITypeContactService
    {
        private readonly ApiSecFormunicaContext _context;
        public TypeContactService(ApiSecFormunicaContext context)
        {
            this._context=context;
        }

        public PaginaCollection<ListTypeContact> ListarTipoContacto (TypeContactDto param)
        {
            var data = _context.TypeContacts.Where(w => 
                (param.IdTypeContact.IsNullOrDefault()||w.IdTypeContact==param.IdTypeContact)
                && (param.TypeContact.IsNullOrEmpty()||w.TypeContact1.ToUpper().Contains(param.TypeContact.ToUpper()))
            ).Select(s => new ListTypeContact
            {
                IdTypeContact=s.IdTypeContact,
                TypeContact=s.TypeContact1,
                Status=s.Status==true?"Activo":"Inactivo"
            }).Paginar(param.pagina,param.registroPorPagina);

            return data;
        }

        public async Task CrearTipoContacto(CreateTypeContact obj)
        {
            TypeContact typeContact = Mapper<CreateTypeContact,TypeContact>.Map(obj);

            await _context.TypeContacts.AddAsync(typeContact);
            await _context.SaveChangesAsync();

        }
    }
}