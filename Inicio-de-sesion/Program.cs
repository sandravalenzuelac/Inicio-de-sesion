// Importa los namespaces necesarios para configurar CORS, Entity Framework Core y los servicios de la aplicación
using Inicio_de_sesion.Models;
using Inicio_de_sesion.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;

// Crea el builder para configurar la aplicación web
var builder = WebApplication.CreateBuilder(args);

// Configura los servicios de CORS para permitir cualquier origen, método y encabezado
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", // Nombre de la política de CORS
        builder =>
        {
            builder
                .AllowAnyOrigin()  // Permite cualquier origen
                .AllowAnyMethod()  // Permite cualquier método HTTP (GET, POST, etc.)
                .AllowAnyHeader(); // Permite cualquier encabezado
        });
});

// Agrega los servicios al contenedor de inyección de dependencias

// Registra el servicio de usuario para la inyección de dependencias con el ciclo de vida Scoped
//builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();

// Configura el contexto de la base de datos para usar SQL Server

builder.Services.AddDbContext<UserContext>(options =>
{
    // Utiliza la cadena de conexión "UserConnection" desde el archivo de configuración
    options.UseSqlServer(builder.Configuration.GetConnectionString("LoginConnection"));
});


// Agrega los controladores al contenedor de servicios
builder.Services.AddControllers();

// Configura Swagger para la documentación de la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Construye la aplicación
var app = builder.Build();

// Configura el pipeline de manejo de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    // Si la aplicación está en modo desarrollo, usa Swagger y la página de UI de Swagger
    app.UseSwagger();
    app.UseSwaggerUI();

    // Usa la página de excepción del desarrollador para mostrar errores detallados
    app.UseDeveloperExceptionPage();
}

// Redirige las solicitudes HTTP a HTTPS
app.UseHttpsRedirection();

// Habilita la política de CORS configurada anteriormente
app.UseCors("AllowAll");

// Habilita la autorización
app.UseAuthorization();

// Mapea los controladores a las rutas correspondientes
app.MapControllers();

// Ejecuta la aplicación
app.Run();
