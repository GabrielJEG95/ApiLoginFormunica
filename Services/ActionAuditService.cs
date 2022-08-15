using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLoginFormunica.Models;
using ApiLoginFormunica.Models.Dto;
using Common.Extensions;
using Common.Paginado;
using Common.Util;
using static ApiLoginFormunica.Models.Dto.ActionAuditDto;

namespace ApiLoginFormunica.Services
{
    public interface IActionAuditService
    {
        PaginaCollection<ListAudit> ListarAuditoria(ActionAuditDto param);
        Task crearAuditoria(CreateAudit obj);
    }
    public class ActionAuditService:IActionAuditService
    {
        private readonly ApiSecFormunicaContext _context;
        public ActionAuditService(ApiSecFormunicaContext context)
        {
            this._context=context;
        }

        public PaginaCollection<ListAudit> ListarAuditoria(ActionAuditDto param)
        {
            var data = _context.ActionsAudits.Where(w => 
                (param.IdPantalla.IsNullOrDefault()||w.IdPantalla==param.IdPantalla)
            &&  (param.IDUsers.IsNullOrDefault()||w.IdUser==param.IDUsers)
            ).Select(s => new ListAudit
            {
                IdActionsAudit=s.IdActionsAudit,
                Accion=s.IdAccionNavigation.Accion1,
                Pantalla=s.IdPantallaNavigation.Pantalla1,
                Entidad=s.IdEntidadNavigation.Entidad,
                User=s.IdUserNavigation.UserName+" "+s.IdUserNavigation.Email,
                CreationDate=(DateTime)s.CreationDate
            }).Paginar(param.pagina,param.registroPorPagina);
            
            return data;
        }

        public async Task crearAuditoria(CreateAudit obj)
        {
            ActionsAudit actionsAudit = Mapper<CreateAudit,ActionsAudit>.Map(obj);
            await _context.ActionsAudits.AddAsync(actionsAudit);
            await _context.SaveChangesAsync();
        }
    }
}