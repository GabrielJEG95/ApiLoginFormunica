using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLoginFormunica.Models.Dto;
using ApiLoginFormunica.Services;
using Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using static ApiLoginFormunica.Models.Dto.ContactInformationDto;

namespace ApiLoginFormunica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactInformationController : ControllerBase
    {
        private readonly IContactInformationService _contactInformationService;
        public ContactInformationController(IContactInformationService contactInformationService)
        {
            this._contactInformationService=contactInformationService;
        }

        [HttpGet]
        public IActionResult GetContactInformation ([FromQuery] ContactInformationDto param)
        {
            try
            {
                var data = _contactInformationService.ListarInformacionContacto(param);
                return Ok(data);
            }
            catch (System.Exception ex)
            {
                var error = RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode,error);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostContactInformation ([FromBody] CreateContactInformation obj)
        {
            try
            {
                await _contactInformationService.CrearInformacionContact(obj);
                return Ok(RespuestaModel.CreacionExitosa());
            }
            catch (System.Exception ex)
            {
                var error = RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode,error);
            }
        }

        [HttpPut("{IdContactInformation:int}")]
        public IActionResult PutContactInformation(int IdContactInformation,UpdateContactInformation obj)
        {
            try
            {
                _contactInformationService.ActualizarInformacionContact(IdContactInformation,obj);
                return Ok(RespuestaModel.ActualizacionExitosa());
            }
            catch (System.Exception ex)
            {
                var error = RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode,error);
            }
        }

        [HttpDelete("{IdContactInformation:int}")]
        public IActionResult DeleteContactInformation(int IdContactInformation)
        {
            try
            {
                _contactInformationService.EliminarInformacionContact(IdContactInformation);
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