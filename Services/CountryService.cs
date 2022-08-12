using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLoginFormunica.Models;
using ApiLoginFormunica.Models.Dto;
using Common.Extensions;
using Common.Paginado;
using Common.Util;
using static ApiLoginFormunica.Models.Dto.CountryDto;

namespace ApiLoginFormunica.Services
{
    public interface ICountryService
    {
        PaginaCollection<ListCountry> listarPaises (CountryDto param);
        Task crearPais(CreateCountry obj);
        Task asociarPaisUsuario (asociarPais obj);
    }
    public class CountryService:ICountryService
    {
        private readonly ApiSecFormunicaContext _context;
        public CountryService(ApiSecFormunicaContext context)
        {
            this._context=context;
        }

        public PaginaCollection<ListCountry> listarPaises (CountryDto param)
        {
            var data = _context.Countries.Where(w => 
                (param.IdCountry.IsNullOrDefault()||w.IdCountry==param.IdCountry)
            && (param.Country.IsNullOrEmpty()||w.Country1.ToUpper().Contains(param.Country.ToUpper()))
            ).Select(s => new ListCountry
            {
                IdCountry=s.IdCountry,
                Country=s.Country1,
                CreationDate=(DateTime)s.CreationDate,
                Status=s.Status==true?"Activo":"Inactivo"
            }).Paginar(param.pagina,param.registroPorPagina);

            return data;
        }

        public async Task crearPais(CreateCountry obj)
        {
            Country country = Mapper<CreateCountry,Country>.Map(obj);
            await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();
        }

        public async Task asociarPaisUsuario (asociarPais obj)
        {
            RelacionPaise relacionPaise = Mapper<asociarPais,RelacionPaise>.Map(obj);
            await _context.RelacionPaises.AddAsync(relacionPaise);
            await _context.SaveChangesAsync();
        }
    }
}