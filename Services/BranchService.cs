using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLoginFormunica.Models;
using ApiLoginFormunica.Models.Dto;
using Common.Extensions;
using Common.Paginado;
using Common.Util;
using static ApiLoginFormunica.Models.Dto.BranchDto;

namespace ApiLoginFormunica.Services
{
    public interface IBranchService
    {
        PaginaCollection<ListBrach> ListarSucursales (BranchDto param);
        Task crearSucursal (CreateBranch obj);
    }
    public class BranchService:IBranchService
    {
        private readonly ApiSecFormunicaContext _context;
        public BranchService(ApiSecFormunicaContext context)
        {
            this._context=context;
        }

        public PaginaCollection<ListBrach> ListarSucursales (BranchDto param)
        {
            var data = _context.Branches.Where(w => 
                (param.IdBranch.IsNullOrDefault()||w.IdBranch==param.IdBranch)
            &&  (param.IdCity.IsNullOrDefault()||w.IdCity==param.IdCity)
            &&  (param.Branch.IsNullOrEmpty()||w.Branch1.ToUpper().Contains(param.Branch.ToUpper()))
            ).Select(s => new ListBrach
            {
                IdBranch=s.IdBranch,
                Branch=s.Branch1,
                Identifier=(Guid)s.Identifier,
                City=s.IdCityNavigation.City1,
                Status=s.Status==true?"Activo":"Inactivo",
                CreationDate=(DateTime)s.CreationDate

            }).Paginar(param.pagina,param.registroPorPagina);

            return data;
        }

        public async Task crearSucursal (CreateBranch obj)
        {
            Branch branch = Mapper<CreateBranch,Branch>.Map(obj);
            await _context.Branches.AddAsync(branch);
            await _context.SaveChangesAsync();
        }
    }
}