using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLoginFormunica.Models.Dto;
using ApiLoginFormunica.Services;
using Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using static ApiLoginFormunica.Models.Dto.ActionAuditDto;

namespace ApiLoginFormunica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActionAuditController : ControllerBase
    {
        private readonly IActionAuditService _actionAuditService;
        public ActionAuditController(IActionAuditService actionAuditService)
        {
            this._actionAuditService=actionAuditService;
        }

        [HttpGet]
        public IActionResult GetAudit ([FromQuery] ActionAuditDto param)
        {
            try
            {
                var data = _actionAuditService.ListarAuditoria(param);
                return Ok(data);
            }
            catch (System.Exception ex)
            {
                var error = RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode,error);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAudit([FromBody] CreateAudit obj)
        {
            try
            {
                await _actionAuditService.crearAuditoria(obj);
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