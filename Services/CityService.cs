using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLoginFormunica.Models;
using ApiLoginFormunica.Models.Dto;
using Common.Extensions;
using Common.Paginado;
using Common.Util;
using static ApiLoginFormunica.Models.Dto.CityDto;

namespace ApiLoginFormunica.Services
{
    public interface ICityService
    {
        PaginaCollection<ListCity> ListarCiudades (CityDto param);
        Task CrearCiudad (CreateCity obj);
    }
    public class CityService:ICityService
    {
        private readonly ApiSecFormunicaContext _context;
        public CityService(ApiSecFormunicaContext context)
        {
            this._context=context;
        }

        public PaginaCollection<ListCity> ListarCiudades (CityDto param)
        {
            var data = _context.Cities.Where(w => 
                (param.IdCity.IsNullOrDefault()||w.IdCity==param.IdCity)
            &&  (param.IdCountry.IsNullOrDefault()||w.IdCountry==param.IdCountry)
            &&  (param.City.IsNullOrEmpty()||w.City1.ToUpper().Contains(param.City.ToUpper()))
            ).Select(s => new ListCity
            {
                IdCity=s.IdCity,
                City=s.City1,
                Country=s.IdCountryNavigation.Country1,
                status=s.Status==true?"Activo":"Inactivo",
                CreationTime=(DateTime)s.CreationTime
            }).Paginar(param.pagina,param.registroPorPagina);
            return data;
        }

        public async Task CrearCiudad (CreateCity obj)
        {
            City city = Mapper<CreateCity,City>.Map(obj);
            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync();
        }
    }
}