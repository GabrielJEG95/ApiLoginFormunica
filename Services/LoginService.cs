using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ApiLoginFormunica.Models;
using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;
using ApiLoginFormunica.Repository;

namespace ApiLoginFormunica.Services
{
    public interface ILoginService
    {
        string ObtenerCodigo();
        Task<string> ObtenerToken(string code, string state);
        bool tienePermiso (string token,string sistema,string pantalla,string accion);
        //Task<string> GetToken(HttpContext httpContext);
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

        public string ObtenerCodigo()
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
        }

        public string readToken(string Token)
        {
            var handler = new JwtSecurityTokenHandler();
            string authHandler = Token;
            authHandler = authHandler.Replace("Bearer ","");
            var jsonToken = handler.ReadToken(authHandler);
            var tokenS=handler.ReadToken(authHandler) as JwtSecurityToken;
            var email = tokenS.Claims.First(claim => claim.Type == "unique_name").Value;

            return email;
        }

        public bool existeUsuario (string email)
        {
            bool existe = _userRepository.ValidateUserByEmail(email);
            if(!existe)
                return false;
            return true;
        }

        public bool validarUsuario (string email)
        {
            
            bool validate = existeUsuario(email);

            if(!validate)
                return false;
            return true;
        }
        
        public bool tienePermiso (string token,string sistema,string pantalla,string accion)
        {
            string emailRegister = readToken(token);
            bool existeUsuario = validarUsuario(emailRegister);

            if(existeUsuario)
            {
                var user = _userRepository.ObtenerUsuariobyEmail(emailRegister);
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
