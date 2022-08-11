using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Common.Extensions
{
    public static class HttpClientTokenExtension
    {
        public static void AddBearerToken(this HttpClient client, IHttpContextAccessor context)
        {

            if (context.HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues authToken))
            {
                //var token2 = authToken.First().Split("Bearer ")[1];
                var token = context.HttpContext.Request.Headers["Authorization"].ToString();

                if (!string.IsNullOrEmpty(token))
                {
                    // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", token);
                }
            }
            else
            {
                //throw new ArgumentNullException("Error al tratrar de obtener el Token");
            }
        }
    }
}