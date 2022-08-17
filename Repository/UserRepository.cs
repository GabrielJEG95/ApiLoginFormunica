using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLoginFormunica.Models;

namespace ApiLoginFormunica.Repository
{
    public class UserRepository
    {
        private readonly ApiSecFormunicaContext _context;
        public UserRepository(ApiSecFormunicaContext context)
        {
            this._context=context;
        }
        public User ObtenerUsuario (int IdUsers)
        {
            User user = _context.Users.Find(IdUsers);
            if(user==null)
                return null;
            return user;
        }

        public User ObtenerUsuariobyEmail(string email)
        {
            User user = _context.Users.Where(w => w.Email==email).FirstOrDefault();
            if(user==null)
                return null;
            return user;
        }

        public bool ValidaUser(int IdUsers)
        {
            User user =_context.Users.Find(IdUsers);
            if(user.Status==false)
                return false;
            return true;
        }

        public bool ValidateUserByEmail(string email)
        {
            User user = _context.Users.Where(w => w.Email==email).FirstOrDefault();

            if(user == null || user.Status==false)
                return false;
            return true;
        }

        
    }
}