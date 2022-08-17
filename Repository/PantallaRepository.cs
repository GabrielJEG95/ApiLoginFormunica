using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLoginFormunica.Models;

namespace ApiLoginFormunica.Repository
{
    public class PantallaRepository
    {
        private readonly ApiSecFormunicaContext _context;
        public PantallaRepository(ApiSecFormunicaContext context)
        {
            this._context=context;
        }
        
        public Pantalla obtenerPantalla(string screen)
        {
            Pantalla pantalla = _context.Pantallas.Where(w => w.Pantalla1.ToUpper().Contains(screen.ToUpper())).FirstOrDefault();
            if(pantalla==null)
                return null;
            return pantalla;
        }

        public RelacionPantalla accesoPantalla(int IdPantalla,int IdUser)
        {
            RelacionPantalla relacionPantalla = _context.RelacionPantallas.Where(w => w.IdPantalla==IdPantalla && w.IdUsers==IdUser).FirstOrDefault();
            if(relacionPantalla==null)
                return null;
            return relacionPantalla;
        }
    }
}