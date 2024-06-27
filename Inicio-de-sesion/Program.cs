// Importa los namespaces necesarios para configurar CORS, Entity Framework Core y los servicios de la aplicaci�n
using Inicio_de_sesion.Models;
using Inicio_de_sesion.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;

// Crea el builder para configurar la aplicaci�n web
var builder = WebApplication.CreateBuilder(args);

// Configura los servicios de CORS para permitir cualquier origen, m�todo y encabezado
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", // Nombre de la pol�tica de CORS
        builder =>
        {
            builder
                .AllowAnyOrigin()  // Permite cualquier origen
                .AllowAnyMethod()  // Permite cualquier m�todo HTTP (GET, POST, etc.)
                .AllowAnyHeader(); // Permite cualquier encabezado
        });
});

// Agrega los servicios al contenedor de inyecci�n de dependencias

// Registra el servicio de usuario para la inyecci�n de dependencias con el ciclo de vida Scoped
//builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();

// Configura el contexto de la base de datos para usar SQL Server

builder.Services.AddDbContext<UserContext>(options =>
{
    // Utiliza la cadena de conexi�n "UserConnection" desde el archivo de configuraci�n
    options.UseSqlServer(builder.Configuration.GetConnectionString("LoginConnection"));
});


// Agrega los controladores al contenedor de servicios
builder.Services.AddControllers();

// Configura Swagger para la documentaci�n de la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Construye la aplicaci�n
var app = builder.Build();

// Configura el pipeline de manejo de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    // Si la aplicaci�n est� en modo desarrollo, usa Swagger y la p�gina de UI de Swagger
    app.UseSwagger();
    app.UseSwaggerUI();

    // Usa la p�gina de excepci�n del desarrollador para mostrar errores detallados
    app.UseDeveloperExceptionPage();
}

// Redirige las solicitudes HTTP a HTTPS
app.UseHttpsRedirection();

// Habilita la pol�tica de CORS configurada anteriormente
app.UseCors("AllowAll");

// Habilita la autorizaci�n
app.UseAuthorization();

// Mapea los controladores a las rutas correspondientes
app.MapControllers();

// Ejecuta la aplicaci�n
app.Run();
