using Swashbuckle.AspNetCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IO;
using System.Text;
using Data.dbcontext;
using Controller;
using Entity;

var builder = WebApplication.CreateBuilder(args);

// Configuración de las variables de entorno 
IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

string connectionString = configuration["Configuracion:connectionString"];

// Cliente entity framework
builder.Services.AddScoped<fleetRouteProContext>(provider =>
{
    // Construir e inicializar ClientSql con parámetros
    var fleetRouteProContext = new fleetRouteProContext(connectionString);
    return fleetRouteProContext;
});

//users
builder.Services.AddScoped<authControllogical>();
builder.Services.AddScoped<UsersContrlollogical>();
builder.Services.AddScoped<DAOUsers>();

//rute
builder.Services.AddScoped<RouteControlLogical>();
builder.Services.AddScoped<DAORoutes>();

//vehicles
builder.Services.AddScoped<VehiclesControlLogical>();
builder.Services.AddScoped<DAOVehicles>();

//Drivers
builder.Services.AddScoped<DriversControlLogical>();
builder.Services.AddScoped<DAODrivers>();

//schedules
builder.Services.AddScoped<SchedulesControlLogical>();
builder.Services.AddScoped<DAOSchedules>();


// Add services to the container.
builder.Services.AddRazorPages();

// Configuracion de Cors 
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200/")
                 .AllowAnyHeader()
                 .AllowAnyMethod();
        });
});

// Configuración de la autenticación JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]))
        };
    });

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Middleware de autenticación y autorización
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
