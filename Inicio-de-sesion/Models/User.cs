using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Inicio_de_sesion.Models
{
    public class User
    {
            // Marca la propiedad como clave primaria
            [Key]
            // Especifica que el valor de esta propiedad se generará automáticamente por la base de datos
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            // Propiedad para el nombre del usuario
            public string Name { get; set; }

            // Propiedad para el correo electrónico del usuario
            public string Email { get; set; }

            // Propiedad para la contraseña del usuario
            public string Password { get; set; }

            // Propiedad para el número de teléfono del usuario
            public string Phone { get; set; }

            public string Username { get; set; }

    }

}

