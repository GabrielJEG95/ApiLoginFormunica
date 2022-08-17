using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLoginFormunica.Models.Dto;
using ApiLoginFormunica.Services;
using Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using static ApiLoginFormunica.Models.Dto.AccionDto;

namespace ApiLoginFormunica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccionController : ControllerBase
    {
        private readonly  IAccionService _accionService;
        public AccionController(IAccionService accionService)
        {
            this._accionService=accionService;
        }

        [HttpGet]
        public IActionResult GetAction([FromQuery] AccionDto param)
        {
            try
            {
                var data = _accionService.ListarAcciones(param);
                return Ok(data);
            }
            catch (System.Exception ex)
            {
                var error = RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode,error);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAction ([FromBody] createAction obj)
        {
            try
            {   
                await _accionService.crearAccion(obj);
                return Ok(RespuestaModel.CreacionExitosa());
            }
            catch (System.Exception ex)
            {
                var error = RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode,error);
            }
        }

        [HttpPost("/api/users/accion")]
        public async Task<IActionResult> PostAsociarAccion([FromBody] asocirAcciones obj)
        {
            try
            {
                await _accionService.asociarAccion(obj);
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