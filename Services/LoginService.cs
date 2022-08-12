using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ApiLoginFormunica.Models;
using Microsoft.AspNetCore.Authentication;

namespace ApiLoginFormunica.Services
{
    public interface ILoginService
    {
        string ObtenerCodigo();
        Task<string> ObtenerToken(string code, string state);
        //Task<string> GetToken(HttpContext httpContext);
    }
    public class LoginService : ILoginService
    {
        private readonly IConfiguration _configuration;
        public LoginService(IConfiguration configuration)
        {
            this._configuration = configuration;
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

        /*public async Task<string> GetToken(HttpContext httpContext)
        {
            var AccesToken = await httpContext.GetTokenAsync("access_token");
            string api = _configuration["OAuth:Api"];

            var httpClient=new HttpClient(); 
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",AccesToken);

            var response = await httpClient.GetAsync(api);

            (string Status,string Content) Model;
            Model.Status = $"{(int)response.StatusCode}{response.ReasonPhrase}";
            if(response.IsSuccessStatusCode)
            {
                var JsonElement = JsonSerializer.Deserialize<JsonElement>(await response.Content.ReadAsStringAsync());

                Model.Content = JsonSerializer.Serialize(JsonElement,new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                });
            }
            else
            {
                Model.Content= await response.Content.ReadAsStringAsync();
            }

            return Model.Content;
            
        }*/
    }

    
}
