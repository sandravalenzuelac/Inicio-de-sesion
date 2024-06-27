using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Inicio_de_sesion.Models
{
    // Define la clase UserContext que hereda de DbContext, proporcionando acceso a la base de datos
    public class UserContext : DbContext
        {
            // Constructor que acepta opciones y las pasa al constructor base de DbContext
            public UserContext(DbContextOptions<UserContext> options) :
            base(options)
            {

            }

            // Define una propiedad DbSet para la entidad User, que representa la colección de usuarios en la base de datos
            public DbSet<User> Users { get; set; }
        }
    }


