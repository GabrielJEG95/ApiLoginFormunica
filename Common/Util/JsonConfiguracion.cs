using System.IO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace Common.Referencia
{

    public class JsonConfiguracion
    {
        // private readonly IConfiguration _configuration;
        // string connString = SSA.Api.Startup.StaticConfig.GetConnectionString("DefaultConnection");

        public static string myJsonString => LeerAppSetting();
        public static JObject myJObject => JLeerAppSetting();

        public static string LeerAppSetting()
        {
            return File.ReadAllText("appsettings.json");
        }

        public static JObject JLeerAppSetting()
        {
            string myJsonString = LeerAppSetting();
            return JObject.Parse(myJsonString);
        }
    }

}