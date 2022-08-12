using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLoginFormunica.Models;
using ApiLoginFormunica.Models.Dto;
using Common.Extensions;
using Common.Paginado;
using Common.Util;
using static ApiLoginFormunica.Models.Dto.PantallasDto;

namespace ApiLoginFormunica.Services
{
    public interface IPantallaService
    {
        PaginaCollection<ListPantalla> ListarPantallas (PantallasDto param);
        Task crearPantalla (cretePantalla obj);
    }
    public class PantallaService:IPantallaService
    {
        private readonly ApiSecFormunicaContext _context;
        public PantallaService(ApiSecFormunicaContext context)
        {
            this._context=context;
        }

        public PaginaCollection<ListPantalla> ListarPantallas (PantallasDto param)
        {
            var data = _context.Pantallas.Where(w => 
                (param.IdPantalla.IsNullOrDefault()||w.IdPantalla==param.IdPantalla)
            &&  (param.IdEntidad.IsNullOrDefault()||w.IdEntidad==param.IdEntidad)
            &&  (param.Pantalla.IsNullOrEmpty()||w.Pantalla1.ToUpper().Contains(param.Pantalla.ToUpper()))
            ).Select(s => new ListPantalla
            {
                IdPantalla=s.IdPantalla,
                Pantalla=s.Pantalla1,
                Entidad=s.IdEntidadNavigation.Entidad,
                Identifier=(Guid)s.Identificador,
                Status=s.Status==true?"Activo":"Inactivo",
                CreationDate=(DateTime)s.CreationDate

            }).Paginar(param.pagina,param.registroPorPagina);

            return data;
        }

        public async Task crearPantalla (cretePantalla obj)
        {
            Pantalla pantalla = Mapper<cretePantalla,Pantalla>.Map(obj);
            await _context.Pantallas.AddAsync(pantalla);
            await _context.SaveChangesAsync();
        }
    }
}