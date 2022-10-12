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
using static ApiLoginFormunica.Models.Dto.EntidadDto;

namespace ApiLoginFormunica.Services
{
    public interface IEntidadService
    {
        PaginaCollection<ListEntidades> ListarEntidades(EntidadDto param);
        PaginaCollection<EntidadPantalla> ListarPantallaEntidades(EntidadDto param);
        Task CrearEntidad (CreateEntidades obj);
        void EliminarEntidad (int IdEntidad);
        void ActualizarEntidad (int IdEntidad,UpdateEntidad obj);
        Task asociarEntidadUsuario(asociarEntidad obj);
    }
    public class EntidadService:IEntidadService
    {
        private readonly ApiSecFormunicaContext _context;
        private EntidadRepository _entidadRepository;
        public EntidadService(ApiSecFormunicaContext context)
        {
            this._context=context;
            this._entidadRepository = new EntidadRepository(context);
        }
        public PaginaCollection<ListEntidades> ListarEntidades(EntidadDto param)
        {
            var data = _context.Entidades.Where(w => 
                (param.IdEntidad.IsNullOrDefault()|| w.IdEntidad==param.IdEntidad)
            &&  (param.Entidad.IsNullOrEmpty()||w.Entidad.ToUpper().Contains(param.Entidad.ToUpper()))
            ).Select(s => new ListEntidades
            {
                IdEntidad=s.IdEntidad,
                Entidad=s.Entidad,
                Identificador=(Guid)s.Identificador,
                Url=s.Url,
                Status= s.Status==true?"Activo":"Inactivo",
                Creationdate=(DateTime) s.CreationDate,
                Photo=s.Photo!=null?"data:image/png;base64,"+Convert.ToBase64String(s.Photo):"data:image/png;base64,"
            }).Paginar(param.pagina,param.registroPorPagina);

            return data;
        }

        public PaginaCollection<EntidadPantalla> ListarPantallaEntidades(EntidadDto param)
        {
            var data = _context.Entidades.Where(w =>
                (param.IdEntidad.IsNullOrDefault() || w.IdEntidad == param.IdEntidad)
            && (param.Entidad.IsNullOrEmpty() || w.Entidad.ToUpper().Contains(param.Entidad.ToUpper()))
            ).Select(s => new EntidadPantalla
            {
                id = s.IdEntidad,
                name = s.Entidad,
                children = _context.Pantallas
                .Where(w => w.IdEntidad == s.IdEntidad)
                .Select(s => new DisplayEntidad
                {
                    id = s.IdPantalla,
                    name = s.Pantalla1,
                    children = _context.Accions
                    .Where(w => w.IdPantalla==s.IdPantalla)
                    .Select(s => new ActionsEntidad
                    {
                        id = s.IdAccion,
                        name = s.Accion1
                    }).ToList()
                }).ToList()
            }).Paginar(param.pagina, param.registroPorPagina);

            return data;
        }
        public async Task CrearEntidad (CreateEntidades obj)
        {
            if(obj.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                await obj.Image.CopyToAsync(ms);
                byte[] image = ms.ToArray();
                obj.Photo= image;
            }
            else
                obj.Photo=null;

            Entidade entidade = Mapper<CreateEntidades,Entidade>.Map(obj);
            
            await _context.Entidades.AddAsync(entidade);
            await _context.SaveChangesAsync();
        }

        public void ActualizarEntidad (int IdEntidad,UpdateEntidad obj)
        {
            Entidade entidade = BuscarEntidad(IdEntidad);
            if(obj.Image !=null)
            {
                MemoryStream ms = new MemoryStream();
                obj.Image.CopyTo(ms);
                byte[] image = ms.ToArray();
                obj.Photo=image;
            }
            
            entidade = EntidadUpdate.Map(entidade,obj);
            _context.Entidades.Update(entidade);
            _context.SaveChanges();
        }

        public void EliminarEntidad (int IdEntidad)
        {
            Entidade entidade = BuscarEntidad(IdEntidad);
            entidade.Status=false;
            _context.Entidades.Update(entidade);
            _context.SaveChanges();
        }

        public Entidade BuscarEntidad(int IdEntidad)
        {
            Entidade entidade = _entidadRepository.ObtenerEntidad(IdEntidad);
            if(entidade==null)
                throw new HttpStatusException(System.Net.HttpStatusCode.NotFound,"No se encontro el sistem solicitado"); 
            return entidade;
        }

        public async Task asociarEntidadUsuario(asociarEntidad obj)
        {
            RelacionEntidade relacionEntidade = Mapper<asociarEntidad,RelacionEntidade>.Map(obj);
            await _context.RelacionEntidades.AddAsync(relacionEntidade);
            await _context.SaveChangesAsync();
        }
    }
}