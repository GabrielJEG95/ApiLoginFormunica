using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using ApiLoginFormunica.Models;
using ApiLoginFormunica.Models.Dto;
using ApiLoginFormunica.Repository;
using Common.Exceptions;
using Common.Extensions;
using Common.Paginado;
using Common.Util;
using Microsoft.IdentityModel.Tokens;
using static ApiLoginFormunica.Models.Dto.UserDto;

namespace ApiLoginFormunica.Services
{
    public interface IUsersService
    {
        PaginaCollection<ListUsers> ListarUsuarios (UserDto param);
        Task CrearUsuario(createUsers obj);
        void EliminarUsuario(int IdUsers);
        PaginaCollection<userCountry> ListarPaisesUsuario (UserDto param);
        PaginaCollection<userEntidades> ListarEntidadesUsuario(UserDto param);
        PaginaCollection<userPantallas> ListarPantallasUsuario(UserDto param);
        
    }
    public class UsersService:IUsersService
    {
        private readonly ApiSecFormunicaContext _context;
        private UserRepository _userRepository;
        public UsersService(ApiSecFormunicaContext context)
        {
            this._context=context;
            this._userRepository=new UserRepository(context);
        }

        public PaginaCollection<ListUsers> ListarUsuarios (UserDto param)
        {
            var data = _context.Users.Where(w => 
                (param.IdUsers.IsNullOrDefault()||w.IdUsers==param.IdUsers)
            &&  (param.Name.IsNullOrEmpty()||w.UserName.ToUpper().Contains(param.Name.ToUpper()))
            ).Select(s => new ListUsers
            {
                IdUsers=s.IdUsers,
                UserName=s.UserName,
                Email=s.Email,
                Name=s.IdPersonNavigation.Name,
                LastName=s.IdPersonNavigation.LastName,
                WorkerCode=(int)s.IdPersonNavigation.WorkerCode,
                CreationDate=(DateTime)s.CreationDate,
                Status=s.Status==true?"Activo":"Inactivo"
            }).Paginar(param.pagina,param.registroPorPagina);

            return data;
        }

        public PaginaCollection<userCountry> ListarPaisesUsuario (UserDto param)
        {
            var data = _context.Users.Where(w => 
                (param.IdUsers.IsNullOrDefault()||w.IdUsers==param.IdUsers)
            &&  (param.Name.IsNullOrEmpty()||w.UserName.ToUpper().Contains(param.Name.ToUpper()))
            ).Select(s => new userCountry
            {
                IdUsers=s.IdUsers,
                UserName=s.UserName,
                Email=s.Email,
                Name=s.IdPersonNavigation.Name,
                LastName=s.IdPersonNavigation.LastName,
                WorkerCode=(int)s.IdPersonNavigation.WorkerCode,
                CreationDate=(DateTime)s.CreationDate,
                Status=s.Status==true?"Activo":"Inactivo",
                countryUsers=_context.RelacionPaises
                .Where(w => w.Idusers==s.IdUsers)
                .Select(s2 => new CountryUser 
                {
                    IdCountry=s2.IdCountry,
                    Country=s2.IdCountryNavigation.Country1
                }).ToList()
            }).Paginar(param.pagina,param.registroPorPagina);

            return data;
        }

        public PaginaCollection<userEntidades> ListarEntidadesUsuario(UserDto param)
        {
            var data = _context.Users.Where(w => 
                (param.IdUsers.IsNullOrDefault()||w.IdUsers==param.IdUsers)
            &&  (param.Name.IsNullOrEmpty()||w.UserName.ToUpper().Contains(param.Name.ToUpper()))
            ).Select(s => new userEntidades
            {
                IdUsers=s.IdUsers,
                UserName=s.UserName,
                Email=s.Email,
                Name=s.IdPersonNavigation.Name,
                LastName=s.IdPersonNavigation.LastName,
                WorkerCode=(int)s.IdPersonNavigation.WorkerCode,
                CreationDate=(DateTime)s.CreationDate,
                Status=s.Status==true?"Activo":"Inactivo",
                entidadUsers=_context.RelacionEntidades
                .Where(w => w.IdUsers==s.IdUsers)
                .Select(s => new EntidadUser
                {
                    IdEntidad=s.IdEntidad,
                    Entidad=s.IdEntidadNavigation.Entidad
                }).ToList()
            }).Paginar(param.pagina,param.registroPorPagina);

            return data;
        }

        public PaginaCollection<userPantallas> ListarPantallasUsuario(UserDto param)
        {
            var data = _context.Users.Where(w => 
                (param.IdUsers.IsNullOrDefault()||w.IdUsers==param.IdUsers)
            &&  (param.Name.IsNullOrEmpty()||w.UserName.ToUpper().Contains(param.Name.ToUpper()))
            ).Select(s => new userPantallas
            {
                IdUsers=s.IdUsers,
                UserName=s.UserName,
                Email=s.Email,
                Name=s.IdPersonNavigation.Name,
                LastName=s.IdPersonNavigation.LastName,
                WorkerCode=(int)s.IdPersonNavigation.WorkerCode,
                CreationDate=(DateTime)s.CreationDate,
                Status=s.Status==true?"Activo":"Inactivo",
                pantallaUsers=_context.RelacionPantallas
                .Where(w => w.IdUsers==s.IdUsers)
                .Select(s => new PantallaUser
                {
                    IdPantalla=s.IdPantalla,
                    Pantalla=s.IdPantallaNavigation.Pantalla1,
                    Entidad=s.IdPantallaNavigation.IdEntidadNavigation.Entidad
                }).ToList()
            }).Paginar(param.pagina,param.registroPorPagina);

            return data;
        }
        public async Task CrearUsuario(createUsers obj)
        {
            User user = Mapper<createUsers,User>.Map(obj);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public void EliminarUsuario(int IdUsers)
        {
            User user = buscarUsuario(IdUsers);
            user.Status=false;
            user.RemoveDate=DateTime.Now;
            user.Token=null;
            
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public User buscarUsuario(int IdUsers)
        {
            User user = _userRepository.ObtenerUsuario(IdUsers);
            if(user==null)
                throw new HttpStatusException(System.Net.HttpStatusCode.NotFound,"No se encontro el usuario solicitado");
            return user;
        }
    }
}