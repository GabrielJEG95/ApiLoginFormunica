using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ApiLoginFormunica.Models;
using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;
using ApiLoginFormunica.Repository;
using System.DirectoryServices;
using ApiLoginFormunica.Models.Dto;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;

namespace ApiLoginFormunica.Services
{
    public interface ILoginService
    {
        //string ObtenerCodigo();
        //Task<string> ObtenerToken(string code, string state);
        bool tienePermiso (string token,string sistema,string pantalla,string accion);
        int getIdUser (string token);
        string loginAD(loginDto param);
    }
    public class LoginService : ILoginService
    {
        private readonly IConfiguration _configuration;
        private UserRepository _userRepository;
        private EntidadRepository _entidadRepository;
        private PantallaRepository _pantallaRepository;
        private AccionRepository _accionRepository;
        private readonly ApiSecFormunicaContext _context;
        public LoginService(IConfiguration configuration,ApiSecFormunicaContext context)
        {
            this._configuration = configuration;
            this._userRepository=new UserRepository(context);
            this._entidadRepository = new EntidadRepository(context);
            this._pantallaRepository=new PantallaRepository(context);
            this._accionRepository=new AccionRepository(context);
        }

        public bool LoginActiveDirectory(loginDto param)
        {
            try
            {
                string domain = "FORMUNICA.COM";
                

                DirectoryEntry DE = new DirectoryEntry($"LDAP://{domain}",param.UserName,param.Password);
                DirectorySearcher DS = new DirectorySearcher(DE);
                SearchResult result = null;
                result = DS.FindOne();
                
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public string loginAD(loginDto param)
        {
            if(LoginActiveDirectory(param))
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("@formunica_key@2022!"));
                var secutiyKey=new SigningCredentials(secretKey,SecurityAlgorithms.HmacSha256);
                var signingCredentials=new SigningCredentials(secretKey,SecurityAlgorithms.HmacSha256Signature);

                ClaimsIdentity claimsIdentity= new ClaimsIdentity(new[]{new Claim(ClaimTypes.Name,param.UserName)});

                var tokenhandler=new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                var jwtSecurityToken = tokenhandler.CreateJwtSecurityToken(
                    subject:claimsIdentity,
                    expires:DateTime.UtcNow.AddHours(6),
                    signingCredentials:signingCredentials
                    );
                var jwtTokenString = tokenhandler.WriteToken(jwtSecurityToken);
                return jwtTokenString;
            } else {
                throw new Exception("Nombre de Usuario o Contraseña incorrectos");
            }
        }

        
        /*public string ObtenerCodigo()
        {
            string Authorization = _configuration["OAuth:Authorization"];
            string Response = "code";
            string ClientId = _configuration["OAuth:ClientId"];
            string Redirecturi = _configuration["OAuth:RedirectUri"];
            string Scope = _configuration["OAuth:Scope"];
            const string State = "FormunicaSA2022";
            string URL = $"{Authorization}?" + $"response_type={Response}&" + $"client_id={ClientId}&" +
                $"redirect_uri={Redirecturi}&" + $"scope={Scope}&state={State}";

            return URL;
        }

        public async Task<string> ObtenerToken(string code, string state)
        {
            const string Grant_Type = "authorization_code";
            string TokenAPI = _configuration["OAuth:Token"];
            string RedirectUri = _configuration["OAuth:RedirectUri"];
            string ClientId = _configuration["OAuth:ClientId"];
            string SecretKey = _configuration["OAuth:SecretKey"];
            string Scope = _configuration["OAuth:Scope"];

            Dictionary<string, string> data = new Dictionary<string, string>
            {
                {"grant_type",Grant_Type },
                {"code",code },
                {"redirect_uri",RedirectUri },
                {"client_id",ClientId },
                {"client_secret",SecretKey },
                {"scope",Scope}
            };

            HttpClient httpClient = new HttpClient();
            var body = new FormUrlEncodedContent(data);
            var response = await httpClient.PostAsync(TokenAPI, body);
            var Status = $"{(int)response.StatusCode}{response.ReasonPhrase}";
            var JsonContent = await response.Content.ReadFromJsonAsync<JsonElement>();
            var JsonToken =JsonSerializer.Serialize(JsonContent, new JsonSerializerOptions { WriteIndented = true });

            
            var result = JsonSerializer.Deserialize<TokenDto>(JsonToken);
            string token = result.access_token;
            return token;
        }*/

        public string[] readToken(string Token)
        {
            var handler = new JwtSecurityTokenHandler();
            string authHandler = Token;
            authHandler = authHandler.Replace("Bearer ","");
            var jsonToken = handler.ReadToken(authHandler);
            var tokenS=handler.ReadToken(authHandler) as JwtSecurityToken;
            var userName = tokenS.Claims.First(claim => claim.Type == "unique_name").Value;
            var expiracion = tokenS.Claims.First(claim => claim.Type == "exp").Value;

            return new string[] {userName,expiracion};
        }

        public bool existeUsuario (string user)
        {
            bool existe = _userRepository.ValidateUserByUserName(user);
            if(!existe)
                return false;
            return true;
        }

        public bool validarUsuario (string[] tokenInfo)
        {
            
            bool validate = existeUsuario(tokenInfo[0]);
            DateTime actual = DateTime.Now;
            long unixTime = ((DateTimeOffset)actual).ToUnixTimeSeconds();
            long exp = Convert.ToInt32(tokenInfo[1]);
            if(!validate)
                return false;

            if(unixTime>exp)
                return false;
            return true;
        }

        public int getIdUser (string token)
        {
            string[] infoToken = readToken(token);
            var user = _userRepository.ObtenerUsuarioByUsersName(infoToken[0]);
            int Idusers = user.IdUsers;

            return Idusers;

        }
        
        public bool tienePermiso (string token,string sistema,string pantalla,string accion)
        {
            string[] infoToken = readToken(token);
            bool existeUsuario = validarUsuario(infoToken);

            if(existeUsuario)
            {
                var user = _userRepository.ObtenerUsuarioByUsersName(infoToken[0]);
                var entidad = _entidadRepository.ObtenerEntidadByName(sistema);
                var accesoEntidad = _entidadRepository.obtenerAccesoEntidad(entidad.IdEntidad,user.IdUsers);
                if(accesoEntidad!=null)
                {
                    var pantllaAcceso = _pantallaRepository.obtenerPantalla(pantalla);
                    var accesoPantalla = _pantallaRepository.accesoPantalla(pantllaAcceso.IdPantalla,user.IdUsers);
                    if(accesoPantalla != null)
                    {
                        var accionAcceso = _accionRepository.obtenerAccion(accion);
                        var accesoAccion = _accionRepository.accesoAccion(accionAcceso.IdAccion,user.IdUsers);
                        if(accesoAccion != null)
                            return true;
                        return false;
                    }else{
                        return false;
                    }
                }else{
                    return false;
                }
            }
            else
            {
                return false;
            }        
        }
    }
    
}
