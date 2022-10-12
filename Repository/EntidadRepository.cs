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
        public Entidade ObtenerEntidadByName(string entidad)
        {
            Entidade entidade = _context.Entidades.Where(w => w.Entidad.ToUpper().Contains(entidad.ToUpper())).FirstOrDefault();
            if(entidade==null)
                return null;
            return entidade;
        }

        public RelacionEntidade obtenerAccesoEntidad(int IdEntodad,int IdUser)
        {
            RelacionEntidade relacionEntidade = _context.RelacionEntidades.Where(w => w.IdEntidad == IdEntodad && w.IdUsers == IdUser).FirstOrDefault();
            if(relacionEntidade==null)
                return null;
            return relacionEntidade;
        }
    }
}