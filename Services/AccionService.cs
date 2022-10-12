using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLoginFormunica.Models;
using ApiLoginFormunica.Models.Dto;
using Common.Extensions;
using Common.Paginado;
using Common.Util;
using static ApiLoginFormunica.Models.Dto.AccionDto;

namespace ApiLoginFormunica.Services
{
    public interface IAccionService
    {
        PaginaCollection<ListAccion> ListarAcciones (AccionDto param);
        Task crearAccion (createAction obj);
        Task asociarAccion(asocirAcciones obj);
    }
    public class AccionService:IAccionService
    {
        private readonly ApiSecFormunicaContext _context;
        public AccionService(ApiSecFormunicaContext context)
        {
            this._context=context;
        }

        public PaginaCollection<ListAccion> ListarAcciones (AccionDto param)
        {
            var data = _context.Accions.Where(w => 
                (param.IdAccion.IsNullOrDefault()||w.IdAccion==param.IdAccion)
            &&  (param.Accion.IsNullOrEmpty()||w.Accion1.ToUpper().Contains(param.Accion.ToUpper()))
            &&  (param.IdEntidad.IsNullOrDefault()|| w.IdPantallaNavigation.IdEntidadNavigation.IdEntidad == param.IdEntidad)
            ).Select(s => new ListAccion
            {
                IdAccion=s.IdAccion,
                Accion=s.Accion1,
                Pantalla=s.IdPantallaNavigation.Pantalla1,
                City=s.IdCityNavigation.City1,
                Entidad=s.IdPantallaNavigation.IdEntidadNavigation.Entidad,
                Identificador=(Guid)s.Identificador,
                Status=s.Status==true?"Activo":"Inactivo",
                CreationDate=(DateTime)s.CreationDate

            }).Paginar(param.pagina,param.registroPorPagina);

            return data;
        }

        public async Task crearAccion (createAction obj)
        {
            Accion accion = Mapper<createAction,Accion>.Map(obj);
            await _context.Accions.AddAsync(accion);
            await _context.SaveChangesAsync();
        }

        public async Task asociarAccion(asocirAcciones obj)
        {
            RelacionAccione relacionAccione = Mapper<asocirAcciones,RelacionAccione>.Map(obj);
            await _context.RelacionAcciones.AddAsync(relacionAccione);
            await _context.SaveChangesAsync();
        }
    }
}