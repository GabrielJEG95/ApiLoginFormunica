using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLoginFormunica.Models.Dto;
using ApiLoginFormunica.Services;
using Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using static ApiLoginFormunica.Models.Dto.PantallasDto;

namespace ApiLoginFormunica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PantallaController : ControllerBase
    {
        private readonly IPantallaService _pantallaService;
        public PantallaController(IPantallaService pantallaService)
        {
            this._pantallaService=pantallaService;
        }

        [HttpGet]
        public IActionResult GetPantalla ([FromQuery] PantallasDto param)
        {
            try
            {
                var data = _pantallaService.ListarPantallas(param);
                return Ok(data);
            }
            catch (System.Exception ex)
            {
                var error = RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode,error);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostPantalla ([FromBody] cretePantalla obj)
        {
            try
            {
                await _pantallaService.crearPantalla(obj);
                return Ok(RespuestaModel.CreacionExitosa());
            }
            catch (System.Exception ex)
            {
                var error = RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode,error);
            }
        }

        [HttpPost("/api/users/pantalla")]
        public async Task<IActionResult> PostAsociarPantalla([FromBody] asociarPantalla obj)
        {
            try
            {
                await _pantallaService.asociarPantallaUsuario(obj);
                return Ok(RespuestaModel.CreacionExitosa());
            }
            catch (System.Exception ex)
            {
                var error = RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode,error);
            }
        }
    }
}