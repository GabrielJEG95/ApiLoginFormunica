using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLoginFormunica.Models.Dto;
using ApiLoginFormunica.Services;
using Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using static ApiLoginFormunica.Models.Dto.EntidadDto;

namespace ApiLoginFormunica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntidadController : ControllerBase
    {
        private readonly IEntidadService _entidadService;
        public EntidadController(IEntidadService entidadService)
        {
            this._entidadService=entidadService;
        }

        [HttpGet]
        public IActionResult GetEntidades ([FromQuery] EntidadDto param)
        {
            try
            {
                var data = _entidadService.ListarEntidades(param);
                return Ok(data);
            }
            catch (System.Exception ex)
            {
                var error = RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode,error);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostEntidad ([FromForm] CreateEntidades obj)
        {
            try
            {
                await _entidadService.CrearEntidad(obj);
                return Ok(RespuestaModel.CreacionExitosa());
            }
            catch (System.Exception ex)
            {
                var error = RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode,error);
            }
        }

        [HttpPost("/api/users/entidades")]
        public async Task<IActionResult> PostRelacionEntidades([FromBody] asociarEntidad obj)
        {
            try
            {
                await _entidadService.asociarEntidadUsuario(obj);
                return Ok(RespuestaModel.CreacionExitosa());
            }
            catch (System.Exception ex)
            {
                var error = RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode,error);
            }
        }

        [HttpPut("{IdEntidad:int}")]
        public IActionResult PutEntidad (int IdEntidad, [FromForm] UpdateEntidad obj)
        {
            try
            {
                _entidadService.ActualizarEntidad(IdEntidad,obj);
                return Ok(RespuestaModel.ActualizacionExitosa());
            }
            catch (System.Exception ex)
            {
                var error = RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode,error);
            }
        }

        [HttpDelete("{IdEntidad:int}")]
        public IActionResult DeleteEntidad (int IdEntidad)
        {
            try
            {
                _entidadService.EliminarEntidad(IdEntidad);
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