using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLoginFormunica.Models.Dto;
using ApiLoginFormunica.Services;
using Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using static ApiLoginFormunica.Models.Dto.UserDto;

namespace ApiLoginFormunica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly ILoginService _loginService;
        public UserController(IUsersService usersService,ILoginService loginService)
        {
            this._usersService=usersService;
            this._loginService=loginService;
        }

        [HttpGet]
        public IActionResult GetUser([FromQuery] UserDto param)
        {
            try
            {
                
                var data = _usersService.ListarUsuarios(param);
                return Ok(data);
            }
            catch (System.Exception ex)
            {
                var error = RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode,error);
            }
        }

        [HttpGet("/api/users/id")]
        public IActionResult GetUserById()
        {
            try
            {
                string token = Request.Headers["Authorization"];
                int IdUser = _loginService.getIdUser(token);
                var data = _usersService.ObtenerUsuarioId(IdUser);
                return Ok(data);
            }
            catch (System.Exception ex)
            {
                var error = RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode,error);
            }
        }

        [HttpGet("/api/users/country")]
        public IActionResult GetUserCountry([FromQuery] UserDto param)
        {
            try
            {
                var data = _usersService.ListarPaisesUsuario(param);
                return Ok(data);
            }
            catch (System.Exception ex)
            {
                var error = RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode,error);
            }
        }

        [HttpGet("/api/users/entidades")]
        public IActionResult GetEntidadByUserIdToken ([FromQuery] UserDto param)
        {
            try
            {
                if(param.IdUsers == 0 || param.IdUsers == null)
                {
                    string token = Request.Headers["Authorization"];
                    int IdUser = _loginService.getIdUser(token);
                    param.IdUsers = IdUser;
                }
                
                var data = _usersService.ListarEntidadesUsuario(param);
                return Ok(data);
            }
            catch (System.Exception ex)
            {
                var error = RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode,error);
            }
        }

        [HttpGet("/api/users/pantallas")]
        public IActionResult GetUserPantalla ([FromQuery] UserDto param)
        {
            try
            {
                var data = _usersService.ListarPantallasUsuario(param);
                return Ok(data);
            }
            catch (System.Exception ex)
            {
                var error = RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode,error);
            }
        }

        [HttpGet("/api/users/pantallaEntidad")]
        public IActionResult GetUserPantallEntidad ([FromQuery] UserDto param)
        {
            try
            {
                var data = _usersService.ListarPantallaUsuarioEntidad(param);
                return Ok(data);
            }
            catch (System.Exception ex)
            {
                var error = RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode,error);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] createUsers obj)
        {
            try
            {
                await _usersService.CrearUsuario(obj);
                return Ok(RespuestaModel.CreacionExitosa());
            }
            catch (System.Exception ex)
            {
                var error = RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode,error);
            }
        }

        [HttpDelete("{IdUsers:int}")]
        public IActionResult DeleteUser (int IdUsers)
        {
            try
            {
                _usersService.EliminarUsuario(IdUsers);
                return Ok(RespuestaModel.EliminacionExitosa());
            }
            catch (System.Exception ex)
            {
                var error = RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode,error);
            }
        }
    }
}