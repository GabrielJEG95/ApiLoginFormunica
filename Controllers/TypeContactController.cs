using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLoginFormunica.Models.Dto;
using ApiLoginFormunica.Services;
using Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using static ApiLoginFormunica.Models.Dto.TypeContactDto;

namespace ApiLoginFormunica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypeContactController : ControllerBase
    {
        private readonly ITypeContactService _typeContactService;
        public TypeContactController(ITypeContactService typeContactService)
        {
            this._typeContactService=typeContactService;
        }

        [HttpGet]
        public IActionResult GetTypeContact([FromQuery] TypeContactDto param)
        {
            try
            {
                var data = _typeContactService.ListarTipoContacto(param);
                return Ok(data);
            }
            catch (System.Exception ex)
            {
                var error = RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode,error);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostTypeContact ([FromBody] CreateTypeContact obj)
        {
            try
            {
                await _typeContactService.CrearTipoContacto(obj);
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