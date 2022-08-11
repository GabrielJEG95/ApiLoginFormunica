using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLoginFormunica.Models
{
    public class TokenDto
    {
        public string access_token {get;set;}
        public string token_type {get;set;}
    }
}