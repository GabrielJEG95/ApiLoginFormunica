using System.Text;
using ApiLoginFormunica.Models;
using ApiLoginFormunica.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.Identity.Web;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
var MyAllowSpecificOrigins = "AllowAnyCorsPolicy";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApiSecFormunicaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("apiSecFormunica"));

});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Login Formunica", Version = "v1" });
        c.AddSecurityDefinition("Bearer",new OpenApiSecurityScheme{
            Description="Encabezado de autorización de JWT usando el esquema Bearer. \r\n\r\n Ingrese 'Bearer' [espacio] y luego su token en la entrada de texto a continuación. \r\n\r\n Ejemplo: \" Bearer 12345abcdef \"",
            Name="Authorization",
            In=ParameterLocation.Header,
            Type=SecuritySchemeType.ApiKey,
            Scheme="Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement{
        {
            new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }
                },
            new string[]{}
        }
    });
});



builder.Services
.Configure<OpenIdConnectOptions>(AzureADDefaults.OpenIdScheme, options =>
{
    options.Authority = options.Authority + "/v2.0/";
    options.ClientId = builder.Configuration["OAuth:ClientId"];
    options.CallbackPath = configuration["OAuth:RedirectUri"];
    options.ResponseType = OpenIdConnectResponseType.CodeIdToken;
    options.RequireHttpsMetadata = false;

    options.TokenValidationParameters.ValidateIssuer = false; 
    options.GetClaimsFromUserInfoEndpoint = true;
    options.SaveTokens = true;
    options.SignInScheme = IdentityConstants.ExternalScheme;
});

builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddTransient<IPersonInterface,PersonInterface>();
builder.Services.AddTransient<ITypeContactService,TypeContactService>();
builder.Services.AddTransient<IContactInformationService,ContactInformationService>();
builder.Services.AddTransient<IUsersService,UsersService>();
builder.Services.AddTransient<IEntidadService,EntidadService>();
builder.Services.AddTransient<ICountryService,CountryService>();
builder.Services.AddTransient<ICityService,CityService>();
builder.Services.AddTransient<IBranchService,BranchService>();
builder.Services.AddTransient<IPantallaService,PantallaService>();
builder.Services.AddTransient<IAccionService,AccionService>();
builder.Services.AddTransient<IActionAuditService,ActionAuditService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
