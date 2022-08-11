using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using ApiLoginFormunica.Models;
using Microsoft.IdentityModel.Tokens;

namespace ApiLoginFormunica.Services
{
    public interface IUsersService
    {
        
    }
    public class UsersService:IUsersService
    {
        private readonly ApiSecFormunicaContext _context;
        public UsersService(ApiSecFormunicaContext context)
        {
            this._context=context;
        }

        public void ValidateUser(string token)
        {
            SecurityToken securityToken;
            var tokenHandler = new JwtSecurityTokenHandler();
            
        }
    }
}