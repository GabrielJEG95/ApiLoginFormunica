using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLoginFormunica.Models;

namespace ApiLoginFormunica.Repository
{
    public class EntidadRepository
    {
        private readonly ApiSecFormunicaContext _context;
        public EntidadRepository(ApiSecFormunicaContext context)
        {
            this._context=context;
        }

        public Entidade ObtenerEntidad(int IdEntidad)
        {
            Entidade entidade = _context.Entidades.Find(IdEntidad);
            if(entidade==null)
                return null;
            return entidade;
        }
    }
}