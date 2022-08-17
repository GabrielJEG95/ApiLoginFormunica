using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLoginFormunica.Models;

namespace ApiLoginFormunica.Repository
{
    public class AccionRepository
    {
        private readonly ApiSecFormunicaContext _context;
        public AccionRepository(ApiSecFormunicaContext context)
        {
            this._context=context;
        }
        public Accion obtenerAccion(string Accion)
        {
            Accion accion = _context.Accions.Where(w => w.Accion1.ToUpper().Contains(Accion.ToUpper())).FirstOrDefault();
            if(accion==null)
                return null;
            return accion;
        }

        public RelacionAccione accesoAccion(int IdAccion,int IdUser)
        {
            RelacionAccione relacionAccione = _context.RelacionAcciones
                        .Where(w => w.IdAccion==IdAccion && w.IdUsers==IdUser)
                        .FirstOrDefault();
            
            if(relacionAccione==null)
                return null;
            return relacionAccione;
        }
    }
}