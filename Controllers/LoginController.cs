using ApiLoginFormunica.Services;
using Common.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;

namespace ApiLoginFormunica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            this._loginService = loginService;
        }

        [HttpGet("/get/authorization/code")]
        public IActionResult GetCode()
        {
            try
            {
                string URL = _loginService.ObtenerCodigo();

                return Ok(URL);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("/authentication/login")]
        public async Task<IActionResult> GetToken([FromQuery] string code,string state)
        {
            try
            {
                string data = Convert.ToString(await _loginService.ObtenerToken(code, state)) ;
                return Ok(data);
            }
            catch (Exception ex)
            {
                var error = RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode,error);
            }
        }

        
        
    }
}
