using ApiLoginFormunica.Models;
using ApiLoginFormunica.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
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

/*builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
}).AddCookie()
.AddOpenIdConnect(opt =>
{
    builder.Configuration.Bind("OAuth",opt);
});*/

builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddTransient<IPersonInterface,PersonInterface>();
builder.Services.AddTransient<ITypeContactService,TypeContactService>();
builder.Services.AddTransient<IContactInformationService,ContactInformationService>();
builder.Services.AddTransient<IUsersService,UsersService>();
builder.Services.AddTransient<IEntidadService,EntidadService>();
builder.Services.AddTransient<ICountryService,CountryService>();
builder.Services.AddTransient<ICityService,CityService>();
builder.Services.AddTransient<IBranchService,BranchService>();

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
